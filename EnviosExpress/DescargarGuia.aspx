<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="DescargarGuia.aspx.cs" Inherits="EnviosExpress.DescargarGuia" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div  class="container text-center"  style="background-color:#2d2d30;  width:100%;">
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Guia Realizada" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
         <div class="container text-left" style="   height:410px; width:400px;  background-image: url('Resources/.jpg'); background-attachment:fixed;  background-color:white;background-repeat :no-repeat;  position:page; z-index: auto;" >
            
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
             <asp:Label ID="guia13" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Italic="False" Font-Overline="False" ForeColor="Black"></asp:Label>
                <br />
                <asp:Image ID="Image1" ImageAlign="Right" runat="server" Height="130px" ImageUrl="~/Imagenes/enviosgt.jpg" Width="128px" />
        <img runat ="server" id ="imgCtrl" visible="False" />&nbsp;
             
             <br />
        
             <asp:Label ID="guia12" runat="server" Visible="False" Font-Bold="True" Font-Size="Small" Font-Italic="False" Font-Overline="False" ForeColor="Black">Número de Guía: </asp:Label>
             <asp:Label ID="guia11" runat="server" Font-Bold="True" Font-Size="Small" Font-Italic="False" Font-Overline="False" ForeColor="Black"></asp:Label>
        
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:Label ID="destinatario13" runat="server" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Small" ForeColor="Black">Remitente: </asp:Label>
        <asp:Label ID="remitente11" runat="server" Font-Size="Small"></asp:Label>
        
             <br />
        
        <asp:Label ID="destinatario12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black">Destinatario: </asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="telefono13" runat="server" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Small" ForeColor="Black">Telefono: </asp:Label>
        <asp:Label ID="telefono14" runat="server" Font-Size="Small"></asp:Label>
             <br />
        
        <asp:Label ID="destinatario11" runat="server"></asp:Label>
        <br />
        <asp:Label ID="telefono12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black">Telefono: </asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="peso12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Small" ForeColor="Black">Peso:</asp:Label>
        <asp:Label ID="peso11" runat="server" Font-Size="Small"></asp:Label>
        <br />
        <asp:Label ID="telefono11" runat="server"></asp:Label>
             <br />
        <asp:Label ID="direccion12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black">Direccion: </asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="tipo12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Small" ForeColor="Black">Tipo:</asp:Label>
        <asp:Label ID="tipo11" runat="server" Font-Size="Small"></asp:Label>
        <br />
        <asp:Label ID="direccion11" runat="server"></asp:Label>
             <br />
        <asp:Label ID="departamento11" runat="server" Font-Bold="False"></asp:Label>
            ,<asp:Label ID="municipio11" runat="server"></asp:Label>
            ,<asp:Label ID="zona11" runat="server"></asp:Label>
        <br />
        <asp:Label ID="monto12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black">Monto:Q</asp:Label>
        <asp:Label ID="monto11" runat="server" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black"></asp:Label>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="fecha22" runat="server"></asp:Label>
         &nbsp;/<asp:Label ID="fecha11" runat="server"></asp:Label>
             /<asp:Label ID="fecha0" runat="server"></asp:Label>
         <br />
        <br /></div> <br />
        <asp:Button ID="btnGenerarPDF" runat="server" Text="Descargar Guía" OnClick="btnGenerarPDF_click"/>
             &nbsp;&nbsp;
     

     

        <asp:Button ID="regresar" runat="server" OnClick="regresar_Click" Text="&lt; Hacer Otra Guía" BackColor="#33CC33" ForeColor="White" />
        
        &nbsp;&nbsp;
     

     

        <asp:Button ID="btnrecolectar10" runat="server" OnClick="btnrecolectar10_Click" Text="&lt;&lt; Menu" BackColor="#FF3300" ForeColor="White" />
        
             <br />
    </div>
    </asp:Content>