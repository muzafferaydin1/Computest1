namespace SalajansBoyaMusteri.PanelForms
{
    partial class RaporDosyalariOnizle
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
            this.btnraporyazdir = new System.Windows.Forms.Button();
            this.pbonizleme = new System.Windows.Forms.PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnTumRaporlar = new System.Windows.Forms.Button();
            this.pnControls = new System.Windows.Forms.Panel();
            this.btnetiketyazdir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbonizleme)).BeginInit();
            this.SuspendLayout();
            // 
            // btnraporyazdir
            // 
            this.btnraporyazdir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnraporyazdir.BackColor = System.Drawing.Color.Teal;
            this.btnraporyazdir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnraporyazdir.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnraporyazdir.ForeColor = System.Drawing.Color.White;
            this.btnraporyazdir.Image = global::SalajansBoyaMusteri.Properties.Resources.print24;
            this.btnraporyazdir.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnraporyazdir.Location = new System.Drawing.Point(803, 609);
            this.btnraporyazdir.Name = "btnraporyazdir";
            this.btnraporyazdir.Size = new System.Drawing.Size(250, 36);
            this.btnraporyazdir.TabIndex = 24;
            this.btnraporyazdir.Text = "Ön İzleme Raporu Yazdır";
            this.btnraporyazdir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnraporyazdir.UseVisualStyleBackColor = false;
            this.btnraporyazdir.Click += new System.EventHandler(this.btnraporyazdir_Click);
            // 
            // pbonizleme
            // 
            this.pbonizleme.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbonizleme.Location = new System.Drawing.Point(679, 41);
            this.pbonizleme.Name = "pbonizleme";
            this.pbonizleme.Size = new System.Drawing.Size(374, 553);
            this.pbonizleme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbonizleme.TabIndex = 23;
            this.pbonizleme.TabStop = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnTumRaporlar
            // 
            this.btnTumRaporlar.BackColor = System.Drawing.Color.Tomato;
            this.btnTumRaporlar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTumRaporlar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnTumRaporlar.ForeColor = System.Drawing.Color.White;
            this.btnTumRaporlar.Image = global::SalajansBoyaMusteri.Properties.Resources.print24;
            this.btnTumRaporlar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnTumRaporlar.Location = new System.Drawing.Point(374, 609);
            this.btnTumRaporlar.Name = "btnTumRaporlar";
            this.btnTumRaporlar.Size = new System.Drawing.Size(218, 36);
            this.btnTumRaporlar.TabIndex = 25;
            this.btnTumRaporlar.Text = "Tüm Raporları Yazdır";
            this.btnTumRaporlar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTumRaporlar.UseVisualStyleBackColor = false;
            this.btnTumRaporlar.Click += new System.EventHandler(this.btnTumRaporlar_Click);
            // 
            // pnControls
            // 
            this.pnControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnControls.AutoScroll = true;
            this.pnControls.BackColor = System.Drawing.Color.White;
            this.pnControls.Location = new System.Drawing.Point(12, 41);
            this.pnControls.Name = "pnControls";
            this.pnControls.Size = new System.Drawing.Size(580, 553);
            this.pnControls.TabIndex = 19;
            // 
            // btnetiketyazdir
            // 
            this.btnetiketyazdir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnetiketyazdir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnetiketyazdir.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnetiketyazdir.ForeColor = System.Drawing.Color.White;
            this.btnetiketyazdir.Image = global::SalajansBoyaMusteri.Properties.Resources.print24;
            this.btnetiketyazdir.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnetiketyazdir.Location = new System.Drawing.Point(12, 609);
            this.btnetiketyazdir.Name = "btnetiketyazdir";
            this.btnetiketyazdir.Size = new System.Drawing.Size(218, 36);
            this.btnetiketyazdir.TabIndex = 26;
            this.btnetiketyazdir.Text = "Barkod Etiketi Yazdır";
            this.btnetiketyazdir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnetiketyazdir.UseVisualStyleBackColor = false;
            this.btnetiketyazdir.Click += new System.EventHandler(this.btnetiketyazdir_Click);
            // 
            // RaporDosyalariOnizle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 670);
            this.Controls.Add(this.btnetiketyazdir);
            this.Controls.Add(this.btnTumRaporlar);
            this.Controls.Add(this.btnraporyazdir);
            this.Controls.Add(this.pbonizleme);
            this.Controls.Add(this.pnControls);
            this.Name = "RaporDosyalariOnizle";
            this.Text = "Rapor Dosyası";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RaporDosyalariOnizle_FormClosing);
            this.Load += new System.EventHandler(this.RaporDosyalariOnizle_Load);
            this.Leave += new System.EventHandler(this.RaporDosyalariOnizle_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pbonizleme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbonizleme;
        private System.Windows.Forms.Button btnraporyazdir;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnTumRaporlar;
        private System.Windows.Forms.Panel pnControls;
        private System.Windows.Forms.Button btnetiketyazdir;
    }
}