<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="AasaWebApp.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5 mx-auto">

                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <%--<img width="150px" src="img/adminuser.png" />--%>
                                </center>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin login</h3>
                                </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr>
                                </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Admin ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Admin Id" runat="server"></asp:TextBox>
                                </div>
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                                <br />

                                <div class="form-group d-grid gap-2">
                                    <asp:Button ID="Button1" CssClass="btn btn-success btn-block btn-lg " runat="server" Text="Login" OnClick="Button1_Click" />
                                     <%--<a href="usersignup.aspx" style="text-decoration: none">
                                        <input id="Button2" class="btn btn-info btn-lg w-100 " type="button" value="Sign Up" /></a>--%>
                                     
                                </div>


                            </div>
                        </div>

                    </div>
                    <a href="homepage.aspx" style="text-decoration:none"><< Back to Home</a>
                </div>
                <br />

                

            </div>
        </div>
    </div>
</asp:Content>
