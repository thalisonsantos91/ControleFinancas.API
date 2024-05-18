using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinancas.API.DTO.Lancamento
{
    public class LancamentoRequestContract
    {
        public string Descricao { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
    }
}