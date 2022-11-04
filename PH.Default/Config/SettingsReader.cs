using PH.Crypt;
using PH.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH.Default.Config
{
    public class SettingsReader
    {
        public SettingsReader(string path = "")
        {
            if (path.Length > 0)
                _path = path;
        }
        string _path = Application.StartupPath + @"\SMS.ini";
        public SmsSettings? ReadSettings()
        {
            SmsSettings settings = new SmsSettings();
            if (File.Exists(_path))
            {
                string[] _l2 = File.ReadAllLines(_path);
                for (int i = 0; i < _l2.Length; i++)
                {
                    string l = _l2[i];

                    string[] _keyVal = l.Split('=');


                    switch (_keyVal[0].Trim())
                    {
                        case "KullaniciAdi":
                            settings.KullaniciAdi = _keyVal[1].Trim();
                            break;
                        case "Sifre":
                            settings.Sifre = DeCrypt.Decrypt(_keyVal[1].Trim() + "=", "iAYazilim1@./*");
                            break;
                        case "EMail":
                            settings.EMail = _keyVal[1].Trim();
                            break;
                        case "EndPoint":
                            settings.Endpoint = _keyVal[1].Trim();
                            break;
                        case "SMS Baslik":
                            settings.SmsBaslik = _keyVal[1].Trim();
                            break;

                        case "Kayıt Oluşturulduğunda":
                            settings.KayitOlustugunda = Convert.ToInt32(_keyVal[1].Trim());
                            break;
                        case "Randevu Oluşturulduğunda":
                            settings.RandevuOlustugunda = Convert.ToInt32(_keyVal[1].Trim());
                            break;
                        case "Randevu Değiştirildiğinde":
                            settings.RandevuDegistiginde = Convert.ToInt32(_keyVal[1].Trim());
                            break;

                        default:
                            break;
                    }
                }
                return settings;
            }
            else
                return null;
        }
    }
}
