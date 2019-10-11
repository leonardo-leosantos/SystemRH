using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemRH.Models
{
    public partial class TbCargo
    {
        public TbCargo()
        {
            TbFuncionario = new HashSet<TbFuncionario>();
        }
        
        [Key]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        public virtual ICollection<TbFuncionario> TbFuncionario { get; set; }
    }
}
