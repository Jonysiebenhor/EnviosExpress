<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Devolucion.aspx.cs" Inherits="EnviosExpress.Devolucion" %>
<%@ Register Src="~/DynamicData/FieldTemplates/CuwScannerCode.ascx" TagPrefix="uc" TagName="CuwScannerCode" %>



<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <uc:CuwScannerCode runat="server" ID="CuwScannerCode" />

    <div class="container text-center" style="background-color:#2d2d30; min-height:100vh; width:100%;">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Devolución" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
        <br /><br />

        <div class="container" style="background-color:#f5f5f5; border-radius:8px; padding:30px; max-width:700px; margin:auto;">

            <!-- Botón escanear -->
            <div class="mb-4">
                <button type="button" class="btn btn-info" onclick="AbrirModalScanner('devolucion'); return false;">
                    <i class="fa fa-barcode"></i> Escanear
                </button>
            </div>

            <!-- Número de guía -->
            <div class="form-group d-flex justify-content-center align-items-center mb-4" style="flex-wrap: wrap;">
                <label for="txtcodigoo" class="mr-2 font-weight-bold">Número de Guía:</label>
                <asp:TextBox ID="txtcodigoo" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
            </div>

            <!-- Motivo de devolución centrado -->
            <div class="mb-3">
                <label class="font-weight-bold">Motivo de Devolución:</label><br />
                <div class="d-flex justify-content-center">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Value="--Seleccionar">--Seleccionar</asp:ListItem>
                        <asp:ListItem>Entregado</asp:ListItem>
                        <asp:ListItem>No Quizo Recibir</asp:ListItem>
                        <asp:ListItem>Remitente lo Solicito</asp:ListItem>
                        <asp:ListItem>No Contesta LLamadas</asp:ListItem>
                        <asp:ListItem>No Llego a Punto de Encuentro</asp:ListItem>
                        <asp:ListItem>No esta de Acuerdo Con el Precio</asp:ListItem>
                        <asp:ListItem>No Recibe Fines de Semana</asp:ListItem>
                        <asp:ListItem>Ya No Lo Desea</asp:ListItem>
                        <asp:ListItem>Nadie En Casa</asp:ListItem>
                        <asp:ListItem>Dirección Incorrecta</asp:ListItem>
                        <asp:ListItem>Lugar Muy Retirado</asp:ListItem>
                        <asp:ListItem>Desperfectos Mecanicos</asp:ListItem>
                        <asp:ListItem>Bloqueos, Derrumbes, Manifestaciones</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Campo "Recibido por" -->
            <div class="form-group row justify-content-center align-items-center" id="grupoRecibido">
                <asp:Label ID="Label12" runat="server" Text="¿Quién recibió el paquete?" CssClass="col-auto col-form-label font-weight-bold" />
                <div class="col-auto">
                    <asp:TextBox ID="txtrecibido" runat="server" CssClass="form-control" Width="250px" />
                </div>
            </div>

            <!-- Mensaje de error -->
            <div class="form-group row justify-content-center">
                <asp:Label ID="Label11" runat="server" CssClass="text-danger" Font-Bold="true" />
            </div>

            <!-- Botones -->
            <div class="text-center mt-4">
                <asp:Button ID="btnrecolectar" runat="server" OnClick="btnrecolectar_Click" Text="Registrar Devolución" BackColor="#339933" ForeColor="White" CssClass="btn btn-success mr-2" />
                <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" CssClass="btn btn-danger" />
            </div>
        </div>
        <br />
    </div>
</asp:Content>
