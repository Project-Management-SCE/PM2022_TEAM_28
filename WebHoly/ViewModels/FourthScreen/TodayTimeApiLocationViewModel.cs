using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.ViewModels
{
    public class TodayTimeApiLocationViewModel
    {
        [Display(Name = "name")]
        public string name { get; set; }
        [Display(Name = "latitude")]
        public double latitude { get; set; }
        [Display(Name = "longitude")]
        public double longitude { get; set; }
        [Display(Name = "il")]
        public bool il { get; set; }
        [Display(Name = "tzid")]
        public string tzid { get; set; }
        [Display(Name = "cc")]
        public string cc { get; set; }
        [Display(Name = "geoid")]
        public int geoid { get; set; }
        [Display(Name = "geo")]
        public string geo { get; set; }

        [Display(Name = "geonameid")]
        public int geonameid { get; set; }

        [Display(Name = "admin1")]
        public string admin1 { get; set; }
    }
}
