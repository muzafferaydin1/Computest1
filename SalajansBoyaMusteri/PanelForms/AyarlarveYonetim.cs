using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalajansBoyaMusteri.PanelForms
{
    public partial class AyarlarveYonetim : Form
    {
        public AyarlarveYonetim()
        {
            InitializeComponent();
        }

        private void AyarlarveYonetim_Load(object sender, EventArgs e)
        {
            lblfirmaAdi.Text = KullaniciveFirmaBilgileri.FirmaAdi;
            lblfirmano.Text = KullaniciveFirmaBilgileri.FirmaNo;
            lblfirmaKayitT.Text = KullaniciveFirmaBilgileri.KayitTarihi;
            lblfirmano.Text = KullaniciveFirmaBilgileri.FirmaNo;
            lblfirmaTanimliIP.Text = KullaniciveFirmaBilgileri.TanimliIpAdresi;
            lblfirmaTelefon.Text = KullaniciveFirmaBilgileri.FirmaTelefon;
            lblfirmaAdres.Text = KullaniciveFirmaBilgileri.FirmaAdres;
        }
    }
}
