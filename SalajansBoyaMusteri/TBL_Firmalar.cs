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
    
    public partial class TBL_Firmalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_Firmalar()
        {
            this.TBL_Firma_FK = new HashSet<TBL_Firma_FK>();
        }
    
        public int FirmaID { get; set; }
        public string FirmaNo { get; set; }
        public string FirmaAdi { get; set; }
        public string FirmaAdres { get; set; }
        public string FirmaTelefon { get; set; }
        public string FirmaLogo { get; set; }
        public Nullable<System.DateTime> KayitTarihi { get; set; }
        public string FirmaIPAdress { get; set; }
        public string FirmaVersion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Firma_FK> TBL_Firma_FK { get; set; }
    }
}