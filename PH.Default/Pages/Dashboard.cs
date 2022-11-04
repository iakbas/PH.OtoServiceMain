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
    public partial class Dashboard : DevExpress.XtraEditors.XtraForm
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        Core _s;
        private void Dashboard_Load(object sender, EventArgs e)
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
            dt2.DateTime = DateTime.Now;

            btnRefresh_Click(null, null);
            //GRC.DataSource = _s.GetDataTable(@"SELECT A.Marka,A.Model, A.SasiNo,A.Plaka,M.Unvani,M.Telefon1 FROM Randevular AS R INNER JOIN 
            //                        Araclar AS A ON R.AracId=A.Id INNER JOIN
            //                        Musteriler AS M ON A.MusteriId=M.Id WHERE
            //                        A.Durum=1");

            //AND
            //                       (DATEADD(DAY, -1, DATEADD(month, 10, R.Tarih)) = GETDATE()  OR DATEDIFF(Month, R.Tarih, GETDATE()) * A.Km > 15000)
        }

        private void dt1_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void dt2_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void btnRefresh_EditValueChanged(object sender, EventArgs e)
        {

        }
        DataTable _randevular, _randevularYarin,_aramalar;
        private void btnRefresh_Click(object sender, EventArgs e)
        {
         
              _randevular = _s.GetDataTable(@"
SELECT Count(Id) AS Id,AracId FROM Randevular Where RandevuSonucId<>2 AND (
Tarih BETWEEN '" + dt1.DateTime.ToString("yyyyMMdd") + @"' AND '" + 
dt2.DateTime.ToString("yyyyMMdd") + @"')
GROUP BY AracId");
            if (_randevular.Rows.Count > 0)
                lblRandevularBuGun.Text = _randevular.Rows.Count.ToString();
            else
                lblRandevularBuGun.Text = "0";

            _randevularYarin = _s.GetDataTable(@"
SELECT Count(Id) AS Id,AracId FROM Randevular Where RandevuSonucId<>2 AND
(DATEADD(DAY,1,Tarih) BETWEEN '" + dt1.DateTime.ToString("yyyyMMdd") + @"' AND '" +
  dt2.DateTime.ToString("yyyyMMdd") + @"' )
GROUP BY AracId");


            if (_randevularYarin.Rows.Count > 0)
                lblRandevularYarin.Text = _randevularYarin.Rows.Count.ToString();
            else
                lblRandevularYarin.Text = "0"; 
            
//            string _q = @"SELECT Count(Id) AS Id,AracId FROM AramaDetaylari WHERE 
//DosyaDurumu=1 AND 
//AracId NOT IN (SELECT AracId FROM AramaDetaylari WHERE  CONVERT(smalldatetime,convert(varchar(8),cast(Tarih as date),112))>='"+ DateTime.Now.ToString("yyyyMMdd") + @"')  AND
//( (AramaHatirlatmaTarihi  BETWEEN '" + dt1.DateTime.ToString("yyyyMMdd") + @"' AND '" +
//  dt2.DateTime.ToString("yyyyMMdd") + @"' ) OR 
//DATEDIFF(MONTH,Tarih,GETDATE()) * OrtalamaKm >= 15000 OR 
//AracId IN ( SELECT Id FROM Araclar WHERE (DATEADD(MONTH,10,KayitTarihi)  BETWEEN '" + dt1.DateTime.ToString("yyyyMMdd") + @"' AND '" +
//  dt2.DateTime.ToString("yyyyMMdd") + @"') OR 
//(DATEADD(MONTH,10,ISNULL(TescilTarihi,GETDATE()))  BETWEEN '" + dt1.DateTime.ToString("yyyyMMdd") + @"' AND '" +
//  dt2.DateTime.ToString("yyyyMMdd") + @"' ) ))
//GROUP BY AracId";

            string _q = @"SELECT Count(Ad.Id) AS Id,AD.AracId FROM AramaDetaylari AS AD
INNER  JOIN
( SELECT Id FROM Araclar WHERE (DATEADD(MONTH,10,KayitTarihi)  BETWEEN '" + dt1.DateTime.ToString("yyyyMMdd") + @"' AND '" +
  dt2.DateTime.ToString("yyyyMMdd") + @"') OR 
(DATEADD(MONTH,10, TescilTarihi )  BETWEEN '" + dt1.DateTime.ToString("yyyyMMdd") + @"' AND '" +
  dt2.DateTime.ToString("yyyyMMdd") + @"' ) ) AS TES ON TES.Id=AD.AracId 
LEFT JOIN 
 (SELECT AracId FROM AramaDetaylari WHERE  CONVERT(smalldatetime,convert(varchar(8),cast(Tarih as date),112))>='" + 
 dt1.DateTime.ToString("yyyyMMdd") + @"') AS AR ON AR.AracId !=AD.AracId 
 WHERE AD.DosyaDurumu=1 OR
 DATEDIFF(MONTH,Tarih,GETDATE()) * OrtalamaKm >= 15000  
GROUP BY AD.AracId";

            _aramalar = _s.GetDataTable(_q);
            if (_aramalar.Rows.Count > 0)
                lblAramalar.Text = _aramalar.Rows.Count.ToString();
            else
                lblAramalar.Text = "0";
        }

        private void lblAramalar_Click(object sender, EventArgs e)
        {
            string _araclar = "";
            if (_aramalar.Rows.Count == 0)
            {
                GRC.DataSource = null;
                GRW.Columns.Clear();
                return;
            }
            foreach (DataRow item in _aramalar.Rows)
            {
                if (_araclar.Length > 0)
                    _araclar += ",";
                
                    _araclar += item[1].ToString();
            }

            DataTable _t =  _s.GetDataTable("SELECT A.Id,A.SasiNo,A.Plaka,A.Marka,A.Model," +
                "M.Unvani,M.Id AS MusteriId  ,A.TrafigeCikis FROM Araclar AS A INNER JOIN Musteriler AS " +
                "M ON M.Id=A.MusteriId WHERE A.Id IN ("+ _araclar+ ")") ;

            GRC.DataSource = _t;
            GRW.Columns["Id"].Visible = false; 
            GRW.Columns["MusteriId"].Visible = false;
            GRW_FocusedRowChanged(null, null);
        }

        private void GRW_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (GRW.DataRowCount == 0) return;
            DataRow _r = GRW.GetFocusedDataRow();
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

            cmbDurum.SelectedIndex = Convert.ToInt32(_aracRow["Durum"].ToString());

        }

        private void lblRandevularBuGun_Click(object sender, EventArgs e)
        {

            string _araclar = "";
            if (_randevular.Rows.Count == 0)
            {
                GRC.DataSource = null;
                GRW.Columns.Clear();
                return;
            }
            foreach (DataRow item in _randevular.Rows)
            {
                if (_araclar.Length > 0)
                    _araclar += ",";

                _araclar += item[1].ToString();
            }

            DataTable _t = _s.GetDataTable("SELECT A.Id,A.SasiNo,A.Plaka,A.Marka,A.Model," +
                "M.Unvani,M.Id AS MusteriId,A.TrafigeCikis FROM Araclar AS A INNER JOIN Musteriler AS " +
                "M ON M.Id=A.MusteriId WHERE A.Id IN (" + _araclar + ")");

            GRC.DataSource = _t;
            GRW.Columns["Id"].Visible = false;
            GRW.Columns["MusteriId"].Visible = false;
            GRW_FocusedRowChanged(null, null);
        }

        private void lblRandevularYarin_Click(object sender, EventArgs e)
        {

            string _araclar = "";
            if (_randevularYarin.Rows.Count == 0)
            {
                GRC.DataSource = null;
                GRW.Columns.Clear();
                return;
            }
            foreach (DataRow item in _randevularYarin.Rows)
            {
                if (_araclar.Length > 0)
                    _araclar += ",";

                _araclar += item[1].ToString();
            }

            DataTable _t = _s.GetDataTable("SELECT A.Id,A.SasiNo,A.Plaka,A.Marka,A.Model," +
                "M.Unvani,M.Id AS MusteriId,A.TrafigeCikis FROM Araclar AS A INNER JOIN Musteriler AS " +
                "M ON M.Id=A.MusteriId WHERE A.Id IN (" + _araclar + ")");


            GRC.DataSource = _t;
            GRW.Columns["Id"].Visible = false;
            GRW.Columns["MusteriId"].Visible = false;

            GRW_FocusedRowChanged(null, null);
        }

        private void yeniAramaKaydıOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Login.AramalarYetki)
            {
                XtraMessageBox.Show("Bu İşlemi Yapma Yetkiniz Bulunmamaktadır!", "Dikkat", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }
            if (GRW.DataRowCount == 0) return;
            DataRow _r = GRW.GetFocusedDataRow();
            Modals.AramaForm aramaForm = new Modals.AramaForm();
            aramaForm.AracId =
            Convert.ToInt32(_r["Id"].ToString());
            aramaForm.ShowDialog();
        }

        private void yeniRandevuOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Login.RandevularYetki)
            {
                XtraMessageBox.Show("Bu İşlemi Yapma Yetkiniz Bulunmamaktadır!", "Dikkat", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }
            if (GRW.DataRowCount == 0) return;
            DataRow _r = GRW.GetFocusedDataRow();
            Modals.RandevuForm randevuForm = new Modals.RandevuForm();
            randevuForm.AracId = Convert.ToInt32(_r["Id"].ToString());
            randevuForm.Tarih = DateTime.Now;
            randevuForm.ShowDialog();
        }
    }
}