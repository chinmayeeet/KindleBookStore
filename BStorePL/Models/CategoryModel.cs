using Crud;
using DB;

namespace BStorePL.Models
{
    public class CategoryOp
    {
        static List<Category> categorylist = new List<Category>();

        public static List<Category> GetCategories()
        {
            categorylist = CategoryCrud.GetCategories();
            if (categorylist.Count == 0)
            {
                CategoryCrud.InsertCategories(1234, "Book1", "Author1");
                CategoryCrud.InsertCategories(4567, "Book2", "Author2");
                CategoryCrud.InsertCategories(1234, "Book3", "Author3");
                CategoryCrud.InsertCategories(4567, "Book4", "Author4");
            }
            return CategoryCrud.GetCategories();

        }

        public static void CreateNew(Category c)
        {
            var Cid = c.CId;
            var slug = c.CSlug;
            var name = c.CName;

            CategoryCrud.InsertCategories((int)Cid, slug, name);

        }
        public static bool Delete(int id)
        {
            var found = CategoryCrud.GetCategories().Where(b => b.CId == id).FirstOrDefault();
            if (found != null)
            {
                CategoryCrud.DeleteCategories(id);
                return true;
            }
            else
                throw new Exception("Record does not exist");
        }
    }
}
