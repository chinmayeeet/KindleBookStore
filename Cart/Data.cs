using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Cart
{
    public class Data
    {
        public static void SeedDatabase(BookDbContext context)
        {
            context.Database.Migrate();

            if (!context.Book.Any())
            {
                Category books = new Category { Name = "Books", Slug = "books" };

                context.Book.AddRange(

                                        new Book
                                        {
                                            Title = "Book 1",
                                            //Slug = "book-1",
                                            Description = "Good book",
                                            Price = 250,
                                            //Category = books,
                                            Image = "book.jpg"
                                        },
                                        new Book
                                        {
                                            Title = "Book 2",
                                            //Slug = "book-2",
                                            Description = "A very good book",
                                            Price = 400,
                                            //Category = books,
                                            Image = "book.jpg"
                                        },
                                        new Book
                                        {
                                            Title = "Book 3",
                                            //Slug = "book-3",
                                            Description = "Boring book",
                                            Price = 110,
                                            //Category = books,
                                            Image = "book.jpg"
                                        },
                                        new Book
                                        {
                                            Title = "Book 4",
                                            //Slug = "book-4",
                                            Description = "OK",
                                            Price = 120,
                                            //Category = books,
                                            Image = "book.jpg"
                                        }
                                );

                context.SaveChanges();
            }
        }
    }
}
