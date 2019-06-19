using System;
using System.Drawing;


namespace SalajansBoyaMusteri
{
    public static class DisAydinlatmaRapor
    {
        public static void RaporYaz()
        {
            Bitmap DisAydinlatma = new Bitmap(Properties.Resources.cdisaydinlatma, 2480, 3508);
            Graphics g2 = Graphics.FromImage(DisAydinlatma);
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
            g2.DrawString(disaydinlatmadegerleri.solonsinyal, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(420, 2525));
            g2.DrawString(disaydinlatmadegerleri.solonfarlar, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(420, 2585));
            g2.DrawString(disaydinlatmadegerleri.solonparklambasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(420, 2645));
            g2.DrawString(disaydinlatmadegerleri.solonsislambasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(420, 2705));
            g2.DrawString(disaydinlatmadegerleri.solaynasinyallambasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(420, 2765));


            g2.DrawString(disaydinlatmadegerleri.sagonsinyal, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(975, 2525));
            g2.DrawString(disaydinlatmadegerleri.sagonfarlar, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(975, 2585));
            g2.DrawString(disaydinlatmadegerleri.sagonparklambasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(975, 2645));
            g2.DrawString(disaydinlatmadegerleri.sagonsislambasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(975, 2705));
            g2.DrawString(disaydinlatmadegerleri.sagaynasinyal, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(975, 2765));



            g2.DrawString(disaydinlatmadegerleri.solarkasinyal, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1520, 2525));
            g2.DrawString(disaydinlatmadegerleri.solarkafrenlambasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1520, 2585));
            g2.DrawString(disaydinlatmadegerleri.solarkaparklambasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1520, 2645));
            g2.DrawString(disaydinlatmadegerleri.solarkageriviteslambasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1520, 2705));
            g2.DrawString(disaydinlatmadegerleri.plakaisigi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1520, 2765));


            g2.DrawString(disaydinlatmadegerleri.sagarkasinyal, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2525));
            g2.DrawString(disaydinlatmadegerleri.sagarkafrenlambasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2585));
            g2.DrawString(disaydinlatmadegerleri.sagarkaparklambasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2645));
            g2.DrawString(disaydinlatmadegerleri.sagarkageriviteslambasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2705));
            g2.DrawString(disaydinlatmadegerleri.dortluisigi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2765));
            g2.DrawString(musteridegerleri.aliciadsoyad, new Font("Calibri", 39), Brushes.Black, new PointF(300, 3100));

            DisAydinlatma.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "disaydinlatma.jpg");

            DisAydinlatma.Dispose();
            b.Dispose();
            g2.Dispose();
        }
    }
}
