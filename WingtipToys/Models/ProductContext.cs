using System.Data.Entity;
namespace WingtipToys.Models
{
    /// <summary>
    /// Context Class
    /// To start using the classes for data access, you must define a context class. 
    /// As mentioned previously, the context class manages the entity classes 
    /// (such as the Product class and the Category class) and provides data access 
    /// to the database. 
    /// </summary>
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base( "WingtipToys" )
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}