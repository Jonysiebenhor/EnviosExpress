<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra2.Master" AutoEventWireup="true" CodeBehind="GenerarGuiaP.aspx.cs" Inherits="EnviosExpress.GenerarGuiaP" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div  class="container text-center"  style="background-color:#2d2d30;  width:100%;">
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Crear Guia" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
         <div class="container text-center" style="   width:65%;  background-image: url('Resources/.jpg');   background-color:ghostwhite;background-repeat :no-repeat;  position:page; z-index: auto;" >
              <p class="centrado">
                  <br />
                  <br />
             <asp:TextBox ID="txtremitente" runat="server" placeholder="Nombre Remitente" Width="200px"></asp:TextBox>
            <br />
             <asp:Label ID="Remitente0" runat="server"></asp:Label>
            <br />
             <asp:TextBox ID="txtdestinatario" runat="server" placeholder="Nombre Destinatario" Width="200px"></asp:TextBox>
            <br />
             <asp:Label ID="Destinatario0" runat="server"></asp:Label>
             
             
              <p class="centrado">
             
            <asp:DropDownList ID="ddldepartamento" runat="server" OnSelectedIndexChanged="ddldepartamento_SelectedIndexChanged" AutoPostBack="True" Width="200px" AppendDataBoundItems="True" DataSourceID="SqlDataSource4" DataTextField="nombre" DataValueField="iddepartamento" Height="24px">
                <asp:ListItem Selected="True" Value="0">--Departamento</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:EnviosExpressConnectionString %>" SelectCommand="select* from departamento;"></asp:SqlDataSource>
           <br />
             <asp:Label ID="Departamento0" runat="server"></asp:Label>
             <br />
                <p class="centrado">
               
                <asp:DropDownList ID="ddlmunicipio" runat="server" OnSelectedIndexChanged="ddlmunicipio_SelectedIndexChanged" AutoPostBack="True" Width="200px" AppendDataBoundItems="True" DataSourceID="SqlDataSource5" DataTextField="nombre" DataValueField="idmunicipio" Height="24px">
                    <asp:ListItem Selected="True" Value="0">--Municipio</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:EnviosExpressConnectionString %>" SelectCommand="SELECT [idmunicipio], [nombre] FROM [municipio] WHERE ([iddepartamento] = @iddepartamento)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddldepartamento" Name="iddepartamento" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                 <br />
             <asp:Label ID="Municipio0" runat="server"></asp:Label>
             <br />
                <p class="centrado">
                    

                <asp:DropDownList ID="ddlzona" runat="server" OnSelectedIndexChanged="ddlzona_SelectedIndexChanged" Width="200px" AppendDataBoundItems="True" DataSourceID="SqlDataSource6" DataTextField="nombre" DataValueField="idzona" AutoPostBack="True" Height="24px">
                    <asp:ListItem Selected="True" Value="0">--Zona, Aldea, Lugar</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:EnviosExpressConnectionString %>" SelectCommand="SELECT [idzona], [nombre] FROM [zona] WHERE ([idmunicipio] = @idmunicipio)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlmunicipio" Name="idmunicipio" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    <br />
<asp:Label ID="Zona0" runat="server"></asp:Label>
                    <br />
            
                    <asp:DropDownList ID="ddlzona0" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="monto" DataValueField="idzona" OnSelectedIndexChanged="ddlzona0_SelectedIndexChanged1" BackColor="GhostWhite" Font-Overline="False" Font-Size="Smaller" Font-Strikeout="False" Font-Underline="False" ForeColor="GhostWhite">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
            
             <asp:Label ID="tarifaenvio" runat="server" Text="Tarifa de Envio:  Q" Visible="False"></asp:Label>
                        &nbsp;<asp:Label ID="montoenvio" runat="server"></asp:Label>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EnviosExpressConnectionString %>" SelectCommand="SELECT * FROM [zona] WHERE ([idzona] = @idzona)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlzona" Name="idzona" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                  
              <p class="centrado">

                
            <asp:TextBox ID="txtdireccion" runat="server" Height="62px" placeholder="Direccion" Width="200px" TextMode="MultiLine"></asp:TextBox>
            <br />
             <asp:Label ID="Direccion0" runat="server"></asp:Label>
            <br />
             <asp:TextBox ID="txttelefono" runat="server" placeholder="Teléfono" Width="200px"></asp:TextBox>
        
              <p class="centrado">
        
        <asp:Label ID="Telefono0" runat="server"></asp:Label>
           
                  <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                      <asp:ListItem>--Peso</asp:ListItem>
                      <asp:ListItem>1-8 Libras</asp:ListItem>
                      <asp:ListItem>9-20 Libras</asp:ListItem>
                      <asp:ListItem>21-50 Libras</asp:ListItem>
                      
                  </asp:DropDownList>
             <br />
             <asp:Label ID="Peso0" runat="server"></asp:Label>
             <br />
            <asp:DropDownList ID="DropDownList4" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" AutoPostBack="True" Width="200px">
                <asp:ListItem Value="--Tipo de Servicio">--Tipo de Servicio</asp:ListItem>
                <asp:ListItem Value="Estandar">Estandar</asp:ListItem>
                <asp:ListItem Value="Pago Contra Entrega">Pago Contra Entrega</asp:ListItem>
                <asp:ListItem Value="Pagar Solo Envio">Pagar Solo Envio</asp:ListItem>
            </asp:DropDownList>
            
            <br />
             <asp:Label ID="Tipo0" runat="server"></asp:Label>
            <br />
             <asp:Label ID="Montoacobrar" runat="server" Text="Monto a Cobrar:  Q" Visible="False"></asp:Label>
           
             <asp:TextBox ID="txtmontos" runat="server" Visible="False" TextMode="Number" Width="65px"></asp:TextBox>
             <br />
             <asp:Label ID="Monto00" runat="server"></asp:Label>
             <br />
        </div>
         <p class="centrado">   
             <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="&lt; Regresar" OnClick="Button3_Click" BackColor="#FF3300" ForeColor="White" />
      
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      
        <asp:Button ID="Button4" runat="server" Text="Crear Guia" OnClick="Button4_Click" BackColor="#00CC00" ForeColor="White" />
        &nbsp;<p /></div>
      </asp:Content>

