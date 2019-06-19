using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalajansBoyaMusteri
{
    public static class AracDisGorselRapor
    {
        public class aracresimleri
        {
            public string dosyayolu { get; set; }
        }
        public static void RaporYaz()
        {

            Bitmap New_Bitmap = new Bitmap(Properties.Resources.caracgorselleri, 2480, 3508);

            string klasoryolu = @"//10.0.0.141/SalautoRaporlar/" + musteridegerleri.barkodno + "/Resimler";

            FileInfo[] Images;
            DirectoryInfo Folder;

            Folder = new DirectoryInfo(klasoryolu);
            Images = Folder.GetFiles();

            List<aracresimleri> sepet = new List<aracresimleri>();
            foreach (FileInfo img in Images)
            {
                if (img.Extension.ToLower() == ".png" || img.Extension.ToLower() == ".jpg" || img.Extension.ToLower() == ".jpeg" || img.Extension.ToLower() == ".bmp")
                {
                    aracresimleri ar = new aracresimleri();
                    ar.dosyayolu = img.FullName;
                    sepet.Add(ar);
                }
            }


            Graphics g2 = Graphics.FromImage(New_Bitmap);

            try { if (sepet[0] != null) { Bitmap gelenresim1 = new Bitmap(sepet[0].dosyayolu); Image resizedImage1 = new Bitmap(gelenresim1, new Size(1066, 738)); g2.DrawImage(resizedImage1, new PointF(155, 1230)); } } catch (Exception) { }

            try { if (sepet[1] != null) { Bitmap gelenresim2 = new Bitmap(sepet[1].dosyayolu); Image resizedImage2 = new Bitmap(gelenresim2, new Size(1066, 738)); g2.DrawImage(resizedImage2, new PointF(1289, 1230)); } } catch (Exception) { }

            try { if (sepet[2] != null) { Bitmap gelenresim3 = new Bitmap(sepet[2].dosyayolu); Image resizedImage3 = new Bitmap(gelenresim3, new Size(1066, 738)); g2.DrawImage(resizedImage3, new PointF(155, 2230)); } } catch (Exception) { }

            try { if (sepet[3] != null) { Bitmap gelenresim4 = new Bitmap(sepet[3].dosyayolu); Image resizedImage4 = new Bitmap(gelenresim4, new Size(1066, 738)); g2.DrawImage(resizedImage4, new PointF(1289, 2230)); } } catch (Exception) { }
            #region Barkod
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            b.Alignment = BarcodeLib.AlignmentPositions.LEFT;
            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            type = BarcodeLib.TYPE.Codabar;
            g2.DrawImage(b.Encode(type, musteridegerleri.barkodno, 750, 170), new PointF(1625, 665));
            g2.DrawString(musteridegerleri.barkodno, new Font("Calibri", 30), Brushes.Black, new PointF(1860, 830));
            #endregion
            g2.DrawString(musteridegerleri.plaka, new Font("Calibri", 100), Brushes.Black, new PointF(1000, 3050));
            g2.DrawString(DateTime.Now.ToString(), new Font("Calibri", 58), Brushes.Black, new PointF(600, 730));

            New_Bitmap.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "z1.jpg");

           
            New_Bitmap.Dispose();
            g2.Dispose();

            if (sepet.Count > 4)
            {
                Bitmap New_Bitmap2 = new Bitmap(Properties.Resources.caracgorselleri, 2480, 3508);
                Graphics g3 = Graphics.FromImage(New_Bitmap2);

                try { if (sepet[4] != null) { Bitmap gelenresim5 = new Bitmap(sepet[4].dosyayolu); Image resizedImage5 = new Bitmap(gelenresim5, new Size(1066, 738)); g3.DrawImage(resizedImage5, new PointF(155, 1230)); } } catch (Exception) { }

                try { if (sepet[5] != null) { Bitmap gelenresim6 = new Bitmap(sepet[5].dosyayolu); Image resizedImage6 = new Bitmap(gelenresim6, new Size(1066, 738)); g3.DrawImage(resizedImage6, new PointF(1289, 1230)); } } catch (Exception) { }

                try { if (sepet[6] != null) { Bitmap gelenresim7 = new Bitmap(sepet[6].dosyayolu); Image resizedImage7 = new Bitmap(gelenresim7, new Size(1066, 738)); g3.DrawImage(resizedImage7, new PointF(155, 2230)); } } catch (Exception) { }

                try { if (sepet[7] != null) { Bitmap gelenresim8 = new Bitmap(sepet[7].dosyayolu); Image resizedImage8 = new Bitmap(gelenresim8, new Size(1066, 738)); g3.DrawImage(resizedImage8, new PointF(1289, 2230)); } } catch (Exception) { }


                g3.DrawImage(b.Encode(type, musteridegerleri.barkodno, 750, 170), new PointF(1625, 665));
                g3.DrawString(musteridegerleri.barkodno, new Font("Calibri", 30), Brushes.Black, new PointF(1860, 830));


                g3.DrawString(musteridegerleri.plaka, new Font("Calibri", 100), Brushes.Black, new PointF(1000, 3050));

                New_Bitmap2.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "z2.jpg");

               
                New_Bitmap2.Dispose();
                g3.Dispose();
            }



            if (sepet.Count > 8)
            {
                Bitmap New_Bitmap3 = new Bitmap(Properties.Resources.caracgorselleri, 2480, 3508);
                Graphics g3 = Graphics.FromImage(New_Bitmap3);

                try { if (sepet[8] != null) { Bitmap gelenresim9 = new Bitmap(sepet[8].dosyayolu); Image resizedImage9 = new Bitmap(gelenresim9, new Size(1066, 738)); g3.DrawImage(resizedImage9, new PointF(155, 1230)); } } catch (Exception) { }

                try { if (sepet[9] != null) { Bitmap gelenresim10 = new Bitmap(sepet[9].dosyayolu); Image resizedImage10 = new Bitmap(gelenresim10, new Size(1066, 738)); g3.DrawImage(resizedImage10, new PointF(1289, 1230)); } } catch (Exception) { }

                try { if (sepet[10] != null) { Bitmap gelenresim11 = new Bitmap(sepet[10].dosyayolu); Image resizedImage11 = new Bitmap(gelenresim11, new Size(1066, 738)); g3.DrawImage(resizedImage11, new PointF(155, 2230)); } } catch (Exception) { }

                try { if (sepet[11] != null) { Bitmap gelenresim12 = new Bitmap(sepet[11].dosyayolu); Image resizedImage12 = new Bitmap(gelenresim12, new Size(1066, 738)); g3.DrawImage(resizedImage12, new PointF(1289, 2230)); } } catch (Exception) { }
                g3.DrawImage(b.Encode(type, musteridegerleri.barkodno, 750, 170), new PointF(1625, 665));
                g3.DrawString(musteridegerleri.barkodno, new Font("Calibri", 30), Brushes.Black, new PointF(1860, 830));
                g3.DrawString(musteridegerleri.plaka, new Font("Calibri", 100), Brushes.Black, new PointF(1000, 3050));

                New_Bitmap3.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "z3.jpg");

             
                g3.Dispose();
                New_Bitmap3.Dispose();

            }
            if (sepet.Count > 12)
            {
                Bitmap New_Bitmap4 = new Bitmap(Properties.Resources.caracgorselleri, 2480, 3508);
                Graphics g3 = Graphics.FromImage(New_Bitmap4);

                try { if (sepet[12] != null) { Bitmap gelenresim13 = new Bitmap(sepet[12].dosyayolu); Image resizedImage13 = new Bitmap(gelenresim13, new Size(1066, 738)); g3.DrawImage(resizedImage13, new PointF(155, 1230)); } } catch (Exception) { }

                try { if (sepet[13] != null) { Bitmap gelenresim14 = new Bitmap(sepet[13].dosyayolu); Image resizedImage14 = new Bitmap(gelenresim14, new Size(1066, 738)); g3.DrawImage(resizedImage14, new PointF(1289, 1230)); } } catch (Exception) { }

                try { if (sepet[14] != null) { Bitmap gelenresim15 = new Bitmap(sepet[14].dosyayolu); Image resizedImage15 = new Bitmap(gelenresim15, new Size(1066, 738)); g3.DrawImage(resizedImage15, new PointF(155, 2230)); } } catch (Exception) { }

                try { if (sepet[15] != null) { Bitmap gelenresim16 = new Bitmap(sepet[15].dosyayolu); Image resizedImage16 = new Bitmap(gelenresim16, new Size(1066, 738)); g3.DrawImage(resizedImage16, new PointF(1289, 2230)); } } catch (Exception) { }
                g3.DrawImage(b.Encode(type, musteridegerleri.barkodno, 750, 170), new PointF(1625, 665));
                g3.DrawString(musteridegerleri.barkodno, new Font("Calibri", 30), Brushes.Black, new PointF(1860, 830));
                g3.DrawString(musteridegerleri.plaka, new Font("Calibri", 100), Brushes.Black, new PointF(1000, 3050));

                New_Bitmap4.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "z4.jpg");

                g3.Dispose();
                New_Bitmap4.Dispose();

            }
            if (sepet.Count > 16)
            {
                Bitmap New_Bitmap5 = new Bitmap(Properties.Resources.caracgorselleri, 2480, 3508);
                Graphics g3 = Graphics.FromImage(New_Bitmap5);

                try { if (sepet[16] != null) { Bitmap gelenresim17 = new Bitmap(sepet[16].dosyayolu); Image resizedImage17 = new Bitmap(gelenresim17, new Size(1066, 738)); g3.DrawImage(resizedImage17, new PointF(155, 1230)); } } catch (Exception) { }

                try { if (sepet[17] != null) { Bitmap gelenresim18 = new Bitmap(sepet[17].dosyayolu); Image resizedImage18 = new Bitmap(gelenresim18, new Size(1066, 738)); g3.DrawImage(resizedImage18, new PointF(1289, 1230)); } } catch (Exception) { }

                try { if (sepet[18] != null) { Bitmap gelenresim19 = new Bitmap(sepet[18].dosyayolu); Image resizedImage19 = new Bitmap(gelenresim19, new Size(1066, 738)); g3.DrawImage(resizedImage19, new PointF(155, 2230)); } } catch (Exception) { }

                try { if (sepet[19] != null) { Bitmap gelenresim20 = new Bitmap(sepet[19].dosyayolu); Image resizedImage20 = new Bitmap(gelenresim20, new Size(1066, 738)); g3.DrawImage(gelenresim20, new PointF(1289, 2230)); } } catch (Exception) { }

                g3.DrawImage(b.Encode(type, musteridegerleri.barkodno, 750, 170), new PointF(1625, 665));
                g3.DrawString(musteridegerleri.barkodno, new Font("Calibri", 30), Brushes.Black, new PointF(1860, 830));
                g3.DrawString(musteridegerleri.plaka, new Font("Calibri", 100), Brushes.Black, new PointF(1000, 3050));
                New_Bitmap5.Save(musteridegerleri.veriadresi + "\\" + musteridegerleri.barkodno + "z5.jpg");

              
                g3.Dispose();
                New_Bitmap5.Dispose();

            }
            b.Dispose();
        }
    }
}
