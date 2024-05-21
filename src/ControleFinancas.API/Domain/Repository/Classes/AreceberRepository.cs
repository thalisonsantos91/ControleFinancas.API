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
    
    public class AreceberRepository : IAreceberRepository
    {
        private readonly ApplicationContext _contexto;

        public AreceberRepository(ApplicationContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Areceber> Adicionar(Areceber entidade)
        {
           try
            {
                await _contexto.Areceber.AddAsync(entidade);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não é possível salvar esse Areceber, {ex}");
            }

            return entidade;
        }

        public async Task<Areceber> Atualizar(Areceber entidade)
        { 
            var areceberId = await ConsultarPeloId(entidade);
            
            try
            {
                if (areceberId != null)
                {
                    _contexto.Entry(areceberId).CurrentValues.SetValues(entidade);
                    _contexto.Update(areceberId);
                    await _contexto.SaveChangesAsync();
                    return entidade;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Não é possível Atualizar esse Areceber, {ex}");
            }

            return entidade;
        }

        public async Task Deletar(Areceber entidade)
        { 
            try
            {
                var areceberId = await ConsultarPeloId(entidade);
                
                if (areceberId != null)
                {
                    // Exclusão lógica, só altera a data de inativação.
                    entidade.DataInativacao = DateTime.Now;
                    await Atualizar(entidade);
                }
                else
                {
                    throw new Exception($"Não foi possível encontrar " +
                                        $"esse Areceber com Id: {entidade.Id}");
                                        
                }                
            }
            catch (Exception ex)
            {
                throw new Exception($"Não é possível deleter esse Areceber, {ex.Message}", ex);
            }
        } 

        public async Task<IEnumerable<Areceber>> Obter()
        {
            return await _contexto.Areceber.AsNoTracking()
                                           .OrderBy(u => u.Id)
                                           .ToListAsync();
        }   

        public async Task<Areceber?> Obter(int id)
        {
            if (id <= 0)            
                throw new ArgumentException("O ID fornecido é inválido.", nameof(id));          

            return await _contexto.Areceber.AsNoTracking()
                                            .Where(u => u.Id == id)
                                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Areceber>> ObterPeloIdUsuario(int idUsuario)
        {

            if (idUsuario <= 0)            
                throw new ArgumentException("O ID fornecido é inválido.", nameof(idUsuario));

            return await _contexto.Areceber.AsNoTracking()
                                                       .Where(n => n.IdUsuario == idUsuario)
                                                       .OrderBy(n => n.Id)
                                                       .ToListAsync();
        }

        private async Task<Areceber> ConsultarPeloId(Areceber entidade)
        {
            var areceberId = await _contexto.Areceber.Where(x=>x.Id == entidade.Id).FirstOrDefaultAsync();
            return areceberId;
        }

    }
}