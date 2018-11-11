using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAndLogin.Models
{
    public class Compra
    {
        [Display(Name = "Id")]
        public long ID { get; set; }

        [Display(Name = "Pagamento_ID")]
        [Required(ErrorMessage = "Adicionar uma forma de pagamento é obrigatório")]
        public Pagamento PagamentoID { get; set; }

        [Display(Name = "Vezes")]
        [Required(ErrorMessage = "Vezes de pagamento é obrigatória")]
        public int Vezes { get; set; }

        [Display(Name = "User_ID")]
        [Required(ErrorMessage = "Adicionar uma cliente é obrigatório")]
        public User UserID { get; set; }

        [Display(Name = "Preco_Total")]
        public double PrecoTotal { get; }
    }
}