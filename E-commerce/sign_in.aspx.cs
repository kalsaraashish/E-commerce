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
            if (!IsPostBack)
            {
                if (Request.Cookies["username"] != null && Request.Cookies["pass"] != null)
                {
                    username.Text = Request.Cookies["username"].Value;
                    pass.Text = Request.Cookies["pass"].Value;
                    chkRememberMe.Checked = true;
                }
            }
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
                reader.Read(); // 🔥 THIS IS REQUIRED

                if (chkRememberMe.Checked)
                {
                    Response.Cookies["username"].Value = username.Text;
                    Response.Cookies["pass"].Value = pass.Text;

                    Response.Cookies["username"].Expires = DateTime.Now.AddHours(2);
                    Response.Cookies["pass"].Expires = DateTime.Now.AddHours(2);
                }
                else
                {
                    Response.Cookies["username"].Expires = DateTime.Now.AddHours(-1);
                    Response.Cookies["pass"].Expires = DateTime.Now.AddHours(-1);
                }

                
                
                string usertype = reader["usertype"].ToString().Trim().ToLower();

                if (usertype == "user")
                {
                    Session["username"] = username.Text;
                    if (Request.QueryString["rurl"] !=null)
                    {
                        if (Request.QueryString["rurl"] == "cart")
                        { 
                            Response.Redirect("~/cart.aspx");
                        }
                      
                    }
                    else
                    {
                        Response.Redirect("~/userhomepage.aspx");
                        
                    }
                }
                else
                {
                    Response.Write(usertype);
                    Response.Redirect("~/admin/adminhomepage.aspx");
                    Session["username"] = username.Text;
                }

                username.Text = string.Empty;
                pass.Text = string.Empty;
                username.Focus();
            }
            else
            {
                Response.Write("<script>alert('Invalid username or password');</script>");
                username.Text = string.Empty;
                pass.Text = string.Empty;
                username.Focus();
            }


            conn.Close();
        }
    }
}