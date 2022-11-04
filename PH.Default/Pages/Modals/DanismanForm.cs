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
    public partial class DanismanForm : DevExpress.XtraEditors.XtraForm
    {
        public DanismanForm()
        {
            InitializeComponent();
        }
        Core _s;
        public int GelenId { get; set; }
        private void DanismanForm_Load(object sender, EventArgs e)
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
                DataTable danisman = _s.GetDataTable("SELECT * FROM Danismanlar WHERE Id=" + GelenId);
                txtKodu.Text = danisman.Rows[0]["Kodu"].ToString();
                txtUnvani.Text = danisman.Rows[0]["Unvani"].ToString();
                if (danisman.Rows[0]["Renk"].ToString() != "")
                    cmbRenkSecim.EditValue = (int)danisman.Rows[0]["Renk"];
                LoadData();
            }
        }

        void LoadData()
        {
            GRC.DataSource = _s.GetDataTable(@"SELECT I.Id,I.BaslangicTarihi,
dbo.GetTimeString(I.BaslangicSaati) AS BaslangicSaati,
I.BitisTarihi, dbo.GetTimeString(I.BitisSaati) AS BitisSaati,
I.Aciklama FROM Danismanlar AS D
INNER JOIN DanismanIzinleri AS I ON D.Id = I.DanismanId ");
            GRW.Columns["Id"].Visible = false;
            GRW.Columns["BaslangicTarihi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            GRW.Columns["BaslangicTarihi"].SummaryItem.DisplayFormat = "{0}";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (txtKodu.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Kodu Boş Olamaz!", "Dikkat",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtUnvani.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Ünvanı Boş Olamaz!", "Dikkat",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _s.ClearParameters();
            _s.AddParameters("@Id", GelenId);
            _s.AddParameters("@Kodu", txtKodu.Text);
            _s.AddParameters("@Unvani", txtUnvani.Text);


            _s.AddParameters("@Renk", cmbRenkSecim.EditValue);

            string _q = "INSERT INTO Danismanlar (Kodu,Unvani,Renk) VALUES (@Kodu,@Unvani,@Renk)";
            if (GelenId > 0)
                _q = "UPDATE Danismanlar SET Kodu=@Kodu,Unvani=@Unvani,Renk=@Renk WHERE Id=@Id";

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

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if(e.Button.Properties.Caption=="Yeni İzin")
            {
                if (GelenId == 0)
                {
                    XtraMessageBox.Show("İzin Eklemek İçin Önce Danışman Eklemelisiniz!", "Dikkat", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                    return;
                }
                Modals.IzinForm izin = new Modals.IzinForm();
                izin.DanismanId = GelenId;
                izin.ShowDialog();
                LoadData();
            }
            if (e.Button.Properties.Caption == "Düzenle")
            {
                if (GRW.DataRowCount == 0)
                {
                    return;
                }
                if (GelenId == 0)
                {
                    XtraMessageBox.Show("İzin Eklemek İçin Önce Danışman Eklemelisiniz!", "Dikkat", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                    return;
                }
                Modals.IzinForm izin = new Modals.IzinForm();
                izin.DanismanId = GelenId;
                izin.IzinId= Convert.ToInt32(GRW.GetFocusedDataRow()["Id"]);
                izin.ShowDialog();
                LoadData();
            }
            if (e.Button.Properties.Caption == "İptal")
            {
                if (GRW.DataRowCount == 0)
                {
                    return;
                }
                DialogResult= XtraMessageBox.Show("İzin Kaydını İptal Etmek İstiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, icon: MessageBoxIcon.Warning);
                if (DialogResult == DialogResult.No) return;
                _s.CmdExecute("DELETE FROM DanismanIzinleri WHERE Id=" + Convert.ToInt32(GRW.GetFocusedDataRow()["Id"]));
                LoadData();

            }
        }
    }
}