using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinancas.API.DTO.Usuario
{
    public class UsuarioResponseContract : UsuarioRequestContract
    {
        public int Id {get; set;}
        public DateTime? DataCadastro {get; set;}
    }
}