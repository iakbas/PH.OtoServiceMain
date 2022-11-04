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

namespace PH.Default.Extentions
{
    public partial class ExcelImport : DevExpress.XtraEditors.XtraForm
    {
        public ExcelImport()
        {
            InitializeComponent();
        }
        Core _s;
        private void txtExcel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openfileDialog1 = new OpenFileDialog();
            openfileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openfileDialog1.Multiselect = false;

            if (openfileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtExcel.Text = openfileDialog1.FileName;

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtExcel.Text.Trim().Length == 0) return;

            using (var stream = File.Open(txtExcel.Text, FileMode.Open, FileAccess.Read))
            {


                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    progressBarControl1.Properties.Step = 1;
                    progressBarControl1.Properties.Maximum = reader.RowCount;
                    progressBarControl1.Properties.Minimum = 0;

                    int index = 0;
                    do
                    {
                        while (reader.Read())
                        {
                            index++;
                            if (index == 1) continue;

                            progressBarControl1.PerformStep();
                            progressBarControl1.Update();
                            ImportEx(reader);
                        }
                    } while (reader.NextResult());

                }
                XtraMessageBox.Show("Aktarım Tamamlandı!");

            }
        }

        bool ImportEx(IExcelDataReader reder)
        {
            string _unvan = reder.GetValue(1) != null ? reder.GetValue(1).ToString() : "";
            DataTable _tMusteri = new DataTable();
            int _musteriId = 0;
            int _result = -1;
            if (_unvan.Trim() != "")
            {
                _tMusteri = _s.GetDataTable("SELECT Id FROM Musteriler where Unvani='" + _unvan + "'");
                if (_tMusteri.Rows.Count > 0)
                    _musteriId = Convert.ToInt32(_tMusteri.Rows[0][0].ToString());

                _result = 1;
            }
            if(_musteriId==0)
            { 
                int _t = _s.GetDataTable("SELECT Id FROM Musteriler").Rows.Count;
                _t++;
                string _f = "";
                for (int i = 0; i < 10 - _t.ToString().Length; i++)
                    _f += "0";


                _s.ClearParameters();
                _s.AddParameters("@MusteriNo", _f + _t);
                _s.AddParameters("@Telefon1", reder.GetValue(5) != null ? reder.GetValue(5).ToString() : "");
                _s.AddParameters("@Telefon2", reder.GetValue(6) != null ? reder.GetValue(6).ToString() : "");
                _s.AddParameters("@Telefon3", reder.GetValue(7) != null ? reder.GetValue(7).ToString() : "");
                _s.AddParameters("@Unvani", reder.GetValue(1) != null ? reder.GetValue(1).ToString() : "");
                _s.AddParameters("@Durum", 1);
               


                _result = _s.CmdExecute("INSERT INTO Musteriler (MusteriNo,Telefon1,Telefon2,Telefon3,Unvani,Durum) VALUES " +
                                                             " (@MusteriNo,@Telefon1,@Telefon2,@Telefon3, @Unvani,@Durum)");

                _musteriId = Convert.ToInt32(_s.GetDataTable("SELECT IDENT_CURRENT('Musteriler')").Rows[0][0].ToString());
            }
            if (_result > 0)
            {
                _s.ClearParameters();
                _s.AddParameters("@MusteriId", _musteriId);
                _s.AddParameters("@KayitTarihi", DateTime.Now);
                _s.AddParameters("@SasiNo", reder.GetValue(2) != null ? reder.GetValue(2).ToString() : "");
                _s.AddParameters("@AracTanimi", "");
                _s.AddParameters("@Km", 0);
                _s.AddParameters("@Marka", reder.GetValue(0) != null ? reder.GetValue(0).ToString() : "");
                _s.AddParameters("@Model", reder.GetValue(8) != null ? reder.GetValue(8).ToString() : "");
                _s.AddParameters("@Plaka", reder.GetValue(4) != null ? reder.GetValue(4).ToString() : "");
                _s.AddParameters("@Durum", 1);


                if (reder.GetValue(9) != null)
                {
                    if (reder.GetValue(9).ToString() != "")
                    {

                        if (reder.GetValue(9).ToString().Length < 10)
                            _s.AddParameters("@TrafigeCikis", reder.GetValue(9) != null ? new DateTime(Convert.ToInt32(reder.GetValue(9).ToString().Substring(0, 4)), 1, 1).Year : DBNull.Value);
                        else
                            _s.AddParameters("@TrafigeCikis", reder.GetValue(9) != null ? Convert.ToDateTime(reder.GetValue(9).ToString()).Year : DBNull.Value);
                    }
                    else
                        _s.AddParameters("@TrafigeCikis", DBNull.Value);
                }
                else
                    _s.AddParameters("@TrafigeCikis", DBNull.Value);


                _s.AddParameters("@SonServisTarihi", DBNull.Value);

                if (reder.GetValue(10) != null)
                {
                    if (reder.GetValue(10).ToString() != "" && reder.GetValue(10).ToString() != "0")
                    {

                        if (reder.GetValue(10).ToString().Length < 10)
                            _s.AddParameters("@TescilTarihi", reder.GetValue(10) != null ? new DateTime(Convert.ToInt32(reder.GetValue(10).ToString().Substring(0, 4)), 1, 1) : DBNull.Value);
                        else
                            _s.AddParameters("@TescilTarihi", reder.GetValue(10) != null ? Convert.ToDateTime(reder.GetValue(10).ToString()) : DBNull.Value);
                    }
                    else
                        _s.AddParameters("@TescilTarihi", DBNull.Value);
                }
                else
                    _s.AddParameters("@TescilTarihi", DBNull.Value);


                _result = _s.CmdExecute("INSERT INTO Araclar (SasiNo,AracTanimi,Km,Marka,Model, Plaka, Durum,SonServisTarihi,TrafigeCikis,TescilTarihi,MusteriId,KayitTarihi) VALUES " +
                                                   " (@SasiNo,@AracTanimi,@Km,@Marka,@Model, @Plaka, @Durum,@SonServisTarihi,@TrafigeCikis,@TescilTarihi,@MusteriId,@KayitTarihi)");

                if (_result > 0)
                {
                    int _aracId = 0;
                    _aracId = Convert.ToInt32(_s.GetDataTable("SELECT IDENT_CURRENT('Araclar')").Rows[0][0].ToString());

                    if (reder.GetValue(10) != null)
                    {
                        if (reder.GetValue(10).ToString() != "" && reder.GetValue(10).ToString() != "0")
                        {

                            if (reder.GetValue(10).ToString().Length < 10)
                                _s.AddParameters("@Tarih", reder.GetValue(9) != null ? new DateTime(Convert.ToInt32(reder.GetValue(10).ToString().Substring(0, 4)), 1, 1) : DBNull.Value);
                            else
                                _s.AddParameters("@Tarih", reder.GetValue(9) != null ? Convert.ToDateTime(reder.GetValue(10).ToString()) : DBNull.Value);
                        }
                        else
                            _s.AddParameters("@Tarih", DBNull.Value);
                    }
                    else
                        _s.AddParameters("@Tarih", DBNull.Value);

                    _s.AddParameters("@Aciklama", reder.GetValue(13) != null ? reder.GetValue(13).ToString() : "");

                    int OperatorId = 0;
                    string _opAdi = reder.GetValue(15) != null ? reder.GetValue(15).ToString() : "";


                    DataTable _op = _s.GetDataTable("SELECT Id FROM Operatorler WHERE Unvani='" + _opAdi + "'");

                    if (_op.Rows.Count > 0)
                        OperatorId = Convert.ToInt32(_op.Rows[0][0].ToString());
                    else
                    {
                        int _t = _s.GetDataTable("SELECT Id FROM Operatorler").Rows.Count;
                        _t++;
                        string _f = "";
                        for (int i = 0; i < 5- _t.ToString().Length; i++)
                            _f += "0";
                        _s.CmdExecute("INSERT INTO Operatorler (Kodu,Unvani) " +
                                       "VALUES('"+  _f +"','" + _opAdi + "')");
                        OperatorId = Convert.ToInt32(_s.GetDataTable("SELECT IDENT_CURRENT('Operatorler')").Rows[0][0].ToString());
                    }
                    if (OperatorId > 0)
                        _result = _s.CmdExecute("INSERT INTO AramaDetaylari (Tarih,AracId,Aciklama,DosyaDurumu,OperatorId,Sonuc) " +
                                        "VALUES(@Tarih," + _aracId + ",@Aciklama,1," + OperatorId.ToString() + ",1)");


                    if( _result < 0)
                    {
                        string _sgs = PH.Data.Core.GetError();
                    }
                    return _result < 0;
                }
                else
                {
                    string _sgs = PH.Data.Core.GetError();
                    return false;
                }
            }
            else
            {
                string _sgs = PH.Data.Core.GetError();
                return false;
            }

        }

        private void ExcelImport_Load(object sender, EventArgs e)
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
        }
    }
}