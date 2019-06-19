using System;
using System.Drawing;

namespace SalajansBoyaMusteri
{
    public static class TripDsgSanzimanRapor
    {
        public static void RaporYaz()
        {
            Bitmap TripDsgGorsel = new Bitmap(Properties.Resources.ctriptoniksanziman, 2408, 3508);
            Graphics  g = Graphics.FromImage(TripDsgGorsel);
            #region Araç Km
             g.DrawString(musteridegerleri.kmsi, new Font("Calibri", 39), Brushes.Black, new PointF(1308, 695));
            #endregion
            #region Araç Plaka
             g.DrawString(musteridegerleri.plaka, new Font("Calibri", 45), Brushes.Black, new PointF(537, 690));
            #endregion
            #region MarkaModel
             g.DrawString(musteridegerleri.aracmodeli + " Model:" + musteridegerleri.aracyili, new Font("Calibri", 37), Brushes.Black, new PointF(140, 910));
            #endregion
            #region rENK
             g.DrawString(musteridegerleri.renk, new Font("Calibri", 39), Brushes.Black, new PointF(1215, 825));
            #endregion
            #region Barkod
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            b.Alignment = BarcodeLib.AlignmentPositions.LEFT;
            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            type = BarcodeLib.TYPE.Codabar;
             g.DrawImage(b.Encode(type, musteridegerleri.barkodno, 750, 170), new PointF(1625, 810));


             g.DrawString(musteridegerleri.barkodno, new Font("Calibri", 30), Brushes.Black, new PointF(1860, 975));
            #endregion

            #region Tarih Saat
             g.DrawString(DateTime.Now.ToShortDateString() + " / " + DateTime.Now.ToShortTimeString(), new Font("Calibri", 33), Brushes.Black, new PointF(1950, 700));
            #endregion

            #region AlıcıTelefon
             g.DrawString(musteridegerleri.alicitelefon, new Font("Calibri", 33), Brushes.Black, new PointF(440, 2885));
            #endregion
             g.DrawString(sanzimandegerleri.baskibalata, new Font("Calibri", 27, FontStyle.Bold), Brushes.Black, new PointF(2040, 2525));
             g.DrawString(sanzimandegerleri.vitesgecisleri, new Font("Calibri", 27, FontStyle.Bold), Brushes.Black, new PointF(2040, 2582));
             g.DrawString(sanzimandegerleri.yagkacagi, new Font("Calibri", 27, FontStyle.Bold), Brushes.Black, new PointF(2040, 2642));
             g.DrawString(sanzimandegerleri.sanzimankulagi, new Font("Calibri", 27, FontStyle.Bold), Brushes.Black, new PointF(2040, 2702));
             g.DrawString(sanzimandegerleri.sanzimanbeyni, new Font("Calibri", 27, FontStyle.Bold), Brushes.Black, new PointF(2040, 2760));
            g.DrawString(musteridegerleri.aliciadsoyad, new Font("Calibri", 39), Brushes.Black, new PointF(300, 3100));

            TripDsgGorsel.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "sanziman.jpg");
            
            g.Dispose();
            TripDsgGorsel.Dispose();
            b.Dispose();
        }
    }
}
