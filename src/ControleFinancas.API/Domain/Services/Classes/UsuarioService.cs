using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ControleFinancas.API.DTO.Usuario;
using ControleFinancas.API.Damain.Models;
using ControleFinancas.API.Domain.Services.Interfaces;
using ControleFinancas.API.Domain.Repository.Interfaces;

namespace ControleFinancas.API.Damain.Services.Classes
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        // private readonly TokenService _tokenService;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IMapper mapper
            )
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

         public Task<UsuarioLoginResponseContract> Autenticar(UsuarioLoginRequestContract usuarioLoginRequest)
        {
            throw new NotImplementedException();
        }
        
        public async Task<UsuarioResponseContract> Adicionar(UsuarioRequestContract entidade, long IdUsuario)
        {
            var usuario = _mapper.Map<Usuario>(entidade);
            usuario.Senha = GerarHashSenha(usuario.Senha);
            usuario = await _usuarioRepository.Adicionar(usuario);            
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }      

        public async Task<UsuarioResponseContract> Atualizar(UsuarioRequestContract entidade, long id, long idUsuario)
        {
            var validandoId = await Obter(id) ?? throw new Exception("Usuário não encontrado para Atualização.");
            var usuario = _mapper.Map<Usuario>(entidade);
            usuario.Id = id;
            usuario.Senha = GerarHashSenha(entidade.Senha);

            usuario =   await _usuarioRepository.Atualizar(usuario);
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }

        public async Task Inativar(long id, long idUsuario)
        {
            var usuario = await Obter(id) ?? throw new Exception("Usuário não encontrado para Inativação.");
            await _usuarioRepository.Deletar(_mapper.Map<Usuario>(usuario));
        }

        public async Task<IEnumerable<UsuarioResponseContract>> Obter(long idUsuario)
        {
           return await Obter(idUsuario);
        }

        public async Task<UsuarioResponseContract> Obter(long id, long idUsuario)
        {
            var usuario = await _usuarioRepository.Obter(id);
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }

        public async Task<UsuarioResponseContract> Obter(string email)
        {
           var usuario = await _usuarioRepository.Obter(email);

           return _mapper.Map<UsuarioResponseContract>(usuario);
        }

        private string GerarHashSenha(string senha)
        {
            string hashSenha =string.Empty; 

            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] bytesSenha = Encoding.UTF8.GetBytes(senha);
                byte[] bytesHashSenha = sha256.ComputeHash(bytesSenha);   
                hashSenha  =  BitConverter.ToString(bytesHashSenha).ToLower();         
            }
            return hashSenha;
        }
    }
}