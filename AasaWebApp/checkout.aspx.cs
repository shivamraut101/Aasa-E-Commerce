using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AasaWebApp
{
    public partial class checkout : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string SessionID = Session["user_id"]?.ToString();
                if (SessionID != null)
                {
                    // Code For - If User is Successfully Loged In Then 
                    address();
                }
                else
                {
                    Response.Redirect("homepage.aspx");
                    
                }
            }
        }

        // User Defined Function
        void address()
        {
            if (!IsPostBack)
            {
                // create a SqlConnection object

                SqlConnection con = new SqlConnection(strcon);

                // create a SqlCommand object with the SQL query
                SqlCommand cmd = new SqlCommand("SELECT * FROM signup_tbl WHERE user_id=@SessionID", con);
                cmd.Parameters.AddWithValue("@SessionID", Session["user_id"].ToString());

                // open the connection and execute the query
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    // get the value of the "Required" column and bind it to the Label control

                    full_name.Text = dt.Rows[0][1].ToString();
                    contact_no.Text = dt.Rows[0][3].ToString();
                    state.Text = dt.Rows[0][5].ToString();
                    city.Text = dt.Rows[0][6].ToString();
                    pincode.Text = dt.Rows[0][7].ToString();
                    full_address.Text = dt.Rows[0][8].ToString();
                }

                // close the connection and release resources
                
                con.Close();
            }
        }

        //Edit Address Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx?user_id=" + Session["user_id"].ToString());
        }
    }
}