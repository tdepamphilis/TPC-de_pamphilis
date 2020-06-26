<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Frontend.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Checkout</title>
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
                        <a href="#" class="btn btn-dark btn-sm">Mis pedidos</a>
                        <a href="MainPage.aspx" class="btn btn-dark btn-sm">Salir</a>
                        <a href="#" class="btn btn-dark btn-sm">Carrito<%=" (" + carrito.items.Count + ")" %></a>
                    </div>
                </div>
                <div class="col-sm-4" style="position: relative; top: 27px;"></div>
                <div class="col-sm-3"></div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row justify-content-center pt-5">
                <div class="col-4">

                    <div class="card text-center">

                        <div class="card-header">
                            <h3 class="card-title">Checkout</h3>
                        </div>
                        <div class="card-body">

                            <div class="container-fluid">
                                <div class="row pt-1 ">
                                    <div class="col-sm-5 align-self-center  ">
                                        <h5 class="card-text align-self-center"><%="monto final :$" + carrito.totalPrice().ToString() %>   </h5>
                                    </div>
                                    <div class="col-sm-2"></div>
                                    <div class="col-sm-5 ">
                                        <asp:Label ID="Label1" runat="server" Text="Metodo de pago" CssClass="text-left"></asp:Label>
                                        <asp:DropDownList ID="DropDownMetodo" runat="server" CssClass="custom-select" AutoPostBack="true"></asp:DropDownList>

                                    </div>



                                </div>
                                <div class="row pt-2 justify-content-center">
                                </div>
                               
                                <%if (DropDownMetodo.SelectedValue == "1")
                                    { %>
                                
                                <div class="dropdown-divider pt-3"></div>
                                <div class="row">
                                    <div class="col-sm-6 ">
                                        <div class="form-group">

                                            <asp:Label ID="Label2" runat="server" Text="Numero de tarjeta"></asp:Label>
                                            <input id="TextCard" type="text" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="col-sm-2"></div>
                                    <div class="col-sm-3 px-2">
                                        <asp:Label ID="LabelExp" runat="server" Text="Vencimiento"></asp:Label>
                                        <asp:TextBox ID="TextExpiration" runat="server" CssClass="form-control" placeholder="MM/AA"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1"></div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <asp:Label ID="LabelName" runat="server" Text="Nombre y apellido"></asp:Label>
                                        <asp:TextBox ID="TextName" runat="server" Class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1"></div>
                                    <div class="col-sm-5">
                                        <asp:Label ID="LabelDNI" runat="server" Text="DNI" ></asp:Label>
                                        <asp:TextBox ID="TextBoxDNI" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>                                    
                                </div>
                                <div class="row justify-content-center">
                                    <div class="col-sm-10">
                                        <asp:Label ID="LabelFacDir" runat="server" Text="Direccion de Facturacion"></asp:Label>
                                        <asp:TextBox ID="TextFacDir" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <%} %>
                                <div class="dropdown-divider pt-3"></div>
                                <div class="row pt-1">
                                    <div class="col-sm-4">
                                         <asp:Label ID="LabelDelAdress" runat="server" Text="Direccion de entrega" CssClass="text-left"></asp:Label>
                                        <asp:DropDownList ID="DropDownListDelivery" runat="server" CssClass="custom-select" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-2"></div>
                                    <%if (DropDownListDelivery.SelectedValue == "2")
                                        { %>
                                    <div class="col-sm-6 align-self-end">
                                        <asp:TextBox ID="TextOtherAdress" runat="server" CssClass="form-control" placeholder="Direccion"></asp:TextBox>
                                    </div>
                                    <%} %>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer justify-content-center">
                            <asp:Button ID="Button1" runat="server" Text="Comprar" CssClass="btn btn-secondary" OnClick="Button1_Click" />

                        </div>
                    </div>

                </div>

            </div>

        </div>
    </form>
</body>
</html>
