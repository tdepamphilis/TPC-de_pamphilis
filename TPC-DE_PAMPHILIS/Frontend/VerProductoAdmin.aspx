<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerProductoAdmin.aspx.cs" Inherits="Frontend.VerProductoAdmin" %>

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
<body style="background-color: #e8e4e1">
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
                    <div class="input-group mb-4">
                        <div class="input-group-prepend">
                            <button class="btn btn-outline-secondary dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="background-color: white">Categorias</button>
                            <div class="dropdown-menu">
                                <a class="dropdown-item" href="tiendaAdmin.aspx">Todos</a>
                                <%foreach (Dominio.Categoria item in categorias)
                                    { %>
                                <div><a class="dropdown-item" href="?cat=<%= item.id %>"><%=item.name %></a></div>
                                <%} %>
                            </div>
                        </div>
                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" ></asp:TextBox>
                    </div>
                </div>
                <div class="hidden-lg hidden-md hidden-sm">&nbsp;</div>
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
                    <div class="card-body">
                        <div class="row" style="text-align: center">
                            <div class="col">
                                
                                <h4><%= producto.desc %></h4>
                            </div>
                        </div>
                        <div class="row">
                            <div>&nbsp</div>
                            <div class="col-6">
                                <div>&nbsp;</div>
                                <p>-Stock actual:<%=" "+ producto.stock.ammount %></p>
                                <p>-Ultimo precio de repsicion: <%=" $"+ (float)producto.stock.price %></p>
                                <p>-Precio de venta <%=" $"+ producto.unitPrice().ToString() %></p>
                               

                            </div>
                        </div>
                    </div>
                    <div class="card-footer">
                        <div class="row justify-content-center">


                            <p>
                                <a class="btn btn-primary btn-sm " data-toggle="collapse" href="#stock" role="button" aria-expanded="false" aria-controls="collapseExample">Agregar stock  </a>
                                <a href="<%="NuevoProducto.aspx?mod=" + producto.code %> " class="btn btn-primary btn-sm">Modificar</a>
                                <a class="btn btn-primary btn-sm" data-toggle="collapse" href="#del" role="button" aria-expanded="false" aria-controls="collapseExample">Eliminar</a>
                            </p>
                        </div>
                        <div class="collapse" id="stock">
                            <div class="card card-body">
                                <div class="form-row">
                                    <div class="col-sm-3"></div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="TextAmmount" runat="server" CssClass="form-control" placeholder="Cantidad" type="number" min="1"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <div class="input-group-text">$</div>
                                            </div>
                                            <asp:TextBox ID="TextPrice" runat="server" CssClass="form-control" type="number" min="1"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="col-sm-3"></div>

                                </div>
                                <div class="form-row mt-3 ">
                                    <div class="col-sm-4"></div>
                                    <div class="col-sm-4">
                                        <asp:Button ID="ButtonStock" runat="server" Text="Agregar" OnClick="ButtonStock_Click" CssClass="btn btn-light" />
                                    </div>
                                    <div class="col-sm-4"></div>
                                </div>
                            </div>
                        </div>
                        <div class="collapse" id="del">
                            <div class=" card card-body">
                                <div class="row justify-content-center">
                                    <h6>Seguro?</h6>

                                </div>
                                <div class="row justify-content-center">

                                    <asp:Button ID="ButtonDel" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" OnClick="ButtonDel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
      
            
        </div>
    </form>
</body>
</html>
