<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="add-to-cart.aspx.cs" Inherits="AasaWebApp.add_to_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
     </script>
    <link href="homepage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Shopping Cart</h1>
    <hr />
    <div class="container">
        <div class="row">

            <%--Code For Display Added Product To Cart--%>
            <div class="col-md-8">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=SHIVAM-ASUS\SQLEXPRESS;Initial Catalog=aasa;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [usercart_tbl] WHERE user_id=@user_id">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="user_id" QueryStringField="user_id" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:DataList ID="DataList1" CssClass="table" OnItemCommand="DataList1_ItemCommand" runat="server" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
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
                        
                        <asp:LinkButton ID="LinkButton11" CommandName="Remove" CommandArgument='<%# Eval("ID") %>' runat="server">Remove</asp:LinkButton>
                        
                        <br />
                        <hr />
                    </ItemTemplate>
                </asp:DataList>
            </div>

            <%--Code For Procceding To CheckOut Pay--%>
            <div class="col-md-4">

              <span style="font-size: medium; font-family: Arial, Helvetica, sans-serif">Subtotal: </span> <asp:Label ID="lblSubTotalPrice" runat="server"  Font-Bold="True"></asp:Label>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Proceed To Buy</asp:LinkButton>
            </div>

        </div>


    </div>

</asp:Content>
