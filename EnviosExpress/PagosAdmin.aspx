<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="PagosAdmin.aspx.cs" Inherits="EnviosExpress.PagosAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
  <style>
    /* Fuerza el salto de línea dentro de celdas y encabezados */
    .text-wrap td,
    .text-wrap th {
      white-space: normal !important;
      word-wrap: break-word !important;
    }
  </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">


        <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
            <div class="container text-center" style="background-color:#e1dddd; height:90%; width:90%;">
             <br /><br />
           
               <div class="container text-center" style="background-color:#e1dddd; height:90%; width:90%;">
             <br /><br />
           <div class="container text-center row" style="background-color:#f5f5f5; width:600px;">


<br /><br />
     <asp:Label ID="Label2" runat="server" Text="Pagos de Clientes Pendientes" Font-Bold="True" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
 <p>
              Desde: <asp:TextBox ID="txtfecha1" runat="server" Width="100px" TextMode="Date"></asp:TextBox>&nbsp;
a: <asp:TextBox ID="txtfecha2" runat="server" Width="100px" TextMode="Date"></asp:TextBox>
           &nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="btn3_Click" Text="Consultar" BackColor="#339933" ForeColor="White" />





               <br />
            <br />
               <p class="centrado">
                   <asp:GridView ID="GridView2" runat="server" ForeColor="Black" CellSpacing="30" HorizontalAlign="Center"
                    OnRowCommand="GridView2_RowCommand"
                        DataKeyNames="dpi"
                        


                       AutoGenerateEditButton="true"
                       AutoGenerateColumns="false"
                       OnRowCancelingEdit="RowCancelingEvent1"
                       OnRowEditing="RowEditingEvent1"
                       OnRowUpdating="RowUpdatingEvent1" TextOnRowUpdating="Liquidar" >

                       <HeaderStyle BackColor="#FF6600" Font-Bold="True" Font-Italic="False" ForeColor="White" />
<SelectedRowStyle BorderStyle="Solid" />

                            <Columns>
             <asp:TemplateField HeaderText="DPI">
                 <ItemTemplate>
                     <asp:Label ID="Label7" runat="server" Text='<%# Bind("dpi") %>' Enabled="false" Width="80px"></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("dpi") %>' Enabled="false" Width="80px"></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>

              <asp:TemplateField HeaderText="Cliente">
               <ItemTemplate>
                 <asp:Label ID="Label8" runat="server" Text='<%# Bind("Cliente") %>' Enabled="false" Width="80px"></asp:Label>
               </ItemTemplate>
                <EditItemTemplate>
                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Cliente") %>' Enabled="false" Width="80px"></asp:TextBox>
               </EditItemTemplate>
              </asp:TemplateField>

              <asp:TemplateField HeaderText="Negocio">
               <ItemTemplate>
                 <asp:Label ID="Label9" runat="server" Text='<%# Bind("Negocio") %>' Enabled="false" Width="80px"></asp:Label>
               </ItemTemplate>
                <EditItemTemplate>
                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Negocio") %>' Enabled="false" Width="80px"></asp:TextBox>
               </EditItemTemplate>
              </asp:TemplateField>

              <asp:TemplateField HeaderText="Monto">
               <ItemTemplate>
                 <asp:Label ID="Label10" runat="server" Text='<%# Bind("Monto") %>' Enabled="false" Width="80px"></asp:Label>
               </ItemTemplate>
                <EditItemTemplate>
                <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Monto") %>' Enabled="false" Width="80px"></asp:TextBox>
               </EditItemTemplate>
              </asp:TemplateField>

           <asp:TemplateField HeaderText="#Referencia">
  <ItemTemplate>
    <asp:Label 
      ID="Label11" 
      runat="server" 
      Text='<%# Bind("descripcion") %>' 
      Enabled="false" 
      Width="80px" />
  </ItemTemplate>
  <EditItemTemplate>
    <asp:TextBox 
      ID="TextBox11" 
      runat="server" 
      Text='<%# Bind("descripcion") %>' 
      Enabled="true" 
      Width="80px" />
  </EditItemTemplate>
</asp:TemplateField>


             <asp:TemplateField HeaderText="Acción">
      <ItemTemplate>
        <asp:Button
            ID="btnReporteFila"
            runat="server"
            Text="Ver Reporte"
            CommandName="VerReporte"
            CommandArgument='<%# Eval("dpi") %>'
            CssClass="btn btn-info btn-sm" />
      </ItemTemplate>
    </asp:TemplateField>

         </Columns>


            </asp:GridView><p />

