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
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
        }

        private void Rapor_Load(object sender, EventArgs e)
        {
            Bitmap BoyaGorsel = new Bitmap(Properties.Resources.caracgorselleri, 2480, 3508);
            Graphics g = Graphics.FromImage(BoyaGorsel);

            //g.DrawString("Aracın sadece Motor,Boya ve Değişenine bakılmıştır.Müşteri isteği üzerine Mekaniğe,Şaselere,Yürüyene ve Elektroniğe bakılmamıştır.", new Font("Calibri", 30), Brushes.Black, new PointF(110, 3400));

            //g.DrawString("Aracın sadece Motor,Boya,Değişenine ve şaselere bakılmıştır.Müşteri isteği üzerine Mekaniğe,Yürüyene ve Elektroniğe bakılmamıştır.", new Font("Calibri", 30), Brushes.Black, new PointF(110, 3400));

            g.DrawString(DateTime.Now.ToString(), new Font("Calibri", 58), Brushes.Black, new PointF(600, 730));

            pictureBox1.Image = BoyaGorsel;
        }
    }
}
