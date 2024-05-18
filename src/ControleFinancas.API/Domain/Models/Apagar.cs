using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinancas.API.Damain.Models
{
    public class Apagar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        [Required]
        public int IdLancamento { get; set; }

        public Lancamento Lancamento { get; set; }

        [Required(ErrorMessage = "O campo de Descrição é obrigatório.")]
        public string Descricao { get; set; } = string.Empty;

        public string? Observacao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo de ValorOriginal é obrigatório.")]
        public double ValorOriginal { get; set; }
        
        [Required(ErrorMessage = "O campo de ValorPago é obrigatório.")]
        public double ValorPago { get; set; }        

        [Required]
        public DateTime DataCadastro { get; set;}        
        
        [Required(ErrorMessage = "O campo de DataVancimento é obrigatório.")]
        public DateTime DataVancimento { get; set;} 
        public DateTime? DataInativacao { get; set; }
        public DateTime? DataReferencia { get; set; }
        public DateTime? DataPagamento { get; set; }

    }
}