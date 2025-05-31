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
    public partial class addcategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["msg"] == "success")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Category updated successfully!');", true);
                }
                else if (Request.QueryString["msg"] == "error")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error updating Category.');", true);
                }
                else if(Request.QueryString["msg"] == "successdelete")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Category deleted successfully!');", true);
                }
                else if (Request.QueryString["msg"] == "errorcat")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error deleting Category.');", true);
                }
                Bindmaincat();
                Bindcategorydata();
                Bindsubcategorydata();
            }
        }
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand insertcmd = new SqlCommand("insert into category(catname) values('" + cname.Text + "')", conn);
                insertcmd.ExecuteNonQuery();
                Response.Write("<script>alert('Category added successfully!');</script>");

                cname.Text = string.Empty;
                cname.Focus();
                conn.Close();
                Response.Redirect("~/admin/addcategory.aspx");
            }
        }

        protected void subcatbtn_Click(object sender, EventArgs e)
        {

            if (mcatdroplist.SelectedValue == "0")
            {
                Response.Write("<script>alert('Please select a valid category.');</script>");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();


                SqlCommand insertcatcmd = new SqlCommand("insert into subcategory(subcatname,maincatid) values(@subcatname, @maincatid)", conn);
                insertcatcmd.Parameters.AddWithValue("@subcatname", subcatname.Text);
                insertcatcmd.Parameters.AddWithValue("@maincatid", mcatdroplist.SelectedItem.Value);
                insertcatcmd.ExecuteNonQuery();


                
                Response.Write("<script>alert('SubCategory added successfully!');</script>");

                subcatname.Text = string.Empty;
                mcatdroplist.ClearSelection();
                //mcatdroplist.Items.FindByValue("0").Selected = true;
                Response.Redirect("~/admin/addcategory.aspx");
                conn.Close();
            }
        }
        private void Bindmaincat()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand viewdata = new SqlCommand("select * from category", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(viewdata);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    mcatdroplist.DataSource = dataTable;
                    mcatdroplist.DataTextField = "catname";
                    mcatdroplist.DataValueField = "catid";
                    mcatdroplist.DataBind();
                    //mcatdroplist.Items.Insert(0,new ListItem("-select-","0"));
                }
                conn.Close();
            }

        }
        private void Bindcategorydata()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand viewdata = new SqlCommand("select * from category", conn);
                SqlDataAdapter da = new SqlDataAdapter(viewdata);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rp.DataSource = dt;
                rp.DataBind();
                conn.Close();
            }
        }
        private void Bindsubcategorydata()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand viewdata = new SqlCommand("select c.*, s.* from subcategory s inner join category c on c.catid=s.maincatid", conn);
                SqlDataAdapter da = new SqlDataAdapter(viewdata);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rp2.DataSource = dt;
                rp2.DataBind();
                conn.Close();
            }
        }
    }
}