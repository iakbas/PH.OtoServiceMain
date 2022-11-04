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
    public partial class RandevuForm : DevExpress.XtraEditors.XtraForm
    {
        public RandevuForm()
        {
            InitializeComponent();
        }
        Core _s;
        public int RandevuId { get; set; }
        public DateTime Tarih { get; set; }
        public int AracId { get; set; }
        private void RandevuForm_Load(object sender, EventArgs e)
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

            dtRandevuTarihi.DateTime = Tarih;
            //dtRandevuSaati.DateTime = DateTime.Now;

            cmbSaat.Text = DateTime.Now.ToString("HH");
            cmbDakika.Text = "00";

            cmbAracLook.Properties.DataSource = _s.GetDataTable(@"SELECT A.Id,SasiNo,Plaka,Marka,Model,AracTanimi,
CASE WHEN A.Durum = 1 THEN 'Aktif' ELSE 'Pasif' END Durum, M.Unvani FROM Araclar AS A INNER JOIN
Musteriler AS M ON M.Id = A.MusteriId");

            cmbAracLook.Properties.ValueMember = "Id";
            cmbAracLook.Properties.DisplayMember = "Plaka";


            cmbRandevuNedeniLook.Properties.DataSource = _s.GetDataTable("SELECT Id,Kodu,Tanimi FROM RandevuNedenleri WHERE Aktif=1 ");
            cmbRandevuNedeniLook.Properties.ValueMember = "Id";
            cmbRandevuNedeniLook.Properties.DisplayMember = "Tanimi";


            cmbDurumLook.Properties.DataSource = _s.GetDataTable("SELECT Id,Kodu,Tanimi FROM RandevuDurumlari WHERE Aktif=1 ");
            cmbDurumLook.Properties.ValueMember = "Id";
            cmbDurumLook.Properties.DisplayMember = "Tanimi";



            if (AracId > 0)
                cmbAracLook.EditValue = AracId;


            if (RandevuId > 0)
            {

                DataTable _randevu = _s.GetDataTable("SELECT *,K.KullaniciAdi FROM Randevular AS Randevu LEFT JOIN Kullanicilar AS K ON K.Id=Randevu.OperatorId WHERE Randevu.Id=" + RandevuId.ToString());

              


                cmbDurumLook.EditValue = Convert.ToInt32(_randevu.Rows[0]["RandevuSonucId"].ToString());
                cmbAracLook.EditValue = Convert.ToInt32(_randevu.Rows[0]["AracId"].ToString());
                dtRandevuTarihi.DateTime = Convert.ToDateTime(_randevu.Rows[0]["Tarih"].ToString());
                dtSonrakiServisTarihi.DateTime = Convert.ToDateTime(_randevu.Rows[0]["SonrakiServisTarihi"].ToString());
                //dtRandevuSaati.EditValue = Converter.IntToTime((int)_randevu.Rows[0]["Saat"]);
                string _saat = ((int)_randevu.Rows[0]["Saat"] / 60).ToString();
                string _dakika = ((int)_randevu.Rows[0]["Saat"] % 60).ToString();

                cmbSaat.Text = _saat.Length==1 ? "0"+_saat : _saat;
                cmbDakika.Text= _dakika.Length == 1 ? "0" + _dakika : _dakika;

                cmbRandevuNedeniLook.EditValue = Convert.ToInt32(_randevu.Rows[0]["RandevuNedenId"].ToString());
                cmbDanismanLook.EditValue = Convert.ToInt32(_randevu.Rows[0]["DanismanId"].ToString());
                txtRandevuyuAlan.Text = _randevu.Rows[0]["KullaniciAdi"].ToString();
                txtAciklama.Text = _randevu.Rows[0]["Aciklama"].ToString();
                
               txtGorusulenKisi.Text = _randevu.Rows[0]["GorusulenKisi"].ToString();
                txtTelefon.Text = _randevu.Rows[0]["Telefon"].ToString();

                cmbDanismanLook.Properties.DataSource = _s.GetDataTable("SELECT Id,Kodu,Unvani FROM Danismanlar WHERE Id Not In " +
                                         "   (SELECT DanismanId FROM Randevular WHERE DanismanId<>" + _randevu.Rows[0]["DanismanId"].ToString() + " AND Tarih = '" + dtRandevuTarihi.DateTime.ToString("yyyyMMdd")
                                         + "' AND Saat BETWEEN " + _randevu.Rows[0]["Saat"] + " AND " + ((int)_randevu.Rows[0]["Saat"] + 30) + ") ");
                cmbDanismanLook.Properties.ValueMember = "Id";
                cmbDanismanLook.Properties.DisplayMember = "Unvani";
            }
            else
            {
                txtRandevuyuAlan.Text = Login.KullaniciAdi;
                int _saat = Converter.TimeToInt(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());

                if (_saat > 0)
                {
 
                        int _fark = (_saat % 60) % 30;
                      
                        if (_fark > 30)
                            _saat += (30 - _fark);
                        else
                            _saat -= _fark;
                         
                }

                cmbDanismanLook.Properties.DataSource = _s.GetDataTable("SELECT Id,Kodu,Unvani FROM Danismanlar WHERE Id Not In " +
                                            "   (SELECT DanismanId FROM Randevular WHERE Tarih = '" + dtRandevuTarihi.DateTime.ToString("yyyyMMdd")
                                            + "' AND Saat BETWEEN " + _saat + " AND " + (_saat +30 )+ ") ");
                cmbDanismanLook.Properties.ValueMember = "Id";
                cmbDanismanLook.Properties.DisplayMember = "Unvani";

            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cmbAracLook.Text == "")
            { XtraMessageBox.Show("Müşteri Aracı Seçimi Yapmalısınız!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (cmbDanismanLook.Text == "")
            { XtraMessageBox.Show("Danışman Seçimi Yapmalısınız!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (cmbRandevuNedeniLook.Text == "")
            { XtraMessageBox.Show("Randevu Nedeni Seçimi Yapmalısınız!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            _s.ClearParameters();
            _s.AddParameters("@Id", RandevuId);
            _s.AddParameters("@AracId", (int)(((DataRowView)cmbAracLook.GetSelectedDataRow()).Row["Id"]));
            _s.AddParameters("@Tarih", dtRandevuTarihi.DateTime);
            _s.AddParameters("@SonrakiServisTarihi", dtSonrakiServisTarihi.DateTime);

            int _saat = Convert.ToInt32(cmbSaat.Text) * 60;
            int _dakika= Convert.ToInt32(cmbDakika.Text);

            _s.AddParameters("@Saat", _saat+_dakika); 
            _s.AddParameters("@RandevuNedenId", (int)(((DataRowView)cmbRandevuNedeniLook.GetSelectedDataRow()).Row["Id"]));
            _s.AddParameters("@DanismanId", (int)(((DataRowView)cmbDanismanLook.GetSelectedDataRow()).Row["Id"])); 
            _s.AddParameters("@Aciklama", txtAciklama.Text);
            _s.AddParameters("@GorusulenKisi", txtGorusulenKisi.Text);
            _s.AddParameters("@Telefon", txtTelefon.Text);
            _s.AddParameters("@OperatorId", Login.OperatorId);

            _s.AddParameters("@RandevuSonucId", (int)(((DataRowView)cmbDurumLook.GetSelectedDataRow()).Row["Id"]));

            string _q = "INSERT INTO Randevular (AracId,Tarih,Saat, RandevuSonucId, RandevuNedenId, Aciklama,DanismanId,SonrakiServisTarihi,GorusulenKisi,Telefon,OperatorId ) " +
                "VALUES (@AracId,@Tarih,@Saat, @RandevuSonucId, @RandevuNedenId, @Aciklama,@DanismanId,@SonrakiServisTarihi ,@GorusulenKisi,@Telefon,@OperatorId)";
            if (RandevuId > 0)
                _q = "UPDATE Randevular SET AracId=@AracId," +
                    "Tarih=@Tarih," +
                    "Saat=@Saat," +
                      "DanismanId=@DanismanId," +
                    "RandevuNedenId=@RandevuNedenId," +
                     "GorusulenKisi=@GorusulenKisi," +
                           "RandevuSonucId=@RandevuSonucId," +
                    "Telefon=@Telefon," + 
                     "SonrakiServisTarihi=@SonrakiServisTarihi," + 
                    "Aciklama=@Aciklama  WHERE Id=@Id";

            if (_s.CmdExecute(_q) > 0)
            {
                XtraMessageBox.Show("Kayıt Başarılı", "Başarılı", MessageBoxButtons.OK, icon: MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                XtraMessageBox.Show(Core.GetError());
                return;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            DataTable _tMusteri = _s.GetDataTable("SELECT Telefon1 FROM Musteriler WHERE Id=" + (int)(((DataRowView)cmbAracLook.GetSelectedDataRow()).Row["MusteriId"]));
            if (_tMusteri.Rows[0][0].ToString() == "")
            {
                XtraMessageBox.Show("Seçilen Müşteriye Ait Telefon Numarası bulunamadı!", "Dikkat", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }
            Netgsm.Netgsm _net = new Netgsm.Netgsm();

            _net.SetUsercode(Main.sms.KullaniciAdi);
            _net.SetPassword(Main.sms.Sifre);
            Netgsm.Netgsm.XML mL = _net.Sms(Main.sms.SmsBaslik, _tMusteri.Rows[0][0].ToString(), dtRandevuTarihi.DateTime.ToString("dd.MM.yyyy") + " " + cmbSaat.Text + ":" + cmbDakika.Text + " tarihinde randevunuz oluşturulmuştur.");
            if (Convert.ToInt32(mL.Main.JobID) > 102)
            {
                XtraMessageBox.Show("Sms Başarılı : " + mL.Main.JobID, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                XtraMessageBox.Show("Sms Başarısız : " + mL.Main.JobID, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dtRandevuTarihi_EditValueChanged(object sender, EventArgs e)
        {
            dtSonrakiServisTarihi.DateTime = dtRandevuTarihi.DateTime.AddMonths(10);
        }

        private void dtRandevuSaati_EditValueChanged(object sender, EventArgs e)
        {
            if (RandevuId > 0)
            {
                int _saat = Convert.ToInt32(cmbSaat.Text) * 60;
                int _dakika = Convert.ToInt32(cmbDakika);
                DataTable _randevu = _s.GetDataTable("SELECT * FROM Randevular WHERE Id=" + RandevuId.ToString());

                cmbDanismanLook.Properties.DataSource = _s.GetDataTable("SELECT Id,Kodu,Unvani FROM Danismanlar WHERE Id Not In " +
                                           "   (SELECT DanismanId FROM Randevular WHERE DanismanId<>" + _randevu.Rows[0]["DanismanId"].ToString() + " AND Tarih = '" + dtRandevuTarihi.DateTime.ToString("yyyyMMdd")
                                           + "' AND Saat BETWEEN " + (_saat + _dakika) + " AND " + (_saat + _dakika + 60) + ") ");
                cmbDanismanLook.Properties.ValueMember = "Id";
                cmbDanismanLook.Properties.DisplayMember = "Unvani";
                 

            }
            else
            {
                int _saat = Convert.ToInt32(cmbSaat.Text) * 60;
                int _dakika = Convert.ToInt32(cmbDakika);
                cmbDanismanLook.Properties.DataSource = _s.GetDataTable("SELECT Id,Kodu,Unvani FROM Danismanlar WHERE Id Not In " +
                                            "   (SELECT DanismanId FROM Randevular WHERE Tarih = '" + dtRandevuTarihi.DateTime.ToString("yyyyMMdd")
                                            + "' AND Saat BETWEEN " + (_saat + _dakika) + " AND " + (_saat + _dakika + 60) + ") ");
                cmbDanismanLook.Properties.ValueMember = "Id";
                cmbDanismanLook.Properties.DisplayMember = "Unvani";

            }
        }

        private void cmbAracLook_EditValueChanged(object sender, EventArgs e)
        {
            DataRowView _r = (DataRowView)cmbAracLook.GetSelectedDataRow();
            if (_r == null) return;
            txtMarka.Text = _r["Marka"].ToString();
            txtModel.Text = _r["Model"].ToString();
            txtMusteri.Text = _r["Unvani"].ToString();
            txtPlaka.Text = _r["Plaka"].ToString();
            txtSasiNo.Text = _r["SasiNo"].ToString();
        }

        private void cmbAracLook_QueryPopUp(object sender, CancelEventArgs e)
        {

            GridLookUpEdit _lokk = (GridLookUpEdit)sender;

            _lokk.Properties.View.Columns["Id"].Visible = false;
            _lokk.Properties.View.Columns["Durum"].Visible = false;
            _lokk.Properties.View.Columns["AracTanimi"].Visible = false;
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSaat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}