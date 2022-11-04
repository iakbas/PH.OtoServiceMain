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
    public partial class Aramalar : DevExpress.XtraEditors.XtraForm
    {
        public Aramalar()
        {
            InitializeComponent();
        }
        Core _s;
        private void Aramalar_Load(object sender, EventArgs e)
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
            dt1.DateTime = new DateTime(2022, DateTime.Now.Month, 1);
            dt2.DateTime = new DateTime(2022, DateTime.Now.Month, 
                new DateTime(2022, DateTime.Now.AddMonths(1).Month ,1).AddDays(-1).Day );

            LoadData();
        }

        void LoadData()
        {
            GRC.DataSource = _s.GetDataTable(@"SELECT 
                                    Detay.Id AS AramaId, Arac.SasiNo, Arac.Plaka, Arac.Marka, Arac.Model, Arac.SonServisTarihi,Arac.TrafigeCikis,
                                    Musteri.Unvani, Musteri.Telefon1, Musteri.Telefon2, Kullanici.KullaniciAdi AS Operator,
                                    Detay.Tarih, dbo.GetTimeString(Detay.Saat) as Saat, Dosya.Tanimi AS DosyaDurumu, Sonuc.Tanimi AS Sonuc,Detay.Aciklama 
                                    FROM   Araclar AS Arac  
                                    INNER JOIN Musteriler AS Musteri ON Musteri.Id = Arac.MusteriId
                                    INNER JOIN AramaDetaylari AS Detay ON Detay.AracId = Arac.Id
                                    INNER JOIN Sonuclar AS Sonuc ON Sonuc.Id = Detay.Sonuc
                                    INNER JOIN DosyaDurumlari AS Dosya ON Dosya.Id = Detay.DosyaDurumu 
                                      LEFT JOIN Kullanicilar AS Kullanici ON Kullanici.Id = Detay.OperatorId 
                                    WHERE Detay.Tarih BETWEEN '" + 
                                    dt1.DateTime.ToString("yyyyMMdd") + "' AND '" +
                                    dt2.DateTime.ToString("yyyyMMdd") + "'");
             
            GRW.Columns["AramaId"].Visible = false;
            GRW.Columns["SasiNo"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            GRW.Columns["SasiNo"].SummaryItem.DisplayFormat = "{0}";
        }

        private void GRW_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (GRW.DataRowCount == 0) GRC.ContextMenuStrip = contextMenuStrip1;
            else
           if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                GRC.ContextMenuStrip = contextMenuStrip1;
            else
                GRC.ContextMenuStrip = null;
        }

        private void yeniEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modals.AramaForm arama = new Modals.AramaForm();
            arama.ShowDialog();
            LoadData();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GRW.DataRowCount <= 0) return;

            Modals.AramaForm arama = new Modals.AramaForm(); 
            arama.DetayId = Convert.ToInt32(GRW.GetFocusedDataRow()["AramaId"].ToString());
            arama.ShowDialog();
            LoadData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //LoadData();
        }
    }
}