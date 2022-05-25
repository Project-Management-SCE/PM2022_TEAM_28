////using Microsoft.AspNetCore.Mvc;
////using Microsoft.EntityFrameworkCore;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WebHoly.Controllers;
//using WebHoly.Data;
//using WebHoly.Models;
//using Microsoft.AspNetCore.Identity;
//using Xunit;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
//using Microsoft.EntityFrameworkCore;
//using WebHoly.Tests;
//using Microsoft.AspNet.Identity;

//namespace WebHoly.Tests
//{


//    public class AccountTest : IDisposable
//    {
//        private DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
//       .UseInMemoryDatabase(databaseName: "AccountTest")
//       .Options;
//        //private readonly TestFixture<Startup> _fixture;
//        private readonly ApplicationDbContext _context;
       

//        [SetUp]
//        [Fact]
//        public void SetUp()
//        {
//             private readonly List<> _users = new List<IdentityUser>
//        {
//            new IdentityUser{ Id = new Guid().ToString(), Email="govo@gmail.com", UserName="govo@gmail.com" },
//            new IdentityUser{ Id = new Guid().ToString(), Email="govo2@gmail.com", UserName="govo2@gmail.com" },

//        };
//        private UserManager = MockUserManager<IdentityUser>(_users).Object; 
//            SeedDatabaseAsync();
//        }


//        private async Task SeedDatabaseAsync()
//        {
//            var User1 = new IdentityUser { UserName = "Rafi@gmail.com", Email = "Rafi@gmail.com", };
//            //            var result1 = await _mockuserManager.CreateAsync(User1, "12345");
//            //            var User2 = new IdentityUser { UserName = "Tal@gmail.com", Email = "Tal@gmail.com", };
//            //            var result2 = await _mockuserManager.CreateAsync(User2, "12345");
//            //            var User3 = new IdentityUser { UserName = "Rafi2@gmail.com", Email = "Rafi2@gmail.com", };
//            //            var result3 = await _mockuserManager.CreateAsync(User3, "12345");
//            //            var User4 = new IdentityUser { UserName = "Tal2@gmail.com", Email = "Tal2@gmail.com", };
//            //            var result4 = await _mockuserManager.CreateAsync(User4, "12345");

//            //            _context.Users.Add(User1);
//            //            _context.Users.Add(User2);
//            //            _context.Users.Add(User3);
//            //            _context.Users.Add(User4);
//            //            _context.SaveChanges();
//            var regularSub = new List<RegularSubscription>()
//            {
//               new RegularSubscription
//               {
//                    Id =1,
//                    UserId = "123",
//                    CreatedDate = DateTime.Now,
//                    Gender = true,
//                    Age =26,
//                    Community = "מרוקאי",
//                    FirstName ="רפאל"
//               },
//               new RegularSubscription
//               {
//                    Id =2,
//                    UserId = "1235",
//                    CreatedDate = DateTime.Now,
//                    Gender = true,
//                    Age =21,
//                    Community = "טריפולטי",
//                    FirstName ="טל אוחיון"
//               }
//            };
//            _context.RegularSubscription.AddRange(regularSub);
//            var holySub = new List<HolySubscription>()
//            {
//               new HolySubscription
//               {
//                    Id =1,
//                    UserId = "1234",
//                    CreatedDate = DateTime.Now,
//                    Community = "מרוקאי",
//                    FirstName ="רפאל",
//                    Address = "גני יהב",
//                    Phone = "052025262",
//                    Last4Digits = "0000",
//                    TokenNumber = "רפאל"+DateTime.Now,
//                    IdentityNumber = "123",
//                     City = "באר שבע"
//               },
//               new HolySubscription
//               {
//                    Id =2,
//                    UserId = "12413",
//                   CreatedDate = DateTime.Now,
//                    Community = "טריפולטי",
//                    FirstName ="טלטול",
//                    Address = "גני באר",
//                    Phone = "052025262",
//                    Last4Digits = "0000",
//                    TokenNumber = "טלטול"+DateTime.Now,
//                    IdentityNumber = "123",
//                     City = "חדרה"
//               }
//            };
//            _context.HolySubscription.AddRange(holySub);

//            _context.SaveChanges();
//        }


//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }
//        public async Task<int> CreateUser(IdentityUser user, string password) => (await _userManager.CreateAsync(user, password)).Succeeded ? user.Id : -1;

//        [Fact]
//        public async Task CreateAUser()
//        {
//            var newUser = new IdentityUser { UserName = "Rafi@gmail.com", Email = "Rafi@gmail.com", };
//            var password = "P@ssw0rd!";

//            var result = await CreateUser(newUser, password);

//            Assert.Equal(3, _users.Count);
//        }
//    }
//}

////        [Fact]
////        public async Task LoginTest()
////        {
////            NUnit.Framework.Assert.True(true);
////            //var result = await _signInManager.PasswordSignInAsync("rafi@gmail.com", "12345", true, lockoutOnFailure: false);
////            //Xunit.Assert.True(result.Succeeded, "משתמש הצליח להתחבר");
////            _signInManager.Setup(
////    x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
////        It.IsAny<bool>())).Returns(Task.FromResult(SignInResult.Success));
////        }

////        public void Dispose()
////        {
////            _context.Dispose();
////        }
////    }
////}
