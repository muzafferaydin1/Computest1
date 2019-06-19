using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalajansBoyaMusteri.PanelForms
{
    public partial class MusteriveRaporList : Form
    {
        public MusteriveRaporList()
        {
            InitializeComponent();

        }


        private void RaporEkrani_Load(object sender, EventArgs e)
        {
            cbhizliara.SelectedIndex = 0;
            VeriGetir();
            GridAyarlari();
        }

        private void GridAyarlari()
        {
            dtmusterivearaclar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtmusterivearaclar.Columns[0].Name = "Alıcı Ad/Soyad";
            dtmusterivearaclar.Columns[0].HeaderText = "Alıcı Ad/Soyad";

            dtmusterivearaclar.Columns[1].Name = "Alıcı Telefon";
            dtmusterivearaclar.Columns[1].HeaderText = "Alıcı Telefon";
            dtmusterivearaclar.Columns[1].DefaultCellStyle.Format = "(###) ###-####";
 

            dtmusterivearaclar.Columns[2].Name = "Araç Bilgisi";
            dtmusterivearaclar.Columns[2].HeaderText = "Araç Bilgisi";

            dtmusterivearaclar.Columns[3].Name = "Plaka";
            dtmusterivearaclar.Columns[3].HeaderText = "Plaka";

            dtmusterivearaclar.Columns[4].Name = "Tutar";
            dtmusterivearaclar.Columns[4].HeaderText = "Tutar";
            dtmusterivearaclar.Columns[4].DefaultCellStyle.Format = "C";


            dtmusterivearaclar.Columns[5].Name = "Barkod";
            dtmusterivearaclar.Columns[5].HeaderText = "Barkod";

            dtmusterivearaclar.Columns[6].Name = "Tarih";
            dtmusterivearaclar.Columns[6].HeaderText = "Tarih";

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Gelişmiş";
            btn.Text = "Rapor Aç";
            btn.Name = "btn";
            
            btn.UseColumnTextForButtonValue = true;

            btn.FlatStyle = FlatStyle.System;

            dtmusterivearaclar.Columns.Add(btn);
            dtmusterivearaclar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtmusterivearaclar.MultiSelect = false;
            dtmusterivearaclar.Columns[dtmusterivearaclar.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            txtbarkod.Focus();

            pnlozelarama.Enabled = false;
            dttarih1.Text = DateTime.Today.AddDays(-7).ToShortDateString();
        }

        List<musteri> eskidb = null;
        private void btnyenile_Click(object sender, EventArgs e)
        {
            VeriGetir();
        }


        private void txtaramayap_TextChanged(object sender, EventArgs e)
        {
            DBEntities db = new DBEntities();
            string aranan = txtaramayap.Text;

            List<musterilistesi> sepet = new List<musterilistesi>();

            sepet = (from ymusteri in db.TBL_MUSTERILER
                     join fk in db.TBL_FK
                     on ymusteri.MusteriID equals fk.MusteriID
                     join arac in db.TBL_MUSTERIARACLARI
                     on fk.AracID equals arac.AracID
                     join odeme in db.TBL_ODEMELER
                     on fk.MusteriID equals odeme.MusteriID
                     where ymusteri.SaticiTelefon.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Contains(aranan) ||
                     ymusteri.AliciTelefon.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Contains(aranan) ||
                     ymusteri.AliciAdsoyad.Contains(aranan) || 
                     arac.MarkaveTip.Contains(aranan) ||
                     arac.Plaka.Contains(aranan) ||
                     ymusteri.BarkodNo.Contains(aranan)
                     select new musterilistesi
                     {

                         MusteriAdSoyad = ymusteri.AliciAdsoyad,
                         AliciTelefon = ymusteri.AliciTelefon.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""), 
                         AracMarkaTip = arac.MarkaveTip,
                         AracPlakasi = arac.Plaka,
                         OdemeTutari = odeme.OdemeTutari,
                         BarkodNo = ymusteri.BarkodNo,
                         Tarih = odeme.OdemeTarihi,

                     }).OrderByDescending(x => x.Tarih).ToList();

            eskidb = db.musteri.Where(x => x.aracplakasi.Contains(aranan) || x.musteriadi.Contains(aranan) || x.musterisoyadi.Contains(aranan) || x.musteritelefon.Contains(aranan)).ToList();

            var eskisonuclar = (from musteri in eskidb
                                select new musterilistesi
                                {
                                    MusteriAdSoyad = musteri.musteriadi + " " + musteri.musterisoyadi,
                                    AliciTelefon = musteri.musteritelefon, 
                                    AracMarkaTip = musteri.aracadi,
                                    AracPlakasi = musteri.aracplakasi,
                                    OdemeTutari = musteri.aracservisucreti,
                                    BarkodNo = musteri.MusteriID.ToString(),
                                    Tarih = musteri.tarih,
                                }).ToList();

            sepet.AddRange(eskisonuclar);

            dtmusterivearaclar.DataSource = sepet;


        }
        private void lbleskikayitsonuc_Click(object sender, EventArgs e)
        {
            DBEntities db = new DBEntities();
            dtmusterivearaclar.DataSource = null;
            dtmusterivearaclar.DataSource = (from musteri in eskidb
                                             select new
                                             {

                                                 musteriAdSoyad = musteri.musteriadi + " " + musteri.musterisoyadi,
                                                 musteri.musteritelefon, 
                                                 musteri.aracadi,
                                                 musteri.aracplakasi,
                                                 musteri.aracservisucreti,
                                                 barkod = "BARKOD YOK",
                                                 musteri.tarih
                                             }).OrderByDescending(x => x.tarih).ToList();

        }
        private void rdhizliarama_CheckedChanged(object sender, EventArgs e)
        {
            pnlhizliara.Enabled = true;
            pnlozelarama.Enabled = false;
            VeriGetir();
            cbhizliara.SelectedIndex = 0;
        }

        private void rdozelarama_CheckedChanged(object sender, EventArgs e)
        {
            pnlozelarama.Enabled = true;
            pnlhizliara.Enabled = false;

        }

        private void cbhizliara_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DateTime baslangic = DateTime.Today;
                DateTime bitis = DateTime.Today.AddDays(1).AddTicks(-1);
                if (cbhizliara.SelectedIndex == 0)
                {
                    VeriGetir();
                }
                if (cbhizliara.SelectedIndex != 0)
                {
                    if (cbhizliara.SelectedIndex == 1)
                    {
                        baslangic = DateTime.Now.AddDays(-1);
                        bitis = baslangic.AddDays(1).AddTicks(-1);
                    }

                    else if (cbhizliara.SelectedIndex == 2)
                    {
                        baslangic = (baslangic.AddDays(-1)).ToDateTime();
                        bitis = baslangic.AddDays(1).AddTicks(-1);
                    }
                    else if (cbhizliara.SelectedIndex == 3)
                    {
                        baslangic = (baslangic.AddDays(-7)).ToDateTime();
                        bitis = baslangic.AddDays(7).AddTicks(-1);
                    }
                    else if (cbhizliara.SelectedIndex == 4)
                    {
                        baslangic = (baslangic.AddDays(-30)).ToDateTime();
                        bitis = baslangic.AddDays(30).AddTicks(-1);
                    }

                    VeriTariheGore(baslangic, bitis);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnkayitbul_Click(object sender, EventArgs e)
        {
            VeriTariheGore(dttarih1.Text.ToDateTime(), dttarih2.Text.ToDateTime().AddHours(23).AddMinutes(59).AddSeconds(59));
        }

        private void VeriGetir()
        {
            DBEntities db = new DBEntities();
            List<musterilistesi> sepet = new List<musterilistesi>();

            sepet = (from ymusteri in db.TBL_MUSTERILER
                     join fk in db.TBL_FK
                     on ymusteri.MusteriID equals fk.MusteriID
                     join arac in db.TBL_MUSTERIARACLARI
                     on fk.AracID equals arac.AracID
                     join odeme in db.TBL_ODEMELER
                     on fk.MusteriID equals odeme.MusteriID
                     select new musterilistesi
                     {
                         MusteriAdSoyad = ymusteri.AliciAdsoyad,
                         AliciTelefon = ymusteri.AliciTelefon.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""), 
                         AracMarkaTip = arac.MarkaveTip,
                         AracPlakasi = arac.Plaka,
                         OdemeTutari = odeme.OdemeTutari,
                         BarkodNo = ymusteri.BarkodNo.ToString(),
                         Tarih = odeme.OdemeTarihi,
                     }).OrderByDescending(x => x.Tarih).ToList();

            var eskisonuclar = (from musteri in db.musteri
                                select new musterilistesi
                                {
                                    MusteriAdSoyad = musteri.musteriadi + " " + musteri.musterisoyadi,
                                    AliciTelefon = musteri.musteritelefon, 
                                    AracMarkaTip = musteri.aracadi,
                                    AracPlakasi = musteri.aracplakasi,
                                    OdemeTutari = musteri.aracservisucreti,
                                    BarkodNo = musteri.MusteriID.ToString(),
                                    Tarih = musteri.tarih,
                                }).ToList();

            sepet.AddRange(eskisonuclar);

            dtmusterivearaclar.DataSource = sepet;
        }

        private void VeriTariheGore(DateTime baslangic, DateTime bitis)
        {
            DBEntities db = new DBEntities();

            List<musterilistesi> sepet = new List<musterilistesi>();

            sepet = (from ymusteri in db.TBL_MUSTERILER
                     join fk in db.TBL_FK
                     on ymusteri.MusteriID equals fk.MusteriID
                     join arac in db.TBL_MUSTERIARACLARI
                     on fk.AracID equals arac.AracID
                     join odeme in db.TBL_ODEMELER
                     on fk.MusteriID equals odeme.MusteriID
                     where odeme.OdemeTarihi >= baslangic && odeme.OdemeTarihi <= bitis
                     select new musterilistesi
                     {
                         MusteriAdSoyad = ymusteri.AliciAdsoyad,
                         AliciTelefon = ymusteri.AliciTelefon.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""),
                   
                         AracMarkaTip = arac.MarkaveTip,
                         AracPlakasi = arac.Plaka,
                         OdemeTutari = odeme.OdemeTutari,
                         BarkodNo = ymusteri.BarkodNo,
                         Tarih = odeme.OdemeTarihi,
                     }).OrderByDescending(x => x.Tarih).ToList();

            var eskisonuclar = (from musteri in db.musteri
                                where musteri.tarih >= baslangic && musteri.tarih <= bitis
                                select new musterilistesi
                                {
                                    MusteriAdSoyad = musteri.musteriadi + " " + musteri.musterisoyadi,
                                    AliciTelefon = musteri.musteritelefon,
                                
                                    AracMarkaTip = musteri.aracadi,
                                    AracPlakasi = musteri.aracplakasi,
                                    OdemeTutari = musteri.aracservisucreti,
                                    BarkodNo = musteri.MusteriID.ToString(),
                                    Tarih = musteri.tarih,
                                }).ToList();

            sepet.AddRange(eskisonuclar);

            dtmusterivearaclar.DataSource = sepet;

        }

        private void txtbarkod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtbarkod.Text.Length == 10)
                {
                    DBEntities db = new DBEntities();



                    dtmusterivearaclar.DataSource = (from musteri in db.TBL_MUSTERILER
                                                     join fk in db.TBL_FK
                                                     on musteri.MusteriID equals fk.MusteriID
                                                     join arac in db.TBL_MUSTERIARACLARI
                                                     on fk.AracID equals arac.AracID
                                                     join odeme in db.TBL_ODEMELER
                                                     on fk.MusteriID equals odeme.MusteriID
                                                     where musteri.BarkodNo.Substring(1, 10) == txtbarkod.Text
                                                     select new
                                                     {

                                                         musteri.AliciAdsoyad,
                                                         AliciCepTelefon = musteri.AliciTelefon.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""), 
                                                         arac.MarkaveTip,
                                                         arac.Plaka,
                                                         Odeme = odeme.OdemeTutari,
                                                         musteri.BarkodNo,
                                                         odeme.OdemeTarihi,

                                                     }).OrderByDescending(x => x.OdemeTarihi).ToList();


                    string barkod = db.TBL_MUSTERILER.FirstOrDefault(x => x.BarkodNo.Substring(1, 10) == txtbarkod.Text.ToString()).BarkodNo;

                    string klasoradresi = @"//10.0.0.141/SalautoRaporlar//" + barkod;
                    
                    foreach (string f in Directory.GetFiles(klasoradresi))
                    {
 

                        Bitmap resim = new Bitmap(@"//10.0.0.141/SalautoRaporlar//" + barkod + " //" + Path.GetFileName(f) );

                        pbraporaracresmi.Image = resim;
                        pbraporaracresmi.SizeMode = PictureBoxSizeMode.StretchImage;
                        txtbarkod.Text = "";
                        break;
                    }


                }

            }
            catch (Exception)
            {
                MessageBox.Show("Barkod numarasına ait sonuç bulunamadı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnexcelaktar_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                object Missing = Type.Missing;
                Workbook workbook = excel.Workbooks.Add(Missing);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                for (int j = 0; j < dtmusterivearaclar.Columns.Count; j++)
                {
                    Range myRange = (Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dtmusterivearaclar.Columns[j].HeaderText;
                }
                StartRow++;
                for (int i = 0; i < dtmusterivearaclar.Rows.Count; i++)
                {
                    for (int j = 0; j < dtmusterivearaclar.Columns.Count; j++)
                    {

                        Range myRange = (Range)sheet1.Cells[StartRow + i, StartCol + j];
                        myRange.Value2 = dtmusterivearaclar[j, i].Value == null ? "" : dtmusterivearaclar[j, i].Value;
                        myRange.Select();
                    }
                }
            }
            catch (Exception)
            {
                 
            }
        }

        private void dtmusterivearaclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    int acikformvarmi = 0;


                    foreach (Form item in System.Windows.Forms.Application.OpenForms)
                    {
                        if (item.Name == "RaporDosyalariOnizle")
                        {
                            acikformvarmi++;
                        }
                    }
                    if (acikformvarmi == 0)
                    {

                        string barkodno = dtmusterivearaclar.Rows[e.RowIndex].Cells[6].Value.ToString();
                        RaporBarkodNo.BarkodKodu = barkodno;
                        RaporDosyalariOnizle frm = new RaporDosyalariOnizle();
                        frm.Show();
                    }
                    else
                    {
                        foreach (Form item in System.Windows.Forms.Application.OpenForms)
                        {
                            if (item.Name == "RaporDosyalariOnizle")
                            {
                                item.Close();
                                string barkodno = dtmusterivearaclar.Rows[e.RowIndex].Cells[6].Value.ToString();
                                RaporBarkodNo.BarkodKodu = barkodno;
                                RaporDosyalariOnizle frm = new RaporDosyalariOnizle();
                                frm.Show();
                            }
                        }
                     }

                }
                else
                {
                    string barkod = dtmusterivearaclar.Rows[e.RowIndex].Cells[6].Value.ToString();
                    Bitmap resim = new Bitmap(System.Windows.Forms.Application.StartupPath + "\\Raporlar\\" + barkod + "\\" + barkod + ".jpg");
                    pbraporaracresmi.Image = resim;
                    pbraporaracresmi.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception)
            {


            }
        }

        private void txtbarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


    }
}
