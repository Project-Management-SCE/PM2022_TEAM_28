using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebHoly.Data;
using WebHoly.Models;
using WebHoly.Service.PayPalHelper;
using WebHoly.ViewModels;

namespace WebHoly.Controllers
{
    public class HolySubscriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public IConfiguration _configuration { get; }
        public HolySubscriptionsController(ApplicationDbContext context, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
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
        public async Task<IActionResult> Create(HolySubscriptionViewModel holySubscription)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = holySubscription.Email, Email = holySubscription.Email, };
                var result = await _userManager.CreateAsync(user, holySubscription.Password);
                if (result.Succeeded)
                {
                    var Holysub = new HolySubscription
                    {
                        Community = holySubscription.Community,
                        Address = holySubscription.Address,
                        CreatedDate = DateTime.Now,
                        FirstName = holySubscription.FirstName,
                        Phone = holySubscription.Phone,
                        UserId = user.Id,
                        IdentityNumber = holySubscription.IdentityNumber!=null? holySubscription.IdentityNumber:"123",
                        Last4Digits = holySubscription.Last4Digits.ToString().PadLeft(4, '0'),
                        TokenNumber = DateTime.Now.ToString("dd:MM:yyyy") + holySubscription.FirstName + holySubscription.IdentityNumber,
                    };
                    _context.HolySubscription.Add(Holysub);
                    _context.SaveChanges();

                    var holyPayment = new Payment
                    {
                        Aproved = true,
                        HolySubscriptionId = Holysub.Id,
                        ReceptionNumber = 1,//until we will do a recept in sprint 2
                        PaymentDate = DateTime.Now,
                        Price = 199,

                    };
                    _context.Payment.Add(holyPayment);

                    _context.SaveChanges();
                }
                return View("Success");
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

        [HttpPost]
        [Route("checkout")]
        public async Task<IActionResult> PayPalPayment(HolySubscriptionViewModel model)
        {
            TempData["User"] = model;
            var payPalAPI = new PayPalApi(_configuration);
            string url = await payPalAPI.GetRedirectURLToPayPal(199, "ILS");
            return Redirect(url); 
        }
        [Route("success")]
        public async Task<IActionResult> Success([FromQuery(Name="paymentId")] string paymentId,
            [FromQuery(Name = "PayerID")] string PayerID)
        {
            var payPalAPI = new PayPalApi(_configuration);
            var result = await payPalAPI.exectedPayment(paymentId, PayerID);

            ViewBag.result = result;
            return RedirectToAction("Create", TempData["User"]);
        }
    }
}
