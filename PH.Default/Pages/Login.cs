using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using PH.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PH.Default.Pages
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }
        Core _s;
        public static int OperatorId { get; set; }
        public static string KullaniciAdi { get; set; }
        public static bool AraclarYetki { get; set; }
        public static bool AramalarYetki { get; set; }
        public static bool RandevularYetki { get; set; }
        public static  bool AyarlarYetki { get; set; }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Kullanıcı Adı Boş Olamaz!", "Dikkat", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }
            if (txtSifre.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Şifre Boş Olamaz!", "Dikkat", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }

            DataTable _t = _s.GetDataTable("SELECT * FROM Kullanicilar WHERE KullaniciAdi='" + txtKullaniciAdi.Text.Trim() + "' AND Sifre='" + txtSifre.Text.Trim() + "'");
            if (_t.Rows.Count > 0) {

                KullaniciAdi = _t.Rows[0][1].ToString() ;
                OperatorId = Convert.ToInt32(_t.Rows[0][0].ToString());
                AraclarYetki = (bool)_t.Rows[0]["MusteriYonetim"];
                AramalarYetki= (bool)_t.Rows[0]["AramaYonetim"];
                RandevularYetki = (bool)_t.Rows[0]["RandevuYonetim"];
                AyarlarYetki = (bool)_t.Rows[0]["AyarYonetim"];
                _giris = true;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Kullanıcı Adı yada Şifre Hatalı!", "Dikkat", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
            }

        }
        bool _giris = false;
        private void Login_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(
              splashFormType: typeof(Extentions.Splash), throwExceptionIfAlreadyOpened: false, parentForm: this, useFadeIn: true, useFadeOut: true);
            _s = Core.NesneOlustur();
            SplashScreenManager.CloseForm(false);
            if (_s == null)
            {
                Extentions.Settings settings = new Extentions.Settings();
                settings.ShowDialog();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
         
              
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_giris) Application.Exit();
        }
    }
}