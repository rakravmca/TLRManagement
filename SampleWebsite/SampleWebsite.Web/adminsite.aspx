<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminsite.aspx.cs" Inherits="SampleWebsite.Web.adminsite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.11.3.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="angular/angular.min.js"></script>
    <script src="angular/angular-route.min.js"></script>
    <script src="Scripts/Utility.js"></script>
    <script src="Scripts/AdminSite.js"></script>

    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="divMain" data-ng-app="adminSiteApp">
                <div id="divHeader">
                    <div id="divHeaderTop" class="navbar-default">
                        <div class="authLinks">
                            <a href="#" style="display: none;">Register</a>
                            <asp:LinkButton ID="lnkBtnSignout" runat="server" OnClick="SignOut" Text="Logout"></asp:LinkButton>
                        </div>
                    </div>
                    <div id="divHeaderContent"></div>
                    <div id="divHeaderBottom">
                        <div id="divMenu">
                            <nav class="navbar navbar-inverse">
                                <div class="container-fluid">
                                    <!-- Brand and toggle get grouped for better mobile display -->
                                    <div class="navbar-header">
                                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                                            <span class="sr-only">Toggle navigation</span>
                                            <span class="icon-bar"></span>
                                            <span class="icon-bar"></span>
                                            <span class="icon-bar"></span>
                                        </button>
                                        <a class="navbar-brand" href="#">Brand</a>
                                    </div>

                                    <!-- Collect the nav links, forms, and other content for toggling -->
                                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                                        <ul class="nav navbar-nav">
                                            <li class="active"><a href="#/home">Home</a></li>
                                            <li><a href="#/product">Products</a></li>
                                            <li>
                                                <a class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Orders 
                                                    <span class="caret"></span>
                                                </a>
                                                <ul class="dropdown-menu">
                                                    <li><a href="#/stitchingorder/0">Add</a></li>
                                                    <li><a href="#/stitchingorder">List</a></li>
                                                </ul>
                                            </li>

                                        </ul>
                                    </div>
                                    <!-- /.navbar-collapse -->
                                </div>
                                <!-- /.container-fluid -->
                            </nav>
                        </div>
                    </div>
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
        </div>
    </form>
</body>
</html>
