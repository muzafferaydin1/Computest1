using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalajansBoyaMusteri.PanelForms;
using SalajansBoyaMusteri.PanelForms.Ayarlar;
using System.Diagnostics;
using System.Management;

namespace SalajansBoyaMusteri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DBEntities db = new DBEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            AracYuklemeEkrani.markalist = db.TBLMARKA.OrderBy(x => x.MARKANAME).ToList();
            KullaniciveFirmaBilgileri.FirmaAdi = "TEKOTO COMPUTEST";
            KullaniciveFirmaBilgileri.FirmaNo = "580671";
            KullaniciveFirmaBilgileri.KullaniciAdSoyad = "CENK SÖNMEZ";
            KullaniciveFirmaBilgileri.Yetki = true;

            tmrDeger.Enabled = true;
            pbmenuyarlarok.Visible = false;
            pbmenusatisraporok.Visible = false;
            pbmenuraporok.Visible = false;
            pbanasayfaok.Visible = true;
            pbyeniprojeok.Visible = false;

            FullProje newForm = new FullProje();
            newForm.TopLevel = false; 
            pnlgetgorm.Controls.Add(newForm);
            newForm.Show();
            newForm.Dock = DockStyle.Top;
            newForm.BringToFront();

            label8.Text = KullaniciveFirmaBilgileri.KullaniciAdSoyad;
            tmrDeger.Interval = 1000;

        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
  
        private void pnlheader_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FormResizeHeader();
            }
        }

        private void pbexit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Programı kapatmak istediğinize eminmisiniz ?", "Salauto Müşteri Takip Sistemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (var process in Process.GetProcessesByName("SalajansBoyaMusteri"))
                {
                    process.Kill();
                }
            }


        }

        private void pbmaxmin_Click(object sender, EventArgs e)
        { 
            FormResizeHeader(); 
        }


        private void FormResizeHeader()
        {

            if (Width != Screen.PrimaryScreen.WorkingArea.Width)
            {

                FormBorderStyle = FormBorderStyle.None;
                Left = Top = 0;
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Height = Screen.PrimaryScreen.WorkingArea.Height;

            }
            else
            {
                FormBorderStyle = FormBorderStyle.None;
                Left = Top = 0;
                Width = 1366;
                Height = 800;
                this.StartPosition = FormStartPosition.CenterScreen;


            }
        }

    
        private void pbhakkindaheader_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yardım için 05425996079");
        }

        private void pbminumum_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Minimized;
        }


        private void pnlheader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        private void pnlanasayfa_Click(object sender, EventArgs e)
        {
         
            if (pbyeniprojeok.Visible == true)
            {
                DialogResult yanit = new DialogResult();
                yanit = MessageBox.Show("Dikkat ! Tüm bilgiler kaybedilecek ! Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yanit == DialogResult.Yes)
                {
                    AnasayfayaGit();
                }
            }
            else
            {
                foreach (Form item in Application.OpenForms)
                {
                    if (item.Text != "Araç Boya Rapor ve Müşteri Takip")
                    {
                        this.BeginInvoke(new MethodInvoker(((Form)item).Dispose));
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
                AnasayfayaGit();
            }


        }

        private void AnasayfayaGit()
        {
            if (FullProje.cam != null)
            {
                FullProje.cam.Stop();
            }

            pbmenuyarlarok.Visible = false;
            pbmenusatisraporok.Visible = false;
            pbmenuraporok.Visible = false;
            pbanasayfaok.Visible = true;
            pbyeniprojeok.Visible = false;
            pnlgetgorm.Controls.Clear();


            Anasayfa newForm = new Anasayfa();
            newForm.TopLevel = false;
            pnlgetgorm.Controls.Add(newForm);
            newForm.Show();
            newForm.Dock = DockStyle.Top;
            newForm.BringToFront();
        }

        private void pnlmenusatistakip_Click(object sender, EventArgs e)
        {
           
            if (pbyeniprojeok.Visible == true)
            {
                DialogResult yanit = new DialogResult();
                yanit = MessageBox.Show("Dikkat ! Tüm bilgiler kaybedilecek ! Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (yanit == DialogResult.Yes)
                {
                    SatisTakipGit();
                }
            }
            else
            {
                foreach (Form item in Application.OpenForms)
                {
                    if (item.Text != "Araç Boya Rapor ve Müşteri Takip")
                    {
                        this.BeginInvoke(new MethodInvoker(((Form)item).Dispose));
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
                SatisTakipGit();
            }
        }

        private void SatisTakipGit()
        {
            if (FullProje.cam != null)
            {
                FullProje.cam.Stop();
            }
            pbmenuyarlarok.Visible = false;
            pbmenusatisraporok.Visible = true;
            pbmenuraporok.Visible = false;
            pbanasayfaok.Visible = false;
            pbyeniprojeok.Visible = false;
            pnlgetgorm.Controls.Clear();
            OdemeTakip newForm = new OdemeTakip();
            newForm.TopLevel = false;
            pnlgetgorm.Controls.Add(newForm);
            newForm.Show();
            newForm.Dock = DockStyle.Top;
            newForm.BringToFront();
        }

        private void pnlmenurapor_Click(object sender, EventArgs e)
        { 
            if (pbyeniprojeok.Visible == true)
            {
                DialogResult yanit = new DialogResult();
                yanit = MessageBox.Show("Dikkat ! Tüm bilgiler kaybedilecek ! Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yanit == DialogResult.Yes)
                {
                    RaporEkraninaGit();
                }
            }
            else
            {
                foreach (Form item in Application.OpenForms)
                {
                    if (item.Text != "Araç Boya Rapor ve Müşteri Takip")
                    {
                        this.BeginInvoke(new MethodInvoker(((Form)item).Dispose));
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
                RaporEkraninaGit();
            }
        }

        private void RaporEkraninaGit()
        {
            if (FullProje.cam != null)
            {
                FullProje.cam.Stop();
            }
            pbmenuyarlarok.Visible = false;
            pbmenusatisraporok.Visible = false;
            pbmenuraporok.Visible = true;
            pbanasayfaok.Visible = false;
            pbyeniprojeok.Visible = false;
            pnlgetgorm.Controls.Clear();
            MusteriveRaporList newForm = new MusteriveRaporList();
            newForm.TopLevel = false;
            pnlgetgorm.Controls.Add(newForm);
            newForm.Show();
            newForm.Dock = DockStyle.Top;
            newForm.BringToFront();
        }

        private void pnlmenuyeniproje_Click(object sender, EventArgs e)
        {
            YProje(); 
        }

        public void YProje()
        {
            if (pbyeniprojeok.Visible == true)
            {
                DialogResult yanit = new DialogResult();
                yanit = MessageBox.Show("Yeni Proje Başlatılsın mı ? ! Tüm bilgiler kaybedilecek ! ", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yanit == DialogResult.Yes)
                {
                    YeniProjeBaslat();
                }
            }
            else
            {
                foreach (Form item in Application.OpenForms)
                {
                    if (item.Text != "Araç Boya Rapor ve Müşteri Takip")
                    {
                        this.BeginInvoke(new MethodInvoker(((Form)item).Dispose));
                        if (item.Text == "Full Proje")
                        {
                            item.Dispose();
                            item.Close();
                        }
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
                YeniProjeBaslat();
            }
        }

        private void YeniProjeBaslat()
        {
            try
            {
                foreach (Form item in Application.OpenForms)
                {
                    if (item.Text != "Araç Boya Rapor ve Müşteri Takip")
                    {
                        this.BeginInvoke(new MethodInvoker(((Form)item).Dispose));
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
                if (FullProje.cam != null)
                {
                    FullProje.cam.Stop();
                }


                pbmenuyarlarok.Visible = false;
                pbmenusatisraporok.Visible = false;
                pbmenuraporok.Visible = false;
                pbanasayfaok.Visible = false;
                pbyeniprojeok.Visible = true;
                pnlgetgorm.Controls.Clear();
                FullProje newForm = new FullProje();
                newForm.TopLevel = false;
                pnlgetgorm.Controls.Add(newForm);
                newForm.Show();
                newForm.Dock = DockStyle.Top;
                newForm.BringToFront();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.ToString(), "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlmenuayarlar_Click(object sender, EventArgs e)
        {
 
            if (pbyeniprojeok.Visible == true)
            {
                DialogResult yanit = new DialogResult();
                yanit = MessageBox.Show("Dikkat ! Tüm bilgiler kaybedilecek ! Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yanit == DialogResult.Yes)
                {
                    AyarlaraGit();
                }
            }
            else
            {
                foreach (Form item in Application.OpenForms)
                {
                    if (item.Text != "Araç Boya Rapor ve Müşteri Takip")
                    {
                        this.BeginInvoke(new MethodInvoker(((Form)item).Dispose));
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
                AyarlaraGit();
            }
        }

        private void AyarlaraGit()
        {
            if (FullProje.cam != null)
            {
                FullProje.cam.Stop();
            }
            pbmenuyarlarok.Visible = false;
            pbmenusatisraporok.Visible = false;
            pbmenuraporok.Visible = true;
            pbanasayfaok.Visible = false;
            pbyeniprojeok.Visible = false;
            pnlgetgorm.Controls.Clear();
            AyarlariDegistir newForm = new AyarlariDegistir();
            newForm.TopLevel = false;
            pnlgetgorm.Controls.Add(newForm);
            newForm.Show();
            newForm.Dock = DockStyle.Top;
            newForm.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltarih.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }


        private void tmrDeger_Tick(object sender, EventArgs e)
        {
            lbltarih.Text = DateTime.Now.ToString(); 
        }
    }
}
