using AutoMapper;
using ControleFinancas.API.Damain.Models;
using ControleFinancas.API.Domain.Repository.Interfaces;
using ControleFinancas.API.Domain.Services.Interfaces;
using ControleFinancas.API.DTO.Apagar;

namespace ControleFinancas.API.Domain.Services.Classes
{
    public class ApagarService : IApagarService
    {
        private readonly IApagarRepository _apagarRepository;
        private readonly IMapper _mapper; 

        public ApagarService(IApagarRepository apagarRepository, IMapper mapper)
        {
            _apagarRepository = apagarRepository;
            _mapper = mapper;            
        }

        public async Task<ApagarResponseContract> Adicionar(ApagarRequestContract entidade, int IdUsuario)
        {
            Apagar Apagar = _mapper.Map<Apagar>(entidade);
            Apagar.DataCadastro = DateTime.Now;
            Apagar.IdUsuario = IdUsuario;
            Apagar = await _apagarRepository.Adicionar(Apagar);

            return _mapper.Map<ApagarResponseContract>(Apagar);
        }

        public async Task<ApagarResponseContract> Atualizar(ApagarRequestContract entidade, int id, int idUsuario)
        {            
            Apagar apagar = await ObterIdvinculado(id, idUsuario);

            var contrato = _mapper.Map<Apagar>(entidade);
            contrato.IdUsuario = apagar.IdUsuario;
            contrato.Id = apagar.Id;
            contrato.DataCadastro = apagar.DataCadastro; 
           
            contrato =   await _apagarRepository.Atualizar(contrato);

            return _mapper.Map<ApagarResponseContract>(contrato);
        }

        public async Task Inativar(int id, int idUsuario)
        {
            Apagar apagar = await ObterIdvinculado(id, idUsuario);

            await _apagarRepository.Deletar(apagar);
        }

        public async Task<IEnumerable<ApagarResponseContract>> Obter(int idUsuario)
        {
            var titulosApagar = await _apagarRepository.ObterPeloIdUsuario(idUsuario);
            return titulosApagar.Select(titulo => _mapper.Map<ApagarResponseContract>(titulo));
        }

        public async Task<ApagarResponseContract> Obter(int id, int idUsuario)
        {
             Apagar apagar = await ObterIdvinculado(id, idUsuario);
            
            return _mapper.Map<ApagarResponseContract>(apagar);
        }

        private async Task<Apagar> ObterIdvinculado(int id, int idUsuario)
        {
            var apagar = await _apagarRepository.Obter(id);
            
            if (apagar is null || apagar.IdUsuario != idUsuario)
                throw new Exception($"Não foi encontrada nenhum titulo apagar pelo Id: {id}");

            
            return apagar;
        }
    }
}