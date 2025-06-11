using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace E_commerce
{
    public partial class payment : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (!IsPostBack)
                {
                    Binduserdata();
                    Bindpricedata();
                }
            }
            else
            {
                Response.Redirect("sign_in.aspx");
            }
        }

        private void Binduserdata()
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM user_data WHERE username=@username", connection);
                command.Parameters.AddWithValue("@username", Session["username"].ToString());

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    username.Text = dt.Rows[0]["username"].ToString().Trim();
                    txtEmail.Text = dt.Rows[0]["email"].ToString().Trim();
                    txtAddress.Text = dt.Rows[0]["address"].ToString().Trim();
                    txtMobile.Text = dt.Rows[0]["p_number"].ToString().Trim();
                }
            }
        }

        private void Bindpricedata()
        {
            if (Request.Cookies["cartpid"] != null)
            {
                DataTable dt = new DataTable();
                string cookiedata = Request.Cookies["cartpid"].Value;
                string[] cookiedataArray = cookiedata.Split(',');

                if (cookiedataArray.Length > 0)
                {
                    Int64 carttotal = 0;
                    Int64 total = 0;

                    for (int i = 0; i < cookiedataArray.Length; i++)
                    {
                        string[] parts = cookiedataArray[i].Split('-');
                        if (parts.Length != 2) continue;

                        string pid = parts[0];
                        string sizeid = parts[1];

                        using (SqlConnection con = new SqlConnection(connStr))
                        {
                            using (SqlCommand view = new SqlCommand(@"
                                SELECT A.*, 
                                       dbo.getsizename(@sizeid) AS sizenamee, 
                                       @sizeid AS sizeidd, 
                                       sizeData.imgname, 
                                       sizeData.extension, 
                                       ISNULL(PQ.quantity, 1) AS qty
                                FROM products A
                                CROSS APPLY (
                                    SELECT TOP 1 B.imgname, B.extension 
                                    FROM productimages B 
                                    WHERE B.pid = A.pid
                                ) sizeData
                                LEFT JOIN pquantity PQ ON PQ.pid = A.pid AND PQ.sid = @sizeid
                                WHERE A.pid = @pid", con))
                            {
                                view.Parameters.AddWithValue("@pid", pid);
                                view.Parameters.AddWithValue("@sizeid", sizeid);

                                using (SqlDataAdapter sda = new SqlDataAdapter(view))
                                {
                                    sda.Fill(dt);
                                }
                            }
                        }

                        if (dt.Rows.Count > i)
                        {
                            int qty = Convert.ToInt32(dt.Rows[i]["qty"]);
                            carttotal += Convert.ToInt64(dt.Rows[i]["price"]) * qty;
                            total += Convert.ToInt64(dt.Rows[i]["pselprice"]) * qty;
                        }
                    }

                    lblCartTotal.Text = carttotal.ToString();
                    lblTotalAmount.Text = "Rs. " + total.ToString();
                    lblDiscount.Text = "- " + (carttotal - total).ToString();

                    hdcartamount.Value = carttotal.ToString();
                    hdtotalpayed.Value = "Rs. " + total.ToString();
                    hdcartdiscount.Value = "- " + (carttotal - total).ToString();
                }
                else
                {
                    Response.Redirect("cart.aspx");
                }
            }
        }

        private int GetUserIdFromDatabase(string username)
        {
            int userId = 0;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id FROM user_data WHERE username = @username", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        userId = Convert.ToInt32(result);
                }
            }
            return userId;
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand insertpurchasedata = new SqlCommand(@"
                    INSERT INTO purchase(userid,pidsizeid,cartamount,cartdiscount,totalpayed,paymenttype,paymentstatus,dateofpurchase,name,email,address,pincod,m_number) 
                    VALUES(@userid,@pidsizeid,@cartamount,@cartdiscount,@totalpayed,@paymenttype,@paymentstatus,@dateofpurchase,@name,@email,@address,@pincod,@m_number)", con))
                {
                    string paymentType;
                    string paymentStatus;

                    if (rdoWallet.Checked)
                    {
                        paymentType = "Wallet";
                        paymentStatus = "Paid";
                    }
                    else if (rdoCard.Checked)
                    {
                        paymentType = "Credit/Debit Card";
                        paymentStatus = "Paid";
                    }
                    else
                    {
                        paymentType = "Cash on Delivery";
                        paymentStatus = "Pending";
                    }

                    string username = Session["username"].ToString();
                    int userId = GetUserIdFromDatabase(username);

                    insertpurchasedata.Parameters.AddWithValue("@userid", userId);
                    insertpurchasedata.Parameters.AddWithValue("@pidsizeid", Request.Cookies["cartpid"].Value);
                    insertpurchasedata.Parameters.AddWithValue("@cartamount", hdcartamount.Value);

                    decimal cartDiscount = decimal.Parse(hdcartdiscount.Value.Replace(" ", "").Trim(), System.Globalization.NumberStyles.AllowLeadingSign);
                    decimal totalPayed = decimal.Parse(hdtotalpayed.Value.Replace("Rs.", "").Trim(), System.Globalization.NumberStyles.Currency);

                    insertpurchasedata.Parameters.AddWithValue("@cartdiscount", cartDiscount);
                    insertpurchasedata.Parameters.AddWithValue("@totalpayed", totalPayed);
                    insertpurchasedata.Parameters.AddWithValue("@paymenttype", paymentType);
                    insertpurchasedata.Parameters.AddWithValue("@paymentstatus", paymentStatus);
                    insertpurchasedata.Parameters.AddWithValue("@dateofpurchase", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    insertpurchasedata.Parameters.AddWithValue("@name", username);
                    insertpurchasedata.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    insertpurchasedata.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    insertpurchasedata.Parameters.AddWithValue("@pincod", txtPincode.Text.Trim());
                    insertpurchasedata.Parameters.AddWithValue("@m_number", txtMobile.Text.Trim());

                    con.Open();
                    int result = insertpurchasedata.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Response.Cookies["cartpid"].Expires = DateTime.Now.AddDays(-1);
                        Response.Redirect("orderplaced.aspx");
                    }
                }
            }
        }
    }
}
