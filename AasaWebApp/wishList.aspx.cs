using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AasaWebApp
{
    public partial class wishList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string SessionID = (Request.QueryString["user_id"]);
                if (SessionID != null)
                {
                    DataList1.DataBind();
                    //Response.Write("<script>alert('" + productId + "');</script>");
                }
                else
                {
                    Response.Redirect("homepage.aspx");
                    //Response.Write("<script>alert('" + productId + "');</script>");
                }
            }
        }
        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}