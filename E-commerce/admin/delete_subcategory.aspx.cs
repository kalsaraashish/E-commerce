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
    public partial class delete_subcategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["subcatid"] != null)
                {
                    int subcatid = Convert.ToInt32(Request.QueryString["subcatid"]);
                    Deletesubcategory(subcatid);
                }
                else
                {
                    Response.Write("<script>alert('Subcategory ID is missing.');</script>");
                }
            }
        }
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";
        protected void Deletesubcategory(int subcatid)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM subcategory WHERE subcatid=@subcatid", conn);
                cmd.Parameters.AddWithValue("@subcatid", subcatid);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("<script>alert('Subcategory Delete successfully.'); window.location='addcategory.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Subcategory Delete successfully.'); window.location='addcategory.aspx';</script>");
                }
                conn.Close();
            }
        }
    }
}