using Crud;
using DB;
using System;

namespace BStorePL.Models
{
    public class BookOp
    {
        static List<Book> booklist = new List<Book>();

        public static List<Book> GetBook()
        {
            booklist = BookCrud.GetBooks();
            if (booklist.Count == 0)
            {
                BookCrud.InsertBooks(1234, "Book1","Author1","Good Book", Convert.ToDateTime("10-10-2022"), "BookHouse",1,"img.png") ;
                BookCrud.InsertBooks(4567, "Book2", "Author2", "Good Book", Convert.ToDateTime("10-10-2012"), "BookHouse", 2, "img.png");
                BookCrud.InsertBooks(1234, "Book3", "Author3", "Good Book", Convert.ToDateTime("18-10-2000"), "BookLibrary", 3, "img.png");
                BookCrud.InsertBooks(4567, "Book4", "Author4", "Good Book", Convert.ToDateTime("1-10-2003"), "BookLibrary", 4, "img.png");
            }
            return BookCrud.GetBooks();

        }

        public static void CreateNew(Book b)
        {
            var id = b.BookId;
            var title = b.Title;
            var auth = b.Author;
            var desc = b.Description;
            var dtime = b.PublicationDate;
            var pub = b.Publisher;
            var cid = b.CategoryId;
            var img = b.Image;

            BookCrud.InsertBooks(id,title,auth,desc,dtime,pub,cid,img);
    
        }

        public static Book Search(int bookid)
        {
            return BookCrud.GetBooks().Where(b => b.BookId == bookid).FirstOrDefault();
        }

        public static bool Update(int bid, Book UBook)
        {
            var found = BookCrud.GetBooks().Where(p => p.BookId == bid).FirstOrDefault();
            if (found != null)
            {
                var id = UBook.BookId;
                var title = UBook.Title;
                var auth = UBook.Author;
                var desc = UBook.Description;
                var dtime = UBook.PublicationDate;
                var pub = UBook.Publisher;
                var cid = UBook.CategoryId;
                var img = UBook.Image;
                BookCrud.UpdateBook(id, title, auth, desc, dtime, pub, cid, img);
                return true;
            }

            else
                throw new Exception("No such record");
        }

        public static bool Delete(int bid)
        {
            var found = BookCrud.GetBooks().Where(b => b.BookId == bid).FirstOrDefault();
            if (found != null)
            {
                BookCrud.DeleteBook(bid);
                return true;
            }
            else
                throw new Exception("Record does not exist");
        }
    }
}
