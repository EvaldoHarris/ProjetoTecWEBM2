using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistrationAndLogin.Models
{
    public class Pacote
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

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
        public Hotel HotelID { get; set; }

        [Display(Name = "Voo_ID")]
        [Required(ErrorMessage = "Adicionar um vôo é obrigatório")]
        public User VooID { get; set; }
    }
}