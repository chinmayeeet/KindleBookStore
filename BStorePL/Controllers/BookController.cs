using BStorePL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BStorePL.Controllers
{
    public class BookController : Controller
    {

        [HttpGet("/books")]
        public IActionResult GetBook()
        {
            var books = BookOp.GetBook();
            return View("BookList", books);
        }

        [HttpGet("/search/{bookid}")]
        public IActionResult GetPersonDetails(int bookid)
        {
            var found = BookOp.Search(bookid);
            return View("Search", found);

        }

        [HttpGet("/create")]
        public IActionResult Create()
        {
            return View("Create", new DB.Book());
        }
        [HttpPost("/create")]
        public IActionResult Create([FromForm] DB.Book b)
        {
            BookOp.CreateNew(b);
            return View("BookList", BookOp.GetBook());
        }

        [HttpGet("/edit/{bookid}")]
        public IActionResult Edit(int bookid)
        {
            var found = BookOp.Search(bookid);
            return View("Edit", found);

        }

        [HttpPost("/edit/{bookid}")]
        public IActionResult Edit(int bookid, [FromForm] DB.Book b)
        {
            BookOp.Update(bookid, b);
            return View("EmpList", BookOp.GetBook());
        }

        
    }
}
