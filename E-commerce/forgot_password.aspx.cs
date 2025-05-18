using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net.Mail;
using System.Net;

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
                    int uid = Convert.ToInt32(dt.Rows[0]["id"]);
                    
                    SqlCommand emailcheck = new SqlCommand("insert into forgotpass(id,uid,requestdatetime) values('" + myid + "','" + uid + "',GETDATE())", conn);
                    emailcheck.ExecuteNonQuery();

                    //send email
                    string ToEamilAddress = dt.Rows[0]["email"].ToString();
                    string Username = dt.Rows[0]["username"].ToString();
                    string emailBody = "Hello " + Username + ",<br/><br/>" + "Please click the link below to reset your password:<br/>"+ "<a href='https://localhost:44346/recoverpass.aspx?id=" + myid + "'>Reset Password</a><br/><br/>" +
                    "Thank you!<br/>" +
                    "ShopZone Team";
                    MailMessage Passmail = new MailMessage("batukbhaikalsara@gmail.com ",ToEamilAddress);
                    Passmail.Body = emailBody;  
                    Passmail.IsBodyHtml = true;
                    Passmail.Subject = "Password Reset Request";
                    SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 587);
                    SMTP.EnableSsl = true;
                    SMTP.Credentials = new NetworkCredential("batukbhaikalsara@gmail.com", "mnjrysyewpwtmszr");
                    
                    
                    SMTP.Send(Passmail);





                    Response.Write("<script>alert('Password reset link sent to your email.');</script>");
                    
                    email.Text=string.Empty;
                    
                    email.Focus();
                    
                    conn.Close();

                }
                else 
                { 
                    Response.Write("<script>alert('Email not found.');</script>");
                    email.Text = string.Empty;
                    email.Focus();
                }
            }
        }
    }
}