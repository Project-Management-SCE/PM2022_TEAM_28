using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.Models
{
    public class RegularSubscription
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public bool Gender { get; set; }
        public Nullable<int> TopicsOfInterest { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string Community { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
