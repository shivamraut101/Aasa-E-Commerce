using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AasaWebApp
{
    public partial class payment : System.Web.UI.Page
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
    }
}