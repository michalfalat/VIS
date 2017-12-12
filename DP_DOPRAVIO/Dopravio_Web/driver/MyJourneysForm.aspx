<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyJourneysForm.aspx.cs" Inherits="Dopravio_Web.driver.MyJourneysForm" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Moje jazdy - vodič</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        body {
            
            background-color: #f1f1f1;
        }
        /* Remove the navbar's default margin-bottom and rounded borders */
        .navbar {
            margin-bottom: 0;
            border-radius: 0;
        }

        /* Set height of the grid so .sidenav can be 100% (adjust as needed) */
        .row.content {
            height: 450px
        }

        /* Set gray background color and 100% height */
        .sidenav {
            padding-top: 20px;
            background-color: #f1f1f1;
            height: 100%;
        }

        /* Set black background color, white text and some padding */
        footer {
            background-color: #555;
            color: white;
            padding: 15px;
            position: fixed;
            bottom: 0;
            width: 100%;
        }

        .whiteA {
            color:white !important;
        }

        /* On small screens, set height to 'auto' for sidenav and grid */
        @media screen and (max-width: 767px) {
            .sidenav {
                height: auto;
                padding: 15px;
            }

            .row.content {
                height: auto;
            }
        }
        table tr:first-of-type {
            font-weight:bold;
        }

        table tr {
               border-bottom: 1px solid darkgray;
            line-height: 3;
        }
        
    </style>
</head>
<body>

    <nav class="navbar navbar-inverse">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">DOPRAVIO A. S.</a>
            </div>
            <div class="collapse navbar-collapse" id="myNavbar">
                <ul class="nav navbar-nav">
                    <li ><a href="HomeForm.aspx">Moje udalosti</a></li>
                    <li class="active"><a href="MyJourneysForm.aspx">Moje jazdy</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li style="color:white;margin-top:15px;">
                        <form runat="server">
                            <asp:LinkButton  runat="server" ID="logoutBtn" OnClick="logoutBtn_Click" CssClass="whiteA"><span class="glyphicon glyphicon-log-out"></span> Odhlásiť</asp:LinkButton>
                        </form>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="container-fluid text-center">
        <div class="row content">
            <div class="col-sm-2 sidenav">
            </div>
            <div class="col-sm-8 text-left" style="background-color:white; margin-top: 50px;padding:20px;">
                <h1>Moje jazdy</h1>
                <asp:Table ID="tableJourneys" runat="server" Width="100%">
                    <asp:TableRow >
                        <asp:TableCell>Odchod</asp:TableCell>
                        <asp:TableCell>Príchod</asp:TableCell>
                        <asp:TableCell>Vozidlo</asp:TableCell>
                        <asp:TableCell>Trasa</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <div class="col-sm-2 sidenav">
            </div>
        </div>
    </div>

    <footer class="container-fluid text-center">
            <p>Autor: Michal Falát, FAL0045</p>
    </footer>

</body>
</html>
