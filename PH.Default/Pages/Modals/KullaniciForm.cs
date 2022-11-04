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

namespace PH.Default.Pages.Modals
{
    public partial class KullaniciForm : DevExpress.XtraEditors.XtraForm
    {
        public KullaniciForm()
        {
            InitializeComponent();
        }
        Core _s;
        public int GelenId { get; set; }
        private void txtKullaniciAdi_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void KullaniciForm_Load(object sender, EventArgs e)
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
            if (GelenId > 0)
            {
                DataTable danisman = _s.GetDataTable("SELECT * FROM Kullanicilar WHERE Id=" + GelenId);
                txtKullaniciAdi.Text = danisman.Rows[0]["KullaniciAdi"].ToString();
                txtSifre.Text = danisman.Rows[0]["Sifre"].ToString();

                chkAracYonetim.Checked = (bool)danisman.Rows[0]["MusteriYonetim"];
                chkAramaYonetim.Checked = (bool)danisman.Rows[0]["AramaYonetim"];
                chkAyarYonetim.Checked = (bool)danisman.Rows[0]["AyarYonetim"];
                chkRandevuYonetim.Checked = (bool)danisman.Rows[0]["RandevuYonetim"];
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (txtKullaniciAdi.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Kullanıcı Adı Boş Olamaz!", "Dikkat",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSifre.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Şifre Boş Olamaz!", "Dikkat",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _s.ClearParameters();
            _s.AddParameters("@Id", GelenId);
            _s.AddParameters("@KullaniciAdi", txtKullaniciAdi.Text);
            _s.AddParameters("@Sifre", txtSifre.Text);
            _s.AddParameters("@MusteriYonetim", chkAracYonetim.Checked);
            _s.AddParameters("@AramaYonetim",chkAramaYonetim.Checked);
            _s.AddParameters("@AyarYonetim", chkAyarYonetim.Checked);
            _s.AddParameters("@RandevuYonetim", chkRandevuYonetim.Checked);

            string _q = "INSERT INTO Kullanicilar (KullaniciAdi,Sifre,MusteriYonetim,AramaYonetim,AyarYonetim,RandevuYonetim) VALUES (@KullaniciAdi,@Sifre,@MusteriYonetim,@AramaYonetim,@AyarYonetim,@RandevuYonetim)";
            if (GelenId > 0)
                _q = "UPDATE Kullanicilar SET KullaniciAdi=@KullaniciAdi,Sifre=@Sifre,MusteriYonetim=@MusteriYonetim,AramaYonetim=@AramaYonetim,AyarYonetim=@AyarYonetim,RandevuYonetim=@RandevuYonetim  WHERE Id=@Id";

            if (_s.CmdExecute(_q) > 0)
            {
                XtraMessageBox.Show("Kayıt Başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                XtraMessageBox.Show(Core.GetError(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}