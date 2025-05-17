using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;    
using System.Configuration; 
using System.Data;

namespace E_commerce
{
    public partial class sign_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from user_data where username=@username and password=@pass",conn);
            cmd.Parameters.AddWithValue("@username",username.Text);
            cmd.Parameters.AddWithValue("@pass",pass.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                // Login successful
                Session["username"] = username.Text;
                Response.Write("<script>alert('Login successful');</script>");
                Response.Redirect("userhomepage.aspx");
                username.Text = string.Empty;
                pass.Text = string.Empty;
                username.Focus();
            }
            else
            {
                // Login failed
                Response.Write("<script>alert('Invalid username or password');</script>");
                username.Text = string.Empty;   
                pass.Text = string.Empty;
                username.Focus();
            }

            conn.Close();
        }
    }
}