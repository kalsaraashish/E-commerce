using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace E_commerce
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindproductcart();
            }
        }
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";
        private void Bindproductcart()
        {

            if (Request.Cookies["cartpid"] != null)
            {
                DataTable dt = new DataTable();
               
                string cookiedata = Request.Cookies["cartpid"].Value;
                string [] cookiedataArray = cookiedata.Split(',');
                //cookiepid = cookiepid + "," + pid + "-" + selectedsize;

                //HttpCookie cartproducts = new HttpCookie("cartpid");
                //cartproducts.Value = cookiepid;
                //cartproducts.Expires = DateTime.Now.AddDays(30);
                //Response.Cookies.Add(cartproducts);
                if (cookiedataArray.Length > 0)
                {
                    h3noitems.InnerText = "My Cart("+cookiedataArray.Length+ "Items)";
                    Int64 carttotal = 0;
                    Int64 total = 0;
                    for (int i = 0; i < cookiedataArray.Length; i++)
                    {
                        string pid = cookiedataArray[i].ToString().Split('-')[0];
                        string sizeid = cookiedataArray[i].ToString().Split('-')[1];

                        using (SqlConnection con = new SqlConnection(connStr))
                        {
                            //using (SqlCommand view = new SqlCommand("SELECT A.*, dbo.getsizename(@sizeid) AS sizenamee, @sizeid AS sizeidd, sizeData.sizename, sizeData.extension FROM products A CROSS APPLY (SELECT TOP 1 B.imgname, B.extension FROM productimages B WHERE B.pid = A.pid) sizeData WHERE A.pid = @pid", con))
                            using (SqlCommand view = new SqlCommand("SELECT A.*, dbo.getsizename(@sizeid) AS sizenamee, @sizeid AS sizeidd,    sizeData.imgname, sizeData.extension FROM products A CROSS APPLY ( SELECT TOP 1 B.imgname, B.extension FROM productimages B WHERE B.pid = A.pid) sizeData WHERE A.pid = @pid", con))
                            {
                                view.Parameters.AddWithValue("@sizeid", sizeid);
                                view.Parameters.AddWithValue("@pid", pid);
                                using (SqlDataAdapter sda = new SqlDataAdapter(view))
                                {
                                    sda.Fill(dt);
                                }
                            }
                        }

                    carttotal += Convert.ToInt64(dt.Rows[i]["price"]);
                    total += Convert.ToInt64(dt.Rows[i]["pselprice"]);
                    }
                rpcart.DataSource = dt;
                rpcart.DataBind();
                rpcart.Visible = true;

                    spancarttotal.InnerText = carttotal.ToString();
                    spantotal.InnerText = "Rs. "+total.ToString();
                    spandiscaunt.InnerText= "- " + (carttotal - total).ToString();
                }


                else
                {
                    h3noitems.InnerText = "Your shopping Cart is Empty";
                    rpcart.Visible = false;
                }

            }
            else
            {
                h3noitems.InnerText = "Your shopping Cart is Empty";
                rpcart.Visible = false;
            }

        }

        protected void btnRemove1_Click(object sender, EventArgs e)
        {

        }
        protected void btnBuyNow_Click(object sender, EventArgs e)
        {

        }

    }
}