using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.ViewModels
{
    public class RegularPersonalAreaViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "שם מלא")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "גיל")]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "מייל")]
        public string Email { get; set; }

    }
}
