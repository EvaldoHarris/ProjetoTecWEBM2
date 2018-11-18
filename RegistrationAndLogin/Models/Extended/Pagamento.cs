using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAndLogin.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class Pagamento
    {
    }

    public class PagamentoMetaData
    {
        [Display(Name = "Tipo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tipo é obrigatório")]
        public string Tipo { get; set; }
    }
}