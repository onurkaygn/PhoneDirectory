using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telefonRehberi
{
    internal class Rehber
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelNo { get; set; }

        public Rehber(string ad, string soyad, string telNo)
        {
            Ad = ad;
            Soyad = soyad;
            TelNo = telNo;
        }
    }
}
