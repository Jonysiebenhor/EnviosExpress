<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="CrearCuentaAdmin.aspx.cs" Inherits="EnviosExpress.CrearCuentaAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

            <div  class="container text-center"  style="background-color:#2d2d30;  width:100%;">
            <br />
            <br />
                <br />
                <br />
            <asp:Label ID="Label1" runat="server" Text="Crear Cuenta" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
         <div class="container text-center" style="   width:70%;  background-image: url('Resources/.jpg');   background-color:ghostwhite;background-repeat :no-repeat;  position:page; z-index: auto;" >
              <p class="centrado">
                  <br />
                  <br />

            <asp:TextBox ID="txtnombre1" runat="server" placeholder="Primer Nombre" Width="200px" ></asp:TextBox>
            <br />
            <asp:Label ID="nombre1" runat="server" ></asp:Label>
            <br />
            <asp:TextBox ID="txtnombre2" runat="server" placeholder="Segundo Nombre" Width="200px"></asp:TextBox>
            <br /><br />
            <asp:TextBox ID="txtnombre3" runat="server" placeholder="Tercer Nombre" Width="200px"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtapellido1" runat="server" placeholder="Primer Apellido" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="apellido1" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtapellido2" runat="server"  placeholder="Segundo Apellido" Width="200px"></asp:TextBox>
            <br /><br />
            <asp:TextBox ID="txtapellido3" runat="server" placeholder="Apellido Casada" Width="200px"></asp:TextBox>
            <br /><br />
            <asp:TextBox ID="txtnegocio" runat="server" placeholder="Nombre del Negocio" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="negocio0" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtproducto" runat="server" placeholder="Producto que envia" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="producto0" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtdpi" runat="server"  placeholder="DPI" TextMode="Number" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="dpi0" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtdireccion" runat="server" placeholder="Dirección" TextMode="MultiLine" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="direccion0" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtcorreo" runat="server" placeholder="Correo" TextMode="Email" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="correo0" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtnit" runat="server" placeholder="Nit" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="nit0" runat="server">El NIT tiene que ser el mismo del usuario que se esta registrando.</asp:Label>
            <br />
           <asp:TextBox ID="txttelefono" runat="server" placeholder="Teléfono" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="telefono0" runat="server"></asp:Label>
            <br />
                  Nacimiento:
            <asp:TextBox ID="txtnacimiento" runat="server" placeholder="Fecha Nacimiento" TextMode="Date" Width="127px"></asp:TextBox>
            <br />
            <asp:Label ID="nacimiento0" runat="server"></asp:Label>
            <br />
                  <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                      <asp:ListItem>--Banco</asp:ListItem>
                      <asp:ListItem>Banrural (Desarrollo Rural)</asp:ListItem>
                      <asp:ListItem>BI Banco Industrial</asp:ListItem>
                      <asp:ListItem>G&amp;T Continental</asp:ListItem>
                      <asp:ListItem>BAC Credomatic</asp:ListItem>
                      <asp:ListItem>Bantrab (Trabajadores)</asp:ListItem>
                      <asp:ListItem Enabled="False">BAM (Agromercantil)</asp:ListItem>
                      <asp:ListItem>Azteca, S. A.</asp:ListItem>
                      <asp:ListItem>Antigua, S. A.</asp:ListItem>
                      <asp:ListItem>Citi</asp:ListItem>
                      <asp:ListItem>Credito Hipotecario</asp:ListItem>
                      <asp:ListItem>Banco De Credito</asp:ListItem>
                      <asp:ListItem>Inmobiliario, S. A.</asp:ListItem>
                      <asp:ListItem>Internacional, S. A.</asp:ListItem>
                      <asp:ListItem>Ficohsa, S. A.</asp:ListItem>
                      <asp:ListItem>Vivibanco, S. A.</asp:ListItem>
                  </asp:DropDownList>
            <br />
            <asp:Label ID="banconombre0" runat="server">El nombre de la cuenta bancaria tiene que ser el mismo del usuario que se esta registrando.</asp:Label>
            <br />
                  <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                      <asp:ListItem>--Tipo Cuenta</asp:ListItem>
                      <asp:ListItem>Monetaria</asp:ListItem>
                      <asp:ListItem>Ahorro</asp:ListItem>
                  </asp:DropDownList>
            <br />
            <asp:Label ID="tipocuenta0" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtbanco" runat="server" placeholder="Numero de Cuenta" Width="200px" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Label ID="banco0" runat="server"></asp:Label>
            <br />
            Rol:
            <asp:DropDownList ID="ddlRol" runat="server" Width="178px">
                <asp:ListItem Value="0">--Seleccionar</asp:ListItem>
                <asp:ListItem Value="1">Cliente</asp:ListItem>
                <asp:ListItem Value="2">Mensajero</asp:ListItem>
                <asp:ListItem Value="3">Administrador</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Rol0" runat="server"></asp:Label>
            <br />
            Activo: <asp:DropDownList ID="ddlActivo" runat="server" Width="162px">
                <asp:ListItem Value="2">--Seleccionar</asp:ListItem>
                <asp:ListItem Value="1">Si</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Activo0" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtcontraseña" runat="server" placeholder="Contraseña" TextMode="Password" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="contraseña0" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtcontraseña2" runat="server" placeholder="Confirmar Contraseña" TextMode="Password" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="contraseña20" runat="server"></asp:Label>
            <br />
                  </div>
            <br />

            <asp:Button ID="regresar" runat="server" Text="&lt; Regresar" OnClick="regresar_Click" BackColor="#FF3300" ForeColor="White" />
&nbsp;
            <asp:Button ID="crear" runat="server" OnClick="crear_Click" Text="Crear Cuenta" />
            <br />
            <br /></div>
</asp:Content>
