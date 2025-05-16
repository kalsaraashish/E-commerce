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
            SqlConnection con=new SqlConnection("Data Source=localhost;Initial Catalog=E-commerce;Integrated Security=True");
            
            string nm=name.Text;
            string password=pass.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string em=email.Text;
            string phone=p_mo.Text;
            string add=address.Text;
            string gender = rdoMale.Checked ? "Male" : (rdoFemale.Checked ? "Female" : "");
            string imagePath = "";

            if (password != confirmPassword)
            {
                Response.Write("<script>alert('Passwords do not match');</script>");
                return;
            }
            if(img.HasFile)
            {
                string fileName = System.IO.Path.GetFileName(img.PostedFile.FileName);
                string filePath = Server.MapPath("~/user_img/") + fileName;
                img.SaveAs(filePath);
                imagePath = "~/user_img/" + fileName;
            }


            SqlCommand cmd=new SqlCommand("insert into user_data values(,@password,@email)",con);
        }
    }
}