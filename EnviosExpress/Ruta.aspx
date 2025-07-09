<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Ruta.aspx.cs" Inherits="EnviosExpress.Ruta" %>
<%@ Register Src="~/DynamicData/FieldTemplates/CuwScannerCode.ascx" TagPrefix="uc1" TagName="ScannerControl" %>



<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        #ModalScannerCode.modal {
            z-index: 1055;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <!-- Escáner reutilizable -->
    <uc1:ScannerControl ID="ScannerControl1" runat="server" />

    <div class="container text-center" style="background-color:#2d2d30; min-height:100vh; width:100%;">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Ruta" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
        <br /><br />

        <div class="container" style="background-color:#f5f5f5; border-radius:8px; padding:30px; max-width:700px; margin:auto;">

            <!-- Botón escanear -->
            <div class="mb-4">
                <asp:Button ID="btnAbrirScannerRuta" runat="server"
                    Text="🚚 Enrutar paquetes"
                    CssClass="btn btn-warning"
                    OnClientClick="AbrirModalScanner('enrutar'); return false;" />
            </div>

            <!-- Número de guía y botón "Enviar a ruta" -->
            <div class="form-group d-flex justify-content-center align-items-center mb-4" style="flex-wrap: wrap;">
                <label for="txtcodigoo" class="mr-2 font-weight-bold">Número de Guía:</label>
                <asp:TextBox ID="txtcodigoo" runat="server" CssClass="form-control mr-2" Width="200px"></asp:TextBox>
                <asp:Button ID="btnrecolectar" runat="server" OnClick="btnrecolectar_Click" Text="Enviar a ruta" CssClass="btn btn-success" />
            </div>

            <asp:Label ID="Label11" runat="server" CssClass="text-danger"></asp:Label>
        </div>

        <!-- Botón regresar -->
        <div class="mt-4">
            <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" CssClass="btn btn-danger" />
        </div>

        <br />
    </div>
</asp:Content>
