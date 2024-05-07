using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Posta
    {
        public string senderEmail { get; private set; } = "xdevlethastanesi@gmail.com";
        public string senderpassword { get; private set; } = "uhnheuyuogtmsego";
        public string smtphost { get; private set; } = "smtp.gmail.com";
        public string konu { get; set; }
        public string baslik { get; set; }
        public int smtpport { get; private set; } = 587;
    }
}
