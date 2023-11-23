using DB;

namespace Cart
{
    public class BookOp
    {
        public List<Book> GetBooks()
        {
            BookDbContext dbContext = new BookDbContext();
            return dbContext.Book.ToList();
        }

        public List<Book> InsertBooks()
        {
            BookDbContext dbContext = new BookDbContext();
            return dbContext.Book.ToList();
        }

        public List<Book> UpdateBook()
        {
            BookDbContext dbContext = new BookDbContext();
            return dbContext.Book.ToList();
        }

        public List<Book> DeleteBook()
        {
            BookDbContext dbContext = new BookDbContext();
            return dbContext.Book.ToList();
        }

    }
}