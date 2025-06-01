using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class usertemplate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bindcartnumber();
            if (Session["username"] != null)
            {
                username.Text = "Hello, " + Session["username"].ToString();
            }
            else
            {
                Response.Redirect("sign_out.aspx");
            }
        }

        public void Bindcartnumber()
        {
            if (Request.Cookies["cartpid"] != null)
            {
                string cookiepid = Request.Cookies["cartpid"].Value; // Correctly read the cookie
                string[] productArray = cookiepid.Split(',');
                int productcount = productArray.Length;
                pcount.InnerText = productcount.ToString();
            }
            else
            {
                pcount.InnerText = "0";
            }
        }
    }
}
