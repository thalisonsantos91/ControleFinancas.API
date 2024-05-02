using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinancas.API.DTO.Usuario
{
    public class UsuarioLoginResponseContract
    {
        public int Id {get;set;} 
        public string Email {get;set;} = string.Empty;
        public Guid Token {get;set;}
    }
}