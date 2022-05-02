using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.ViewModels
{
    public class TodayTimeApiTimeViewModel
    {
        
        [Display(Name = "chatzotNight")]
        public DateTime chatzotNight { get; set; } //חצות הלילה

        [Display(Name = "alotHaShachar")]
        public DateTime alotHaShachar { get; set; } // עלות השחר

        [Display(Name = "misheyakir")]
        public DateTime misheyakir { get; set; } // זמן טלית ותפילין 

        [Display(Name = "misheyakirMachmir")]
        public DateTime misheyakirMachmir { get; set; } // זמן מחמיר טלית ותפילין

        [Display(Name = "sunrise")]
        public DateTime sunrise { get; set; }// דמדומים אזרחיים מסתיימים (הנחץ החמה זריחה

        [Display(Name = "dawn")]
        public DateTime dawn { get; set; } //(הנחץ החמה זריחה

        [Display(Name = "sofZmanShma")]
        public DateTime sofZmanShma { get; set; } //סוף זמן תפילה הגר"א

        [Display(Name = "sofZmanTfillaMGA")]
        public DateTime sofZmanTfillaMGA { get; set; } //סוף זמן תפילה מג"א

        [Display(Name = "chatzot")]
        public DateTime chatzot { get; set; } //חצות 

        [Display(Name = "minchaGedola")]
        public DateTime minchaGedola { get; set; } // מנחה גדולה

        [Display(Name = "minchaKetana")]
        public DateTime minchaKetana { get; set; } //מנחה קטנה 

        [Display(Name = "plagHaMincha")]
        public DateTime plagHaMincha { get; set; } //פלג המנחה

        [Display(Name = "sunset")]
        public DateTime sunset { get; set; } //שקיעה

        [Display(Name = "dusk")]
        public DateTime dusk { get; set; } //דמדומים

        [Display(Name = "tzeit7083deg")]
        public DateTime tzeit7083deg { get; set; } //צאת הכוכבים

        [Display(Name = "tzeit85deg")]
        public DateTime tzeit85deg { get; set; } //צאת שבת

        [Display(Name = "tzeit72min")]
        public DateTime tzeit72min { get; set; } //יציאת שבת רבנו תם

        [Display(Name = "tzeit42min")]
        public DateTime tzeit42min { get; set; } 

        [Display(Name = "tzeit50min")]
        public DateTime tzeit50min { get; set; } 
    }
}
