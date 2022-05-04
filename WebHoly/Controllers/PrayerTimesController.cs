using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHoly.Data;
using WebHoly.Models;

namespace WebHoly.Controllers
{
    public class PrayerTimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrayerTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userName = HttpContext.User.Identity.Name;
            if (userName != null)
            {
                var user = _context.Users.Where(x => x.Email == userName).Select(s => s.Id).FirstOrDefault();
                var Holyuser = _context.HolySubscription.Where(x => x.UserId == user).FirstOrDefault();
                return View(_context.PrayerTimes.Where(x => x.HolySubscriptionId ==Holyuser.Id).FirstOrDefault());

            }
            return RedirectToAction("Login");

        }

        public IActionResult Create()
        {
            ViewData["HolySubscriptionId"] = new SelectList(_context.HolySubscription, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PrayerTimes prayerTimes)
        {
            var userName = HttpContext.User.Identity.Name;
            if (userName != null)
            {
                var user = _context.Users.Where(x => x.Email == userName).Select(s => s.Id).FirstOrDefault();
                var Holyuser = _context.HolySubscription.Where(x => x.UserId == user).Select(s => s.Id).FirstOrDefault();
                prayerTimes.HolySubscriptionId = Holyuser;
                if (ModelState.IsValid)
                {
                    _context.Add(prayerTimes);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["HolySubscriptionId"] = new SelectList(_context.HolySubscription, "Id", "Id", prayerTimes.HolySubscriptionId);
            return View(prayerTimes);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var PrayerTimes = await _context.PrayerTimes.FindAsync(id);
            if (PrayerTimes == null)
            {
                return NotFound();
            }
            ViewData["HolySubscriptionId"] = new SelectList(_context.HolySubscription, "Id", "Id", PrayerTimes.HolySubscriptionId);
            return View(PrayerTimes);
        }

        // POST: SoulBoards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShacharitPrayer,InauguralPrayer,MaarivPrayer,HolySubscriptionId,UpdateTime")] PrayerTimes prayerTimes)
        {
            if (id != prayerTimes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    prayerTimes.UpdateTime = DateTime.Now; 
                    _context.Update(prayerTimes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!prayerTimesExists(prayerTimes.Id))
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
            ViewData["HolySubscriptionId"] = new SelectList(_context.HolySubscription, "Id", "Id", prayerTimes.HolySubscriptionId);
            return View(prayerTimes);
        }

        private bool prayerTimesExists(int id)
        {
            return _context.PrayerTimes.Any(e => e.Id == id);
        }
    }
}
