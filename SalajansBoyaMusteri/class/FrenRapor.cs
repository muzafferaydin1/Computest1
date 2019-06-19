using System;
using System.Drawing;


namespace SalajansBoyaMusteri
{
   public static class FrenRapor
    {
        public static void RaporYaz()
        {
            Bitmap FrenGorsel = new Bitmap(Properties.Resources.cfren, 2480, 3508);
            Graphics g2 = Graphics.FromImage(FrenGorsel);

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



            if (frendegerleri.AbsDurumu == "Yok")
            {
                g2.DrawString("Yok", new Font("Calibri", 30, FontStyle.Bold), Brushes.Black, new PointF(500, 2075));
            }
            else if (frendegerleri.AbsDurumu == "Kontrol Edilmelidir")
            {
                g2.DrawString("Kontrol Edilmelidir", new Font("Calibri", 30, FontStyle.Bold), Brushes.Black, new PointF(400, 2075));
            }
            else if (frendegerleri.AbsDurumu == "Çalışıyor")
            {
                g2.DrawString("Çalışıyor", new Font("Calibri", 30, FontStyle.Bold), Brushes.Black, new PointF(460, 2075));
            }
            else
            {
                g2.DrawString("Çalışmıyor", new Font("Calibri", 30, FontStyle.Bold), Brushes.Black, new PointF(458, 2075));
            }

            if (frendegerleri.EspDurumu == "Yok")
            {
                g2.DrawString("Yok", new Font("Calibri", 30, FontStyle.Bold), Brushes.Black, new PointF(1190, 2075));
            }
            else if (frendegerleri.EspDurumu == "Kontrol Edilmelidir")
            {
                g2.DrawString("Kontrol Edilmelidir", new Font("Calibri", 30, FontStyle.Bold), Brushes.Black, new PointF(1080, 2075));
            }
            else if (frendegerleri.EspDurumu == "Çalışıyor")
            {
                g2.DrawString("Çalışıyor", new Font("Calibri", 30, FontStyle.Bold), Brushes.Black, new PointF(1160, 2075));
            }
            else
            {
                g2.DrawString("Çalışmıyor", new Font("Calibri", 30, FontStyle.Bold), Brushes.Black, new PointF(1158, 2075));
            }
            if (frendegerleri.FrenAnaMerkezi == "Yok")
            {
                g2.DrawString("Yok", new Font("Calibri", 30, FontStyle.Bold), Brushes.Black, new PointF(1880, 2075));
            }
            else if (frendegerleri.FrenAnaMerkezi == "İyi")
            {
                g2.DrawString("İyi", new Font("Calibri", 30, FontStyle.Bold), Brushes.Black, new PointF(1880, 2075));
            }
            else if (frendegerleri.FrenAnaMerkezi == "Orta")
            {
                g2.DrawString("Orta", new Font("Calibri", 30, FontStyle.Bold), Brushes.Black, new PointF(1878, 2075));
            }
            else if (frendegerleri.FrenAnaMerkezi == "Kontrol Edilmelidir")
            {
                g2.DrawString("Kontrol Edilmelidir", new Font("Calibri", 30, FontStyle.Bold), Brushes.Black, new PointF(1785, 2075));
            }
            else
            {
                g2.DrawString("Zayıf", new Font("Calibri", 30, FontStyle.Bold), Brushes.Black, new PointF(1875, 2075));
            }

            //SOL ÖN

            g2.DrawString(frendegerleri.SolOnFrenDiski, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(475, 2230));
            g2.DrawString(frendegerleri.SolOnFrenBalatasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(475, 2290));
            g2.DrawString(frendegerleri.SolOnFrenPistonlari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(475, 2350));
            g2.DrawString(frendegerleri.SolOnFrenHortumlari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(475, 2410));
            g2.DrawString(frendegerleri.SolOnBijonGirisleri, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(475, 2470));
            g2.DrawString(frendegerleri.SolOnHidrolikSeviyesi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(475, 2530));
            g2.DrawString(frendegerleri.SolOnMerkezPompasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(475, 2590));
            g2.DrawString(frendegerleri.SolOnKampana, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(475, 2650));
            g2.DrawString(frendegerleri.SolOnLimitor, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(475, 2710));
            g2.DrawString(frendegerleri.SolOnServo, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(475, 2770));

            ////SAĞ ÖN

            g2.DrawString(frendegerleri.SagOnFrenDiski, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1000, 2230));
            g2.DrawString(frendegerleri.SagOnFrenBalatasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1000, 2290));
            g2.DrawString(frendegerleri.SagOnFrenPistonlari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1000, 2350));
            g2.DrawString(frendegerleri.SagOnFrenHortumlari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1000, 2410));
            g2.DrawString(frendegerleri.SagOnBijonGirisleri, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1000, 2470));
            g2.DrawString(frendegerleri.SagOnHidrolikSeviyesi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1000, 2530));
            g2.DrawString(frendegerleri.SagOnMerkezPompasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1000, 2590));
            g2.DrawString(frendegerleri.SagOnKampana, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1000, 2650));
            g2.DrawString(frendegerleri.SagOnLimitor, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1000, 2710));
            g2.DrawString(frendegerleri.SagOnServo, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1000, 2770));


            ////SOL ARKA

            g2.DrawString(frendegerleri.SolArkaFrenDiski, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2230));
            g2.DrawString(frendegerleri.SolArkaFrenBalatasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2290));
            g2.DrawString(frendegerleri.SolArkaFrenPistonlari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2350));
            g2.DrawString(frendegerleri.SolArkaFrenHortumlari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2410));
            g2.DrawString(frendegerleri.SolArkaBijonGirisleri, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2470));
            g2.DrawString(frendegerleri.SolArkaHidrolikSeviyesi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2530));
            g2.DrawString(frendegerleri.SolArkaMerkezPompasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2590));
            g2.DrawString(frendegerleri.SolArkaKampana, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2650));
            g2.DrawString(frendegerleri.SolArkaLimitor, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2710));
            g2.DrawString(frendegerleri.SolArkaServo, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(1525, 2770));

            ////SAĞ ARKA

            g2.DrawString(frendegerleri.SagArkaFrenDiski, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2050, 2230));
            g2.DrawString(frendegerleri.SagArkaFrenBalatasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2050, 2290));
            g2.DrawString(frendegerleri.SagArkaFrenPistonlari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2050, 2350));
            g2.DrawString(frendegerleri.SagArkaFrenHortumlari, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2050, 2410));
            g2.DrawString(frendegerleri.SagArkaBijonGirisleri, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2050, 2470));
            g2.DrawString(frendegerleri.SagArkaHidrolikSeviyesi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2050, 2530));
            g2.DrawString(frendegerleri.SagArkaMerkezPompasi, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2050, 2590));
            g2.DrawString(frendegerleri.SagArkaKampana, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2050, 2650));
            g2.DrawString(frendegerleri.SagArkaLimitor, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2050, 2710));
            g2.DrawString(frendegerleri.SagArkaServo, new Font("Calibri", 22, FontStyle.Bold), Brushes.Black, new PointF(2050, 2770));

            g2.DrawString(musteridegerleri.aliciadsoyad, new Font("Calibri", 39), Brushes.Black, new PointF(300, 3100));

            FrenGorsel.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "fren.jpg");

            FrenGorsel.Dispose();
            g2.Dispose();
            b.Dispose();
        }
    }
}
