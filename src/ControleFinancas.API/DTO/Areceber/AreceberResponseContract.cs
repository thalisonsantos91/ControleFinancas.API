using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinancas.API.DTO.Areceber
{
    public class AreceberResponseContract : AreceberRequestContract

    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataInativacao { get; set; }

    }
}