using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControleFinancas.API.Domain.Models;

namespace ControleFinancas.API.Damain.Models
{
    public class Apagar : Titulo
    {    
        [Required(ErrorMessage = "O campo de ValorPago é obrigatório.")]
        public double ValorPago { get; set; } 
        public DateTime? DataPagamento { get; set; }

    }
}