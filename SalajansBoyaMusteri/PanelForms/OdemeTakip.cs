using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SalajansBoyaMusteri.PanelForms
{
    public partial class OdemeTakip : Form
    {
        public OdemeTakip()
        {
            InitializeComponent();
        }

        private void OdemeTakip_Load(object sender, EventArgs e)
        {

            try
            {
                DateTime now = DateTime.Now;
                DateTime baslangic = DateTime.Today;
                DateTime bitis = baslangic.AddDays(1);
                DBEntities db = new DBEntities();
                double toplam = db.TBL_ODEMELER.Where(x => x.OdemeTarihi >= baslangic && x.OdemeTarihi <= bitis).Sum(x => x.OdemeTutari).ToDouble();
                double bugunarac=  AracSay(baslangic, bitis, db);

                bitis = GunCikar(ref baslangic);
                lblbuguntutar.Text = toplam.ToDecimal().ToString("N").Replace(",00", " ₺");

                double toplam1 = db.TBL_ODEMELER.Where(x => x.OdemeTarihi >= baslangic && x.OdemeTarihi <= bitis).Sum(x => x.OdemeTutari).ToDouble();
                double dunarac = AracSay(baslangic, bitis, db); 
                bitis = GunCikar(ref baslangic);
                lbldun.Text = toplam1.ToDecimal().ToString("N").Replace(",00", " ₺");
                double toplam2 = db.TBL_ODEMELER.Where(x => x.OdemeTarihi >= baslangic && x.OdemeTarihi <= bitis).Sum(x => x.OdemeTutari).ToDouble();
                double arac5 = AracSay(baslangic, bitis, db);

                bitis = GunCikar(ref baslangic);
                lbl5.Text = toplam2.ToDecimal().ToString("N").Replace(",00", " ₺");

                double toplam3 = db.TBL_ODEMELER.Where(x => x.OdemeTarihi >= baslangic && x.OdemeTarihi <= bitis).Sum(x => x.OdemeTutari).ToDouble();
                double arac4 = AracSay(baslangic, bitis, db);

                bitis = GunCikar(ref baslangic);
                lbl4.Text = toplam3.ToDecimal().ToString("N").Replace(",00", " ₺");

                double toplam4 = db.TBL_ODEMELER.Where(x => x.OdemeTarihi >= baslangic && x.OdemeTarihi <= bitis).Sum(x => x.OdemeTutari).ToDouble();
                double arac3 = AracSay(baslangic, bitis, db);

                bitis = GunCikar(ref baslangic);
                lbl3.Text = toplam4.ToDecimal().ToString("N").Replace(",00", " ₺");

                double toplam5 = db.TBL_ODEMELER.Where(x => x.OdemeTarihi >= baslangic && x.OdemeTarihi <= bitis).Sum(x => x.OdemeTutari).ToDouble();
                double arac2 = AracSay(baslangic, bitis, db);

                bitis = GunCikar(ref baslangic);
                lbl2.Text = toplam5.ToDecimal().ToString("N").Replace(",00", " ₺");

                double toplam6 = db.TBL_ODEMELER.Where(x => x.OdemeTarihi >= baslangic && x.OdemeTarihi <= bitis).Sum(x => x.OdemeTutari).ToDouble();
                lbl1.Text = toplam6.ToDecimal().ToString("N").Replace(",00", " ₺");
                double arac1 = AracSay(baslangic, bitis, db);


                TutarChart.Series["Tutar"].Points.Add(toplam6);
                TutarChart.Series["Tutar"].Points.Add(toplam5);
                TutarChart.Series["Tutar"].Points.Add(toplam4);
                TutarChart.Series["Tutar"].Points.Add(toplam3);
                TutarChart.Series["Tutar"].Points.Add(toplam2);
                TutarChart.Series["Tutar"].Points.Add(toplam1);
                TutarChart.Series["Tutar"].Points.Add(toplam);

                AracChart.Series["Arac"].Points.Add(arac1+5);
                AracChart.Series["Arac"].Points.Add(arac2 + 5);
                AracChart.Series["Arac"].Points.Add(arac3 + 5);
                AracChart.Series["Arac"].Points.Add(arac4 + 5);
                AracChart.Series["Arac"].Points.Add(arac5 + 5);
                AracChart.Series["Arac"].Points.Add(dunarac + 5);
                AracChart.Series["Arac"].Points.Add(bugunarac + 5);

                TutarChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                TutarChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                 
                GunleriBul(bugunarac,dunarac,arac5,arac4,arac3,arac2,arac1);
            }
            catch (Exception )
            {
                
            }
        }

        private  double AracSay(DateTime baslangic, DateTime bitis, DBEntities db)
        {
            var toplamarac = (from arac in db.TBL_MUSTERIARACLARI
                              join odeme in db.TBL_ODEMELER
                              on arac.AracID equals odeme.AracID
                              where odeme.OdemeTarihi >= baslangic && odeme.OdemeTarihi <= bitis
                              select new
                              {
                                  arac.AracID
                              }).ToList().Count();
            return toplamarac;
        }

        private static DateTime GunCikar(ref DateTime baslangic)
        {
            DateTime bitis;
            baslangic = baslangic.AddDays(-1);
            bitis = baslangic.AddDays(1).AddTicks(-1);
            return bitis;
        }

        private void GunleriBul(double arac7,double arac6, double arac5, double arac4, double arac3, double arac2, double arac1)
        {
            TutarChart.Series["Tutar"].Points[6].AxisLabel = "Bugün";
            TutarChart.Series["Tutar"].Points[5].AxisLabel = "Dün";
            TutarChart.Series["Tutar"].Points[4].AxisLabel = DateTime.Now.AddDays(-2).ToString("ddd");
            TutarChart.Series["Tutar"].Points[3].AxisLabel = DateTime.Now.AddDays(-3).ToString("ddd");
            TutarChart.Series["Tutar"].Points[2].AxisLabel = DateTime.Now.AddDays(-4).ToString("ddd");
            TutarChart.Series["Tutar"].Points[1].AxisLabel = DateTime.Now.AddDays(-5).ToString("ddd");
            TutarChart.Series["Tutar"].Points[0].AxisLabel = DateTime.Now.AddDays(-6).ToString("ddd");

            AracChart.Series["Arac"].Points[6].AxisLabel = "Bugün ("+arac7.ToString()+")";
            AracChart.Series["Arac"].Points[5].AxisLabel = "Dün (" + arac6.ToString() + ")";
            AracChart.Series["Arac"].Points[4].AxisLabel = DateTime.Now.AddDays(-2).ToString("ddd")+" ("+arac5.ToString() + ")";
            AracChart.Series["Arac"].Points[3].AxisLabel = DateTime.Now.AddDays(-3).ToString("ddd") + " (" + arac4.ToString() + ")";
            AracChart.Series["Arac"].Points[2].AxisLabel = DateTime.Now.AddDays(-4).ToString("ddd") + " (" + arac3.ToString() + ")";
            AracChart.Series["Arac"].Points[1].AxisLabel = DateTime.Now.AddDays(-5).ToString("ddd") + " (" + arac2.ToString() + ")";
            AracChart.Series["Arac"].Points[0].AxisLabel = DateTime.Now.AddDays(-6).ToString("ddd") + " (" + arac1.ToString() + ")";



        }
        //private void RenkAyarlari()
        //{
        //    chart1.Series["Ödeme"].Points[0].Color = Color.Red;
        //    chart1.Series["Ödeme"].Points[1].Color = ColorTranslator.FromHtml("#ba4202");
        //    chart1.Series["Ödeme"].Points[2].Color = ColorTranslator.FromHtml("#a05e03");

        //    chart1.Series["Ödeme"].Points[3].Color = ColorTranslator.FromHtml("#8f6e03");

        //    chart1.Series["Ödeme"].Points[4].Color = ColorTranslator.FromHtml("#7c83");

        //    chart1.Series["Ödeme"].Points[5].Color = ColorTranslator.FromHtml("#6f8c04");
        //    chart1.Series["Ödeme"].Points[6].Color = Color.Green;

        //}
    }
}
