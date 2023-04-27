<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="AasaWebApp.checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        
            
        <asp:Label ID="full_name" runat="server" Text="Label"></asp:Label>,
        <br />
        <asp:Label ID="full_address" runat="server" Text="Label"></asp:Label>,
        <br />
        <asp:Label ID="city" runat="server" Text="Label"></asp:Label>,<asp:Label ID="state" runat="server" Text="Label"></asp:Label>,
        <br />
        <span>Pincode: </span><asp:Label ID="pincode" runat="server" Text="Label"></asp:Label>,
        <br />
        <span>Phone Number: </span><asp:Label ID="contact_no" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Edit Address" OnClick="Button1_Click" />

        <hr />
        <span>Details Of Payee</span>
        <br />
        <span>Name: </span><asp:Label ID="name_of_payee" runat="server" Text="Label"></asp:Label>
        <br />
        <span>Email ID: </span><asp:Label ID="Email" runat="server" Text="Label"></asp:Label>
        <br />
        <span>Contact Number: </span><asp:Label ID="Contact" runat="server" Text="Label"></asp:Label>
        <br />
        <span>Total Amount: </span><asp:Label ID="Amount" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="order_id" runat="server" Text="Label" Visible="True"></asp:Label>
        <br />
        <div class="row">
            <div class="col-6">
                 <asp:Button ID="Button2" runat="server" Text="Edit Details" OnClick="Button1_Click" />
            </div>
           
            <div class="col-6">
                <asp:Button ID="Button3" runat="server" Text="Pay Now" OnClick="Button3_Click" />
            </div>
        </div>
        
            
        <hr />
        
        
    </div>
    
</asp:Content>
