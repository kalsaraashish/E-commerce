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
    public partial class edit_gender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindgendata();
            }

        }

        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";


        private void Bindgendata()
        {
            int genid = Convert.ToInt32(Request.QueryString["genid"]);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from gender where genid='" + genid + "'", conn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                ad.Fill(tb);
                if (tb.Rows.Count > 0)
                {
                    gname.Text = tb.Rows[0]["genname"].ToString().Trim();
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
            int genid = Convert.ToInt32(Request.QueryString["genid"]);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE gender SET genname='" + gname.Text + "' WHERE genid='" + genid + "'", conn);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    Response.Write("<script>alert('Gender updated successfully.'); window.location='addgender.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Error updating');</script>");
                }
            }
        }
    }
}