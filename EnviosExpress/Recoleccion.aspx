<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Recoleccion.aspx.cs" Inherits="EnviosExpress.Recoleccion" %>
<%@ Register Src="~/DynamicData/FieldTemplates/CuwScannerCode.ascx" TagPrefix="uc1" TagName="ScannerControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        #ModalScannerCode.modal {
            z-index: 1055;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <!-- Escáner QR -->
    <uc1:ScannerControl ID="ScannerControl1" runat="server" />

    <div class="container text-center" style="background-color:#2d2d30; min-height:100vh; width:100%;">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Recolección" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
        <br /><br />

        <div class="container" style="background-color:#f5f5f5; border-radius:8px; padding:30px; max-width:700px; margin:auto;">

            <!-- Botón escanear -->
            <div class="mb-4">
                <asp:Button ID="btnAbrirScanner" runat="server" Text="📷 Escanear códigos de paquetes" CssClass="btn btn-primary" OnClientClick="AbrirModalScanner(); return false;" />
                <small class="d-block mt-2 text-muted">Nota: Al escanear los códigos de los paquetes, puede ponerlos en ruta directamente.</small>
            </div>

            <!-- Número de guía y botón recolectar -->
            <div class="form-group d-flex justify-content-center align-items-center mb-4" style="flex-wrap: wrap;">
                <label for="txtcodigoo" class="mr-2 font-weight-bold">Número de Guía:</label>
                <asp:TextBox ID="txtcodigoo" runat="server" CssClass="form-control mr-2" Width="200px" />
                <asp:Button ID="Button2" runat="server" OnClick="btnrecolectar_Click" Text="Recolectar" CssClass="btn btn-success" />
            </div>

            <!-- Checkbox para marcar en ruta -->
            <div class="mb-3">
                <asp:CheckBox ID="CheckBox3" Text="Marcar paquete en Ruta" runat="server" />
            </div>

            <!-- Mensaje de error -->
            <asp:Label ID="Label11" runat="server" CssClass="text-danger" />
        </div>

        <!-- Botón regresar -->
        <div class="mt-4">
            <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" CssClass="btn btn-danger" />
        </div>

        <br />
    </div>
</asp:Content>
