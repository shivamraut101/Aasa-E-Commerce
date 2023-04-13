<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="payment.aspx.cs" Inherits="AasaWebApp.payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-6 mx-auto">
                <div class="card">
                    <br />
                    <center>
                        <h1>Payment Details</h1>
                    <i class="fa-solid fa-credit-card fa-2x" ></i>
                    </center>
                    <hr />
                    <div class="card-body">
                        <h4>Card Details</h4>
                        
                        <asp:Label ID="Label1" runat="server" Text="Name on Card"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Card Number"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                        <div class="row">
                            <div class="col-4">
                                <asp:Label ID="Label3" runat="server" Text="Security Code"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <asp:Label ID="Label4" runat="server" Text="Expriration Date"></asp:Label>
                        <br />
                                <asp:TextBox ID="TextBox4" runat="server" TextMode="Date"></asp:TextBox> 
                            </div>
                        </div>
                        <br />
                        <h4>Billing Information</h4>
                        <div class="row">
                            <div class="col-12">
                                <asp:Label ID="Label5" runat="server" Text="First Name"></asp:Label>
                                <asp:TextBox ID="TextBox5" runat="server" Text="Rajesh"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <asp:Label ID="Label6" runat="server" Text="Second Name"></asp:Label>
                                <asp:TextBox ID="TextBox6" runat="server" Text="Kutrapali"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <asp:Label ID="Label7" runat="server" Text="Billing Address"></asp:Label>
                                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-12">
                                <asp:Label ID="Label8" runat="server" Text="City"></asp:Label>
                                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <asp:Label ID="Label9" runat="server" Text="Pincode"></asp:Label>
                                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-6">
                                <asp:Label ID="Label10" runat="server" Text="State"></asp:Label>
                                <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        
                        <asp:LinkButton ID="LinkButton1" runat="server">SUBMIT</asp:LinkButton>
                    </div>

                </div>
            </div>
        </div>

    </div>
</asp:Content>
