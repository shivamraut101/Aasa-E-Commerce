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

        
    </div>
    
</asp:Content>
