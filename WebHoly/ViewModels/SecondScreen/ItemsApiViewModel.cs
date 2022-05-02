using System;
using System.ComponentModel.DataAnnotations;

namespace WebHoly.ViewModels
{
    public class ItemsApiViewModel
    {

        [Display(Name = "title")]
        public string title { get; set; }

        [Display(Name = "date")]
        public DateTime date { get; set; }

        [Display(Name = "category")]
        public string category { get; set; }

        [Display(Name = "title_orig")]
        public string title_orig { get; set; }

        [Display(Name = "hebrew")]
        public string hebrew { get; set; }

        [Display(Name = "subcat")]
        public string subcat { get; set; }

        [Display(Name = "link")]
        public string link { get; set; }

        [Display(Name = "memo")]
        public string memo { get; set; }

        public LeyningApiViewModel leyning { get; set; }

        public bool yomtov { get; set; }
    }
}