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
    
    public partial class TBL_Firma_FK
    {
        public int FirmaID { get; set; }
        public Nullable<int> LisansID { get; set; }
        public Nullable<int> KullaniciID { get; set; }
        public int ID { get; set; }
    
        public virtual TBL_Firmalar TBL_Firmalar { get; set; }
        public virtual TBL_FirmaPCKeys TBL_FirmaPCKeys { get; set; }
        public virtual TBL_Kullanicilar TBL_Kullanicilar { get; set; }
    }
}