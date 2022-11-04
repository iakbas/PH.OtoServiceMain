using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace PH.Config
{
    public class ReaderCore
    {

        public string ErrMess { get; set; }
        private string P { get; set; }
        public ReaderCore()
        {

            ErrMess = "";
        }

        public SqlConnectionStringBuilder GetCnnStr(string filePath = "")
        {
            System.Data.SqlClient.SqlConnectionStringBuilder builder =
                 new System.Data.SqlClient.SqlConnectionStringBuilder();



            if (ReadFile(filePath))
            {
                builder.ConnectionString = P;
                builder.Password = PH.Crypt.DeCrypt.Decrypt(builder.Password, "ibr123*");


                return builder;

            }
            else { return null; }
        }

        public System.Data.SqlClient.SqlConnectionStringBuilder GetCnnStr2(string filePath = "")
        {
            System.Data.SqlClient.SqlConnectionStringBuilder builder =
                 new System.Data.SqlClient.SqlConnectionStringBuilder();



            if (ReadFile(filePath))
            {

                builder.ConnectionString = PH.Crypt.DeCrypt.Decrypt(P, "ibr112*");


                return builder;

            }
            else { return null; }
        }


        private bool ReadFile(string filePath = "")
        {
            string mainFile = "";

            if (filePath.Trim().Length == 0)
            {
                mainFile = "cnn.ini";
            }
            else
            {
                if (File.Exists(filePath))
                    mainFile = filePath;
                else
                {
                    ErrMess = "Belirtilen dosya yolu bulunamadı !";
                    return false;
                }
            }
            int chk = -1;


            const Int32 BufferSize = 128;
            if (File.Exists(mainFile))
            {
                using (var fileStream = File.OpenRead(mainFile))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        P = line;
                        chk = 1;
                    }

                }
            }
            else
            {
                ErrMess = "Cnn Dosyası Bulunamadı !";
                chk = -1;
            }

            return chk < 0 ? false : true;
        }

    }
}
