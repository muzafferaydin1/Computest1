using System;
using System.Drawing;
using System.IO;

namespace SalajansBoyaMusteri
{
    public static class RaporBaslik
    {
        public static void RaporYaz()
        {
            Bitmap RaporBaslik = new Bitmap(Properties.Resources.craporanaekran, 2480, 3508);
            Graphics g = Graphics.FromImage(RaporBaslik);

            #region Tarih Saat
            g.DrawString(DateTime.Now.ToShortDateString() + " / " + DateTime.Now.ToShortTimeString(), new Font("Calibri", 39), Brushes.Black, new PointF(530, 855));
            #endregion


            #region Alıcı Ad Soyad
            if (musteridegerleri.aliciadsoyad.Length > 25)
            {
                g.DrawString(musteridegerleri.aliciadsoyad, new Font("Calibri", 37), Brushes.Black, new PointF(530, 940));
            }
            else
            {
                g.DrawString(musteridegerleri.aliciadsoyad, new Font("Calibri", 40), Brushes.Black, new PointF(530, 940));
            }
            #endregion

            g.DrawString(musteridegerleri.alicitelefon, new Font("Calibri", 40), Brushes.Black, new PointF(530, 1020));

            g.DrawString(musteridegerleri.motorno, new Font("Calibri", 40), Brushes.Black, new PointF(530, 1100));
            g.DrawString(musteridegerleri.sasino, new Font("Calibri", 40), Brushes.Black, new PointF(530, 1180));


            g.DrawString(musteridegerleri.plaka, new Font("Calibri", 100), Brushes.Black, new PointF(920, 2900));


            if (musteridegerleri.aracmodeli.Length > 30)
            {
                g.DrawString(musteridegerleri.aracmodeli, new Font("Calibri", 37), Brushes.Black, new PointF(1575, 855));
            }
            else
            {
                g.DrawString(musteridegerleri.aracmodeli, new Font("Calibri", 40), Brushes.Black, new PointF(1575, 855));

            }
            g.DrawString(musteridegerleri.aracyili, new Font("Calibri", 40), Brushes.Black, new PointF(1575, 935));
            g.DrawString(musteridegerleri.yakitturu, new Font("Calibri", 40), Brushes.Black, new PointF(1575, 1015));

            if (musteridegerleri.vites.Length > 30)
            {
                g.DrawString(musteridegerleri.vites, new Font("Calibri", 37), Brushes.Black, new PointF(1575, 1095));
            }
            else
            {
                g.DrawString(musteridegerleri.vites, new Font("Calibri", 40), Brushes.Black, new PointF(1575, 1095));
            }


            g.DrawString(musteridegerleri.renk, new Font("Calibri", 40), Brushes.Black, new PointF(1575, 1175));




            if (musteridegerleri.AracResmi == true)
            {
                string barkodkodu = musteridegerleri.barkodno.ToString();
                string klasoryolu = "C://SAutoTemp/" + barkodkodu;

                 if (Directory.Exists(klasoryolu))
                {
                    string resimadi = barkodkodu + ".jpg";
                    #region Araç Resmi
                    Bitmap aracresim = new Bitmap(klasoryolu + "\\" + resimadi);
                    g.DrawImage(aracresim, 355, 1600, 1775, 1270);
                    #endregion
                }

            }
            #region Barkod
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            int genislik = Convert.ToInt32(770);
            int yukseklik = Convert.ToInt32(150);
            b.Alignment = BarcodeLib.AlignmentPositions.LEFT;
            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            type = BarcodeLib.TYPE.Codabar;
            g.DrawImage(b.Encode(type, musteridegerleri.barkodno, genislik, yukseklik), new PointF(1630, 600));
            g.DrawString(musteridegerleri.barkodno, new Font("Calibri", 25), Brushes.Black, new PointF(1900, 750));
            #endregion 
            g.DrawString(musteridegerleri.aliciadsoyad, new Font("Calibri", 40), Brushes.Black, new PointF(500, 3300));
            RaporBaslik.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "Anasayfa.jpg");


            RaporBaslik.Dispose();
            g.Dispose();
            b.Dispose();
        }
    }
}
