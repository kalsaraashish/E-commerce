using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace E_commerce.admin
{
    public partial class addgender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand insertcmd = new SqlCommand("insert into gender(genname) values('" + gname.Text + "')", conn);
                insertcmd.ExecuteNonQuery();
                Response.Write("<script>alert('Gender added successfully!');</script>");

                gname.Text = string.Empty;
                gname.Focus();
                conn.Close();
            }
        }
    }
}