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
    
    public partial class TBL_ODEMELER
    {
        public int ID { get; set; }
        public Nullable<int> AracID { get; set; }
        public Nullable<int> MusteriID { get; set; }
        public string OdemeSekli { get; set; }
        public Nullable<bool> OdemeDurumu { get; set; }
        public Nullable<decimal> OdemeTutari { get; set; }
        public Nullable<System.DateTime> OdemeTarihi { get; set; }
    
        public virtual TBL_MUSTERIARACLARI TBL_MUSTERIARACLARI { get; set; }
        public virtual TBL_MUSTERILER TBL_MUSTERILER { get; set; }
    }
}
