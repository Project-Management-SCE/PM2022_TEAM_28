using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.ViewModels
{
    public class ScreenCssTypeViewModel
    {

        [Display(Name = "גודל כתב")]
        public string FontSize { get; set; }

        [Display(Name = "סוג תמונת רקע ")]
        public string PictureType { get; set; }

        [Display(Name = "צבע רקע")]
        public string FontColor { get; set; }

        [Display(Name = "סוג כתב")]
        public string FontType { get; set; }
    }
}
