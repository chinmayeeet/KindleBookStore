using Crud;
using DB;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BStorePL.Models
{
    public class UserOp
    {
        static List<User> userlist = new List<User>();

        public static List<User> GetUsers()
        {
            userlist = UserCrud.GetUsers();
            if (userlist.Count == 0)
            {
                UserCrud.InsertUsers(1234, "Book1", "Author1", "Good Book", Convert.ToDateTime("10-10-2022"), "BookHouse", 1, "img.png");
                
            }
            return UserCrud.GetUsers();

        }

        public static void CreateNew(User b)
        {
            var uid = b.UserId;
            var uname = b.UserName;
            var email = b.Email;
            var password = b.Password;

            UserCrud.InsertUsers(uid, uname, email, password);

        }



        public static bool Delete(int uid)
        {
            var found = UserCrud.GetUsers().Where(b => b.UserId == uid).FirstOrDefault();
            if (found != null)
            {
                BookCrud.DeleteBook(uid);
                return true;
            }
            else
                throw new Exception("Record does not exist");
        }
    }
}
