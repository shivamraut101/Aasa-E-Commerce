<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="AasaWebApp.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <ul>
                <li>
                     <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Update Profile</asp:LinkButton>
                </li>
                <li>
                     <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Your Orders</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Payment Option</asp:LinkButton>
                </li>
                <li>
                     <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Contact Us</asp:LinkButton>
                </li>
            </ul>
           
        </div>
    </div>
</asp:Content>
