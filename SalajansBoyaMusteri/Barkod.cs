using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalajansBoyaMusteri
{
    public partial class Barkod : Form
    {
        public Barkod()
        {
            InitializeComponent();
        }

        private void Barkod_Load(object sender, EventArgs e)
        {
         
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
             
           

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text.Length==10)
            {
                DBEntities db = new DBEntities();

                var kayit = db.TBL_MUSTERILER.FirstOrDefault(x => x.BarkodNo == textBox1.Text);
                MessageBox.Show(kayit.AliciAdsoyad + " " + kayit.AliciTelefon);
                textBox1.Text = "";

            }
        }
    }
}
