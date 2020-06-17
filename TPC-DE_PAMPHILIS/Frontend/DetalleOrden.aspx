<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleOrden.aspx.cs" Inherits="Frontend.DetalleOrden" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">

            <div class="form-row">
                <div class="col-sm"></div>
                <div class="col-sm-9">
                    <div class="container" style="border:solid">
                        <%foreach (Dominio.ItemCarrito item in carrito.items)
                            { %>
                        <div class="row">
                            <div class="col-sm-2"></div>
                            <div class="col-sm-5" style="border:solid; border-width:thin">
                                <p> <%= item.name + " X " + item.ammount + " Precio parcial $" + item.partialPrice() %></p>
                            </div>
                            <div class="col-sm-3" style="border:solid; border-width:thin">
                                <a href="?add=<%=item.code %>">+1</a>
                                <a href="?take=<%=item.code %>">-1</a>
                                <a href="?del=<%=item.code %>">Quitar todo</a>
                            </div>
                            <div class="col-sm-2"></div>

                        </div>

                        <%} %>
                    </div>

                </div>
                <div class="col-sm"></div>

            </div>
        </div>
    </form>
</body>
</html>
