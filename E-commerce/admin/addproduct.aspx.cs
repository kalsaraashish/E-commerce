using Microsoft.SqlServer.Server;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.admin
{
    public partial class addproduct : Page
    {
        private readonly string connStr =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopZone.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindbrand();
                Bindcategory();
                Bindgender();

                subcategory.Enabled = false;
                gen.Enabled = false;
            }
        }

        private void Bindbrand()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM brand", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                brand.DataSource = rdr;
                brand.DataTextField = "name";
                brand.DataValueField = "brid";
                brand.DataBind();
                brand.Items.Insert(0, new ListItem("--Select Brand--", "0"));
                con.Close();
            }
        }

        private void Bindcategory()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM category", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                category.DataSource = rdr;
                category.DataTextField = "catname";
                category.DataValueField = "catid";
                category.DataBind();
                category.Items.Insert(0, new ListItem("--Select Category--", "0"));
                con.Close();
            }
        }

        private void Bindgender()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM gender", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                gen.DataSource = rdr;
                gen.DataTextField = "genname";
                gen.DataValueField = "genid";
                gen.DataBind();
                gen.Items.Insert(0, new ListItem("--Select Gender--", "0"));
                con.Close();
            }
        }

        protected void category_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM subcategory WHERE maincatid=@catid", con);
                cmd.Parameters.AddWithValue("@catid", category.SelectedValue);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                subcategory.DataSource = rdr;
                subcategory.DataTextField = "subcatname";
                subcategory.DataValueField = "subcatid";
                subcategory.DataBind();
                subcategory.Items.Insert(0, new ListItem("--Select Subcategory--", "0"));
                subcategory.Enabled = true;
                con.Close();
            }
        }

        protected void subcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            gen.Enabled = true;
        }

        protected void gen_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvSizes.DataSource = null;
            gvSizes.DataBind();

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                var cmd = new SqlCommand(
                    @"SELECT sid, sizename FROM sizees 
                      WHERE brid=@b AND catid=@c AND subcatid=@s AND genid=@g", con);
                cmd.Parameters.AddWithValue("@b", brand.SelectedValue);
                cmd.Parameters.AddWithValue("@c", category.SelectedValue);
                cmd.Parameters.AddWithValue("@s", subcategory.SelectedValue);
                cmd.Parameters.AddWithValue("@g", gen.SelectedValue);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                gvSizes.DataSource = dt;
                gvSizes.DataKeyNames = new string[] { "sid" };
                gvSizes.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long newPid;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlCommand sp = new SqlCommand("sp_Insertproduct", con);
                sp.CommandType = CommandType.StoredProcedure;
                sp.Parameters.AddWithValue("@pname", pname.Text);
                sp.Parameters.AddWithValue("@price", price.Text);
                sp.Parameters.AddWithValue("@pselprice", sprice.Text);
                sp.Parameters.AddWithValue("@pbrandid", brand.SelectedValue);
                sp.Parameters.AddWithValue("@pcatid", category.SelectedValue);
                sp.Parameters.AddWithValue("@psubcatid", subcategory.SelectedValue);
                sp.Parameters.AddWithValue("@pgenid", gen.SelectedValue);
                sp.Parameters.AddWithValue("@pdiscription", description.Text);
                sp.Parameters.AddWithValue("@productdetails", productdetails.Text);
                sp.Parameters.AddWithValue("@matcare", materialcare.Text);
                sp.Parameters.AddWithValue("@freedelivery", chkFreeDelivery.Checked ? 1 : 0);
                sp.Parameters.AddWithValue("@chk30DayReturn", chk30DayReturn.Checked ? 1 : 0);
                sp.Parameters.AddWithValue("@chkCOD", chkCOD.Checked ? 1 : 0);

                newPid = Convert.ToInt64(sp.ExecuteScalar());

                foreach (GridViewRow row in gvSizes.Rows)
                {
                    var chk = (CheckBox)row.FindControl("chkSel");
                    if (chk.Checked)
                    {
                        int sid = Convert.ToInt32(gvSizes.DataKeys[row.RowIndex].Value);
                        int qty = Convert.ToInt32(((TextBox)row.FindControl("txtQty")).Text);

                        SqlCommand qCmd = new SqlCommand(
                            @"INSERT INTO pquantity (pid, sid, quantity)
                              VALUES (@pid, @sid, @qty)", con);
                        qCmd.Parameters.AddWithValue("@pid", newPid);
                        qCmd.Parameters.AddWithValue("@sid", sid);
                        qCmd.Parameters.AddWithValue("@qty", qty);
                        qCmd.ExecuteNonQuery();
                    }
                }

                SaveProductImage(fuImage1, newPid, "01", con);
                SaveProductImage(fuImage2, newPid, "02", con);
                SaveProductImage(fuImage3, newPid, "03", con);
                SaveProductImage(fuImage4, newPid, "04", con);

                con.Close();
            }

            ClientScript.RegisterStartupScript(GetType(), "ok",
                "alert('Product added successfully');", true);
            ClearForm();
        }

        private void SaveProductImage(FileUpload fu, long pid, string suffix, SqlConnection con)
        {
            if (!fu.HasFile) return;

            string ext = Path.GetExtension(fu.FileName).ToLower();
            string dir = Server.MapPath("~/img/productimg/" + pid);
            Directory.CreateDirectory(dir);
            string fname = pname.Text.Trim() + suffix + ext;
            fu.SaveAs(Path.Combine(dir, fname));

            var cmd = new SqlCommand(
                "INSERT INTO productimages(pid, imgname, extension) VALUES(@p,@n,@e)", con);
            cmd.Parameters.AddWithValue("@p", pid);
            cmd.Parameters.AddWithValue("@n", pname.Text.Trim() + suffix);
            cmd.Parameters.AddWithValue("@e", ext);
            cmd.ExecuteNonQuery();
        }

        private void ClearForm()
        {
            foreach (var ctl in form1.Controls.OfType<TextBox>())
                ctl.Text = string.Empty;

            chkFreeDelivery.Checked = chk30DayReturn.Checked = chkCOD.Checked = false;
            brand.SelectedIndex = category.SelectedIndex = subcategory.SelectedIndex =
                gen.SelectedIndex = 0;
            gvSizes.DataSource = null;
            gvSizes.DataBind();
        }
    }
}
