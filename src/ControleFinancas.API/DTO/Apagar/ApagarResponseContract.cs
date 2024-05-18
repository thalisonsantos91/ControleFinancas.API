using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinancas.API.DTO.Apagar
{
    public class ApagarResponseContract : ApagarRequestContract

    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataInativacao { get; set; }

    }
}