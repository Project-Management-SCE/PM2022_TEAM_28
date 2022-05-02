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

        public async Task<IActionResult> FourthScreen()
        {
                var userName = HttpContext.User.Identity.Name;
            if(userName != null)
            {
                var user =  _context.Users.Where(x => x.Email == userName).Select(s => s.Id).FirstOrDefault();
                var Holyuser =  _context.HolySubscription.Where(x => x.UserId == user).FirstOrDefault();
                var x = _apiController.TodayTimeHebcal(Holyuser.City);
                var todayTime = await _apiController.TodayTimeAsync(x.CityId,x.TodayDate);
                var hebrewDate = await _apiController.HebrewDate();
                if (todayTime != null&& hebrewDate != null)
                {
                    var allTime = new AllTimeViewModel()
                    {
                        Times = todayTime,
                        HebrewDate = hebrewDate,
                         SinagugName = Holyuser.FirstName != null ? Holyuser.FirstName : ""
                        
                    };

                    return View(allTime);
                }
            }
            return View("index");
        }
    }
}
