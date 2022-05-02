using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.ViewModels
{
    public class PayPalViewModel
    {
        public string ApiAppName { get; set; }
        public string Account { get; set; }
        public string ClientId { get; set; }
        public string Secret { get; set; }
    }
}
