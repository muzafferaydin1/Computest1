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
    
    public partial class TBL_ARACBOYASONUC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ARACBOYASONUC()
        {
            this.TBL_MUSTERIARACLARI = new HashSet<TBL_MUSTERIARACLARI>();
        }
    
        public int BoyaRaporID { get; set; }
        public string SolOnCamurluk { get; set; }
        public string SolOnKapi { get; set; }
        public string SolArkaKapi { get; set; }
        public string SolArkaCamurluk { get; set; }
        public string SagOnCamurluk { get; set; }
        public string SagOnKapi { get; set; }
        public string SagArkaKapi { get; set; }
        public string SagArkaCamurluk { get; set; }
        public string Bagaj { get; set; }
        public string Kaput { get; set; }
        public string Tavan { get; set; }
        public string TestSonucu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MUSTERIARACLARI> TBL_MUSTERIARACLARI { get; set; }
    }
}