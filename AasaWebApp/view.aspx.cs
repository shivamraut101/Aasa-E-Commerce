﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace AasaWebApp
{
    public partial class view : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int productId = Convert.ToInt32(Request.QueryString["ID"]);
                if (productId > 0)
                {
                    FormView1.DataBind();

                }
                else
                {
                    Response.Redirect("homepage.aspx");

                }
            }


        }

        
        protected void FormView1_ItemCommand(object source, FormViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
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
                        Response.Write("<script>alert('You have already Added this Product');</script>");
                        Response.Redirect("add-to-cart.aspx?user_id=" + SessionID);
                    }
                    else
                    {
                        try
                        {
                            SqlConnection conn = new SqlConnection(strcon);
                            conn.Open();
                            String query = "INSERT INTO usercart_tbl(user_id, ID, Name, Detail, MRP, Category, Contributor, Date,Image1,Image2,Image3) SELECT @user_id, ID, Name, Detail, MRP, Category, Contributor, @date_added,Image1,Image2,Image3 FROM product_tbl WHERE ID=@ID";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@user_id", Session["user_id"].ToString());
                            cmd.Parameters.AddWithValue("@ID", productId);
                            cmd.Parameters.AddWithValue("@date_added", DateTime.Now);

                            cmd.ExecuteNonQuery();
                            conn.Close();
                            Response.Write("<script>alert('Your Product is Successfully Added To Cart');</script>");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                            Response.Write("< script > alert('First You Have To Login');</ script >");
                        }
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
    }
}