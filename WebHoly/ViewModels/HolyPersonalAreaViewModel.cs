using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.ViewModels
{
    public class HolyPersonalAreaViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name ="שם מלא")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "עיר")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "מייל")]
        public string Email { get; set; }

        [Display(Name = "כתובת")]
        public string Address { get; set; }

        [Display(Name = "מספר פלאפון")]
        public string PhoneNumber { get; set; }

    }
}
