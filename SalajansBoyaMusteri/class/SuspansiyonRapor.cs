using System;
using System.Drawing;

namespace SalajansBoyaMusteri
{
    public static class SuspansiyonRapor
    {
        public static void RaporYaz()
        {
            Bitmap SuspansiyonGorsel = new Bitmap(Properties.Resources.csuspansiyon, 2408, 3508);
            Graphics g2 = Graphics.FromImage(SuspansiyonGorsel);
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
            g2.DrawString(suspansiyondegerleri.solonamortisor, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(475, 2530));
            g2.DrawString(suspansiyondegerleri.solonamortisortakozu, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(475, 2590));
            g2.DrawString(suspansiyondegerleri.solonsuspansiyonkollari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(475, 2660));
            g2.DrawString(suspansiyondegerleri.solonhelezonyayi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(475, 2730)); 
            g2.DrawString(suspansiyondegerleri.solarkaamortisor, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1000, 2530));
            g2.DrawString(suspansiyondegerleri.solarkaamortisortakozu, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1000, 2590));
            g2.DrawString(suspansiyondegerleri.solarkasuspansiyonkollari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1000, 2660));
            g2.DrawString(suspansiyondegerleri.solarkahelezonyayi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1000, 2730)); 
            g2.DrawString(suspansiyondegerleri.sagonamortisor, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2530));
            g2.DrawString(suspansiyondegerleri.sagonamortisortakozu, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2590));
            g2.DrawString(suspansiyondegerleri.sagonsuspansiyonkollari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2660));
            g2.DrawString(suspansiyondegerleri.sagonhelezonyayi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2730)); 
            g2.DrawString(suspansiyondegerleri.sagarkaamortisor, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2050, 2530));
            g2.DrawString(suspansiyondegerleri.sagarkaamortisortakozu, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2050, 2590));
            g2.DrawString(suspansiyondegerleri.sagarkasuspansiyonkollari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2050, 2660));
            g2.DrawString(suspansiyondegerleri.sagarkahelezonyayi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2050, 2730));
            g2.DrawString(musteridegerleri.aliciadsoyad, new Font("Calibri", 39), Brushes.Black, new PointF(300, 3100));

            SuspansiyonGorsel.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "suspansiyon.jpg"); 

        
            SuspansiyonGorsel.Dispose();
            g2.Dispose();
            b.Dispose();
        }
    }
}
