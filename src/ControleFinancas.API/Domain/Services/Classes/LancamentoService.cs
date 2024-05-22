using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFinancas.API.Damain.Models;
using ControleFinancas.API.Domain.Repository.Interfaces;
using ControleFinancas.API.Domain.Services.Interfaces;
using ControleFinancas.API.DTO.Lancamento;
using ControleFinancas.API.Exceptions;

namespace ControleFinancas.API.Domain.Services.Classes
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly IMapper _mapper; 

        public LancamentoService(ILancamentoRepository lancamentoRepository, IMapper mapper)
        {
            _lancamentoRepository = lancamentoRepository;
            _mapper = mapper;            
        }

        public async Task<LancamentoResponseContract> Adicionar(LancamentoRequestContract entidade, int IdUsuario)
        {
            Lancamento lancamento = _mapper.Map<Lancamento>(entidade);
            lancamento.DataCadastro = DateTime.Now;
            lancamento.IdUsuario = IdUsuario;
            lancamento = await _lancamentoRepository.Adicionar(lancamento);

            return _mapper.Map<LancamentoResponseContract>(lancamento);
        }

        public async Task<LancamentoResponseContract> Atualizar(LancamentoRequestContract entidade, int id, int idUsuario)
        {            
            Lancamento lancamento = await ObterIdvinculado(id, idUsuario);
            lancamento.Descricao = entidade.Descricao;
            lancamento.Observacao = entidade.Observacao;
            lancamento.IdUsuario = idUsuario;      
            lancamento =   await _lancamentoRepository.Atualizar(lancamento);

            return _mapper.Map<LancamentoResponseContract>(lancamento);
        }

        public async Task Inativar(int id, int idUsuario)
        {
            Lancamento lancamento = await ObterIdvinculado(id, idUsuario);

            await _lancamentoRepository.Deletar(lancamento);
        }

        public async Task<IEnumerable<LancamentoResponseContract>> Obter(int idUsuario)
        {
            var lancamento = await _lancamentoRepository.ObterPeloIdUsuario(idUsuario);
            return lancamento.Select(natureza => _mapper.Map<LancamentoResponseContract>(natureza));

        }

        public async Task<LancamentoResponseContract> Obter(int id, int idUsuario)
        {
             Lancamento lancamento = await ObterIdvinculado(id, idUsuario);
            
            return _mapper.Map<LancamentoResponseContract>(lancamento);
        }

        private async Task<Lancamento> ObterIdvinculado(int id, int idUsuario)
        {
            var lancamento = await _lancamentoRepository.Obter(id);
            
            if (lancamento is null || lancamento.IdUsuario != idUsuario)
                throw new NotFoundException($"Não foi encontrada nenhum lançamento pelo Id: {id}");

            
            return lancamento;
        }
    }
}