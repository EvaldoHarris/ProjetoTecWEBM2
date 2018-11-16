using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAndLogin.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class Pacote
    {
    }

    public class PacoteMetaData
    {
        [Display(Name = "Origem")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Origem é obrigatória")]
        public string Origem { get; set; }

        [Display(Name = "Destino")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Destino é obrigatório")]
        public string Destino { get; set; }

        [Display(Name = "Preco")]
        [Required(ErrorMessage = "Preço é obrigatório")]
        public double Preco { get; set; }

        [Display(Name = "Hotel_ID")]
        [Required(ErrorMessage = "Adicionar um hotel é obrigatório")]
        public int HotelID { get; set; }

        [Display(Name = "Voo_ID")]
        [Required(ErrorMessage = "Adicionar um vôo é obrigatório")]
        public long VooID { get; set; }

        [Display(Name = "Promocao")]
        [Required(ErrorMessage = "É necessário indicar se está em promoção ou não")]
        public bool Promocao { get; set; }
    }
}