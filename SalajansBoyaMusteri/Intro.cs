using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalajansBoyaMusteri
{
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }
        DBEntities db = new DBEntities();
        private void Intro_Load(object sender, EventArgs e)
        {
            try
            {
                 
              

                timer3.Interval = 1000;
                timer3.Start();

            }
            catch (Exception)
            {

                MessageBox.Show("Bağlantı kurulamadı !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         }


    private void pictureBox1_Click(object sender, EventArgs e)
    {

    }

    private void timer2_Tick(object sender, EventArgs e)
    {




    }

    private void timer3_Tick(object sender, EventArgs e)
    {



        this.Close();
        timer3.Stop();
        Form1 FRM = new Form1();
        FRM.Show();



    }
}
}
