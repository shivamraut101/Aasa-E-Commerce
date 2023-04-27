using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


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
                    subTotal();
                    orderId();
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
                    name_of_payee.Text = dt.Rows[0][1].ToString();
                    Email.Text = dt.Rows[0][4].ToString();
                    Contact.Text = dt.Rows[0][3].ToString();
                }

                // close the connection and release resources
                
                con.Close();
            }
        }

        // Total Amount
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

                Amount.Text = reader["SubTotalPrice"].ToString();
            }

            // close the connection and release resources
            reader.Close();
            con.Close();
           

        }

        // Order ID
        void orderId()
        {
            if (!IsPostBack)
            {
                // create a SqlConnection object

                SqlConnection con = new SqlConnection(strcon);

                // create a SqlCommand object with the SQL query
                SqlCommand cmd = new SqlCommand("SELECT * FROM userpayment_tbl", con);
                
                // open the connection and execute the query
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int lastRowIndex = dt.Rows.Count - 1;
                if (dt.Rows.Count >= 1)
                {
                    // get the value of the "Required" column and bind it to the Label control
                    int orderId = Convert.ToInt32(dt.Rows[lastRowIndex]["order_id"]) + 1; // Add +1 to the retrieved order_id
                    order_id.Text = orderId.ToString();

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

        private string CreateToken(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        

        // Pay Now Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            string secret = "TEST26f0c57318c18e8939cec1fd51c8748fab2a98b3";
            string data = "";
            string Merchantkey = "TEST3691604db12c47bbd6c11dcd3e061963";

            SortedDictionary<string, string> formsParams = new SortedDictionary<string, string>();
            formsParams.Add("appId", Merchantkey);
            formsParams.Add("orderId", order_id.Text);
            formsParams.Add("orderAmount", Amount.Text);
            formsParams.Add("customerName", name_of_payee.Text);
            formsParams.Add("customerPhone", Contact.Text);
            formsParams.Add("customerEmail", Email.Text);
            formsParams.Add("returnUrl", "https://localhost:44370/callBack.aspx");

            foreach (var kvp in formsParams)
            {
                data = data + kvp.Key + kvp.Value;
            }

            string signature = CreateToken(data, secret);
           // Console.Write(signature);

            string outputHTML = "<html>";
            outputHTML += "<head>";
            outputHTML += "<title>Merchant Check Out Page</title>";
            outputHTML += "</head>";
            outputHTML += "<body>";
            outputHTML += "<center><h1>Please do not refresh this page</h1></center>";
            outputHTML += "<form id = 'redirectForm' method='post' action=' https://sandbox.cashfree.com/pg' >";
            //outputHTML += "<script type='text/javascript' src='https://sdk.cashfree.com/js/ui/2.0.0/cashfree.sandbox.js'></script>";
            outputHTML += "<input type = 'hidden' name='appId' value= '" + Merchantkey + "'/>";

            outputHTML += "<input type = 'hidden' name='orderId' value='" + order_id.Text + "'/>";

            outputHTML += "< input type = 'hidden' name = 'orderAmount' value = '" + Amount.Text + "' />";
            outputHTML += "< input type = 'hidden' name = 'orderCurrency' value = 'INR' />";

            outputHTML += "< input type = 'hidden' name = 'customerName' value = '" + name_of_payee.Text + "' />";
            outputHTML += "< input type = 'hidden' name = 'customerEmail' value = '"+ Email.Text + "' />";
            outputHTML += "< input type = 'hidden' name = 'customerPhone' value = '" + Contact.Text + "' />";
            //< input type = "hidden" name = "merchantData" value = "<GENERATED_BASE64_MERCHANTDATA>" />;
            outputHTML += "< input type = 'hidden' name = 'returnUrl' value = ' https://localhost:44370/callBack.aspx '/>";
            //< input type = "hidden" name = "notifyUrl" value = "<NOTIFY_URL>" />
            outputHTML += "< input type = 'hidden' name = 'signature' value = '" + signature + "' />";
            outputHTML += "<table border = '1'>";
            outputHTML += "<tbody>";

            foreach (string keys in formsParams.Keys)
            {
                outputHTML += "<input type ='hidden' name='"+ keys +"' value='"+ formsParams[keys] +"'>";
            }
            outputHTML += "</tbody>";
            outputHTML += "</table>";

            outputHTML += "<script type='text/javascript'>";
            outputHTML += "document.getElementById('redirectForm').submit();";
            
            outputHTML += "</script>";
            outputHTML += "</form>";
            outputHTML += "</body>";
            outputHTML += "</html>";
            Response.Write(outputHTML);



        }





    }
}