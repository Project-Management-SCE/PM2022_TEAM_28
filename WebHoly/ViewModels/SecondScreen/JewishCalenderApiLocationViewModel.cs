using System.ComponentModel.DataAnnotations;

namespace WebHoly.ViewModels
{
    public class JewishCalenderApiLocationViewModel
    {
        [Display(Name = "title")]
        public string title { get; set; }
        [Display(Name = "latitude")]
        public double latitude { get; set; }
        [Display(Name = "longitude")]
        public double longitude { get; set; }
        [Display(Name = "city")]
        public string city { get; set; }
        [Display(Name = "tzid")]
        public string tzid { get; set; }
        [Display(Name = "cc")]
        public string cc { get; set; }
        [Display(Name = "geonameid")]
        public int geonameid { get; set; }
        [Display(Name = "geo")]
        public string geo { get; set; }

        [Display(Name = "asciiname")]
        public string asciiname { get; set; }

        [Display(Name = "admin1")]
        public string admin1 { get; set; }

        [Display(Name = "country")]
        public string country { get; set; }
       

    }
}