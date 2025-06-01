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
            Bindcartnumber();
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
        public void Bindcartnumber()
        {
            if (Request.Cookies["cartpid"] != null)
            {
                string cookiepid = Request.Cookies["cartpid"].Value.Split('=')[1];
                string[] productArray = cookiepid.Split(',');
                int productcount = productArray.Length;
                pcount.InnerText = productcount.ToString();
            }
            else
            {
                pcount.InnerText = 0.ToString();
            }
        }
    }
}