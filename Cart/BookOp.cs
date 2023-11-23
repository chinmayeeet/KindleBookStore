using DB;

namespace Cart
{
    public class BookOp<T> where T:Book
    {
        static BookDbContext dbContext = new BookDbContext();
        public static int BookCount {get; set; }
        
        public List<DB.Book> GetBooks()
        {
    
            return dbContext.Books.ToList();
        }

        public static void InsertBooks( int id,string title, string auth, string desc )
        {
            id = new Random(1000).Next();
            BookCount++;
            dbContext.Books.Add(new Book() { BookId = id, Title = title, Author = auth, Description = desc });
            dbContext.SaveChanges();

        }

        public static void UpdateBook(int id, string title, string auth, string desc)
        {
            var upbook = dbContext.Books.ToList().Where((i)=> i.BookId == id).FirstOrDefault();
            upbook.Title = title;
            upbook.Author= auth;
            upbook.Description = desc;
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