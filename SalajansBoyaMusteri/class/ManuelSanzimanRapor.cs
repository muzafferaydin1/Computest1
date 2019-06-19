using System;
using System.Drawing;
 
namespace SalajansBoyaMusteri
{
    public static class ManuelSanzimanRapor
    {
        public static void RaporYaz()
        {
            Bitmap DuzVitesGorsel = new Bitmap(Properties.Resources.cduzvitessanziman, 2480, 3508);

            Graphics g2 = Graphics.FromImage(DuzVitesGorsel);

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

            g2.DrawString(sanzimandegerleri.baskibalata, new Font("Calibri", 27, FontStyle.Bold), Brushes.Black, new PointF(2040, 2525));
            g2.DrawString(sanzimandegerleri.vitesgecisleri, new Font("Calibri", 27, FontStyle.Bold), Brushes.Black, new PointF(2040, 2582));
            g2.DrawString(sanzimandegerleri.yagkacagi, new Font("Calibri", 27, FontStyle.Bold), Brushes.Black, new PointF(2040, 2642));
            g2.DrawString(sanzimandegerleri.sanzimankulagi, new Font("Calibri", 27, FontStyle.Bold), Brushes.Black, new PointF(2040, 2702));
            g2.DrawString(sanzimandegerleri.sanzimanbeyni, new Font("Calibri", 27, FontStyle.Bold), Brushes.Black, new PointF(2040, 2760));
            g2.DrawString(musteridegerleri.aliciadsoyad, new Font("Calibri", 39), Brushes.Black, new PointF(300, 3100));


            DuzVitesGorsel.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "sanziman.jpg");

        
            DuzVitesGorsel.Dispose();
            g2.Dispose();
            b.Dispose();
        }
    }
}
