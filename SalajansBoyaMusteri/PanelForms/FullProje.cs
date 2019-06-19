using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using SalajansBoyaMusteri.Properties;
using System.Drawing.Printing;

namespace SalajansBoyaMusteri.PanelForms
{
    public partial class FullProje : Form
    {
        private FilterInfoCollection webcam;
        public static VideoCaptureDevice cam;
        public FullProje()
        {
            InitializeComponent();
        }
        DBEntities db = new DBEntities();
        delegate void ProcessDelegate();

        string barkodkodu = string.Empty;
        public VideoCapabilities FrameSizes;

        private void FullProje_Load(object sender, EventArgs e)
        {

            // Ayarları Yükle
            if (@default.Default.OtomatikGirisSayfasi == true) { cbgirissayfasi.Checked = true; } else { cbgirissayfasi.Checked = false; }
            if (@default.Default.OtomatikBarkodEtiketi == true) { cbetiket.Checked = true; } else { cbetiket.Checked = false; }
            if (@default.Default.OtomatikYapilanTestler == true) { cbyapilantestler.Checked = true; } else { cbyapilantestler.Checked = false; }

            //Araç giriş t/s timer
            timer1.Interval = 1000;
            timer1.Start();

            //araç bilgileri seçimi
            cbyakittipi.SelectedIndex = 0;
            cbvitestipi.SelectedIndex = 0;


            //Kasa tipi hususi seçili gelsin
            RDhususi();

            for (int i = DateTime.Now.Year + 1; i >= 1960; i--)
            {
                cbaracmodeli.Items.Add(i.ToString());
            }

            cbaracmodeli.SelectedIndex = 0;
            cbaracrenk.SelectedIndex = 0;
            cbzamanlayici.SelectedIndex = 0;

            BarcodeLib.Barcode b = BarkodOlustur();
            int genislik = Convert.ToInt32(269);
            int yukseklik = Convert.ToInt32(58);
            b.Alignment = BarcodeLib.AlignmentPositions.LEFT;
            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            type = BarcodeLib.TYPE.Codabar;
            pbbarkod.Image = b.Encode(type, barkodkodu, genislik, yukseklik);
            lblbarkod.Text = barkodkodu;

            droppaketler.DataSource = db.Paketler.Select(x => new { x.PaketAdi }).ToList();
            droppaketler.DisplayMember = "PaketAdi";
            droppaketler.ValueMember = "PaketAdi";


            string paketicerik = db.Paketler.FirstOrDefault(x => x.PaketAdi == droppaketler.Text).PaketIcerik;
            toolTip1.SetToolTip(droppaketler, paketicerik);


            PaketSecimi();

            pnlhususi.Visible = true;
            rdtekkapihususi.Enabled = false;
            rd4kapihususi.Enabled = true;
            rd4kapihususi.Checked = true;

            pnlticarisecim.Visible = false;

            foreach (var item in tabOnDuzen.Controls)
            {
                if (item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = 0;
                }
            }
            foreach (var item in tabMotor.Controls)
            {
                if (item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = 0;
                }
            }
            foreach (var item in tabsanziman.Controls)
            {
                if (item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = 0;
                }
            }
            foreach (var item in tabDonanim.Controls)
            {
                if (item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = 0;
                }
            }
            foreach (var item in tabElektrik.Controls)
            {
                if (item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = 0;
                }
            }

            cbabs.Items.Add("Kontrol Edilmedi");
            cbabs.Items.Add("Çalışıyor");
            cbabs.Items.Add("Çalışmıyor");
            cbabs.Items.Add("Yok");

            cbesp.Items.Add("Kontrol Edilmedi");
            cbesp.Items.Add("Çalışıyor");
            cbesp.Items.Add("Çalışmıyor");
            cbesp.Items.Add("Yok");

            cbfrenmerkezpompasi.Items.Add("Kontrol Edilmedi");
            cbfrenmerkezpompasi.Items.Add("Zayıf");
            cbfrenmerkezpompasi.Items.Add("Orta");
            cbfrenmerkezpompasi.Items.Add("İyi");
            cbfrenmerkezpompasi.Items.Add("Acil Bakım Gerekli");

            cbabs.SelectedIndex = 0;

            cbesp.SelectedIndex = 0;

            cbfrenmerkezpompasi.SelectedIndex = 0;

            foreach (var item in pnlfrencb.Controls)
            {
                if (item is ComboBox)
                {
                    ((ComboBox)item).Items.Add("Kontrol Edilmedi");
                    ((ComboBox)item).Items.Add("İyi");
                    ((ComboBox)item).Items.Add("Orta");
                    ((ComboBox)item).Items.Add("Zayıf");
                    ((ComboBox)item).Items.Add("Acil Bakım");
                    ((ComboBox)item).Items.Add("Yok");
                    ((ComboBox)item).SelectedIndex = 0;
                }
            }
            foreach (var item in pnlsuspansiyoncb.Controls)
            {
                if (item is ComboBox)
                {
                    ((ComboBox)item).Items.Add("Kontrol Edilmedi");
                    ((ComboBox)item).Items.Add("İyi");
                    ((ComboBox)item).Items.Add("Orta");
                    ((ComboBox)item).Items.Add("Zayıf");
                    ((ComboBox)item).Items.Add("Acil Bakım");
                    ((ComboBox)item).Items.Add("Yok");
                    ((ComboBox)item).SelectedIndex = 0;
                }
            }
            foreach (var item in pnldisaydinlatma.Controls)
            {
                if (item is ComboBox)
                {
                    ((ComboBox)item).Items.Add("Kontrol Edilmedi");
                    ((ComboBox)item).Items.Add("Çalışıyor");
                    ((ComboBox)item).Items.Add("Çalışmıyor");
                    ((ComboBox)item).Items.Add("Yok");
                    ((ComboBox)item).SelectedIndex = 0;
                }
            }


            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);


            droppaketler.Text = @default.Default.OtomatikPaket;


            cbkameralist.Items.Clear();
            string[] kameraaygit = @default.Default.KameraAygiti.Split(',');
            bool aygitvarmi = false;
            bool tanimliaygitmi = false;
            foreach (FilterInfo videocapturedevice in webcam)
            {
                if (kameraaygit[0] == videocapturedevice.Name)
                {
                    aygitvarmi = true;
                    tanimliaygitmi = true;
                    cbkameralist.Items.Add(new { Text = kameraaygit[0], Value = 0 });
                    cbkameralist.SelectedIndex = 0;
                    break;
                }
                else
                {
                    aygitvarmi = true;
                    tanimliaygitmi = false;
                }
            }
            if (aygitvarmi && tanimliaygitmi)
            {
                try
                {

                }
                catch (Exception)
                {

                    MessageBox.Show("Kamera aygıtı yüklenirken hata oluştu !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (aygitvarmi && !tanimliaygitmi)
            {
                MessageBox.Show("Yeni kamera cihazı algılandı.Lütfen Ayarlar->Aygıtları Yönet sayfasından cihazı tanıtınız. !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cbkameralist.Items.Add(new { Text = "Aygıt Bulunamadı", Value = "-111" });
                cbkameralist.SelectedIndex = 0;
            }

            cbkameralist.DisplayMember = "Text";
            cbkameralist.ValueMember = "Value";
            cam = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        private BarcodeLib.Barcode BarkodOlustur()
        {
            Random rastgele = new Random();
            string harfler = "AB";
            string sayilar = "0123456789";
            barkodkodu = harfler[rastgele.Next(harfler.Length)].ToString();

            for (int s = 0; s < 10; s++)
            {
                barkodkodu += sayilar[rastgele.Next(sayilar.Length)];
            }
            barkodkodu += harfler[rastgele.Next(harfler.Length)].ToString();
            BarkodKontrol(barkodkodu);
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            return b;
        }

        private void BarkodKontrol(string BarkodNo)
        {
            using (DBEntities db1 = new DBEntities())
            {

                var kontrolbarkod = db1.TBL_MUSTERILER.Any(x => x.BarkodNo.Substring(1, 10) == BarkodNo.Substring(1, 10));

                if (kontrolbarkod)
                {
                    Random rastgele = new Random();
                    string harfler = "AB";
                    string sayilar = "0123456789";
                    string barkodkodu = harfler[rastgele.Next(harfler.Length)].ToString();
                    for (int s = 0; s < 10; s++)
                    {
                        barkodkodu += sayilar[rastgele.Next(sayilar.Length)];
                    }
                    barkodkodu += harfler[rastgele.Next(harfler.Length)].ToString();
                    barkodkodu = BarkodNo;
                    BarkodKontrol(barkodkodu);

                }
                else
                {
                    musteridegerleri.barkodno = BarkodNo;
                    barkodkodu = BarkodNo;
                }
            }
        }



        private void AracYukle()
        {
            if (listaracmarka.Items.Count == 0)
            {

                listaracmarka.DataSource = AracYuklemeEkrani.markalist;
                listaracmarka.DisplayMember = "MARKANAME";
                listaracmarka.ValueMember = "MARKAID";
            }
        }

        private void txtmarkaAra_Click(object sender, EventArgs e)
        {
            AracYukle();
            txtmarkaAra.ForeColor = Color.Black;
            txtmarkaAra.Text = "";
        }
        private void txtmarkaAra_TextChanged(object sender, EventArgs e)
        {
            if (txtmarkaAra.Text != "")
            {

                IList<TBLMARKA> markalist = AracYuklemeEkrani.markalist.Where(x => x.MARKANAME.ToLower().Contains(txtmarkaAra.Text.ToLower())).OrderBy(x => x.MARKANAME).ToList();
                IList<TBLMODEL> modellist = db.TBLMODEL.Where(x => x.MODELNAME.Contains(txtmarkaAra.Text)).OrderBy(x => x.MODELNAME).ToList();


                if (markalist.Count > 0)
                {
                    listaracmarka.DataSource = markalist;
                    listaracmarka.DisplayMember = "MARKANAME";
                    listaracmarka.ValueMember = "MARKAID";

                }
                else if (modellist.Count > 0)
                {
                    var markaid = modellist.First().MARKAID;
                    var modelid = modellist.First().MODELID;
                }


            }
        }

        private void listaracmarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseSetup();

        }

        private void DatabaseSetup()
        {
            int secilenmarka = listaracmarka.SelectedValue.Toint58();
            if (secilenmarka == -111)
            {
                secilenmarka = AracYuklemeEkrani.markalist.FirstOrDefault().MARKAID;

            }
            IList<TBLMODEL> modellist = db.TBLMODEL.Where(x => x.MARKAID == secilenmarka).OrderBy(x => x.MODELNAME).ToList();
            listaracmodel.DataSource = modellist;
            listaracmodel.DisplayMember = "MODELNAME";
            listaracmodel.ValueMember = "MODELID";

            txtYeniAracMarkaAdi.Text = listaracmarka.Text;
            txtYeniAracMarkaAdi.ForeColor = Color.Black;

            int secilenmodel = listaracmodel.SelectedValue.Toint58();


            IList<TBLARACSERISI> seriList = db.TBLARACSERISI.Where(x => x.ModelID == secilenmodel).OrderBy(x => x.SeriAdi).ToList();
            listarackasa.DataSource = seriList;
            listarackasa.DisplayMember = "SeriAdi";
            listarackasa.ValueMember = "MarkaID";

            txtYeniAracMarkaAdi.Text = listaracmarka.Text;
            txtYeniAracMarkaAdi.ForeColor = Color.Black;

            int secilenkasaseriID = listarackasa.SelectedValue.Toint58();
            IList<TBLARACVERSIYON> seriversList = db.TBLARACVERSIYON.Where(x => x.SeriID == secilenkasaseriID).OrderBy(x => x.VersiyonAdi).ToList();
            listaracversiyon.DataSource = seriversList;
            listaracversiyon.DisplayMember = "VersiyonAdi";
            listaracversiyon.ValueMember = "id";

            soloncamurluk.DataSource = db.TBL_BOYADEGERLERI.OrderBy(x => x.SiraNo).ToList();
            soloncamurluk.DisplayMember = "Deger";
            soloncamurluk.ValueMember = "Value";
            sagoncamurluk.DataSource = db.TBL_BOYADEGERLERI.OrderBy(x => x.SiraNo).ToList();
            sagoncamurluk.DisplayMember = "Deger";
            sagoncamurluk.ValueMember = "Value";
            solonkapi.DataSource = db.TBL_BOYADEGERLERI.OrderBy(x => x.SiraNo).ToList();
            solonkapi.DisplayMember = "Deger";
            solonkapi.ValueMember = "Value";
            sagonkapi.DataSource = db.TBL_BOYADEGERLERI.OrderBy(x => x.SiraNo).ToList();
            sagonkapi.DisplayMember = "Deger";
            sagonkapi.ValueMember = "Value";
            solarkakapi.DataSource = db.TBL_BOYADEGERLERI.OrderBy(x => x.SiraNo).ToList();
            solarkakapi.DisplayMember = "Deger";
            solarkakapi.ValueMember = "Value";
            sagarkapaki.DataSource = db.TBL_BOYADEGERLERI.OrderBy(x => x.SiraNo).ToList();
            sagarkapaki.DisplayMember = "Deger";
            sagarkapaki.ValueMember = "Value";
            solarkacamurluk.DataSource = db.TBL_BOYADEGERLERI.OrderBy(x => x.SiraNo).ToList();
            solarkacamurluk.DisplayMember = "Deger";
            solarkacamurluk.ValueMember = "Value";
            sagarkacamurluk.DataSource = db.TBL_BOYADEGERLERI.OrderBy(x => x.SiraNo).ToList();
            sagarkacamurluk.DisplayMember = "Deger";
            sagarkacamurluk.ValueMember = "Value";
            kaput.DataSource = db.TBL_BOYADEGERLERI.OrderBy(x => x.SiraNo).ToList();
            kaput.DisplayMember = "Deger";
            kaput.ValueMember = "Value";
            tavan.DataSource = db.TBL_BOYADEGERLERI.OrderBy(x => x.SiraNo).ToList();
            tavan.DisplayMember = "Deger";
            tavan.ValueMember = "Value";
            bagaj.DataSource = db.TBL_BOYADEGERLERI.OrderBy(x => x.SiraNo).ToList();
            bagaj.DisplayMember = "Deger";
            bagaj.ValueMember = "Value";

        }

        private void listaracmodel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secilenmodel = listaracmodel.SelectedValue.Toint58();
            try
            {
                if (secilenmodel != -111)
                {

                    IList<TBLARACSERISI> seriList = db.TBLARACSERISI.Where(x => x.ModelID == secilenmodel).OrderBy(x => x.SeriAdi).ToList();
                    listarackasa.DataSource = seriList;
                    listarackasa.DisplayMember = "SeriAdi";
                    listarackasa.ValueMember = "id";
                    listarackasa.SelectedIndex = 0;

                    txtYeniAracModelAdi.Text = listaracmodel.Text;
                }
            }
            catch (Exception)
            {


            }
        }

        private void listarackasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int secilenkasaseriID = listarackasa.SelectedValue.Toint58();
                IList<TBLARACVERSIYON> seriversList = db.TBLARACVERSIYON.Where(x => x.SeriID == secilenkasaseriID).OrderBy(x => x.VersiyonAdi).ToList();
                listaracversiyon.DataSource = seriversList;
                listaracversiyon.DisplayMember = "VersiyonAdi";
                listaracversiyon.ValueMember = "id";
                if (seriversList.Count == 0)
                {

                    listaracversiyon.Items.Clear();
                }
                txtYeniAracKasaAdi.Text = listarackasa.Text;
            }
            catch (Exception)
            {


            }
        }

