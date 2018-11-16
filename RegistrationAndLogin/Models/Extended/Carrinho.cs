using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAndLogin.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class Carrinho
    {
    }

    public class CarrinhoMetaData
    {
        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Quantidade de pacotes é obrigatória")]
        public int Quantidade { get; set; }

        [Display(Name = "Data_Ida")]
        [Required(ErrorMessage = "Data de ida é obrigatória")]
        public DateTime dataIda { get; set; }

        [Display(Name = "Data_Volta")]
        [Required(ErrorMessage = "Data de volta é obrigatória")]
        public DateTime dataVolta { get; set; }
    }
}