<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra2.Master" AutoEventWireup="true" CodeBehind="RastrearGuia.aspx.cs" Inherits="EnviosExpress.RastrearGuia" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
             <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Consultar Guia" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
           <div class="container text-center""row" style="background-color:#f5f5f5; width:500px;">


<br /><br />
      <p>
            Numero de Guia:<br />
        <asp:TextBox ID="txtcodigoo" runat="server" Width="187px"></asp:TextBox>
            </p>
     

        <asp:Button ID="btnrecolectar" runat="server" OnClick="btnrecolectar_Click" Text="Consultar" BackColor="#339933" ForeColor="White" />
               <br />
               <br />
               <p />
                   <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Large" Text="Estado del Paquete"></asp:Label>
                   <br />
               <asp:GridView ID="GridView5" runat="server" ForeColor="Black" CellSpacing="10" HorizontalAlign="Center" Width="100px" >
                <HeaderStyle BackColor="#FF6600" Font-Bold="True" Font-Italic="False" ForeColor="White" />
                <SelectedRowStyle BorderStyle="Solid" />
            </asp:GridView>
            <br />
        
               <asp:Label ID="Label11" runat="server"></asp:Label>
               <br /><br />
     </div>
        <br />
     

     

        <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Inicio" BackColor="#FF3300" ForeColor="White" />
        
        &nbsp;&nbsp;&nbsp;&nbsp;
     

        <br/><br/> </div>
    </asp:Content>