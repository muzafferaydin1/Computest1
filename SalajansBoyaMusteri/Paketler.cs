//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalajansBoyaMusteri
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paketler
    {
        public int PaketID { get; set; }
        public string PaketAdi { get; set; }
        public string PaketIcerik { get; set; }
        public string PaketiOlusturan { get; set; }
        public Nullable<System.DateTime> PaketOlusturmaTarihi { get; set; }
        public Nullable<bool> PaketAktifMi { get; set; }
    }
}