        bool aracimage = false;
        private void btnalicisatisiresimdvmet_Click(object sender, EventArgs e)
        {

            if (txtaliciadsoyad.Text.Trim() != "" && txtalicitelefon.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim() != "" && txtodemetutari.Text.Trim() != "")
            {

                AracYukle();
                if (cam == null && aracimage == false)
                {
                    aracimage = false;
                    DialogResult yanit = new DialogResult();
                    yanit = MessageBox.Show("Araç resmi kayıt edilmedi ? ! Devam edilsin mi ? ! ", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (yanit == DialogResult.Yes)
                    {

                        AracResmiKaydet();
                        tabmain.SelectedTab = tabaracsecimi;
                    }
                }
                else
                {
                    aracimage = true;
                    string resimadi = barkodkodu + ".jpg";
                    string klasoryolu = "C://SAutoTemp/" + barkodkodu;

                    if (cam != null)
                    {

                        musteridegerleri.AracResmi = true;
                        if (Directory.Exists(klasoryolu))
                        {
                            pbkamera.Image.Save(klasoryolu + "\\" + resimadi);

                        }
                        else
                        {
                            Directory.CreateDirectory("C://SAutoTemp/" + barkodkodu);
                            pbkamera.Image.Save(klasoryolu + "\\" + resimadi);
                        }
                    }
                    else
                    {
                        musteridegerleri.AracResmi = false;

                        if (Directory.Exists(klasoryolu))
                        {
                            pbtransparentpng.Image.Save(klasoryolu + "\\" + resimadi);
                        }
                        else
                        {
                            Directory.CreateDirectory("C://SAutoTemp/" + barkodkodu);
                            pbtransparentpng.Image.Save(klasoryolu + "\\" + resimadi);

                        }

                    }
                    musteridegerleri.barkodno = barkodkodu;
                    exitcamera();
                    tabmain.SelectedTab = tabaracsecimi;
                }


            }
            else
            {
                MessageBox.Show("* olan alanlar zorunludur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AracResmiKaydet()
        {
            string barkodkodu = lblbarkod.Text.ToString();
            string resimadi = barkodkodu + ".jpg";
            string klasoryolu = "C://SAutoTemp/" + barkodkodu;

            if (cam != null)
            {

                musteridegerleri.AracResmi = true;
                if (Directory.Exists(klasoryolu))
                {
                    pbkamera.Image.Save(klasoryolu + "\\" + resimadi);
                }
                else
                {
                    Directory.CreateDirectory("C://SAutoTemp/" + barkodkodu);
                    pbkamera.Image.Save(klasoryolu + "\\" + resimadi);
                }
            }
            else
            {
                musteridegerleri.AracResmi = false;

                if (Directory.Exists(klasoryolu))
                {
                    pbtransparentpng.Image.Save(klasoryolu + "\\" + resimadi);
                }
                else
                {
                    Directory.CreateDirectory("C://SAutoTemp/" + barkodkodu);
                    pbtransparentpng.Image.Save(klasoryolu + "\\" + resimadi);

                }

            }
            musteridegerleri.barkodno = barkodkodu;
            exitcamera();


        }
        private void exitcamera()
        {

            try
            {
                if (cam != null)
                {
                    cam.SignalToStop();
                    cam.WaitForStop();
                    cam = null;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void tabaracsec_Click(object sender, EventArgs e)
        {
            AracYukle();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnresimcek_Click(object sender, EventArgs e)
        {


        }

        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {


            lock (pbkamera)
                pbkamera.Image = (Bitmap)eventArgs.Frame.Clone();


        }



        #region "Kod Oluştur"
        public static string KodOlustur(string Text)
        {
            try

            {
                string strReturn = Text.Trim();
                strReturn = strReturn.Replace("ğ", "g");
                strReturn = strReturn.Replace("Ğ", "G");
                strReturn = strReturn.Replace("ü", "u");
                strReturn = strReturn.Replace("Ü", "U");
                strReturn = strReturn.Replace("ş", "s");
                strReturn = strReturn.Replace("Ş", "S");
                strReturn = strReturn.Replace("ı", "i");
                strReturn = strReturn.Replace("İ", "i");
                strReturn = strReturn.Replace("I", "i");
                strReturn = strReturn.Replace("ö", "o");
                strReturn = strReturn.Replace("Ö", "O");
                strReturn = strReturn.Replace("ç", "c");
                strReturn = strReturn.Replace("Ç", "C");
                strReturn = strReturn.Replace("-", "+");
                strReturn = strReturn.Replace(" ", "+");
                strReturn = strReturn.Trim();
                strReturn = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9+]").Replace(strReturn, "");
                strReturn = strReturn.Trim();
                strReturn = strReturn.Replace("+", "-").ToLower();
                return strReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltarihaat.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();

            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdsedan_Click(object sender, EventArgs e)
        {
            pnlhususi.Visible = true;
            rdtekkapihususi.Enabled = false;
            rd4kapihususi.Enabled = true;
            rd4kapihususi.Checked = true;
            pnlcamlicamsiz.Visible = false;

            pnlticarisecim.Visible = false;
        }

        private void rdhatchbag_Click(object sender, EventArgs e)
        {

            pnlhususi.Visible = true;
            rdtekkapihususi.Enabled = true;
            rd4kapihususi.Enabled = true;
            rd4kapihususi.Checked = true;

            pnlticarisecim.Visible = false;
            pnlcamlicamsiz.Visible = false;

        }

        private void rdsuv_Click(object sender, EventArgs e)
        {
            pnlhususi.Visible = true;
            rdtekkapihususi.Enabled = true;
            rd4kapihususi.Enabled = true;
            rd4kapihususi.Checked = true;
            pnlticarisecim.Visible = false;
            pnlcamlicamsiz.Visible = false;

        }

        private void rdcabrio_Click(object sender, EventArgs e)
        {
            pnlhususi.Visible = true;
            rdtekkapihususi.Enabled = true;
            rd4kapihususi.Enabled = true;
            rd4kapihususi.Checked = true;
            pnlticarisecim.Visible = false;
            pnlcamlicamsiz.Visible = false;

        }

        private void rdcoupe_Click(object sender, EventArgs e)
        {
            pnlhususi.Visible = true;
            rd4kapihususi.Enabled = false;
            rdtekkapihususi.Enabled = true;
            rdtekkapihususi.Checked = true;
            pnlticarisecim.Visible = false;
            pnlcamlicamsiz.Visible = false;

        }

        private void rdsw_Click(object sender, EventArgs e)
        {
            pnlhususi.Visible = true;
            rdtekkapihususi.Enabled = true;
            rd4kapihususi.Enabled = true;
            rd4kapihususi.Checked = true;
            pnlticarisecim.Visible = false;
            pnlcamlicamsiz.Visible = false;

        }

        private void rdticari_Click(object sender, EventArgs e)
        {
            rdsedan.Enabled = false;
            rdhatchbag.Enabled = false;
            rdsuv.Enabled = false;
            rdpanelvan.Enabled = true;
            rdglassvan.Enabled = true;
            rdminivan.Enabled = true;
            rdmidivan.Enabled = true;
            rdcabrio.Enabled = false;
            rdcoupe.Enabled = false;
            rdglassvan.Checked = true;
            rdsw.Enabled = false;
            pnlhususi.Visible = false;
            pnlticarisecim.Visible = true;
            pnlticarisecim.Location = new Point(544, 247);
            pnlhususi.Visible = false;
            pnlticarisecim.Visible = true;
            rdacikkasa.Enabled = false;
            rdkapalikasa.Enabled = true;
            rdkapalikasa.Checked = true;
            rdkabintipi2kapi.Enabled = false;
            rdkabintipi3kapi.Checked = true;
            rdkabintipi3kapi.Enabled = true;
            rdkabintipiciftkabin.Enabled = false;
            rdkabintipitekkabin.Enabled = false;
            pnlcamlicamsiz.Visible = false;

        }

        private void rdglassvan_Click(object sender, EventArgs e)
        {

            if (rdhususi2.Checked)
            {
                pnlhususi.Visible = true;
                rdtekkapihususi.Enabled = false;
                rd4kapihususi.Enabled = true;
                rd4kapihususi.Checked = true;
                pnlticarisecim.Visible = false;
            }
            else
            {
                pnlhususi.Visible = false;
                pnlticarisecim.Visible = true;
                rdacikkasa.Enabled = false;
                rdkapalikasa.Enabled = true;
                rdkapalikasa.Checked = true;
                rdkabintipi2kapi.Enabled = false;
                rdkabintipi3kapi.Checked = true;
                rdkabintipi3kapi.Enabled = true;
                rdkabintipiciftkabin.Enabled = false;
                rdkabintipitekkabin.Enabled = false;
                rdkabintipi4kapi.Enabled = true;

            }
            pnlcamlicamsiz.Visible = false;

        }

        private void rdpanelvan_Click(object sender, EventArgs e)
        {
            rdacikkasa.Enabled = true;
            rdkabintipi2kapi.Enabled = true;
            rdkapalikasa.Checked = true;
            rdkapalikasa.Enabled = true;
            rdkabintipitekkabin.Enabled = false;
            rdkabintipiciftkabin.Enabled = false;
            rdkabintipi4kapi.Enabled = false;
            pnlcamlicamsiz.Visible = false;
        }

        private void rdhususi2_Click(object sender, EventArgs e)
        {
            RDhususi();
        }

        private void RDhususi()
        {
            rdsedan.Enabled = true;
            rdhatchbag.Enabled = true;
            rdsuv.Enabled = true;
            rdminivan.Enabled = false;
            rdpanelvan.Enabled = false;
            rdmidivan.Enabled = false;
            rdglassvan.Enabled = true;
            rdsedan.Checked = true;
            rdcabrio.Enabled = true;
            rdcoupe.Enabled = true;
            rdsw.Enabled = true;
            pnlticarisecim.Visible = false;
            pnlhususi.Visible = true;

        }

        private void rdkapalikasa_Click(object sender, EventArgs e)
        {
            rdkabintipi3kapi.Enabled = true;
            rdkabintipitekkabin.Enabled = false;
            rdkabintipiciftkabin.Enabled = false;
            rdkabintipi3kapi.Checked = true;
            rdkabintipi2kapi.Enabled = true;
        }

        private void rdacikkasa_Click(object sender, EventArgs e)
        {
            rdkabintipi3kapi.Enabled = false;
            rdkabintipitekkabin.Enabled = true;
            rdkabintipiciftkabin.Enabled = true;
            rdkabintipitekkabin.Checked = true;
            rdkabintipi2kapi.Enabled = false;
            rdkabintipi3kapi.Enabled = false;



        }

        private void rdminivan_Click(object sender, EventArgs e)
        {
            pnlhususi.Visible = false;
            rdacikkasa.Enabled = false;
            rdkapalikasa.Enabled = true;
            rdkapalikasa.Checked = true;
            rdkabintipi2kapi.Enabled = false;
            rdkabintipi3kapi.Enabled = true;
            rdkabintipi3kapi.Checked = true;
            rdkabintipi4kapi.Enabled = false;
            rdkabintipitekkabin.Enabled = false;
            rdkabintipiciftkabin.Enabled = false;
            pnlcamlicamsiz.Visible = true;

        }

        private void rdhususi2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdticari_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnaracbilgileritab_Click(object sender, EventArgs e)
        {
            tabmain.SelectedTab = tabaracbilgileri;
            txtmarkatip.Text = listaracmarka.Text + " " + listaracmodel.Text;

            txtalttipi.Text = listarackasa.Text + " " + listaracversiyon.Text;

        }

        private void txtmuayenetarihi_TextChanged(object sender, EventArgs e)
        {
            if (txtmuayenetarihi.Text.Length == 2 || txtmuayenetarihi.Text.Length == 5)
            {
                txtmuayenetarihi.Text += "/";

            }
            txtmuayenetarihi.SelectionStart = txtmuayenetarihi.Text.Length;
        }

        private void txtegsozmuayenetarihi_TextChanged(object sender, EventArgs e)
        {
            if (txtegsozmuayenetarihi.Text.Length == 2 || txtegsozmuayenetarihi.Text.Length == 5)
            {
                txtegsozmuayenetarihi.Text += "/";

            }
            txtegsozmuayenetarihi.SelectionStart = txtegsozmuayenetarihi.Text.Length;
        }



        private void RadioKontrolleri(out string kaskodurumu, out string sigortateklifi, out string kullanimturu, out string kasatipi, out string aracalttipi)
        {
            kaskodurumu = string.Empty;
            sigortateklifi = string.Empty;
            kullanimturu = string.Empty;
            if (rdkaskovar.Checked)
            {
                kaskodurumu = "Var";
            }
            else
            {
                kaskodurumu = "Yok";
            }
            if (rdsigortteklifvar.Checked)
            {
                sigortateklifi = "Var";
            }
            else
            {
                sigortateklifi = "Yok";
            }
            if (rdhususi2.Checked)
            {
                kullanimturu = "Hususi";
            }
            else
            {
                kullanimturu = "Ticari";
            }
            kasatipi = string.Empty;
            aracalttipi = string.Empty;
            if (rdsedan.Checked)
            {
                kasatipi = "Sedan";
                if (rd4kapihususi.Checked)
                {
                    aracalttipi = "Standart";
                }
                else if (rdcabrio.Checked)
                {
                    aracalttipi = "Cabrio";
                }
                else if (rdcoupe.Checked)
                {
                    aracalttipi = "Coupe";
                }
                else
                {
                    aracalttipi = "SW";
                }
            }
            else if (rdhatchbag.Checked)
            {
                kasatipi = "Hatchbag";
                if (rd4kapihususi.Checked)
                {
                    aracalttipi = "Standart";
                }
                else if (rdcabrio.Checked)
                {
                    aracalttipi = "Cabrio";
                }
                else if (rdcoupe.Checked)
                {
                    aracalttipi = "Coupe";
                }
                else
                {
                    aracalttipi = "SW";
                }
            }
            else if (rdsuv.Checked)
            {
                kasatipi = "SUV";
                if (rd4kapihususi.Checked)
                {
                    aracalttipi = "Standart";
                }
                else if (rdcabrio.Checked)
                {
                    aracalttipi = "Cabrio";
                }
                else if (rdcoupe.Checked)
                {
                    aracalttipi = "Coupe";
                }
                else
                {
                    aracalttipi = "SW";
                }
            }
            else if (rdminivan.Checked)
            {
                kasatipi = "Minivan";
                if (rdacikkasa.Checked)
                {
                    aracalttipi = "Açık Kasa";
                    if (rdkabintipiciftkabin.Checked)
                    {
                        aracalttipi += "-Tek Kabin";
                    }
                    else
                    {
                        aracalttipi += "-Çift Kabin";
                    }
                }
                else
                {
                    aracalttipi = "Kapalı Kasa";
                }

            }
            else if (rdpanelvan.Checked)
            {
                kasatipi = "Panelvan";
                if (rdacikkasa.Checked)
                {
                    aracalttipi = "Açık Kasa";
                    if (rdkabintipiciftkabin.Checked)
                    {
                        aracalttipi += "-Tek Kabin";
                    }
                    else
                    {
                        aracalttipi += "-Çift Kabin";
                    }
                }
                else
                {
                    aracalttipi = "Kapalı Kasa";
                }
            }
            else
            {
                kasatipi = "Glassvan";
                if (rdacikkasa.Checked)
                {
                    aracalttipi = "Açık Kasa";
                    if (rdkabintipiciftkabin.Checked)
                    {
                        aracalttipi += "-Tek Kabin";
                    }
                    else
                    {
                        aracalttipi += "-Çift Kabin";
                    }
                }
                else
                {
                    aracalttipi = "Kapalı Kasa";
                }
            }
        }

        private Bitmap BitmapBul(string deger)
        {
            Bitmap aracalani;
            if (deger == "B")
            {
                aracalani = new Bitmap(Properties.Resources.b, 100, 100);

            }
            else if (deger == "H")
            {
                aracalani = new Bitmap(Properties.Resources.h, 100, 100);

            }
            else if (deger == "Bİ")
            {
                aracalani = new Bitmap(Properties.Resources.bi, 100, 100);

            }
            else if (deger == "YB")
            {
                aracalani = new Bitmap(Properties.Resources.yb, 100, 100);

            }
            else if (deger == "LB")
            {
                aracalani = new Bitmap(Properties.Resources.lb, 100, 100);

            }
            else if (deger == "D")
            {
                aracalani = new Bitmap(Properties.Resources.d, 100, 100);

            }
            else if (deger == "P")
            {
                aracalani = new Bitmap(Properties.Resources.p, 100, 100);

            }
            else if (deger == "V")
            {
                aracalani = new Bitmap(Properties.Resources.vb, 100, 100);

            }
            else if (deger == "ST")
            {
                aracalani = new Bitmap(Properties.Resources.st, 100, 100);

            }
            else if (deger == "B/ST")
            {
                aracalani = new Bitmap(Properties.Resources.bst, 100, 100);

            }
            else if (deger == "Bİ/ST")
            {
                aracalani = new Bitmap(Properties.Resources.bist, 100, 100);

            }
            else if (deger == "YB/ST")
            {
                aracalani = new Bitmap(Properties.Resources.ybst, 100, 100);

            }
            else if (deger == "LB/ST")
            {
                aracalani = new Bitmap(Properties.Resources.lbst, 100, 100);

            }
            else if (deger == "D/ST")
            {
                aracalani = new Bitmap(Properties.Resources.dst, 100, 100);

            }
            else if (deger == "P/ST")
            {
                aracalani = new Bitmap(Properties.Resources.pst, 100, 100);
            }
            else if (deger == "V/ST")
            {
                aracalani = new Bitmap(Properties.Resources.vst, 100, 100);
            }
            else
            {
                aracalani = new Bitmap(Properties.Resources.ok, 100, 100);
            }
            return aracalani;
        }

        private void txtalicitc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }


        private void tabmain_SelectedIndexChanged(object sender, EventArgs e)
        {



            int index = tabmain.SelectedIndex;
            if (txtaliciadsoyad.Text.Trim() != "" && txtalicitelefon.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim() != "" && txtodemetutari.Text.Trim() != "")
            {
                tabmain.SelectedIndex = index;
            }
            else if (index != 0)
            {
                MessageBox.Show("* olan alanlar zorunludur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabmain.SelectedTab = tabalicibilgileri;
            }
        }

        private void txttestsonucu_TextChanged(object sender, EventArgs e)
        {
            int satir = 4 - txttestsonucu.Lines.Length;


            if (txttestsonucu.Lines.Length == 1)
            {
                lblsayac.Text = satir + " satır ve " + (400 - txttestsonucu.Text.Length).ToString() + " karakter hakkınız kaldı.";
            }
            else if (txttestsonucu.Lines.Length == 2)
            {
                lblsayac.Text = satir + " satır ve " + (300 - txttestsonucu.Text.Length).ToString() + " karakter hakkınız kaldı.";
            }
            else if (txttestsonucu.Lines.Length == 3)
            {
                lblsayac.Text = satir + " satır ve " + (200 - txttestsonucu.Text.Length).ToString() + " karakter hakkınız kaldı.";
            }
            else if (txttestsonucu.Lines.Length == 4)
            {
                lblsayac.Text = satir + " satır ve " + (100 - txttestsonucu.Text.Length).ToString() + " karakter hakkınız kaldı.";
            }
        }

        private void txttestsonucu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txttestsonucu.Lines.Length == 4)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void btnboyadegisenegec_Click(object sender, EventArgs e)
        {
            tabmain.SelectedIndex = (tabmain.SelectedIndex + 1 < tabmain.TabCount) ?
                             tabmain.SelectedIndex + 1 : tabmain.SelectedIndex;
        }

        Bitmap SasiHasarTuru;
        string SasiHasarAdiveLocation;
        Bitmap SasiBmp = new Bitmap(Properties.Resources.chassis, 1200, 500);

        private void btndefarmasyonsasi_Click(object sender, EventArgs e)
        {
            SasiHasarTuru = Properties.Resources.df;
            SasiHasarAdiveLocation = "D,";
        }

        private void btnkaynaklisasi_Click(object sender, EventArgs e)
        {
            SasiHasarTuru = Properties.Resources.i;
            SasiHasarAdiveLocation = "İ,";

        }
        private void btneklenmisparcasasi_Click(object sender, EventArgs e)
        {
            SasiHasarTuru = Properties.Resources.ep;
            SasiHasarAdiveLocation = "EP,";
        }

        private void btnclickeventsasi_Click(object sender, EventArgs e)
        {
            PictureBox tiklananBtn = (PictureBox)sender;
            pbchassis.Controls.Remove(tiklananBtn);
        }
        int islemno = 1;
        private void pbchassis_Click(object sender, EventArgs e)
        {
            islemno++;
            var mouseEventArgs = e as MouseEventArgs;

            PictureBox pbox = new PictureBox();
            pbox.Name = "btnSasiHasarTuru" + islemno.ToString();
            pbox.Width = 35;
            pbox.Height = 35;
            pbox.Tag += SasiHasarAdiveLocation + (mouseEventArgs.X - 10).ToString() + "," + (mouseEventArgs.Y - 10).ToString();
            pbox.BringToFront();
            pbox.Image = SasiHasarTuru;
            pbox.Location = new Point(mouseEventArgs.X - 10, mouseEventArgs.Y - 10);
            pbox.Click += btnclickeventsasi_Click;
            pbox.SizeMode = PictureBoxSizeMode.StretchImage;
            pbox.BackColor = Color.Transparent;
            pbchassis.Controls.Add(pbox);
        }

        private void btnsasidevamet_Click(object sender, EventArgs e)
        {
            if ((tabmain.TabPages.IndexOf(tabpagechassis) + 1).ToString() == (tabmain.TabPages.Count).ToString())
            {
                RaporlariYazdir();
            }
            else
            {
                tabmain.SelectedIndex = (tabmain.SelectedIndex + 1 < tabmain.TabCount) ?
                   tabmain.SelectedIndex + 1 : tabmain.SelectedIndex;
            }

        }

        private void btnonduzendevamet_Click(object sender, EventArgs e)
        {
            if ((tabmain.TabPages.IndexOf(tabOnDuzen) + 1).ToString() == (tabmain.TabPages.Count).ToString())
            {
                RaporlariYazdir();
            }
            else
            {
                tabmain.SelectedIndex = (tabmain.SelectedIndex + 1 < tabmain.TabCount) ?
                  tabmain.SelectedIndex + 1 : tabmain.SelectedIndex;
            }

        }

        private void btnfrenrapordevamet_Click(object sender, EventArgs e)
        {
            if ((tabmain.TabPages.IndexOf(tabFren) + 1).ToString() == (tabmain.TabPages.Count).ToString())
            {
                RaporlariYazdir();
            }
            else
            {
                tabmain.SelectedIndex = (tabmain.SelectedIndex + 1 < tabmain.TabCount) ?
                  tabmain.SelectedIndex + 1 : tabmain.SelectedIndex;
            }

        }
        private void btnraporac_Click(object sender, EventArgs e)
        {
            if ((tabmain.TabPages.IndexOf(TabBoyaDegisen) + 1).ToString() == (tabmain.TabPages.Count).ToString())
            {
                RaporlariYazdir();
            }
            else
            {
                tabmain.SelectedIndex = (tabmain.SelectedIndex + 1 < tabmain.TabCount) ?
                   tabmain.SelectedIndex + 1 : tabmain.SelectedIndex;
            }


        }
        private void btndevamsuspansiyon_Click(object sender, EventArgs e)
        {
            if ((tabmain.TabPages.IndexOf(tabSuspansiyon) + 1).ToString() == (tabmain.TabPages.Count).ToString())
            {
                RaporlariYazdir();
            }
            else
            {
                tabmain.SelectedIndex = (tabmain.SelectedIndex + 1 < tabmain.TabCount) ?
                   tabmain.SelectedIndex + 1 : tabmain.SelectedIndex;

            }

        }

        private void RaporlariYazdir()
        {
            try
            {
                DialogResult yazdir = new DialogResult();
                yazdir = MessageBox.Show("Raporları kaydet ve yazdır ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yazdir == DialogResult.Yes)
                {
                    string veriadresi = @"//10.0.0.141/SalautoRaporlar/" + musteridegerleri.barkodno;
                    Directory.CreateDirectory(veriadresi);
                    if (cbetiket.Checked == true)
                    {
                        try
                        {

                            var label = DYMO.Label.Framework.Label.Open(Application.StartupPath + "\\etiket.label");
                            label.SetObjectText("txtbarcode", barkodkodu);

                            string byazici = @default.Default.BarkodYazici;
                            label.Print(byazici);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);


                            //MessageBox.Show("Barkod etiket yazıcınızı kontrol edin", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    musteridegerleri.plaka = txtplaka.Text;
                    musteridegerleri.kmsi = txtarackilometre.Text;
                    musteridegerleri.renk = cbaracrenk.Text;
                    musteridegerleri.testsonucu = txttestsonucu.Text;
                    musteridegerleri.alicitelefon = txtalicitelefon.Text;
                    musteridegerleri.aracyili = cbaracmodeli.Text;
                    musteridegerleri.yakitturu = cbyakittipi.Text;
                    musteridegerleri.renk = cbaracrenk.Text;
                    musteridegerleri.motorno = txtmotorno.Text;
                    musteridegerleri.sasino = txtsasino.Text;
                    musteridegerleri.aliciadsoyad = txtaliciadsoyad.Text;
                    musteridegerleri.vites = cbvitestipi.Text;
                    musteridegerleri.aracmodeli = cbaracmodeli.Text;
                    musteridegerleri.uyarimesaji = txtuyariyazisi.Text;

                    if (listaracmarka.Text != listarackasa.Text)
                    {
                        musteridegerleri.aracmodeli = listaracmarka.Text + " " + listaracmodel.Text + " " + listarackasa.Text.Replace("-", "") + " " + listaracversiyon.Text.Replace("-", "");
                    }
                    else
                    {
                        musteridegerleri.aracmodeli = listaracmarka.Text + " " + listaracmodel.Text;
                    }
                    var deger = db.TBL_BOYAKONUMLARI.ToList();
                    if (rdsedan.Checked && rdhususi2.Checked)
                    {
                        musteridegerleri.arackasa = "Sedan";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "Sedan").ToList();
                    }
                    else if (rdhususi2.Checked && rdglassvan.Checked && rd4kapihususi.Checked)
                    {
                        musteridegerleri.arackasa = "Glassvan-Kapalı Kasa-Standart";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "Glassvan-Kapalı Kasa-Standart").ToList();
                    }
                    else if (rdticari.Checked && rdglassvan.Checked && rdkapalikasa.Checked && rdkabintipi4kapi.Checked)
                    {
                        musteridegerleri.arackasa = "Glassvan-Kapalı Kasa-Standart";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "Glassvan-Kapalı Kasa-Standart").ToList();
                    }
                    else if (rdticari.Checked && rdglassvan.Checked && rdkapalikasa.Checked && rdkabintipi3kapi.Checked)
                    {
                        musteridegerleri.arackasa = "Glassvan-Kapalı Kasa-Standart-3 Kapı";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "Glassvan-Kapalı Kasa-Standart").ToList();
                    }
                    else if (rdticari.Checked && rdpanelvan.Checked && rdkapalikasa.Checked && rdkabintipi3kapi.Checked)
                    {
                        musteridegerleri.arackasa = "Panelvan-Kapalı Kasa-Standart";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "Panelvan-Kapalı Kasa-Standart").ToList();
                    }
                    else if (rdticari.Checked && rdminivan.Checked && rdkapalikasa.Checked && rdkabintipi3kapi.Checked && rddigercamli.Checked)
                    {
                        musteridegerleri.arackasa = "Minivan-Kapalı Kasa-Standart";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "Minivan-Kapalı Kasa-Standart").ToList();
                    }
                    else if (rdticari.Checked && rdminivan.Checked && rdkapalikasa.Checked && rdkabintipi3kapi.Checked && rddigercamsiz.Checked)
                    {
                        musteridegerleri.arackasa = "Minivan-Kapalı Kasa-Standart-Camsız";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "Minivan-Kapalı Kasa-Standart").ToList();
                    }
                    else if (rdticari.Checked && rdmidivan.Checked && rdkapalikasa.Checked && rdkabintipi3kapi.Checked && rddigercamli.Checked)
                    {
                        musteridegerleri.arackasa = "Midivan-Kapalı Kasa-Standart";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "Minivan-Kapalı Kasa-Standart").ToList();
                    }
                    else if (rdticari.Checked && rdmidivan.Checked && rdkapalikasa.Checked && rdkabintipi3kapi.Checked && rddigercamsiz.Checked)
                    {
                        musteridegerleri.arackasa = "Midivan-Kapalı Kasa-Standart-Camsız";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "Minivan-Kapalı Kasa-Standart").ToList();
                    }
                    else if (rdticari.Checked && rdpanelvan.Checked && rdacikkasa.Checked && rdkabintipitekkabin.Checked)
                    {
                        musteridegerleri.arackasa = "Pickup Tek Kabin";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "Pickup").ToList();
                    }
                    else if (rdticari.Checked && rdpanelvan.Checked && rdacikkasa.Checked && rdkabintipiciftkabin.Checked)
                    {
                        musteridegerleri.arackasa = "Pickup Çift Kabin";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "Pickup").ToList();
                    }
                    else if (rdticari.Checked && rdpanelvan.Checked && rdkapalikasa.Checked && rdkabintipi2kapi.Checked)
                    {
                        musteridegerleri.arackasa = "Hatchbag Tek Kapı";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "HatchbagTekKapi").ToList();
                    }

                    else if (rdhususi2.Checked && rdhatchbag.Checked && rdtekkapihususi.Checked)
                    {
                        musteridegerleri.arackasa = "Hatchbag Tek Kapı";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "HatchbagTekKapi").ToList();
                    }
                    else if (rdsuv.Checked && rdtekkapihususi.Checked)
                    {
                        musteridegerleri.arackasa = "SUV Tek Kapı";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "SUV").ToList();
                    }
                    else if (rdsuv.Checked && rd4kapihususi.Checked)
                    {
                        musteridegerleri.arackasa = "SUV Çift Kapı";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "SUV").ToList();
                    }
                    else if (rdsw.Checked && rd4kapihususi.Checked)
                    {
                        musteridegerleri.arackasa = "SW";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "SW").ToList();
                    }
                    else if (rdsw.Checked && rdtekkapihususi.Checked)
                    {
                        musteridegerleri.arackasa = "SW 2 Kapı";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "SW").ToList();
                    }
                    else if (rdhususi2.Checked && rdcoupe.Checked)
                    {
                        musteridegerleri.arackasa = "Coupe";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "HatchbagTekKapi").ToList();
                    }
                    else if (rdhususi2.Checked && rdcabrio.Checked && rdtekkapihususi.Checked)
                    {
                        musteridegerleri.arackasa = "Cabrio";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "HatchbagTekKapi").ToList();
                    }
                    else if (rdhususi2.Checked && rdcabrio.Checked && rd4kapihususi.Checked)
                    {
                        musteridegerleri.arackasa = "Cabrio4";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "HatchbagTekKapi").ToList();
                    }
                    else
                    {
                        musteridegerleri.arackasa = "Hatchbag";
                        deger = db.TBL_BOYAKONUMLARI.Where(x => x.AracTipi == "Hatchbag").ToList();
                    }
                    musteridegerleri.veriadresi = veriadresi;

                    if (cbgirissayfasi.Checked)
                    {
                        RaporBaslik.RaporYaz();
                    }

                    if (cbyapilantestler.Checked)
                    {
                        YapilanTestlerRapor.RaporYaz();
                    }



                    string[] pliste = db.Paketler.FirstOrDefault(x => x.PaketAdi == droppaketler.Text).PaketIcerik.ToString().Split(',');

                    foreach (var item in pliste)
                    {
                        if (item.ToString() == "Boya/Değişen")
                        {

                            boyakonumlari.solarkacamurlukX = deger.FirstOrDefault(x => x.KonumAdi == "Sol Arka Çamurluk").KonumX.Toint58();
                            boyakonumlari.solarkacamurlukY = deger.FirstOrDefault(x => x.KonumAdi == "Sol Arka Çamurluk").KonumY.Toint58();
                            boyakonumlari.solarkakapiX = deger.FirstOrDefault(x => x.KonumAdi == "Sol Arka Kapı").KonumX.Toint58();
                            boyakonumlari.solarkakapiY = deger.FirstOrDefault(x => x.KonumAdi == "Sol Arka Kapı").KonumY.Toint58();
                            boyakonumlari.solonkapiX = deger.FirstOrDefault(x => x.KonumAdi == "Sol Ön Kapı").KonumX.Toint58();
                            boyakonumlari.solonkapiY = deger.FirstOrDefault(x => x.KonumAdi == "Sol Ön Kapı").KonumY.Toint58();
                            boyakonumlari.soloncamurlukX = deger.FirstOrDefault(x => x.KonumAdi == "Sol Ön Çamurluk").KonumX.Toint58();
                            boyakonumlari.soloncamurlukY = deger.FirstOrDefault(x => x.KonumAdi == "Sol Ön Çamurluk").KonumY.Toint58();
                            /**/
                            boyakonumlari.sagarkacamurlukX = deger.FirstOrDefault(x => x.KonumAdi == "Sağ Arka Çamurluk").KonumX.Toint58();
                            boyakonumlari.sagarkacamurlukY = deger.FirstOrDefault(x => x.KonumAdi == "Sağ Arka Çamurluk").KonumY.Toint58();
                            boyakonumlari.sagarkakapiX = deger.FirstOrDefault(x => x.KonumAdi == "Sağ Arka Kapı").KonumX.Toint58();
                            boyakonumlari.sagarkakapiY = deger.FirstOrDefault(x => x.KonumAdi == "Sağ Arka Kapı").KonumY.Toint58();
                            boyakonumlari.sagonkapiX = deger.FirstOrDefault(x => x.KonumAdi == "Sağ Ön Kapı").KonumX.Toint58();
                            boyakonumlari.sagonkapiY = deger.FirstOrDefault(x => x.KonumAdi == "Sağ Ön Kapı").KonumY.Toint58();
                            boyakonumlari.sagoncamurlukX = deger.FirstOrDefault(x => x.KonumAdi == "Sağ Ön Çamurluk").KonumX.Toint58();
                            boyakonumlari.sagoncamurlukY = deger.FirstOrDefault(x => x.KonumAdi == "Sağ Ön Çamurluk").KonumY.Toint58();
                            /**/
                            boyakonumlari.kaputX = deger.FirstOrDefault(x => x.KonumAdi == "Kaput").KonumX.Toint58();
                            boyakonumlari.kaputY = deger.FirstOrDefault(x => x.KonumAdi == "Kaput").KonumY.Toint58();
                            boyakonumlari.tavanX = deger.FirstOrDefault(x => x.KonumAdi == "Tavan").KonumX.Toint58();
                            boyakonumlari.tavanY = deger.FirstOrDefault(x => x.KonumAdi == "Tavan").KonumY.Toint58();
                            boyakonumlari.bagajX = deger.FirstOrDefault(x => x.KonumAdi == "Bagaj").KonumX.Toint58();
                            boyakonumlari.bagajY = deger.FirstOrDefault(x => x.KonumAdi == "Bagaj").KonumY.Toint58();



                            #region Sedan Boya Resimleri
                            //Sol Taraf Değerler 
                            boyadegerleri.soloncamurluk = BitmapBul(soloncamurluk.SelectedValue.ToString());
                            boyadegerleri.solonkapi = BitmapBul(solonkapi.SelectedValue.ToString());
                            boyadegerleri.solarkakapi = BitmapBul(solarkakapi.SelectedValue.ToString());
                            boyadegerleri.solarkacamurluk = BitmapBul(solarkacamurluk.SelectedValue.ToString());
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            //Sağ Taraf Değerler 
                            boyadegerleri.sagarkacamurluk = BitmapBul(sagarkacamurluk.SelectedValue.ToString());
                            boyadegerleri.sagarkakapi = BitmapBul(sagarkapaki.SelectedValue.ToString());
                            boyadegerleri.sagoncamurluk = BitmapBul(sagoncamurluk.SelectedValue.ToString());
                            boyadegerleri.sagonkapi = BitmapBul(sagonkapi.SelectedValue.ToString());
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            //Tavan-Kaput-Bagaj
                            boyadegerleri.kaput = BitmapBul(kaput.SelectedValue.ToString());
                            boyadegerleri.tavan = BitmapBul(tavan.SelectedValue.ToString());
                            boyadegerleri.bagaj = BitmapBul(bagaj.SelectedValue.ToString());
                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            #endregion




                            BoyaRapor.RaporYaz();

                            GC.Collect();
                            GC.WaitForPendingFinalizers();


                            boyadegerleri.soloncamurluk.Dispose();
                            boyadegerleri.solonkapi.Dispose();
                            boyadegerleri.solarkakapi.Dispose();
                            boyadegerleri.solarkacamurluk.Dispose();

                            boyadegerleri.sagarkacamurluk.Dispose();
                            boyadegerleri.sagarkakapi.Dispose();
                            boyadegerleri.sagoncamurluk.Dispose();
                            boyadegerleri.sagonkapi.Dispose();

                            boyadegerleri.kaput.Dispose();
                            boyadegerleri.tavan.Dispose();
                            boyadegerleri.bagaj.Dispose();

                            pbkamera.Image.Dispose();
                            GC.Collect();
                            GC.WaitForPendingFinalizers();


                        }
                        if (item.ToString() == "Şasi Kontrol")
                        {
                            List<sasikonumlari> skonumlistesi = new List<sasikonumlari>();
                            foreach (var sasiitem in pbchassis.Controls)
                            {
                                if (sasiitem is PictureBox)
                                {
                                    string[] dizi = ((PictureBox)sasiitem).Tag.ToString().Split(',');
                                    sasikonumlari skonum = new sasikonumlari();
                                    if (dizi[0].ToString() == "D")
                                    {
                                        skonum.sasideger = Properties.Resources.df;
                                    }
                                    else if (dizi[0].ToString() == "İ")
                                    {
                                        skonum.sasideger = Properties.Resources.i;
                                    }
                                    else
                                    {
                                        skonum.sasideger = Properties.Resources.ep;
                                    }
                                    skonum.X = Convert.ToInt32(dizi[1]);
                                    skonum.Y = Convert.ToInt32(dizi[2]);
                                    skonumlistesi.Add(skonum);

                                }
                            }
                            sasilist.sliste = skonumlistesi;
                            SasiRapor.RaporYaz();

                        }
                        if (item.ToString() == "Ön Düzen")
                        {
                            onduzensonuclari.SolAmartisorTakozu = "1-Amortisör Takozu/Bilyası " + cbsoltarafamartisortakozuvebilyasi.Text;
                            onduzensonuclari.SolUstTabla = "2-Üst Tabla " + cbsoltarafamartisortakozuvebilyasi.Text;
                            onduzensonuclari.SolYanTablaKolu = "3-Yan Tabla Kolu " + cbsoltarafamartisortakozuvebilyasi.Text;
                            onduzensonuclari.SolPorya = "4-Porya " + cbsoltarafamartisortakozuvebilyasi.Text;
                            onduzensonuclari.SolZrot = "5-Z Rot " + cbsoltarafamartisortakozuvebilyasi.Text;
                            onduzensonuclari.SolTabla = "6-Tabla " + cbsoltarafamartisortakozuvebilyasi.Text;
                            onduzensonuclari.SolTeraziKolu = "7-Terazi Kolu " + cbsoltarafamartisortakozuvebilyasi.Text;

                            onduzensonuclari.SagAmartisorTakozu = "1-Amortisör Takozu/Bilyası " + cbsagtarafamartisortakozuvebilyasi.Text;
                            onduzensonuclari.SagUstTabla = "2-Üst Tabla " + cbsagtarafusttabla.Text;
                            onduzensonuclari.SagYanTablaKolu = "3-Yan Tabla Kolu " + cbsagtarafyantablakolu.Text;
                            onduzensonuclari.SagPorya = "4-Porya " + cbsagtarafporya.Text;
                            onduzensonuclari.SagZrot = "5-Z Rot " + cbsagtarafzrot.Text;
                            onduzensonuclari.SagTabla = "6-Tabla " + cbsagtaraftabla.Text;
                            onduzensonuclari.SagTeraziKolu = "7-Terazi Kolu " + cbsagtarafterazikolu.Text;
                            OnDuzenRapor.RaporYaz();
                        }
                        if (item.ToString() == "Fren")
                        {
                            frendegerleri.AbsDurumu = cbabs.Text;
                            frendegerleri.EspDurumu = cbesp.Text;
                            frendegerleri.FrenAnaMerkezi = cbfrenmerkezpompasi.Text;

                            frendegerleri.SolOnFrenDiski = cbsolonfrendiski.Text;
                            frendegerleri.SolOnFrenBalatasi = cbsolonfrenbalatasi.Text;
                            frendegerleri.SolOnFrenPistonlari = cbsolonfrenpistonlari.Text;
                            frendegerleri.SolOnFrenHortumlari = cbsolonfrenhortumlari.Text;
                            frendegerleri.SolOnBijonGirisleri = cbsolonbijongirisleri.Text;
                            frendegerleri.SolOnHidrolikSeviyesi = cbsolonhidrolikseviyesi.Text;
                            frendegerleri.SolOnMerkezPompasi = cbsolonmerkezpompasi.Text;
                            frendegerleri.SolOnKampana = cbsolonkampana.Text;
                            frendegerleri.SolOnLimitor = cbsolonlimitor.Text;
                            frendegerleri.SolOnServo = cbsolonservo.Text;

                            frendegerleri.SagOnFrenDiski = cbsagonfrendiski.Text;
                            frendegerleri.SagOnFrenBalatasi = cbsagonfrenbalatasi.Text;
                            frendegerleri.SagOnFrenPistonlari = cbsagonfrenpistonlari.Text;
                            frendegerleri.SagOnFrenHortumlari = cbsagonfrenhortumlari.Text;
                            frendegerleri.SagOnBijonGirisleri = cbsagonbijongirisleri.Text;
                            frendegerleri.SagOnHidrolikSeviyesi = cbsagonhidrolikseviyesi.Text;
                            frendegerleri.SagOnMerkezPompasi = cbsagonmerkezpompasi.Text;
                            frendegerleri.SagOnKampana = cbsagonkampana.Text;
                            frendegerleri.SagOnLimitor = cbsagonlimitor.Text;
                            frendegerleri.SagOnServo = cbsagonservo.Text;

                            frendegerleri.SolArkaFrenDiski = cbsolarkafrendiski.Text;
                            frendegerleri.SolArkaFrenBalatasi = cbsolarkafrenbalatasi.Text;
                            frendegerleri.SolArkaFrenPistonlari = cbsolarkafrenpistonlari.Text;
                            frendegerleri.SolArkaFrenHortumlari = cbsolarkafrenhortumlari.Text;
                            frendegerleri.SolArkaBijonGirisleri = cbsolarkabijongirisleri.Text;
                            frendegerleri.SolArkaHidrolikSeviyesi = cbsolarkahidrolikseviyesi.Text;
                            frendegerleri.SolArkaMerkezPompasi = cbsolarkamerkezpompasi.Text;
                            frendegerleri.SolArkaKampana = cbsolarkakampana.Text;
                            frendegerleri.SolArkaLimitor = cbsolarkalimitor.Text;
                            frendegerleri.SolArkaServo = cbsolarkaservo.Text;

                            frendegerleri.SagArkaFrenDiski = cbsagarkafrendiski.Text;
                            frendegerleri.SagArkaFrenBalatasi = cbsagarkafrenbalatasi.Text;
                            frendegerleri.SagArkaFrenPistonlari = cbsagarkafrenpistonlari.Text;
                            frendegerleri.SagArkaFrenHortumlari = cbsagarkafrenhortumlari.Text;
                            frendegerleri.SagArkaBijonGirisleri = cbsagarkabijongirisleri.Text;
                            frendegerleri.SagArkaHidrolikSeviyesi = cbsagarkahidrolikseviyesi.Text;
                            frendegerleri.SagArkaMerkezPompasi = cbsagarkamerkezpompasi.Text;
                            frendegerleri.SagArkaKampana = cbsagarkakampana.Text;
                            frendegerleri.SagArkaLimitor = cbsagarkalimitor.Text;
                            frendegerleri.SagArkaServo = cbsagarkaservo.Text;
                            FrenRapor.RaporYaz();
                        }
                        if (item.ToString() == "Süspansiyon")
                        {

                            suspansiyondegerleri.solonamortisor = cbsolonamortisor.Text;
                            suspansiyondegerleri.solonamortisortakozu = cbsolonamartisortakozu.Text;
                            suspansiyondegerleri.solonsuspansiyonkollari = cbsolonsuspansiyonkollari.Text;
                            suspansiyondegerleri.solonhelezonyayi = cbsolonhelezonyayi.Text;

                            suspansiyondegerleri.solarkaamortisor = cbsolarkaamortisor.Text;
                            suspansiyondegerleri.solarkaamortisortakozu = cbsolarkaamortisortakozu.Text;
                            suspansiyondegerleri.solarkasuspansiyonkollari = cbsolarkasuspansiyonkollari.Text;
                            suspansiyondegerleri.solarkahelezonyayi = cbsolarkahelezonyayi.Text;

                            suspansiyondegerleri.sagonamortisor = cbsagonamortisor.Text;
                            suspansiyondegerleri.sagonamortisortakozu = cbsagarkaamortisortakozu.Text;
                            suspansiyondegerleri.sagonsuspansiyonkollari = cbsagonsuspansiyonkollari.Text;
                            suspansiyondegerleri.sagonhelezonyayi = cbsagonhelezonyayi.Text;

                            suspansiyondegerleri.sagarkaamortisor = cbsagarkaamortisor.Text;
                            suspansiyondegerleri.sagarkaamortisortakozu = cbsagarkaamortisortakozu.Text;
                            suspansiyondegerleri.sagarkasuspansiyonkollari = cbsagarkasuspansiyonkollari.Text;
                            suspansiyondegerleri.sagarkahelezonyayi = cbsagarkahelezonyayi.Text;

                            SuspansiyonRapor.RaporYaz();
                        }
                        if (item.ToString() == "Motor")
                        {
                            motordegerleri.ustkapak = cbmotorustkapak.Text;
                            motordegerleri.silindirkapak = cbmotorsilindirkapak.Text;
                            motordegerleri.sarjdinamosu = cbmotorsarjdinamosu.Text;
                            motordegerleri.vkayisi = cbmotorvkayisi.Text;
                            motordegerleri.krankkasnagi = cbmotorkrankkasnagi.Text;
                            motordegerleri.motorkasnaklari = cbmotorkasnaklari.Text;
                            motordegerleri.marsdinamosu = cbmotormarsdinamosu.Text;
                            motordegerleri.yakitpompasi = cbmotoryakitpompasi.Text;
                            motordegerleri.elektriktesisati = cbmotorelektriktesisati.Text;
                            motordegerleri.klimahortumu = cbmotorklimahortumu.Text;
                            motordegerleri.egr = cbmotoregr.Text;
                            motordegerleri.turbo = cbmotorturbo.Text;
                            motordegerleri.turbohortumlari = cbmotorturbohortumlari.Text;
                            motordegerleri.klima = cbmotorklima.Text;
                            motordegerleri.klimagazi = cbmotorklimagazi.Text;
                            motordegerleri.emmemanifortu = cbmotoremmemanifortu.Text;
                            motordegerleri.kelebekkutusu = cbmotorkelebekkutusu.Text;
                            motordegerleri.motorkulagi = cbmotorkulagi.Text;
                            motordegerleri.motorbeyni = cbmotorbeyni.Text;
                            motordegerleri.yagseviyesi = cbmotoryagseviyesi.Text;
                            motordegerleri.egzozemisyon = cbmotoregzozemisyonfiltresi.Text;
                            motordegerleri.havaakisfiltresi = cbmotorhavaakismetre.Text;
                            motordegerleri.sogutmasistemi = cbmotorsogutmasistemi.Text;
                            motordegerleri.yagkacagi = cbmotoryagkacagi.Text;
                            motordegerleri.ufleme = cbmotorufleme.Text;
                            motordegerleri.yagyakma = cbmotoryagyakma.Text;
                            motordegerleri.sibopiticileri = cbmotorsibopiticileri.Text;
                            motordegerleri.silindirkapakconta = cbmotorsilindirkapakcontasi.Text;
                            motordegerleri.suhortumlari = cbmotorsuhortumlari.Text;
                            motordegerleri.yakithortumlari = cbmotoryakithortumlari.Text;
                            motordegerleri.lpgsistemivekizdirmabujileri = cbmotorlpgveKizdirmaBuji.Text;
                            motordegerleri.ateslemesistemiveyakitenjektorleri = cbmotorateslemeveYakitEnjektor.Text;

                            if (cbyakittipi.Text == "Dizel" && cbMotorTabloYazdir.Checked)
                            {
                                motordegerleri.RaporResmi = new Bitmap(Properties.Resources.cdizelmotor, 2480, 3508);

                            }
                            else if (cbyakittipi.Text == "Dizel" && cbMotorTabloYazdir.Checked)
                            {
                                motordegerleri.RaporResmi = new Bitmap(Properties.Resources.cdizelmotorTablosuz, 2480, 3508);

                            }
                            else
                            {
                                if (cbMotorTabloYazdir.Checked)
                                {
                                    motordegerleri.RaporResmi = new Bitmap(Properties.Resources.cbenzinlpgmotor, 2480, 3508);
                                }
                                else
                                {
                                    motordegerleri.RaporResmi = new Bitmap(Properties.Resources.cbenzinlpgmotorTablosuz, 2480, 3508);

                                }
                            }

                            motordegerleri.MotorPerformansPuani = Math.Round(((txtdynomotorgucu.Text.ToDouble() / txtfabrikamotorgucu.Text.ToDouble()) * 100), 1, MidpointRounding.AwayFromZero);
                            motordegerleri.MotorGenelDurum = cbmotordurumu.Text;

                            MotorRapor.RaporYaz(cbMotorTabloYazdir.Checked);
                        }

                        if (item.ToString() == "Şanzıman")
                        {

                            sanzimandegerleri.baskibalata = cbsanzimanbaskibalata.Text;
                            sanzimandegerleri.vitesgecisleri = cbsanzimanvitesgecisleri.Text;
                            sanzimandegerleri.yagkacagi = cbsanzimanyagkacagi.Text;
                            sanzimandegerleri.sanzimankulagi = cbsanzimankulagi.Text;
                            sanzimandegerleri.sanzimanbeyni = cbsanzimanbeyni.Text;
                            if (cbvitestipi.Text == "Manuel")
                            {
                                ManuelSanzimanRapor.RaporYaz();

                            }
                            else if (cbvitestipi.Text == "Otomatik")
                            {

                                OtoSanzimanRapor.RaporYaz();
                            }
                            else
                            {
                                TripDsgSanzimanRapor.RaporYaz();
                            }
                        }
                        if (item.ToString() == "Dış Aydınlatma")
                        {

                            disaydinlatmadegerleri.solonsinyal = cbsolondisaydinlatmasinyal.Text;
                            disaydinlatmadegerleri.solonfarlar = cbsolondisaydinlatmafarlar.Text;
                            disaydinlatmadegerleri.solonparklambasi = cbsolondisaydinlatmaparkl.Text;
                            disaydinlatmadegerleri.solonsislambasi = cbsolondisaydinlatmasisl.Text;
                            disaydinlatmadegerleri.solaynasinyallambasi = cbdisaydinlatmasolaynasinyal.Text;


                            disaydinlatmadegerleri.sagonsinyal = cbsagondisaydinlatmasinyal.Text;
                            disaydinlatmadegerleri.sagonfarlar = cbsagondisaydinlatmafarlar.Text;
                            disaydinlatmadegerleri.sagonparklambasi = cbsagondisaydinlatmaparkl.Text;
                            disaydinlatmadegerleri.sagonsislambasi = cbsagondisaydinlatmasisl.Text;
                            disaydinlatmadegerleri.sagaynasinyal = cbdisaydinlatmasagaynasinyal.Text;


                            disaydinlatmadegerleri.solarkasinyal = cbsolarkadisaydinlatmasinyal.Text;
                            disaydinlatmadegerleri.solarkafrenlambasi = cbsolarkadisaydinlatmafrenl.Text;
                            disaydinlatmadegerleri.solarkaparklambasi = cbsolarkadisaydinlatmaparkl.Text;
                            disaydinlatmadegerleri.solarkageriviteslambasi = cbsolarkadisaydinlatmagerivitesl.Text;
                            disaydinlatmadegerleri.plakaisigi = cbdisaydinlatmaplakaisigi.Text;


                            disaydinlatmadegerleri.sagarkasinyal = cbsagarkadisaydinlatmasinyal.Text;
                            disaydinlatmadegerleri.sagarkafrenlambasi = cbsagarkadisaydinlatmafrenl.Text;
                            disaydinlatmadegerleri.sagarkaparklambasi = cbsagarkadisaydinlatmaparkl.Text;
                            disaydinlatmadegerleri.sagarkageriviteslambasi = cbsagarkadisaydinlatmagerivitesl.Text;
                            disaydinlatmadegerleri.dortluisigi = cbdisaydinlatmadortlulambasi.Text;

                            DisAydinlatmaRapor.RaporYaz();
                        }
                        if (item.ToString() == "Donanım")
                        {

                            donanimdegerleri.surucuhy = cbdonanimsurucuhy.Text;
                            donanimdegerleri.yolcuhy = cbdonanimyolcuhy.Text;
                            donanimdegerleri.bagajdosemesi = cbdonanimbagajdosemesi.Text;
                            donanimdegerleri.gogusdosemesi = cbdonanimgogusdosemesi.Text;
                            donanimdegerleri.camtavan = cbdonanimcamtavan.Text;

                            donanimdegerleri.onemniyetk = cbdonanimOnEmnK.Text;
                            donanimdegerleri.arkaemniyet = cbdonanimArkaEmn.Text;
                            donanimdegerleri.otomatikcamlar = cbdonanimotomatikC.Text;
                            donanimdegerleri.tavanaydinlatamasi = cbdonanimtavanA.Text;
                            donanimdegerleri.kapiaydinlatmasi = cbdonanimkapiA.Text;

                            donanimdegerleri.koltukdosemeleri = cbdonanimKoltukD.Text;
                            donanimdegerleri.direksiyon = cbdonanimdireksiyon.Text;
                            donanimdegerleri.merkezikilit = cbdonanimmerkeziK.Text;
                            donanimdegerleri.sunroof = cbdonanimSunroof.Text;
                            donanimdegerleri.alarm = cbdonanimAlarm.Text;

                            donanimdegerleri.sagayna = cbdonanimSagAyna.Text;
                            donanimdegerleri.solayna = cbdonanimSolAyna.Text;
                            donanimdegerleri.panelvekadran = cbdonanimpanelveKadran.Text;
                            donanimdegerleri.konsol = cbdonanimKonsol.Text;
                            donanimdegerleri.silecekler = cbdonanimsilecekler.Text;
                            DonanimRapor.RaporYaz();
                        }
                        if (item.ToString() == "Elektrik")
                        {

                            elektrikdegerleri.akudurumu = cbelektrikraporuaku.Text;
                            elektrikdegerleri.sarjdinamosu = cbelektrikraporsarjd.Text;
                            elektrikdegerleri.marsdinamosu = cbelektrikraporumarsd.Text;
                            elektrikdegerleri.klimaelektrik = cbelektrikraporklima.Text;

                            elektrikdegerleri.yakitsistemielektrik = cbelektrikraporyakit.Text;
                            elektrikdegerleri.motorelektrik = cbelektrikrapormotor.Text;
                            elektrikdegerleri.otomatikcamelektrik = cbelektrikraporotomatikcam.Text;
                            elektrikdegerleri.aydinlatmaelektrik = cbelektrikraporaydinlatma.Text;

                            elektrikdegerleri.teypelektrik = cbelektrikraporteyp.Text;
                            elektrikdegerleri.sogutmasistemielektrik = cbelelektrikraporsogutma.Text;
                            elektrikdegerleri.merkezikilitelektrik = cbelektrikrapormerkezik.Text;
                            elektrikdegerleri.alarmsistemielektrik = cbelektrikraporalarm.Text;

                            elektrikdegerleri.sagaynaelektrik = cbelektrikraporsagayna.Text;
                            elektrikdegerleri.solaynaelektrik = cbelektrikraporsolayna.Text;
                            elektrikdegerleri.panelvekadranelektrik = cbelektrikraporpanelkadran.Text;
                            elektrikdegerleri.tesisatkacak = cbelektrikraportesisatkacak.Text;

                            ElektrikRapor.RaporYaz();
                        }
                        if (item.ToString() == "Resimler")
                        {
                            try
                            {
                                AracDisGorselRapor.RaporYaz();
                            }
                            catch (Exception)
                            {
                                return;
                            }
                        }
                    }
                    TBL_MUSTERILER musteri = new TBL_MUSTERILER { AliciAdsoyad = txtaliciadsoyad.Text, AliciEmail = "-", AliciTcNo = "-", AliciTelefon = txtalicitelefon.Text, SaticiAdsoyad = "-", SaticiıEmail = "-", SaticiTcNo = "-", SaticiTelefon = "-", BarkodNo = musteridegerleri.barkodno, PaketAdi = droppaketler.Text, PaketIcerik = db.Paketler.FirstOrDefault(x => x.PaketAdi == droppaketler.Text).PaketIcerik };
                    db.TBL_MUSTERILER.Add(musteri);
                    db.SaveChanges();

                    TBL_ARACBOYASONUC boya = new TBL_ARACBOYASONUC();
                    try
                    {
                        boya = new TBL_ARACBOYASONUC { Bagaj = bagaj.SelectedValue.ToString(), Tavan = tavan.SelectedValue.ToString(), Kaput = kaput.SelectedValue.ToString(), SolArkaCamurluk = solarkacamurluk.SelectedValue.ToString(), SolArkaKapi = solarkakapi.SelectedValue.ToString(), SolOnCamurluk = soloncamurluk.SelectedValue.ToString(), SolOnKapi = solonkapi.SelectedValue.ToString(), SagArkaCamurluk = sagarkacamurluk.SelectedValue.ToString(), SagArkaKapi = sagarkapaki.SelectedValue.ToString(), SagOnCamurluk = sagoncamurluk.SelectedValue.ToString(), SagOnKapi = sagonkapi.SelectedValue.ToString(), TestSonucu = txttestsonucu.Text };
                        db.TBL_ARACBOYASONUC.Add(boya);
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        boya = new TBL_ARACBOYASONUC { Bagaj = "-", Tavan = "-", Kaput = "-", SolArkaCamurluk = "-", SolArkaKapi = "-", SolOnCamurluk = "-", SolOnKapi = "-", SagArkaCamurluk = "-", SagArkaKapi = "-", SagOnCamurluk = "-", SagOnKapi = "-", TestSonucu = "-" };
                        db.TBL_ARACBOYASONUC.Add(boya);
                        db.SaveChanges();
                    }

                    string kaskodurumu, sigortateklifi, kullanimturu, kasatipi, aracalttipi;
                    RadioKontrolleri(out kaskodurumu, out sigortateklifi, out kullanimturu, out kasatipi, out aracalttipi);

                    TBL_MUSTERIARACLARI musteriaraci = new TBL_MUSTERIARACLARI { MarkaID = listaracmarka.SelectedValue.Toint58(), AltTipi = listaracmodel.Text, BoyaDegisenID = boya.BoyaRaporID, BoyaRaporPath = veriadresi, EgsızMuayeneTarihi = txtegsozmuayenetarihi.Text, KaskoVarmi = kaskodurumu, SigortaTeklfi = sigortateklifi, Km = txtarackilometre.Text, KullanimTuru = kullanimturu, KullanimKasaTipi = kasatipi, KullanimAltTipi = aracalttipi, MarkaveTip = listaracmarka.Text + " " + listaracmodel.Text, ModelYili = cbaracmodeli.Text, MotorNo = txtmotorno.Text, MuayeneTarihi = txtmuayenetarihi.Text, Plaka = txtplaka.Text, Renk = cbaracrenk.Text, SasiNo = txtsasino.Text, VitesTipi = cbvitestipi.Text, YakitTipi = cbyakittipi.Text };
                    db.TBL_MUSTERIARACLARI.Add(musteriaraci);
                    db.SaveChanges();

                    TBL_ODEMELER odeme = new TBL_ODEMELER { AracID = musteriaraci.AracID, MusteriID = musteri.MusteriID, OdemeSekli = "Nakit", OdemeDurumu = true, OdemeTutari = txtodemetutari.Text.ToDecimal(), OdemeTarihi = DateTime.Now };
                    db.TBL_ODEMELER.Add(odeme);
                    db.SaveChanges();

                    TBL_FK fk = new TBL_FK { AracID = musteriaraci.AracID, MusteriID = musteri.MusteriID };
                    db.TBL_FK.Add(fk);
                    db.SaveChanges();


                    btnonduzendevamet.Enabled = false;


                    pbkamera.Image.Dispose();


                    foreach (string imageFileName in Directory.GetFiles(@"//10.0.0.141/SalautoRaporlar/" + barkodkodu))
                    {
                        using (Bitmap bmp = new Bitmap(imageFileName))
                        {
                            PrintDocument printDoc = new PrintDocument();
                            printDoc.DefaultPageSettings.Margins = new Margins(0, 45, 0, 45);
                            printDoc.PrinterSettings.PrinterName = @default.Default.VarsayilanYazici;
                            printDoc.PrintPage += (sender, args) =>
                            {

                                Rectangle m = args.MarginBounds;

                                if ((double)bmp.Width / (double)bmp.Height > (double)m.Width / (double)m.Height)
                                {
                                    m.Height = (int)((double)bmp.Height / (double)bmp.Width * (double)m.Width);
                                }
                                else
                                {
                                    m.Width = (int)((double)bmp.Width / (double)bmp.Height * (double)m.Height);
                                }
                                args.Graphics.DrawImage(bmp, m);
                            };
                            printDoc.Print();
                            bmp.Dispose();
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            GC.Collect();
                            GC.WaitForFullGCComplete();
                            GC.Collect();
                        }

                    }
                    if (cam != null)
                    {
                        cam.SignalToStop();
                        cam.WaitForStop();
                        cam = null;
                        pbDisGorselKamera.Image.Dispose();
                        pbDisGorselKamera.Image = Properties.Resources.nocamera2;
                    }


                    var klasorsil = "C://SAutoTemp/" + barkodkodu;

                    Array.ForEach(Directory.GetFiles(klasorsil), File.Delete);
                    Directory.Delete(klasorsil);

                    MessageBox.Show("Yazdırma tamamlandı!", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabmain.Enabled = false;

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForFullGCComplete();
                    GC.Collect();

                }

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString(), "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class paketsecimi
        {

            public string paketadi { get; set; }
            public TabControl TabControlAdi { get; set; }
            public TabPage TabPageAdi { get; set; }
        }


        private void droppaketler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PaketSecimi();
            }
            catch (Exception)
            {

            }

        }

        private void PaketSecimi()
        {
            setTabPageVisibility(tabmain, TabBoyaDegisen, false);
            setTabPageVisibility(tabmain, tabOnDuzen, false);
            setTabPageVisibility(tabmain, tabSuspansiyon, false);
            setTabPageVisibility(tabmain, tabFren, false);
            setTabPageVisibility(tabmain, tabpagechassis, false);
            setTabPageVisibility(tabmain, tabMotor, false);
            setTabPageVisibility(tabmain, tabsanziman, false);
            setTabPageVisibility(tabmain, tabDisAydinlatma, false);
            setTabPageVisibility(tabmain, tabDonanim, false);
            setTabPageVisibility(tabmain, tabElektrik, false);
            setTabPageVisibility(tabmain, tabResimler, false);

            List<paketsecimi> plist = new List<paketsecimi>();

            string paketicerik = db.Paketler.FirstOrDefault(x => x.PaketAdi == droppaketler.Text).PaketIcerik;
            toolTip1.SetToolTip(droppaketler, paketicerik);

            string[] degerler = paketicerik.Split(',');

            List<string> aktifler = new List<string>();
            foreach (var item in degerler)
            {
                paketsecimi p = new paketsecimi();
                if (item.ToString() == "Boya/Değişen")
                {
                    p.paketadi = "Boya/Değişen";
                    p.TabControlAdi = tabmain;
                    p.TabPageAdi = TabBoyaDegisen;
                }

                if (item.ToString() == "Şasi Kontrol")
                {
                    p.paketadi = "Şasi Kontrol";
                    p.TabControlAdi = tabmain;
                    p.TabPageAdi = tabpagechassis;
                }

                if (item.ToString() == "Ön Düzen")
                {
                    p.paketadi = "Ön Düzen";
                    p.TabControlAdi = tabmain;
                    p.TabPageAdi = tabOnDuzen;
                }

                if (item.ToString() == "Fren")
                {
                    p.paketadi = "Fren";
                    p.TabControlAdi = tabmain;
                    p.TabPageAdi = tabFren;
                }

                if (item.ToString() == "Süspansiyon")
                {
                    p.paketadi = "Süspansiyon";
                    p.TabControlAdi = tabmain;
                    p.TabPageAdi = tabSuspansiyon;
                }
                if (item.ToString() == "Motor")
                {
                    p.paketadi = "Motor";
                    p.TabControlAdi = tabmain;
                    p.TabPageAdi = tabMotor;
                }
                if (item.ToString() == "Şanzıman")
                {
                    p.paketadi = "Şanzıman";
                    p.TabControlAdi = tabmain;
                    p.TabPageAdi = tabsanziman;
                }
                if (item.ToString() == "Dış Aydınlatma")
                {
                    p.paketadi = "Dış Aydınlatma";
                    p.TabControlAdi = tabmain;
                    p.TabPageAdi = tabDisAydinlatma;
                }
                if (item.ToString() == "Donanım")
                {
                    p.paketadi = "Donanım";
                    p.TabControlAdi = tabmain;
                    p.TabPageAdi = tabDonanim;
                }
                if (item.ToString() == "Elektrik")
                {
                    p.paketadi = "Elektrik";
                    p.TabControlAdi = tabmain;
                    p.TabPageAdi = tabElektrik;
                }
                if (item.ToString() == "Resimler")
                {
                    p.paketadi = "Resimler";
                    p.TabControlAdi = tabmain;
                    p.TabPageAdi = tabResimler;
                }

                plist.Add(p);

                foreach (var deger in plist)
                {
                    setTabPageVisibility(deger.TabControlAdi, deger.TabPageAdi, true);
                }

            }

            if (plist.Count == 1)
            {
                for (int i = 0; i < plist.Count; i++)
                {
                    if (plist[0].paketadi == "Boya/Değişen")
                    {
                        txtuyariyazisi.Text = "Aracın sadece Boya ve Değişenine bakılmıştır.Müşteri isteği üzerine Motor,Mekaniğe,Şaselere,Yürüyene ve Elektroniğe bakılmamıştır.";
                    }
                    else if (plist[0].paketadi == "Motor")
                    {
                        txtuyariyazisi.Text = "Aracın sadece motoruna bakılmıştır.Müşteri isteği üzerine Boya,Değişen,Mekaniğe,Şaselere,Yürüyene ve Elektroniğe bakılmamıştır.";
                    }
                    else
                    {
                        txtuyariyazisi.Text = "Aracın sadece şaselerine bakılmıştır.Müşteri isteği üzerine Motor,Boya,Değişen,Mekaniğe,Yürüyene ve Elektroniğe bakılmamıştır.";
                    }
                }
            }
            else if (plist.Count == 2)
            {
                for (int i = 0; i < plist.Count;)
                {
                    if (plist[0].paketadi == "Boya/Değişen" && plist[1].paketadi == "Motor")
                    {
                        txtuyariyazisi.Text = "Aracın sadece Motor,Boya ve Değişenine bakılmıştır.Müşteri isteği üzerine Mekaniğe,Şaselere,Yürüyene ve Elektroniğe bakılmamıştır.";
                    }
                    else if (plist[0].paketadi == "Boya/Değişen" && plist[1].paketadi == "Şasi Kontrol")
                    {
                        txtuyariyazisi.Text = "Aracın sadece Boya,Değişenine ve Şaselerine bakılmıştır.Müşteri isteği üzerine Mekaniğe,Şaselere,Yürüyene ve Elektroniğe bakılmamıştır.";
                    }
                    break;
                }
            }
            else if (plist.Count == 3)
            {
                for (int i = 0; i < plist.Count;)
                {
                    if (plist[0].paketadi == "Boya/Değişen" && plist[1].paketadi == "Şasi Kontrol" && plist[2].paketadi == "Motor")
                    {
                        txtuyariyazisi.Text = "Aracın sadece Motor,Boya,Değişenine ve Şaselerine bakılmıştır.Müşteri isteği üzerine Mekaniğe,Yürüyene ve Elektroniğe bakılmamıştır.";
                    }
                    break;
                }
            }
            else if (plist.Count == 6)
            {
                for (int i = 0; i < plist.Count;)
                {
                    if (plist[0].paketadi == "Boya/Değişen" && plist[1].paketadi == "Şasi Kontrol" && plist[2].paketadi == "Ön Düzen" && plist[3].paketadi == "Fren" && plist[4].paketadi == "Süspansiyon" && plist[5].paketadi == "Motor")
                    {
                        txtuyariyazisi.Text = "Aracın sadece Motor,Boya,Değişenine,Yürüyen ve Şaselerine bakılmıştır.Müşteri isteği üzerine Elektroniğe bakılmamıştır.";
                    }
                    break;
                }
            }
        }

        void setTabPageVisibility(TabControl tc, TabPage tp, bool visibility)
        {
            if ((visibility == true) && (tc.TabPages.IndexOf(tp) <= -1))
            {
                tc.TabPages.Insert(tc.TabCount, tp);
                tc.Visible = true;
            }
            else if ((visibility == false) && (tc.TabPages.IndexOf(tp) > -1))
            {
                tc.TabPages.Remove(tp);
                if (tc.TabCount == 0)
                {
                    tc.Visible = false;
                }
            }
        }

        private void cbmotorkasnaklari_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnmotordevamet_Click(object sender, EventArgs e)
        {
            if ((tabmain.TabPages.IndexOf(tabMotor) + 1).ToString() == (tabmain.TabPages.Count).ToString())
            {
                RaporlariYazdir();
            }
            else
            {
                tabmain.SelectedIndex = (tabmain.SelectedIndex + 1 < tabmain.TabCount) ?
                  tabmain.SelectedIndex + 1 : tabmain.SelectedIndex;
            }
        }

        private void cbyakittipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbyakittipi.Text == "Dizel")
            {
                lblateslemeveenjektor.Text = "Yakıt Enjektörleri";
                lblLpgveKizdirmaBuji.Text = "Kızdırma Bujileri";
                cbmotorlpgveKizdirmaBuji.SelectedIndex = 0;
                motordegerleri.YakitTipi = "Dizel";

            }
            else if (cbyakittipi.Text == "Benzin/LPG")
            {
                lblateslemeveenjektor.Text = "Ateşleme Sistemi";
                lblLpgveKizdirmaBuji.Text = "LPG Sistemi";
                cbmotorlpgveKizdirmaBuji.SelectedIndex = 0;
                motordegerleri.YakitTipi = "Benzin/Lpg";

            }
            else
            {
                lblateslemeveenjektor.Text = "Ateşleme Sistemi";
                lblLpgveKizdirmaBuji.Text = "LPG Sistemi";
                cbmotorlpgveKizdirmaBuji.SelectedIndex = 1;
                motordegerleri.YakitTipi = "Benzin/Lpg/Hybird";


            }
        }

        private void btnsanzimandevamet_Click(object sender, EventArgs e)
        {
            if ((tabmain.TabPages.IndexOf(tabsanziman) + 1).ToString() == (tabmain.TabPages.Count).ToString())
            {
                RaporlariYazdir();
            }
            else
            {
                tabmain.SelectedIndex = (tabmain.SelectedIndex + 1 < tabmain.TabCount) ?
                  tabmain.SelectedIndex + 1 : tabmain.SelectedIndex;
            }
        }
        private void btndisaylatmadevam_Click(object sender, EventArgs e)
        {
            if ((tabmain.TabPages.IndexOf(tabDisAydinlatma) + 1).ToString() == (tabmain.TabPages.Count).ToString())
            {
                RaporlariYazdir();
            }
            else
            {
                tabmain.SelectedIndex = (tabmain.SelectedIndex + 1 < tabmain.TabCount) ?
                  tabmain.SelectedIndex + 1 : tabmain.SelectedIndex;
            }
        }

        private void btndonanimdvmet_Click(object sender, EventArgs e)
        {
            if ((tabmain.TabPages.IndexOf(tabDonanim) + 1).ToString() == (tabmain.TabPages.Count).ToString())
            {
                RaporlariYazdir();
            }
            else
            {
                tabmain.SelectedIndex = (tabmain.SelectedIndex + 1 < tabmain.TabCount) ?
                  tabmain.SelectedIndex + 1 : tabmain.SelectedIndex;
            }
        }
        private void btnelektrikrapordevamet_Click(object sender, EventArgs e)
        {
            if ((tabmain.TabPages.IndexOf(tabElektrik) + 1).ToString() == (tabmain.TabPages.Count).ToString())
            {
                RaporlariYazdir();
            }
            else
            {
                tabmain.SelectedIndex = (tabmain.SelectedIndex + 1 < tabmain.TabCount) ?
                 tabmain.SelectedIndex + 1 : tabmain.SelectedIndex;
            }
        }
        private void btntestibitir_Click(object sender, EventArgs e)
        {
            if ((tabmain.TabPages.IndexOf(tabResimler) + 1).ToString() == (tabmain.TabPages.Count).ToString())
            {
                RaporlariYazdir();
            }
            else
            {
                MessageBox.Show("HATA");
            }
        }
        private void cbvitestipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbvitestipi.Text == "Manuel")
            {
                pbsanziman.Image = Properties.Resources.duzvitestext;
                lblbaskibalata.Visible = true;
                cbsanzimanbaskibalata.Visible = true;
            }
            else if (cbvitestipi.Text == "Otomatik")
            {
                pbsanziman.Image = Properties.Resources.tamototext;
                lblbaskibalata.Visible = false;
                cbsanzimanbaskibalata.Visible = false;

            }
            else
            {
                pbsanziman.Image = Properties.Resources.triptoniktext;
                lblbaskibalata.Visible = true;
                cbsanzimanbaskibalata.Visible = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label160_Click(object sender, EventArgs e)
        {

        }

        private void label159_Click(object sender, EventArgs e)
        {

        }

        private void label157_Click(object sender, EventArgs e)
        {

        }

        private void label161_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndisgorselkamerabaslat_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbkameralist.SelectedIndex >= 0)
                {
                    string[] devices = @default.Default.KameraAygiti.Split(',');
                    int deviceID = devices[1].Toint58();
                    cam = new VideoCaptureDevice(webcam[deviceID].MonikerString);
                    cam.VideoResolution = cam.VideoCapabilities[@default.Default.KameraCozunurluk];
                    cam.NewFrame += new NewFrameEventHandler(cam_NewFrameDisGorsel);
                    cam.Start();

                }
                else if (cbkameralist.Items.Count > 0)
                {
                    MessageBox.Show("Kamera Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }



            }
            catch (Exception)
            {

                MessageBox.Show("Kamera Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        void cam_NewFrameDisGorsel(object sender, NewFrameEventArgs eventArgs)
        {
            pbDisGorselKamera.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        DirectoryInfo Folder;
        int locX = 20;
        int locY = 10;
        int sizeWidth = 30;
        int sizeHeight = 30;
        FileInfo[] Images;
        private void btndisgorselkaydet_Click(object sender, EventArgs e)
        {

            try
            {
                string klasoryolu = @"//10.0.0.141/SalautoRaporlar/" + barkodkodu + "/Resimler";
                if (cam != null)
                {
                    if (Directory.Exists(klasoryolu))
                    {
                        pbDisGorselKamera.Image.Save(klasoryolu + "\\" + string.Format(@"{0}.jpg", Guid.NewGuid()));
                    }
                    else
                    {
                        Directory.CreateDirectory(klasoryolu);
                        pbDisGorselKamera.Image.Save(klasoryolu + "\\" + string.Format(@"{0}.jpg", Guid.NewGuid()));
                    }
                }
                Folder = new DirectoryInfo(klasoryolu);
                Images = Folder.GetFiles();
                pnControls.Controls.Clear();
                int locnewX = locX;
                int locnewY = locY;
                foreach (FileInfo img in Images)
                {
                    if (img.Extension.ToLower() == ".png" || img.Extension.ToLower() == ".jpg" || img.Extension.ToLower() == ".gif" || img.Extension.ToLower() == ".jpeg" || img.Extension.ToLower() == ".bmp" || img.Extension.ToLower() == ".tif")
                    {

                        if (locnewX >= pnControls.Width - sizeWidth - 10)
                        {
                            locnewX = locX;
                            locY = locY + sizeHeight + 30;
                            locnewY = locY;
                        }
                        else
                        {

                            locnewY = locY;
                        }

                        loadImagestoPanel(img.Name, img.FullName, locnewX, locnewY);
                        locnewY = locY + sizeHeight + 10;
                        locnewX = locnewX + sizeWidth + 10;


                    }
                    int SaveVal = 0;
                    locX = 20;
                    locY = 10;
                    sizeWidth = 220;
                    sizeHeight = 160;
                    foreach (Control p in pnControls.Controls)
                    {
                        SaveVal = SaveVal + 1;
                    }
                    if (SaveVal > 0)
                    {
                        loadControls();
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kamaranız aktif değil !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void loadImagestoPanel(String imageName, String ImageFullName, int newLocX, int newLocY)
        {
            PictureBox ctrl = new PictureBox();
            ctrl.Image = Image.FromFile(ImageFullName);
            ctrl.BackColor = Color.Black;
            ctrl.Location = new Point(newLocX, newLocY);
            ctrl.Size = new System.Drawing.Size(sizeWidth, sizeHeight);
            ctrl.SizeMode = PictureBoxSizeMode.StretchImage;
            ctrl.MouseClick += new MouseEventHandler(control_MouseClick);
            ctrl.Tag = ImageFullName;
            pnControls.Controls.Add(ctrl);


        }
        private void loadControls()
        {
            int locnewX = locX;
            int locnewY = locY;

            foreach (Control p in pnControls.Controls)
            {
                if (locnewX >= pnControls.Width - sizeWidth - 10)
                {
                    locnewX = locX;
                    locY = locY + sizeHeight + 30;
                    locnewY = locY;
                }
                else
                {

                    locnewY = locY;
                }
                p.Location = new Point(locnewX, locnewY);
                p.Size = new System.Drawing.Size(sizeWidth, sizeHeight);

                locnewY = locY + sizeHeight + 10;
                locnewX = locnewX + sizeWidth + 10;
            }
        }
        private void control_MouseClick(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;

            PictureBox pic = (PictureBox)control;
            string yol = pic.Tag.ToString();


            var result = MessageBox.Show("Görseli silmek istediğinize emin misiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                pnControls.Controls.Remove(pic);

                pic.Image.Dispose();
                File.Delete(yol);


            }


        }

        private void FullProje_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void cbkameralist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pbcamstop_Click(object sender, EventArgs e)
        {
            exitcamera();
        }

        private void pbcamstart_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbkameralist.Text != "Aygıt Bulunamadı")
                {
                    try { exitcamera(); } catch (Exception) { }

                    string[] webcamdevice = @default.Default.KameraAygiti.Split(',');
                    int deviceID = webcamdevice[1].Toint58();
                    cam = new VideoCaptureDevice(webcam[deviceID].MonikerString);
                    cam.VideoResolution = cam.VideoCapabilities[@default.Default.KameraCozunurluk];
                    cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);

                    cam.Start();
                }
                else
                {
                    MessageBox.Show("Kamera Aygıtı Bulunamadı.Ayarlar->Aygıt Ayarları kısmından cihaz tanıtınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            catch (Exception)
            {

                MessageBox.Show("Kamera Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pbdisgorseldurdur_Click(object sender, EventArgs e)
        {
            try
            {
                if (cam != null)
                {
                    cam.SignalToStop();
                    cam.WaitForStop();
                    cam = null;
                    pbDisGorselKamera.Image = Properties.Resources.nocamera2;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tabalicibilgileri_Click(object sender, EventArgs e)
        {

        }

        private void tabaracsecimi_Click(object sender, EventArgs e)
        {

        }

        private void btnyeniaracekle_Click(object sender, EventArgs e)
        {
            if (pnleklemealani1.Visible == false)
            {
                pnleklemealani1.Visible = true;

            }
            else
            {
                //Ekleme işlemine devam et
            }
        }

        private void listaracversiyon_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtYeniAracVersiyonAdi.Text = listaracversiyon.Text;
        }

        private void pbAracKasaEkle_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show((listaracmarka.Text + "-" + listaracmodel.Text + " aracına " + txtYeniAracKasaAdi.Text + " Motor Tipi eklensin mi ?"), "Yeni Değer Ekle ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int MarkaID = listaracmarka.SelectedValue.Toint58();
                int ModelID = listaracmodel.SelectedValue.Toint58();
                string SeriAdi = txtYeniAracKasaAdi.Text;

                bool serikontrol = db.TBLARACSERISI.Any(x => x.MarkaID == MarkaID && x.ModelID == ModelID && x.SeriAdi == SeriAdi);
                if (!serikontrol && SeriAdi.Trim() != "")
                {
                    TBLARACSERISI tBLARACSERISI = new TBLARACSERISI();
                    tBLARACSERISI.MarkaID = MarkaID;
                    tBLARACSERISI.ModelID = ModelID;
                    tBLARACSERISI.SeriAdi = SeriAdi;
                    db.TBLARACSERISI.Add(tBLARACSERISI);
                    db.SaveChanges();

                    IList<TBLARACSERISI> seriList = db.TBLARACSERISI.Where(x => x.ModelID == ModelID).OrderBy(x => x.SeriAdi).ToList();
                    listarackasa.DataSource = seriList;
                    listarackasa.DisplayMember = "SeriAdi";
                    listarackasa.ValueMember = "id";
                    listarackasa.SelectedIndex = 0;

                    MessageBox.Show("Ekleme işlemi başarı ile tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Eklemek istediğiniz değer mevcut", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void pbAracVersiyonEkle_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show((listaracmarka.Text + "-" + listaracmodel.Text + "-" + listarackasa.Text + " aracına " + txtYeniAracVersiyonAdi.Text + " değeri eklensin mi ?"), "Yeni Değer Ekle ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                int SeriID = listarackasa.SelectedValue.Toint58();

                string VersiyonAdi = txtYeniAracVersiyonAdi.Text;

                bool versionkontrol = db.TBLARACVERSIYON.Any(x => x.SeriID == SeriID && x.VersiyonAdi == VersiyonAdi);
                if (!versionkontrol && VersiyonAdi.Trim() != "")
                {
                    TBLARACVERSIYON tBLARACVERSIYON = new TBLARACVERSIYON();
                    tBLARACVERSIYON.SeriID = SeriID;
                    tBLARACVERSIYON.VersiyonAdi = VersiyonAdi;
                    db.TBLARACVERSIYON.Add(tBLARACVERSIYON);
                    db.SaveChanges();

                    IList<TBLARACVERSIYON> seriversList = db.TBLARACVERSIYON.Where(x => x.SeriID == SeriID).OrderBy(x => x.VersiyonAdi).ToList();
                    listaracversiyon.DataSource = seriversList;
                    listaracversiyon.DisplayMember = "VersiyonAdi";
                    listaracversiyon.ValueMember = "id";


                    txtYeniAracVersiyonAdi.Text = listarackasa.Text;

                    MessageBox.Show("Ekleme işlemi başarı ile tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Eklemek istediğiniz değer mevcut", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void txtYeniAracVersiyonAdi_Click(object sender, EventArgs e)
        {
            if (txtYeniAracVersiyonAdi.Text == "Araç serisi seçin veya yazın..")
            {
                txtYeniAracVersiyonAdi.Text = "";
            }
        }

        private void txtYeniAracKasaAdi_Click(object sender, EventArgs e)
        {
            if (txtYeniAracKasaAdi.Text == "Araç tipi seçin veya yazın..")
            {
                txtYeniAracKasaAdi.Text = "";
            }
        }
    }
}
