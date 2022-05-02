using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.ViewModels
{
    public class HolySubscriptionViewModel
    {
        public string UserId { get; set; }
        [Display(Name = "כתובת ")]
        public string Address { get; set; }
        [Display(Name = "פלאפון ")]
        public string Phone { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        [Display(Name = "מספר כרטיס ")]
        public string Last4Digits { get; set; }
        public string TokenNumber { get; set; }
        [Display(Name = "תעודת זהות ")]

        public string IdentityNumber { get; set; }

        [Display(Name = "שם מלא")]
        public string FirstName { get; set; }
        [Display(Name = "קהילה")]
        public string Community { get; set; }

        public decimal Price { get; set; }
        public bool Aproved { get; set; }

        [Required(ErrorMessage = "חובה לרשום מייל")]
        [EmailAddress]
        [Display(Name = "איימל")]
        public string Email { get; set; }
        [Required(ErrorMessage = "חובה לרשום סיסמה")]
        [StringLength(100, ErrorMessage = "ה {0} חייבת להכיל {2} בין {1} תויים.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "סיסמה")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "אישור סיסמה")]
        [Compare("Password", ErrorMessage = "הסיסמאות אינן תאומות.")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }

    }
}
