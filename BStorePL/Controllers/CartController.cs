using BStorePL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BStorePL.Controllers
{
    public class CartController : Controller
    {
        [HttpGet("/cart")]
        public IActionResult GetCarts()
        {
            var carts = CartOp.GetCartItems();
            return View("CartList", carts);
        }


        [HttpGet("/create")]
        public IActionResult Create()
        {
            return View("Create", new DB.CartItem());
        }
        [HttpPost("/create")]
        public IActionResult Create([FromForm] DB.CartItem u)
        {
            CartOp.CreateNew(u);
            return View("EmpList", CartOp.GetCartItems());
        }

 
        
    }
}
