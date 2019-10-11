using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemRH.Models
{
    public partial class TbFuncionario
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range (0,9000,ErrorMessage ="Valor de salário não pode ser superior a R$9.000")]
        public decimal? Salario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int Cargoid { get; set; }

        public virtual TbCargo Cargo { get; set; }
    }
}
