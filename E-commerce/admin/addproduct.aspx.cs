using System;
using System.Collections;
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
    public partial class addproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindbrand();
                Bindcategory();
                Bindsize();
                Bindgender();
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

        private void Bindsize()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand viewdata = new SqlCommand("select * from sizees", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(viewdata);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    size.DataSource = dataTable;
                    size.DataTextField = "sizename";
                    size.DataValueField = "sid";
                    size.DataBind();
                    size.Items.Insert(0, new ListItem("-select-", "0"));
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
            int maincatid = Convert.ToInt32(category.SelectedItem.Value);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand viewdata = new SqlCommand("select * from subcategory where maincatid= '" + category.SelectedItem.Value + "' ", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(viewdata);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                if (dataTable.Rows.Count != 0)
                {
                    subcategory.DataSource = dataTable;
                    subcategory.DataTextField = "subcatname";
                    subcategory.DataValueField = "subcatid";
                    subcategory.DataBind();
                    subcategory.Items.Insert(0, new ListItem("-select-", "0"));
                }
                conn.Close();
            }
        }
    }
}