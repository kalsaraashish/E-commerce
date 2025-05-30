using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace E_commerce.admin
{
    public partial class addbrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["msg"] == "success")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Brand updated successfully!');", true);
                }
                else if (Request.QueryString["msg"] == "error")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error updating brand.');", true);
                }
                else if (Request.QueryString["msg"] == "successdelete")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Brand Deleted successfully!');", true);
                }
                    Bindtabledata();
            }
        }
        // Connection string to the database
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";


        protected void btnLogin_Click(object sender, EventArgs e)
        {


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand insertcmd = new SqlCommand("insert into brand(name,date) values('" + brname.Text + "',GETDATE())", conn);
                insertcmd.ExecuteNonQuery();
                Response.Write("<script>alert('Brand added successfully!');</script>");
                brname.Text = string.Empty;
                brname.Focus();
                conn.Close();
                Bindtabledata();
            }
        }
        private void Bindtabledata()
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from brand", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rp.DataSource = dt;
                rp.DataBind();
                conn.Close();
            }
        }
    }
}