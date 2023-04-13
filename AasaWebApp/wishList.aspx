<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="wishList.aspx.cs" Inherits="AasaWebApp.wishList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
     </script>
    <link href="homepage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=SHIVAM-ASUS\SQLEXPRESS;Initial Catalog=aasa;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [userwishlist_tbl] WHERE user_id=@user_id">
             <SelectParameters>
        <asp:QueryStringParameter Name="user_id" QueryStringField="user_id" Type="String" />
    </SelectParameters>
         </asp:SqlDataSource>
    <asp:DataList ID="DataList1" CssClass="table" runat="server" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
        <ItemTemplate>
            <strong>Name:</strong>
            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            <strong>
            <br />
            Detail:</strong>
            <asp:Label ID="DetailLabel" runat="server" Text='<%# Eval("Detail") %>' />
            <br />
            <asp:Image ID="Image1" CssClass="image-size" runat="server" ImageUrl='<%# Eval("Image1") %>' />
            <asp:Image ID="Image2" runat="server" CssClass="image-size" ImageUrl='<%# Eval("Image2") %>' />
            <asp:Image ID="Image3" runat="server" CssClass="image-size" ImageUrl='<%# Eval("Image3") %>' />
            <br />
            <strong>MRP:</strong>
            <asp:Label ID="MRPLabel" runat="server" Text='<%# Eval("MRP") %>' />
            <br />
            <em>Category:</em>
            <asp:Label ID="CategoryLabel" runat="server" Text='<%# Eval("Category") %>' />
            <br />
            <em>Contributor:</em>
            <asp:Label ID="ContributorLabel" runat="server" Text='<%# Eval("Contributor") %>' />
            <br />
            Date:
            <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </ItemTemplate>
    </asp:DataList>
    </div>
</asp:Content>
