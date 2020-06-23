<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerProducto.aspx.cs" Inherits="Frontend.VerProducto" %>

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
                        <a href="Perfil.aspx" class="btn btn-dark btn-sm">Perfil</a>
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
                                <div><a class="dropdown-item" href="Tienda.aspx?cat=<%= item.id %>"><%=item.name %></a></div>
                                <%} %>
                            </div>
                        </div>
                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-3"></div>
            </div>
        </div>
        <div class="container">
            <div class="row pt-5">
                <div class="col-sm-5">
                    <img src="<% = producto.urlimagen %>" class="card-img-top" alt="..." height="370" width="250" style="border: solid">
                </div>
                <div class="col-sm-7 card">

                    <div class="row card-header">
                        <div class="col">
                            <h1 style="text-align: center;"><%=producto.name %></h1>
                        </div>
                    </div>
                    <div class="row card-body" style="text-align: center">
                        <div class="col">
                            <h4><%= producto.desc %></h4>
                            <div>&nbsp;</div>
                            <div>&nbsp;</div>
                            <div>&nbsp;</div>
                            <p><%="Precio unitario: $"+ producto.unitPrice()%></p>
                        </div>
                    </div>



                    <div class="row card-footer justify-content-md-center" style="text-align: center;">
                        <%if (producto.stock.ammount > 0)
                            { %>
                        <div class="container-fluid">


                            <div class="row justify-content-center">
                                <div class="col-5">
                                    <div class="input-group input-group-sm">
                                        <div class="input-group-append">
                                            <asp:Button ID="ButtonUpTen" runat="server" Text="+10" CssClass="btn btn-dark btn-sm" OnClick="ButtonUpTen_Click" />
                                            <asp:Button ID="Buttonup" runat="server" Text="+1" CssClass="btn btn-dark btn-sm" OnClick="Buttonup_Click" />
                                        </div>
                                        <asp:TextBox ID="TextCuantity" runat="server" CssClass="form-control col-sm"></asp:TextBox>
                                        <div class="input-group-prepend">
                                            <asp:Button ID="ButtonDown" runat="server" Text="-1" CssClass=" btn btn-dark btn-sm" OnClick="ButtonDown_Click" />
                                            <asp:Button ID="ButtonDownTen" runat="server" Text="-10" CssClass="btn btn-dark btn-sm" OnClick="ButtonDownTen_Click" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="row justify-content-md-center">

                                <div class="col-sm-5" style="text-align: center">
                                    <div>&nbsp;</div>
                                    <asp:Button ID="ButtonAddChart" runat="server" Text="Agregar al carrito" CssClass="btn btn-secondary " Style="position: relative; bottom: 10px" />
                                </div>

                            </div>
                        </div>
                        <%}
                        else
                        { %>
                        <p style="color: red">Sin stock</p>
                        <%} %>
                    </div>





                </div>
            </div>

        </div>
    </form>
</body>
</html>
