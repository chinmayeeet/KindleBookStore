using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    public class UserCrud
    {
        static BookDbContext dbContext = new BookDbContext();

        public List<DB.User> GetUsers()
        {

            return dbContext.Users.ToList();
        }
        public static void InsertUsers(int uid, string uname, string email, string password)
        {
            dbContext.Users.Add(new User() { UserId = uid, UserName = uname, Email = email, Password = password });
            dbContext.SaveChanges();
        }
        public static void DeleteUsers(int uid)
        {
            var del = dbContext.Users.ToList().Where((i) => i.UserId == uid).FirstOrDefault();
            dbContext.Users.Remove(del);
            dbContext.SaveChanges();
        }

    }
}
