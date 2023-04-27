<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="AasaWebApp.homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>--%>

    <link href="homepage.css" rel="stylesheet" />

   

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <h1>AASA</h1>
        </center>
    <%--Crousel Start--%>

    <asp:Panel ID="Panel1" runat="server">
        
        <div class="container">
                      
            <div id="myCarousel" class="carousel slide" style="width: 1000px; height: 200.5px;" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <asp:Repeater ID="rptIndicators" runat="server">
                        <ItemTemplate>
                            <li data-target="#myCarousel" data-slide-to="<%# Container.ItemIndex %>"></li>
                            
                        </ItemTemplate>
                    </asp:Repeater>
                </ol>

                <!-- Slides -->
                <div class="carousel-inner" >
                    <asp:Repeater ID="rptSlides" runat="server" OnItemCommand="rptSlides_ItemCommand" >
                        <ItemTemplate >
                            
                                <div class="item <%# Container.ItemIndex == 0 ? "active" : "" %>" >
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="View" CommandArgument='<%# Eval("ID") %>' CssClass="my-link-button" >
                                    <asp:Image ID="Image1" CssClass="image-size" runat="server" ImageUrl='<%# Eval("Image1") %>' />
                                    <div class="carousel-caption" style="padding-left: 48px; color: black; padding-top: 20px; padding-bottom: 20px; bottom: 0;">
                                        <h3><%# Eval("Name") %></h3>
                                        <!-- Additional caption or description data from database -->
                                        <p><%# Eval("Detail") %></p>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                           
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <!-- Controls -->
                <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
   
    </asp:Panel>

    

    <br />
    <%--Crousel Ends--%>
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
