using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalajansBoyaMusteri.PanelForms.Ayarlar
{
    public partial class GuncellemeMerkezi : Form
    {
        public GuncellemeMerkezi()
        {
            InitializeComponent();
        }

        private void GuncellemeMerkezi_Load(object sender, EventArgs e)
        {

        }
        private void startDownload()
        {
            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri("http://www.saltur.com.tr/salturservice2.rar"), Application.StartupPath+"\\Update\\1.exe");
            });
            thread.Start();
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
               
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
                label2.Text = "%"+progressBar1.Value+" Toplam:" + e.BytesReceived + " of " + e.TotalBytesToReceive;
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                label2.Text = "Güncelleme Tamamlandı.";
            });
        }

        private void btnguncellemeindir_Click(object sender, EventArgs e)
        {
            label2.Text = "Programınız güncel.";
            // startDownload();
        }
    }
}
