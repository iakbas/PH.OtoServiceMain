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
    public partial class AramaForm : DevExpress.XtraEditors.XtraForm
    {
        public AramaForm()
        {
            InitializeComponent();
        }
        Core _s;

        public int DetayId { get; set; }
         

        public int AracId { get; set; }
        private void AramaForm_Load(object sender, EventArgs e)
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

            dtAramaTarihi.DateTime = DateTime.Now;
            dtAramaSaati.DateTime = DateTime.Now;

            cmbAracLook.Properties.DataSource = _s.GetDataTable(@"SELECT A.Id,SasiNo,Plaka,Marka,Model,AracTanimi,
CASE WHEN A.Durum = 1 THEN 'Aktif' ELSE 'Pasif' END Durum, M.Unvani FROM Araclar AS A INNER JOIN
Musteriler AS M ON M.Id = A.MusteriId");

          


            cmbAracLook.Properties.ValueMember = "Id";
            cmbAracLook.Properties.DisplayMember = "Plaka";

            cmbDosyaDurum.Properties.DataSource = _s.GetDataTable("SELECT Id,Kodu,Tanimi FROM DosyaDurumlari WHERE Aktif=1 ");
            cmbDosyaDurum.Properties.ValueMember = "Id";
            cmbDosyaDurum.Properties.DisplayMember = "Tanimi";

            cmbSonuc.Properties.DataSource = _s.GetDataTable("SELECT Id,Kodu,Tanimi FROM Sonuclar WHERE Aktif=1 ");
            cmbSonuc.Properties.ValueMember = "Id";
            cmbSonuc.Properties.DisplayMember = "Tanimi";

            if (AracId > 0)
                cmbAracLook.EditValue = AracId;

            if (DetayId > 0)
            {
                DataTable _aramaTable = _s.GetDataTable(@"SELECT  *,Kullanici.KullaniciAdi FROM AramaDetaylari AS Arama  
                    LEFT JOIN Kullanicilar AS Kullanici ON Kullanici.Id = Arama.OperatorId WHERE Arama.Id=" + DetayId.ToString());

                cmbAracLook.EditValue = (int)_aramaTable.Rows[0]["AracId"];
                cmbDosyaDurum.EditValue = (int)_aramaTable.Rows[0]["DosyaDurumu"];
                cmbSonuc.EditValue = (int)_aramaTable.Rows[0]["Sonuc"];
                txtKm.EditValue = (int)_aramaTable.Rows[0]["OrtalamaKm"];
                cmbTeklifVerildiMi.SelectedIndex = (bool)_aramaTable.Rows[0]["TeklifVerildi"] ? 1 : 0;
                cmbRandevuAlindiMi.SelectedIndex = (bool)_aramaTable.Rows[0]["RandevuAlindi"] ? 1 : 0;
                cmbBaskaServisMi.SelectedIndex = (bool)_aramaTable.Rows[0]["BaskaServis"] ? 1 : 0;
                if (_aramaTable.Rows[0]["AramaHatirlatmaTarihi"].ToString() != "")
                    dtTeklifHatirlatma.DateTime = (DateTime)_aramaTable.Rows[0]["AramaHatirlatmaTarihi"];

                txtAciklama.Text = _aramaTable.Rows[0]["Aciklama"].ToString();
                txtGorusulenKisi.Text = _aramaTable.Rows[0]["GorusulenKisi"].ToString();
                txtTelefoNo.Text = _aramaTable.Rows[0]["Telefon"].ToString();
                txtAramaYapan.Text = _aramaTable.Rows[0]["KullaniciAdi"].ToString();

                if (_aramaTable.Rows[0]["Tarih"].ToString() != "")
                {
                    dtAramaTarihi.DateTime = (DateTime)_aramaTable.Rows[0]["Tarih"];

                    dtAramaSaati.EditValue = Converter.IntToTime((int)_aramaTable.Rows[0]["Saat"]);
                }
            }
            else
                txtAramaYapan.Text = Login.KullaniciAdi;
        }

        private void cmbBaskaServisMi_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkYetkili.Enabled = cmbBaskaServisMi.SelectedIndex == 1;
        }

        private void cmbTeklifVerildiMi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFiyat.Enabled = cmbTeklifVerildiMi.SelectedIndex == 1;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cmbAracLook.Text == "")
            { XtraMessageBox.Show("Müşteri Aracı Seçimi Yapmalısınız!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (cmbSonuc.Text == "")
            { XtraMessageBox.Show("Sonuç Seçimi Yapmalısınız!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (cmbDosyaDurum.Text == "")
            { XtraMessageBox.Show("Dosya Durumu Seçimi Yapmalısınız!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }


         
            _s.ClearParameters();
            _s.AddParameters("@Id", DetayId);
            _s.AddParameters("@TeklifVerildi", cmbTeklifVerildiMi.SelectedIndex == 1);
            if (dtTeklifHatirlatma.Text != "")
                _s.AddParameters("@AramaHatirlatmaTarihi", dtTeklifHatirlatma.DateTime);
            else
                _s.AddParameters("@AramaHatirlatmaTarihi", DBNull.Value);

            _s.AddParameters("@Fiyat", txtFiyat.Text.Replace(',', '.'));
            _s.AddParameters("@RandevuAlindi", cmbRandevuAlindiMi.SelectedIndex == 1);
            _s.AddParameters("@BaskaServis", cmbBaskaServisMi.SelectedIndex == 1);
            _s.AddParameters("@BaskaServisYetkiliMi", chkYetkili.Checked);
            _s.AddParameters("@AracId", (int)(((DataRowView)cmbAracLook.GetSelectedDataRow()).Row["Id"]));
            _s.AddParameters("@Sonuc", (int)(((DataRowView)cmbSonuc.GetSelectedDataRow()).Row["Id"]));
            _s.AddParameters("@DosyaDurumu", (int)(((DataRowView)cmbDosyaDurum.GetSelectedDataRow()).Row["Id"]));
            _s.AddParameters("@Tarih", dtAramaTarihi.DateTime);
            _s.AddParameters("@Saat", Converter.TimeToInt(dtAramaSaati.Text));
            _s.AddParameters("@Aciklama", txtAciklama.Text);
            _s.AddParameters("@OrtalamaKm", Convert.ToInt32(txtKm.Text));
            _s.AddParameters("@OperatorId", Login.OperatorId);
            _s.AddParameters("@GorusulenKisi", txtGorusulenKisi.Text);
            _s.AddParameters("@Telefon", txtTelefoNo.Text);


            string   _q = "INSERT INTO AramaDetaylari (TeklifVerildi,AramaHatirlatmaTarihi,Fiyat,RandevuAlindi,BaskaServis,BaskaServisYetkiliMi,AracId,Sonuc,DosyaDurumu,Tarih,Saat,Aciklama,GorusulenKisi,Telefon,OrtalamaKm,OperatorId" +
                ") VALUES (@TeklifVerildi,@AramaHatirlatmaTarihi,@Fiyat,@RandevuAlindi,@BaskaServis,@BaskaServisYetkiliMi,@AracId,@Sonuc,@DosyaDurumu,@Tarih,@Saat,@Aciklama,@GorusulenKisi,@Telefon,@OrtalamaKm,@OperatorId)";
            if (DetayId > 0)
                _q = "UPDATE AramaDetaylari SET " +
                    "TeklifVerildi=@TeklifVerildi," +
                    "AramaHatirlatmaTarihi=@AramaHatirlatmaTarihi," +
                    "Fiyat=@Fiyat," +
                    "RandevuAlindi=@RandevuAlindi," +
                    "BaskaServis=@BaskaServis," +
                    "BaskaServisYetkiliMi=@BaskaServisYetkiliMi," +
                    "AracId=@AracId," +
                    "Sonuc=@Sonuc," +
                    "DosyaDurumu=@DosyaDurumu," +
                     "GorusulenKisi=@GorusulenKisi," +
                      "Telefon=@Telefon," +
                    "Tarih=@Tarih," +
                    "Saat=@Saat," +
                       "OrtalamaKm=@OrtalamaKm," + 
                    "Aciklama=@Aciklama WHERE Id=@Id";

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

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (!Login.RandevularYetki)
            {
                XtraMessageBox.Show("Bu İşlemi Yapma Yetkiniz Bulunmamaktadır!", "Dikkat", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }
            RandevuForm randevuForm = new RandevuForm();
            randevuForm.AracId = (int)(((DataRowView)cmbAracLook.GetSelectedDataRow()).Row["Id"]);
            randevuForm.Tarih = DateTime.Now;
            randevuForm.ShowDialog();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

        }

        private void cmbAracLook_EditValueChanged(object sender, EventArgs e)
        {
            DataRowView _r = (DataRowView)cmbAracLook.GetSelectedDataRow();
            if (_r == null) return;
            txtMarka.Text = _r["Marka"].ToString();
            txtModel.Text = _r["Model"].ToString();
            txtMusteri.Text= _r["Unvani"].ToString();
            txtPlaka.Text= _r["Plaka"].ToString();
            txtSasiNo.Text = _r["SasiNo"].ToString();
        }

        private void cmbAracLook_QueryCloseUp(object sender, CancelEventArgs e)
        {

        }

        private void cmbAracLook_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit _lokk = (GridLookUpEdit)sender;

            _lokk.Properties.View.Columns["Id"].Visible = false;
            _lokk.Properties.View.Columns["Durum"].Visible = false;
            _lokk.Properties.View.Columns["AracTanimi"].Visible = false;

        }
    }
}