<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tienda.aspx.cs" Inherits="Frontend.Tienda" %>

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
                    <a href="Tienda.aspx">
                    <img src="https://darodistribuidora.com/wp-content/uploads/logodarodist.png" style="width: 170px; height: 80px" alt="Alternate Text" />
                    </a>                
                </div>
                <div class="col-sm-4" style="position: relative; top: 27px; text-align: center;">
                    <div class="dropdown show">
                        <a href="#" class="btn btn-dark btn-sm">Perfil</a>
                        <a href="#" class="btn btn-dark btn-sm">Mis pedidos</a>
                        <a href="MainPage.aspx" class="btn btn-dark btn-sm">Salir</a>
                        <a href="#" class="btn btn-dark btn-sm">Carrito<%=" (" + carrito.items.Count + ")" %></a>
                    </div>
                </div>
                <div class="col-sm-4" style="position: relative; top: 27px;">
                    <div class="input-group">
                        <div class="input-group-prepend">
                            <button class="btn btn-light dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Categorias</button>
                            <div class="dropdown-menu">
                                <a class="dropdown-item" href="tienda.aspx">Todos</a>
                                <%foreach (Dominio.Categoria item in categorias)
                                    { %>
                                <div><a class="dropdown-item" href="?cat=<%= item.id %>"><%=item.name %></a></div>
                                <%}  %>
                            </div>
                        </div>
                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-3"></div>
            </div>
        </div>

        <div class="container">
            <div class="row">
                <div class="col-sm"><a href="TiendaAdmin.aspx">Admin</a> </div>
                <div class="col-sm">
                </div>
                <div class="col-sm"></div>
            </div>

            <div class="row row-cols-1 row-cols-md-5">

                <% foreach (Dominio.Producto product in productos)

                    {
                %>

                <div class="col mb-4">
                    <div class="card">
                        <a href="VerProducto.aspx?prod=<%=product.code %>">
                            <img src="<% = product.urlimagen %>" class="card-img-top" alt="..." height="130" width="40" >
                        </a>
                        <div class="card-body" style="height: 150px">
                            <h5 class="card-title" style="display: flex"><% = product.name %></h5>
                            <p class="card-subtitle">$<% =product.unitPrice() %> </p>
                            <p class="card-text" style="font-size: smaller"><% =product.desc %></p>
                        </div>
                        <div class="card-footer text-center">
                            <%if (product.stock.ammount > 0)
                                { %>
                            <a class="btn btn-dark" href="<%="?ART=" + product.code %> ">Agregar a carrito</a>
                            <%}
                                else
                                { %>

                            <p style="color: red">Sin stock</p>
                            <%} %>
                        </div>
                    </div>
                </div>
                <%} %>
            </div>





        </div>

    </form>
</body>
</html>
