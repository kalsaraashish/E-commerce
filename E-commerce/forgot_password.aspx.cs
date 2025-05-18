using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace E_commerce
{
    public partial class forgot_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("select * from user_data where email=@email", conn);
                cmd.Parameters.AddWithValue("@email", email.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                int a = da.Fill(dt);

                if (a > 0)
                {
                    string myid = Guid.NewGuid().ToString();
                    int uid = Convert.ToInt32(dt.Rows[0]["uid"]);
                    SqlCommand emailcheck = new SqlCommand("insert into forgotpass(id,uid,requestdatetime) values('" + myid + "','" + uid + "',GETDATE())", conn);
                    emailcheck.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}