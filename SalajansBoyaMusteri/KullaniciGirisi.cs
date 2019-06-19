using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Management;
using Microsoft.Win32;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.IO;

namespace SalajansBoyaMusteri
{
    public partial class KullaniciGirisi : Form
    {
        public KullaniciGirisi()
        {
            InitializeComponent();
        }

        DBEntities db = new DBEntities();
        private void KullaniciGirisi_Load(object sender, EventArgs e)
        {
            try
            {
                var cpuid = string.Empty;
                var hddserial = string.Empty;
                var motherboardserial = string.Empty;
                var macaddress = string.Empty;

                #region cpu id  
                string sQuery = "SELECT ProcessorId FROM Win32_Processor";
                ManagementObjectSearcher oManagementObjectSearcher = new ManagementObjectSearcher(sQuery);
                ManagementObjectCollection oCollection = oManagementObjectSearcher.Get();
                foreach (ManagementObject oManagementObject in oCollection)
                {
                    cpuid = (string)oManagementObject["ProcessorId"];
                    break;
                }

                #endregion cpu id

                #region mac address// Mac adresi alma

                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                String sMacAddress = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        macaddress = adapter.GetPhysicalAddress().ToString();
                    }
                }

                #endregion mac address

                #region hdd serial // Harddisk serial alma

                ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
                dsk.Get();
                hddserial = dsk["VolumeSerialNumber"].ToString();

                #endregion hdd serial

                #region motherboard serial // Motherboard serial alma

                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                ManagementObjectCollection moc = mos.Get();
                foreach (ManagementObject mo in moc)
                {
                    motherboardserial = (string)mo["SerialNumber"];
                    break;
                }

                #endregion motherboard serial

                var anahtar = cpuid.Trim() + " " + hddserial.Trim() + " " + motherboardserial.Trim() + " " + macaddress.Trim();
                anahtar = Md5Sifrele(anahtar);
                string RegisterKey = Registry.CurrentUser.OpenSubKey("Volatile Unvironment").GetValue("CLIENTNO").ToString();
                //var ipAdress = GetIPAddress().Trim();

                var yanit = (from firma in db.TBL_Firmalar
                             join fk in db.TBL_Firma_FK
                             on firma.FirmaID equals fk.FirmaID
                             join lisans in db.TBL_FirmaPCKeys
                             on fk.LisansID equals lisans.LisansID
                             join kullanici in db.TBL_Kullanicilar
                             on fk.KullaniciID equals kullanici.KullaniciID
                             where lisans.RegeditKey == RegisterKey  && lisans.LisansNo == anahtar
                              
                             select new
                             {
                                 firma.FirmaAdi,
                                 lisans.RegeditKey,
                                 kullanici.KullaniciAdi,
                                 kullanici.Parola,
                                 kullanici.KullaniciAdSoyad,
                                 firma.FirmaNo,
                                 kullanici.Yetki
                             });

                if (RegisterKey == yanit.First().RegeditKey && yanit != null)
                {
                    lblfirma.Text = yanit.First().FirmaAdi;
                    lbllisanssahibi.Text = yanit.First().KullaniciAdSoyad;
                    KullaniciveFirmaBilgileri.FirmaAdi = yanit.First().FirmaAdi;
                    KullaniciveFirmaBilgileri.FirmaNo = yanit.First().FirmaNo;
                    KullaniciveFirmaBilgileri.KullaniciAdSoyad = yanit.First().KullaniciAdSoyad;
                    KullaniciveFirmaBilgileri.Yetki = yanit.First().Yetki;
                }
                else
                {
                    MessageBox.Show("Lisans Anahtarı Hatası.", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show("Program Kapatılıyor..", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                    Application.Exit();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lisans Anahtarı Hatası.", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show("Program Kapatılıyor..", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(ex.ToString(),"", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Application.Exit();
            }




        }


        public static string Md5Sifrele(string str)
        {
            string result = string.Empty;
            try
            {
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                byte[] bytes = Encoding.ASCII.GetBytes(str);
                byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
                int capacity = (int)Math.Round((double)(array.Length * 3) + (double)array.Length / 8);
                StringBuilder stringBuilder = new StringBuilder(capacity);
                int num = array.Length - 1;
                for (int i = 0; i <= num; i++)
                {
                    stringBuilder.Append(BitConverter.ToString(array, i, 1));
                }
                result = stringBuilder.ToString().TrimEnd(new char[]
                {
            ' '
                });
            }
            catch (Exception)
            {
            }
            return result;
        }
        static string GetIPAddress()
        {
            String address = "";
            WebRequest request = WebRequest.Create("http://compytest.com/home/getip");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                address = stream.ReadToEnd();
            }
             
            return address;
        }
        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btngiris_Click(object sender, EventArgs e)
        {
            var kontrol = db.TBL_Kullanicilar.Any(x => x.KullaniciAdi == txtkadi.Text && x.Parola == txtsifre.Text);
            if (kontrol)
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı bilgileri hatalı !..", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        private void KullaniciGirisi_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

    }
}
