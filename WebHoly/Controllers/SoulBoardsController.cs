using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHoly.Data;
using WebHoly.Models;
using WebHoly.ViewModels;

namespace WebHoly.Controllers
{
    [Authorize(Roles = "HolyUser")]
    public class SoulBoardsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SoulBoardVIewModel soulBoardViewModel = null;
        public SoulBoardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SoulBoards
        public IActionResult Index()
        {
            var user = HttpContext.User.Identity.Name;

            if (user != null)
            {
                var userid = _context.Users.Where(x => x.Email == user).Select(s => s.Id).FirstOrDefault();

                if (_context.HolySubscription.Where(x => x.UserId == userid).Any())
                {
                    var holyUser = _context.HolySubscription.Where(x => x.UserId == userid).FirstOrDefault();
                    var soulBoard = _context.SoulBoard.Where(x => x.HolySubscriptionId == holyUser.Id).Include(r => r.HolySubscription).ToList();
                    var soulBoardsCss = _context.SoulBoardCssTypes.Where(x => x.HolySubscriptionId == holyUser.Id).FirstOrDefault();
                    if (soulBoardsCss != null)
                    {
                        soulBoardViewModel = new SoulBoardVIewModel
                        {
                            SoulBoard = soulBoard,
                            CandleType = soulBoardsCss.CandleType,
                            FontSize = soulBoardsCss.FontSize.ToString() + "px",
                            FontType = soulBoardsCss.FontType,
                            SoulBoardZero = soulBoard.Count != 0 ? true : false,
                        };
                    }
                    else
                    {
                        soulBoardViewModel = new SoulBoardVIewModel
                        {
                            SoulBoard = soulBoard,
                            CandleType = "Regular.jpg",
                            FontSize = "14px",
                            FontType = "Arial",
                            SoulBoardZero = soulBoard.Count != 0 ? true : false,
                        };
                    }

                    return View(soulBoardViewModel);
                }
                return Redirect("login");
            }
            return Redirect("login");
        }

        // GET: SoulBoards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var soulBoard = await _context.SoulBoard
                .Include(s => s.HolySubscription)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soulBoard == null)
            {
                return NotFound();
            }
            return View(soulBoard);
        }

        // GET: SoulBoards/Create
        public IActionResult Create()
        {
            ViewData["HolySubscriptionId"] = new SelectList(_context.HolySubscription, "Id", "Id");
            return View();
        }

        // POST: SoulBoards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SoulBoard soulBoard)
        {
            var userName = HttpContext.User.Identity.Name;
            if (userName != null)
            {
                var user = _context.Users.Where(x => x.Email == userName).Select(s => s.Id).FirstOrDefault();
                var Holyuser = _context.HolySubscription.Where(x => x.UserId == user).Select(s => s.Id).FirstOrDefault();
                soulBoard.HolySubscriptionId = Holyuser;
                if (ModelState.IsValid)
                {

                    _context.Add(soulBoard);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["HolySubscriptionId"] = new SelectList(_context.HolySubscription, "Id", "Id", soulBoard.HolySubscriptionId);
            return View(soulBoard);
        }

        // GET: SoulBoards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soulBoard = await _context.SoulBoard.FindAsync(id);
            if (soulBoard == null)
            {
                return NotFound();
            }
            ViewData["HolySubscriptionId"] = new SelectList(_context.HolySubscription, "Id", "Id", soulBoard.HolySubscriptionId);
            return View(soulBoard);
        }

        // POST: SoulBoards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateOfDeathForeign,DateOfDeathHebrew,HolySubscriptionId")] SoulBoard soulBoard)
        {
            if (id != soulBoard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soulBoard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoulBoardExists(soulBoard.Id))
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
            ViewData["HolySubscriptionId"] = new SelectList(_context.HolySubscription, "Id", "Id", soulBoard.HolySubscriptionId);
            return View(soulBoard);
        }

        // GET: SoulBoards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soulBoard = await _context.SoulBoard
                .Include(s => s.HolySubscription)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soulBoard == null)
            {
                return NotFound();
            }

            return View(soulBoard);
        }

        // POST: SoulBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soulBoard = await _context.SoulBoard.FindAsync(id);
            _context.SoulBoard.Remove(soulBoard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoulBoardExists(int id)
        {
            return _context.SoulBoard.Any(e => e.Id == id);
        }

        [Authorize]
        public IActionResult CssChange()
        {
            ViewBag.FontSize = new SelectList(new List<int> { 14, 16, 18, 20 });
            ViewBag.FontType = new SelectList(new List<string> { "Arial", "David", "Candara", "Times New Roman" });
            ViewBag.CandleType = new SelectList(new List<string> { "Regular", "OneOnly", "Many", "fire" });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CssChange(SoulBoardCssType soulBoardCss)
        {
            var userid = await _context.Users.Where(x => x.Email == HttpContext.User.Identity.Name).Select(s => s.Id).FirstOrDefaultAsync();
            var holyUser = await _context.HolySubscription.Where(x => x.UserId == userid).FirstOrDefaultAsync();
            var allSoulCss = await _context.SoulBoardCssTypes.Where(x => x.HolySubscriptionId == holyUser.Id).FirstOrDefaultAsync();
            if (allSoulCss == null)
            {
                soulBoardCss.HolySubscriptionId = holyUser.Id;
                soulBoardCss.LastUpdate = DateTime.Now;
                _context.SoulBoardCssTypes.Add(soulBoardCss);
                _context.SaveChanges();
            }
            else
            {
                allSoulCss.Id = allSoulCss.Id;
                allSoulCss.FontSize = soulBoardCss.FontSize;
                allSoulCss.FontType = soulBoardCss.FontType;
                allSoulCss.CandleType = soulBoardCss.CandleType + ".jpg";
                allSoulCss.LastUpdate = DateTime.Now;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}
