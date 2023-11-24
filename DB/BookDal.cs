
//using Microsoft.AspNetCore.Identity;
//using ShoppingCart.Infrastructure.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace DB
{

    public class Book
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

        [NotMapped]
        [FileExtensions]
        public IFormFile ImageUpload { get; set; }
    }
    public class CartItem  
    {
        
        public CartItem()
        {
            
        }
        public CartItem(Book book)
        {
            BookId = book.BookId;
             BookTitle = book.Title;
            Price = book.Price;
            Quantity = 1;
            Image = book.Image;
        }
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Total
        {
            get { return (float)Quantity * Price; }
        }
        public string Image { get; set; }

    }
    public class Category
    {
        public long CId { get; set; }
        public string CName { get; set; }
        public string CSlug { get; set; }
    }

    /*public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }*/

    public class User
    {
        [Key]
        public int UserId { get; set; }

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
        public DbSet<Book>Books{ get; set; }

        public DbSet<User>Users { get; set; }

        public DbSet<CartItem> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BookStore;Trusted_Connection=true");
        }
    }
}