using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using PH.Config;
namespace PH.Data
{
    public class Core
    {

        private static string _sqlConnectionStr;
        private static Core _sinifDeg;
        private static string _errMsg;
        private SqlTransaction _mainTransAction;
        public static SqlConnectionStringBuilder b;
        public static string _gelistirici = "Geliştirici :İbrahim AKBAŞ\r\n\r\nTarih :01.01.2018";
        //SINGLETON
        private Core(string cnnStr = "")
        {
            PSqlConnectionStr = cnnStr;


            if (PSqlConnectionStr.Trim().Length == 0)
            {
                ReaderCore _r = new ReaderCore();
                b = _r.GetCnnStr();
                if (b == null)
                { _errMsg = _r.ErrMess; return; }


                PSqlConnectionStr = b.ConnectionString;

            }
            if (PMainCnn == null)
            {
                //Bağlantı Boş ise

                //if (DateTime.Now > new DateTime(2019, 03, 05)) {
                //    _errMsg = "Lisans Süreniz Dolmuştur. Lütfen Yöneticinize Danışınız...";
                //    return;
                //}

                try
                {
                    PMainCnn = new SqlConnection(PSqlConnectionStr);
                    PMainCnn.Open();
                    PMainCmd = PMainCnn.CreateCommand();
                }
                catch (Exception e)
                {
                    PMainCnn = null;
                    _errMsg = "Sistem Veritabına Erişim Sağlanamadı ! \n Hata Mesajı: " + e.Message;
                }
            }

        }



        public SqlConnection PMainCnn { get; set; }

        public SqlCommand PMainCmd { get; set; }

        public SqlDataAdapter PMainAdapter { get; set; }

        public SqlDataAdapter PChildAdapter { get; set; }

        public DataSet PmDataset { get; set; }

        public DataTable PmDatatable { get; set; }

        public string PSqlConnectionStr
        {
            get { return _sqlConnectionStr; }
            set { _sqlConnectionStr = value; }
        }

        public int AddParametersImage(string name, object value)
        {
            if (PMainCnn == null) return -1;
            if (PMainCmd == null) PMainCmd = new SqlCommand();
            try
            {
                PMainCmd.Parameters.AddWithValue(name, (value == null) ? (object)DBNull.Value : value).SqlDbType = SqlDbType.Image;
                return 1;
            }
            catch (Exception E)
            {
                _errMsg = "Parametre Atama Esnasında Hata Oluştu ! \n Hata Mesajı: " + E.Message;
                return -1;
            }
        }
        public int AddParameters(string name, object value)
        {
            if (PMainCnn == null) return -1;
            if (PMainCmd == null) PMainCmd = new SqlCommand();
            try
            {
                PMainCmd.Parameters.AddWithValue(name, value);
                return 1;
            }
            catch (Exception E)
            {
                _errMsg = "Parametre Atama Esnasında Hata Oluştu ! \n Hata Mesajı: " + E.Message;
                return -1;
            }
        }

        public void BeginTrans()
        {
            try
            {
                _mainTransAction = PMainCnn.BeginTransaction();
                PMainCmd.Transaction = _mainTransAction;
            }
            catch (Exception)
            {
                _mainTransAction.Dispose();
                _mainTransAction = PMainCnn.BeginTransaction();
                PMainCmd.Transaction = _mainTransAction;
            }
        }

        public void ClearParameters()
        {
            PMainCmd.Parameters.Clear();
        }

        public int CmdExecute(string query, CommandType cmdType = CommandType.Text)
        {
            try
            {
                if (PMainCnn == null)
                {
                    _errMsg = "Bağlantı Nesnesi Boş : ";
                    return -1;
                }
                if (PMainCnn.State == ConnectionState.Closed)
                    PMainCnn.Open();
                CmdFill(query, cmdType);
                PMainCmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception e)
            {
                _errMsg = "T-SQL Hata ! \n Hata Mesajı : " + e.Message;
                return -1;
            }
        }

