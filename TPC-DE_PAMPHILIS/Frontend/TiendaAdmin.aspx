﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TiendaAdmin.aspx.cs" Inherits="Frontend.TiendaAdmin" %>

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
<body>
    <form id="form1" runat="server">


        <div class="container-fluid">
            <div class="row">
                <div class="col-sm"></div>
                <div class="col-sm">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <button class="btn btn-outline-secondary dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Categorias</button>
                            <div class="dropdown-menu">
                                <a class="dropdown-item" href="tiendaAdmin.aspx">Todos</a>
                                <%foreach (Dominio.Categoria item in categorias)
                                    { %>
                                <div><a class="dropdown-item" href="?cat=<%= item.id %>"><%=item.name %></a></div>
                                <%} %>
                            </div>
                        </div>
                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm"></div>
            </div>
            <div class="row">
                <div class="col-sm">
                    <div class="container-fluid" style="background-color:lightslategrey">                     
                        <div class="form-row">
                            <div class="form-group col-sm" style="text-align:center">
                                <a href="#" class="btn btn-dark btn-sm">Nuevo producto</a>

                            </div>
                        </div>
                        <div class="form-row" style="text-align:center">
                            <div class="form-group col-sm">
                                <a href="#" class="btn btn-dark btn-sm">Marcas</a>

                            </div>
                        </div>
                        <div class="form-row" style="text-align:center">
                            <div class="form-group col-sm">
                                <a href="#" class="btn btn-dark btn-sm">categorias</a>

                            </div>
                        </div>
                        <div class="form-row" style="text-align:center">
                            <div class="form-group col-sm">
                                <a href="#" class="btn btn-dark btn-sm">Estadisticas</a>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-9" style="border: solid">
                    <div class="container-fluid">

                        <div class="row row-cols-1 row-cols-md-5">

                            <% foreach (Dominio.Producto product in productos)

                                {
                            %>

                            <div class="col sm-4">
                                <div class="card">
                                    <img src="<% = product.urlimagen %>" class="card-img-top" alt="..." height="200" width="80">
                                    <div class="card-body" style="height: 150px">
                                        <h5 class="card-title" style="display: flex"><% = product.name %></h5>
                                        <p class="card-subtitle">$<% =product.margin %> </p>
                                        <p class="card-text" style="font-size: smaller"><% =product.desc %></p>
                                    </div>
                                    <div class="card-footer text-center">

                                        <a class="btn btn-danger btn-sm" href="<%="?ART="+product.code %> ">X</a>
                                        <a class="btn btn-dark btn-sm" href="<%="?ART="+product.code %> ">Editar</a>
                                        <a class="btn btn-dark btn-sm" href="<%="?ART="+product.code %> ">Agregar stock</a>
                                    </div>
                                </div>
                            </div>
                            <%} %>
                        </div>
                    </div>


                </div>
                <div class="col-sm"></div>


            </div>

        </div>


    </form>
</body>
</html>
