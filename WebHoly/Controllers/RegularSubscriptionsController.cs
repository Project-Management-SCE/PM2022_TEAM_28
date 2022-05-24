using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHoly.Data;
using WebHoly.Models;
using WebHoly.ViewModels;

namespace WebHoly.Controllers
{
    public class RegularSubscriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegularSubscriptionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: RegularSubscriptions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegularSubscription.Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegularSubscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regularSubscription = await _context.RegularSubscription
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regularSubscription == null)
            {
                return NotFound();
            }

            return View(regularSubscription);
        }

        // GET: RegularSubscriptions/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            var sex_items = new List<SelectListItem>
            {
                new SelectListItem() { Text = "נקבה", Value = "נקבה" },
                new SelectListItem() { Text = "זכר", Value = "זכר" }
            };

            ViewBag.Sex = sex_items;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegularSubscriptionViewModel regularSubscription)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = regularSubscription.Email, Email = regularSubscription.Email, };
                var result = await _userManager.CreateAsync(user, regularSubscription.Password);
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "RegularUser").Wait();

                    var regulerSub = new RegularSubscription
                    {
                        Community = regularSubscription.Community,
                        Age = regularSubscription.Age,
                        CreatedDate = DateTime.Now,
                        FirstName = regularSubscription.FirstName,
                        Gender = regularSubscription.Gender != "זכר",
                        UserId = user.Id,
                    };
                    _context.RegularSubscription.Add(regulerSub);
                    _context.SaveChanges();
                }
                return RedirectToAction("thanks", "Home");
            }
            return View("error");

        }
        // GET: RegularSubscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regularSubscription = await _context.RegularSubscription.FindAsync(id);
            if (regularSubscription == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", regularSubscription.UserId);
            return View(regularSubscription);
        }

        // POST: RegularSubscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,CreatedDate,UpdateDate,Gender,TopicsOfInterest,Age")] RegularSubscription regularSubscription)
        {
            if (id != regularSubscription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regularSubscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegularSubscriptionExists(regularSubscription.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", regularSubscription.UserId);
            return View(regularSubscription);
        }

        // GET: RegularSubscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regularSubscription = await _context.RegularSubscription
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regularSubscription == null)
            {
                return NotFound();
            }

            return View(regularSubscription);
        }

        // POST: RegularSubscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regularSubscription = await _context.RegularSubscription.FindAsync(id);
            _context.RegularSubscription.Remove(regularSubscription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegularSubscriptionExists(int id)
        {
            return _context.RegularSubscription.Any(e => e.Id == id);
        }


        

    }
}
