//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegistrationAndLogin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Carrinho
    {
        public int PacoteID { get; set; }
        public string Local { get; set; }
        public int CompraID { get; set; }
        public Nullable<int> HotelID { get; set; }
        public Nullable<long> VooID { get; set; }
        public Nullable<System.DateTime> DataIda { get; set; }
        public Nullable<System.DateTime> DataVolta { get; set; }
        public Nullable<int> Quantidade { get; set; }
        public string HotelNome { get; set; }
        public Nullable<int> Dias { get; set; }
    
        public virtual Compra Compra { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual Pacote Pacote { get; set; }
        public virtual Voo Voo { get; set; }
    }
}
