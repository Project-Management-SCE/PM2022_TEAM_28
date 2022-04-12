using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.Models
{
    public class SoulBoard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime DateOfDeathForeign { get; set; }
        public string DateOfDeathHebrew { get; set; }
        public int HolySubscriptionId { get; set; }

        public virtual HolySubscription HolySubscription { get; set; }
    }
}
