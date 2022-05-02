using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebHoly.Models;

namespace WebHoly.ViewModels
{
    public class SoulBoardVIewModel
    {
        public int Id { get; set; }
        public int HolySubscriptionId { get; set; }
        [Display(Name = "גודל כתב")]
        public string FontSize { get; set; }

        [Display(Name = "סוג נר")]
        public string CandleType { get; set; }

        [Display(Name = "סוג כתב")]
        public string FontType { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<SoulBoard> SoulBoard { get; set; }
        public bool SoulBoardZero { get; set; }
    }
}
