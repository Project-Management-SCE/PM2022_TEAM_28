using Microsoft.AspNetCore.Mvc;
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

            //https://www.hebcal.com/home/195/jewish-calendar-rest-api#lg
            var Allcitys = citys();
            if (Allcitys.ContainsKey(City))
            {
                ViewBag.city = Allcitys.Values;
            }

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

        public IActionResult TodayTimeHebcal(string cityId)
        {
            //https://www.hebcal.com/zmanim?cfg=json&geonameid=3448439&date=2021-03-23 זמני היום 

            TodayTimeHebcalViewModel model = new TodayTimeHebcalViewModel
            {
                TodayDate = DateTime.Now,
                CityId = cityId
            };
            //using a java scrip and load the info from Hebcal Api
            return View(model);
        }

        public Dictionary<string, string> citys()
        {
            Dictionary<string, string> citys = new Dictionary<string, string>();
            citys.Add("IL - Ashdod", "295629");
            citys.Add("IL - Ashkelon", "295620");
            citys.Add("IL - Bat Yam", "295548");
            citys.Add("IL - Be'er Sheva", "295530");
            citys.Add("IL - Beit Shemesh", "295432");
            citys.Add("IL - Bnei Brak", "295514");
            citys.Add("IL - Eilat", "295277");
            citys.Add("IL - Hadera", "294946");
            citys.Add("IL - Haifa", "294801");
            citys.Add("IL - Herzliya", "294778");
            citys.Add("IL - Holon", "294751");
            citys.Add("IL - Jerusalem", "281184");
            citys.Add("IL - Kfar Saba", "294514");
            citys.Add("IL - Lod", "294421");
            citys.Add("IL - Modiin", "282926");
            citys.Add("IL - Nazareth", "294098");
            citys.Add("IL - Netanya", "294071");
            citys.Add("IL - Tel Aviv", "293397");
            citys.Add("IL - Tiberias", "293322");
            citys.Add("IL - Petach Tikvah", "293918");
            return citys;
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
