using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.admin
{
    public partial class adminhomepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                if (Session["username"] == null)
                {
                    Response.Redirect("../sign_out.aspx");
                }
                else
                {
                    Binduserdata();
                    Bindpurchasedata();
                }
            
        }
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

        private void Binduserdata()
        {
           SqlConnection con=new SqlConnection(connStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from user_data", con);
            SqlDataAdapter ad=new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            userdata.DataSource = dt;
            userdata.DataBind();
            con.Close();
        }

        private void Bindpurchasedata()
        {
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from purchase", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            pdata.DataSource = dt;
            pdata.DataBind();
            con.Close();
        }
    }
}