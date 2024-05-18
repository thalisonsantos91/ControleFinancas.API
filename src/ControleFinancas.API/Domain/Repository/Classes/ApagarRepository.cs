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
    
    public class ApagarRepository : IApagarRepository
    {
        private readonly ApplicationContext _contexto;

        public ApagarRepository(ApplicationContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Apagar> Adicionar(Apagar entidade)
        {
           try
            {
                await _contexto.Apagar.AddAsync(entidade);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não é possível salvar esse Apagar, {ex}");
            }

            return entidade;
        }

        public async Task<Apagar> Atualizar(Apagar entidade)
        { 
            var ApagarId = await ConsultarPeloId(entidade);
            
            try
            {
                if (ApagarId != null)
                {
                    _contexto.Entry(ApagarId).CurrentValues.SetValues(entidade);
                    _contexto.Update(ApagarId);
                    await _contexto.SaveChangesAsync();
                    return entidade;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Não é possível Atualizar esse Apagar, {ex}");
            }

            return entidade;
        }

        public async Task Deletar(Apagar entidade)
        { 
            try
            {
                var ApagarId = await ConsultarPeloId(entidade);
                
                if (ApagarId != null)
                {
                    // Exclusão lógica, só altera a data de inativação.
                    entidade.DataInativacao = DateTime.Now;
                    await Atualizar(entidade);
                }
                else
                {
                    throw new Exception($"Não foi possível encontrar " +
                                        $"esse Apagar com Id: {entidade.Id}");
                                        
                }                
            }
            catch (Exception ex)
            {
                throw new Exception($"Não é possível deleter esse Apagar, {ex.Message}", ex);
            }
        } 

        public async Task<IEnumerable<Apagar>> Obter()
        {
            return await _contexto.Apagar.AsNoTracking()
                                           .OrderBy(u => u.Id)
                                           .ToListAsync();
        }   

        public async Task<Apagar?> Obter(int id)
        {
            if (id <= 0)            
                throw new ArgumentException("O ID fornecido é inválido.", nameof(id));          

            return await _contexto.Apagar.AsNoTracking()
                                            .Where(u => u.Id == id)
                                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Apagar>> ObterPeloIdUsuario(int idUsuario)
        {

            if (idUsuario <= 0)            
                throw new ArgumentException("O ID fornecido é inválido.", nameof(idUsuario));

            return await _contexto.Apagar.AsNoTracking()
                                                       .Where(n => n.IdUsuario == idUsuario)
                                                       .OrderBy(n => n.Id)
                                                       .ToListAsync();
        }

        private async Task<Apagar> ConsultarPeloId(Apagar entidade)
        {
            var ApagarId = await _contexto.Apagar.Where(x=>x.Id == entidade.Id).FirstOrDefaultAsync();
            return ApagarId;
        }

    }
}