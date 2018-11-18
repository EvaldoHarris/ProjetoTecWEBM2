using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAndLogin.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class Voo
    {
    }

    public class VooMetadata
    {
        [Display(Name = "qtdPassageiros")]
        [Required(ErrorMessage = "Quantidade de passageiros é obrigatória")]
        public int qtdPassageiros { get; set; }

        [Display(Name = "Empresa")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Empresa é obrigatória")]
        public string Empresa { get; set; }

        [Display(Name = "Origem")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Origem é obrigatória")]
        public string Origem { get; set; }

        [Display(Name = "Destino")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Destino é obrigatório")]
        public string Destino { get; set; }
    }
}