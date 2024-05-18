using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinancas.API.DTO.Apagar
{
    public class ApagarRequestContract
    {
        public int IdLancamento { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public double ValorOriginal { get; set; } 
        public double ValorPago { get; set; }
        public DateTime? DataReferencia { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}