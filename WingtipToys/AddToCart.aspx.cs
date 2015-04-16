using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WingtipToys.Logic;

namespace WingtipToys
{
    /// <summary>
    /// When the AddToCart.aspx page is loaded, the product ID is retrieved 
    /// from the query string. Next, an instance of the shopping cart class 
    /// is created and used to call the AddToCart method that you added 
    /// earlier in this tutorial. The AddToCart method, contained in the 
    /// ShoppingCartActions.cs file, includes the logic to add the selected 
    /// product to the shopping cart or increment the product quantity of 
    /// the selected product. If the product hasn’t been added to the 
    /// shopping cart, the product is added to the CartItem table of the 
    /// database. If the product has already been added to the shopping cart
    ///  and the user adds an additional item of the same product, 
    /// the product quantity is incremented in the CartItem table. Finally,
    ///  the page redirects back to the ShoppingCart.aspx page that you’ll 
    /// add in the next step, where the user sees an updated list of items 
    /// in the cart.
    /// </summary>
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProductID"];
            int productId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
            {
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {
                    usersShoppingCart.AddToCart(Convert.ToInt16(rawId));
                }

            }
            else
            {
                Debug.Fail("ERROR : We should never get to AddToCart.aspx without a ProductId.");
                throw new Exception("ERROR : It is illegal to load AddToCart.aspx without setting a ProductId.");
            }
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}