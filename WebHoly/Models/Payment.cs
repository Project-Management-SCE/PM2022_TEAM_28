using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public decimal Price { get; set; }
        public int ReceptionNumber { get; set; }
        public int HolySubscriptionId { get; set; }
        public bool Aproved { get; set; }

        public virtual HolySubscription HolySubscription { get; set; }
    }
}
