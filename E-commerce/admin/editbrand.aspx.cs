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
            Bindbranddata();
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
                    brname.Text = tb.Rows[0]["name"].ToString();
                }
                else
                {
                    // Handle the case where no rows are returned, e.g., show an error message.
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}