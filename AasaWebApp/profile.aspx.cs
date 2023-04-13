using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AasaWebApp
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string SessionID = Session["user_id"]?.ToString();
                if (SessionID != null)
                {
                    // Code For - If User is Successfully Loged In Then 
                    
                }
                else
                {
                    Response.Redirect("homepage.aspx");

                }
            }
        }
        //Update Button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx");
        }
        //Your Orders
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("youOrders.aspx");
        }
        //Payment Option
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("payment_details.aspx");
        }
        //Contact Us
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactUs.aspx");
        }
    }
}