<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="AasaWebApp.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="customcss/userlogin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container rounded">
        <div class="row">
            <div class="col-md-4 mx-auto">

                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <%--<img width="150px" src="img/generaluser.png" />--%>
                                </center>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>User Login</h3>
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
                                <label>User Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Username" runat="server"></asp:TextBox>
                                </div>
                                
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                                <br />

                                <div class="form-group d-grid gap-2">

                                    <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Login" OnClick="Button1_Click" />
                                    
                                     <a href="usersignup.aspx" style="text-decoration: none">
                                        <input id="Button2" class="btn btn-info " type="button" value="Sign Up" /></a>
                                     
                                </div>


                            </div>
                        </div>

                    </div>
                    <button id="BTH"><a href="homepage.aspx" id="backToHome">👈 Back to Home</a></button>
                </div>
                <br />

                

            </div>
        </div>
    </div>
</asp:Content>