<asp:Panel ID="pnlDetallePendientes" runat="server" Visible="false" Style="margin-top:20px;">
  <asp:Label ID="lblTituloDetallePendientes" runat="server" CssClass="h4" Text="" Style="display:block; margin-bottom:10px;" />
  <asp:GridView
      ID="GridViewDetallePendientes"
      runat="server"
      AutoGenerateColumns="false"
      CssClass="table table-striped text-wrap"
      EmptyDataText="No hay detalles"
      Width="100%"
      CellSpacing="10">
    <HeaderStyle BackColor="#FF0000" ForeColor="White" />
    <Columns>
      <asp:BoundField DataField="NoGuia"          HeaderText="No. Guía"               />
      <asp:BoundField DataField="Departamento"    HeaderText="Departamento"           />
      <asp:BoundField DataField="Municipio"       HeaderText="Municipio"              />
      <asp:BoundField DataField="Zona"            HeaderText="Zona"                   />
      <asp:BoundField DataField="MontoCobrado"    HeaderText="Monto Cobrado"          DataFormatString="Q{0:N2}" />
      <asp:BoundField DataField="ValorEnvio"      HeaderText="Valor Envío"            DataFormatString="Q{0:N2}" />
        <asp:BoundField DataField="ValorVisita"      HeaderText="Valor Visita"        DataFormatString="Q{0:N2}" />
      <asp:BoundField DataField="PagoCliente"     HeaderText="Pago al Cliente"        DataFormatString="Q{0:N2}" />
      <asp:BoundField DataField="FechaHoraEntrega" HeaderText="Fecha y Hora Entrega" DataFormatString="{0:dd/MM/yyyy HH:mm}" />

      <asp:BoundField DataField="Mensajero"       HeaderText="Mensajero"              />
    </Columns>
  </asp:GridView>
    </asp:Panel>

  <asp:Panel ID="pnlReporte" runat="server" Visible="false">
  <asp:Label 
      ID="lblReporteTitulo" 
      runat="server" 
      CssClass="h4 text-left"
      Text="" 
      Style="display:block; margin-bottom:10px;" />

  <asp:GridView
    ID="GridViewReporte"
    runat="server"
    AutoGenerateColumns="false"
    CssClass="table table-striped text-wrap"
    EmptyDataText="No hay datos para ese rango"
    Width="700px"
    Style="table-layout:fixed;"
    CellSpacing="30">
    
    <HeaderStyle BackColor="#FF0000" ForeColor="White" />

    <Columns>
     
          <asp:BoundField
              DataField="NoGuia"
        HeaderText="No. Guía"
        HeaderStyle-Width="80px"
        ItemStyle-Width="80px" />

      <asp:BoundField
        DataField="Departamento"
        HeaderText="Departamento"
        HeaderStyle-Width="115px"
        ItemStyle-Width="115px" />

      <asp:BoundField
        DataField="Municipio"
        HeaderText="Municipio"
        HeaderStyle-Width="95px"
        ItemStyle-Width="95px" />

      <asp:BoundField
        DataField="Zona"
        HeaderText="Zona"
        HeaderStyle-Width="70px"
        ItemStyle-Width="70px" />

      <asp:BoundField
        DataField="MontoCobrado"
        HeaderText="Monto Cobrado"
        DataFormatString="Q{0:N2}"
        HeaderStyle-Width="100px"
        ItemStyle-Width="100px" />

      <asp:BoundField
        DataField="ValorEnvio"
        HeaderText="Valor Envío"
        DataFormatString="Q{0:N2}"
        HeaderStyle-Width="100px"
        ItemStyle-Width="100px" />

      <asp:BoundField
        DataField="PagoCliente"
        HeaderText="Pago al Cliente"
        DataFormatString="Q{0:N2}"
        HeaderStyle-Width="100px"
        ItemStyle-Width="100px" />

        <asp:BoundField 
  DataField="FechaHoraEntrega" 
  HeaderText="Fecha y Hora Entrega" 
  DataFormatString="{0:dd/MM/yyyy HH:mm}" 
  HeaderStyle-Width="100px" 
  ItemStyle-Width="100px" />


      <asp:BoundField
        DataField="Mensajero"
        HeaderText="Mensajero"
        HeaderStyle-Width="100px"
        ItemStyle-Width="100px" />
    </Columns>

  </asp:GridView>

      </asp:Panel>

