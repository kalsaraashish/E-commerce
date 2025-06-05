using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace E_commerce
{
    public partial class payment : System.Web.UI.Page
    {
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
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";
        private void Binduserdata()
        {
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            SqlCommand command = new SqlCommand("select * from user_data where username=@username", connection);
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
        private void Bindpricedata()
        {
            if (Request.Cookies["cartpid"] != null)
            {
                DataTable dt = new DataTable();
                string cookiedata = Request.Cookies["cartpid"].Value;
                string[] cookiedataArray = cookiedata.Split(',');

                if (cookiedataArray.Length > 0)
                {
                    //h3noitems.InnerText = "My Cart (" + cookiedataArray.Length + " Items)";
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


                    lblCartTotal.Text = carttotal.ToString();
                    lblTotalAmount.Text = "Rs. " + total.ToString();
                    lblDiscount .Text= "- " + (carttotal - total).ToString();

                    hdcartamount.Value = carttotal.ToString();
                    hdtotalpayed.Value = "Rs. " + total.ToString();
                    hdcartdiscount.Value = "- " + (carttotal - total).ToString();


                }
                else
                {
                  
                    Response.Redirect("cart.aspx"); // Redirect to cart if no items
                }
            }
            else
            {
                //h3noitems.InnerText = "Your shopping Cart is Empty";
                //rpcart.Visible = false;
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
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
            }
            return userId;
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand insertpurchasedata = new SqlCommand("INSERT INTO purchase(userid,pidsizeid,cartamount,cartdiscount,totalpayed,paymenttype,paymentstatus,dateofpurchase,name,email,address,pincod,m_number) values(@userid,@pidsizeid,@cartamount,@cartdiscount,@totalpayed,@paymenttype,@paymentstatus,@dateofpurchase,@name,@email,@address,@pincod,@m_number)", con))
                {
                    string paymentType;
                    string paymentStatus;   // so you can mark “Paid” for prepaid options

                    if (rdoWallet.Checked)
                    {
                        paymentType = "Wallet";
                        paymentStatus = "Paid";        // you typically grab money from wallet instantly
                    }
                    else if (rdoCard.Checked)
                    {
                        paymentType = "Credit/Debit Card";
                        paymentStatus = "Paid";        // card gateway confirms right away
                    }
                    else                       // the only remaining possibility is COD
                    {
                        paymentType = "Cash on Delivery";
                        paymentStatus = "Pending";
                    }

                    insertpurchasedata.Parameters.AddWithValue("@paymenttype", paymentType);
                    insertpurchasedata.Parameters.AddWithValue("@paymentstatus", paymentStatus);
                    string username = Session["username"].ToString();
                    int userId = GetUserIdFromDatabase(username); // Implement this method to fetch the user ID
                    insertpurchasedata.Parameters.AddWithValue("@userid", userId);
                    //insertpurchasedata.Parameters.AddWithValue("@userid", Session["username"].ToString());
                    decimal cartDiscount = decimal.Parse(hdcartdiscount.Value.Replace(" ", "").Trim(), System.Globalization.NumberStyles.AllowLeadingSign);
                    decimal totalPayed = decimal.Parse(hdtotalpayed.Value.Replace("Rs.", "").Trim(), System.Globalization.NumberStyles.Currency);
                    insertpurchasedata.Parameters.AddWithValue("@pidsizeid", Request.Cookies["cartpid"].Value);
                    insertpurchasedata.Parameters.AddWithValue("@cartamount", hdcartamount.Value);
                    insertpurchasedata.Parameters.AddWithValue("@cartdiscount", cartDiscount);
                    insertpurchasedata.Parameters.AddWithValue("@totalpayed", totalPayed);
                   
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
                        Response.Cookies["cartpid"].Expires = DateTime.Now.AddDays(-1); // Clear cart cookie
                        Response.Redirect("orderplaced.aspx"); // Redirect to order placed page
                    }

                }
            }
        }
    }
}