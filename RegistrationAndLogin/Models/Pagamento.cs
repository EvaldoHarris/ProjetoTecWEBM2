using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistrationAndLogin.Models
{
    public class Pagamento
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Display(Name = "Tipo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tipo é obrigatório")]
        public string Tipo { get; set; }
    }
}