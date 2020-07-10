<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerFacturaAdmin.aspx.cs" Inherits="Frontend.VerFacturaAdmin" %>

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
                        <a href="GestionPendientes.aspx" class="btn btn-dark btn-sm"><%="Facturacion (" + facturaBusiness.contarPendientes() + ")" %></a>
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
            <div class="row justify-content-center pt-6">

                <div class="col-4 pt-4">

                    <div class="card">

                        <div class="card-header">

                            <h6><%="Codigo: "+ factura.codigo %> </h6>
                            <h6><%="Usuario:" + factura.ApellidoNombre %></h6>
                            <h6><%="Direccion: " + factura.dir %></h6>
                            <h6><%="fecha: "+ factura.fecha %></h6>

                        </div>
                        <div class="card-body" style="min-height: 300px; max-height: 350px; overflow: auto">
                            <%foreach (Dominio.ItemCarrito item in factura.items)
                                { %>
                            <div class="d-flex bd-highlight mb-3 card-header pt-2" style="border: thin">
                                <div class="mr-auto p-2 bd-highlight">
                                    <p><%=item.name + " x " + item.ammount.ToString() %></p>
                                    <p><%= "Subtotal: $" + item.partialPrice() %></p>
                                </div>
                                <div class="p-2 bd-highlight ">
                                    <p><%="Precio unitario: $" + item.unitPrice.ToString() %> </p>
                                </div>
                            </div>
                            <%} %>
                        </div>
                        <div class="card-footer">
                             <div class="row justify-content-center">                                
                                 <asp:Button ID="ButtonDown" runat="server" Text="Anular" CssClass="btn btn-secondary mx-2" OnClick="ButtonDown_Click" />  
                                <asp:Button ID="ButtonUp" runat="server" Text="Volver" CssClass="btn btn-secondary mx-2" OnClick="ButtonUp_Click" />                                                          
                            </div>
                            <div class="row justify-content-center mt-1">                         
                                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" CssClass="btn btn-secondary mx-2" OnClick="ButtonVolver_Click" />                                                                                 
                                <asp:Button ID="Buttondel" runat="server" Text="Anular" CssClass="btn btn-danger mx-2" OnClick="Buttondel_Click" />                               
                            </div>
                        </div>

                    </div>
                </div>

            </div>

        </div>



    </form>
</body>
</html>