</div>





 <br /> 
                              <div class="container text-center row" style="background-color:#f5f5f5; width:600px;">


<br /><br />
     <%-- Pagos de Clientes Liquidados --%>
<asp:Label ID="lblPagosLiquidados" runat="server"
  Text="Pagos de Clientes Liquidados"
  Font-Bold="True" Font-Size="XX-Large" ForeColor="Black" />
<p>
  Desde:
  <asp:TextBox ID="txtfecha3" runat="server" TextMode="Date" Width="100px" />
  &nbsp;a:&nbsp;
  <asp:TextBox ID="txtfecha4" runat="server" TextMode="Date" Width="100px" />
  &nbsp;
  <asp:Button ID="btn2" runat="server" Text="Consultar"
    OnClick="btn2_Click" BackColor="#339933" ForeColor="White" />
</p>

<asp:GridView
  ID="GridView3"
  runat="server"
  AutoGenerateColumns="false"
  DataKeyNames="idpago"
  OnRowCommand="GridView3_RowCommand"
  CssClass="table table-striped text-wrap"
  Style="table-layout:fixed; width:700px;"
  ForeColor="Black" CellSpacing="10" HorizontalAlign="Center">
  <HeaderStyle BackColor="#FF6600" Font-Bold="True" ForeColor="White" />
  <SelectedRowStyle BorderStyle="Solid" />
  <Columns>
    <asp:BoundField DataField="idpago"     HeaderText="ID Pago" />
    <asp:BoundField DataField="Cliente"    HeaderText="Cliente" />
    <asp:BoundField
      DataField="FechaHoraEntrega"
      HeaderText="Fecha y Hora Entrega"
      DataFormatString="{0:dd/MM/yyyy HH:mm}"
      HeaderStyle-Width="140px" ItemStyle-Width="140px" />
    <asp:BoundField DataField="Monto"      HeaderText="Monto" />
    <asp:BoundField DataField="Estado"     HeaderText="Estado" />
    <asp:BoundField DataField="descripcion" HeaderText="#Referencia" />

    <asp:TemplateField HeaderText="Acciones">
      <ItemTemplate>
        <asp:LinkButton
          ID="btnGenReporte"
          runat="server"
          CommandName="GenerarReporte"
          CommandArgument='<%# Eval("idpago") %>'
          CssClass="btn btn-sm btn-success">
          Generar Reporte
        </asp:LinkButton>
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>
</asp:GridView>


<%-- Panel oculto con detalle completo --%>
<asp:Panel ID="pnlDetalleLiquidados" runat="server" Visible="false" Style="margin-top:20px;">
  <asp:Label
    ID="lblTituloDetalle"
    runat="server"
    CssClass="h4"
    Text=""
    Style="display:block; margin-bottom:10px;" />

  <asp:GridView
    ID="GridViewDetalleLiquidados"
    runat="server"
    AutoGenerateColumns="false"
    CssClass="table table-striped text-wrap"
    EmptyDataText="No hay detalles"
    Width="100%"
    Style="table-layout:fixed;"
    CellSpacing="10">
    <HeaderStyle BackColor="#FF0000" ForeColor="White" />
    <Columns>
    <%-- Ahora mostramos el pago --%>
        <asp:BoundField DataField="NoGuia"
            HeaderText="No. Guía"
            HeaderStyle-Width="80px"
            ItemStyle-Width="80px" />
    
        <asp:BoundField 
DataField="idpago"      
HeaderText="ID Pago"       
HeaderStyle-Width="80px" 
ItemStyle-Width="80px" />

    <asp:BoundField 
    DataField="Departamento"      
    HeaderText="Departamento"       
    HeaderStyle-Width="80px" 
    ItemStyle-Width="80px" />

<asp:BoundField 
    DataField="Municipio"         
    HeaderText="Municipio"          
    HeaderStyle-Width="80px" 
    ItemStyle-Width="80px" />

<asp:BoundField 
    DataField="Zona"              
    HeaderText="Zona"               
    HeaderStyle-Width="80px" 
    ItemStyle-Width="80px" />

