using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalajansBoyaMusteri
{
    public static class SasiRapor
    {
        public static void RaporYaz()
        {
            Bitmap SasiGorsel = new Bitmap(Properties.Resources.csasi, 2408, 3508);

            Graphics g2 = Graphics.FromImage(SasiGorsel);

            //Üst Kısım
            #region Araç Km
            g2.DrawString(musteridegerleri.kmsi, new Font("Calibri", 39), Brushes.Black, new PointF(1308, 695));
            #endregion
            #region Araç Plaka
            g2.DrawString(musteridegerleri.plaka, new Font("Calibri", 45), Brushes.Black, new PointF(537, 690));
            #endregion
            #region MarkaModel
            g2.DrawString(musteridegerleri.aracmodeli + " Model:" + musteridegerleri.aracyili, new Font("Calibri", 37), Brushes.Black, new PointF(140, 910));
            #endregion
            #region rENK
            g2.DrawString(musteridegerleri.renk, new Font("Calibri", 39), Brushes.Black, new PointF(1215, 825));
            #endregion
            #region Barkod
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            b.Alignment = BarcodeLib.AlignmentPositions.LEFT;
            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            type = BarcodeLib.TYPE.Codabar;
            g2.DrawImage(b.Encode(type, musteridegerleri.barkodno, 750, 170), new PointF(1625, 810));


            g2.DrawString(musteridegerleri.barkodno, new Font("Calibri", 30), Brushes.Black, new PointF(1860, 975));
            #endregion

            #region Tarih Saat
            g2.DrawString(DateTime.Now.ToShortDateString() + " / " + DateTime.Now.ToShortTimeString(), new Font("Calibri", 33), Brushes.Black, new PointF(1950, 700));
            #endregion

            #region AlıcıTelefon
            g2.DrawString(musteridegerleri.alicitelefon, new Font("Calibri", 33), Brushes.Black, new PointF(440, 2885));
            #endregion

            Bitmap sasisolo = new Bitmap(Properties.Resources.chassis, 1203, 436);

            Graphics g = Graphics.FromImage(sasisolo);
            foreach (var item in sasilist.sliste)
            {
                Bitmap bmpdeger = new Bitmap(item.sasideger, 50, 50);
                g.DrawImage(bmpdeger, new PointF(item.X, item.Y));
                bmpdeger.Dispose();
            }

            Bitmap sasisolo2 = new Bitmap(sasisolo, 2100, 703);
            g2.DrawImage(sasisolo2, new PointF(170, 1450));
            g2.DrawString(musteridegerleri.aliciadsoyad, new Font("Calibri", 39), Brushes.Black, new PointF(300, 3100));


            SasiGorsel.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "sasi.jpg");

          
            g.Dispose();
            g2.Dispose();
            sasisolo.Dispose();
            SasiGorsel.Dispose();
            b.Dispose();
          
        }
    }
}
