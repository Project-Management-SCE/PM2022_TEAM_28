using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHoly.Data;

namespace WebHoly.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> HolyUserList()
        {
            var applicationDbContext = _context.HolySubscription.Include(h => h.User);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult RevenueStatement()
        {
            var applicationDbContext = _context.Payment.Include(h => h.HolySubscription).ToList();
            decimal sum = 0;
            foreach (var payment in applicationDbContext)
            {
                sum += payment.Price;
            }
            ViewBag.sum = sum;
            return View(applicationDbContext);

        }
    }
}
