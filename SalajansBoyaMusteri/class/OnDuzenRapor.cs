using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalajansBoyaMusteri
{
    public static class OnDuzenRapor
    {
        public static void RaporYaz()
        {

            Bitmap OnduzenGorsel = new Bitmap(Properties.Resources.conduzen, 2408, 3508);
            Graphics g2 = Graphics.FromImage(OnduzenGorsel);

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


            #region SolTaraf1
            g2.DrawString("SOL", new Font("Calibri", 44, FontStyle.Bold), Brushes.Black, new PointF(520, 2200));

            g2.DrawString(onduzensonuclari.SolAmartisorTakozu, new Font("Calibri", 33), Brushes.Black, new PointF(200, 2300));
            g2.DrawString(onduzensonuclari.SolUstTabla, new Font("Calibri", 33), Brushes.Black, new PointF(200, 2360));
            g2.DrawString(onduzensonuclari.SolYanTablaKolu, new Font("Calibri", 33), Brushes.Black, new PointF(200, 2420));
            g2.DrawString(onduzensonuclari.SolPorya, new Font("Calibri", 33), Brushes.Black, new PointF(200, 2480));
            g2.DrawString(onduzensonuclari.SolZrot, new Font("Calibri", 33), Brushes.Black, new PointF(200, 2540));
            g2.DrawString(onduzensonuclari.SolTabla, new Font("Calibri", 33), Brushes.Black, new PointF(200, 2600));
            g2.DrawString(onduzensonuclari.SolTeraziKolu, new Font("Calibri", 33), Brushes.Black, new PointF(200, 2660));

            #endregion
            #region SolTaraf2
            g2.DrawString("SAĞ", new Font("Calibri", 44, FontStyle.Bold), Brushes.Black, new PointF(1630, 2200));

            g2.DrawString(onduzensonuclari.SagAmartisorTakozu, new Font("Calibri", 33), Brushes.Black, new PointF(1310, 2300));
            g2.DrawString(onduzensonuclari.SagUstTabla, new Font("Calibri", 33), Brushes.Black, new PointF(1310, 2360));
            g2.DrawString(onduzensonuclari.SagYanTablaKolu, new Font("Calibri", 33), Brushes.Black, new PointF(1310, 2420));
            g2.DrawString(onduzensonuclari.SagPorya, new Font("Calibri", 33), Brushes.Black, new PointF(1310, 2480));
            g2.DrawString(onduzensonuclari.SagZrot, new Font("Calibri", 33), Brushes.Black, new PointF(1310, 2540));
            g2.DrawString(onduzensonuclari.SagTabla, new Font("Calibri", 33), Brushes.Black, new PointF(1310, 2600));
            g2.DrawString(onduzensonuclari.SagTeraziKolu, new Font("Calibri", 33), Brushes.Black, new PointF(1310, 2660));

            #endregion

            g2.DrawString(musteridegerleri.aliciadsoyad, new Font("Calibri", 39), Brushes.Black, new PointF(300, 3100));

            OnduzenGorsel.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "OnDuzen.jpg");

       
            OnduzenGorsel.Dispose();
            g2.Dispose();
            b.Dispose();

        }
    }
}
