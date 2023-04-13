using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace AasaWebApp
{
    public partial class product : System.Web.UI.Page
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
                    GridView1.DataBind();
                }
                else
                {
                    Response.Redirect("homepage.aspx");

                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkProductExists())
            {
                Response.Write("<script>alert('This Product Id Exits');</script>");
            }
            else
            {
                addProduct();
            }

        }
        //Update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkProductExists())
            {
                updateButton();
            }
            else
            {
                Response.Write("<script>alert('This Product Id Do not Exits');</script>");
            }
        }
        //DELETE button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkProductExists())
            {
                deleteButton();
            }
            else
            {
                Response.Write("<script>alert('This Product Id Do not Exits');</script>");
            }
        }

        //User Defined Function
        bool checkProductExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM product_tbl WHERE ID='" + TextBox7.Text.Trim() + "';", con);
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
                return false;
            }

        }
        void addProduct()
        {
            try
            {
                
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                String query = "INSERT INTO product_tbl(Name,Detail,Cost_Price,MRP,Current_Stock,Image1,Image2,Image3,Category,Contributor) values('" + TextBox2.Text.Trim() + "','" + TextBox6.Text.Trim() + "','" + TextBox10.Text.Trim() + "','" + TextBox1.Text.Trim() + "','" + TextBox4.Text.Trim() + "',@Image1,@Image2,@Image3,'" + ListBox1.Text.Trim() + "','" + TextBox3.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(query, conn);

                string filepath1 = "~/Images/backpack.png";
                if (FileUpload1.HasFile)
                {
                    string filename1 = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/Product_Image/" + filename1));
                    filepath1 = "~/Product_Image/" + filename1;
                    cmd.Parameters.AddWithValue("@Image1", filepath1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Image1", filepath1);
                }
                if (FileUpload2.HasFile) 
                {
                    string filename2 = Path.GetFileName(FileUpload2.PostedFile.FileName);
                    FileUpload2.SaveAs(Server.MapPath("~/Product_Image/" + filename2));
                    string filepath2 = "~/Product_Image/" + filename2;
                    cmd.Parameters.AddWithValue("@Image2", filepath2);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Image2", "Null");
                }
                if (FileUpload3.HasFile)
                {
                    string filename3 = Path.GetFileName(FileUpload3.PostedFile.FileName);
                    FileUpload3.SaveAs(Server.MapPath("~/Product_Image/" + filename3));
                    string filepath3 = "~/Product_Image/" + filename3;
                    cmd.Parameters.AddWithValue("@Image3", filepath3);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Image3", "Null");
                }
                
                
                
                cmd.ExecuteNonQuery();
                conn.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Your Product is Successfully Added');</script>");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            SqlConnection con = new SqlConnection(strcon);
            con.Close();

        }
        //Go Button
        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM product_tbl WHERE ID='" + TextBox7.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox6.Text = dt.Rows[0][2].ToString();
                    TextBox10.Text = dt.Rows[0][3].ToString();
                    TextBox1.Text = dt.Rows[0][4].ToString();
                    TextBox5.Text = dt.Rows[0][5].ToString();
                    TextBox3.Text = dt.Rows[0][10].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        //Update Button
        void updateButton()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                //ID,Name,Detail,Cost_Price,MRP,Current_Stock,Image1,Image2,Image3,Category,Contributor
                string query = "UPDATE product_tbl SET Name='" + TextBox2.Text.Trim() + "',Detail='" + TextBox6.Text.Trim() + "',Cost_price='" + TextBox10.Text.Trim() +"',MRP='" + TextBox1.Text.Trim() + "',Current_Stock='" + TextBox4.Text.Trim() + "', Category='" + ListBox1.Text.Trim() + "', Contributor='" + TextBox3.Text.Trim() +"' WHERE ID='"+TextBox7.Text.Trim()+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Update Successful')</script>");

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        
        //Delete Button
        void deleteButton()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "delete from product_tbl where ID='"+TextBox7.Text.Trim()+"'";
                SqlCommand cmd =new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Deleted Successful')</script>");

            }
            catch (Exception ex) 
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
   