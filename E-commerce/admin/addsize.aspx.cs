using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace E_commerce.admin
{
    public partial class addsize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindbrand();
                Bindcategory();
                Bindgender();
                Bindsize();
            }
        }

        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

        private void Bindsize()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand viewdata = new SqlCommand("select A.*,B.*,C.*,D.*,E.* from sizees A inner join brand B on B.brid= A.brid inner join category C on c.catId=A.catid  inner join subcategory D on D.subcatId=A.subcatid inner join gender E on E.genId=A.genid", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(viewdata);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                sizerp.DataSource = dataTable;
                sizerp.DataBind();
                conn.Close();
            }
        }
        private bool IsValidBrand(string brid)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand checkBrand = new SqlCommand("SELECT COUNT(*) FROM brand WHERE brid = @brid", conn);
                checkBrand.Parameters.AddWithValue("@brid", brid);
                int count = (int)checkBrand.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }
        protected void btnsize_Click(object sender, EventArgs e)
        {
            string brid = brlist.SelectedItem.Value;
            if (!IsValidBrand(brid))
            {
                Response.Write("<script>alert('Invalid brand selected.');</script>");
                return;
            }
            // Repeat similar checks for category, subcategory, and gender if needed

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand insertdata = new SqlCommand("insert into sizees(sizename,brid,catid,subcatid,genid) values(@sizename,@brid,@catid,@subcatid,@genid)", conn);
                insertdata.Parameters.AddWithValue("@sizename", sizename.Text);
                insertdata.Parameters.AddWithValue("@brid", brid);
                insertdata.Parameters.AddWithValue("@catid", catlist.SelectedItem.Value);
                insertdata.Parameters.AddWithValue("@subcatid", subcatlist.SelectedItem.Value);
                insertdata.Parameters.AddWithValue("@genid", genlist.SelectedItem.Value);
                int a = insertdata.ExecuteNonQuery();
                conn.Close();
                if (a > 0)
                {
                    Response.Write("<script>alert('Size Added successfully!');</script>");
                    // ... rest of your code
                    sizename.Text = string.Empty;

                    brlist.ClearSelection();
                    brlist.Items.FindByValue("0").Selected = true;

                    catlist.ClearSelection();
                    catlist.Items.FindByValue("0").Selected = true;

                    subcatlist.ClearSelection();
                    subcatlist.Items.FindByValue("0").Selected = true;

                    genlist.ClearSelection();
                    genlist.Items.FindByValue("0").Selected = true;
                }
                Bindsize();
            }
        }

        

        private void Bindbrand()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand viewdata = new SqlCommand("select * from brand", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(viewdata);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    brlist.DataSource = dataTable;
                    brlist.DataTextField = "name";
                    brlist.DataValueField = "brid";
                    brlist.DataBind();
                    brlist.Items.Insert(0,new ListItem("-select-","0"));
                }
                conn.Close();
            }

        }
        private void Bindcategory()
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
                    catlist.DataSource = dataTable;
                    catlist.DataTextField = "catname";
                    catlist.DataValueField = "catid";
                    catlist.DataBind();
                    catlist.Items.Insert(0,new ListItem("-select-","0"));
                }
                conn.Close();
            }

        }

        

        private void Bindgender()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand viewdata = new SqlCommand("select * from gender", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(viewdata);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    genlist.DataSource = dataTable;
                    genlist.DataTextField = "genname";
                    genlist.DataValueField = "genid";
                    genlist.DataBind();
                    genlist.Items.Insert(0,new ListItem("-select-","0"));
                }
                conn.Close();
            }

        }

        protected void catlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maincatid = Convert.ToInt32(catlist.SelectedItem.Value);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand viewdata = new SqlCommand("select * from subcategory where maincatid= '"+catlist.SelectedItem.Value+"' ", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(viewdata);
                
                DataTable dataTable = new DataTable();
                
                adapter.Fill(dataTable);
                
                if (dataTable.Rows.Count != 0)
                {
                    subcatlist.DataSource = dataTable;
                    subcatlist.DataTextField = "subcatname";
                    subcatlist.DataValueField = "subcatid";
                    subcatlist.DataBind();
                    subcatlist.Items.Insert(0, new ListItem("-select-", "0"));
                }
                conn.Close();
            }

        }
    }
}