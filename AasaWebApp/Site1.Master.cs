using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AasaWebApp
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    LinkButton1.Visible = true; //user login
                    LinkButton2.Visible = true; //Sign Up 

                    // User Access
                    LinkButton3.Visible = false; //logout
                    LinkButton7.Visible = false; // Hello user
                    LinkButton4.Visible = false; //Contribute Button

                    // Admin Access
                    LinkButton6.Visible = true; // Admin login
                                                // LinkButton11.Visible = false; //Author management
                                                // Linkbutton12.Visible = false; //Publisher management
                    LinkButton8.Visible = false; //Book inventory
                                                 // LinkButton9.Visible = false; //Book Issuing
                    LinkButton10.Visible = false; // Member Management
                    LinkButton9.Visible = false; // Cart

                }
                else if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true; //user login
                    LinkButton2.Visible = true; //Sign Up 

                    // User Access
                    LinkButton3.Visible = false; //logout
                    LinkButton7.Visible = false; // Hello user
                    LinkButton4.Visible = false; //Contribute Button

                    // Admin Access
                    LinkButton6.Visible = true; // Admin login
                                                // LinkButton11.Visible = false; //Author management
                                                // Linkbutton12.Visible = false; //Publisher management
                    LinkButton8.Visible = false; //Book inventory
                                                 // LinkButton9.Visible = false; //Book Issuing
                    LinkButton10.Visible = false; // Member Management
                    LinkButton9.Visible = false; // Cart

                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; //user login
                    LinkButton2.Visible = false; //Sign Up 

                    // User Access
                    LinkButton3.Visible = true; //logout
                    LinkButton7.Visible = true; // Hello user
                    LinkButton4.Visible = true; //Contribute Button
                    LinkButton7.Text = "Hello " + Session["user_id"].ToString();
                    LinkButton9.Visible = true; // Cart



                    // Admin Access
                    LinkButton6.Visible = true; // Admin login
                                                // LinkButton11.Visible = false; //Author management
                                                //Linkbutton12.Visible = false; //Publisher management
                    LinkButton8.Visible = false; //Book inventory
                                                 // LinkButton9.Visible = false; //Book Issuing
                    LinkButton10.Visible = false; // Member Management

                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; //user login
                    LinkButton2.Visible = false; //Sign Up 

                    // User Access
                    LinkButton3.Visible = true; //logout
                    LinkButton7.Visible = true; // Hello user
                    LinkButton4.Visible = false; //Contribute Button
                    LinkButton9.Visible = false; // Cart
                    LinkButton7.Text = "Hello Admin";

                    // Admin Access
                    LinkButton6.Visible = false; // Admin login
                                                 // LinkButton11.Visible = true; //Author management
                                                 //Linkbutton12.Visible = true; //Publisher management
                    LinkButton8.Visible = true; //Book inventory
                                                // LinkButton9.Visible = true; //Book Issuing
                    LinkButton10.Visible = true; // Member Management


                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        // User Signup Button
        protected void LinkButton2_click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }
        // Admin login Button
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }
        // Login button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {

        }
        // Feedback Button
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("feedback.aspx");
        }

        //Add Product Button
        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("product.aspx");
        }

        // Contributor
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("contribute.aspx?user_id=" + Session["user_id"].ToString());
        }

        //Logout Button
        protected void LinkButton3_Click1(object sender, EventArgs e)
        {
            Session["user_id"] = "";
            Session["fullname"] = "";
            Session["role"] = "";

            Response.Redirect("userlogin.aspx");
        }

        // Hello User Button
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            
                Response.Redirect("profile.aspx");
            
                
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile/newPage.aspx");
        }

        // Add to Cart
        protected void Cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("add-to-cart.aspx?user_id="+ Session["user_id"].ToString());
        }
    }
}