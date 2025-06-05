using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                Bindproduct();
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

        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";
        private void Bindproduct()
        {

            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("BindAllProducts", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rp1.DataSource = dt;
                        rp1.DataBind();
                    }
                }
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