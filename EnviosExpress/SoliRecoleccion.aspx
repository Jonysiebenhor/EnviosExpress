<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra2.Master" AutoEventWireup="true" CodeBehind="SoliRecoleccion.aspx.cs" Inherits="EnviosExpress.SoliRecoleccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
             <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Solicitar Recolección" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
           <div class="container text-center""row" style="background-color:#f5f5f5; width:500px;">


<br /><br />
   
            <br />
        <asp:TextBox ID="txtnombre" runat="server" placeholder="Nombre de Remitente" Width="130px"></asp:TextBox>
            <br />
               <asp:Label ID="nombre0" runat="server"></asp:Label>
            <br />
               <asp:TextBox ID="txttelefono1" runat="server" placeholder="Teléfono 1" Width="130px"></asp:TextBox>
            <br />
               <asp:Label ID="tel10" runat="server"></asp:Label>
            <br />
               <asp:TextBox ID="txttelefono2" runat="server" placeholder="Teléfono 2" Width="130px"></asp:TextBox>
            <br />
               <asp:Label ID="tel20" runat="server"></asp:Label>
            <br />
               <asp:TextBox ID="txtdireccion" runat="server" placeholder="Dirección" Width="130px" Height="100px"></asp:TextBox>
            <br />
               <asp:Label ID="direccion0" runat="server"></asp:Label>
     
               <p />
                   <br />
     </div>
        <br />
     

     

        <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Inicio" BackColor="#FF3300" ForeColor="White" />
        
        &nbsp;&nbsp;&nbsp;&nbsp;
     

        <asp:Button ID="btnrecolectar" runat="server" OnClick="btnrecolectar_Click" Text="Solicitar" BackColor="#339933" ForeColor="White" />
     

        <br/><br/></div>
   </asp:Content>
