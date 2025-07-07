<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="PagosClientes.aspx.cs" Inherits="EnviosExpress.PagosClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
             <br />
            <br />
           <div class="container text-center""row" style="background-color:#f5f5f5; width:500px;">
               <br />
               <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Transferencias" Visible="True"></asp:Label>
<br />
     
 <p>
            <br />
        Desde: <asp:TextBox ID="txtfecha1" runat="server" Width="100px" TextMode="Date"></asp:TextBox>&nbsp;
      a: <asp:TextBox ID="txtfecha2" runat="server" Width="100px" TextMode="Date"></asp:TextBox>
            &nbsp;
     

        <asp:Button ID="btnrecolectar" runat="server" OnClick="btnrecolectar_Click" Text="Consultar" BackColor="#339933" ForeColor="White" />
            </p>
     
               <asp:Label ID="Label11" runat="server"></asp:Label>
&nbsp;
               &nbsp;&nbsp;
               <br />
                <br />
         <div class="container text-center" style="   width:400px;  background-image: url('Resources/.jpg'); background-attachment:fixed;  background-color:white;background-repeat :no-repeat;  position:page; z-index: auto;" >
            
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                   
               
               <p />
               <asp:GridView ID="GridView5" runat="server"  
                   AutoGenerateColumns="false"
                   DataKeyNames="idpagoCliente"
                   OnRowCommand="GridView5_RowCommand"
                   ForeColor="Black" 
                   CellSpacing="10" 
                   HorizontalAlign="Center" 
                   GridLines="Horizontal" 
                   CellPadding="10" 
                   Width="380px" >
                   <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <EditRowStyle HorizontalAlign="Center" />
                <HeaderStyle BackColor="#FF6600" Font-Bold="True" Font-Italic="False" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Width="600px" Wrap="True" />
                   <RowStyle HorizontalAlign="Center" />
                <SelectedRowStyle BorderStyle="Solid" HorizontalAlign="Center" />
                   <SortedAscendingHeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <SortedDescendingHeaderStyle HorizontalAlign="Center" />
                   <Columns>
    <asp:BoundField DataField="idpagoCliente"    HeaderText="ID Pago Cliente" />
    <asp:BoundField DataField="FechaHoraEntrega" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
    <asp:BoundField DataField="MontoEstado"      HeaderText="Monto/Estado" />
    <asp:BoundField DataField="descripcion"      HeaderText="#Referencia" />
    <asp:TemplateField HeaderText="Acción">
      <ItemTemplate>
        <asp:Button
          ID="btnVerConsulta"
          runat="server"
          Text="Ver Consulta"
          CommandName="VerConsulta"
          CommandArgument='<%# Eval("idpagoCliente") %>'
          CssClass="btn btn-info btn-sm" />
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>
            </asp:GridView>


             <%-- PANEL OCULTO CON LA TABLA DE DETALLE --%>
<asp:Panel ID="pnlDetalleT" runat="server" Visible="false" Style="margin-top:20px;">
  <asp:Label runat="server" Text="Detalle de la transferencia" CssClass="h4" />

  <%-- 1) Contenedor scrollable --%>
  <div style="overflow-x:auto;">
    <asp:GridView ID="GridViewDetalleT" runat="server"
        AutoGenerateColumns="false"
        CssClass="table table-bordered table-hover"
        Width="100%"
        HeaderStyle-BackColor="#d9534f" HeaderStyle-ForeColor="White"
        RowStyle-Wrap="True">
      
      <%-- 2) Columnas con anchos fijos y word-wrap --%>
      <Columns>
        <asp:BoundField DataField="NoGuia"           HeaderText="No. Guía"               HeaderStyle-Width="80px" ItemStyle-Width="80px" />
        <asp:BoundField DataField="IdPago"           HeaderText="ID Pago"               HeaderStyle-Width="60px" ItemStyle-Width="60px" />
        <asp:BoundField DataField="Departamento"     HeaderText="Departamento"          HeaderStyle-Width="120px" ItemStyle-Width="120px" />
        <asp:BoundField DataField="Municipio"        HeaderText="Municipio"             HeaderStyle-Width="120px" ItemStyle-Width="120px" />
        <asp:BoundField DataField="Zona"             HeaderText="Zona"                  HeaderStyle-Width="100px" ItemStyle-Width="100px" />
        <asp:BoundField DataField="MontoCobrado"     HeaderText="Monto Cobrado"         DataFormatString="Q{0:N2}" HeaderStyle-Width="100px" ItemStyle-Width="100px" />
        <asp:BoundField DataField="ValorEnvio"       HeaderText="Valor Envío"           DataFormatString="Q{0:N2}" HeaderStyle-Width="100px" ItemStyle-Width="100px" />
        <asp:BoundField DataField="ValorVisita"      HeaderText="Valor Visita"          DataFormatString="Q{0:N2}" HeaderStyle-Width="100px" ItemStyle-Width="100px" />
        <asp:BoundField DataField="PagoCliente"      HeaderText="Pago al Cliente"       DataFormatString="Q{0:N2}" HeaderStyle-Width="100px" ItemStyle-Width="100px" />
        <asp:BoundField DataField="FechaHoraEntrega" HeaderText="Fecha y Hora Entrega"  DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderStyle-Width="140px" ItemStyle-Width="140px" />
        <asp:BoundField DataField="Estado"           HeaderText="Estado"                HeaderStyle-Width="80px" ItemStyle-Width="80px" />
        <asp:BoundField DataField="descripcion"      HeaderText="#Referencia"           HeaderStyle-Width="100px" ItemStyle-Width="100px" />
      </Columns>
    </asp:GridView>
  </div>
</asp:Panel>
             </div>
            <br />
        
               <br /><br />
     </div>
        <br />
     

     

        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" />
        
        &nbsp;&nbsp;&nbsp;&nbsp;
     

        <br/><br/></div>
    </asp:Content>
