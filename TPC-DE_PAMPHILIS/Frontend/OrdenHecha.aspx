<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdenHecha.aspx.cs" Inherits="Frontend.OrdenHecha" %>

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
        <div class="container-fluid" style="background-color: dimgrey">
            <div class="row">
                <a href="Tienda.aspx">
                    <img src="https://darodistribuidora.com/wp-content/uploads/logodarodist.png" style="width: 170px; height: 80px" alt="Alternate Text" />
                </a>
                <div class="col-sm-4" style="position: relative; top: 27px; text-align: center;">
                    <div class="dropdown show">
                        <a href="Tienda.aspx" class="btn btn-dark btn-sm">Tienda</a>
                        <a href="MisCompras.aspx" class="btn btn-dark btn-sm">Mis pedidos</a>
                        <a href="MainPage.aspx" class="btn btn-dark btn-sm">Salir</a>
                        <a href="MiCarrito.aspx" class="btn btn-dark btn-sm">Carrito<%=" (" + carrito.items.Count + ")" %></a>
                    </div>
                </div>
                <div class="col-sm-4" style="position: relative; top: 27px;"></div>
                <div class="col-sm-3"></div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row mt-5 justify-content-center">
                <div class="col-4">
                    <div class="card">

                        <div class="card-header text-center">
                            <h3>Pedido Confirmado.</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <p>Su compra ha sido procesada y aguarda confirmacion.  </p>
                                <p>Podra ver su estado en "mis pedidos".</p>
                            </div>               
                            <div class="row">
                                <p>Gracias por comprar con nosotros!</p>
                            </div>
                        </div>
                        <div class="card-footer">
                            <div class="row justify-content-center">
                                <a href="MisCompras.aspx" class="btn btn-secondary mx-1">Mis pedidos</a>
                                <a href="Tienda.aspx" class="btn btn-secondary mx-1">Continuar</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
