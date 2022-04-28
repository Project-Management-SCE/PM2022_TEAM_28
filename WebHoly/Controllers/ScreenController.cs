using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHoly.ViewModels;
using WebHoly.Controllers;
using Microsoft.AspNetCore.Http;
using WebHoly.Data;

namespace WebHoly.Controllers
{
    public class ScreenController : Controller
    {
        private Controllers.ApiController _apiController;
        private readonly ApplicationDbContext _context;

        public ScreenController(ApiController apiController,ApplicationDbContext context)
        {
            _apiController = apiController;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FourthScreen()
        {
            var user = HttpContext.User.Identity.Name;
            if(user != null)
            {
                
                //var city = _context.HolySubscription.Where(x => x.UserId == user.id).select(s => s.city);
                TodayTimeHebcalViewModel x = _apiController.TodayTimeHebcal("באר שבע");
                return View();
            }
            return View("index");
        }
    }
}
