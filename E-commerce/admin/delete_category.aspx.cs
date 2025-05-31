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
    public partial class delete_category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["catid"] != null)
                {
                    int catid = Convert.ToInt32(Request.QueryString["catid"]);
                    Deletecategory(catid);
                }
                else
                {
                    Response.Write("<script>alert('Brand ID is missing.');</script>");
                }
            }
        }
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";
        protected void Deletecategory(int catid)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand checksubcat = new SqlCommand("select * from subcategory where maincatid='"+ catid +"'",conn);
                SqlDataAdapter ad = new SqlDataAdapter(checksubcat);
                DataTable tb = new DataTable();
                ad.Fill(tb);
                if (tb.Rows.Count > 0)
                {
                    SqlCommand delsubcat = new SqlCommand("DELETE FROM subcategory WHERE maincatid='" + catid + "'", conn);
                    int checksub = delsubcat.ExecuteNonQuery();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM category WHERE catid=@catid", conn);
                cmd.Parameters.AddWithValue("@catid", catid);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Redirect("addcategory.aspx?msg=successdelete");
                }
                else
                {
                    Response.Redirect("addcategory.aspx?msg=errorcat");
                }
                conn.Close();
            }
        }
    }
}