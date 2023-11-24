using DB;
using Microsoft.AspNetCore.Http;

namespace Crud
{
    public class BookCrud 
    {
        static BookDbContext dbContext = new BookDbContext();
        public static int BookCount {get; set; }
        
        public static List<DB.Book> GetBooks()
        {
            var res = dbContext.Books.ToList();
            return res;
        }

        public static void InsertBooks( int id,string title, string auth, string descp, DateTime pubdate, string publisher, int cid, string img )
        {
            id = new Random(1000).Next();
            BookCount++;
            dbContext.Books.Add(new DB.Book() { BookId = id, Title = title, Author = auth, Description = descp, PublicationDate=pubdate, Publisher = publisher, CategoryId = cid,Image = img });
            dbContext.SaveChanges();

        }

        public static void UpdateBook(int id, string title, string auth, string descp, DateTime pubdate, string publisher, int cid, string img)
        {
            var upbook = dbContext.Books.ToList().Where((i)=> i.BookId == id).FirstOrDefault();
            upbook.Title = title;
            upbook.Author= auth;
            upbook.Description = descp;
            upbook.PublicationDate = pubdate;
            upbook.Publisher = publisher;
            upbook.CategoryId= cid;
            upbook.Image = img;
            dbContext.SaveChanges();
        }

        public static void DeleteBook(int id)
        {
            var del = dbContext.Books.ToList().Where((i) => i.BookId == id).FirstOrDefault();
            dbContext.Books.Remove(del);
            dbContext.SaveChanges();
        }

    }
}