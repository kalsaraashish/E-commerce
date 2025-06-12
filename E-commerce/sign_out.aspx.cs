using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class sign_out : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // In logout button click event
            HttpCookie cartCookie = new HttpCookie("cartpid");
            cartCookie.Expires = DateTime.Now.AddDays(-1); // Expire it
            Response.Cookies.Add(cartCookie);
            
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            Response.Redirect("~/Homepage.aspx");
        }
    }
}