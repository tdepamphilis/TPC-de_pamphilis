﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewBC.aspx.cs" Inherits="Frontend.NewBC" %>

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
        <div class="container">
            <div class="form-row"> 
                <div class="col-sm-4"></div>
                <div class="col-sm-4" style="text-align:center">
                    <h4>Nueva <%= title%> </h4>
                </div>
                <div class="col-sm-4"></div>
            </div>
            <div class="form-row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                </div>
                <div class="col-sm-4"></div>
            </div>
            <div class="form-row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4" style="text-align:center">
                    <asp:Button ID="Confirm" runat="server" Text="Confirmar" OnClick="Confirm_Click" />
                </div>
                <div class="col-sm-4"></div>
            </div>
        </div>
    </form>
</body>
</html>