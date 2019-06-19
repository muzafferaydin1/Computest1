namespace SalajansBoyaMusteri.PanelForms
{
    partial class TestPaketleriniYonet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clistTestler = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaketAdi = new System.Windows.Forms.TextBox();
            this.btneklemeyitamamla = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listeklipaketler = new System.Windows.Forms.ListBox();
            this.btnpaketguncelle = new System.Windows.Forms.Button();
            this.btnpaketsil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clistTestler
            // 
            this.clistTestler.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.clistTestler.FormattingEnabled = true;
            this.clistTestler.Items.AddRange(new object[] {
            "Boya/Değişen",
            "Şasi Kontrol",
            "Ön Düzen",
            "Fren",
            "Süspansiyon",
            "Motor",
            "Şanzıman",
            "Dış Aydınlatma",
            "Donanım",
            "Elektrik",
            "Resimler"});
            this.clistTestler.Location = new System.Drawing.Point(429, 120);
            this.clistTestler.MultiColumn = true;
            this.clistTestler.Name = "clistTestler";
            this.clistTestler.Size = new System.Drawing.Size(332, 232);
            this.clistTestler.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F);
            this.label1.Location = new System.Drawing.Point(426, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hangi testleri içeriyor ?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F);
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Paket için isim giriniz:";
            // 
            // txtPaketAdi
            // 
            this.txtPaketAdi.Font = new System.Drawing.Font("Calibri", 10F);
            this.txtPaketAdi.Location = new System.Drawing.Point(15, 44);
            this.txtPaketAdi.MaxLength = 50;
            this.txtPaketAdi.Name = "txtPaketAdi";
            this.txtPaketAdi.Size = new System.Drawing.Size(332, 24);
            this.txtPaketAdi.TabIndex = 4;
            // 
            // btneklemeyitamamla
            // 
            this.btneklemeyitamamla.BackColor = System.Drawing.Color.DarkCyan;
            this.btneklemeyitamamla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneklemeyitamamla.ForeColor = System.Drawing.Color.White;
            this.btneklemeyitamamla.Location = new System.Drawing.Point(15, 355);
            this.btneklemeyitamamla.Name = "btneklemeyitamamla";
            this.btneklemeyitamamla.Size = new System.Drawing.Size(128, 35);
            this.btneklemeyitamamla.TabIndex = 5;
            this.btneklemeyitamamla.Text = "Paket Ekle";
            this.btneklemeyitamamla.UseVisualStyleBackColor = false;
            this.btneklemeyitamamla.Click += new System.EventHandler(this.btneklemeyitamamla_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F);
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Paket seçiniz";
            // 
            // listeklipaketler
            // 
            this.listeklipaketler.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.listeklipaketler.FormattingEnabled = true;
            this.listeklipaketler.ItemHeight = 15;
            this.listeklipaketler.Location = new System.Drawing.Point(15, 120);
            this.listeklipaketler.Name = "listeklipaketler";
            this.listeklipaketler.Size = new System.Drawing.Size(332, 229);
            this.listeklipaketler.TabIndex = 10;
            this.listeklipaketler.SelectedIndexChanged += new System.EventHandler(this.listeklipaketler_SelectedIndexChanged);
            // 
            // btnpaketguncelle
            // 
            this.btnpaketguncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnpaketguncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpaketguncelle.ForeColor = System.Drawing.Color.White;
            this.btnpaketguncelle.Location = new System.Drawing.Point(219, 355);
            this.btnpaketguncelle.Name = "btnpaketguncelle";
            this.btnpaketguncelle.Size = new System.Drawing.Size(128, 35);
            this.btnpaketguncelle.TabIndex = 11;
            this.btnpaketguncelle.Text = "Güncelle";
            this.btnpaketguncelle.UseVisualStyleBackColor = false;
            this.btnpaketguncelle.Click += new System.EventHandler(this.btnpaketguncelle_Click);
            // 
            // btnpaketsil
            // 
            this.btnpaketsil.BackColor = System.Drawing.Color.DarkRed;
            this.btnpaketsil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpaketsil.ForeColor = System.Drawing.Color.White;
            this.btnpaketsil.Location = new System.Drawing.Point(681, 85);
            this.btnpaketsil.Name = "btnpaketsil";
            this.btnpaketsil.Size = new System.Drawing.Size(80, 29);
            this.btnpaketsil.TabIndex = 12;
            this.btnpaketsil.Text = "Sil";
            this.btnpaketsil.UseVisualStyleBackColor = false;
            this.btnpaketsil.Click += new System.EventHandler(this.btnpaketsil_Click);
            // 
            // TestPaketleriniYonet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1156, 402);
            this.Controls.Add(this.btnpaketsil);
            this.Controls.Add(this.btnpaketguncelle);
            this.Controls.Add(this.listeklipaketler);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btneklemeyitamamla);
            this.Controls.Add(this.txtPaketAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clistTestler);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestPaketleriniYonet";
            this.Text = "TestPaketleriniYonet";
            this.Load += new System.EventHandler(this.TestPaketleriniYonet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clistTestler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPaketAdi;
        private System.Windows.Forms.Button btneklemeyitamamla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listeklipaketler;
        private System.Windows.Forms.Button btnpaketguncelle;
        private System.Windows.Forms.Button btnpaketsil;
    }
}