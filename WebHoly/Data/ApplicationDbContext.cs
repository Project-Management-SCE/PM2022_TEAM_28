using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebHoly.Models;

namespace WebHoly.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<RegularSubscription> RegularSubscription { get; set; }
        public virtual DbSet<Halachot> Halachot { get; set; }
        public virtual DbSet<HolySubscription> HolySubscription { get; set; }
        public virtual DbSet<Mails> Mails { get; set; }
        public virtual DbSet<PrayerTimes> PrayerTimes { get; set; }
        public virtual DbSet<SoulBoard> SoulBoard { get; set; }
        public virtual DbSet<SoulBoardCssType> SoulBoardCssTypes { get; set; }


    }
}
