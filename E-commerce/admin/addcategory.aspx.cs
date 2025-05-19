using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.admin
{
    public partial class addcategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand insertcmd = new SqlCommand("insert into category(catname) values('" + cname.Text + "')", conn);
                insertcmd.ExecuteNonQuery();
                Response.Write("<script>alert('Category added successfully!');</script>");
                cname.Text = string.Empty;
                cname.Focus();

            }
        }
    }
}