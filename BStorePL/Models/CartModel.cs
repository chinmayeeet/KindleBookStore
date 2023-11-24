using Crud;
using DB;
using System;

namespace BStorePL.Models
{
    public class CartOp
    {
        //static List<CartItem> cartlist = new List<CartItem>();

        public static List<CartItem> GetCartItems()
        {
            return CartCrud.GetCartItems();
        }

        public static void CreateNew(CartItem b)
        {
            var Cid = b.CartId;
            var Uid = b.UserId;
            var Bid = b.BookId;
            var title = b.BookTitle;
            var quantity = b.Quantity;
            var price = b.Price;
            string img = b.Image;

            CartCrud.InsertCartItems(Cid, Uid, Bid, title, quantity, price, img);

        }



        public static bool Delete(int Cid)
        {
            var found = CartCrud.GetCartItems().Where(b => b.CartId == Cid).FirstOrDefault();
            if (found != null)
            {
                CartCrud.DeleteCartItems(Cid);
                return true;
            }
            else
                throw new Exception("Record does not exist");
        }

    }
}