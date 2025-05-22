using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace E_commerce.admin
{
    public partial class addproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindbrand();
                Bindcategory();
                Bindgender();

                subcategory.Enabled = false;
                gen.Enabled = false;
            }
        }
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";


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
                   brand.DataTextField = "name";
                   brand.DataSource = dataTable;
                   brand.DataValueField = "brid";
                   brand.DataBind();
                   brand.Items.Insert(0, new ListItem("-select-", "0"));
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
                    category.DataSource = dataTable;
                    category.DataTextField = "catname";
                    category.DataValueField = "catid";
                    category.DataBind();
                    category.Items.Insert(0, new ListItem("-select-", "0"));
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
                    gen.DataSource = dataTable;
                    gen.DataTextField = "genname";
                    gen.DataValueField = "genid";
                    gen.DataBind();
                    gen.Items.Insert(0, new ListItem("-select-", "0"));
                }
                conn.Close();
            }

        }




        protected void category_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCatId = Convert.ToInt32(category.SelectedValue);

            if (selectedCatId == 0)
            {
                // Clear and disable subcategory and gender dropdowns
                subcategory.Items.Clear();
                subcategory.Items.Insert(0, new ListItem("-select-", "0"));
                subcategory.Enabled = false;

                gen.Items.Clear();
                gen.Items.Insert(0, new ListItem("-select-", "0"));
                gen.Enabled = false;

                sizeList.Items.Clear(); // Also clear sizes if they were bound
                return;
            }

            // Load related subcategories
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand viewdata = new SqlCommand("SELECT * FROM subcategory WHERE maincatid = @catid", conn);
                viewdata.Parameters.AddWithValue("@catid", selectedCatId);

                SqlDataAdapter adapter = new SqlDataAdapter(viewdata);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    subcategory.DataSource = dataTable;
                    subcategory.DataTextField = "subcatname";
                    subcategory.DataValueField = "subcatid";
                    subcategory.DataBind();
                    subcategory.Items.Insert(0, new ListItem("-select-", "0"));
                    subcategory.Enabled = true;
                }
                else
                {
                    subcategory.Items.Clear();
                    subcategory.Items.Insert(0, new ListItem("-select-", "0"));
                    subcategory.Enabled = false;
                }

                conn.Close();
            }

            // Reset other dependent fields
            gen.Items.Clear();
            gen.Items.Insert(0, new ListItem("-select-", "0"));
            gen.Enabled = false;

            sizeList.Items.Clear();
        }


        protected void subcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (subcategory.SelectedIndex != 0)
            {
                gen.Enabled = true;

                // Load gender based on current brand, category, and subcategory
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT g.genid, g.genname FROM gender g " + "INNER JOIN sizees s ON g.genid = s.genid " + "WHERE s.brid = @brid AND s.catid = @catid AND s.subcatid = @subcatid", conn);

                    cmd.Parameters.AddWithValue("@brid", brand.SelectedValue);
                    cmd.Parameters.AddWithValue("@catid", category.SelectedValue);
                    cmd.Parameters.AddWithValue("@subcatid", subcategory.SelectedValue);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        gen.DataSource = dt;
                        gen.DataTextField = "genname";
                        gen.DataValueField = "genid";
                        gen.DataBind();
                        gen.Items.Insert(0, new ListItem("-select-", "0"));
                    }
                    else
                    {
                        gen.Items.Clear();
                        gen.Items.Insert(0, new ListItem("-select-", "0"));
                    }

                    conn.Close();
                }
            }
            else
            {
                gen.Enabled = false;
                gen.Items.Clear();
                gen.Items.Insert(0, new ListItem("-select-", "0"));
            }

            sizeList.Items.Clear(); // Clear size if subcategory is changed
        }

        protected void gen_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand viewdata = new SqlCommand("SELECT * FROM sizees WHERE brid= @brid AND catid= @catid AND subcatid= @subcatid AND genid= @genid", conn);
                viewdata.Parameters.AddWithValue("@brid", brand.SelectedItem.Value);
                viewdata.Parameters.AddWithValue("@catid", category.SelectedItem.Value);
                viewdata.Parameters.AddWithValue("@subcatid", subcategory.SelectedItem.Value);
                viewdata.Parameters.AddWithValue("@genid", gen.SelectedItem.Value);

                SqlDataAdapter adapter = new SqlDataAdapter(viewdata);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    sizeList.DataSource = dataTable;
                    sizeList.DataTextField = "sizename";
                    sizeList.DataValueField = "sid";
                    sizeList.DataBind();
                }
                else
                {
                    sizeList.Items.Clear();
                }

                conn.Close();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand indata = new SqlCommand("sp_Insertproduct",conn);
                indata.CommandType=CommandType.StoredProcedure;
                indata.Parameters.AddWithValue("@pname", pname.Text);
                indata.Parameters.AddWithValue("@price", price.Text);
                indata.Parameters.AddWithValue("@pselprice", sprice.Text);
                indata.Parameters.AddWithValue("@pbrandid", brand.SelectedItem.Value);
                indata.Parameters.AddWithValue("@pcatid", category.SelectedItem.Value);
                indata.Parameters.AddWithValue("@psubcatid", subcategory.SelectedItem.Value);
                indata.Parameters.AddWithValue("@pgenid", gen.SelectedItem.Value);
                indata.Parameters.AddWithValue("@pdiscription", description.Text);
                indata.Parameters.AddWithValue("@productdetails", productdetails.Text);
                indata.Parameters.AddWithValue("@matcare", materialcare.Text);

                //1 is for true and 0 is for false
                if (chkFreeDelivery.Checked = true)
                {
                    indata.Parameters.AddWithValue("@freedelivery", 1.ToString());
                }
                else
                {
                    indata.Parameters.AddWithValue("@freedelivery", 0.ToString());
                }
                if (chk30DayReturn.Checked = true)
                {
                    indata.Parameters.AddWithValue("@chk30DayReturn", 1.ToString());
                }
                else
                {
                    indata.Parameters.AddWithValue("@chk30DayReturn", 0.ToString());
                }
                if (chkCOD.Checked = true)
                {
                    indata.Parameters.AddWithValue("@chkCOD", 1.ToString());
                }
                else
                {
                    indata.Parameters.AddWithValue("@chkCOD", 0.ToString());
                }
                conn.Open();

                conn.Close();
            }
                //            create procedure sp_Insertproduct
                //(
                //@pname nvarchar(500),
                //@price money,
                //@pselprice money,
                //@pbrandid int,
                //@pcatid int,
                //@psubcatid int,
                //@pgenid int,
                //@pdiscription nvarchar(500),
                //@productdetails nvarchar(500),
                //@matcare nvarchar(500),
                //@freedelivery int,
                //@chk30DayReturn int,
                //@chkCOD int
                //)
                //as
                //insert into products values(@pname, @price, @pselprice, @pbrandid, @pcatid, @psubcatid, @pgenid, @pdiscription, @productdetails, @matcare, @freedelivery, @chk30DayReturn,
                //@chkCOD);
                //            select SCOPE_IDENTITY()
                //return 0;
        }
    }
}