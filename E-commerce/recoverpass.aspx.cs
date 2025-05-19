using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class recoverpass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["id"] == null)
            {
                lblMessage.Text = "Invalid or expired password reset link.";
                btnSubmit.Enabled = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                lblMessage.Text = "Passwords do not match.";
                return;
            }

            string id = Request.QueryString["id"];
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand getUidCmd = new SqlCommand("SELECT uid FROM forgotpass WHERE id = @id", conn);
                getUidCmd.Parameters.AddWithValue("@id", id);

                object result = getUidCmd.ExecuteScalar();

                if (result != null)
                {
                    int uid = Convert.ToInt32(result);
                    
                    SqlCommand updateCmd = new SqlCommand("UPDATE user_data SET password = @pwd WHERE id = @uid", conn);
                    updateCmd.Parameters.AddWithValue("@pwd", txtNewPassword.Text);
                    updateCmd.Parameters.AddWithValue("@uid", uid);

                    updateCmd.ExecuteNonQuery();

                    lblMessage.CssClass = "text-success";
                    lblMessage.Text = "Your password has been successfully reset!";
                    btnSubmit.Enabled = false;
                }
                else
                {
                    lblMessage.Text = "Invalid reset token.";
                }
            }
        
    }
    }
}