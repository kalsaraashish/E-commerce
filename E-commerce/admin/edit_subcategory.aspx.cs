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
                    Response.Write("No subcategory data found.");
                }
            }
        }

        protected void subcatbtn_Click(object sender, EventArgs e)
        {
            int subcatid = Convert.ToInt32(Request.QueryString["subcatid"]);
            int selectedCatid = Convert.ToInt32(mcatdroplist.SelectedValue);
            string updatedSubcatName = subcatname.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Check current data before updating
                string currentSubcatName = "";
                int currentMainCatId = 0;

                SqlCommand checkCmd = new SqlCommand("SELECT subcatname, maincatid FROM subcategory WHERE subcatid=@subcatid", conn);
                checkCmd.Parameters.AddWithValue("@subcatid", subcatid);
                SqlDataReader reader = checkCmd.ExecuteReader();
                if (reader.Read())
                {
                    currentSubcatName = reader["subcatname"].ToString().Trim();
                    currentMainCatId = Convert.ToInt32(reader["maincatid"]);
                }
                reader.Close();

                // If no changes, inform user
                if (currentSubcatName == updatedSubcatName && currentMainCatId == selectedCatid)
                {
                    Response.Write("<script>alert('No changes detected.');</script>");
                    return;
                }

                // Update only if data is different
                SqlCommand updateCmd = new SqlCommand("UPDATE subcategory SET subcatname=@subcatname, maincatid=@maincatid WHERE subcatid=@subcatid", conn);
                updateCmd.Parameters.AddWithValue("@subcatname", updatedSubcatName);
                updateCmd.Parameters.AddWithValue("@maincatid", selectedCatid);
                updateCmd.Parameters.AddWithValue("@subcatid", subcatid);

                int rowsAffected = updateCmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("<script>alert('Subcategory updated successfully.'); window.location='addcategory.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Update failed.');</script>");
                }
            }
        }
    }
}
