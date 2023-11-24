using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    public class CartCrud

    {
        static BookDbContext dbContext = new BookDbContext();

        public static List<DB.CartItem> GetCartItems()
        {

            return dbContext.Carts.ToList();
        }

        public static void InsertCartItems(int cartid, int userid, int bookid, string title, int quantity, float price, string img)
        {
            dbContext.Carts.Add(new CartItem() { CartId = cartid, UserId = userid, BookId = bookid, BookTitle = title, Quantity = quantity, Price = price, Image = img });
            dbContext.SaveChanges();

        }

        public static void DeleteCartItems(int id)
        {
            var del = dbContext.Carts.ToList().Where((i) => i.BookId == id).FirstOrDefault();
            dbContext.Carts.Remove(del);
            dbContext.SaveChanges();

        }

        public static void EmptyCart(int id)
        {
            var del = dbContext.Carts.ToList().Where((i) => i.CartId == id).FirstOrDefault();
            dbContext.Carts.Remove(del);
            dbContext.SaveChanges();

        }
    }
}
