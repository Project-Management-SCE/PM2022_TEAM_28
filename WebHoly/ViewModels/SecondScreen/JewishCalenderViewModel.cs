using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.ViewModels
{
    public class JewishCalenderViewModel
    {

        [Display(Name = "title")]
        public string title { get; set; }

        [Display(Name = "times")]
        public List<ItemsApiViewModel> items { get; set; }

        [Display(Name = "date")]
        public DateTime date { get; set; }

        [Display(Name = "location")]
        public JewishCalenderApiLocationViewModel location { get; set; }
    }
}