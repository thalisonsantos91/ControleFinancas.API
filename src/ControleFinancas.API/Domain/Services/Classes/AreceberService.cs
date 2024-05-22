using AutoMapper;
using ControleFinancas.API.Damain.Models;
using ControleFinancas.API.Domain.Repository.Interfaces;
using ControleFinancas.API.Domain.Services.Interfaces;
using ControleFinancas.API.DTO.Apagar;
using ControleFinancas.API.DTO.Areceber;

namespace ControleFinancas.API.Domain.Services.Classes
{
    public class AreceberService : IAreceberService
    {
        private readonly IAreceberRepository _areceberRepository;
        private readonly IMapper _mapper; 

        public AreceberService(IAreceberRepository areceberRepository, IMapper mapper)
        {
            _areceberRepository = areceberRepository;
            _mapper = mapper;            
        }

        public async Task<AreceberResponseContract> Adicionar(AreceberRequestContract entidade, int IdUsuario)
        {
            Areceber areceber = _mapper.Map<Areceber>(entidade);
            areceber.DataCadastro = DateTime.Now;
            areceber.IdUsuario = IdUsuario;
            areceber = await _areceberRepository.Adicionar(areceber);

            return _mapper.Map<AreceberResponseContract>(areceber);
        }

        public async Task<AreceberResponseContract> Atualizar(AreceberRequestContract entidade, int id, int idUsuario)
        {            
            Areceber areceber = await ObterIdvinculado(id, idUsuario);

            var contrato = _mapper.Map<Areceber>(entidade);
            contrato.IdUsuario = areceber.IdUsuario;
            contrato.Id = areceber.Id;
            contrato.DataCadastro = areceber.DataCadastro; 
           
            contrato =   await _areceberRepository.Atualizar(contrato);

            return _mapper.Map<AreceberResponseContract>(contrato);
        }

        public async Task Inativar(int id, int idUsuario)
        {
            Areceber areceber = await ObterIdvinculado(id, idUsuario);

            await _areceberRepository.Deletar(areceber);
        }

        public async Task<IEnumerable<AreceberResponseContract>> Obter(int idUsuario)
        {
            var contasAreceber = await _areceberRepository.ObterPeloIdUsuario(idUsuario);
            return contasAreceber.Select(contas => _mapper.Map<AreceberResponseContract>(contas));
        }

        public async Task<AreceberResponseContract> Obter(int id, int idUsuario)
        {
             Areceber areceber = await ObterIdvinculado(id, idUsuario);
            
            return _mapper.Map<AreceberResponseContract>(areceber);
        }

        private async Task<Areceber> ObterIdvinculado(int id, int idUsuario)
        {
            var areceber = await _areceberRepository.Obter(id);
            
            if (areceber is null || areceber.IdUsuario != idUsuario)
                throw new Exception($"Não foi encontrada nenhuma conta a areceber pelo Id: {id}");

            
            return areceber;
        }
    }
}