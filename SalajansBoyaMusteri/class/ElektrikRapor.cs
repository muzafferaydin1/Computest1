using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalajansBoyaMusteri
{
    public static class ElektrikRapor
    {
        public static void RaporYaz()
        {
            Bitmap ElektrikGorsel = new Bitmap(Properties.Resources.celektrik, 2408, 3508);


            Graphics  g = Graphics.FromImage(ElektrikGorsel);
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
             g.DrawString(elektrikdegerleri.akudurumu, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(425, 2600));
             g.DrawString(elektrikdegerleri.sarjdinamosu, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(425, 2660));
             g.DrawString(elektrikdegerleri.marsdinamosu, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(425, 2715));
             g.DrawString(elektrikdegerleri.klimaelektrik, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(425, 2780));

             g.DrawString(elektrikdegerleri.yakitsistemielektrik, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(975, 2600));
             g.DrawString(elektrikdegerleri.motorelektrik, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(975, 2660));
             g.DrawString(elektrikdegerleri.otomatikcamelektrik, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(975, 2715));
             g.DrawString(elektrikdegerleri.aydinlatmaelektrik, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(975, 2780));


             g.DrawString(elektrikdegerleri.teypelektrik, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2600));
             g.DrawString(elektrikdegerleri.sogutmasistemielektrik, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2660));
             g.DrawString(elektrikdegerleri.merkezikilitelektrik, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2715));
             g.DrawString(elektrikdegerleri.alarmsistemielektrik, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2780));

             g.DrawString(elektrikdegerleri.sagaynaelektrik, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2600));
             g.DrawString(elektrikdegerleri.solaynaelektrik, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2660));
             g.DrawString(elektrikdegerleri.panelvekadranelektrik, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2715));
             g.DrawString(elektrikdegerleri.tesisatkacak, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2780));


            g.DrawString(musteridegerleri.aliciadsoyad, new Font("Calibri", 39), Brushes.Black, new PointF(300, 3100));

            ElektrikGorsel.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "elektrik.jpg");
          
            ElektrikGorsel.Dispose();
            g.Dispose();
            b.Dispose();

        }
    }
}
