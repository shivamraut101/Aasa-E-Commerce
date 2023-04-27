using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace AasaWebApp.Profile
{
    public partial class UpdateProfile : System.Web.UI.Page
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
                    userId();
                }
                else
                {
                    Response.Redirect("homepage.aspx");

                }
            }
            
        }

        // Update Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            updateButton();
        }

        // USER DEFINED FUNCTION

        //Fill Data On Load Function
        void fillData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM signup_tbl WHERE user_id=@sessionUser", con);
                cmd.Parameters.AddWithValue("@sessionUser", Session["user_id"]);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {

                    TextBox3.Text = dt.Rows[0][1].ToString();
                    TextBox4.Text = dt.Rows[0][2].ToString();
                    TextBox5.Text = dt.Rows[0][3].ToString();
                    TextBox6.Text = dt.Rows[0][4].ToString();
                    DropDownList2.Text = dt.Rows[0][5].ToString();
                    TextBox8.Text = dt.Rows[0][6].ToString();
                    TextBox9.Text = dt.Rows[0][7].ToString();
                    TextBox10.Text = dt.Rows[0][8].ToString();
                    TextBox1.Text = dt.Rows[0][0].ToString();
                    TextBox2.Text = dt.Rows[0][9].ToString();


                }

    

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        // Update Button
        void updateButton()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                string query = "UPDATE signup_tbl SET full_name=@full_name, dob=@dob, contact_no=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_address=@full_address, password=@password WHERE user_id=@sessionUser";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@full_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList2.Text.Trim());
                cmd.Parameters.AddWithValue("@city", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@sessionUser", Session["user_id"]);
                int rowsAffected = cmd.ExecuteNonQuery();

                con.Close();

                if (rowsAffected > 0)
                {
                    Response.Write("<script>alert('Update Successful. " + rowsAffected + " rows affected.')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Update Failed')</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            fillData();
        }

        void userId()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM signup_tbl WHERE user_id=@sessionUser", con);
                cmd.Parameters.AddWithValue("@sessionUser", Session["user_id"]);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {

                    TextBox1.Text = dt.Rows[0][0].ToString();


                }



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
    }
}
