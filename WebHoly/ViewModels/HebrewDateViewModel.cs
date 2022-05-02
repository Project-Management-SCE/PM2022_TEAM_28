using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.ViewModels
{
    public class HebrewDateViewModel
    {
        public int gy { get; set; }
        public int gm { get; set; }
        public int gd { get; set; }
        public bool afterSunset { get; set; }
        public int hy { get; set; }
        public string hm { get; set; } //חודש עברי באנגלית
        public int hd { get; set; } // יום עברי כמספר
        public string hebrew { get; set; } // תאריך עברי
        public List<string> events { get; set; } // אירועי היום
    }
}
