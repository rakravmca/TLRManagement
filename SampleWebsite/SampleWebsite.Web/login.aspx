<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SampleWebsite.Web.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="divMain">
            <div id="divHeader">
                <div id="divHeaderTop">
                    <a href="#">Register</a>
                </div>
                <div id="divHeaderBottom"></div>
            </div>
            <div id="divMenu">
            </div>
            <div id="divBody">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-xs-12 col-sm-3 col-md-4">
                        </div>
                        <div class="col-xs-12 col-sm-6 col-md-4">
                            <div class="container-fluid boxBorder" id="divLogin">
                                <div class="row form-group">
                                    <div class="col-xs-12">
                                        <h4><b>User Login:</b></h4>
                                    </div>
                                    <div class="col-xs-12">
                                        <asp:Label ID="lblError" runat="server" color="red" Visible="false" ForeColor="Red">Invalid Username or Password</asp:Label>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-xs-12 col-sm-3">
                                        <label for="txtUsername">Username</label>
                                    </div>
                                    <div class="col-xs-12 col-sm-9">
                                        <input type="text" id="txtUsername" class="form-control" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server"
                                            ControlToValidate="txtUsername"
                                            ErrorMessage="Username is a required field."
                                            ValidationGroup="vgLogin"
                                            ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-xs-12 col-sm-3">
                                        <label for="txtPassword">Password</label>
                                    </div>
                                    <div class="col-xs-12 col-sm-9">
                                        <input type="password" class="form-control" id="txtPassword" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                                            ControlToValidate="txtPassword"
                                            ErrorMessage="Password is a required field."
                                            ValidationGroup="vgLogin"
                                            ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-xs-12" style="text-align: right;">
                                        <asp:Button ID="btnLogin" runat="server" OnClick="Login_Click" Text="Login" Class="btn btn-default" ValidationGroup="vgLogin" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group" style="text-align: right;">
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-3 col-md-4">
                        </div>
                    </div>
                </div>
            </div>
            <div id="divFooter">
                <div id="divFooterTop"></div>
                <div id="divFooterContent"></div>
                <div id="divFooterBottom"></div>
            </div>
        </div>
    </form>
</body>
</html>
