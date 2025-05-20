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
                Bindsubcategory();
                Bindgender();
            }
        }

        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

        protected void btnsize_Click(object sender, EventArgs e)
        {
            
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
                    //mcatdroplist.Items.Insert(0,new ListItem("-select-","0"));
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
                    //mcatdroplist.Items.Insert(0,new ListItem("-select-","0"));
                }
                conn.Close();
            }

        }

        private void Bindsubcategory()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand viewdata = new SqlCommand("select * from subcategory", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(viewdata);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    subcatlist.DataSource = dataTable;
                    subcatlist.DataTextField = "subcatname";
                    subcatlist.DataValueField = "subcatid";
                    subcatlist.DataBind();
                    //mcatdroplist.Items.Insert(0,new ListItem("-select-","0"));
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
                    //mcatdroplist.Items.Insert(0,new ListItem("-select-","0"));
                }
                conn.Close();
            }

        }

    }
}