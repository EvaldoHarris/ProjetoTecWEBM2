using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistrationAndLogin.Models
{
    public class UserLogin
    {
        [Display(Name ="Email")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Email obrigatório")]
        public string EmailID { get; set; }

        [Display(Name = "Senha")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Senha Obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Manter conectado")]
        public bool RememberMe { get; set; }
    }
}