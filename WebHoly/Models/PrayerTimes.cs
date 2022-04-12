using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.Models
{
    public class PrayerTimes
    {
        public int Id { get; set; }
        public System.TimeSpan ShacharitPrayer { get; set; }
        public System.TimeSpan InauguralPrayer { get; set; }
        public System.TimeSpan MaarivPrayer { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public int HolySubscriptionId { get; set; }

        public virtual HolySubscription HolySubscription { get; set; }
    }
}
