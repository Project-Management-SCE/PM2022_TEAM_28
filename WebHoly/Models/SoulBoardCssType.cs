using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.Models
{
    public class SoulBoardCssType
    {
        [Key]
        public int Id { get; set; }
        public int HolySubscriptionId { get; set; }
        [Display(Name ="גודל כתב")]
        public int FontSize { get; set; }

        [Display(Name = "סוג נר")]
        public string CandleType { get; set; }

        [Display(Name = "סוג כתב")]
        public string FontType { get; set; }
        public DateTime LastUpdate { get; set; }
        public virtual HolySubscription HolySubscription { get; set; }

    }
}
