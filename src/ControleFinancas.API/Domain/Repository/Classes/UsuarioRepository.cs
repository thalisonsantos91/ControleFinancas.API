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
            try
            {
                await _context.Usuario.AddAsync(entidade);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não é possível salvar esse Usuário, {ex}");
            }

            return entidade;
        }

        public async Task<Usuario> Atualizar(Usuario entidade)
        {
            var usuario = await _context.Usuario.FindAsync(entidade.Id);
            try
            {
                if (usuario != null)
                {
                    _context.Entry(usuario).CurrentValues.SetValues(entidade);
                    _context.Update<Usuario>(usuario);
                    await _context.SaveChangesAsync();
                    return entidade;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Não é possível Atualizar esse Usuário, {ex}");
            }

            return entidade;
        }

        public async Task Deletar(Usuario entidade)
        {
            try
            {
                var usuario = _context.Usuario.Find(entidade.Id);
                if (usuario != null)
                {
                    _context.Usuario.Remove(usuario);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Não foi possível encontrar esse usuário");
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception($"Não é possível deleter esse Usuário, {ex}");
            }
        }

        public async Task<Usuario> Obter(string email)
        {
            return await _context.Usuario
                .FirstOrDefaultAsync(x => x.Email == email)
                ?? throw new Exception("Usuário não encontrado.");
        }

        public async Task<IEnumerable<Usuario>> Obter()
        {
            return await _context.Usuario.OrderBy(x => x.Id)
                                         .ToListAsync();
        }

        public async Task<Usuario> Obter(int id)
        {
            return await _context.Usuario.FindAsync(id)
                   ?? throw new Exception("Usuário não encontrado.");
        }
    }
}