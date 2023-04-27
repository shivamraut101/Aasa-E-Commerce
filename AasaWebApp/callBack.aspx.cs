using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AasaWebApp
{
    public partial class callBack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string,string> parameters = new Dictionary<string,string>();

            foreach (string key in parameters.Keys)
            {
                parameters.Add(key.Trim(), Request.Form[key].Trim());
            }

            string paymentStatus = parameters["txtStatus"];
            string paymode = parameters["paymentMode"];
            string txnId = parameters["orderId"];
            pTxnId.InnerText = "Transaction Id: " + txnId;
            h1Message.InnerText = "Your Payment is " + paymentStatus;
            pMode.InnerText = "Payment Mode: "+ paymode;
        }
    }
}