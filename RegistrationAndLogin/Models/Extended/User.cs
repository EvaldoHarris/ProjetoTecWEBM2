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

        [Display(Name = "CPF")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CPF obrigatorio")]
        public string CPF { get; set; }

        [Display(Name = "RG")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RG obrigatorio")]
        public string RG { get; set; }

        [Display(Name = "Estado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Estado obrigatorio")]
        //[DataType(DataType.EmailAddress)]
        public string Estado { get; set; }

        [Display(Name = "Cidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "cidade obrigatorio")]
        public string Cidade { get; set; }

        [Display(Name = "Renda")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Renda obrigatorio")]
        public string Renda { get; set; }

        [Display(Name = "Dependentes")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Dependentes obrigatorio")]
        public string Dependentes { get; set; }

        [Display(Name = "Telefone")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Telefone obrigatorio")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Display(Name = "CEP")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CEP obrigatorio")]
        public string CEP { get; set; }

        [Display(Name = "Endereço")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Endereço obrigatorio")]
        //[DataType(DataType.EmailAddress)]
        public string Endereço { get; set; }

        [Display(Name = "Numero")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Numero obrigatorio")]
        //[DataType(DataType.EmailAddress)]
        public string Numero { get; set; }

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