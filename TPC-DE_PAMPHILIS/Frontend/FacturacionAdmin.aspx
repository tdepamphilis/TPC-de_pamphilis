<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FacturacionAdmin.aspx.cs" Inherits="Frontend.FacturacionAdmin" %>

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
                    <div class="input-group mb-4">
                        <div class="input-group-prepend">
                            <asp:DropDownList ID="DropDown" runat="server" CssClass=" custom-select" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <asp:TextBox CssClass="form-control" ID="TextSearch" runat="server" AutoPostBack="true"></asp:TextBox>
                    </div>
                </div>
                <div class="hidden-lg hidden-md hidden-sm">&nbsp;</div>
                <div class="col-sm-3"></div>


            </div>
        </div>
        <div class="container-fluid">
            <div class="row justify-content-center pt-5">

                <div class="col-sm-4">

                    <div class="card">

                        <div class="card-body" style="min-height: 300px; max-height: 700px; overflow: auto">

                            <div class="container-fluid">



                                <%foreach (Dominio.Factura item in facturas)
                                    { %>



                                <div class="d-flex bd-highlight mb-3 card-header pt-2">

                                    <div class="mr-auto p-2 bd-highlight">

                                        <p><%="Factura: "+ item.codigo %></p>
                                        <p><%="Cliente: "+ item.ApellidoNombre %></p>
                                        <p><%=item.fecha %></p>
                                        <p><%="Monto: $"+ item.monto %></p>

                                    </div>
                                    <div class="p-2 bd-highlight align-self-center">

                                        <a href="VerFacturaAdmin.aspx?fac=<%=item.codigo %>" class="btn btn-secondary">Detalles</a>
                                    </div>
                                </div>



                                <%} %>
                            </div>
                        </div>



                    </div>

                </div>

            </div>

        </div>






    </form>
</body>
</html>
