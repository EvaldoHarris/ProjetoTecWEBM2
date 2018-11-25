using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAndLogin.Models
{
    [MetadataType(typeof(CompraMetaData))]
    public partial class Compra
    {
    }

    public class CompraMetaData
    {
        [Display(Name = "Vezes_Pagamento")]
        [Range(1,12)]
        public int vezesPagamento { get; set; }

        [Display(Name = "Pagamento_ID")]
        public int PagamentoID { get; set; }

        [Display(Name = "User_ID")]
        public int UserID { get; set; }

        //[Display(Name = "InsiraEmail")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Email é obrigatório")]
        //public string EmailConfirmar { get; set; }

        [Display(Name = "User")]
        public virtual User User { get; set; }
    }
}