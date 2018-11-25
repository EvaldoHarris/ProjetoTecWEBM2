using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAndLogin.Models
{
    [MetadataType(typeof(PacoteMetaData))]
    public partial class Pacote
    {
    }

    public class PacoteMetaData
    {
        [Display(Name = "Local")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Local é obrigatório")]
        public string Local { get; set; }

        [Display(Name = "Preco")]
        [Required(ErrorMessage = "Preço é obrigatório")]
        public double Preco { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Imagem")]
        [Required(ErrorMessage = "Inserir imagem é obrigatório")]
        public string Imagem { get; set; }

        [Display(Name = "Promocao")]
        [Required(ErrorMessage = "É necessário indicar se está em promoção ou não")]
        public bool Promocao { get; set; }
    }
}