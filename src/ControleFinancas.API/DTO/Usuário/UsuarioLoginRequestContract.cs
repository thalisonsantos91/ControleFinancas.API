using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinancas.API.DTO.Usuário
{
    public class UsuarioLoginRequestContract
    {
        public string Email {get;set;} = string.Empty;
        public string Senha {get;set;} = string.Empty;
    }       
}