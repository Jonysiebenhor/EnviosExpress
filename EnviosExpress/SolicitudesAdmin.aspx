<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="SolicitudesAdmin.aspx.cs" Inherits="EnviosExpress.SolicitudesAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
             <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Solicitudes" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
           <div class="container text-center" style="background-color:#f5f5f5; width:40%; ">
    
    <br />
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <br />
    
    <br />
    
    Desde: <asp:TextBox ID="txtfecha1" runat="server" Width="100px" TextMode="Date"></asp:TextBox>&nbsp;
a: <asp:TextBox ID="txtfecha2" runat="server" Width="100px" TextMode="Date"></asp:TextBox>
           &nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="btn3_Click" Text="Consultar" BackColor="#339933" ForeColor="White" />
               <br />
            <br />
    <br />
   <asp:GridView ID="GridView1" runat="server" ForeColor="Black" CellSpacing="10" HorizontalAlign="Center" GridLines="Horizontal" CellPadding="10" Width="380px" >
       <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
       <EditRowStyle HorizontalAlign="Center" />
    <HeaderStyle BackColor="#FF6600" Font-Bold="True" Font-Italic="False" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Width="600px" Wrap="True" />
       <RowStyle HorizontalAlign="Center" />
    <SelectedRowStyle BorderStyle="Solid" HorizontalAlign="Center" />
       <SortedAscendingHeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
       <SortedDescendingHeaderStyle HorizontalAlign="Center" />
</asp:GridView>    <br />
    <br />
    <br />
    <br />
               
           </div>
        <br/>
     

     

        <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" />
        
             <br/> </div>
    </asp:Content>