<asp:BoundField 
    DataField="MontoCobrado"      
    HeaderText="Monto Cobrado"       
    DataFormatString="Q{0:N2}" 
    HeaderStyle-Width="80px" 
    ItemStyle-Width="80px" />

<asp:BoundField 
    DataField="ValorEnvio"        
    HeaderText="Valor Envío"         
    DataFormatString="Q{0:N2}" 
    HeaderStyle-Width="80px" 
    ItemStyle-Width="80px" />

         <asp:BoundField 
 DataField="ValorVisita"      
 HeaderText="Valor Visita"       
 HeaderStyle-Width="80px" 
 ItemStyle-Width="80px" />

<asp:BoundField 
    DataField="PagoCliente"       
    HeaderText="Pago al Cliente"     
    DataFormatString="Q{0:N2}" 
    HeaderStyle-Width="80px" 
    ItemStyle-Width="80px" />

<asp:BoundField 
    DataField="FechaHoraEntrega"  
    HeaderText="Fecha y Hora Entrega" 
    DataFormatString="{0:dd/MM/yyyy HH:mm}" 
    HeaderStyle-Width="80px" 
    ItemStyle-Width="80px" />

<asp:BoundField 
    DataField="Estado"            
    HeaderText="Estado"             
    HeaderStyle-Width="80px" 
    ItemStyle-Width="80px" />

<asp:BoundField 
    DataField="descripcion"       
    HeaderText="#Referencia"        
    HeaderStyle-Width="80px" 
    ItemStyle-Width="80px" />
    </Columns>
  </asp:GridView>
</asp:Panel>
               <br />
               </div>
 <br /> 
                <div class="container text-center row" style="background-color:#f5f5f5; width:600px;">


<br /><br />
     <asp:Label ID="Label1" runat="server" Text="Pagos de Mensajeros" Font-Bold="True" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
 <p>
          Desde: <asp:TextBox ID="txtfecha5" runat="server" Width="100px" TextMode="Date"></asp:TextBox>&nbsp;
a: <asp:TextBox ID="txtfecha6" runat="server" Width="100px" TextMode="Date"></asp:TextBox>
           &nbsp;
        <asp:Button ID="btnrecolectar" runat="server" OnClick="btnrecolectar_Click" Text="Consultar" BackColor="#339933" ForeColor="White" />
               <br />
            <br />
               <p class="centrado">
                   <asp:GridView ID="GridView1" runat="server" ForeColor="Black" CellSpacing="10" HorizontalAlign="Center"
                       OnRowCommand="GridView1_RowCommand"
                       OnRowUpdating="RowUpdatingEvent" 
                       OnRowEditing="RowEditingEvent" AutoGenerateEditButton="true"
                       OnRowCancelingEdit="RowCancelingEvent" AutoGenerateColumns="false" >
                       
                       <HeaderStyle BackColor="#FF6600" Font-Bold="True" Font-Italic="False" ForeColor="White" />
                <SelectedRowStyle BorderStyle="Solid" />

                       <Columns>
                           <asp:TemplateField HeaderText="IdPago">
                               <ItemTemplate>
                                   <asp:Label ID="Label3" runat="server" Text='<%# Bind("idpago") %>' Enabled="false" Width="80px"></asp:Label>
                               </ItemTemplate>
                               <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("idpago") %>' Enabled="false" Width="80px"></asp:TextBox>

                               </EditItemTemplate>
                           </asp:TemplateField>

                            <asp:TemplateField HeaderText="Mensajero">
                             <ItemTemplate>
                               <asp:Label ID="Label4" runat="server" Text='<%# Bind("Mensajero") %>' Enabled="false" Width="80px"></asp:Label>
                             </ItemTemplate>
                              <EditItemTemplate>
                              <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Mensajero") %>' Enabled="false" Width="80px"></asp:TextBox>
                             </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Fecha">
                             <ItemTemplate>
                               <asp:Label ID="Label5" runat="server" Text='<%# Bind("Fecha") %>' Enabled="false" Width="80px"></asp:Label>
                             </ItemTemplate>
                              <EditItemTemplate>
                              <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Fecha") %>' Enabled="false" Width="80px"></asp:TextBox>
                             </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Monto">
                             <ItemTemplate>
                               <asp:Label ID="Label6" runat="server" Text='<%# Bind("Monto") %>' Enabled="false" Width="80px"></asp:Label>
                             </ItemTemplate>
                              <EditItemTemplate>
                              <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Monto") %>' Enabled="false" Width="80px"></asp:TextBox>
                             </EditItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="Estado">
                             <ItemTemplate>
                               <asp:Label ID="Label77" runat="server" Text='<%# Bind("Estado") %>' Enabled="false" Width="80px"></asp:Label>
                             </ItemTemplate>
                              <EditItemTemplate>
                                    <asp:DropDownList ID="ddl2" runat="server" AutoPostBack="True"  Width="80px" >
                                    <asp:ListItem>--Seleccione</asp:ListItem>
                                    <asp:ListItem>Proceso</asp:ListItem>
                                    <asp:ListItem>Pago no Realizado</asp:ListItem>
                                    <asp:ListItem>Recibido</asp:ListItem>
              </asp:DropDownList>
                             </EditItemTemplate>
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText="#Referencia">
                    <ItemTemplate>
                        <asp:Label ID="Label88" runat="server"
                             Text='<%# Bind("descripcion") %>'
                            Enabled="false"
                            Width="80px" />
                     
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="TextBox88" runat="server"
                             Text='<%# Bind("descripcion") %>'
                             Enabled="true"
                             Width="80px" />
                    
                    </EditItemTemplate>
                    </asp:TemplateField>
                           <%-- Botón Ver Reporte --%>
   <asp:TemplateField HeaderText="Acción">
     <ItemTemplate>
       <asp:Button
           ID="btnVerDetalleMensajero"
           runat="server"
           Text="Ver Reporte"
           CommandName="VerReporteMensajero"
           CommandArgument='<%# Eval("idpago") %>'
           CssClass="btn btn-info btn-sm" />
     </ItemTemplate>
  </asp:TemplateField>

                       </Columns>
            </asp:GridView><p />
               
               <br />
               </div>

                   <%-- Panel oculto con detalle de este mensajero --%>
