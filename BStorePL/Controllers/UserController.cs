using BStorePL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BStorePL.Controllers
{
    public class UserController : Controller
    {
        /*[HttpGet("/users")]
        public IActionResult GetUser()
        {
            var users = UserOp.GetUsers();
            return View("UserList", users);
        }

        [HttpGet("/search/{userid}")]
        public IActionResult GetPersonDetails(int userid)
        {
            var found = UserOp.Search(empid);
            return View("Search", found);

        }*/

        [HttpGet("/create")]
        public IActionResult Create()
        {
            return View("Create", new DB.User());
        }
        [HttpPost("/create")]
        public IActionResult Create([FromForm] DB.User u)
        {
            UserOp.CreateNew(u);
            return View("UserList", UserOp.GetUsers());
        }

        
            

       
        
    }
}
