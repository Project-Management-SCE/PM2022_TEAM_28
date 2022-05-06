using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebHoly.ViewModels.ThirdScreen
{
    public class ShulchanAruchAbbreviationViewModel
    {
        public string language { get; set; }
        public string title { get; set; }
        public string versionSource { get; set; }
        public string versionTitle { get; set; }
        public string status { get; set; }
        public string heversionSource { get; set; }
        public string license { get; set; }
        public string heTitle { get; set; }
        public IEnumerable<string> categories { get; set; }
        public IEnumerable<List<string>> text { get; set; }
    }
}
