using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinancas.API.Damain.Models;
using ControleFinancas.API.Data;
using ControleFinancas.API.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleFinancas.API.Domain.Repository.Classes
{ 
    
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly ApplicationContext _contexto;

        public LancamentoRepository(ApplicationContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Lancamento> Adicionar(Lancamento entidade)
        {
           try
            {
                await _contexto.Lancamento.AddAsync(entidade);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não é possível salvar esse lancamento, {ex}");
            }

            return entidade;
        }

        public async Task<Lancamento> Atualizar(Lancamento entidade)
        { 
            var lancamentoId = ConsultarPeloId(entidade);
            try
            {
                if (lancamentoId != null)
                {
                    _contexto.Entry(lancamentoId).CurrentValues.SetValues(entidade);
                    _contexto.Update(lancamentoId);
                    await _contexto.SaveChangesAsync();
                    return entidade;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Não é possível Atualizar esse lancamento, {ex}");
            }

            return entidade;
        }

        public async Task Deletar(Lancamento entidade)
        { 
            try
            {
                var lancamentoId = ConsultarPeloId(entidade);
                
                if (lancamentoId != null)
                {
                    // Exclusão lógica, só altera a data de inativação.
                    entidade.DataInativacao = DateTime.Now;
                    await _contexto.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Não foi possível encontrar " +
                                        $"esse lancamento com Id: {entidade.Id}");
                                        
                }                
            }
            catch (Exception ex)
            {
                throw new Exception($"Não é possível deleter esse lancamento, {ex.Message}", ex);
            }
        } 

        public async Task<IEnumerable<Lancamento>> Obter()
        {
            return await _contexto.Lancamento.AsNoTracking()
                                           .OrderBy(u => u.Id)
                                           .ToListAsync();
        }   

        public async Task<Lancamento?> Obter(int id)
        {
            if (id <= 0)            
                throw new ArgumentException("O ID fornecido é inválido.", nameof(id));          

            return await _contexto.Lancamento.AsNoTracking()
                                            .Where(u => u.Id == id)
                                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Lancamento>> ObterPeloIdUsuario(int idUsuario)
        {

            if (idUsuario <= 0)            
                throw new ArgumentException("O ID fornecido é inválido.", nameof(idUsuario));

            return await _contexto.Lancamento.AsNoTracking()
                                                       .Where(n => n.IdUsuario == idUsuario)
                                                       .OrderBy(n => n.Id)
                                                       .ToListAsync();
        }

        private async Task<Lancamento> ConsultarPeloId(Lancamento entidade)
        {
            var lancamentoId = await _contexto.Lancamento.FirstOrDefaultAsync(u => u.Id == entidade.Id);
            return lancamentoId;
        }

    }
}