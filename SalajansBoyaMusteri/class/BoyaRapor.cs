using System;
using System.Drawing;


namespace SalajansBoyaMusteri
{
    public static class BoyaRapor
    {

        public static void  RaporYaz()
        {
            try
            {
                Bitmap BoyaGorsel = new Bitmap(Properties.Resources.csedan, 2480, 3508);

                if (musteridegerleri.arackasa == "Sedan")
                {
                    BoyaGorsel = Properties.Resources.csedan;
                }
                else if (musteridegerleri.arackasa == "Glassvan-Kapalı Kasa-Standart")
                {
                    BoyaGorsel = Properties.Resources.cglassvan;
                }
                else if (musteridegerleri.arackasa == "Glassvan-Kapalı Kasa-Standart-3 Kapı")
                {
                    BoyaGorsel = Properties.Resources.cglassvan3kapi;
                }
                else if (musteridegerleri.arackasa == "Panelvan-Kapalı Kasa-Standart")
                {
                    BoyaGorsel = Properties.Resources.cpanelvan3kapicamsiz;
                }
                else if (musteridegerleri.arackasa == "Minivan-Kapalı Kasa-Standart")
                {
                    BoyaGorsel = Properties.Resources.cminivancamli;
                }
                else if (musteridegerleri.arackasa == "Minivan-Kapalı Kasa-Standart-Camsız")
                {
                    BoyaGorsel = Properties.Resources.cminivancamsiz;
                }
                else if (musteridegerleri.arackasa == "Midivan-Kapalı Kasa-Standart")
                {
                    BoyaGorsel = Properties.Resources.cminivancamli;
                }
                else if (musteridegerleri.arackasa == "Midivan-Kapalı Kasa-Standart-Camsız")
                {
                    BoyaGorsel = Properties.Resources.cminivancamsiz;
                }
                else if (musteridegerleri.arackasa == "Hatchbag Tek Kapı")
                {
                    BoyaGorsel = Properties.Resources.chbtekkapi;

                }
                else if (musteridegerleri.arackasa == "Pickup Tek Kabin")
                {
                    BoyaGorsel = Properties.Resources.cpickup3kabin;

                }
                else if (musteridegerleri.arackasa == "Pickup Çift Kabin")
                {
                    BoyaGorsel = Properties.Resources.cpickup4kabin;

                }
                else if (musteridegerleri.arackasa == "SUV Tek Kapı")
                {
                    BoyaGorsel = Properties.Resources.csuvtekkapi;

                }
                else if (musteridegerleri.arackasa == "SUV Çift Kapı")
                {
                    BoyaGorsel = Properties.Resources.csuv;

                }
                else if (musteridegerleri.arackasa == "SW")
                {
                    BoyaGorsel = Properties.Resources.csw;

                }
                else if (musteridegerleri.arackasa == "SW 2 Kapı")
                {
                    BoyaGorsel = Properties.Resources.cswtek;

                }
                else if (musteridegerleri.arackasa == "Cabrio")
                {
                    BoyaGorsel = Properties.Resources.ccabrio;

                }
                else if (musteridegerleri.arackasa == "Cabrio4")
                {
                    BoyaGorsel = Properties.Resources.ccabrio4kapi;

                }
                else if (musteridegerleri.arackasa == "Coupe")
                {
                    BoyaGorsel = Properties.Resources.chbtekkapi;

                }
                else
                {
                    BoyaGorsel = Properties.Resources.chb4kapi;
                }

                Graphics g = Graphics.FromImage(BoyaGorsel);
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();


                b.Alignment = BarcodeLib.AlignmentPositions.LEFT;
                BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
                type = BarcodeLib.TYPE.Codabar;


                #region Araç Km
                g.DrawString(musteridegerleri.kmsi, new Font("Calibri", 13), Brushes.Black, new PointF(1308, 695));
                #endregion
                #region Araç Plaka
                g.DrawString(musteridegerleri.plaka, new Font("Calibri", 15), Brushes.Black, new PointF(537, 690));
                #endregion
                #region MarkaModel
                g.DrawString(musteridegerleri.aracmodeli+" Model:"+musteridegerleri.aracyili, new Font("Calibri", 13), Brushes.Black, new PointF(140, 910));
                #endregion
                #region rENK
                g.DrawString(musteridegerleri.renk, new Font("Calibri", 13), Brushes.Black, new PointF(1215, 825));
                #endregion
                #region Kanaat
                g.DrawString(musteridegerleri.testsonucu, new Font("Calibri", 15), Brushes.Black, new PointF(144, 2510));
                #endregion


                //Sol Taraf
                #region Sol Ön Çamurluk
                Bitmap bmpsoloncamurluk = new Bitmap(boyadegerleri.soloncamurluk, 35, 35);
                g.DrawImage(bmpsoloncamurluk, new PointF(boyakonumlari.soloncamurlukX, boyakonumlari.soloncamurlukY));
                #endregion
                #region Sol Ön Kapı
                Bitmap bmpsolonkapi = new Bitmap(boyadegerleri.solonkapi, 35, 35);
                g.DrawImage(bmpsolonkapi, new PointF(boyakonumlari.solonkapiX, boyakonumlari.solonkapiY));
                #endregion
                #region Sol Arka Kapı
                Bitmap bmpsolarkakapi = new Bitmap(boyadegerleri.solarkakapi, 35, 35);
                g.DrawImage(bmpsolarkakapi, new PointF(boyakonumlari.solarkakapiX, boyakonumlari.solarkakapiY));
                #endregion
                #region Sol Arka Çamurluk
                Bitmap bmpsolarkacamurluk = new Bitmap(boyadegerleri.solarkacamurluk, 35, 35);
                g.DrawImage(bmpsolarkacamurluk, new PointF(boyakonumlari.solarkacamurlukX, boyakonumlari.solarkacamurlukY));
                #endregion


                //Sağ Taraf
                #region Sağ Arka Çamurluk
                Bitmap bmpsagarkacamurluk = new Bitmap(boyadegerleri.sagarkacamurluk, 35, 35);
                g.DrawImage(bmpsagarkacamurluk, new PointF(boyakonumlari.sagarkacamurlukX, boyakonumlari.sagarkacamurlukY));
                #endregion
                #region Sağ Arka Kapı
                Bitmap bmpsagarakkapi = new Bitmap(boyadegerleri.sagarkakapi, 35, 35);
                g.DrawImage(bmpsagarakkapi, new PointF(boyakonumlari.sagarkakapiX, boyakonumlari.sagarkakapiY));
                #endregion
                #region Sağ Ön Kapı
                Bitmap bmpsagonkapi = new Bitmap(boyadegerleri.sagonkapi, 35, 35);
                g.DrawImage(bmpsagonkapi, new PointF(boyakonumlari.sagonkapiX, boyakonumlari.sagonkapiY));
                #endregion
                #region Sağ Ön Çamurluk
                Bitmap bmpsagoncamurluk = new Bitmap(boyadegerleri.sagoncamurluk, 35, 35);
                g.DrawImage(bmpsagoncamurluk, new PointF(boyakonumlari.sagoncamurlukX, boyakonumlari.sagoncamurlukY));
                #endregion

                //Diğer taraflar
                #region Kaput
                Bitmap bmpkaput = new Bitmap(boyadegerleri.kaput, 35, 35);
                g.DrawImage(bmpkaput, new PointF(boyakonumlari.kaputX, boyakonumlari.kaputY));
                #endregion

                #region Tavan
                Bitmap bmptavan = new Bitmap(boyadegerleri.tavan, 35, 35);
                g.DrawImage(bmptavan, new PointF(boyakonumlari.tavanX, boyakonumlari.tavanY));
                #endregion

                #region Bagaj
                Bitmap bmpbagaj = new Bitmap(boyadegerleri.bagaj, 35, 35);
                g.DrawImage(bmpbagaj, new PointF(boyakonumlari.bagajX, boyakonumlari.bagajY));
                #endregion

                #region Barkod

                g.DrawImage(b.Encode(type, musteridegerleri.barkodno, 244, 55), new PointF(1625, 810));


                g.DrawString(musteridegerleri.barkodno, new Font("Calibri", 8), Brushes.Black, new PointF(1860, 975));
                #endregion

                #region Tarih Saat
                g.DrawString(DateTime.Now.ToShortDateString() + " / " + DateTime.Now.ToShortTimeString(), new Font("Calibri", 12), Brushes.Black, new PointF(1950, 700));
                #endregion

                #region AlıcıTelefon
                g.DrawString(musteridegerleri.alicitelefon, new Font("Calibri", 12), Brushes.Black, new PointF(440, 2885));
                #endregion

                g.DrawString(musteridegerleri.aliciadsoyad, new Font("Calibri", 13), Brushes.Black, new PointF(300, 3100));

           
                 g.DrawString(musteridegerleri.uyarimesaji, new Font("Calibri", 9), Brushes.Black, new PointF(110, 3400));
                        


                
                BoyaGorsel.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "Boya.jpg");

              
                BoyaGorsel.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                g.Dispose();
                b.Dispose();
            }
            catch (Exception)
            {
            }
           
        }

    }
}
