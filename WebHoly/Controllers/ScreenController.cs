using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHoly.ViewModels;
using WebHoly.Controllers;
using Microsoft.AspNetCore.Http;
using WebHoly.Data;
using WebHoly.ViewModels.SecondScreen;

namespace WebHoly.Controllers
{
    public class ScreenController : Controller
    {
        private Controllers.ApiController _apiController;
        private readonly ApplicationDbContext _context;

        public ScreenController(ApiController apiController, ApplicationDbContext context)
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
            if (userName != null)
            {
                var user = _context.Users.Where(x => x.Email == userName).Select(s => s.Id).FirstOrDefault();
                var Holyuser = _context.HolySubscription.Where(x => x.UserId == user).FirstOrDefault();
                var x = _apiController.TodayTimeHebcal(Holyuser.City);
                var todayTime = await _apiController.TodayTimeAsync(x.CityId, x.TodayDate);
                var hebrewDate = await _apiController.HebrewDate();
                if (todayTime != null && hebrewDate != null)
                {
                    var details = new FourthScreenViewModel()
                    {
                        Times = todayTime,
                        HebrewDate = hebrewDate,
                        SinagugName = Holyuser.FirstName != null ? Holyuser.FirstName : ""

                    };

                    return View(details);
                }
            }
            return View("index");
        }
        public async Task<IActionResult> FirstScreen()
        {

            var userName = HttpContext.User.Identity.Name;
            if (userName != null)
            {
                var user = _context.Users.Where(x => x.Email == userName).Select(s => s.Id).FirstOrDefault();
                var Holyuser = _context.HolySubscription.Where(x => x.UserId == user).FirstOrDefault();
                var prayTimes = _context.PrayerTimes.Where(x => x.HolySubscriptionId == Holyuser.Id).FirstOrDefault();
                var hebrewDate = await _apiController.HebrewDate();

                var details = new FirstScreenViewModel()
                {
                    SinagugName = Holyuser.FirstName != null ? Holyuser.FirstName : "",
                    PrayerTimes =prayTimes,
                    HebrewDate =hebrewDate
                };
                return View(details);
            }
            return View("index");

        }
        public async Task<IActionResult> SecondScreen()
        {

            var userName = HttpContext.User.Identity.Name;
            if (userName != null)
            {
                var user = _context.Users.Where(x => x.Email == userName).Select(s => s.Id).FirstOrDefault();
                var Holyuser = _context.HolySubscription.Where(x => x.UserId == user).FirstOrDefault();
                var hebrewDate = await _apiController.HebrewDate();
                var x = _apiController.TodayTimeHebcal(Holyuser.City);
                var jewishCalender = await _apiController.JewishCalendarAsync(x.CityId, x.TodayDate);
                var details = new SecondScreenViewModel()
                {
                    SinagugName = Holyuser.FirstName != null ? Holyuser.FirstName : "",
                    JewishCalender = jewishCalender,
                    HebrewDate = hebrewDate
                };
                return View(details);
            }
            return View("index");

        }
    }
}
