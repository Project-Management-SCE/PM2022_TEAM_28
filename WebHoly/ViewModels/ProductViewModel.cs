using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.ViewModels
{
    public class ProductViewModel
    {

        [Display(Name = "תעודת זהות ")]
        public string IdNumber { get; set; }

        [Display(Name = "מספר כרטיס ")]
        public string  Last4Dig { get; set; }
    }
}
