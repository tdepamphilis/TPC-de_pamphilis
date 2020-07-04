<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewBC.aspx.cs" Inherits="Frontend.NewBC" %>

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
<body style="background: #e8e4e1">
    <form id="form1" runat="server">
        <div class="row" style="background-color: dimgrey">
            <div class="col-sm-1" style="text-align: center">
                <a href="TiendaAdmin.aspx">
                    <img src="https://darodistribuidora.com/wp-content/uploads/logodarodist.png" style="width: 170px; height: 80px" alt="Alternate Text" />
                    </a>
            </div>
            <div class="col-sm-10" style="position: relative; top: 27px; text-align: center">
                <div class="dropdown show">
                    <a class="btn btn-secondary btn-sm dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Nuevo</a>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                        <a class="dropdown-item" href="NuevoProducto.aspx">Producto</a>
                        <a class="dropdown-item" href="NewBC.aspx?type=cat">Categoria</a>
                        <a class="dropdown-item" href="NewBC.aspx?type=brand">Marca</a>
                    </div>

                    <a href="TiendaAdmin.aspx" class="btn btn-dark btn-sm" style="text-align: left">Productos</a>
                    <a href="GestionStock.aspx" class="btn btn-dark btn-sm">Stock</a>
                    <a href="Marcas.aspx" class="btn btn-dark btn-sm">Marcas</a>
                    <a href="Categorias.aspx" class="btn btn-dark btn-sm">categorias</a>
                    <a href="FacturacionAdmin.aspx" class="btn btn-dark btn-sm"><%="Facturacion (" + facturaBusiness.contarPendientes() + ")" %></a>
                    <a href="MainPage.aspx" class="btn btn-dark btn-sm">Salir</a>
                </div>
            </div>
        </div>
        <div>&nbsp;</div>
        <div class="container">
            <div class="form-row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4" style="text-align: center">
                    <h1>Nueva <%= title%> </h1>
                </div>
                <div class="col-sm-4"></div>
                <div>&nbsp;</div>
            </div>
            <div class="form-row">
                <div class="col-sm-5"></div>
                <div class="col-sm-2" style="text-align:center">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                </div>
                <div class="col-sm-5"></div>
                <div>&nbsp;</div>
            </div>
            <div class="form-row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4" style="text-align: center">
                    <asp:Button ID="Confirm" runat="server" Text="Confirmar" OnClick="Confirm_Click" CssClass="btn btn-light" />
                </div>
                <div class="col-sm-4"></div>
            </div>
        </div>
    </form>
</body>
</html>
