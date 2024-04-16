using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinancas.API.Domain.Repository.Interfaces;
using ControleFinancas.API.Domain.Services.Interfaces;
using ControleFinancas.API.DTO.Usuário;

namespace ControleFinancas.API.Domain.Services.Classes
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Task<UsuarioLoginResponseContract> Adicionar(UsuarioLoginRequestContract entidade, long usuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioLoginResponseContract> Atualizar(UsuarioLoginRequestContract entidade, long id, long usuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioLoginResponseContract> Autenticar(UsuarioLoginRequestContract usuarioLoginRequest)
        {
            throw new NotImplementedException();
        }

        public Task Inativar(long id, long usuario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioLoginResponseContract>> Obter(long usuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioLoginResponseContract> Obter(long id, long usuario)
        {
            throw new NotImplementedException();
        }
    }
}