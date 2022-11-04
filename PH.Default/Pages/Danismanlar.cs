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
    public partial class Danismanlar : DevExpress.XtraEditors.XtraForm
    {
        public Danismanlar()
        {
            InitializeComponent();
        }

        Core _s;
        private void Danismanlar_Load(object sender, EventArgs e)
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

            GRC.DataSource = _s.GetDataTable(@"SELECT * FROM Danismanlar");
            GRW.Columns["Id"].Visible = false;
            GRW.Columns["Kodu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            GRW.Columns["Kodu"].SummaryItem.DisplayFormat = "{0}";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Modals.DanismanForm danisman = new Modals.DanismanForm();
            danisman.ShowDialog();
            LoadData();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (GRW.DataRowCount <= 0) return;
            Modals.DanismanForm danisman = new Modals.DanismanForm();
            danisman.GelenId = Convert.ToInt32(GRW.GetFocusedDataRow()["Id"]);
            danisman.ShowDialog();
            LoadData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (GRW.DataRowCount <= 0) return;
            Modals.IzinForm izin = new Modals.IzinForm();
            izin.DanismanId = Convert.ToInt32(GRW.GetFocusedDataRow()["Id"]);
            izin.ShowDialog();
            LoadData();
        }
    }
}