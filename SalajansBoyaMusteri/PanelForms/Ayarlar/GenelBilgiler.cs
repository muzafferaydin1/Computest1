using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalajansBoyaMusteri.PanelForms.Ayarlar
{
    public partial class GenelBilgiler : Form
    {
        public GenelBilgiler()
        {
            InitializeComponent();
        }

        private void GenelBilgiler_Load(object sender, EventArgs e)
        {
            GetCPUInfos();

            GetRamInfos();

            GetHDDFreeSpaces();

            GetGraphics();

            Rectangle resolution = Screen.PrimaryScreen.Bounds;

            if (resolution.Width>=1280 && resolution.Height>=800)
            {
                pnlcozunurluk.BackColor = Color.DarkGreen;
                lblcozunurluk.ForeColor = Color.White;
            }
            else
            {
                pnlcozunurluk.BackColor = Color.Red;
                lblcozunurluk.ForeColor = Color.White;
            }
            lblcozunurluk.Text = resolution.Width+ "x" + resolution.Height;

        }

        private void GetGraphics()
        {
            if (GetDirectxMajorVersion()< 9)
            {
                pnl3d.BackColor = Color.Red;
                lbl3d.ForeColor = Color.White;
            }
            else if (GetDirectxMajorVersion()>= 9 && GetDirectxMajorVersion() <=10 )
            {
                pnl3d.BackColor = Color.Blue;
                lbl3d.ForeColor = Color.White;
                
            }
            else if (GetDirectxMajorVersion() > 10)
            {
                pnl3d.BackColor = Color.DarkGreen;
                lbl3d.ForeColor = Color.White; 
            }
            lbl3d.Text = "Directx " + GetDirectxMajorVersion().ToString();

        }

        private void GetHDDFreeSpaces()
        {
            if (AvailableFreeSpace() > 2147483648 && AvailableFreeSpace() < 4147483648)
            {
                pnlhdd.BackColor = Color.DarkOrange;
                lblhdd.ForeColor = Color.White;
                lblhdd.Text = "Orta";
            }
            else if (AvailableFreeSpace() <= 2147483648)
            {
                pnlhdd.BackColor = Color.Red;
                lblhdd.ForeColor = Color.White;
                lblhdd.Text = "Kötü";
            }
            else if (AvailableFreeSpace() > 5147483648)
            {
                pnlhdd.BackColor = Color.DarkGreen;
                lblhdd.ForeColor = Color.White;
                lblhdd.Text = "Çok İyi";
            }
        }

        private void GetRamInfos()
        {
            string deger = getRAMsize();
            int ramMemory = getRAMsize().Toint58();
            lblram.Text = ramMemory.ToString() + " MB";

            if (ramMemory <= 1024)
            {
                pnlram.BackColor = Color.Black;
                lblram.ForeColor = Color.White;
            }
            else if (ramMemory > 1024 && ramMemory <= 2047)
            {
                pnlram.BackColor = Color.Red;
                lblram.ForeColor = Color.White;
            }
            else if (ramMemory > 2048 && ramMemory <= 2815)
            {
                pnlram.BackColor = Color.DarkOrange;
                lblram.ForeColor = Color.White;
            }
            else if (ramMemory > 2815 && ramMemory <= 3999)
            {
                pnlram.BackColor = Color.Blue;
                lblram.ForeColor = Color.White;
            }
            else if (ramMemory > 3999)
            {
                pnlram.BackColor = Color.DarkGreen;
                lblram.ForeColor = Color.White;
            }
        }

        private void GetCPUInfos()
        {
            var searcher = new ManagementObjectSearcher("select MaxClockSpeed from Win32_Processor");
            foreach (var item in searcher.Get())
            {
                double clockSpeed = (uint)item["MaxClockSpeed"] / 1000;
                lblislemci.Text = clockSpeed.ToString() + ".0 Ghz";

                if (clockSpeed <= 1.2)
                {
                    pnlislemci.BackColor = Color.Black;
                    lblislemci.ForeColor = Color.White;
                }
                else if (clockSpeed > 1.2 && clockSpeed <= 1.8)
                {
                    pnlislemci.BackColor = Color.Red;
                    lblislemci.ForeColor = Color.White;
                }
                else if (clockSpeed > 1.8 && clockSpeed <= 2.3)
                {
                    pnlislemci.BackColor = Color.DarkOrange;
                    lblislemci.ForeColor = Color.White;
                }
                else if (clockSpeed > 2.3 && clockSpeed <= 2.9)
                {
                    pnlislemci.BackColor = Color.Blue;
                    lblislemci.ForeColor = Color.White;
                }
                else if (clockSpeed >= 2.9)
                {
                    pnlislemci.BackColor = Color.DarkGreen;
                    lblislemci.ForeColor = Color.White;
                }
            }
        }

        private static String getRAMsize()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject item in moc)
            {
                return Convert.ToString(Math.Round(Convert.ToDouble(item.Properties["TotalPhysicalMemory"].Value) / 1048576, 0));
            }

            return "RAMsize";
        }
        public long AvailableFreeSpace()
        {
            long longAvailableFreeSpace = 0;

            DriveInfo[] arrayOfDrives = DriveInfo.GetDrives();
            foreach (var d in arrayOfDrives)
            {
                longAvailableFreeSpace = d.TotalFreeSpace;
                break;
            }

            return longAvailableFreeSpace;
        }
        private int GetDirectxMajorVersion()
        {
            int directxMajorVersion = 0;

            var OSVersion = Environment.OSVersion;

            // if Windows Vista or later
            if (OSVersion.Version.Major >= 6)
            {
                // if Windows 7 or later
                if (OSVersion.Version.Major > 6 || OSVersion.Version.Minor >= 1)
                {
                    directxMajorVersion = 11;
                }
                // if Windows Vista
                else
                {
                    directxMajorVersion = 10;
                }
            }
            // if Windows XP or earlier.
            else
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\DirectX"))
                {
                    string versionStr = key.GetValue("Version") as string;
                    if (!string.IsNullOrEmpty(versionStr))
                    {
                        var versionComponents = versionStr.Split('.');
                        if (versionComponents.Length > 1)
                        {
                            int directXLevel;
                            if (int.TryParse(versionComponents[1], out directXLevel))
                            {
                                directxMajorVersion = directXLevel;
                            }
                        }
                    }
                }
            }

            return directxMajorVersion;
        }
    }
}
