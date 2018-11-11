using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistrationAndLogin.Models
{
    public class Carrinho
    {
        [Display(Name = "Pacote_ID")]
        [Required(ErrorMessage = "Adicionar um pacote é obrigatório")]
        public Pacote PacoteID { get; set; }

        [Display(Name = "Compra_ID")]
        [Required(ErrorMessage = "É obrigatório haver uma compra")]
        public Compra CompraID { get; set; }

        public int Quantidade { get; set; }

        [Display(Name = "Data_Ida")]
        [Required(ErrorMessage = "Data de ida é obrigatória")]
        public DateTime dataIda { get; set; }

        [Display(Name = "Data_Volta")]
        [Required(ErrorMessage = "Data de volta é obrigatória")]
        public DateTime dataVolta { get; set; }
    }
}