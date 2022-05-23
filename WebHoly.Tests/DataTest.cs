//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WebHoly.Data;
//using WebHoly.Models;

//namespace WebHoly.Tests
//{
//    [TestClass]
//    class DataTest
//    {
//        private DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
//       .UseInMemoryDatabase(databaseName: "AccountTest")
//       .Options;
//        private readonly ApplicationDbContext _context;

//        DataTest(ApplicationDbContext)
//        {

//        }

//        [TestClass]
//        public void SeedDatabaseAsync()
//        {
//            var User1 = new IdentityUser { UserName = "Rafi@gmail.com", Email = "Rafi@gmail.com", PasswordHash = "123", Id = "1" };
//            var User2 = new IdentityUser { UserName = "Tal@gmail.com", Email = "Tal@gmail.com", PasswordHash = "123", Id = "2" };
//            var User3 = new IdentityUser { UserName = "Rafi2@gmail.com", Email = "Rafi2@gmail.com", PasswordHash = "123", Id = "3" };
//            var User4 = new IdentityUser { UserName = "Tal2@gmail.com", Email = "Tal2@gmail.com", PasswordHash = "123", Id = "4" };

//            _context.Users.Add(User1);
//            _context.Users.Add(User2);
//            _context.Users.Add(User3);
//            _context.Users.Add(User4);
//            _context.SaveChanges();
//            var regularSub = new List<RegularSubscription>()
//                    {
//                       new RegularSubscription
//                       {
//                            Id =1,
//                            UserId = "123",
//                            CreatedDate = DateTime.Now,
//                            Gender = true,
//                            Age =26,
//                            Community = "מרוקאי",
//                            FirstName ="רפאל"
//                       },
//                       new RegularSubscription
//                       {
//                            Id =2,
//                            UserId = "1235",
//                            CreatedDate = DateTime.Now,
//                            Gender = true,
//                            Age =21,
//                            Community = "טריפולטי",
//                            FirstName ="טל אוחיון"
//                       }
//                    };
//            _context.RegularSubscription.AddRange(regularSub);
//            var holySub = new List<HolySubscription>()
//                    {
//                       new HolySubscription
//                       {
//                            Id =1,
//                            UserId = "1234",
//                            CreatedDate = DateTime.Now,
//                            Community = "מרוקאי",
//                            FirstName ="רפאל",
//                            Address = "גני יהב",
//                            Phone = "052025262",
//                            Last4Digits = "0000",
//                            TokenNumber = "רפאל"+DateTime.Now,
//                            IdentityNumber = "123",
//                             City = "באר שבע"
//                       },
//                       new HolySubscription
//                       {
//                            Id =2,
//                            UserId = "12413",
//                           CreatedDate = DateTime.Now,
//                            Community = "טריפולטי",
//                            FirstName ="טלטול",
//                            Address = "גני באר",
//                            Phone = "052025262",
//                            Last4Digits = "0000",
//                            TokenNumber = "טלטול"+DateTime.Now,
//                            IdentityNumber = "123",
//                             City = "חדרה"
//                       }
//                    };
//            _context.HolySubscription.AddRange(holySub);

//            _context.SaveChanges();

//            Assert.IsTrue(_context.HolySubscription.Any(x => x.FirstName == "טלטול"), "קיים");
//        }
//    }
//}
