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
            Bindmaincat();
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
           

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand insertcmd = new SqlCommand("insert into subcategory(subcatname,maincatid) values('" + subcatname.Text + "','"+mcatdroplist.SelectedItem.Value+"')", conn);
                insertcmd.ExecuteNonQuery();
                Response.Write("<script>alert('SubCategory added successfully!');</script>");
                
                subcatname.Text = string.Empty;
                mcatdroplist.ClearSelection();
                mcatdroplist.Items.FindByValue("0").Selected = true;
               
                conn.Close();
            }
        }
        private void Bindmaincat()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand viewdata = new SqlCommand("select * from category",conn);
                SqlDataAdapter adapter = new SqlDataAdapter(viewdata);
                DataTable dataTable = new DataTable();  
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count !=0)
                {
                    mcatdroplist.DataSource = dataTable;
                    mcatdroplist.DataTextField = "catname";
                    mcatdroplist.DataValueField = "catid";
                    mcatdroplist.DataBind();
                }
                conn.Close ();
            }

            }
    }
}