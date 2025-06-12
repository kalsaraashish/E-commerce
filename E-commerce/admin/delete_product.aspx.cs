using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace E_commerce.admin
{
    public partial class delete_product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Binddelproduct();
            }
        }

        private void Binddelproduct()
        {
            int pid = Convert.ToInt32(Request.QueryString["pid"]);
            if (pid <= 0)
            {
                Response.Write("<script>alert('Invalid product ID.'); window.location='Viewproduct.aspx';</script>");
                return;
            }
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True"))
            {
                SqlCommand delquantity = new SqlCommand("DELETE FROM pquantity WHERE pid = @pid", conn);
                delquantity.Parameters.AddWithValue("@pid", pid);
                conn.Open();
                int qa = delquantity.ExecuteNonQuery();
                if (qa > 0)
                {
                    SqlCommand pimg = new SqlCommand("DELETE FROM productimages WHERE pid = @pid", conn);
                    pimg.Parameters.AddWithValue("@pid", pid);
                    int  img= pimg.ExecuteNonQuery();
                    if (img > 0) 
                    { 
                        SqlCommand cmd = new SqlCommand("DELETE FROM products WHERE pid = @pid", conn);
                        cmd.Parameters.AddWithValue("@pid", pid);
                        int a= cmd.ExecuteNonQuery();
                        conn.Close();
                       if (a > 0)
                        {
                            Response.Write("<script>alert('Product deleted successfully.'); window.location='Viewproduct.aspx';</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Error deleting product');</script>");
                        }
                    }
                }
            }
        }
    }
}