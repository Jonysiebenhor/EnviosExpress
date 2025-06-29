﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="PagosAdmin.aspx.cs" Inherits="EnviosExpress.PagosAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">


        <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
            <div class="container text-center" style="background-color:#e1dddd; height:90%; width:90%;">
             <br /><br />
           
               <div class="container text-center" style="background-color:#e1dddd; height:90%; width:90%;">
             <br /><br />
           <div class="container text-center""row" style="background-color:#f5f5f5; width:600px;">


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
                   <asp:GridView ID="GridView2" runat="server" ForeColor="Black" CellSpacing="10" HorizontalAlign="Center"
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
                     <asp:Label ID="Label7" runat="server" Text='<% # Bind("dpi") %>' Enabled="false" Width="80px"></asp:Label>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox7" runat="server" Text='<% # Bind("dpi") %>' Enabled="false" Width="80px"></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>

              <asp:TemplateField HeaderText="Cliente">
               <ItemTemplate>
                 <asp:Label ID="Label8" runat="server" Text='<% # Bind("Cliente") %>' Enabled="false" Width="80px"></asp:Label>
               </ItemTemplate>
                <EditItemTemplate>
                <asp:TextBox ID="TextBox8" runat="server" Text='<% # Bind("Cliente") %>' Enabled="false" Width="80px"></asp:TextBox>
               </EditItemTemplate>
              </asp:TemplateField>

              <asp:TemplateField HeaderText="Negocio">
               <ItemTemplate>
                 <asp:Label ID="Label9" runat="server" Text='<% # Bind("Negocio") %>' Enabled="false" Width="80px"></asp:Label>
               </ItemTemplate>
                <EditItemTemplate>
                <asp:TextBox ID="TextBox9" runat="server" Text='<% # Bind("Negocio") %>' Enabled="false" Width="80px"></asp:TextBox>
               </EditItemTemplate>
              </asp:TemplateField>

              <asp:TemplateField HeaderText="Monto">
               <ItemTemplate>
                 <asp:Label ID="Label10" runat="server" Text='<% # Bind("Monto") %>' Enabled="false" Width="80px"></asp:Label>
               </ItemTemplate>
                <EditItemTemplate>
                <asp:TextBox ID="TextBox10" runat="server" Text='<% # Bind("Monto") %>' Enabled="false" Width="80px"></asp:TextBox>
               </EditItemTemplate>
              </asp:TemplateField>

            <asp:TemplateField HeaderText="#Referencia">
                <ItemTemplate>
                <asp:Label ID="Label11" runat="server" Text="" Enabled="false" Width="80px"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
             <asp:TextBox ID="TextBox11" runat="server" Text="" Enabled="true" Width="80px"></asp:TextBox>
            </EditItemTemplate>
            </asp:TemplateField>

         </Columns>


            </asp:GridView><p />
               <br />
               </div>
 <br /> 
                              <div class="container text-center""row" style="background-color:#f5f5f5; width:600px;">


<br /><br />
     <asp:Label ID="Label11" runat="server" Text="Pagos de Clientes Liquidados" Font-Bold="True" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
 <p>
                          Desde: <asp:TextBox ID="txtfecha3" runat="server" Width="100px" TextMode="Date"></asp:TextBox>&nbsp;
a: <asp:TextBox ID="txtfecha4" runat="server" Width="100px" TextMode="Date"></asp:TextBox>
           &nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="btn2_Click" Text="Consultar" BackColor="#339933" ForeColor="White" />
               <br />
            <br />
               <p class="centrado">
                   <asp:GridView ID="GridView3" runat="server" ForeColor="Black" CellSpacing="10" HorizontalAlign="Center">

                       <HeaderStyle BackColor="#FF6600" Font-Bold="True" Font-Italic="False" ForeColor="White" />
<SelectedRowStyle BorderStyle="Solid" />

                          


            </asp:GridView><p />
               <br />
               </div>
 <br /> 
                <div class="container text-center""row" style="background-color:#f5f5f5; width:600px;">


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
                       OnRowUpdating="RowUpdatingEvent" 
                       OnRowEditing="RowEditingEvent" AutoGenerateEditButton="true"
                       OnRowCancelingEdit="RowCancelingEvent" AutoGenerateColumns="false" >
                       
                       <HeaderStyle BackColor="#FF6600" Font-Bold="True" Font-Italic="False" ForeColor="White" />
                <SelectedRowStyle BorderStyle="Solid" />

                       <Columns>
                           <asp:TemplateField HeaderText="IdPago">
                               <ItemTemplate>
                                   <asp:Label ID="Label3" runat="server" Text='<% # Bind("idpago") %>' Enabled="false" Width="80px"></asp:Label>
                               </ItemTemplate>
                               <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<% # Bind("idpago") %>' Enabled="false" Width="80px"></asp:TextBox>

                               </EditItemTemplate>
                           </asp:TemplateField>

                            <asp:TemplateField HeaderText="Mensajero">
                             <ItemTemplate>
                               <asp:Label ID="Label4" runat="server" Text='<% # Bind("Mensajero") %>' Enabled="false" Width="80px"></asp:Label>
                             </ItemTemplate>
                              <EditItemTemplate>
                              <asp:TextBox ID="TextBox4" runat="server" Text='<% # Bind("Mensajero") %>' Enabled="false" Width="80px"></asp:TextBox>
                             </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Fecha">
                             <ItemTemplate>
                               <asp:Label ID="Label5" runat="server" Text='<% # Bind("Fecha") %>' Enabled="false" Width="80px"></asp:Label>
                             </ItemTemplate>
                              <EditItemTemplate>
                              <asp:TextBox ID="TextBox5" runat="server" Text='<% # Bind("Fecha") %>' Enabled="false" Width="80px"></asp:TextBox>
                             </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Monto">
                             <ItemTemplate>
                               <asp:Label ID="Label6" runat="server" Text='<% # Bind("Monto") %>' Enabled="false" Width="80px"></asp:Label>
                             </ItemTemplate>
                              <EditItemTemplate>
                              <asp:TextBox ID="TextBox6" runat="server" Text='<% # Bind("Monto") %>' Enabled="false" Width="80px"></asp:TextBox>
                             </EditItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="Estado">
                             <ItemTemplate>
                               <asp:Label ID="Label77" runat="server" Text='<% # Bind("Estado") %>' Enabled="false" Width="80px"></asp:Label>
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
                      <asp:Label ID="Label88" runat="server" Text='<% # Bind("descripcion") %>' Enabled="false" Width="80px"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox ID="TextBox88" runat="server" Text='<% # Bind("descripcion") %>' Enabled="true" Width="80px"></asp:TextBox>
                    </EditItemTemplate>
                    </asp:TemplateField>


                       </Columns>
            </asp:GridView><p />
               
               <br />
               </div>

     

        <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" />
        
        &nbsp;&nbsp;&nbsp;&nbsp;
     

        <br/><br/></div> </div>
            </asp:Content>