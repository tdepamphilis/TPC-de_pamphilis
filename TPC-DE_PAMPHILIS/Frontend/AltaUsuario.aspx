<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="Frontend.AltaUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>

</head>
<body style="background-color:#e8e4e1">
    <form id="form1" runat="server">
        <div class="container-fluid" style="background-color: dimgrey">
            <div class="row">
                <div class="col-sm-1" style="text-align: center">
                    <img src="https://darodistribuidora.com/wp-content/uploads/logodarodist.png" style="width: 170px; height: 80px" alt="Alternate Text" />
                </div>
                <div class="col-sm-5" style="position: relative; top: 27px; text-align: center">
                </div>
                <div class="hidden-lg hidden-md hidden-sm">&nbsp;</div>
                <div class="col-sm-3" style="position: relative; top: 25px; text-align: center;">
                </div>
                <div class="hidden-lg hidden-md hidden-sm">&nbsp;</div>
                <div class="col-sm-3"></div>
            </div>
        </div>
        <div class="container" style="">
            <div class="row justify-content-center">
                <div class="col-5 justify-content-center">
                     <img src="https://darodistribuidora.com/wp-content/uploads/logodarodist.png" style="width: 460px; height: 280px" alt="Alternate Text" />
                </div>
            </div>                        
            <div class="row justify-content-center">
                <div class="col-5">

                    <div class="container mt-5">
                        <div class="form-row justify-content-center mt-3">

                            <div class="form-group col-md-6 my-2">
                                <asp:Label ID="LabelNombre" runat="server" Text="Nombre"></asp:Label>
                                <asp:TextBox ID="TextName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-6 my-2">
                                <asp:Label ID="LabelApellido" runat="server" Text="Apellido"></asp:Label>
                                <asp:TextBox ID="TextApellido" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                        <div class="form-row justify-content-center mt-2">
                            <div class="form-group col-6 my-2 ">

                                <asp:Label ID="LabelCorreo" runat="server" Text="Correo"></asp:Label>
                                <asp:TextBox ID="TextMail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-6 my-2">
                                <asp:Label ID="LabelPass" runat="server" Text="Contraseña"></asp:Label>
                                <asp:TextBox ID="TextPass" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row justify-content-center mt-2">
                            <div class="form-group col-6 my-2 ">

                                <asp:Label ID="LabelDNI" runat="server" Text="D.N.I."></asp:Label>
                                <asp:TextBox ID="TextDNI" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-6 my-2">
                                <asp:Label ID="LabelTel" runat="server" Text="Telefono"></asp:Label>
                                <asp:TextBox ID="TextTel" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row justify-content-center mt-2">
                            <div class="form-group col-9 my-2 ">

                                <asp:Label ID="LabelDir" runat="server" Text="Direccion de su comercio"></asp:Label>
                                <asp:TextBox ID="TextDir" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-3 my-2">
                                <asp:Label ID="Label2" runat="server" Text="Zona"></asp:Label>
                                <asp:DropDownList ID="DropDownZonas" runat="server" CssClass="dropwdown"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row justify-content-center mt-4">
                            <asp:Button ID="ButtonSend" runat="server" Text="Registrarse" CssClass="btn btn-light"/>
                        </div>
                    </div>
                </div>
            </div>

        </div>



    </form>
</body>
</html>
