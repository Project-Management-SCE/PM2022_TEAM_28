using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHoly.Models;

namespace WebHoly.ViewModels
{
    public class ScreenVieModel
    {

        public string SinagugName { get; set; }

        public PrayerTimes PrayerTimes { get; set; }

        public HebrewDateViewModel HebrewDate { get; set; }

        public TimesViewModel Times { get; set; }

        public JewishCalenderViewModel JewishCalender { get; set; }

        public Halachot Halachot { get; set; }

        public ScreenCssTypeViewModel ScreenCssType { get; set; }
        public SoulBoard SoulBoard { get; set; }


    }
}
