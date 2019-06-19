using System;
using System.Drawing;

namespace SalajansBoyaMusteri
{
    public static class MotorRapor
    {
        public static void RaporYaz(bool TabloYazilsinMi)
        {
            Bitmap MotorGorsel = new Bitmap(motordegerleri.RaporResmi, 2480, 3508);


            Graphics g2 = Graphics.FromImage(MotorGorsel);


            if (motordegerleri.YakitTipi == "Dizel")
            {
                if (motordegerleri.MotorGenelDurum == "İyi")
                {
                    g2.DrawString(motordegerleri.MotorGenelDurum, new Font("Calibri", 50, FontStyle.Bold), Brushes.Black, new PointF(2030, 1880));
                }
                else
                {
                    g2.DrawString(motordegerleri.MotorGenelDurum, new Font("Calibri", 50, FontStyle.Bold), Brushes.Black, new PointF(2000, 1880));
                }

                g2.DrawString("%" + motordegerleri.MotorPerformansPuani.ToString(), new Font("Calibri", 50, FontStyle.Bold), Brushes.Black, new PointF(2075, 1310));


            }
            else
            {
                if (motordegerleri.MotorGenelDurum == "İyi")
                {
                    g2.DrawString(motordegerleri.MotorGenelDurum, new Font("Calibri", 50, FontStyle.Bold), Brushes.Black, new PointF(1860, 1880));
                }
                else
                {
                    g2.DrawString(motordegerleri.MotorGenelDurum, new Font("Calibri", 50, FontStyle.Bold), Brushes.Black, new PointF(1830, 1880));

                }

                g2.DrawString("%" + motordegerleri.MotorPerformansPuani.ToString(), new Font("Calibri", 50, FontStyle.Bold), Brushes.Black, new PointF(2075, 1310));


            }


            g2.DrawString("", new Font("Calibri", 50, FontStyle.Bold), Brushes.Black, new PointF(2000, 1880));



            g2.DrawString("", new Font("Calibri", 50, FontStyle.Bold), Brushes.Black, new PointF(2100, 1310));



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

            if (TabloYazilsinMi)
            {
                g2.DrawString(motordegerleri.ustkapak, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(435, 2300));
                g2.DrawString(motordegerleri.silindirkapak, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(435, 2360));
                g2.DrawString(motordegerleri.sarjdinamosu, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(435, 2420));
                g2.DrawString(motordegerleri.vkayisi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(435, 2475));
                g2.DrawString(motordegerleri.krankkasnagi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(435, 2535));
                g2.DrawString(motordegerleri.motorkasnaklari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(435, 2595));
                g2.DrawString(motordegerleri.marsdinamosu, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(435, 2655));
                g2.DrawString(motordegerleri.yakitpompasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(435, 2710));



                g2.DrawString(motordegerleri.elektriktesisati, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(960, 2300));
                g2.DrawString(motordegerleri.klimahortumu, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(960, 2360));
                g2.DrawString(motordegerleri.egr, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(960, 2420));
                g2.DrawString(motordegerleri.turbo, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(960, 2475));
                g2.DrawString(motordegerleri.turbohortumlari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(960, 2535));
                g2.DrawString(motordegerleri.klima, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(960, 2595));
                g2.DrawString(motordegerleri.klimagazi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(960, 2655));
                g2.DrawString(motordegerleri.emmemanifortu, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(960, 2710));



                g2.DrawString(motordegerleri.kelebekkutusu, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1485, 2300));
                g2.DrawString(motordegerleri.ateslemesistemiveyakitenjektorleri, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1485, 2360));
                g2.DrawString(motordegerleri.motorkulagi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1485, 2420));
                g2.DrawString(motordegerleri.motorbeyni, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1485, 2475));
                g2.DrawString(motordegerleri.yagseviyesi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1485, 2535));
                g2.DrawString(motordegerleri.egzozemisyon, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1485, 2595));
                g2.DrawString(motordegerleri.havaakisfiltresi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1485, 2655));
                g2.DrawString(motordegerleri.sogutmasistemi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1485, 2710));



                g2.DrawString(motordegerleri.yagkacagi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2300));
                g2.DrawString(motordegerleri.ufleme, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2360));
                g2.DrawString(motordegerleri.yagyakma, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2420));
                g2.DrawString(motordegerleri.sibopiticileri, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2475));
                g2.DrawString(motordegerleri.silindirkapakconta, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2535));
                g2.DrawString(motordegerleri.suhortumlari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2595));
                g2.DrawString(motordegerleri.yakithortumlari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2655));
                g2.DrawString(motordegerleri.lpgsistemivekizdirmabujileri, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2060, 2710)); 
            }

            g2.DrawString(musteridegerleri.aliciadsoyad, new Font("Calibri", 39), Brushes.Black, new PointF(300, 3100));


            MotorGorsel.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "motor.jpg");
           

            MotorGorsel.Dispose();
            b.Dispose();
            g2.Dispose();
        }
    }
}
