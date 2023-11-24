using BStorePL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BStorePL.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet("/categories")]
        public IActionResult GetCategories()
        {
            var categories = CategoryOp.GetCategories();
            return View("CatList", categories );
        }

        /*[HttpGet("/search/{catid}")]
        public IActionResult GetPersonDetails(int catid)
        {
            var found = CategoryOp.Search(empid);
            return View("Search", found);

        }*/

        [HttpGet("/create")]
        public IActionResult Create()
        {
            return View("Create", new DB.Category());
        }
        [HttpPost("/create")]
        public IActionResult Create([FromForm] DB.Category c)
        {
            CategoryOp.CreateNew(c);
            return View("CatList", CategoryOp.GetCategories());
        }

        
        


        

        
    }
}
