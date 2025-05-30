using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.admin
{
    public partial class editbrand : System.Web.UI.Page
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
            Bindbranddata();
            }
        }
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";


        private void Bindbranddata()
        {
            int brid = Convert.ToInt32(Request.QueryString["brid"]);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from brand where brid='" + brid + "'", conn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                ad.Fill(tb);
                if (tb.Rows.Count > 0)
                {
                    bname.Text = tb.Rows[0]["name"].ToString().Trim();
                }
                else
                {
                    // Handle the case where no rows are returned, e.g., show an error message.
                }
                conn.Close();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int brid = Convert.ToInt32(Request.QueryString["brid"]);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE brand SET name=@name, date=GETDATE() WHERE brid=@brid", conn);
                cmd.Parameters.AddWithValue("@name", bname.Text);
                cmd.Parameters.AddWithValue("@brid", brid);

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    // Optionally use Session or QueryString to show success message on next page
                    Response.Redirect("addbrand.aspx?msg=success");
                }
                else
                {
                    Response.Redirect("addbrand.aspx?msg=error");
                }

                conn.Close();
            }
        }

    }
}