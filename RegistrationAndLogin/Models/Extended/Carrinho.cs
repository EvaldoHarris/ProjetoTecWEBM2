using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAndLogin.Models
{
    [MetadataType(typeof(CarrinhoMetaData))]
    public partial class Carrinho
    {
        public class CarrinhoMetaData
        {
            [Display(Name = "Pacote")]
            [Required(ErrorMessage = "Pacote é obrigatório")]
            public int PacoteID { get; set; }

            [Display(Name = "Compra")]
            [Required(ErrorMessage = "É necessário estar em uma compra")]
            public int CompraID { get; set; }

            [Display(Name = "Hotel")]
            [Required(ErrorMessage = "Hotel é obrigatório")]
            public int HotelID { get; set; }

            [Display(Name = "Voo")]
            [Required(ErrorMessage = "Voo é obrigatório")]
            public long VooID { get; set; }

            [Display(Name = "Quantidade")]
            [Required(ErrorMessage = "Quantidade de pacotes é obrigatória")]
            public int Quantidade { get; set; }

            [Display(Name = "Data_Ida")]
            [Required(ErrorMessage = "Data de ida é obrigatória")]
            public DateTime DataIda { get; set; }

            [Display(Name = "Data_Volta")]
            [Required(ErrorMessage = "Data de volta é obrigatória")]
            public DateTime DataVolta { get; set; }
        }
    }
}