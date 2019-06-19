using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Printing;
using SalajansBoyaMusteri.Properties;

namespace SalajansBoyaMusteri.PanelForms
{
    public partial class RaporDosyalariOnizle : Form
    {
        public RaporDosyalariOnizle()
        {
            InitializeComponent();
        }
        DBEntities db = new DBEntities();
        int locX = 20;
        int locY = 10;
        int sizeWidth = 30;
        int sizeHeight = 30;
        FileInfo[] Images;
        Bitmap bmpimage;
        private void RaporDosyalariOnizle_Load(object sender, EventArgs e)
        {
            try
            {
                DBEntities db = new DBEntities(); 
                DirectoryInfo Folder;
                string barkod = RaporBarkodNo.BarkodKodu;
                Bitmap pbimage;
                if (barkod.Length <= 5)
                {
                    Folder = new DirectoryInfo(@"//10.0.0.141/SalautoRaporlar//MusterilerEskiDB//" + barkod);
                     pbimage = new Bitmap(@"//10.0.0.141/SalautoRaporlar//MusterilerEskiDB//" + barkod + "//" + barkod + ".jpg");

                    int musterino = barkod.Toint58();
                    musteri tm = db.musteri.FirstOrDefault(x => x.MusteriID == musterino);
                    this.Text = tm.musteriadi+" "+tm.musterisoyadi;
                }
                else
                {
                    string dosyadi = string.Empty;
                    foreach (string f in Directory.GetFiles(@"//10.0.0.141/SalautoRaporlar//" + barkod))
                    {
                        dosyadi = Path.GetFileName(f);
                        break;
                    }

                    Folder = new DirectoryInfo(@"//10.0.0.141/SalautoRaporlar//" + barkod);
                    pbimage = new Bitmap(@"//10.0.0.141/SalautoRaporlar//" + barkod +"//"+ dosyadi);
                     TBL_MUSTERILER tm = db.TBL_MUSTERILER.FirstOrDefault(x => x.BarkodNo == barkod);
                    this.Text = tm.AliciAdsoyad;
                }

                pbonizleme.Image = pbimage;
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
                       
                        bmpimage = new Bitmap(img.FullName);
                        loadImagestoPanel(img.Name, locnewX, locnewY);
                        locnewY = locY + sizeHeight + 10;
                        locnewX = locnewX + sizeWidth + 10; 

                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        GC.Collect();
                        GC.WaitForFullGCComplete();
                        GC.Collect();
                     
                    }
                    int SaveVal = 0;
                    locX = 20;
                    locY = 10;
                    sizeWidth = 113;
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
             
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForFullGCComplete();
                GC.Collect();
            }
            catch (Exception )
            {
                MessageBox.Show("Rapor dosyası bulunamadı !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
        private void loadImagestoPanel(String imageName, int newLocX, int newLocY)
        {
            PictureBox ctrl = new PictureBox(); 
            ctrl.Image = bmpimage;
            ctrl.BackColor = Color.Black;
            ctrl.Location = new Point(newLocX, newLocY);
            ctrl.Size = new Size(sizeWidth, sizeHeight);
            ctrl.SizeMode = PictureBoxSizeMode.StretchImage;
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            pnControls.Controls.Add(ctrl);
             
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int SaveVal = 0;
            locX = 20;
            locY = 10;
            sizeWidth = 50;
            sizeHeight = 50;
            foreach (Control p in pnControls.Controls)
            {
                SaveVal = SaveVal + 1;
            }
            if (SaveVal > 0)
            {
                loadControls();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int SaveVal = 0;
            locX = 20;
            locY = 10;
            sizeWidth = 80;
            sizeHeight = 80;
            foreach (Control p in pnControls.Controls)
            {
                SaveVal = SaveVal + 1;
            }
            if (SaveVal > 0)
            {
                loadControls();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {

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
        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            PictureBox pic = (PictureBox)control;
            pbonizleme.Image = pic.Image;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pbonizleme.Image, e.MarginBounds);

        }

        private void btnraporyazdir_Click(object sender, EventArgs e)
        {
            pbonizleme.SizeMode = PictureBoxSizeMode.StretchImage;
            string Vyazici = @default.Default.VarsayilanYazici;
            printDocument1.PrinterSettings.PrinterName = Vyazici;
            printDocument1.DefaultPageSettings.Margins = new Margins(0, 45, 0, 45);
            printDocument1.Print();
        }

        private void btnTumRaporlar_Click(object sender, EventArgs e)
        {
            foreach (FileInfo f in Images)
            {
                if ((RaporBarkodNo.BarkodKodu + ".jpg") != f.Name)
                {
                    Bitmap bmp = new Bitmap(f.FullName);
                    pbonizleme.Image = bmp;
                    pbonizleme.SizeMode = PictureBoxSizeMode.StretchImage;
                    string Vyazici = @default.Default.VarsayilanYazici;
                    printDocument1.PrinterSettings.PrinterName = Vyazici;
                    printDocument1.DefaultPageSettings.Margins = new Margins(0, 45, 0, 45);
                    printDocument1.Print();
                }

            }
            // printDocument1.DefaultPageSettings.Margins = new Margins(0, 45, 0, 45);
            // printDocument1.Print();
        }

        private void btnetiketyazdir_Click(object sender, EventArgs e)
        {
            try
            {
                var label = DYMO.Label.Framework.Label.Open(Application.StartupPath + "\\etiket.label");
                label.SetObjectText("txtbarcode", RaporBarkodNo.BarkodKodu);
           
                string byazici = @default.Default.BarkodYazici;
                label.Print(byazici);
                MessageBox.Show("Etiket yazdırıldı", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {

                MessageBox.Show("Barkod etiket yazıcınızı kontrol edin","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void RaporDosyalariOnizle_Leave(object sender, EventArgs e)
        {
           
        }

        private void RaporDosyalariOnizle_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
