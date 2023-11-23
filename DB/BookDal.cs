
//using Microsoft.AspNetCore.Identity;
//using ShoppingCart.Infrastructure.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;

namespace DB
{

    public class BookDal
    {
        [Key]
        public int BookId { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(150)]
        public string Author { get; set; }

        public float Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime PublicationDate { get; set; }

        [StringLength(100)]
        public string Publisher { get; set; }

        //[ForeignKey]
        public int CategoryId { get; set; }
        public string Image { get; set; } = "noimage.png";

        //[NotMapped]
        //[FileExtension]
        //public IFormFile ImageUpload { get; set; }
    }
    public class CartItem
    {
        public long BookId { get; set; }
        public string BookName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Total
        {
            get { return (float)Quantity * Price; }
        }
        public string Image { get; set; }



        public CartItem(BookDal book)
        {
            BookId = book.BookId;
            BookName = book.Title;
            Price = book.Price;
            Quantity = 1;
            Image = book.Image;
        }


    }
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }

    /*public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }*/

    public class User
    {
        public string Id { get; set; }

        [Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minimum length is 4")]
        public string Password { get; set; }
    }

    

    public class BookDbContext : DbContext
    {
        public DbSet<BookDal> Book{ get; set; }

        public DbSet<User> User { get; set; }

        //public DbSet<CartItem> Cart(BookDal) { get; set; }
        public DbSet<Category> Category { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EmployeeDb;Trusted_Connection=true");
        }
    }
}