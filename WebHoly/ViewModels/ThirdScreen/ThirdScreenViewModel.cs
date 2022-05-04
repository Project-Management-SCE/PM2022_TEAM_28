using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHoly.Models;

namespace WebHoly.ViewModels.ThirdScreen
{
    public class ThirdScreenViewModel
    {
        public string SinagugName { get; set; }

        public Halachot Halachot { get; set; }

        public HebrewDateViewModel HebrewDate { get; set; }
    }
}
