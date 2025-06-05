using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if (Request.Cookies["cartpid"] == null || string.IsNullOrWhiteSpace(Request.Cookies["cartpid"].Value))
            {
                ShowEmptyCart();
                return;
            }

            string[] items = Request.Cookies["cartpid"].Value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length == 0)
            {
                ShowEmptyCart();
                return;
            }

            DataTable dt = new DataTable();
            long mrpTotal = 0;
            long saleTotal = 0;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                foreach (string item in items)
                {
                    string[] parts = item.Split('-'); // Format: pid-sizeid
                    if (parts.Length != 2) continue;

                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT A.*, 
                               dbo.getsizename(@sid) AS sizenamee, 
                               @sid AS sizeidd, 
                               img.imgname, 
                               img.extension
                        FROM products A
                        CROSS APPLY (
                            SELECT TOP 1 B.imgname, B.extension 
                            FROM productimages B 
                            WHERE B.pid = A.pid
                        ) img
                        WHERE A.pid = @pid", con))
                    {
                        cmd.Parameters.AddWithValue("@sid", parts[1]);
                        cmd.Parameters.AddWithValue("@pid", parts[0]);

                        dt.Load(cmd.ExecuteReader());
                    }
                }
            }

            if (dt.Rows.Count == 0)
            {
                ShowEmptyCart();
                return;
            }

            foreach (DataRow r in dt.Rows)
            {
                mrpTotal += Convert.ToInt64(r["price"]);
                saleTotal += Convert.ToInt64(r["pselprice"]);
            }

            rpcart.DataSource = dt;
            rpcart.DataBind();
            rpcart.Visible = true;

            h3noitems.InnerText = "My Cart (" + dt.Rows.Count + " Items)";
            spancarttotal.InnerText = "Rs. " + mrpTotal.ToString("N0");
            spantotal.InnerText = "Rs. " + saleTotal.ToString("N0");
            spandiscaunt.InnerText = "- Rs. " + (mrpTotal - saleTotal).ToString("N0");

            btnBuyNow.Visible = true;
        }

        private void ShowEmptyCart()
        {
            h3noitems.InnerText = "Your shopping cart is empty";
            rpcart.Visible = false;
            btnBuyNow.Visible = false;
        }

        protected void btnRemove1_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["cartpid"];
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                string cookieValue = cookie.Value;
                Button btn = (Button)sender;
                string pidsize = btn.CommandArgument;

                List<string> pidList = cookieValue.Split(',')
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
                    updatedCookie.Path = "/";
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
