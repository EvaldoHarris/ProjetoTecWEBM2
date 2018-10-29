using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
//namespace RegistrationAndLogin.Models.Extended
namespace RegistrationAndLogin.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        public string ConfirmPassword { get; set; }
    }

    public class UserMetadata
    {
        [Display(Name ="Primeiro nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="Primeiro nome obrigatorio")]
        public string FirstName { get; set; }

        [Display(Name = "Segundo nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Segundo nome obrigatorio")]
        public string LastName { get; set; }

        [Display(Name ="Email")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Email obrigatorio")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Display(Name ="Data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Senha")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Senha obrigatorio")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Minimo 6 caracteres obrigatorio")]
        public string Password { get; set; }

        [Display(Name = "Comfirmar Senha")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="As senhas não correspondem")]
        public string ConfirmPassword { get; set; }

    }
}