<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="AasaWebApp.feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5 mx-auto">

                <div class="card">
                    <div class="card-body">
                        <%--<div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="img/adminuser.png" />
                                </center>
                            </div>

                        </div>--%>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Feedback</h3>
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
                                <label>Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Your Name" runat="server"></asp:TextBox>
                                </div>
                                <label>Comment</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Comment" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <br />

                                <div class="form-group d-grid gap-2">
                                    <asp:Button ID="Button1" CssClass="btn btn-success btn-block btn-lg " runat="server" Text="Submit" OnClick="Button1_Click" />
                                     
                                     
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