<asp:Panel
    ID="pnlDetalleMensajeros"
    runat="server"
    Visible="false"
    Style="width:800px; margin:20px 0;">
  <asp:Label
      ID="lblTituloDetalleMensajeros"
      runat="server"
      CssClass="h4"
      Text="Detalle de la entrega"
      Style="display:block; margin-bottom:10px;" />
  <asp:GridView
      ID="GridViewDetalleMensajeros"
      runat="server"
      AutoGenerateColumns="false"
      CssClass="table table-striped"
      EmptyDataText="No hay detalles"
      Width="100%"
      CellSpacing="10">
    <HeaderStyle BackColor="#DD4B39" ForeColor="White" />
    <Columns>
        <asp:BoundField DataField="NoGuia"
                    HeaderText="No. Guía"
                    HeaderStyle-Width="80px"
                    ItemStyle-Width="80px" />
      <asp:BoundField DataField="IdPago"           HeaderText="ID Pago" />
      <asp:BoundField DataField="Departamento"     HeaderText="Departamento" />
      <asp:BoundField DataField="Municipio"        HeaderText="Municipio" />
      <asp:BoundField DataField="Zona"             HeaderText="Zona" />
      <asp:BoundField DataField="MontoCobrado"     HeaderText="Monto Cobrado" DataFormatString="Q{0:N2}" />
      <asp:BoundField DataField="ValorEnvio"       HeaderText="Valor Envío"   DataFormatString="Q{0:N2}" />
         <asp:BoundField DataField="ValorVisita"      HeaderText="Valor Visita"    DataFormatString="Q{0:N2}" />
    

      <asp:BoundField DataField="PagoCliente"      HeaderText="Pago al Cliente" DataFormatString="Q{0:N2}" />
      <asp:BoundField DataField="FechaHoraEntrega" HeaderText="Fecha/Hora Entrega" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
      <asp:BoundField DataField="Estado"           HeaderText="Estado" />
      <asp:BoundField DataField="Mensajero"        HeaderText="Mensajero" />
        <asp:BoundField DataField="Referencia"       HeaderText="Referencia" />
    </Columns>
  </asp:GridView>
</asp:Panel>


     

        <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" />
        
        &nbsp;&nbsp;&nbsp;&nbsp;
     

        <br/><br/></div> </div>
            </asp:Content>