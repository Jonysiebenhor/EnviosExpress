<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Manifiesto.aspx.cs" Inherits="EnviosExpress.Manifiesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
             <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Manifiestos" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
           <div class="container text-center""row" style="background-color:#f5f5f5;  ">
<div class="container text-center">
    
    <br />
    
    <br />
    
    <asp:Button ID="Cierre" runat="server" Text="Cerrar Manifiesto" OnClick="Cierre_Click" Height="50px" Width="200px" />
   
    &nbsp;<asp:Button ID="imprimir" runat="server" Text="Imprimir Manifiesto" OnClick="imprimir_Click" Height="50px" Width="200px" Visible="False" BackColor="#33CC33" ForeColor="White" />
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Buscar Manifiestos" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <br />
    <br />
    Fecha Inicial <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
&nbsp;Fecha Final <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
    
    &nbsp;
    <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="Button2_Click" /><asp:Image runat="server"></asp:Image>
    <asp:Image ID="Image1" runat="server" />
    <br />
    
    &nbsp;<br />
    <img runat="server" id="imgCtrl" visible="False" />&nbsp;
    
               <asp:GridView ID="GridView5" runat="server" ClientIDMode="AutoID" ForeColor="Black" CellSpacing="30" HorizontalAlign="Center" GridLines="Horizontal" CellPadding="20" Height="200px" Width="400px" >
                   
                   
                   
                   <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <EditRowStyle HorizontalAlign="Center" />
                <HeaderStyle BackColor="#FF6600" Font-Bold="True" Font-Italic="False" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Width="600px" Wrap="True" />
                   <RowStyle HorizontalAlign="Center" />
                <SelectedRowStyle BorderStyle="Solid" HorizontalAlign="Center" />
                   <SortedAscendingHeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <SortedDescendingHeaderStyle HorizontalAlign="Center" />
                  <Columns>
                      <asp:TemplateField HeaderText="">
                       <ItemTemplate>
                      <input type="button" class="btnEditar" value="Descargar" aviable="False"/>
                       </ItemTemplate>
                   </asp:TemplateField>
                  </Columns>
            </asp:GridView>
               </div>
               <div class="container text-center">&nbsp;</div>
               <div class="container text-center">&nbsp;</div>
               <div class="container text-center">&nbsp;</div>
               <div class="container text-center">&nbsp;</div>
           </div>
        <br/>
     

     

        <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" />
        
             <br/></div>
    </asp:Content>
