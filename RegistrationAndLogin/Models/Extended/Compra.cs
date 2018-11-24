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
        [Required(ErrorMessage = "Vezes de pagamento é obrigatória")]
        public int vezesPagamento { get; set; }

        [Display(Name = "Pagamento_ID")]
        [Required(ErrorMessage = "Adicionar uma forma de pagamento é obrigatório")]
        public int PagamentoID { get; set; }

        [Display(Name = "User_ID")]
        [Required(ErrorMessage = "Adicionar uma cliente é obrigatório")]
        public int UserID { get; set; }
    }
}