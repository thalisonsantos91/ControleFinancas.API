using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControleFinancas.API.Damain.Models;

namespace ControleFinancas.API.Domain.Models
{
    public abstract class Titulo
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

        [Required]
        public DateTime DataCadastro { get; set;}        
        
        [Required(ErrorMessage = "O campo de DataVencimento é obrigatório.")]
        public DateTime DataVencimento { get; set;} 
        public DateTime? DataInativacao { get; set; }
        public DateTime? DataReferencia { get; set; }

    }
}