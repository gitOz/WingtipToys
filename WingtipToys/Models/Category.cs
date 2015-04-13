using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WingtipToys.Models
{
    /// <summary>
    /// As previously mentioned, the Category class represents the type of product that
    /// the application is designed to sell (such as "Cars", "Boats", "Rockets", and 
    /// so on), and the Product class represents the individual products (toys) in 
    /// the database. Each instance of a Product object will correspond to a row 
    /// within a relational database table, and each property of the Product class 
    /// will map to a column in the relational database table.
    /// </summary>
    public class Category
    {
        /*
         * You may have noticed that certain members of the classes have attributes 
         * specifying details about the member, such as [ScaffoldColumn(false)].
         * These are data annotations. The data annotation attributes can describe 
         * how to validate user input for that member, to specify formatting for it, 
         * and to specify how it is modeled when the database is created.
         * */
        [ScaffoldColumn( false )]//
        public int CategoryID { get; set; }

        [Required, StringLength( 100 ), Display( Name = "Name" )]
        public string CategoryName { get; set; }

        [Display( Name = "Product Description" )]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}