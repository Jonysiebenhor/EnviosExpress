<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="CierreDiario.aspx.cs" Inherits="EnviosExpress.CierreDiario" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
             <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Cierre Diario" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
           <div class="container text-center" style="background-color:#f5f5f5; ">
<div class="container text-center">
    
    <br />
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <br />
    
    <br />
    
    <asp:Button ID="Cierre" runat="server" Text="X Cerrar todos los paquetes" OnClick="Cierre_Click" Height="50px" Width="250px" />
    <br />
    <br />
    <br />
    <br />
               </div></div>
        <br/>
     

     

        <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" />
        
             <br/></div>
    
      </asp:Content>
