using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.Models
{
    public class SoulBoard
    {
        public int Id { get; set; }
        [Display(Name="שם הנפטר")]
        public string Name { get; set; }

        [Display(Name = "תאריך לועזי")]
        public System.DateTime DateOfDeathForeign { get; set; }
        [Display(Name = "תאריך עברי")]
        public string DateOfDeathHebrew { get; set; }
        public int HolySubscriptionId { get; set; }

        public DateTime UpdatedTime { get; set; }

        public virtual HolySubscription HolySubscription { get; set; }
    }
}
