using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH.Models
{
    public class SmsSettings
    {
        public string KullaniciAdi { get; set; }
        public string Sifre  { get; set; }
        public string EMail { get; set; }
        public string Endpoint { get; set; }
        public string SmsBaslik { get; set; }
        public int KayitOlustugunda { get; set; }
        public int RandevuOlustugunda { get; set; }
        public int RandevuDegistiginde { get; set; }

    }
}
