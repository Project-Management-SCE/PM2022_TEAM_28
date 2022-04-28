﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebHoly.ViewModels;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebHoly.Controllers
{
    public class ApiController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public IEnumerable<MidrasViewModel> midras { get; set; }
        const string BASE_URL = "https://www.sefaria.org/";

        public ApiController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShabbatApiHebcal(string City)
        {

            ////https://www.hebcal.com/home/195/jewish-calendar-rest-api#lg
            //var Allcitys = citys();
            //if (Allcitys.ContainsKey(City))
            //{
            //    ViewBag.city = Allcitys.Values;
            //}

            return View();

        }
        public IActionResult JewishCalendarHebcal(int cityId)
        {
            //https://www.hebcal.com/hebcal?v=1&cfg=json&maj=on&min=on&mod=on&nx=on&year=now&month=x&ss=on&mf=on&c=on&geo=geoname&geonameid=295530&M=on&s=on expmle לוח שנה 
            //using a java scrip and load the info from Hebcal Api
            return View(cityId);
        }
        public IActionResult ShabbatTimesHebcal(string cityId)
        {
            //https://www.hebcal.com/shabbat?cfg=json&geonameid=3448439&M=on זמני שבת
            //using a java scrip and load the info from Hebcal Api
            return View(cityId);
        }
        public IActionResult HebrewdatesHebcal()
        {
            //using a java scrip and load the info from Hebcal Api
            return View();
        }

        public TodayTimeHebcalViewModel TodayTimeHebcal(string cityName)
        {
            //https://www.hebcal.com/zmanim?cfg=json&geonameid=3448439&date=2022-03-23 זמני היום 
            TodayTimeHebcalViewModel TodayTimeHebcalModel;
            string cityId = citys(cityName);
            if(cityId !=null)
            {
                TodayTimeHebcalModel = new TodayTimeHebcalViewModel
                {
                    TodayDate = DateTime.Now,
                    CityId = cityId
                };
                //using a java scrip and load the info from Hebcal Api
            }
            else
            {
                TodayTimeHebcalModel = new TodayTimeHebcalViewModel
                {
                    TodayDate = DateTime.Now,
                    CityId = "281184"
                };
            }
            return TodayTimeHebcalModel;
        }

        public string citys(string cityName)
        {
            Dictionary<string, string> citys = new Dictionary<string, string>();
            citys.Add("אשדוד", "295629");
            citys.Add("אשקלון", "295620");
            citys.Add("בת ים", "295548");
            citys.Add("באר שבע", "295530");
            citys.Add("בית שמש", "295432");
            citys.Add("בני ברק", "295514");
            citys.Add("אילת", "295277");
            citys.Add("חדרה", "294946");
            citys.Add("חיפה", "294801");
            citys.Add("הרצליה", "294778");
            citys.Add("חולון", "294751");
            citys.Add("ירשולים", "281184");
            citys.Add("כפר סבא", "294514");
            citys.Add("לוד", "294421");
            citys.Add("מודיעין", "282926");
            citys.Add("נצרת", "294098");
            citys.Add("נתניה", "294071");
            citys.Add("תל אביב", "293397");
            citys.Add("טבריה", "293322");
            citys.Add("פתח תקווה", "293918");
           foreach(var item in citys)
            {
                if (cityName == item.Key)
                    return item.Value;
            }
            return null;
        }

        public IActionResult BiblebookApi(string book)
        {
            ViewBag.book = book;
            return View(book);
        }
        public IActionResult BibleApichapter(int sChapter, int sVrse, int eChapter, int eVrse)
        {
            //http://ibibles.net/quote.php?hmv-@book/@sChapter:@sVrse-@eChapter:@eVrse
            var model = new BiblesViewModel
            {
                Book = ViewBag.book,
                SChapter = sChapter,
                SVrse = sVrse,
                EChapter = eChapter,
                EVrse = eVrse
            };
            return View(model);
        }
        public async Task<IActionResult> MidrasSefariaApi(string book, int sChapter, int eChapter)
        {

            using (var client = new HttpClient())
            {
                var message = new HttpRequestMessage();
                message.Method = HttpMethod.Get; 
                message.RequestUri = new Uri($"{BASE_URL}api/links/${book}.${sChapter}.${eChapter}");
                message.Headers.Add("Accept", "application/json");
                var clients = _clientFactory.CreateClient();

                var response = await client.SendAsync(message);
                if (response.IsSuccessStatusCode)
                {
                    var readjob = await response.Content.ReadAsStreamAsync();

                    midras = await JsonSerializer.DeserializeAsync <IEnumerable<MidrasViewModel>>(readjob);
                }
                else
                {
                    midras = Array.Empty<MidrasViewModel>();
                }
            }

            return View(midras);
        }
    }
}
