using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAndLogin.Models
{
    [MetadataType(typeof(HotelMetadata))]
    public partial class Hotel
    {
    }

    public class HotelMetadata
    {
        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Local")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Estado é obrigatório")]
        public string Local { get; set; }

        [Display(Name = "Diária")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Preço da diária é obrigatório")]
        public decimal Diaria { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Imagem")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Inserir imagem é obrigatório")]
        public string Imagem { get; set; }

        [Display(Name = "Estrelas")]
        [Range(1, 5)]
        [Required(ErrorMessage = "Número de estrelas é obrigatório")]
        public int Estrelas { get; set; }
    }
}