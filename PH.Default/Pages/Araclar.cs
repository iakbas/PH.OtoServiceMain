using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using ExcelDataReader;
using PH.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PH.Default.Pages
{
    public partial class Araclar : DevExpress.XtraEditors.XtraForm
    {
        public Araclar()
        {
            InitializeComponent();
        }
        Core _s;
        private void Araclar_Load(object sender, EventArgs e)
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

            GRC.DataSource = _s.GetDataTable("SELECT Id,SasiNo,Plaka,Marka,Model,AracTanimi,CASE WHEN Durum=1 THEN 'Aktif' ELSE 'Pasif' END Durum FROM Araclar   ");
            GRW.Columns["Id"].Visible = false;
            GRW.Columns["SasiNo"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            GRW.Columns["SasiNo"].SummaryItem.DisplayFormat = "{0}";
        }
        void LoadARamalar()
        {
            GRCAramalar.DataSource = _s.GetDataTable(@"SELECT  Detay.Tarih, dbo.GetTimeString(Detay.Saat) as Saat,Dosya.Tanimi AS DosyaDurumu, 
                                    Sonuc.Tanimi AS Sonuc,Kullanici.KullaniciAdi AS Operator,
                                   
                                    Detay.Id AS AramaId
                                    
                                    FROM   Araclar  AS Arac
                                    INNER JOIN Musteriler AS Musteri ON Musteri.Id = Arac.MusteriId
                                    INNER JOIN AramaDetaylari AS Detay ON Detay.AracId = Arac.Id
                                    INNER JOIN Sonuclar AS Sonuc ON Sonuc.Id = Detay.Sonuc
                                    
                                    INNER JOIN DosyaDurumlari AS Dosya ON Dosya.Id = Detay.DosyaDurumu 
                                    LEFT JOIN Kullanicilar AS Kullanici ON Kullanici.Id = Detay.OperatorId WHERE Arac.MusteriId= " + lblMusteriId.Text + " ORDER BY  Detay.Tarih DESC");

            GRWAramalar.Columns["AramaId"].Visible = false;
            GRWAramalar.Columns["Tarih"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            GRWAramalar.Columns["Tarih"].SummaryItem.DisplayFormat = "{0}";

        }
        void LoadRandevular()
        {

            GRCRandevular.DataSource = _s.GetDataTable(@"SELECT        
DATEADD(day, DATEDIFF(day, 0, dbo.Randevular.Tarih), dbo.GetTimeString(dbo.Randevular.Saat)) AS BaslangicTarih,  
						 dbo.Musteriler.Unvani AS IlgiliKisi, 
						 dbo.RandevuNedenleri.Tanimi AS Turu, 
						 dbo.Danismanlar.Unvani AS Detayi, dbo.Araclar.SasiNo, 
                         Kullanici.KullaniciAdi AS Operator,dbo.Randevular.Id
FROM            dbo.Randevular INNER JOIN
                         dbo.Danismanlar ON dbo.Randevular.DanismanId = dbo.Danismanlar.Id INNER JOIN
                         
                         dbo.Araclar ON dbo.Randevular.AracId = dbo.Araclar.Id INNER JOIN
						 dbo.Musteriler ON dbo.Araclar.MusteriId = dbo.Musteriler.Id INNER JOIN
                         dbo.RandevuNedenleri ON dbo.Randevular.RandevuNedenId = dbo.RandevuNedenleri.Id
  LEFT JOIN Kullanicilar AS Kullanici ON Kullanici.Id =  dbo.Randevular.OperatorId WHERE dbo.Araclar.MusteriId= " + lblMusteriId.Text + " ORDER BY  dbo.Randevular.Tarih DESC");

            GRWRandevular.Columns["Id"].Visible = false;
            GRWRandevular.Columns["BaslangicTarih"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            GRWRandevular.Columns["BaslangicTarih"].SummaryItem.DisplayFormat = "{0}";

        }
        private void GRW_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
             
            if (GRW.DataRowCount == 0) return;

            DataRow _r = GRW.GetDataRow(GRW.FocusedRowHandle) ?? GRW.GetDataRow(0);
             
            DataRow _aracRow = _s.GetDataTable("SELECT * FROM Araclar WHERE Id=" + _r["Id"].ToString()).Rows[0];
            DataRow _musteriRow = _s.GetDataTable("SELECT *FROM Musteriler Where Id=" + _aracRow["MusteriId"].ToString()).Rows[0];

             
            txtIl.Text = _musteriRow["Il"].ToString();
            txtIlce.Text = _musteriRow["Ilce"].ToString();
            txtMail.Text = _musteriRow["Mail"].ToString();
            txtMusteriNo.Text = _musteriRow["MusteriNo"].ToString();
            txtTelefon1.Text = _musteriRow["Telefon1"].ToString();
            txtTelefon2.Text = _musteriRow["Telefon2"].ToString();
            txtTelefon3.Text = _musteriRow["Telefon3"].ToString();
            txtUnvani.Text = _musteriRow["Unvani"].ToString();
            cmbMusteriTip.SelectedIndex = (int)_musteriRow["Durum"];

            lblAracId.Text = _aracRow["Id"].ToString();

            lblMusteriId.Text = _musteriRow["Id"].ToString();
            txtSasiNo.Text = _aracRow["SasiNo"].ToString();
            txtAracTanimi.Text = _aracRow["AracTanimi"].ToString();
            txtKm.Text = _aracRow["Km"].ToString();
            txtMarka.Text = _aracRow["Marka"].ToString();
            txtModel.Text = _aracRow["Model"].ToString(); 
            txtPlaka.Text = _aracRow["Plaka"].ToString(); 
            txtTrafigeCikis.Text = _aracRow["TrafigeCikis"].ToString();
            txtPlaka.Text = _aracRow["Plaka"].ToString();
            if (_aracRow["SonServisTarihi"].ToString() != "")
                dtSonServis.DateTime = Convert.ToDateTime(_aracRow["SonServisTarihi"].ToString());
            else
                dtSonServis.Text = "";
            if (_aracRow["TescilTarihi"].ToString() != "")
                dtTescil.DateTime = Convert.ToDateTime(_aracRow["TescilTarihi"].ToString());
            else
                dtTescil.Text = "";

            cmbDurum.SelectedIndex = Convert.ToInt32(_aracRow["Durum"].ToString());

            LoadARamalar();
            LoadRandevular();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        { 
            txtIl.Text = "";
            txtIlce.Text = "";
            txtMail.Text = "";
            txtMusteriNo.Text = "";
            txtTelefon1.Text = "";
            txtTelefon2.Text = "";
            txtTelefon3.Text = "";
            txtUnvani.Text = "";


            lblMusteriId.Text = "0";

            lblAracId.Text = "0";
            txtSasiNo.Text = "";
            txtAracTanimi.Text = "";
            txtKm.Text = "";
            txtMarka.Text = "";
            txtModel.Text = ""; 
            txtPlaka.Text = ""; 
            txtTrafigeCikis.Text = "";
            txtPlaka.Text = "";

            dtSonServis.Text = "";
            dtTescil.Text = "";
            cmbMusteriTip.SelectedIndex = 0;
            cmbDurum.SelectedIndex = 1;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Araca ait bilgiler güncellenecektir! Devam etmek istiyor musunuz?", "Dikkat",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.No) return;


            if (txtTelefon1.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Müşterinin Telefon Numarası (Telefon1) Boş Olamaz!", "Dikkat",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _s.ClearParameters(); 
            _s.AddParameters("@Il", txtIl.Text.Trim());
            _s.AddParameters("@Ilce", txtIlce.Text.Trim());
            _s.AddParameters("@Mail", txtMail.Text.Trim());
            _s.AddParameters("@MusteriNo", txtMusteriNo.Text.Trim());
            _s.AddParameters("@Telefon1", txtTelefon1.Text.Trim());
            _s.AddParameters("@Telefon2", txtTelefon2.Text.Trim());
            _s.AddParameters("@Telefon3", txtTelefon3.Text.Trim());
            _s.AddParameters("@Unvani", txtUnvani.Text.Trim());
            _s.AddParameters("@Id", lblMusteriId.Text.Trim());
            _s.AddParameters("@Durum",cmbMusteriTip.SelectedIndex);
            int _result = -1;

            if (lblMusteriId.Text == "0")
            {
                _result = _s.CmdExecute("INSERT INTO Musteriler (Il,Ilce,Mail,MusteriNo,Telefon1,Telefon2,Telefon3,Unvani,Durum) VALUES " +
                                                             " (@Il,@Ilce,@Mail,@MusteriNo,@Telefon1,@Telefon2,@Telefon3,@Unvani,@Durum)");

                lblMusteriId.Text = _s.GetDataTable("SELECT IDENT_CURRENT('Musteriler')").Rows[0][0].ToString();
            }
            else
                _result = _s.CmdExecute("UPDATE Musteriler SET  Il=@Ilce,Mail=@Mail," +
                                            "MusteriNo=@MusteriNo,Telefon1=@Telefon1,Telefon2=@Telefon2,Telefon3=@Telefon3,Unvani=@Unvani,Durum=@Durum WHERE Id=@Id");

            if (_result > 0)
            {


                _s.ClearParameters();
                _s.AddParameters("@MusteriId", lblMusteriId.Text.Trim());
                _s.AddParameters("@Id", lblAracId.Text.Trim());
                _s.AddParameters("@KayitTarihi", DateTime.Now);
                _s.AddParameters("@SasiNo", txtSasiNo.Text.Trim());
                _s.AddParameters("@AracTanimi", txtAracTanimi.Text.Trim());
                _s.AddParameters("@Km", txtKm.Text.Trim().Replace(',', '.'));
                _s.AddParameters("@Marka", txtMarka.Text.Trim());
                _s.AddParameters("@Model", txtModel.Text.Trim()); 
                _s.AddParameters("@Plaka", txtPlaka.Text.Trim()); 
                _s.AddParameters("@Durum", cmbDurum.SelectedIndex);
                _s.AddParameters("@TrafigeCikis", Convert.ToInt32(txtTrafigeCikis.Text.Trim()));
                if (dtSonServis.Text != "")
                    _s.AddParameters("@SonServisTarihi", dtSonServis.DateTime);
                else
                    _s.AddParameters("@SonServisTarihi", DBNull.Value);

                if (dtSonServis.Text != "")
                    _s.AddParameters("@TescilTarihi", dtTescil.DateTime);
                else
                    _s.AddParameters("@TescilTarihi", DBNull.Value);



                if (lblAracId.Text == "0")
                    _result = _s.CmdExecute("INSERT INTO Araclar (SasiNo,AracTanimi,Km,Marka,Model, Plaka, Durum,SonServisTarihi,TrafigeCikis,TescilTarihi,MusteriId,KayitTarihi) VALUES " +
                                                       " (@SasiNo,@AracTanimi,@Km,@Marka,@Model, @Plaka, @Durum,@SonServisTarihi,@TrafigeCikis,@TescilTarihi,@MusteriId,@KayitTarihi)");
                else
                    _result = _s.CmdExecute("UPDATE Araclar SET SasiNo=@SasiNo,AracTanimi=@AracTanimi,Km=@Km,Marka=@Marka,Model=@Model, TescilTarihi=@TescilTarihi," +
                            "Plaka=@Plaka, Durum=@Durum,SonServisTarihi=@SonServisTarihi,TrafigeCikis=@TrafigeCikis,MusteriId=@MusteriId   WHERE Id=@Id");

                if (_result > 0)
                    XtraMessageBox.Show("Kayıt Başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    XtraMessageBox.Show(Core.GetError(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LoadData();
            }
            else
                XtraMessageBox.Show(Core.GetError(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            
            txtIl.Text = "";
            txtIlce.Text = "";
            txtMail.Text = "";
            txtMusteriNo.Text = "";
            txtTelefon1.Text = "";
            txtTelefon2.Text = "";
            txtTelefon3.Text = "";
            txtUnvani.Text = "";


            lblMusteriId.Text = "0";
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            if (!Login.AramalarYetki)
            {
                XtraMessageBox.Show("Bu İşlemi Yapma Yetkiniz Bulunmamaktadır!", "Dikkat", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }
            Modals.AramaForm arama = new Modals.AramaForm();
            arama.AracId = Convert.ToInt32(lblAracId.Text);
            arama.ShowDialog();
            LoadARamalar();
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            if (!Login.RandevularYetki)
            {
                XtraMessageBox.Show("Bu İşlemi Yapma Yetkiniz Bulunmamaktadır!", "Dikkat", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }
            Modals.RandevuForm randevu = new Modals.RandevuForm();
            randevu.AracId = Convert.ToInt32(lblAracId.Text);
            randevu.Tarih = DateTime.Now;
            randevu.ShowDialog();
            LoadRandevular();
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfileDialog1 = new OpenFileDialog();
            openfileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openfileDialog1.Multiselect = false;

            if (openfileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (var stream = File.Open(openfileDialog1.FileName, FileMode.Open, FileAccess.Read))
                {

                    var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);

                     
                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    };

                    var dataSet = reader.AsDataSet(conf);

                    foreach (DataRow item in dataSet.Tables[0].Rows)
                    {
                        _s.ClearParameters();
                        _s.AddParameters("@Adres1", item[10].ToString());  
                        _s.AddParameters("@Adres2", item[11].ToString());
                        _s.AddParameters("@Adres3", item[12].ToString());
                        _s.AddParameters("@Fax", item[13].ToString());
                        _s.AddParameters("@Il", item[14].ToString());
                        _s.AddParameters("@Ilce", item[15].ToString());
                        _s.AddParameters("@Mail", item[16].ToString());
                        _s.AddParameters("@MusteriNo", item[17].ToString());
                        _s.AddParameters("@Telefon1", item[18].ToString());
                        _s.AddParameters("@Telefon2", item[19].ToString());
                        _s.AddParameters("@Telefon3", item[20].ToString());
                        _s.AddParameters("@Unvani", item[21].ToString());

                        int _result = -1;


                        _result = _s.CmdExecute("INSERT INTO Musteriler (Adres1,Adres2,Adres3,Fax,Il,Ilce,Mail,MusteriNo,Telefon1,Telefon2,Telefon3,Unvani) VALUES " +
                                                                     " (@Adres1,@Adres2,@Adres3,@Fax,@Il,@Ilce,@Mail,@MusteriNo,@Telefon1,@Telefon2,@Telefon3,@Unvani)");

                        int _musteriId = Convert.ToInt32(_s.GetDataTable("SELECT IDENT_CURRENT('Musteriler')").Rows[0][0].ToString());

                        if (_result > 0)
                        {

                            _s.ClearParameters();
                            _s.AddParameters("@MusteriId", _musteriId);
                            _s.AddParameters("@SasiNo", item[0].ToString());
                            _s.AddParameters("@AracTanimi", item[1].ToString());
                            _s.AddParameters("@Km", Convert.ToInt32(item[2].ToString()));
                            _s.AddParameters("@Marka", item[3].ToString());
                            _s.AddParameters("@Model", item[4].ToString());
                            _s.AddParameters("@MotorNo", item[5].ToString());
                            _s.AddParameters("@Plaka", item[6].ToString());
                            _s.AddParameters("@Renk", item[7].ToString());
                            _s.AddParameters("@Seri", item[8].ToString());
                            _s.AddParameters("@Durum", 1);
                            _s.AddParameters("@TrafigeCikis", Convert.ToInt32(item[9].ToString()));

                            _s.AddParameters("@SonServisTarihi", DBNull.Value);

                            _result = _s.CmdExecute("INSERT INTO Araclar (SasiNo,AracTanimi,Km,Marka,Model,MotorNo,Plaka,Renk,Seri,Durum,SonServisTarihi,TrafigeCikis,MusteriId) VALUES " +
                                                               " (@SasiNo,@AracTanimi,@Km,@Marka,@Model,@MotorNo,@Plaka,@Renk,@Seri,@Durum,@SonServisTarihi,@TrafigeCikis,@MusteriId)");

                            if (_result < 0)
                            {
                                XtraMessageBox.Show(Core.GetError()); return;

                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(Core.GetError()); return;

                        }
                    }

                    
                    XtraMessageBox.Show("Aktarım Tamamlandı!");
                    LoadData();
                }
            }
        }

        private void GRCRandevular_DoubleClick(object sender, EventArgs e)
        {
            if (!Login.RandevularYetki)
            {
                XtraMessageBox.Show("Bu İşlemi Yapma Yetkiniz Bulunmamaktadır!", "Dikkat", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }
            if (GRWRandevular.DataRowCount == 0) return;
            Modals.RandevuForm randevu = new Modals.RandevuForm();
            randevu.AracId = Convert.ToInt32(lblAracId.Text);
            randevu.RandevuId = Convert.ToInt32(GRWRandevular.GetFocusedRowCellDisplayText("Id"));
            randevu.Tarih = Convert.ToDateTime(GRWRandevular.GetFocusedRowCellDisplayText("BaslangicTarih"));
            randevu.ShowDialog();
        }

        private void GRCAramalar_DoubleClick(object sender, EventArgs e)
        {
            if (!Login.AramalarYetki)
            {
                XtraMessageBox.Show("Bu İşlemi Yapma Yetkiniz Bulunmamaktadır!", "Dikkat", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }
            if (GRWAramalar.DataRowCount == 0) return;
            Modals.AramaForm arama = new Modals.AramaForm();
            arama.AracId = Convert.ToInt32(lblAracId.Text);
            arama.DetayId= Convert.ToInt32(GRWAramalar.GetFocusedRowCellDisplayText("AramaId"));
            arama.ShowDialog();
            LoadARamalar();
        }

        private void GRC_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void GRC_Click(object sender, EventArgs e)
        {
            GRW_FocusedRowChanged(null, null);
        }
    }
}