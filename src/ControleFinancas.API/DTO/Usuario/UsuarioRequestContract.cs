using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinancas.API.DTO.Usuario
{
    public class UsuarioRequestContract : UsuarioLoginRequestContract
    {
        public DateTime? DataInativacao {get; set;}
    }
}