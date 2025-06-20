<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="IntentoEntrega.aspx.cs" Inherits="EnviosExpress.IntentoEntrega" %>
<%@ Register Src="~/DynamicData/FieldTemplates/CuwScannerCode.ascx" TagPrefix="uc2" TagName="CuwScannerCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <uc2:CuwScannerCode runat="server" ID="CuwScannerCode" />

    <div class="container text-center" style="background-color:#2d2d30; min-height:100vh; width:100%;">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Intento de Entrega" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
        <br /><br />

        <div class="container" style="background-color:#f5f5f5; border-radius:8px; padding:30px; max-width:700px; margin:auto;">

            <!-- Botón escanear -->
            <div class="mb-4">
                <button type="button" class="btn btn-info" onclick="AbrirModalScanner('intento')">
                    📦 Escanear códigos
                </button>
            </div>

            <!-- Número de guía y botón reportar al lado -->
            <div class="form-group d-flex justify-content-center align-items-center mb-4" style="flex-wrap: wrap;">
                <label for="txtcodigoo" class="mr-2 font-weight-bold">Número de Guía:</label>
                <asp:TextBox ID="txtcodigoo" runat="server" CssClass="form-control mr-2" Width="200px"></asp:TextBox>
                <asp:Button ID="btnrecolectar" runat="server" OnClick="btnrecolectar_Click" Text="Reportar" CssClass="btn btn-success" />
            </div>

            <!-- Checkbox y dropdown de motivo -->
            <div class="mb-3">
                <asp:CheckBox ID="CheckBox3" Text="Se visitó al Destinatario" runat="server" />
            </div>

            <div class="mb-3">
    <label class="font-weight-bold">Detallar Intento de Entrega Fallido:</label><br />
    <div class="d-flex justify-content-center">
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="250px">
            <asp:ListItem Value="--Seleccionar">--Seleccionar</asp:ListItem>
            <asp:ListItem Value="No Quizo Recibir">No Quizo Recibir</asp:ListItem>
            <asp:ListItem Value="No Contesta LLamadas">No Contesta LLamadas</asp:ListItem>
            <asp:ListItem>No Llego a Punto de Encuentro</asp:ListItem>
            <asp:ListItem>No esta de Acuerdo Con el Precio</asp:ListItem>
            <asp:ListItem>No Recibe Fines de Semana</asp:ListItem>
            <asp:ListItem>Ya No Lo Desea</asp:ListItem>
            <asp:ListItem>Nadie En Casa</asp:ListItem>
            <asp:ListItem>Direccion Incorrecta</asp:ListItem>
            <asp:ListItem>Lugar Muy Retirado</asp:ListItem>
            <asp:ListItem>Desperfectos Mecanicos</asp:ListItem>
            <asp:ListItem>Bloqueos, Derrumbes, Manifestaciones</asp:ListItem>
        </asp:DropDownList>
    </div>
</div>


            <asp:Label ID="Label11" runat="server" CssClass="text-danger"></asp:Label>

        </div>

        <!-- Botón regresar -->
        <div class="mt-4">
            <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" CssClass="btn btn-danger" />
        </div>

        
    </div>
</asp:Content>
