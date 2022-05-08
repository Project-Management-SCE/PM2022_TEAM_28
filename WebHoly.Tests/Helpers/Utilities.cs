using System.Collections.Generic;

using WebHoly.Data;

namespace WebHoly.Tests.Helpers
{
    public static class Utilities
    {
        #region snippet1
        public static void InitializeDbForTests(ApplicationDbContext db)
        {
            var pocoUsers = new PocoUser() { Email = "govo@gmail.com", UserName = "govo@gmail.com", PasswordHash = "126265" };
            db.Add(pocoUsers);
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(ApplicationDbContext db)
        {
            db.RemoveRange(db);
            InitializeDbForTests(db);
        }

       
        #endregion
    }
}
