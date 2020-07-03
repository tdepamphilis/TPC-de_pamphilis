<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerFactura.aspx.cs" Inherits="Frontend.VerFactura" %>

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
                        <a href="MisPedidos.aspx" class="btn btn-dark btn-sm">Mis pedidos</a>
                        <a href="MainPage.aspx" class="btn btn-dark btn-sm">Salir</a>
                        <a href="MiCarrito.aspx" class="btn btn-dark btn-sm">Carrito<%=" (" + carrito.items.Count + ")" %></a>
                    </div>
                </div>
                <div class="col-sm-4" style="position: relative; top: 27px;"></div>
                <div class="col-sm-3"></div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row justify-content-center pt-6">

                <div class="col-4">

                    <div class="card">

                        <div class="card-header">

                            <h6><%="Codigo: "+ factura.codigo %> </h6>


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
                    </div>



                    <div class="card-footer">
                        <div class="row justify-content-center">
                            <asp:Button ID="ButtonVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="ButtonVolver_Click" />
                        </div>

                    </div>
                </div>

            </div>

        </div>




    </form>
</body>
</html>
