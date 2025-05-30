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
    public partial class delete_brand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["brid"] != null)
                {
                    int brid = Convert.ToInt32(Request.QueryString["brid"]);
                    DeleteBrand(brid);
                }
                else
                {
                    Response.Write("<script>alert('Brand ID is missing.');</script>");
                }
            }
        }
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";
        protected void DeleteBrand(int brid)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM brand WHERE brid=@brid", conn);
                cmd.Parameters.AddWithValue("@brid", brid);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Redirect("addbrand.aspx?msg=successdelete"); 
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