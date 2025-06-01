using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.admin
{
    public partial class delete_gender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["genid"] != null)
            {
                int genid = Convert.ToInt32(Request.QueryString["genid"]);
                DeleteBrand(genid);
            }
            else
            {
                Response.Write("<script>alert('Gender ID is missing.');</script>");
            }

        }

        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

        private void DeleteBrand(int genid)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM gender WHERE genid=@genid", conn);
                cmd.Parameters.AddWithValue("@genid", genid);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("<script>alert('Gender Delete successfully.'); window.location='addgender.aspx';</script>");
                }
                else
                {
                    Response.Redirect("<script>alert('Gender Delete successfully.');</script>");
                }
                conn.Close();
            }
        }
    }
}