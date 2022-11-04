using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
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
    public partial class Randevular : DevExpress.XtraEditors.XtraForm
    {
        public Randevular()
        {
            InitializeComponent();
        }
        Core _s;
        private void Randevular_Load(object sender, EventArgs e)
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
            //dt1.DateTime = new DateTime(2022, DateTime.Now.Month, 1);
            //dt2.DateTime = new DateTime(2022, DateTime.Now.Month,
            //    new DateTime(2022, DateTime.Now.AddMonths(1).Month, 1).AddDays(-1).Day);

            DataTable _tDanisman = _s.GetDataTable("SELECT Id,Kodu,Unvani,Renk FROM Danismanlar   ");

            int _loc = 31;
            foreach (DataRow item in _tDanisman.Rows)
            {
                CheckButton button = new CheckButton();

                button.Name = "chk" + item["Kodu"].ToString();
                button.Tag = (int)item["Id"];

                button.Appearance.BackColor = GetColor((int)item["Renk"]);
                button.Width = chkTemplate.Width;
                button.Height = chkTemplate.Height;
                button.Cursor = chkTemplate.Cursor;
                button.CheckedChanged += new System.EventHandler(chkTemplate_CheckedChanged);
                button.ImageOptions.Image = chkTemplate.ImageOptions.Image;
                button.Text = item["Unvani"].ToString();
                _loc += 169;
                button.Location = new Point(_loc, 12);

                panelControl1.Controls.Add(button);

            }


            LoadData();
        }

        Color GetColor(int renk)
        {
            Color c = Color.White;
            switch (renk)
            {
                case 1:
                    c = Color.FromArgb(255, 194, 190);
                    break;
                case 2:
                    c = Color.FromArgb(168, 213, 255);
                    break;
                case 3:
                    c = Color.FromArgb(193, 244, 156);
                    break;
                case 4:
                    c = Color.FromArgb(243, 228, 199);
                    break;
                case 5:
                    c = Color.FromArgb(244, 206, 147);
                    break;
                case 6:
                    c = Color.FromArgb(199, 244, 255);
                    break;
                case 7:
                    c = Color.FromArgb(207, 219, 152);
                    break;
                case 8:
                    c = Color.FromArgb(224, 207, 233);
                    break;
                case 9:
                    c = Color.FromArgb(141, 233, 223);
                    break;
                case 110:
                    c = Color.FromArgb(255, 247, 165);
                    break;

                default:
                    c = Color.White;
                    break;
            }
            return c;
        }

        void LoadData(int _danisman = 0)
        {

            schd.Start = DateTime.Now;

            AppointmentMappingInfo mappings = this.schdStore.Appointments.Mappings;
            mappings.Start = "BaslangicTarih";
            mappings.End = "BitisTarih";
            mappings.Location = "IlgiliKisi";
            mappings.Subject = "Konusu";
            mappings.AppointmentId = "Id";
            mappings.Description = "Turu";
            mappings.Label = "Label";
            mappings.ResourceId = "DanismanId";

            ResourceMappingInfo mappingInfo = this.schdStore.Resources.Mappings;
            mappingInfo.Id = "Id";
            mappingInfo.Caption = "Unvani";

         


            string _f = "";
            if (_danisman > 0)
                _f = " WHERE dbo.Danismanlar.Id=" + _danisman;

            //schd.DayView.ShowMoreButtonsOnEachColumn = true;
            //schd.DayView.ShowNumbersInMoreButtons = true;
            //schd.DayView.ShowDayNumberInAllDayArea = DevExpress.Utils.DefaultBoolean.True;
            //schd.DayView.ShowDayHeaders = false;
            //schd.DayView.ShowAllDayArea = false;
            schd.ActiveViewType = SchedulerViewType.Day;

            //schd.DayView.DayCount = 1;

            schdStore.Resources.DataSource = _s.GetDataTable("SELECT * FROM Danismanlar");

            schdStore.Appointments.DataSource = _s.GetDataTable(@"SELECT      
DATEADD(day, DATEDIFF(day, 0, dbo.Randevular.Tarih), dbo.GetTimeString(dbo.Randevular.Saat)) AS BaslangicTarih, 
DATEADD(day, DATEDIFF(day, 0, dbo.Randevular.Tarih), dbo.GetTimeString(dbo.Randevular.Saat+60)) AS BitisTarih, 
						 dbo.Musteriler.Unvani AS IlgiliKisi, 
						 dbo.RandevuNedenleri.Tanimi AS Turu, 
						 dbo.Danismanlar.Unvani AS Detayi, dbo.Araclar.Plaka AS Konusu, 
                         dbo.Randevular.Id, dbo.Randevular.RandevuNedenId AS Label,dbo.Danismanlar.Id AS DanismanId
FROM            dbo.Randevular INNER JOIN
                         dbo.Danismanlar ON dbo.Randevular.DanismanId = dbo.Danismanlar.Id INNER JOIN 
                         dbo.Araclar ON dbo.Randevular.AracId = dbo.Araclar.Id INNER JOIN
						 dbo.Musteriler ON dbo.Araclar.MusteriId = dbo.Musteriler.Id INNER JOIN
                         dbo.RandevuNedenleri ON dbo.Randevular.RandevuNedenId = dbo.RandevuNedenleri.Id " + _f);

            //this.schdStore.Appointments.ResourceSharing = true;
            this.schd.GroupType = SchedulerGroupType.Resource;
            schd.DayView.ShowDayHeaders = false;
            schd.DataStorage = schdStore; 
            //schd.CustomAppointmentGroup += CustomAppointmentGroup;
            //bool shouldShowRightRuler = false ;
            //UpdateRulers(shouldShowRightRuler);
            //schd.Refresh();
        }
        void UpdateRulers(bool shouldShowRightRuler)
        {
            int timeRulersCount = this.schd.DayView.TimeRulers.Count;
            for (int i = 0; i < timeRulersCount; i++)
            {
                TimeRuler timeRuler = this.schd.DayView.TimeRulers[i];
                if (timeRuler.HorizontalAlignment == TimeRulerHorizontalAlignment.Far)
                    timeRuler.Visible = shouldShowRightRuler;
            }
        }
        void CustomAppointmentGroup(object sender, CustomAppointmentGroupEventArgs e)
        {
            e.GroupKey = (int)e.AppointmentLayoutInfo.Appointment.LabelKey;
        }

        private void günlükToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schd.ActiveViewType = SchedulerViewType.Day;
        }

        private void haftalıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schd.ActiveViewType = SchedulerViewType.Week;
        }

        private void aylıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schd.ActiveViewType = SchedulerViewType.Month;
        }

        private void yıllıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schd.ActiveViewType = SchedulerViewType.Year;
        }

        private void randevuOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modals.RandevuForm _randevu = new Modals.RandevuForm();
            _randevu.Tarih = schd.ActiveView.SelectedInterval.Start;

            _randevu.ShowDialog();
            LoadData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Modals.RandevuForm _randevu = new Modals.RandevuForm();
            _randevu.ShowDialog();
            LoadData();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void seçilenRandevuyuDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modals.RandevuForm _randevu = new Modals.RandevuForm();
            _randevu.ShowDialog();

            LoadData();
        }

        private void schd_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            e.Handled = true;
            if (schd.SelectedAppointments.Count == 0) return;
            Modals.RandevuForm _rf = new Modals.RandevuForm();
            _rf.RandevuId = (int)schd.SelectedAppointments[0].GetValue(schdStore, "Id");
    
            _rf.ShowDialog();
            LoadData();
        }

        int _secilenOperator = 0;
        private void chkTemplate_CheckedChanged(object sender, EventArgs e)
        {


            CheckButton button = (CheckButton)sender;

            if (!button.Checked)
            {
                return;
            }
            else
            {
                if (button.Tag == null)
                {
                    _secilenOperator = 0;
                    LoadData();
                }
                else
                {
                    _secilenOperator = (int)button.Tag;
                    LoadData(_secilenOperator);
                }
            }

            foreach (Control item in panelControl1.Controls)
            {
                CheckButton checkButton = (CheckButton)item;
                if (checkButton.Name != button.Name)
                    checkButton.Checked = false;

            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadData(_secilenOperator);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        { 
        }

        private void ekranYenilemesiniDurdurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = ekranYenilemesiniDurdurToolStripMenuItem.Text != "Ekran Yenilemesini Durdur";

            if (timer1.Enabled)
                ekranYenilemesiniDurdurToolStripMenuItem.Text = "Ekran Yenilemesini Durdur";
            else
                ekranYenilemesiniDurdurToolStripMenuItem.Text = "Ekran Yenilemesini Aç";
        }
    }
}