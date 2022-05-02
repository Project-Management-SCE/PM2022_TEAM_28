using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHoly.Models;

namespace WebHoly.ViewModels
{
    public class FirstScreenViewModel
    {
        public string SinagugName{ get; set; }

        public PrayerTimes PrayerTimes { get; set; }

        public HebrewDateViewModel HebrewDate { get; set; }

    }
}
