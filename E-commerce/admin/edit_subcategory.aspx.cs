using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace E_commerce.admin
{
    public partial class edit_subcategory : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMainCategories();
                BindSubcatData();
            }
        }

        private void BindMainCategories()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM category", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    mcatdroplist.DataSource = dt;
                    mcatdroplist.DataTextField = "catname";
                    mcatdroplist.DataValueField = "catid";
                    mcatdroplist.DataBind();
                }
            }
        }

        private void BindSubcatData()
        {
            if (Request.QueryString["subcatid"] != null)
            {
                int subcatid = Convert.ToInt32(Request.QueryString["subcatid"]);

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM subcategory WHERE subcatid=@subcatid", conn);
                    cmd.Parameters.AddWithValue("@subcatid", subcatid);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        subcatname.Text = dt.Rows[0]["subcatname"].ToString().Trim();
                        string catid = dt.Rows[0]["maincatid"].ToString();
                        mcatdroplist.SelectedValue = catid;
                    }
                    else
                    {
                        Response.Write("<script>alert('No subcategory data found.');</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('No subcategory ID specified.');</script>");
            }
        }

        protected void subcatbtn_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["subcatid"] != null)
            {
                int subcatid = Convert.ToInt32(Request.QueryString["subcatid"]);
                int selectedCatid = Convert.ToInt32(mcatdroplist.SelectedValue);
                string updatedSubcatName = subcatname.Text.Trim();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand updateCmd = new SqlCommand("UPDATE subcategory SET subcatname=@subcatname, maincatid=@maincatid WHERE subcatid=@subcatid", conn);
                    updateCmd.Parameters.AddWithValue("@subcatname", updatedSubcatName);
                    updateCmd.Parameters.AddWithValue("@maincatid", selectedCatid);
                    updateCmd.Parameters.AddWithValue("@subcatid", subcatid);

                    int rowsAffected = updateCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Alert + redirect using JavaScript
                        Response.Write("<script>alert('Subcategory updated successfully.'); window.location='addcategory.aspx';</script>");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("<script>alert('Update failed. No rows affected.');</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('No subcategory ID specified.');</script>");
            }
        }
    }
}
