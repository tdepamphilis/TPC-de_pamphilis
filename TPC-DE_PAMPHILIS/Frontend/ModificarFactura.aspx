<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarFactura.aspx.cs" Inherits="Frontend.ModificarFactura" %>

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
                <div class="col-sm-1" style="text-align: center">
                    <a href="TiendaAdmin.aspx">
                        <img src="https://darodistribuidora.com/wp-content/uploads/logodarodist.png" style="width: 170px; height: 80px" alt="Alternate Text" />
                    </a>
                </div>
                <div class="col-sm-5" style="position: relative; top: 27px; text-align: center">
                    <div class="dropdown show">
                        <a class="btn btn-secondary btn-sm dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Nuevo</a>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                            <a class="dropdown-item" href="NuevoProducto.aspx">Producto</a>
                            <a class="dropdown-item" href="NewBC.aspx?type=cat">Categoria</a>
                            <a class="dropdown-item" href="NewBC.aspx?type=brand">Marca</a>
                        </div>
                        <a href="GestionStock.aspx" class="btn btn-dark btn-sm">Stock</a>
                        <a href="Marcas.aspx" class="btn btn-dark btn-sm">Marcas</a>
                        <a href="Categorias.aspx" class="btn btn-dark btn-sm">categorias</a>
                        <a href="#" class="btn btn-dark btn-sm"><%="Facturacion (" + facturaBusiness.contarPendientes() + ")" %></a>
                        <a href="MainPage.aspx" class="btn btn-dark btn-sm">Salir</a>
                    </div>
                </div>
                <div class="hidden-lg hidden-md hidden-sm">&nbsp;</div>
                <div class="col-sm-3" style="position: relative; top: 25px; text-align: center;">
                </div>
                <div class="hidden-lg hidden-md hidden-sm">&nbsp;</div>
                <div class="col-sm-3"></div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row justify-content-center mt-6">

                <div class="col-4">

                    <div class="card">

                        <div class="card-header">

                            <h2 style="text-align: center">Quitar items</h2>

                        </div>
                        <div class="card-body" style="min-height: 300px; max-height: 350px; overflow: auto">

                            <%foreach (Dominio.ItemCarrito item in factura.items)
                                { %>
                            <div class="d-flex bd-highlight mb-3 card-header pt-2" style="border: thin">
                                <div class="mr-auto p-2 bd-highlight">

                                    <p><%=item.name + " x " + item.ammount.ToString() %></p>
                                    <p><%= "Subtotal: $" + item.partialPrice() %></p>

                                </div>
                                <div class="p-2 bd-highlight align-self-center">

                                    <div class="input-group input-group-sm">
                                        <div class="input-group-append">                                            
                                            <a class="btn btn-secondary btn-sm" href="ModificarFactura.aspx?-1=<%=item.code %>">-1</a>
                                            <a class="btn btn-secondary btn-sm" href="ModificarFactura.aspx?-10=<%=item.code %>">-10</a>
                                            <a class="btn btn-secondary btn-sm" href="ModificarFactura.aspx?rmv=<%=item.code %>">Quitar</a>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%} %>
                        </div>
                        <div class="card-footer">
                            <div class="row justify-content-center">
                                <p><%="Monto original: $" + originalPrice.ToString() %></p>
                            </div>
                            <div class="row justify-content-center">
                                <p><%="Monto nuevo: $" + factura.monto.ToString() %></p>
                            </div>
                            <div class="row justify-content-center mt-1">
                                <asp:Button ID="buttonConfirm" runat="server" Text="Continuar" CssClass="btn btn-secondary" OnClick="buttonConfirm_Click" />
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
