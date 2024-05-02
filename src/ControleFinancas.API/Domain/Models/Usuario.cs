using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinancas.API.Damain.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de E-mail é obrigatório.")]
        public string Email { get; set; } 

        [Required(ErrorMessage = "O campo de Senha é obrigatório.")]
        public string Senha { get; set; } 

        [Required]
        public DateTime DataCadastro { get; set;} 
        public DateTime? DataInativacao { get; set; }

    }
}