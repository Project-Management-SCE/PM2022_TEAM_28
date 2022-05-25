using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebHoly.Data;
using WebHoly.Models;
using WebHoly.Service.PayPalHelper;
using WebHoly.ViewModels;
using WebHoly.Service;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using IEmailSender = WebHoly.Service.IEmailSender;

namespace WebHoly.Controllers
{
    public class HolySubscriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public IConfiguration _configuration { get; }
        public IEmailSender _emailSender { get; }
        public HolySubscriptionViewModel UserHoly { get; private set; }


        public HolySubscriptionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _emailSender = emailSender;
        }
        // GET: HolySubscriptions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HolySubscription.Include(h => h.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HolySubscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holySubscription = await _context.HolySubscription
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holySubscription == null)
            {
                return NotFound();
            }

            return View(holySubscription);
        }

        // GET: HolySubscriptions/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: HolySubscriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel holySubscription)
        {
            var objComplex = HttpContext.Session.GetObject<HolySubscriptionViewModel>("UserHoly");

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = objComplex.Email, Email = objComplex.Email, };
                var result = await _userManager.CreateAsync(user, objComplex.Password);

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "HolyUser").Wait();

                    var Holysub = new HolySubscription
                    {
                        Community = objComplex.Community,
                        Address = objComplex.Address,
                        CreatedDate = DateTime.Now,
                        FirstName = objComplex.FirstName,
                        Phone = objComplex.Phone,
                        UserId = user.Id,
                        IdentityNumber = objComplex.IdentityNumber != null ? objComplex.IdentityNumber : "123",
                        Last4Digits = objComplex.Last4Digits != null ? objComplex.Last4Digits.ToString().PadLeft(4, '0') : "0000",
                        TokenNumber = DateTime.Now.ToString("dd:MM:yyyy") + objComplex.FirstName + objComplex.IdentityNumber,
                        City = objComplex.City
                    };
                    _context.HolySubscription.Add(Holysub);
                    _context.SaveChanges();

                    var holyPayment = new Payment
                    {
                        Aproved = true,
                        HolySubscriptionId = Holysub.Id,
                        ReceptionNumber = RecipteNumber(),
                        PaymentDate = DateTime.Now,
                        Price = 199,
                    };
                    _context.Payment.Add(holyPayment);

                    _context.SaveChanges();
                    RecipteSend(objComplex.Email, objComplex.Password);
                }
                return View("success");
            }
            ViewBag.error = "שם משתמש כבר קיים ממערכת";
            return View("error");
        }


        // GET: HolySubscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holySubscription = await _context.HolySubscription.FindAsync(id);
            if (holySubscription == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", holySubscription.UserId);
            return View(holySubscription);
        }

        // POST: HolySubscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Address,Phone,CreatedDate,UpdateDate,Last4Digits,TokenNumber,IdentityNumber,FirstName,Community")] HolySubscription holySubscription)
        {
            if (id != holySubscription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(holySubscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HolySubscriptionExists(holySubscription.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", holySubscription.UserId);
            return View(holySubscription);
        }

        // GET: HolySubscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holySubscription = await _context.HolySubscription
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holySubscription == null)
            {
                return NotFound();
            }

            return View(holySubscription);
        }

        // POST: HolySubscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var holySubscription = await _context.HolySubscription.FindAsync(id);
            _context.HolySubscription.Remove(holySubscription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HolySubscriptionExists(int id)
        {
            return _context.HolySubscription.Any(e => e.Id == id);
        }


        public IActionResult Payment()
        {
            var objComplex = HttpContext.Session.GetObject<HolySubscriptionViewModel>("UserHoly");
            return View();
        }

        [HttpPost]
        [Route("checkout")]
        public async Task<IActionResult> PayPalPayment()
        {
            var objComplex = HttpContext.Session.GetObject<HolySubscriptionViewModel>("UserHoly");

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = objComplex.Email, Email = objComplex.Email, };
                var result = await _userManager.CreateAsync(user, objComplex.Password);

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "HolyUser").Wait();
                    var Holysub = new HolySubscription
                    {
                        Community = objComplex.Community,
                        Address = objComplex.Address,
                        CreatedDate = DateTime.Now,
                        FirstName = objComplex.FirstName,
                        Phone = objComplex.Phone,
                        UserId = user.Id,
                        IdentityNumber = objComplex.IdentityNumber != null ? objComplex.IdentityNumber : "123",
                        Last4Digits = objComplex.Last4Digits != null ? objComplex.Last4Digits.ToString().PadLeft(4, '0') : "0000",
                        TokenNumber = DateTime.Now.ToString("dd:MM:yyyy") + objComplex.FirstName + objComplex.IdentityNumber,
                    };
                    _context.HolySubscription.Add(Holysub);
                    _context.SaveChanges();

                    var holyPayment = new Payment
                    {
                        Aproved = true,
                        HolySubscriptionId = Holysub.Id,
                        ReceptionNumber = RecipteNumber(),
                        PaymentDate = DateTime.Now,
                        Price = 199,

                    };
                    _context.Payment.Add(holyPayment);

                    _context.SaveChanges();
                }
            }
            else
            {
                ViewBag.error = "שם משתמש כבר קיים ממערכת";
                return View("error");
            }
            var payPalAPI = new PayPalApi(_configuration);
            string url = await payPalAPI.GetRedirectURLToPayPal(199, "ILS");
            return Redirect(url);
        }
        [HttpPost]
        public IActionResult PaymentSave(HolySubscriptionViewModel holySubscription)
        {
            HttpContext.Session.SetObject("UserHoly", holySubscription);
            return RedirectToAction("Payment");
        }
        [Route("success")]
        public async Task<IActionResult> Success([FromQuery(Name = "paymentId")] string paymentId, [FromQuery(Name = "accessToken")] string accessToken,
             [FromQuery(Name = "PayerID")] string PayerID)
        {
            var payPalAPI = new PayPalApi(_configuration);
            var result = await payPalAPI.exectedPayment(paymentId, PayerID);
            ViewBag.result = result;
            return View("Success");
        }
        [Route("cancel")]
        public async Task<IActionResult> Cancel([FromQuery(Name = "accessToken")] string accessToken)
        {

            return RedirectToAction("Create");
        }

        [HttpGet]
        public void RecipteSend(string email, string password)
        {
            var user = _context.Users.Where(x => x.Email == email).FirstOrDefault();
            var HolySub = _context.HolySubscription.Where(x => x.UserId == user.Id).FirstOrDefault();
            var payment = _context.Payment.Where(x => x.HolySubscriptionId == HolySub.Id).FirstOrDefault();
            string body = "<html> <body dir='rtl'>" +

                " <h2> " + HolySub.FirstName + " תודה רבה על הרשמתך ל WebHoly</h2>" +
                "<span> הסכום ששולם : " + payment.Price + "  בתאריך : " + payment.PaymentDate + "</span> " +
                "<strong> מספר קבלה :" + payment.ReceptionNumber + "</strong>" +
                "<div> שם משתמש :" + email + " </div> <div> סיסמה : " + password +
                "</body></html>";

            var message = new Message(new string[] { email }, "ברוכים הבאים ל WebHoly ", body);
            _emailSender.SendEmail(message);
            //var mail = new Mails()
            //{
            //    Email = email,
            //    SendDate = DateTime.Now,
            //};
            //_context.Add(mail);
            //_context.SaveChanges();
        }

        public int RecipteNumber()
        {
            var payment = _context.Payment.OrderBy(x => x.PaymentDate).Select(x => x.ReceptionNumber).FirstOrDefault();
            return payment + 1;
        }


        public IActionResult PersonalArea()
        {
            var userName = HttpContext.User.Identity.Name;
            if (userName != null)
            {
                var user = _context.Users.Where(x => x.Email == userName).Select(s => s.Id).FirstOrDefault();
                var holyUser = _context.HolySubscription.Where(x => x.UserId == user)
                    .Include(x => x.User)
                    .Include(x => x.Payment).ToList();
                return View(holyUser);
            }
            return View();
        }

        public async Task<IActionResult> PersonalAreaEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var HolySubscription = await _context.HolySubscription.Where(x => x.Id == id).Include(x => x.User).FirstOrDefaultAsync();
            if (HolySubscription == null)
            {
                return NotFound();
            }
            var model = new HolyPersonalAreaViewModel()
            {
                Address = HolySubscription.Address,
                Email = HolySubscription.User.Email,
                FirstName = HolySubscription.FirstName,
                Id = HolySubscription.Id,
                City = HolySubscription.City,
                PhoneNumber = HolySubscription.City
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PersonalAreaEdit(HolyPersonalAreaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.HolySubscription.Where(x => x.Id == model.Id).Include(x => x.User).FirstOrDefault();
                var email = user.User.Email;
                user.Address = model.Address;
                user.FirstName = model.FirstName;
                user.User.Email = model.Email;
                user.User.UserName = model.Email;
                user.User.NormalizedEmail = model.Email.ToUpper();
                user.User.NormalizedUserName = model.Email.ToUpper();
                user.City = model.City;
                user.Phone = model.PhoneNumber;
                _context.SaveChanges();
                if (email != model.Email)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("PersonalArea");
            }
            return View(model);
        }

    }
}
//123@aA123 
