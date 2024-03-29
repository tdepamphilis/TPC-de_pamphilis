﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Frontend.MainPage" %>

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
<body  style="background: #e8e4e1">
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
        <div class="container" style="position: relative; top: 150px">
            <div class="row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4" style="text-align: center">
                    <div class="form-group">
                        <img src="https://darodistribuidora.com/wp-content/uploads/logodarodist.png" style="width: 370px; height: 160px" alt="Alternate Text" />
                    </div>
                    <div class="form-group">
                    <asp:TextBox ID="TextUser" runat="server" CssClass="form-control" Placeholder="Correo electronico"></asp:TextBox>
                    </div>
                    <div class="form-group"> 
                    <asp:TextBox ID="TextPass" runat="server" CssClass="form-control" placeholder="Contraseña" type="password" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="ButtonLogin" runat="server" Text="Login"  CssClass="btn btn-light" OnClick="ButtonLogin_Click"/>
                        <a href="AltaUsuario.aspx" class="btn btn-light">Registrarse</a>
                    </div>
                    <div class="form-group">
                        <a href="#" style="text-align:left; font-size:x-small">Olvido su contraseña?</a>                        
                    </div>
                </div>
                <div class="col-sm-4"></div>
            </div>
            
        </div>
    </form>
</body>
</html>
