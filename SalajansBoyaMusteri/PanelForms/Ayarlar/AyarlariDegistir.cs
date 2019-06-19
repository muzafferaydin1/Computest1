using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalajansBoyaMusteri.PanelForms.Ayarlar
{
    public partial class AyarlariDegistir : Form
    {
        public AyarlariDegistir()
        {
            InitializeComponent();
        }

        private void btnpaketyonetimi_Click(object sender, EventArgs e)
        {
          
            p.Controls.Clear();
            TestPaketleriniYonet newForm = new TestPaketleriniYonet();
            newForm.TopLevel = false;
            p.Controls.Add(newForm);
            newForm.Show();
            newForm.Dock = DockStyle.Top;
            newForm.BringToFront();

        }

        private void btngmerkezi_Click(object sender, EventArgs e)
        {
            p.Controls.Clear();
            GuncellemeMerkezi newForm = new GuncellemeMerkezi();
            newForm.TopLevel = false;
            p.Controls.Add(newForm);
            newForm.Show();
            newForm.Dock = DockStyle.Top;
            newForm.BringToFront();
        }

        private void btngenelbilgiler_Click(object sender, EventArgs e)
        {
            p.Controls.Clear();
            GenelBilgiler newForm = new GenelBilgiler();
            newForm.TopLevel = false;
            p.Controls.Add(newForm);
            newForm.Show();
            newForm.Dock = DockStyle.Top;
            newForm.BringToFront();
        }

        private void btnaygityonetimi_Click(object sender, EventArgs e)
        {
            p.Controls.Clear();
            AygitlariYonet newForm = new AygitlariYonet();
            newForm.TopLevel = false;
            p.Controls.Add(newForm);
            newForm.Show();
            newForm.Dock = DockStyle.Top;
            newForm.BringToFront();
        }

        private void AyarlariDegistir_Load(object sender, EventArgs e)
        {
            btngenelbilgiler.PerformClick();
        }

       
    }
}
