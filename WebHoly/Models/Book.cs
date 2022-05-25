using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string SubName { get; set; }
        public int BookTypeId { get; set; }
    }
}
