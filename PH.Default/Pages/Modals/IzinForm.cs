using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using PH.Data;
using PH.Default.Config;
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
    public partial class IzinForm : DevExpress.XtraEditors.XtraForm
    {
        public IzinForm()
        {
            InitializeComponent();
        }
        Core _s;

        public int DanismanId { get; set; }
        public int IzinId { get; set; }
        private void IzinForm_Load(object sender, EventArgs e)
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
            dt1.DateTime = DateTime.Now;
            ds1.DateTime = DateTime.Now;
            dt2.DateTime = DateTime.Now;
            ds2.DateTime = DateTime.Now.AddHours(2);

            if (IzinId > 0)
            {
                DataTable table = _s.GetDataTable("SELECT * FROM DanismanIzinleri WHERE Id=" + IzinId);
                if (table.Rows.Count > 0)
                {

                    dt1.DateTime = (DateTime)table.Rows[0]["BaslangicTarihi"];

                    dt1.EditValue = Converter.IntToTime((int)table.Rows[0]["BaslangicSaati"]);
                    dt2.DateTime = (DateTime)table.Rows[0]["BitisTarihi"];

                    dt2.EditValue = Converter.IntToTime((int)table.Rows[0]["BitisSaati"]);
                    txtAciklama.Text = table.Rows[0]["Aciklama"].ToString();
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            if (dt1.Text == "")
            {
                XtraMessageBox.Show("Başlangıç Tarihi Boş Olamaz", "Dikkat", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }

            _s.ClearParameters();

            if (IzinId > 0)
                _s.AddParameters("@Id", IzinId);

            _s.AddParameters("@DanismanId", DanismanId);
            _s.AddParameters("@BaslangicTarihi", dt1.DateTime);

            if (dt2.Text != "")
                _s.AddParameters("@BitisTarihi", dt2.DateTime);
            else
                _s.AddParameters("@BitisTarihi", dt1.DateTime);


            _s.AddParameters("@BaslangicSaati", Converter.TimeToInt(ds1.Text));
            _s.AddParameters("@BitisSaati", Converter.TimeToInt(ds2.Text));
            _s.AddParameters("@Aciklama", txtAciklama.Text.Trim());

            string _q = "INSERT INTO DanismanIzinleri (DanismanId,BaslangicTarihi,BaslangicSaati,BitisTarihi,BitisSaati,Aciklama) VALUES " +
                " (@DanismanId,@BaslangicTarihi,@BaslangicSaati,@BitisTarihi,@BitisSaati,@Aciklama)";
            if (IzinId > 0)
                _q = "UPDATE DanismanIzinleri SET " +
                    "DanismanId=@DanismanId," +
                    "BaslangicTarihi=@BaslangicTarihi," +
                    "BaslangicSaati=@BaslangicSaati," +
                    "BitisTarihi=@BitisTarihi," +
                    "BitisSaati=@BitisSaati," +
                    "Aciklama=@Aciklama " +
                    "WHERE Id=@Id";

            if (_s.CmdExecute(_q) > 0)
            {
                XtraMessageBox.Show("Kayıt Başarılı", "Başarılı", MessageBoxButtons.OK, icon: MessageBoxIcon.Asterisk);
            }
            else
            {
                XtraMessageBox.Show(Core.GetError());
                return;
            }
            this.Close();
        }
    }
}