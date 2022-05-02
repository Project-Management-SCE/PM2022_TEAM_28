using System.ComponentModel.DataAnnotations;

namespace WebHoly.ViewModels
{
    public class LeyningApiViewModel
    {
        [Display(Name = "1")]
        public string one {get;set;}

        [Display(Name = "2")]
        public string two { get; set; }

        [Display(Name = "3")]
        public string three { get; set; }

        [Display(Name = "4")]
        public string four { get; set; }

        [Display(Name = "5")]
        public string five { get; set; }

        [Display(Name = "torah")]
        public string torah { get; set; }

        [Display(Name = "haftarah")]
        public string haftarah { get; set; }

        [Display(Name = "maftir")]
        public string maftir { get; set; }

    }
}