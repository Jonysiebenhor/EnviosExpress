<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="EnviosExpress.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">


        <div class="container text-center" style="background-color:#2d2d30; height: 500px; width:100%;">
            <asp:Label ID="Label1" runat="server" Text="Menu" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
           <div class="container text-center""row" style="background-color:#f5f5f5; ">
<div class="container text-center">
    <div class="container text-center">
        <p><p>
    
    <asp:Button ID="Crearguia" runat="server" Text="Crear Guías" OnClick="Crearguia_Click" Height="50px" Width="250px" BackColor="White" Font-Bold="False" Font-Size="Large" BorderColor="#CCCCCC" BorderStyle="Outset" />
       <br />
        <br />
            <asp:Button ID="Crearguiamasiva" runat="server" Text="Crear Guías Masivas" OnClick="Crearguiamasiva_Click" Height="50px" Width="250px" BackColor="White" Font-Bold="False" Font-Size="Large" BorderColor="#CCCCCC" BorderStyle="Outset" />
   <br />
    <br />
    
    <asp:Button ID="Consultarguia0" runat="server" Text="Consultar Guías" OnClick="Consultarguia_Click" Height="50px" Width="250px" BackColor="White" Font-Bold="False" Font-Size="Large" BorderColor="#CCCCCC" BorderStyle="Outset" />
     <br />
        <br />
    
   <asp:Button ID="Recoleccion" runat="server" Text="Solicitar Recolección al numero +502 123456879" OnClick="Recoleccion_Click" Height="70px" Width="250px" BackColor="White" Font-Bold="False" Font-Size="Large" BorderColor="#CCCCCC" BorderStyle="Outset" />
        <br />
        <br />
      
    <asp:Button ID="Manifiestos" runat="server" Text="Manifiestos" OnClick="Manifiestos_Click" Height="50px" Width="250px" BackColor="White" Font-Bold="False" Font-Size="Large" BorderColor="#CCCCCC" BorderStyle="Outset" />
    <br />
    <br />
  
<asp:Button ID="Transferencias" runat="server" Text="Transferencias" OnClick="Transferencias_Click" Height="50px" Width="250px" BackColor="White" Font-Bold="False" Font-Size="Large" BorderColor="#CCCCCC" BorderStyle="Outset" />
<br />
            </div>
        </div>
               </div>
            </div>
</asp:Content>