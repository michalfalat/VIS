</html><%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeForm.aspx.cs" Inherits="Dopravio_Web.manager.HomeForm" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <title>Prehľad - manager</title>
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
            color: white !important;
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
            font-weight: bold;
        }

        table tr {
            border-bottom: 1px solid darkgray;
            line-height: 3;
        }

        .formTable {
            width: 100%;
        }

            .formTable tr {
                border: none;
                margin: 10px;
            }


                .formTable tr td:first-of-type {
                    font-weight: bold;
                }

        table input, textarea, select {
            width: 100%;
        }


        .greenDash {
            background-color: #1BC98E;
            color: white;
        }

        .redDash {
            background-color: #E64759;
            color: white;
        }

        .purpleDash {
            background-color: #9F86FF;
            color: white;
        }

        .blueDash {
            background: #3498DB;
            color: white;
        }

        .orangeDash {
            background-color: #ff997c;
            color: white;
        }

        .well h4 {
            font-weight: bold;
        }

        .well h3 {
            font-weightbold;
            margin-top:8px;
        }
    </style>
</head>
<body>
    <form runat="server" visible="true" id="form1">
        <asp:ScriptManager runat="server" ID="ScriptManager1">
        </asp:ScriptManager>
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
                        <li class="active"><a href="HomeForm.aspx">Reporty</a></li>
                        <li><a href="RequestsForm.aspx">Žiadosti</a></li>
                        <li><a href="MessagesForm.aspx">Správy</a></li>
                        <li><a href="EmployeesForm.aspx">Zamestnanci</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li style="color: white;">
                            <asp:LinkButton runat="server" ID="LinkButton1" OnClick="logoutBtn_Click" CssClass="whiteA" AutoPostback="false" CausesValidation="False"><span class="glyphicon glyphicon-log-out" ></span> Odhlásiť</asp:LinkButton>

                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="container-fluid text-center">
            <div class="row content">
                <div class="col-sm-2 sidenav">
                </div>
                <div class="col-sm-8 text-left" style="background-color: white; margin-top: 50px; padding: 20px;">
                    <div class="col-sm-6">
                        <h1>Prehľad</h1>
                    </div>
                    <div class="container-fluid">
                        <div class="row content">

                            <br>

                            <div class="col-sm-12">

                                <div class="row">
                                    <div class="col-sm-3">
                                        <div class="well purpleDash">
                                            <h4>Počet vodičov</h4>
                                            <p>
                                                <asp:Label runat="server" ID="lbDrivers"></asp:Label></p>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="well purpleDash">
                                            <h4>Počet dispečerov</h4>
                                            <p>
                                                <asp:Label runat="server" ID="lbDispatchers"></asp:Label></p>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="well orangeDash">
                                            <h4>Mesačné náklady </h4>
                                            <p>
                                                <asp:Label runat="server" ID="lbSalaries"></asp:Label>
                                                €</p>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="well blueDash">
                                            <h4>Počet vozidiel</h4>
                                            <p>
                                                <asp:Label runat="server" ID="lbVehicles"></asp:Label></p>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <h1>Žiadosti</h1>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="well blueDash">
                                            <h4>Nové žiadosti</h4>
                                            <p>
                                                <asp:Label runat="server" ID="lbNewRequests"></asp:Label></p>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="well redDash">
                                            <h4>Zametnuté žiadosti</h4>
                                            <p>
                                                <asp:Label runat="server" ID="lbDeclinedRquests"></asp:Label></p>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="well greenDash">
                                            <h4>Potvrdené žiadosti</h4>
                                            <p>
                                                <asp:Label runat="server" ID="lbAcceptedRequests"></asp:Label></p>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                        <h1>Udalosti</h1>
                    </div>
                                    <div class="col-sm-8">
                                        <div class="well redDash">
                                            <h3>Počet udalostí</h3>
                                            <h4>
                                                <asp:Label runat="server" ID="lbFailures"></asp:Label></h4>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="well orangeDash">
                                            <h4>Za posledný mesiac</h4>
                                            <p>
                                                <asp:Label runat="server" ID="lbFaliresLastMonth"></asp:Label></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="col-sm-2 sidenav">
                </div>
            </div>
        </div>

        <footer class="container-fluid text-center">
            <p>Autor: Michal Falát, FAL0045</p>
        </footer>

    </form>
</body>
</html>



