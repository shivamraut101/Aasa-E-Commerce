<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="AasaWebApp.view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="homepage.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=SHIVAM-ASUS\SQLEXPRESS;Initial Catalog=aasa;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [ID],[Name], [Detail], [Image1], [Image2], [Image3], [MRP], [Category], [Contributor] FROM [product_tbl] WHERE ID=@ID">
    <SelectParameters>
        <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
        
    <asp:FormView ID="FormView1" runat="server" OnItemCommand="FormView1_ItemCommand" DataSourceID="SqlDataSource1">
        <EditItemTemplate>
            Name:
            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
            <br />
            Detail:
            <asp:TextBox ID="DetailTextBox" runat="server" Text='<%# Bind("Detail") %>' />
            <br />
            Image1:
            <asp:TextBox ID="Image1TextBox" runat="server" Text='<%# Bind("Image1") %>' />
            <br />
            Image2:
            <asp:TextBox ID="Image2TextBox" runat="server" Text='<%# Bind("Image2") %>' />
            <br />
            Image3:
            <asp:TextBox ID="Image3TextBox" runat="server" Text='<%# Bind("Image3") %>' />
            <br />
            MRP:
            <asp:TextBox ID="MRPTextBox" runat="server" Text='<%# Bind("MRP") %>' />
            <br />
            Category:
            <asp:TextBox ID="CategoryTextBox" runat="server" Text='<%# Bind("Category") %>' />
            <br />
            Contributor:
            <asp:TextBox ID="ContributorTextBox" runat="server" Text='<%# Bind("Contributor") %>' />
            <br />
          
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            Name:
            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
            <br />
            Detail:
            <asp:TextBox ID="DetailTextBox" runat="server" Text='<%# Bind("Detail") %>' />
            <br />
            Image1:
            <asp:TextBox ID="Image1TextBox" runat="server" Text='<%# Bind("Image1") %>' />
            <br />
            Image2:
            <asp:TextBox ID="Image2TextBox" runat="server" Text='<%# Bind("Image2") %>' />
            <br />
            Image3:
            <asp:TextBox ID="Image3TextBox" runat="server" Text='<%# Bind("Image3") %>' />
            <br />
            MRP:
            <asp:TextBox ID="MRPTextBox" runat="server" Text='<%# Bind("MRP") %>' />
            <br />
            Category:
            <asp:TextBox ID="CategoryTextBox" runat="server" Text='<%# Bind("Category") %>' />
            <br />
            Contributor:
            <asp:TextBox ID="ContributorTextBox" runat="server" Text='<%# Bind("Contributor") %>' />
            <br />
            
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            <strong>Name:</strong>
            <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
            <br />
            <strong>Detail:</strong>
            <asp:Label ID="DetailLabel" runat="server" Text='<%# Bind("Detail") %>' />
            <br />
            &nbsp;<asp:Image ID="Image1" CssClass="image-size" runat="server" ImageUrl='<%# Eval("Image1") %>' />
            <br />
            <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("Image2") %>' />
&nbsp;<br />&nbsp;<asp:Image ID="Image3" runat="server" ImageUrl='<%# Eval("Image3") %>' />
            <br />
            <strong>MRP:</strong>
            <asp:Label ID="MRPLabel" runat="server" Text='<%# Bind("MRP") %>' />
            <br />
            Category:
            <asp:Label ID="CategoryLabel" runat="server" Text='<%# Bind("Category") %>' />
            <br />
            Contributor:
            <asp:Label ID="ContributorLabel" runat="server" Text='<%# Bind("Contributor") %>' />
            <br />
            <asp:Button ID="Button1" runat="server" CommandName="AddToCart" CommandArgument='<%# Eval("ID") %>' Text="Add To Cart" />
            <br />
            
        </ItemTemplate>
    </asp:FormView>
    </div>
    
</asp:Content>
