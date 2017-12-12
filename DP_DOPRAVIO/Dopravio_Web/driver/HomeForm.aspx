<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeForm.aspx.cs" Inherits="Dopravio_Web.driver.HomeForm" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <title>Moje udalosti - vodič</title>
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
            width:100%;
        }

          .formTable tr {
            border: none;
            margin: 10px;
        }

          
          .formTable tr td:first-of-type {
            font-weight:bold;
        }

          table input, textarea, select {
              width:100%;
          }
    </style>
</head>
<body>
    <form runat="server" visible="true" id="formData">
     <asp:ScriptManager runat="server" ID="sm">
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
                        <li class="active"><a href="HomeForm.aspx">Moje udalosti</a></li>
                        <li><a href="MyJourneysForm.aspx">Moje jazdy</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li style="color: white;">
                            <asp:LinkButton runat="server" ID="logoutBtn" OnClick="logoutBtn_Click" CssClass="whiteA"  AutoPostback="false" CausesValidation="False"><span class="glyphicon glyphicon-log-out" ></span> Odhlásiť</asp:LinkButton>

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
                        <h1>Moje udalosti</h1>
                    </div>
                    <div class="col-sm-6 text-right">
                        <button type="button" class="btn btn-info btn-lg" style="margin-top: 20px;" data-toggle="modal" data-target="#myModal">Pridať udalosť</button>

                        <!-- Modal -->
                        <div class="modal fade text-left" id="myModal" role="dialog">
                            <div class="modal-dialog modal-lg" style="margin-top: 100px;">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h1 class="modal-title">Nová udalosť</h1>
                                    </div>
                                    <div class="modal-body">
                                        <table border="0" cellpadding="0" cellspacing="0" class="formTable">
                                            <tr>
                                            </tr>
                                            <tr>
                                                <td>Jazda
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="dlJourney" CssClass="form-control"></asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ErrorMessage="Povinný údaj" ForeColor="Red" ControlToValidate="dlJourney"
                                                        runat="server" />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>Druh
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="dlType" CssClass="form-control"></asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ErrorMessage="Povinný údaj" ForeColor="Red" ControlToValidate="dlType"
                                                        runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Závažnosť
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSeverity" runat="server" TextMode="Number" CssClass="form-control" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ErrorMessage="Povinný údaj" ForeColor="Red" ControlToValidate="txtSeverity"
                                                        runat="server" />
                                                </td>
                                            </tr>
                                              <tr>
                                                <td>Miesto
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPlace" runat="server" CssClass="form-control"  />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ErrorMessage="Povinný údaj" ForeColor="Red" ControlToValidate="txtPlace"
                                                        runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Správa
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" CssClass="form-control" />
                                                </td>
                                                <td>
                                                     <asp:RequiredFieldValidator ErrorMessage="Povinný údaj" ForeColor="Red" ControlToValidate="txtMessage"
                                                        runat="server" />
                                                </td>
                                            </tr>
                                         
                                            <tr>
                                                <td></td>
                                                <td>
                                                    
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Zatvoriť</button>
                                                <asp:Button runat="server" ID="btnSave" Text="Uložiť" CssClass="btn btn-primary" OnClick="btnSave_Click" AutoPostback="false" />

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:Table ID="tableFailures" runat="server" Width="100%">
                        <asp:TableRow>
                            <asp:TableCell>Vytvorené</asp:TableCell>
                            <asp:TableCell>Miesto</asp:TableCell>
                            <asp:TableCell>Správa</asp:TableCell>
                            <asp:TableCell>Vozidlo</asp:TableCell>
                            <asp:TableCell>Linka</asp:TableCell>
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

    </form>
</body>
</html>

