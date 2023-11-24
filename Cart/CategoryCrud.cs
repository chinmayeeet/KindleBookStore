using DB;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    public class CategoryCrud
    {
        static BookDbContext dbContext = new BookDbContext();

        public static List<DB.Category> GetCategories()
        {

            return dbContext.Categories.ToList();
        }

        public static void InsertCategories(int id, string slug, string name)
        {
            dbContext.Categories.Add(new Category() { CId = id, CSlug = slug, CName = name});
            dbContext.SaveChanges();

        }

        public static void UpdateCategory(int id, string slug, string name)
        {
            var upcat = dbContext.Categories.ToList().Where((i) => i.CId == id).FirstOrDefault();
            upcat.CSlug = slug;
            upcat.CName = name;
            dbContext.SaveChanges();
        }

        public static void DeleteCategories(int id)
        {
            var del = dbContext.Categories.ToList().Where((i) => i.CId == id).FirstOrDefault();
            dbContext.Categories.Remove(del);
            dbContext.SaveChanges();
        }

    }
}
