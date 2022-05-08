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
using WebHoly.ViewModels.ThirdScreen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebHoly.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index()
        {


            var userName = HttpContext.User.Identity.Name;
            if (userName != null)
            {
                var screenCssViewModel = new ScreenCssTypeViewModel();
                var user = _context.Users.Where(x => x.Email == userName).Select(s => s.Id).FirstOrDefault();
                var Holyuser = _context.HolySubscription.Where(x => x.UserId == user).FirstOrDefault();
                var x = _apiController.TodayTimeHebcal(Holyuser.City);
                var todayTime = await _apiController.TodayTimeAsync(x.CityId, x.TodayDate);
                var hebrewDate = await _apiController.HebrewDate();
                var halachot = _context.Halachot.ToList().OrderBy(x => x.ViewDate).FirstOrDefault();
                var prayTimes = _context.PrayerTimes.Where(x => x.HolySubscriptionId == Holyuser.Id).FirstOrDefault();
                var jewishCalender = await _apiController.JewishCalendarAsync(x.CityId, x.TodayDate);
                halachot.ViewDate = DateTime.Now;
                _context.SaveChanges();

                var screenCss = _context.ScreenCssTypes.Where(x => x.HolySubscriptionId == Holyuser.Id).FirstOrDefault();
                if (screenCss != null)
                {
                    screenCssViewModel = new ScreenCssTypeViewModel
                    {
                        PictureType = screenCss.PictureType,
                        FontSize = screenCss.FontSize + "px",
                        FontType = screenCss.FontType,
                        FontColor = screenCss.FontColor,
                    };
                }
                else
                {
                    screenCssViewModel = new ScreenCssTypeViewModel
                    {
                        PictureType = "Golden.jpg",
                        FontSize = "14px",
                        FontType = "Arial",
                        FontColor = "black"
                    };
                }
                var details = new ScreenVieModel()
                {
                    Times = todayTime,
                    HebrewDate = hebrewDate,
                    SinagugName = Holyuser.FirstName != null ? Holyuser.FirstName : "",
                    Halachot = halachot,
                    JewishCalender = jewishCalender,
                    PrayerTimes = prayTimes,
                    ScreenCssType = screenCssViewModel
                };
                return View(details);
            }
            return View("index");
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
                    PrayerTimes = prayTimes,
                    HebrewDate = hebrewDate
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

        public async Task<IActionResult> ThirdScreenAsync()
        {
            var userName = HttpContext.User.Identity.Name;
            if (userName != null)
            {
                var user = _context.Users.Where(x => x.Email == userName).Select(s => s.Id).FirstOrDefault();
                var Holyuser = _context.HolySubscription.Where(x => x.UserId == user).FirstOrDefault();
                var halachot = _context.Halachot.ToList().OrderBy(x => x.ViewDate).FirstOrDefault();
                halachot.ViewDate = DateTime.Now;
                _context.SaveChanges();
                var hebrewDate = await _apiController.HebrewDate();
                var details = new ThirdScreenViewModel()
                {
                    SinagugName = Holyuser.FirstName != null ? Holyuser.FirstName : "",
                    Halachot = halachot,
                    HebrewDate = hebrewDate
                };
                return View(details);
            }
            return View("index");

        }


        [Authorize]
        public IActionResult CssChange()
        {
            ViewBag.FontSize = new SelectList(new List<int> { 14, 16, 18, 20 });
            ViewBag.FontType = new SelectList(new List<string> { "Arial", "David", "Candara", "Times New Roman" });
            ViewBag.PictureType = new SelectList(new List<string> { "tample.jpeg", "Golden.jpg", "holy.png", "Wall.jpg", "WallView.jpg" });
            ViewBag.FontColor = new SelectList(new List<string> { "white", "sliver", "black", "gold" });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CssChange(ScreenCssType screenCssType)
        {
            var userid = await _context.Users.Where(x => x.Email == HttpContext.User.Identity.Name).Select(s => s.Id).FirstOrDefaultAsync();
            var holyUser = await _context.HolySubscription.Where(x => x.UserId == userid).FirstOrDefaultAsync();
            var allSoulCss = await _context.ScreenCssTypes.Where(x => x.HolySubscriptionId == holyUser.Id).FirstOrDefaultAsync();
            if (allSoulCss == null)
            {
                screenCssType.HolySubscriptionId = holyUser.Id;
                screenCssType.LastUpdate = DateTime.Now;
                _context.ScreenCssTypes.Add(screenCssType);
                _context.SaveChanges();
            }
            else
            {
                allSoulCss.Id = allSoulCss.Id;
                allSoulCss.FontSize = screenCssType.FontSize;
                allSoulCss.FontType = screenCssType.FontType;
                allSoulCss.PictureType = screenCssType.PictureType;
                allSoulCss.FontColor = screenCssType.FontColor;
                allSoulCss.LastUpdate = DateTime.Now;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}
