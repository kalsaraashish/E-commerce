using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Data;


namespace E_commerce
{
    public partial class sign_up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            if (!IsFormValid())
                return;

            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);

            string nm = name.Text.Trim();
            string password = pass.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string em = email.Text.Trim();
            string phone = p_mo.Text.Trim();
            string add = address.Text.Trim();
            string gender = rdoMale.Checked ? "Male" : (rdoFemale.Checked ? "Female" : "");
            string imagePath = "";

            if (password != confirmPassword)
            {
                Response.Write("<script>alert('Passwords do not match');</script>");
                return;
            }

            if (img.HasFile)
            {
                try
                {
                    string imgDir = Server.MapPath("/img/");
                    if (!System.IO.Directory.Exists(imgDir))
                    {
                        System.IO.Directory.CreateDirectory(imgDir);
                    }
                    string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(img.FileName);
                    string filePath = System.IO.Path.Combine(imgDir, fileName);
                    img.SaveAs(filePath);
                    imagePath = "/img/" + fileName;
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Image upload failed: " + ex.Message.Replace("'", "") + "');</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script>alert('Please upload a profile image');</script>");
                return;
            }

            conn.Open();

            // 🔒 Check if email already exists
            SqlCommand checkEmail = new SqlCommand("SELECT COUNT(*) FROM user_data WHERE email = @em", conn);
            checkEmail.Parameters.AddWithValue("@em", em);
            int emailExists = (int)checkEmail.ExecuteScalar();

            if (emailExists > 0)
            {
                Response.Write("<script>alert('Email already registered');</script>");
                conn.Close();
                return;
            }

            // ✅ Insert user
            SqlCommand cmd = new SqlCommand("INSERT INTO user_data(username, password, email, p_number, address, gender, img,usertype) VALUES (@nm, @password, @em, @phone, @add, @gender, @imagePath,'user')", conn);
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
                Response.Redirect("sign_in.aspx");
                name.Text = string.Empty;
                pass.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
                email.Text = string.Empty;
                p_mo.Text = string.Empty;
                address.Text = string.Empty;
                rdoMale.Checked = false;
                rdoFemale.Checked = false;
                img.Attributes.Clear();
            }
            else
            {
                Response.Write("<script>alert('Registration Failed');</script>");
            }
            conn.Close();
        }

        private bool IsFormValid()
        {
            if (string.IsNullOrWhiteSpace(name.Text))
            {
                Response.Write("<script>alert('Username is required');</script>");
                return false;
            }

            if (string.IsNullOrWhiteSpace(pass.Text))
            {
                Response.Write("<script>alert('Password is required');</script>");
                return false;
            }

            if (pass.Text.Length < 6 || !Regex.IsMatch(pass.Text, @"[A-Z]") || !Regex.IsMatch(pass.Text, @"[0-9]"))
            {
                Response.Write("<script>alert('Password must be at least 6 characters with at least one uppercase letter and one number');</script>");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                Response.Write("<script>alert('Confirm Password is required');</script>");
                return false;
            }

            if (string.IsNullOrWhiteSpace(email.Text))
            {
                Response.Write("<script>alert('Email is required');</script>");
                return false;
            }

            if (!Regex.IsMatch(email.Text, @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$"))
            {
                Response.Write("<script>alert('Invalid email format');</script>");
                return false;
            }

            if (string.IsNullOrWhiteSpace(p_mo.Text))
            {
                Response.Write("<script>alert('Phone number is required');</script>");
                return false;
            }

            if (!Regex.IsMatch(p_mo.Text, @"^\d{10}$"))
            {
                Response.Write("<script>alert('Phone number must be 10 digits');</script>");
                return false;
            }

            if (string.IsNullOrWhiteSpace(address.Text))
            {
                Response.Write("<script>alert('Address is required');</script>");
                return false;
            }

            if (!rdoMale.Checked && !rdoFemale.Checked)
            {
                Response.Write("<script>alert('Please select gender');</script>");
                return false;
            }

            return true;
        }
    }
}
