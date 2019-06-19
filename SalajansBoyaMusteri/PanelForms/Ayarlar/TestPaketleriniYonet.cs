using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace SalajansBoyaMusteri.PanelForms
{
    public partial class TestPaketleriniYonet : Form
    {
        public TestPaketleriniYonet()
        {
            InitializeComponent();
        }
        DBEntities db = new DBEntities();


        private void TestPaketleriniYonet_Load(object sender, EventArgs e)
        {
            PaketListesi();
        }
        private void btneklemeyitamamla_Click(object sender, EventArgs e)
        {


            if (txtPaketAdi.Text.Trim() != "")
            {
                int testsecilimi = clistTestler.CheckedItems.Count;

                if (testsecilimi > 0)
                {
                    int paketadikontrol = db.Paketler.Where(x => x.PaketAdi == txtPaketAdi.Text).ToList().Count;
                    if (paketadikontrol == 0)
                    {
                        Paketler p = new Paketler();
                        p.PaketAdi = txtPaketAdi.Text;
                        p.PaketAktifMi = true;
                        p.PaketiOlusturan = KullaniciveFirmaBilgileri.KullaniciAdSoyad;
                        p.PaketOlusturmaTarihi = DateTime.Now;
                        p.PaketIcerik = "";
                        foreach (var item in clistTestler.CheckedItems)
                        {
                            if (p.PaketIcerik == "")
                            {
                                p.PaketIcerik = item.ToString();
                            }
                            else
                            {
                                p.PaketIcerik += "," + item.ToString();
                            }
                        }
                        var paketicerikkontrol = db.Paketler.FirstOrDefault(x => x.PaketIcerik == p.PaketIcerik);
                        if (paketicerikkontrol != null)
                        {
                            string yanit = paketicerikkontrol.PaketAdi + " adlı paket ile aynı içeriğe sahip !";
                            MessageBox.Show(yanit, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            db.Paketler.Add(p);
                            db.SaveChanges();
                            MessageBox.Show("Paket ekleme işleminiz tamamlandı.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PaketListesi();
                        }


                    }
                    else
                    {
                        MessageBox.Show("Girdiğiniz isim ile aynı paket mevcut.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("En az 1 tane test seçilmelidir.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Paket adı boş bırakılamaz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void PaketListesi()
        {

            listeklipaketler.DataSource = db.Paketler.Select(x => new { x.PaketID, x.PaketAdi }).ToList();
            listeklipaketler.DisplayMember = "PaketAdi";
            listeklipaketler.ValueMember = "PaketID";
        }





        private void listeklipaketler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                txtPaketAdi.Text = listeklipaketler.GetItemText(listeklipaketler.SelectedItem).ToString();

                for (int i = 0; i < clistTestler.Items.Count; i++)
                {
                    clistTestler.SetItemChecked(i, false);
                }
                int paketid = 0;
                paketid = listeklipaketler.GetItemText(listeklipaketler.SelectedValue).Toint58();
                if (paketid == -111)
                {
                    paketid = db.Paketler.FirstOrDefault().PaketID;
                }
                if (paketid != -111)
                {
                    string[] icerik = db.Paketler.FirstOrDefault(x => x.PaketID == paketid).PaketIcerik.Split(',');

                    for (int i = 0; i < clistTestler.Items.Count; i++)
                    {
                        foreach (var item in icerik)
                        {
                            if ((string)clistTestler.Items[i] == item)
                            {
                                clistTestler.SetItemChecked(i, true);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void btnpaketguncelle_Click(object sender, EventArgs e)
        {
            int paketid = listeklipaketler.GetItemText(listeklipaketler.SelectedValue).Toint58();
            var paket = db.Paketler.FirstOrDefault(x => x.PaketID == paketid);
            string secilipaketler = string.Empty;

            var texts = clistTestler.CheckedItems.Cast<object>().Select(x => this.clistTestler.GetItemText(x));
            foreach (var item in texts)
            {
                if (secilipaketler == string.Empty)
                {
                    secilipaketler = item;
                }
                else
                {
                    secilipaketler += "," + item;
                }
            }
            if (secilipaketler == string.Empty)
            {
                MessageBox.Show("En az 1 tane test seçilmelidir.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                var paketicerikkontrol = db.Paketler.FirstOrDefault(x => x.PaketAdi == txtPaketAdi.Text && x.PaketID != paketid);
                if (paketicerikkontrol != null)
                {
                    string yanit = paketicerikkontrol.PaketAdi + " adlı paket ile aynı içeriğe sahip !";
                    MessageBox.Show(yanit, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (txtPaketAdi.Text.Trim() == "" && paketicerikkontrol == null)
                {
                    MessageBox.Show("Paket adı boş bırakılamaz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult dresult = MessageBox.Show("Paket güncelleme işlemine devam edilsin mi ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dresult == DialogResult.Yes)
                    {
                        paket.PaketIcerik = secilipaketler;
                        paket.PaketOlusturmaTarihi = DateTime.Now;
                        paket.PaketAdi = txtPaketAdi.Text;
                        db.SaveChanges();
                        MessageBox.Show("Paket güncelleme işleminiz tamamlandı.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PaketListesi();
                    }
                }
            }


        }

        private void btnpaketsil_Click(object sender, EventArgs e)
        {

            DialogResult dresult = MessageBox.Show("Paket silme işlemine devam edilsin mi ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dresult == DialogResult.Yes)
            {
                int paketsayisi = db.Paketler.ToList().Count();
                if (paketsayisi > 1)
                {
                    int paketid = listeklipaketler.GetItemText(listeklipaketler.SelectedValue).Toint58();
                    var paket = db.Paketler.FirstOrDefault(x => x.PaketID == paketid);
                    db.Paketler.Remove(paket);
                    db.SaveChanges();
                    MessageBox.Show("Paket silme işleminiz tamamlandı.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PaketListesi();
                }
                else
                {
                    MessageBox.Show("En az 1 paket ekli olmalıdır.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
