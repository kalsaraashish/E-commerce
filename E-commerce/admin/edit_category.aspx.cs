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
using System.Xml.Linq;

namespace E_commerce.admin
{
    public partial class edit_category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindcategory();
            }

        }
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

        private void Bindcategory()
        {
            int catid = Convert.ToInt32(Request.QueryString["catid"]);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from category where catid='" + catid + "'", conn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                ad.Fill(tb);
                if (tb.Rows.Count > 0)
                {
                    cname.Text = tb.Rows[0]["catname"].ToString().Trim();
                }
                else
                {
                    // Handle the case where no rows are returned, e.g., show an error message.
                }
                conn.Close();
            }
        }

        protected void catbtn_Click(object sender, EventArgs e)
        {
            int catid = Convert.ToInt32(Request.QueryString["catid"]);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE category SET catname=@name WHERE catid=@catid", conn);
                cmd.Parameters.AddWithValue("@name", cname.Text);
                cmd.Parameters.AddWithValue("@catid", catid);

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    // Optionally use Session or QueryString to show success message on next page
                    Response.Redirect("addcategory.aspx?msg=success");
                    //Response.Write("update");
                }
                else
                {
                    //Response.Write("error");
                    Response.Redirect("addcategory.aspx?msg=error");
                }

                conn.Close();
            }

        }
    }
}