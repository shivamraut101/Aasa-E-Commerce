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
    public partial class add_to_cart : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string SessionID = (Request.QueryString["user_id"]);
                if (SessionID != null)
                {
                    DataList1.DataBind();
                    subTotal();
                    
                }
                else
                {
                    Response.Redirect("homepage.aspx");
                }
            }
            
        }

        

        // Proceed To Buy
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("checkout.aspx?user_id=" + Session["user_id"].ToString());
        }

        

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int productId = Convert.ToInt32(e.CommandArgument);

                if (Session["user_id"] == null)
                {
                    // User is not logged in, redirect to login page
                    Response.Redirect("~/userlogin.aspx");
                }
                else
                {
                    string SessionID = Session["user_id"].ToString();
                    if (checkProductExists())
                    {
                        try
                        {
                            SqlConnection conn = new SqlConnection(strcon);
                            conn.Open();
                            String query = "DELETE usercart_tbl WHERE ID=@ID AND user_id=@user_id";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@user_id", Session["user_id"].ToString());
                            cmd.Parameters.AddWithValue("@ID", productId);
                            

                            cmd.ExecuteNonQuery();
                            conn.Close();
                            Response.Write("<script>alert('Your Product is Successfully Removed To Cart');</script>");
                            DataList1.DataBind();
                            subTotal();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                            Response.Write("< script > alert('First You Have To Login');</ script >");
                        }
                        
                    }
                    else
                    {
                        Response.Write("<script>alert('You have already Added this Product');</script>");
                        Response.Redirect("add-to-cart.aspx?user_id=" + SessionID);
                    }


                }
                bool checkProductExists()
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(strcon);
                        if (con.State == System.Data.ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlCommand cmd = new SqlCommand("SELECT * FROM usercart_tbl WHERE ID = @productId AND user_id=@SessionID;", con);
                        cmd.Parameters.AddWithValue("@productId", productId);
                        cmd.Parameters.AddWithValue("@SessionID", Session["user_id"].ToString());
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count >= 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                        return true;
                    }

                }




            }
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //User Defined 

         void subTotal()
        {
            
                // create a SqlConnection object

                SqlConnection con = new SqlConnection(strcon);

                // create a SqlCommand object with the SQL query
                SqlCommand cmd = new SqlCommand("SELECT SUM(CAST(MRP AS decimal(10,2))) AS SubTotalPrice FROM usercart_tbl WHERE user_id=@SessionID", con);
                cmd.Parameters.AddWithValue("@SessionID", Session["user_id"].ToString());

                // open the connection and execute the query
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // get the value of the "TotalPrice" column and bind it to the Label control

                    lblSubTotalPrice.Text = reader["SubTotalPrice"].ToString();
                }

                // close the connection and release resources
                reader.Close();
                con.Close();
                DataList1.DataBind();
            
        }
    }
}