﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Calisanlar> Calisanlar { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<musteri> musteri { get; set; }
        public virtual DbSet<Paketler> Paketler { get; set; }
        public virtual DbSet<Randevular> Randevular { get; set; }
        public virtual DbSet<Raporlar> Raporlar { get; set; }
        public virtual DbSet<TBL_ARACBOYASONUC> TBL_ARACBOYASONUC { get; set; }
        public virtual DbSet<TBL_BOYADEGERLERI> TBL_BOYADEGERLERI { get; set; }
        public virtual DbSet<TBL_BOYAKONUMLARI> TBL_BOYAKONUMLARI { get; set; }
        public virtual DbSet<TBL_Firma_FK> TBL_Firma_FK { get; set; }
        public virtual DbSet<TBL_Firmalar> TBL_Firmalar { get; set; }
        public virtual DbSet<TBL_FirmaPCKeys> TBL_FirmaPCKeys { get; set; }
        public virtual DbSet<TBL_FK> TBL_FK { get; set; }
        public virtual DbSet<tbl_iletisim> tbl_iletisim { get; set; }
        public virtual DbSet<TBL_Kullanicilar> TBL_Kullanicilar { get; set; }
        public virtual DbSet<TBL_MUSTERIARACLARI> TBL_MUSTERIARACLARI { get; set; }
        public virtual DbSet<TBL_MUSTERILER> TBL_MUSTERILER { get; set; }
        public virtual DbSet<TBL_ODEMELER> TBL_ODEMELER { get; set; }
        public virtual DbSet<TBLARACSERISI> TBLARACSERISI { get; set; }
        public virtual DbSet<TBLARACVERSIYON> TBLARACVERSIYON { get; set; }
        public virtual DbSet<TBLMARKA> TBLMARKA { get; set; }
        public virtual DbSet<TBLMODEL> TBLMODEL { get; set; }
        public virtual DbSet<Urunler> Urunler { get; set; }
        public virtual DbSet<WebBoyaRapor> WebBoyaRapor { get; set; }
        public virtual DbSet<yedekparcalistesi> yedekparcalistesi { get; set; }
        public virtual DbSet<lisans> lisans { get; set; }
        public virtual DbSet<TBL_YEDEKLER> TBL_YEDEKLER { get; set; }
    }
}
