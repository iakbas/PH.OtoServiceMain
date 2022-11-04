using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH.Default.Config
{
    public class Converter
    {
        public Converter()
        {

        }


        public static string IntToTime(int _value)
        {
            string _s1 = "", _s2 = "";

            _s1 = (_value / 60).ToString().Length == 1 ? "0" + (_value / 60).ToString() : (_value / 60).ToString();
            _s2 = (_value % 60).ToString().Length == 1 ? "0" + (_value % 60).ToString() : (_value % 60).ToString();
            return _s1 + ":" + _s2;
        }
        public static int TimeToInt(string _time)
        {

            if (_time.ToString().Trim().Length == 0) return 0;

            string[] _v = _time.Split(':');
            if (_v.Length < 2) return 0;

            string _v1 = _v[0];
            string _v2 = _v[1];

            int _t1 = 0;
            int _t2 = 0;

            try
            {
                _t1 = Convert.ToInt32(_v1);

            }
            catch (Exception)
            {
            }
            try
            {
                _t2 = Convert.ToInt32(_v2);

            }
            catch (Exception)
            {
            }

            return (_t1 * 60) + _t2;

        }

        internal static DateTime IntToTime(int? baslangicSaat)
        {
            throw new NotImplementedException();
        }
    }
}
