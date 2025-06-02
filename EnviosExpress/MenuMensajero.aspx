<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="MenuMensajero.aspx.cs" Inherits="EnviosExpress.MenuMensajero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
             <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Menu Mensajero" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
           <div class="container text-center""row" style="background-color:#f5f5f5; ">
<div class="container text-center">
    
    <br />
    
    <asp:Button ID="Consultarguia" runat="server" Text="Consultar Guías" OnClick="Consultarguia_Click" Height="50px" Width="250px" BackColor="White" Font-Bold="False" Font-Size="Large" BorderColor="#CCCCCC" BorderStyle="Outset" />
    <br />
    <br />
    <asp:Button ID="Solicitudes" runat="server" Text="Solicitudes" OnClick="Solicitudes_Click" Height="50px" Width="250px" BackColor="White" Font-Bold="False" Font-Size="Large" BorderColor="#CCCCCC" BorderStyle="Outset"  />
    <n />
    <br />
    <br />
    <asp:Button ID="recoleccion" runat="server" Text="Recolecciones" OnClick="recoleccion_Click" Height="50px" Width="250px" BackColor="White" Font-Bold="False" Font-Size="Large" BorderColor="#CCCCCC" BorderStyle="Outset" />
    <br />
    <br />
    <n />
    <asp:Button ID="ruta" runat="server" Text="Ruta" OnClick="ruta_Click" Height="50px" Width="250px" BackColor="White" Font-Bold="False" Font-Size="Large" BorderColor="#CCCCCC" BorderStyle="Outset" />
    <br />
    <br />
    <asp:Button ID="intento" runat="server" Text="Intento de Entrega" OnClick="intento_Click" Height="50px" Width="250px" BackColor="White" Font-Bold="False" Font-Size="Large" BorderColor="#CCCCCC" BorderStyle="Outset" />
    <br />
    <br />
    <asp:Button ID="entrega" runat="server" Text="Entrega" OnClick="entrega_Click" Height="50px" Width="250px" BackColor="White" Font-Bold="False" Font-Size="Large" BorderColor="#CCCCCC" BorderStyle="Outset" />
    <br />
    <br />
    <n />
    <asp:Button ID="devolucion" runat="server" Text="Devolución" OnClick="devolucion_Click" Height="50px" Width="250px" BackColor="White" Font-Bold="False" Font-Size="Large" BorderColor="#CCCCCC" BorderStyle="Outset" />
    <br />
    <br />
    <asp:Button ID="cierre" runat="server" Text="Cierre Diario" OnClick="cierre_Click" Height="50px" Width="250px" BackColor="White" Font-Bold="False" Font-Size="Large" BorderColor="#CCCCCC" BorderStyle="Outset" Enabled="True" />
    <br />
    <br />
    <n />

</div></div>
        <br/><br/></div>
    </asp:Content>
