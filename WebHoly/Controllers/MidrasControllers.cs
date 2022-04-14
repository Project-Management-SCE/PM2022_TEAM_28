using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHoly.Controllers
{
    public class MidrasControllers : Controller
    {
        //private readonly IHttpClieantFactory +
        public IActionResult Index()
        {
            return View();
        }
    }
}
