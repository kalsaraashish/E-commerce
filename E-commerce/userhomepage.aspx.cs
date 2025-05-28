using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class userhomepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {

                username.Text = "Hello, "+Session["username"].ToString();
            }
            else
            {
                btnlogout.Visible= false;
                Response.Redirect("sign_out.aspx");
            }
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("sign_out.aspx");
        }   
    }
}