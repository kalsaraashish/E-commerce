using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace E_commerce
{
    public partial class sign_up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connStr);

            string nm = name.Text;
            string password = pass.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string em = email.Text;
            string phone = p_mo.Text;
            string add = address.Text;
            string gender = rdoMale.Checked ? "Male" : (rdoFemale.Checked ? "Female" : "");
            string imagePath = "";

            if (password != confirmPassword)
            {
                Response.Write("<script>alert('Passwords do not match');</script>");
                return;
            }
            if (img.HasFile)
            {
                string fileName = System.IO.Path.GetFileName(img.PostedFile.FileName);
                string filePath = Server.MapPath("~/user_img/") + fileName;
                img.SaveAs(filePath);
                imagePath = "~/user_img/" + fileName;
            }
            conn.Open();
            //SqlCommand cmd = new SqlCommand("insert into user_data(username,password,email,p_number,address,gender,img) values(@nm,@password,@em,@phone,@add,@gen,@imagePath)", conn);
            SqlCommand cmd = new SqlCommand("insert into user_data(username,password,email,p_number,address,gender,img) values(@nm,@password,@em,@phone,@add,@gender,@imagePath)", conn);
            cmd.Parameters.AddWithValue("@nm", nm);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@em", em);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@add", add);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@imagePath", imagePath);
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                Response.Write("<script>alert('Registration Successful');</script>");
                //Response.Redirect("login.aspx");
            }
            else
            {
                Response.Write("<script>alert('Registration Failed');</script>");
            }
            conn.Close();
        }
    }
}