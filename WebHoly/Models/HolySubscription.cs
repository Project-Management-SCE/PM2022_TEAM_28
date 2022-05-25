using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.Models
{
    public class HolySubscription
    {
        public HolySubscription()
        {
            this.Payment = new HashSet<Payment>();
            this.PrayerTimes = new HashSet<PrayerTimes>();
            this.SoulBoard = new HashSet<SoulBoard>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Last4Digits { get; set; }
        public string TokenNumber { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string Community { get; set; }
        public string City { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<PrayerTimes> PrayerTimes { get; set; }
        public virtual ICollection<SoulBoard> SoulBoard { get; set; }
    }
}
