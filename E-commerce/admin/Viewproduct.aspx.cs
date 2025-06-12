using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.admin
{
    public partial class Viewproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                //Bindqu();
            }
        }

       

        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

        private void BindGrid()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter ad = new SqlDataAdapter(@"
SELECT 
    p.pid,
    p.pname,
    p.price,
    p.pselprice,
    b.name,
    c.catname,
    sc.subcatname,
    g.genname,
    p.pdescription,
    p.productdetails,
    p.matcare,
    q.quantity
FROM products p
JOIN brand b ON p.pbrid = b.brid
JOIN category c ON p.pcatid = c.catid
JOIN subcategory sc ON p.psubcatid = sc.subcatid
JOIN gender g ON p.pgenid = g.genid
LEFT JOIN pquantity q ON p.pid = q.pid", conn);

                DataTable dt = new DataTable();
                ad.Fill(dt);
                viewproduct.DataSource = dt;
                viewproduct.DataBind();
            }
        }
        //private void Bindqu()
        //{
        //    using (SqlConnection conn = new SqlConnection(connStr))
        //    {
        //        SqlDataAdapter ad = new SqlDataAdapter(@"
        //    select 
        //        p.pid 
        //    from products p 
        //    JOIN pquantity q ON p.pid=q.pid", conn);

        //        DataTable dt = new DataTable();
        //        ad.Fill(dt);
        //        viewproduct.DataSource = dt;
        //        viewproduct.DataBind();
        //    }
        //}

    }
}