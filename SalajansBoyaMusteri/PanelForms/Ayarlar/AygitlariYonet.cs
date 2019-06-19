using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalajansBoyaMusteri.Properties;
using System.Management;

namespace SalajansBoyaMusteri.PanelForms.Ayarlar
{
    public partial class AygitlariYonet : Form
    {
        public AygitlariYonet()
        {
            InitializeComponent();
        }
        private FilterInfoCollection webcam;
        DBEntities db = new DBEntities();
        private void AygitlariYonet_Load(object sender, EventArgs e)
        {
            PrinterSetup();
        }

        private void PrinterSetup()
        {
            foreach (string printname in PrinterSettings.InstalledPrinters)
            {
                cbyazici.Items.Add(printname); 
            }
            foreach (string printname in PrinterSettings.InstalledPrinters)
            {                 
                cbbarkodyazici.Items.Add(printname);                              
            }

            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo videocapturedevice in webcam)
            {
                cbgoruntuyazici.Items.Add(videocapturedevice.Name);
            }
            cbyazici.SelectedItem = @default.Default.VarsayilanYazici;
            cbbarkodyazici.SelectedItem = @default.Default.BarkodYazici;
            string[] aygit = @default.Default.KameraAygiti.Split(',');
            cbgoruntuyazici.SelectedItem = aygit[0];
            if (cbgoruntuyazici.Items.Count == 0)
            {
                cbgoruntuyazici.Items.Add("Aygıt Bulunamadı");
                cbgoruntuyazici.SelectedIndex = 0;
            }

            cbpaketotomatik.DataSource = db.Paketler.Select(x => new { x.PaketAdi }).ToList();
            cbpaketotomatik.DisplayMember = "PaketAdi";
            cbpaketotomatik.ValueMember = "PaketAdi";
            string paket = @default.Default.OtomatikPaket;
            cbpaketotomatik.Text = paket;
            if (@default.Default.OtomatikGirisSayfasi == true)
            {
                cbgirissayfasiotomatik.Checked = true;
            }
            else
            {
                cbgirissayfasiotomatik.Checked = false;
            }
            if (@default.Default.OtomatikBarkodEtiketi == true)
            {
                cbbarkodetiketiotomatik.Checked = true;
            }
            else
            {
                cbbarkodetiketiotomatik.Checked = false;
            }
            if (@default.Default.OtomatikYapilanTestler == true)
            {
                cbyapilantestler.Checked = true;
            }
            else
            {
                cbyapilantestler.Checked = false;
            }
            cbcozunurluk.Items.Clear();
            VideoCaptureDevice cam;
            try
            {
                cam = new VideoCaptureDevice(webcam[0].MonikerString);
                foreach (var item in cam.VideoCapabilities)
                {
                    cbcozunurluk.Items.Add(item.FrameSize.Width + "x" + item.FrameSize.Height);
                }
                cbcozunurluk.SelectedIndex = @default.Default.KameraCozunurluk;
            }
            catch (Exception)
            {
                 
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                @default.Default.KameraAygiti = cbgoruntuyazici.SelectedItem.ToString() + "," + cbgoruntuyazici.SelectedIndex.ToString();
                @default.Default.VarsayilanYazici = cbyazici.SelectedItem.ToString();
                @default.Default.BarkodYazici = cbbarkodyazici.SelectedItem.ToString();
                @default.Default.Save();
                if (cbgirissayfasiotomatik.Checked == true)
                {
                    @default.Default.OtomatikGirisSayfasi = true;
                }
                else
                {
                    @default.Default.OtomatikGirisSayfasi = false;
                }
                if (cbbarkodetiketiotomatik.Checked == true)
                {
                    @default.Default.OtomatikBarkodEtiketi = true;
                }
                else
                {
                    @default.Default.OtomatikBarkodEtiketi = false;
                }

                if (cbyapilantestler.Checked == true)
                {
                    @default.Default.OtomatikYapilanTestler = true;
                }
                else
                {
                    @default.Default.OtomatikYapilanTestler = false;
                }
                @default.Default.KameraCozunurluk = cbcozunurluk.SelectedIndex;
                @default.Default.OtomatikPaket = cbpaketotomatik.Text;
                @default.Default.Save();
                MessageBox.Show("Aygıt ayarlarınız kayıt edildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception)
            {
                MessageBox.Show("Aygıt ayarlarınız güncellenirken hata oluştu !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnaygittekrarara_Click(object sender, EventArgs e)
        {
            cbbarkodyazici.Items.Clear();
            cbgoruntuyazici.Items.Clear();
            cbyazici.Items.Clear();
            PrinterSetup();
        }

        private void cbgoruntuyazici_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                VideoCaptureDevice cam;
                cam = new VideoCaptureDevice(webcam[cbgoruntuyazici.SelectedIndex].MonikerString);
                foreach (var item in cam.VideoCapabilities)
                {
                    cbcozunurluk.Items.Add(item.FrameSize.Width + "x" + item.FrameSize.Height);
                }
                cbcozunurluk.SelectedIndex = 0;
            }
            catch (Exception)
            {

                return;
            }
        }

        Bitmap Gorsel = new Bitmap(Properties.Resources.TestSayfasi, 2480, 3508);

        private void lblsinamasayfasi_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show((cbyazici.Text + " adlı yazıcıya sınama sayfası gönderilsin mi ?"), "İşlemi Onaylayın", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    PrintDocument pd = new PrintDocument();
                    pd.DefaultPageSettings.Margins = new Margins(0, 45, 0, 45);
                    pd.PrintPage += new PrintPageEventHandler(PrinterTestPage);

                    pd.PrinterSettings.PrinterName = cbyazici.Text;
                    pd.Print();
                    Gorsel.Dispose();
                    MessageBox.Show("Test sayfası yazdırıldı", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        void PrinterTestPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Gorsel, e.MarginBounds);
        }

        private void lblbarkodsinama_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show((cbbarkodyazici.Text + " adlı yazıcıya barkod etiketi gönderilsin mi ?"), "İşlemi Onaylayın", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    var label = DYMO.Label.Framework.Label.Open(Application.StartupPath + "\\etiket.label");
                    label.SetObjectText("txtbarcode", "A1234567890B");

                    string byazici = cbbarkodyazici.Text;
                    label.Print(byazici);
                    MessageBox.Show("Etiket yazdırıldı", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
