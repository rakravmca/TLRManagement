<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="publicsite.aspx.cs" Inherits="SampleWebsite.Web.publicsite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.11.3.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="angular/angular.min.js"></script>
    <script src="angular/angular-route.min.js"></script>
    <script src="Scripts/PublicSite.js"></script>

    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="divMain" data-ng-app="publicSiteApp">
            <div id="divHeader">
                <div id="divHeaderTop" class="navbar-default">
                    <a href="login.aspx">Login</a>
                    <a href="#" style="display: none;">Register</a>
                </div>
                <div id="divHeaderBottom"></div>
            </div>
            <div id="divMenu">
            </div>
            <div id="divBody">
                <div data-ng-view="" class="container-fluid"></div>
            </div>
            <div id="divFooter">
                <div id="divFooterTop"></div>
                <div id="divFooterContent"></div>
                <div id="divFooterBottom" class="navbar-default">
                    <a href="#">Copyrights</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
