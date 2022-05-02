using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebHoly.ViewModels
{
    public class TimesViewModel
    {
        [Display(Name = "times")]
        public TodayTimeApiTimeViewModel times { get; set; }

        [Display(Name = "date")]
        public DateTime date { get; set; }

        [Display(Name = "location")]
        public TodayTimeApiLocationViewModel location { get; set; }

    }

}