        public bool CmdExecuteBatch(string query, CommandType cmdType = CommandType.Text)
        {
            try
            {
                if (PMainCnn == null)
                {
                    _errMsg = "Bağlantı Nesnesi Boş : ";
                    return false;
                }
                if (PMainCnn.State == ConnectionState.Closed)
                    PMainCnn.Open();
                CmdFill(query, cmdType);
                PMainCmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                _errMsg = e.Message;
                return false;
            }
        }

        public void CmdFill(string query, CommandType cmdType = CommandType.Text)
        {
            if (PMainCmd == null)
                PMainCmd = new SqlCommand();

            PMainCmd.Connection = PMainCnn;
            PMainCmd.CommandType = cmdType;
            PMainCmd.CommandText = query;
        }

        public void CommitTrans()
        {
            _mainTransAction.Commit();
        }

        public DataTable GetDataTable(string query, CommandType cmdType = CommandType.Text)
        {
            try
            {
                CmdFill(query, cmdType);
                PMainAdapter = new SqlDataAdapter();
                PMainAdapter.SelectCommand = PMainCmd;
                PmDatatable = new DataTable();
                PMainAdapter.Fill(PmDatatable);
                return PmDatatable;
            }
            catch (Exception E)
            {
                _errMsg = "DataTable Oluşturulamadı ! \n Hata Mesajı: " + E.Message;
                PMainCmd = new SqlCommand();
                return null;
            }
        }

        //SINGLETON PATTERN

        public int GetRowCount(string query)
        {
            try
            {
                CmdFill(query);
                PMainAdapter = new SqlDataAdapter();
                PMainAdapter.SelectCommand = PMainCmd;
                PmDatatable = new DataTable();
                PMainAdapter.Fill(PmDatatable);
                return PmDatatable.Rows.Count;
            }
            catch (Exception E)
            {
                _errMsg = "DataTable Oluşturulamadı ! \n Hata Mesajı: " + E.Message;
                return -1;
            }
        }

        public void RollbackTrans()
        {
            _mainTransAction.Rollback();
        }

        public static string GetError()
        {
            return _errMsg;
        }


        public DataSet GetMasterDetailDataSet(SqlCommand MainCmd, SqlCommand ChilCmd,
            string MainRelationField, string ChildRelationField, string RelationName)
        {
            PMainAdapter = new SqlDataAdapter(MainCmd);
            PChildAdapter = new SqlDataAdapter(ChilCmd);

            try
            {
                PmDataset = new DataSet();
                PMainAdapter.Fill(PmDataset, "Main");
                PChildAdapter.Fill(PmDataset, "Child");

                var PrimaryColumn = PmDataset.Tables["Main"].Columns[MainRelationField];
                var ForeingColumn = PmDataset.Tables["Child"].Columns[ChildRelationField];

                PmDataset.Relations.Add("Mamül " + RelationName, PrimaryColumn, ForeingColumn, false);

                PmDataset.Relations[0].Nested = true;

                PmDataset.Relations.Add("Yarı-Mamül " + RelationName,
                    PmDataset.Tables["Child"].Columns[MainRelationField],
                    ForeingColumn, false);
                PmDataset.Relations[1].Nested = true;
            }
            catch (Exception)
            {
                PmDataset.Relations.Clear();
                if (PmDataset.Tables.Count > 1)
                    PmDataset.Tables.RemoveAt(1);
            }
            return PmDataset;
        }

        public static Core NesneOlustur(string SourcePath = "", bool _degistir = false)
        {

            if (_sinifDeg == null || _sinifDeg.PMainCnn == null || _degistir)
            {

                _sinifDeg = new Core(SourcePath);

            }
            else
            {
                if (_sinifDeg != null)
                    if (SourcePath != "")
                    {
                        if (_sinifDeg.PMainCnn.ConnectionString != SourcePath)
                        {

                            _sinifDeg = new Core(SourcePath);
                            return _sinifDeg;
                        }
                    }
            }

            if (_sinifDeg.PMainCnn == null) return null;

            return _sinifDeg;
        }
        public void CloseConnection()
        {
            if (PMainCnn.State != ConnectionState.Closed)
                PMainCnn.Close();
        }
    }
} 
