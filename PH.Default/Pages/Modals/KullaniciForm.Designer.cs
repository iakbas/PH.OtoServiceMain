namespace PH.Default.Pages.Modals
{
    partial class KullaniciForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciForm));
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.chkAracYonetim = new DevExpress.XtraEditors.CheckEdit();
            this.chkAramaYonetim = new DevExpress.XtraEditors.CheckEdit();
            this.chkRandevuYonetim = new DevExpress.XtraEditors.CheckEdit();
            this.chkAyarYonetim = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAracYonetim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAramaYonetim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRandevuYonetim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAyarYonetim.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(103, 21);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(234, 20);
            this.txtKullaniciAdi.TabIndex = 44;
            this.txtKullaniciAdi.EditValueChanged += new System.EventHandler(this.txtKullaniciAdi_EditValueChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.simpleButton3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 177);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(388, 33);
            this.panelControl1.TabIndex = 43;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(503, -62);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Text = "Kaydet";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(42, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 47;
            this.labelControl1.Text = "Kullanıcı Adı";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(301, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(42, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 13);
            this.labelControl2.TabIndex = 49;
            this.labelControl2.Text = "Şifre";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(103, 47);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(234, 20);
            this.txtSifre.TabIndex = 48;
            // 
            // chkAracYonetim
            // 
            this.chkAracYonetim.Location = new System.Drawing.Point(103, 73);
            this.chkAracYonetim.Name = "chkAracYonetim";
            this.chkAracYonetim.Properties.Caption = "Araç Yönetim";
            this.chkAracYonetim.Size = new System.Drawing.Size(127, 20);
            this.chkAracYonetim.TabIndex = 50;
            // 
            // chkAramaYonetim
            // 
            this.chkAramaYonetim.Location = new System.Drawing.Point(103, 99);
            this.chkAramaYonetim.Name = "chkAramaYonetim";
            this.chkAramaYonetim.Properties.Caption = "Arama Yönetimi";
            this.chkAramaYonetim.Size = new System.Drawing.Size(127, 20);
            this.chkAramaYonetim.TabIndex = 51;
            // 
            // chkRandevuYonetim
            // 
            this.chkRandevuYonetim.Location = new System.Drawing.Point(103, 125);
            this.chkRandevuYonetim.Name = "chkRandevuYonetim";
            this.chkRandevuYonetim.Properties.Caption = "Randevu Yönetimi";
            this.chkRandevuYonetim.Size = new System.Drawing.Size(127, 20);
            this.chkRandevuYonetim.TabIndex = 52;
            // 
            // chkAyarYonetim
            // 
            this.chkAyarYonetim.Location = new System.Drawing.Point(103, 151);
            this.chkAyarYonetim.Name = "chkAyarYonetim";
            this.chkAyarYonetim.Properties.Caption = "Ayar Yönetimi";
            this.chkAyarYonetim.Size = new System.Drawing.Size(127, 20);
            this.chkAyarYonetim.TabIndex = 53;
            // 
            // KullaniciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 210);
            this.Controls.Add(this.chkAyarYonetim);
            this.Controls.Add(this.chkRandevuYonetim);
            this.Controls.Add(this.chkAramaYonetim);
            this.Controls.Add(this.chkAracYonetim);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.panelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KullaniciForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KullaniciForm";
            this.Load += new System.EventHandler(this.KullaniciForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAracYonetim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAramaYonetim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRandevuYonetim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAyarYonetim.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.CheckEdit chkAracYonetim;
        private DevExpress.XtraEditors.CheckEdit chkAramaYonetim;
        private DevExpress.XtraEditors.CheckEdit chkRandevuYonetim;
        private DevExpress.XtraEditors.CheckEdit chkAyarYonetim;
    }
}