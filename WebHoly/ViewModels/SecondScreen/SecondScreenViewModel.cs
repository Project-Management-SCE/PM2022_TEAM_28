using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.ViewModels.SecondScreen
{
    public class SecondScreenViewModel
    {
        public JewishCalenderViewModel JewishCalender { get; set; }
        public HebrewDateViewModel HebrewDate { get; set; }
        public string SinagugName { get; set; }
    }
}
