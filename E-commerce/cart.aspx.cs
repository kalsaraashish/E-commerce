using System;
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
        private readonly string connStr =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) Bindproductcart();
        }

        /* -----------------------------------------------------------
         *  Build the cart grid + price summary
         * ----------------------------------------------------------*/
        private void Bindproductcart()
        {
            if (Request.Cookies["cartpid"] == null ||
                string.IsNullOrWhiteSpace(Request.Cookies["cartpid"].Value))
            {
                ShowEmptyCart(); return;
            }

            string[] items = Request.Cookies["cartpid"].Value
                             .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (items.Length == 0) { ShowEmptyCart(); return; }

            DataTable dt = new DataTable();
            long mrpTotal = 0, saleTotal = 0;
            int totalItems = 0;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                foreach (string item in items)
                {
                    string[] parts = item.Split('-'); // pid-sizeid
                    if (parts.Length != 2) continue;

                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT P.*, 
                               dbo.getsizename(@sid)        AS sizenamee,
                               @sid                         AS sizeidd,
                               ISNULL(Q.quantity,1)         AS qty,
                               I.imgname, I.extension
                        FROM   products P
                        CROSS APPLY
                               (SELECT TOP 1 imgname, extension
                                FROM productimages
                                WHERE pid = P.pid) I
                        LEFT JOIN pquantity Q
                               ON Q.pid = P.pid AND Q.sid = @sid
                        WHERE  P.pid = @pid", con))
                    {
                        cmd.Parameters.AddWithValue("@sid", parts[1]);
                        cmd.Parameters.AddWithValue("@pid", parts[0]);
                        dt.Load(cmd.ExecuteReader());
                    }
                }
            }

            if (dt.Rows.Count == 0) { ShowEmptyCart(); return; }

            foreach (DataRow r in dt.Rows)
            {
                int qty = Convert.ToInt32(r["qty"]);
                totalItems += qty;
                mrpTotal += Convert.ToInt64(r["price"]) * qty;
                saleTotal += Convert.ToInt64(r["pselprice"]) * qty;
            }

            rpcart.DataSource = dt;
            rpcart.DataBind();
            rpcart.Visible = true;

            h3noitems.InnerText = $"My Cart ({totalItems} Items)";
            spancarttotal.InnerText = "Rs. " + mrpTotal.ToString("N0");
            spantotal.InnerText = "Rs. " + saleTotal.ToString("N0");
            spandiscaunt.InnerText = "- Rs. " + (mrpTotal - saleTotal).ToString("N0");
            btnBuyNow.Visible = true;
        }

        /* ----------------------------------------------------------- */
        private void ShowEmptyCart()
        {
            h3noitems.InnerText = "Your shopping cart is empty";
            rpcart.Visible = btnBuyNow.Visible = false;
        }

        /* -----------------------------------------------------------
         *  + / – quantity buttons (Repeater command)
         * ----------------------------------------------------------*/
        protected void rpcart_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] parts = e.CommandArgument.ToString().Split('-');
            if (parts.Length != 2) return;

            int pid = Convert.ToInt32(parts[0]);
            int sid = Convert.ToInt32(parts[1]);

            string action = e.CommandName; // "Inc" or "Dec"
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand { Connection = con };

                if (action == "Inc")
                {
                    cmd.CommandText = @"
                        IF EXISTS (SELECT 1 FROM pquantity WHERE pid=@pid AND sid=@sid)
                            UPDATE pquantity SET quantity = quantity + 1
                            WHERE pid=@pid AND sid=@sid
                        ELSE
                            INSERT INTO pquantity(pid,sid,quantity) VALUES(@pid,@sid,1)";
                }
                else if (action == "Dec")
                {
                    cmd.CommandText = @"
                        IF EXISTS (SELECT 1 FROM pquantity WHERE pid=@pid AND sid=@sid)
                            UPDATE pquantity SET quantity =
                                   CASE WHEN quantity > 1 THEN quantity - 1 ELSE 1 END
                            WHERE pid=@pid AND sid=@sid";
                }
                else return; // unknown action

                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@sid", sid);
                cmd.ExecuteNonQuery();
            }

            Bindproductcart(); // refresh UI & totals
        }

        /* -----------------------------------------------------------
         *  Remove item button
         * ----------------------------------------------------------*/
        protected void btnRemove1_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["cartpid"];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
            {
                Response.Redirect("cart.aspx");
                return;
            }

            string cookieValue = cookie.Value;
            Button btn = (Button)sender;
            string pidsize = btn.CommandArgument;

            var list = cookieValue.Split(',')
                                  .Where(i => !string.IsNullOrEmpty(i) && i != pidsize)
                                  .ToList();

            HttpCookie updated = new HttpCookie("cartpid") { Path = "/" };
            if (list.Count == 0)
                updated.Expires = DateTime.Now.AddDays(-1);
            else
            {
                updated.Value = string.Join(",", list);
                updated.Expires = DateTime.Now.AddDays(30);
            }

            Response.Cookies.Add(updated);
            Response.Redirect("cart.aspx");
        }

        /* ----------------------------------------------------------- */
        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
                Response.Redirect("payment.aspx");
            else
                Response.Redirect("sign_in.aspx?rurl=cart");
        }
    }
}
