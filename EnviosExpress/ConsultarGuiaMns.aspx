<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarGuiaMns.aspx.cs" Inherits="EnviosExpress.ConsultarGuiaMns" %>

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
        <asp:TextBox ID="txtcodigoo" runat="server" Width="187px" TextMode="Number"></asp:TextBox>
            </p>
     

        <asp:Button ID="btnrecolectar" runat="server" OnClick="btnrecolectar_Click" Text="Consultar" BackColor="#339933" ForeColor="White" />
               <br />
               <br />
         <div class="container text-left" style="   width:400px;  background-image: url('Resources/.jpg'); background-attachment:fixed;  background-color:white;background-repeat :no-repeat;  position:page; z-index: auto;" >
            
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
             <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Italic="False" Font-Overline="False" ForeColor="Black" Visible="False">Datos del Destinatario</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <br />
        
             <asp:Label ID="guia12" runat="server" Visible="False" Font-Bold="True" Font-Size="Medium" Font-Italic="False" Font-Overline="False" ForeColor="Black">Número de Guía: </asp:Label>
             <asp:Label ID="guia11" runat="server" Font-Bold="True" Font-Size="Large" Font-Italic="False" Font-Overline="False" ForeColor="Black"></asp:Label>
        
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="monto12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black" Font-Size="Medium">Monto:Q</asp:Label>
        <asp:Label ID="monto11" runat="server" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black" Font-Size="Large"></asp:Label>
        
             <br />
        
        <asp:Label ID="destinatario12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black">Nombre:</asp:Label>
        &nbsp;<asp:Label ID="destinatario11" runat="server"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     
        <br />
        <asp:Label ID="telefono12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black">Telefono: </asp:Label>
        &nbsp;<asp:Label ID="telefono11" runat="server"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="direccion12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black">Direccion: </asp:Label>
        <asp:Label ID="direccion11" runat="server"></asp:Label>
             <br />
        <asp:Label ID="departamento11" runat="server" Font-Bold="True" BackColor="Black" Font-Size="Medium" ForeColor="White"></asp:Label>
            ,<asp:Label ID="municipio11" runat="server" Font-Bold="True" BackColor="Black" Font-Size="Medium" ForeColor="White"></asp:Label>
            ,<asp:Label ID="zona11" runat="server" Font-Bold="True" BackColor="Black" Font-Size="Medium" ForeColor="White"></asp:Label>
        <br />
        <asp:Label ID="tipo12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Small" ForeColor="Black">Tipo:</asp:Label>
        <asp:Label ID="tipo11" runat="server" Font-Size="Small"></asp:Label>
             <br />
        <asp:Label ID="peso12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Small" ForeColor="Black">Peso:</asp:Label>
        <asp:Label ID="peso11" runat="server" Font-Size="Small"></asp:Label>
             <br />
        <asp:Label ID="recibe" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Small" ForeColor="Black">Recibido por:</asp:Label>
        <asp:Label ID="txtrecibe" runat="server" Font-Size="Small"></asp:Label>
             <br />
             <br />
               </div>
                <br />
         <div class="container text-center" style="   width:400px;  background-image: url('Resources/.jpg'); background-attachment:fixed;  background-color:white;background-repeat :no-repeat;  position:page; z-index: auto;" >
            
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Estado del Paquete" Visible="False"></asp:Label>
               
               <p />
               <asp:GridView ID="GridView5" runat="server" ForeColor="Black" CellSpacing="10" HorizontalAlign="Center" GridLines="Horizontal" CellPadding="10" Width="380px" >
                   <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <EditRowStyle HorizontalAlign="Center" />
                <HeaderStyle BackColor="#FF6600" Font-Bold="True" Font-Italic="False" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Width="600px" Wrap="True" />
                   <RowStyle HorizontalAlign="Center" />
                <SelectedRowStyle BorderStyle="Solid" HorizontalAlign="Center" />
                   <SortedAscendingHeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <SortedDescendingHeaderStyle HorizontalAlign="Center" />
            </asp:GridView>
             </div>
            <br />
        
               <asp:Label ID="Label11" runat="server"></asp:Label>
               <br /><br />
     </div>
        <br />
     

     

        <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" />
        
        &nbsp;&nbsp;&nbsp;&nbsp;
     

        <br/><br/></div>
    </asp:Content>
