using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace E_commerce
{
    public partial class cart : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindproductcart();
            }
        }

        private void Bindproductcart()
        {
            if (Request.Cookies["cartpid"] != null)
            {
                DataTable dt = new DataTable();
                string cookiedata = Request.Cookies["cartpid"].Value;
                string[] cookiedataArray = cookiedata.Split(',');

                if (cookiedataArray.Length > 0)
                {
                    h3noitems.InnerText = "My Cart (" + cookiedataArray.Length + " Items)";
                    Int64 carttotal = 0;
                    Int64 total = 0;

                    for (int i = 0; i < cookiedataArray.Length; i++)
                    {
                        string[] parts = cookiedataArray[i].Split('-');
                        if (parts.Length != 2) continue; // skip invalid entries

                        string pid = parts[0];
                        string sizeid = parts[1];

                        using (SqlConnection con = new SqlConnection(connStr))
                        {
                            using (SqlCommand view = new SqlCommand("SELECT A.*, dbo.getsizename(@sizeid) AS sizenamee, @sizeid AS sizeidd, sizeData.imgname, sizeData.extension FROM products A CROSS APPLY (SELECT TOP 1 B.imgname, B.extension FROM productimages B WHERE B.pid = A.pid) sizeData WHERE A.pid = @pid", con))
                            {
                                view.Parameters.AddWithValue("@sizeid", sizeid);
                                view.Parameters.AddWithValue("@pid", pid);

                                using (SqlDataAdapter sda = new SqlDataAdapter(view))
                                {
                                    sda.Fill(dt);
                                }
                            }
                        }

                        if (dt.Rows.Count > i)
                        {
                            carttotal += Convert.ToInt64(dt.Rows[i]["price"]);
                            total += Convert.ToInt64(dt.Rows[i]["pselprice"]);
                        }
                    }

                    rpcart.DataSource = dt;
                    rpcart.DataBind();
                    rpcart.Visible = true;

                    spancarttotal.InnerText = carttotal.ToString();
                    spantotal.InnerText = "Rs. " + total.ToString();
                    spandiscaunt.InnerText = "- " + (carttotal - total).ToString();
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
            HttpCookie cookie = Request.Cookies["cartpid"];

            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                string cookiepid = cookie.Value;
                Button btn = (Button)sender;
                string pidsize = btn.CommandArgument;

                List<string> pidList = cookiepid.Split(',')
                                                .Select(i => i.Trim())
                                                .Where(i => !string.IsNullOrEmpty(i))
                                                .ToList();

                bool removed = pidList.Remove(pidsize);

                if (removed)
                {
                    HttpCookie updatedCookie = new HttpCookie("cartpid");
                    if (pidList.Count == 0)
                    {
                        updatedCookie.Expires = DateTime.Now.AddDays(-1); // Delete cookie
                    }
                    else
                    {
                        updatedCookie.Value = string.Join(",", pidList);
                        updatedCookie.Expires = DateTime.Now.AddDays(30);
                    }
                    Response.Cookies.Add(updatedCookie);
                }

                Response.Redirect("cart.aspx");
            }
            else
            {
                Response.Redirect("cart.aspx");
            }
        }

        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("payment.aspx");
            }
            else
            {
                Response.Redirect("sign_in.aspx?rurl=cart");
            }
        }
    }
}
