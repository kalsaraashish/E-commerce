using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class orderplaced : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (!IsPostBack)
                {
                    Binduserdata();
                    
                }
            }
            else
            {
                Response.Redirect("sign_in.aspx");
            }
        }
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";
        private void Binduserdata()
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM purchase WHERE name=@username ORDER BY id DESC", connection);
                command.Parameters.AddWithValue("@username", Session["username"].ToString());

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    lblOrderID.Text = dt.Rows[0]["id"].ToString();
                    lblName.Text = dt.Rows[0]["name"].ToString().Trim();
                    lblEmail.Text = dt.Rows[0]["email"].ToString().Trim();
                    lblMobile.Text = dt.Rows[0]["m_number"].ToString().Trim();
                    lblTotal.Text = dt.Rows[0]["totalpayed"].ToString().Trim();
                }
            }
        }
    }
}