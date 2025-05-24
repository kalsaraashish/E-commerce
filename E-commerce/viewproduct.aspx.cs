using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class viewproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBrand.Text = "Nike";
            lblProductName.Text = "Air Max 2025";
            lblPrice.Text = "500";
            lblDiscount.Text = "20%";
            lblFinalPrice.Text = "400";
            lblDescription.Text = "High-quality sports shoes with comfort and style.";
            lblMaterialCare.Text = "Mesh, Rubber sole. Clean with damp cloth.";
        }

    }
}