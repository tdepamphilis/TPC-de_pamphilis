﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="Frontend.Categorias" %>

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
        <div class="container" style="border: solid">
            <div class="form-row" style="text-align: center">
                <div class="col-sm-3"></div>
                <div class="form-group col-sm-6">
                    <h1>categorias</h1>
                </div>
                <div class="col-sm-3"></div>
            </div>
            <div class=" form-row">
                <div class="col-sm-4"></div>
                <div class="col-sm-3">
                    <asp:TextBox ID="TextSearch" runat="server" CssClass="form-control" placeholder="Buscar"></asp:TextBox>

                </div>
                <div class="col-sm-1">
                    <a href="NewBC.aspx?type=cat">Nueva</a>
                </div>
                <div class="col-sm-4"></div>
            </div>
            <%if (action == 1)
                { %>
            <div class="form-row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4" style="text-align: center">
                    <h4><%=selected.name %></h4>
                </div>
                <div class="col-sm-4"></div>
            </div>
            <div class="form-row">
                <div class="col-sm-4"></div>
                <div class="col-sm-3">
                    <asp:TextBox ID="TextRename" runat="server" placeholder="Nuevo nombre" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <asp:Button ID="Confirmar" runat="server" Text="Button" OnClick="Confirmar_Click" />
                </div>
                <div class="col-sm-4"></div>
            </div>
            <%}
                else if (action == 2)
                {%>
           
                <div class="form-row">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4" style="text-align: center">
                        <h4><%="Está seguro que desea eliminar " + selected.name %></h4>
                    </div>
                    <div class="col-sm-4"></div>
                </div>
            <div class="form-row">
                <div class="col-sm-5"></div>
                <div class="col-sm-1">
                    <a href="Categorias.aspx">Cancelar</a>
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="Borrar" runat="server" Text="Borrar" OnClick="Borrar_Click" />
                </div>
                <div class="col-sm-5"></div>
            </div>
            


            <%} %>
            <div class="row row-cols-2 row-cols-md-5">

                <%foreach (Dominio.Categoria cat in categorias)
                    { %>
                <div class="card" style="width: 18rem;">
                    <div class="card-header" style="text-align: center">
                        <%=cat.name %>
                    </div>
                    <ul class="list-group list-group-flush" style="text-align: center">
                        <li class="list-group-item">
                            <a href="Categorias.aspx?rnm=<%=cat.id %>">Renombrar</a>
                            <a href="Categorias.aspx?del=<%=cat.id %>">Eliminar</a>
                        </li>
                    </ul>
                </div>

                <%} %>
            </div>
        </div>
    </form>
</body>
</html>