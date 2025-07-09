<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="MenuAdministrador.aspx.cs" Inherits="EnviosExpress.MenuAdministrador" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">


        <div class="container text-center" style="background-color:#2d2d30; height: 577px; width:100%;">
             <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Menu Administrador" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
           <div class="container text-center""row" style="background-color:#f5f5f5; ">
<div class="container text-center">
    <div class="container text-center">
        
     
        <br />
        <asp:Button ID="crearcuenta" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Outset" Font-Bold="False" Font-Size="Large" Height="50px" OnClick="crearcuenta_Click" Text="Crear una Cuenta" Width="250px" />
        <br />
        <br />
        <asp:Button ID="editarcuenta" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Outset" Font-Bold="False" Font-Size="Large" Height="50px" OnClick="editarcuenta_Click" Text="Editar una Cuenta" Width="250px" />
        <br />
        <br />
        <asp:Button ID="Consultarguia1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Outset" Font-Bold="False" Font-Size="Large" Height="50px" OnClick="Consultarguia1_Click" Text="Consultar Guías" Width="250px" />
        <br />
        <br />
        <asp:Button ID="Solicitudes" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Outset" Font-Bold="False" Font-Size="Large" Height="50px" OnClick="Solicitudes_Click" Text="Solicitudes" Width="250px" />
        <br />
        <br />
        <asp:Button ID="PagosAdmin" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Outset" Font-Bold="False" Font-Size="Large" Height="50px" OnClick="PagosAdmin_Click" Text="Pagos" Width="250px" />
        <br />
        
    </div>
   </div>
        <br/><br/> </div></div>
</asp:Content>
