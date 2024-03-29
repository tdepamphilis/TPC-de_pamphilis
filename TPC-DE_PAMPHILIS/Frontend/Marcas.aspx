﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="Frontend.Marcas" %>

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
        <div class="container-fluid">
            <div class="row" style="background-color: dimgrey">
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
                        <a href="TiendaAdmin.aspx" class="btn btn-dark btn-sm" style="text-align: left">Productos</a>
                        <a href="GestionStock.aspx" class="btn btn-dark btn-sm">Stock</a>
                        <a href="Categorias.aspx" class="btn btn-dark btn-sm">categorias</a>
                        <a href="GestionPendientes.aspx" class="btn btn-dark btn-sm"><%="Facturacion (" + facturaBusiness.contarPendientes() + ")" %></a>
                        <a href="MainPage.aspx" class="btn btn-dark btn-sm">Salir</a>
                    </div>
                </div>
                <div class="hidden-lg hidden-md hidden-sm">&nbsp;</div>
                <div class="col-sm-3">
                    <asp:TextBox ID="TextSearch" runat="server" CssClass="form-control" placeholder="Buscar" Style="position: relative; top: 30%"></asp:TextBox>
                </div>
                <div class="col-sm-3"></div>
            </div>
            <div class="form-row" style="text-align: center">
                <div class="col-sm-3"></div>
                <div class="form-group col-sm-6">
                    <h1>Marcas</h1>
                </div>
                <div class="col-sm-3"></div>
            </div>
            <%if (action == 1)
                { %>
            <div class="row justify-content-center">
                <div class="col-2">
                    <div class="card">
                        <div class="card-header justify-content-center">

                            <h3 style="text-align: center"><%=selected.name %></h3>

                        </div>
                        <div class="card-body justify-content-center">
                            <div class="row">
                                <asp:TextBox ID="TextRename" runat="server" placeholder="Nuevo nombre" CssClass="form-control pt-3"></asp:TextBox>

                            </div>
                            <div class="row justify-content-center pt-3">
                                <asp:Button ID="Confirmar" runat="server" Text="Confirmar" OnClick="Confirmar_Click" class="btn btn-light align-content-center" />

                            </div>

                        </div>

                    </div>
                </div>
            </div>
            <%}
                else if (action == 2)
                { %>

            <div class="row justify-content-center">
                <div class="col-3">

                    <div class="card">
                        <div class="card-header justify-content-center">

                            <h6 style="text-align:justify"><%="Está seguro que desea eliminar " + selected.name + "? Sus productos seguiran existiendo hasta que se eliminen." %></h6>
                        </div>

                   
                    <div class="card-body align-items-center" style="text-align:center">

                        <a href="Marcas.aspx" class="btn btn-primary btn-sm" style="text-align:center">Cancelar</a>

                        <asp:Button ID="Borrar" runat="server" Text="Borrar" OnClick="Borrar_Click" class="btn btn-danger btn-sm"/>

                    </div>

                     </div>

                </div>


            </div>

        </div>




        <%} %>
        <div class="row row-cols-2 row-cols-md-6 pt-3">

            <%foreach (Dominio.Marca marca in marcas)
                { %>
            <div class="col-md-2">

                <div class="card" style="width: 18rem;">
                    <div class="card-header" style="text-align: center">
                        <%=marca.name %>
                    </div>
                    <ul class="list-group list-group-flush" style="text-align: center">
                        <li class="list-group-item">
                            <a href="Marcas?rnm=<%=marca.id %>">Renombrar</a>
                            <a href="Marcas?del=<%=marca.id %>">Eliminar</a>
                        </li>
                    </ul>
                </div>
            </div>


            <%} %>
        </div>
        </div>
    </form>
</body>
</html>
