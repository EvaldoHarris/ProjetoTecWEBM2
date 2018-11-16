using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAndLogin.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class Hotel
    {
    }

    public class HotelMetadata
    {
        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Estado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Estado é obrigatório")]
        public string Estado { get; set; }

        [Display(Name = "Cidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Cidade é obrigatória")]
        public string Cidade { get; set; }

        [Display(Name = "Estrelas")]
        [Range(1, 5)]
        [Required(ErrorMessage = "Número de estrelas é obrigatório")]
        public int Estrelas { get; set; }
    }
}