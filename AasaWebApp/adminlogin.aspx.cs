using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AasaWebApp
{
    public partial class adminlogin : System.Web.UI.Page
    {
        string stcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    string SessionID = Session["admin"]?.ToString();
            //    if (SessionID != null)
            //    {
            //        // Code For - If User is Successfully Loged In Then 
                    
            //    }
            //    else
            //    {
            //        Response.Redirect("homepage.aspx");

            //    }
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(stcon);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM admin_tbl WHERE username='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'  ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Successful login')</script>");
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["fullname"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid creditials')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>('"+ex.Message+"')</script>");
            }
        }
    }
}