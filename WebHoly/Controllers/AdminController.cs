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
      
        public async Task<IActionResult> RegularUserList()
        {
            var applicationDbContext = _context.RegularSubscription.Include(h => h.User);
            return View(await applicationDbContext.ToListAsync());
        }

    }
}
