using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using PH.Config;
using PH.Crypt;
using PH.Data;
using PH.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PH.Default.Extentions
{
    public partial class Settings : DevExpress.XtraEditors.XtraForm
    {
        public Settings()
        {
            InitializeComponent();
            BaglantiTesti = false;
            b = new System.Data.SqlClient.SqlConnectionStringBuilder();
        }
        private bool BaglantiTesti { get; set; }
        System.Data.SqlClient.SqlConnectionStringBuilder b;

        private void Settings_Load(object sender, EventArgs e)
        {
            b = new System.Data.SqlClient.SqlConnectionStringBuilder();
            ReaderCore _r = new ReaderCore();
            b = _r.GetCnnStr();
            if (b != null)
            {
                txtSunucu.Text = b.DataSource;
                txtVeritabani.Text = b.InitialCatalog;
                txtKullaniciAdi.Text = b.UserID;
                txtSifre.Text = b.Password;
                cmbTip.SelectedIndex = b.IntegratedSecurity ? 0 : 1;
            }

            Config.SettingsReader _reader = new Config.SettingsReader();

            SmsSettings sms = _reader.ReadSettings();

            if (sms != null)
            {
                txtSmsKullaniciAdi.Text = sms.KullaniciAdi;
                txtSmsSifre.Text = sms.Sifre;
                txtEmail.Text = sms.EMail;
                txtEndpoint.Text = sms.Endpoint;
                txtSmsBaslik.Text = sms.SmsBaslik;
                _kayitOlustugunda = sms.KayitOlustugunda;
                _randevuOlustugunda = sms.RandevuOlustugunda;
                _randevuDegistiginde = sms.RandevuDegistiginde;
            }

            
            if (_kayitOlustugunda == 1)
                cmbSecenekler.Properties.Items[0].CheckState = CheckState.Checked;
            if (_randevuOlustugunda == 1)
                cmbSecenekler.Properties.Items[1].CheckState = CheckState.Checked;
            if (_randevuDegistiginde == 1)
                cmbSecenekler.Properties.Items[2].CheckState = CheckState.Checked;

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            b = new System.Data.SqlClient.SqlConnectionStringBuilder();

            b.DataSource = txtSunucu.Text.Trim();
            b.InitialCatalog = txtVeritabani.Text.Trim();

            if (cmbTip.SelectedIndex == 0)
                b.IntegratedSecurity = true;
            else
            {
                b.UserID = txtKullaniciAdi.Text.Trim();
                b.Password = txtSifre.Text.Trim();
            }
            b.ConnectTimeout = 30;
            b.TrustServerCertificate = true;

            SplashScreenManager.ShowForm(
                 splashFormType: typeof(Extentions.Splash), throwExceptionIfAlreadyOpened: false, parentForm: this, useFadeIn: true, useFadeOut: true);

            Core _e = Core.NesneOlustur(b.ConnectionString);
            if (_e != null)
            {
                if (_e.PMainCnn != null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Bağlantı Başarılı", "Başarılı",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                    BaglantiTesti = true;

                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Bağlantı Başarısız " + Environment.NewLine + Environment.NewLine
                         +"Hata Bilgisi" + Core.GetError(), "Hata ",
                         System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                    BaglantiTesti = false;

                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bağlantı Başarısız " + Environment.NewLine + Environment.NewLine
                        + "Hata Bilgisi" + Core.GetError(), "Hata ",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                BaglantiTesti = false;

            }

            SplashScreenManager.CloseForm();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (BaglantiTesti)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"cnn.ini"))
                {
                    b.Password = EnCrypt.Encrypt(b.Password, "ibr123*");
                    file.WriteLine(b.ConnectionString);

                    XtraMessageBox.Show("Kayıt Başarılı ", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bağlantı Testi Yapmadan Kaydetmek İstiyor musunuz?", "Dikkat",
                    System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                    return;
                else
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"cnn.ini"))
                    {
                        b.Password = EnCrypt.Encrypt(b.Password, "ibr123*");
                        file.WriteLine(b.ConnectionString);

                        XtraMessageBox.Show("Kayıt Başarılı ", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                }
            }

            this.Close();
        }

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTip.SelectedIndex == 0)
            {
                txtKullaniciAdi.Enabled = false;
                txtSifre.Enabled = false;
            }
            else
            {
                txtKullaniciAdi.Enabled = true;
                txtSifre.Enabled = true;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Netgsm.Netgsm _net = new Netgsm.Netgsm();

            _net.SetUsercode(txtSmsKullaniciAdi.Text);
            _net.SetPassword(txtSmsSifre.Text);
            Netgsm.Netgsm.XML mL= _net.Sms(txtSmsBaslik.Text, txtTestNo.Text, "Deneme SMS");


            if (Convert.ToInt32(mL.Main.JobID) > 102)
            {
                XtraMessageBox.Show("Test Başarılı : " + mL.Main.JobID, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                XtraMessageBox.Show("Test Başarısız : " + mL.Main.JobID,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        int _kayitOlustugunda = 0;
        int _randevuOlustugunda = 0;
        int _randevuDegistiginde = 0;
        private void simpleButton5_Click(object sender, EventArgs e)
        {

            foreach (CheckedListBoxItem item in cmbSecenekler.Properties.Items)
            {
                if (item.CheckState == CheckState.Unchecked) continue;
                if (Convert.ToInt32(item.Value.ToString()) == 1)
                    _kayitOlustugunda = 1;
                if (Convert.ToInt32(item.Value.ToString()) == 2)
                    _randevuOlustugunda = 1;
                if (Convert.ToInt32(item.Value.ToString()) == 3)
                    _randevuDegistiginde = 1;

            }
            StreamWriter writer = new StreamWriter(Application.StartupPath + @"\SMS.ini");

            writer.WriteLine("KullaniciAdi = " + txtSmsKullaniciAdi.Text);
            writer.WriteLine("Sifre = " +  EnCrypt.Encrypt(txtSmsSifre.Text, "iAYazilim1@./*"));
            writer.WriteLine("EMail = " + txtEmail.Text);
            writer.WriteLine("EndPoint = " + txtEndpoint.Text);
            writer.WriteLine("SMS Baslik = " + txtSmsBaslik.Text);
            writer.WriteLine("Kayıt Oluşturulduğunda = " + _kayitOlustugunda);
            writer.WriteLine("Randevu Oluşturulduğunda = " + _randevuOlustugunda);
            writer.WriteLine("Randevu Değiştirildiğinde = " + _randevuDegistiginde);
            writer.Dispose();
            writer.Close();

            XtraMessageBox.Show("Kayıt Başarılı " , "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}