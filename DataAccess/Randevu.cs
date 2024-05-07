using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Randevu
    {
        public string DoktorKimlik { get; set; }
        public string HastaKimlik { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime Saat { get; set; }
    }
}
