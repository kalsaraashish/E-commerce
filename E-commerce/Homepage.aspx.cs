using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Bindcartnumber();

        }

        //public void Bindcartnumber()
        //{
        //    if (Request.Cookies["cartpid"] != null)
        //    {
        //        //string cookiepid = Request.Cookies["cartpid"].Value.Split('=')[1];
        //        //string[] productArray = cookiepid.Split(',');
        //        //int productcount= productArray.Length;
        //        //pcount.InnerText = productcount.ToString();

        //        string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
        //        string[] ProductArray = CookiePID.Split(',');
        //        int ProductCount = ProductArray.Length;
        //        pcount.InnerText = ProductCount.ToString();
        //    }
        //    else
        //    {
        //        pcount.InnerText = 0.ToString();
        //    }
        //}
    }
}