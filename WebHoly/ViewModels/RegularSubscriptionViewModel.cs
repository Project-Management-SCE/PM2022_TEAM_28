using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.ViewModels
{
    public class RegularSubscriptionViewModel
    {
        public string UserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }

        [Display(Name = "מגדר")]
        public string Gender { get; set; }
        public Nullable<int> TopicsOfInterest { get; set; }

        [Required(ErrorMessage = "חובה לרשום גיל")]
        [Display(Name = "גיל")]
        public int Age { get; set; }
        [Required(ErrorMessage = "חובה לרשום מייל")]
        [EmailAddress]
        [Display(Name = "איימל")]
        public string Email { get; set; }
        [Required(ErrorMessage = "סיסמה לא תקינה")]
        [StringLength(100, ErrorMessage = "ה {0} חייבת להכיל {2} בין {1} תויים.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "סיסמה")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "אישור סיסמה")]
        [Compare("Password", ErrorMessage = "הסיסמאות אינן תאומות.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "שם מלא")]
        public string FirstName { get; set; }

        [Display(Name = "קהילה")]
        public string Community { get; set; }



    }
}
