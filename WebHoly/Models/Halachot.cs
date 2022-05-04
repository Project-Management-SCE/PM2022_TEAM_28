using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.Models
{
    public class Halachot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string Contents { get; set; }
        public string Source { get; set; }
        public System.DateTime ViewDate { get; set; }


    }
}
