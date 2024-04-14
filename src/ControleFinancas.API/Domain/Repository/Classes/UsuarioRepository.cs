using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinancas.API.Damain.Models;
using ControleFinancas.API.Data;
using ControleFinancas.API.Domain.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ControleFinancas.API.Domain.Repository.Classes
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public async Task<Usuario> Adicionar(Usuario entidade)
        {
            await  _context.Usuario.AddAsync(entidade);
            await  _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<Usuario> Atualizar(Usuario entidade)
        {
           var usuario = await _context.Usuario.FindAsync(entidade.Id);
            
            if(usuario != null)
            {
                _context.Entry(usuario).CurrentValues.SetValues(entidade);
                _context.Update<Usuario>(usuario);
                await  _context.SaveChangesAsync();
                return entidade;
            }

           return null;
        }

        public Task Deletar(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Obter(string email)
        {
            return await _context.Usuario
                .FirstOrDefaultAsync(x => x.Email == email) 
                ?? throw new Exception("Usuário não encontrado.");
        }

        public async Task<IEnumerable<Usuario>> Obter()
        {
            return await _context.Usuario.OrderBy(x=>x.Id)
                                         .ToListAsync();
        }

        public async Task<Usuario> Obter(long id)
        {
            return await _context.Usuario.FindAsync(id) 
                   ?? throw new Exception("Usuário não encontrado.");
        }
    }
}