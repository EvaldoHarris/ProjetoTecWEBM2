﻿using System;
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
            public int HotelID { get; set; }

            [Display(Name = "Voo")]
            public long VooID { get; set; }

            [Display(Name = "Quantidade")]
            public int Quantidade { get; set; }

            [Display(Name = "Data_Ida")]
            public DateTime DataIda { get; set; }

            [Display(Name = "Data_Volta")]
            public DateTime DataVolta { get; set; }

            [Display(Name = "Pacote")]
            public virtual Pacote Pacote { get; set; }

            [Display(Name = "Compra")]
            public virtual Compra Compra { get; set; }

            [Display(Name = "Hotel")]
            public virtual Hotel Hotel { get; set; }

            [Display(Name = "Voo")]
            public virtual Voo Voo { get; set; }
        }
    }
}