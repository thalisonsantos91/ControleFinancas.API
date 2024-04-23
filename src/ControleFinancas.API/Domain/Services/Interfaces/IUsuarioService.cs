using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinancas.API.Damain.Models;
using ControleFinancas.API.DTO.Usuario;

namespace ControleFinancas.API.Domain.Services.Interfaces
{
    public interface IUsuarioService : IService<UsuarioRequestContract, UsuarioResponseContract, long >
    {
        Task<UsuarioLoginResponseContract> Autenticar(UsuarioLoginRequestContract usuarioLoginRequest);
        Task<UsuarioResponseContract> Obter(string email);
    }
}