using System;
using System.Drawing;



namespace SalajansBoyaMusteri
{
    public static class DonanimRapor
    {
        public static void RaporYaz()
        {
            Bitmap DonanimGorsel = new Bitmap(Properties.Resources.cicmekandonanim, 2480, 3508);
            Graphics g2 = Graphics.FromImage(DonanimGorsel);
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

            g2.DrawString(donanimdegerleri.surucuhy, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(425, 2541));
            g2.DrawString(donanimdegerleri.yolcuhy, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(425, 2599));
            g2.DrawString(donanimdegerleri.bagajdosemesi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(425, 2657));
            g2.DrawString(donanimdegerleri.gogusdosemesi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(425, 2715));
            g2.DrawString(donanimdegerleri.camtavan, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(425, 2773));


            g2.DrawString(donanimdegerleri.onemniyetk, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(970, 2541));
            g2.DrawString(donanimdegerleri.arkaemniyet, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(970, 2599));
            g2.DrawString(donanimdegerleri.otomatikcamlar, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(970, 2657));
            g2.DrawString(donanimdegerleri.tavanaydinlatamasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(970, 2715));
            g2.DrawString(donanimdegerleri.kapiaydinlatmasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(970, 2773));



            g2.DrawString(donanimdegerleri.koltukdosemeleri, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1515, 2541));
            g2.DrawString(donanimdegerleri.direksiyon, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1515, 2599));
            g2.DrawString(donanimdegerleri.merkezikilit, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1515, 2657));
            g2.DrawString(donanimdegerleri.sunroof, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1515, 2715));
            g2.DrawString(donanimdegerleri.alarm, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1515, 2773));
            g2.DrawString(donanimdegerleri.sagayna, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2541));
            g2.DrawString(donanimdegerleri.solayna, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2599));
            g2.DrawString(donanimdegerleri.panelvekadran, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2657));
            g2.DrawString(donanimdegerleri.konsol, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2715));
            g2.DrawString(donanimdegerleri.silecekler, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2773));

            g2.DrawString(musteridegerleri.aliciadsoyad, new Font("Calibri", 39), Brushes.Black, new PointF(300, 3100));

            DonanimGorsel.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "donanim.jpg");



          
            DonanimGorsel.Dispose();
            g2.Dispose();
            b.Dispose();
        }
    }
}
