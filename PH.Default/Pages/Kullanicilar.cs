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
    public partial class Kullanicilar : DevExpress.XtraEditors.XtraForm
    {
        public Kullanicilar()
        {
            InitializeComponent();
        }
        Core _s;
        private void Kullanicilar_Load(object sender, EventArgs e)
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
            LoadData();
        }

        void LoadData()
        {

            GRC.DataSource = _s.GetDataTable(@" SELECT Id, KullaniciAdi,
CASE WHEN MusteriYonetim = 1 THEN 'Evet' ELSE 'Hayır' END AS 'AracForm',
CASE WHEN AramaYonetim = 1 THEN 'Evet' ELSE 'Hayır' END AS 'AramaForm',
CASE WHEN RandevuYonetim = 1 THEN 'Evet' ELSE 'Hayır' END AS 'RandevuForm',
CASE WHEN AyarYonetim = 1 THEN 'Evet' ELSE 'Hayır' END AS 'AyarForm'
FROM Kullanicilar");
            GRW.Columns["Id"].Visible = false;
            GRW.Columns["KullaniciAdi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            GRW.Columns["KullaniciAdi"].SummaryItem.DisplayFormat = "{0}";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Modals.KullaniciForm kullanici = new Modals.KullaniciForm();
            kullanici.ShowDialog();
            LoadData();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Modals.KullaniciForm kullanici = new Modals.KullaniciForm();
            kullanici.GelenId = Convert.ToInt32(GRW.GetFocusedDataRow()["Id"]);
            kullanici.ShowDialog();
            LoadData();
        }
    }
}