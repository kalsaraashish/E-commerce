﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class viewproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["pid"] != null)
            {
                if (!IsPostBack)
                {
                    Bindproductimg();
                    Bindproductdetail();
                }
            }
            else
            {
                Response.Redirect("viewallproduct.aspx");
            }
        }

        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

        private void Bindproductimg()
        {
            int pid = Convert.ToInt32(Request.QueryString["pid"]);
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from productimages where pid='" + pid + "'", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rpimg.DataSource = dt;
                        rpimg.DataBind();
                    }
                }
            }
        }

        private void Bindproductdetail()
        {
            int pid = Convert.ToInt32(Request.QueryString["pid"]);
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand view = new SqlCommand("select * from products where pid='" + pid + "'", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(view))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rpdetail.DataSource = dt;
                        rpdetail.DataBind();
                    }
                }
            }
        }

        protected void rpdetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string brandid = (e.Item.FindControl("hbrid") as HiddenField).Value;
                string catid = (e.Item.FindControl("hcatid") as HiddenField).Value;
                string subcatid = (e.Item.FindControl("hsubcatid") as HiddenField).Value;
                string genid = (e.Item.FindControl("hgenid") as HiddenField).Value;

                RadioButtonList rblSize = e.Item.FindControl("rblSize") as RadioButtonList;

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlCommand view = new SqlCommand("select * from sizees where brid='" + brandid + "' and catid='" + catid + "' and subcatid='" + subcatid + "' and genid='" + genid + "'", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(view))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            rblSize.DataSource = dt;
                            rblSize.DataTextField = "sizename";
                            rblSize.DataValueField = "sid";
                            rblSize.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            string selectedsize = string.Empty;

            // Loop to get the selected size and clear previous error messages
            foreach (RepeaterItem item in rpdetail.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var rblist = item.FindControl("rblSize") as RadioButtonList;
                    selectedsize = rblist.SelectedValue;
                    var errormessage = item.FindControl("errormessage") as Label;
                    errormessage.Text = "";
                }
            }

            if (selectedsize != "")
            {
                Int32 pid = Convert.ToInt32(Request.QueryString["pid"]);

                // Check if cartpid cookie already exists
                if (Request.Cookies["cartpid"] != null)
                {
                    string cookiepid = Request.Cookies["cartpid"].Value;
                    cookiepid = cookiepid + "," + pid + "-" + selectedsize;

                    HttpCookie cartproducts = new HttpCookie("cartpid");
                    cartproducts.Value = cookiepid;
                    cartproducts.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cartproducts);
                }
                else
                {
                    HttpCookie cartproducts = new HttpCookie("cartpid");
                    cartproducts.Value = pid + "-" + selectedsize;
                    cartproducts.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cartproducts);
                }

                Response.Redirect("viewproduct.aspx?pid=" + pid);
            }
            else
            {
                foreach (RepeaterItem item in rpdetail.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var errormessage = item.FindControl("errormessage") as Label;
                        errormessage.Text = "Please select size";
                    }
                }
            }
        }
    }
}
