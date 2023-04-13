<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="AasaWebApp.homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>--%>

    <link href="homepage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <h1>AASA</h1>
        </center>
    <div class="container-fluid">
           <div class="col-12">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=SHIVAM-ASUS\SQLEXPRESS;Initial Catalog=aasa;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [ID],[Name], [Detail], [Image1], [MRP], [Category], [Contributor] FROM [product_tbl]" ></asp:SqlDataSource>

  <asp:DataList ID="DataList1" CssClass="table" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" ItemStyle-HorizontalAlign="Justify" ItemStyle-VerticalAlign="Top" RepeatColumns="5" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" OnItemCommand="DataList1_ItemCommand">
    <ItemTemplate>

        <div class="card">
            <div class="col-12">
                <br />
                <%--<div class="row">
                    <div class="col-12">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Detail") %>' Font-Size="Small"></asp:Label>
                    </div>
                </div>--%>
                <div class="row">
                    <div class="col-12">
                        <asp:Image ID="Image1" CssClass="image-size" runat="server" ImageUrl='<%# Eval("Image1") %>' />
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-12">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text='<%# Eval("Name") %>' Font-Size="X-Large"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        MRP-<asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("MRP") %>' Font-Size="Small"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        Category-<asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Category") %>' Font-Size="Small"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        Contributor-<asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("Contributor") %>' Font-Size="Small"></asp:Label>
                    </div>
                </div>
                <div class="row"> 
                    <div class="col-12">
                        <asp:LinkButton ID="LinkButton2" CommandName="AddToCart" CommandArgument='<%# Eval("ID") %>' runat="server">Add to Cart</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="View" CommandArgument='<%# Eval("ID") %>'>View</asp:LinkButton>
                        <asp:ImageButton ID="WishlistButton" CssClass="wishlist" CommandName="AddToWishlist" CommandArgument='<%# Eval("ID") %>' runat="server" ImageUrl="Images/wishlist.png" />
                    </div>  
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:DataList>

</div>

       
   </div>
   
   
    

</asp:Content>
