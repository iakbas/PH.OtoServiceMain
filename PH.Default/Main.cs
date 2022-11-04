using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using PH.Data;
using PH.Default.Pages;
using PH.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PH.Default
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Main()
        {
            InitializeComponent();
        }

        Core _s;
        public static SmsSettings sms { get; set; }
        private void Main_Load(object sender, EventArgs e)
        {

            Login login = new Login();
            login.ShowDialog();

            SplashScreenManager.ShowForm(
                splashFormType: typeof(Extentions.Splash), throwExceptionIfAlreadyOpened: false, parentForm: this, useFadeIn: true, useFadeOut: true);
            _s = Core.NesneOlustur();
            SplashScreenManager.CloseForm(false);
            if (_s == null)
            {
                Extentions.Settings settings = new Extentions.Settings();
                settings.ShowDialog();
            }
            else
                txtBaglanti.Caption = "Server:" + _s.PMainCnn.DataSource + ";Database:" + _s.PMainCnn.Database;

            if (!Login.AraclarYetki)
                btnAraclar.Visibility = BarItemVisibility.Never;
            if (!Login.AramalarYetki)
                btnAramalar.Visibility = BarItemVisibility.Never;
            if (!Login.RandevularYetki)
                btnRandevular.Visibility = BarItemVisibility.Never;
            if (!Login.AyarlarYetki)
                pageAyarlar.Visible = false;


            Config.SettingsReader _reader = new Config.SettingsReader();

            sms = _reader.ReadSettings();

            if (sms == null)
            {
                XtraMessageBox.Show("Sms Ayarları Yapılandırılmamış!");
                Extentions.Settings settings = new Extentions.Settings();
                settings.ShowDialog();
                sms = _reader.ReadSettings();
            }
            barButtonItem7_ItemClick(null, null);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Extentions.Settings settings = new Extentions.Settings();
            settings.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms.OfType<Pages.Araclar>().Count() > 0)
            {
                Application.OpenForms.OfType<Pages.Araclar>().ElementAt(0).Activate(); return;
            }
            SplashScreenManager.ShowForm(
               splashFormType: typeof(Extentions.Splash), throwExceptionIfAlreadyOpened: false, parentForm: this, useFadeIn: true, useFadeOut: true);
            Pages.Araclar frm = new Pages.Araclar()
            {
                Dock = DockStyle.Fill,
                MdiParent = this
            };
            frm.BringToFront(); frm.Show();
            SplashScreenManager.CloseForm(false);
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            Pages.Kullanicilar kullanicilar = new Pages.Kullanicilar();
            kullanicilar.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms.OfType<Pages.Aramalar>().Count() > 0)
            {
                Application.OpenForms.OfType<Pages.Aramalar>().ElementAt(0).Activate(); return;
            }
            SplashScreenManager.ShowForm(
               splashFormType: typeof(Extentions.Splash), throwExceptionIfAlreadyOpened: false, parentForm: this, useFadeIn: true, useFadeOut: true);
            Pages.Aramalar frm = new Pages.Aramalar()
            {
                Dock = DockStyle.Fill,
                MdiParent = this
            };
            frm.BringToFront(); frm.Show();
            SplashScreenManager.CloseForm(false);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms.OfType<Pages.Randevular>().Count() > 0)
            {
                Application.OpenForms.OfType<Pages.Randevular>().ElementAt(0).Activate(); return;
            }
            SplashScreenManager.ShowForm(
               splashFormType: typeof(Extentions.Splash), throwExceptionIfAlreadyOpened: false, parentForm: this, useFadeIn: true, useFadeOut: true);
            Pages.Randevular frm = new Pages.Randevular()
            {
                Dock = DockStyle.Fill,
                MdiParent = this
            };
            frm.BringToFront(); frm.Show();
            SplashScreenManager.CloseForm(false);
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms.OfType<Pages.Dashboard>().Count() > 0)
            {
                Application.OpenForms.OfType<Pages.Dashboard>().ElementAt(0).Activate(); return;
            }
            SplashScreenManager.ShowForm(
               splashFormType: typeof(Extentions.Splash), throwExceptionIfAlreadyOpened: false, parentForm: this, useFadeIn: true, useFadeOut: true);
            Pages.Dashboard frm = new Pages.Dashboard()
            {
                Dock = DockStyle.Fill,
                MdiParent = this
            };
            frm.BringToFront(); frm.Show();
            SplashScreenManager.CloseForm(false);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Pages.Danismanlar danismanlar = new Danismanlar();
            danismanlar.ShowDialog();
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Extentions.ExcelImport _ex = new Extentions.ExcelImport();
            _ex.ShowDialog();
        }
    }
}