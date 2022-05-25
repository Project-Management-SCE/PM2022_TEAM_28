using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.Models
{
    public class BookType
    {
        public int Id { get; set; }

        [Display(Name = "נושא")]
        public string Name { get; set; }

        public string Type { get; set; }

        [NotMapped]
        public int BookId { get; set; }

        [NotMapped]
        public int EpisodeId { get; set; }
    }
}
