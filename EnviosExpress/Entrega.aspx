﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Entrega.aspx.cs" Inherits="EnviosExpress.Entrega" %>
<%@ Register Src="~/DynamicData/FieldTemplates/CuwScannerCode.ascx" TagPrefix="uc2" TagName="CuwScannerCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link rel="stylesheet" href="fontawesome/css/font-awesome.min.css" />
    <script src="bootstrap/js/popper.min.js"></script>

    <script src="js/jquery-3.3.1.min.js"></script>
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>

    <link href="css/Central.css" rel="stylesheet" />
    <style>
        .bgTituloDocumento {
            -webkit-box-shadow: inset 0px 0px 22px 1px rgba(0,0,0,0.45);
            -moz-box-shadow: inset 0px 0px 22px 1px rgba(0,0,0,0.45);
            box-shadow: inset 0px 0px 22px 1px rgba(0,0,0,0.45);
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="container text-center" style="background-color:#2d2d30; min-height:100vh; width:100%;">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Entrega" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
        <br /><br />

        <div class="container" style="background-color:#f5f5f5; border-radius:8px; padding:30px; max-width:700px; margin:auto;">

            <!-- Botón escanear -->
            <div class="mb-4">
                <button type="button" id="lkbScanner" class="btn btn-info" onclick="AbrirModalScanner('entregar'); return false;">
                    <i class="fa fa-barcode" aria-hidden="true"></i> Escanear paquetes para entrega
                </button>
            </div>

            <uc2:CuwScannerCode runat="server" ID="CuwScannerCode" />
            <asp:Button ID="Button2" runat="server" Text="Button" CssClass="Ocultar" />

            <!-- Número de guía -->
            <div class="form-group d-flex justify-content-center align-items-center mb-4" style="flex-wrap: wrap;">
                <label for="txtcodigoo" class="mr-2 font-weight-bold">Número de Guía:</label>
                <asp:TextBox ID="txtcodigoo" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
            </div>

            <!-- Recibido por + botón entregar -->
            <div class="form-group d-flex justify-content-center align-items-center mb-4" style="flex-wrap: wrap;">
                <label for="txtrecibido" class="mr-2 font-weight-bold">Recibido por:</label>
                <asp:TextBox ID="txtrecibido" runat="server" CssClass="form-control mr-2" Width="200px"></asp:TextBox>
                <asp:Button ID="btnrecolectar" runat="server" OnClick="btnrecolectar_Click" Text="Entregar" CssClass="btn btn-success" />
            </div>

            <!-- Error -->
            <asp:Label ID="Label11" runat="server" CssClass="text-danger"></asp:Label>
        </div>

        <!-- Botón regresar -->
        <div class="mt-4">
            <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" CssClass="btn btn-danger" />
        </div>

        <br />
    </div>
</asp:Content>
