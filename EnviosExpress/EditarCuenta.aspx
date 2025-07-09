<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="EditarCuenta.aspx.cs" Inherits="EnviosExpress.EditarCuenta" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">




            <div  class="container text-center"  style="background-color:#2d2d30;  width:100%;">
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Editar Cuenta" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
         <div class="container text-center" style="   width:400px;  background-image: url('Resources/.jpg');   background-color:ghostwhite;background-repeat :no-repeat;  position:page; z-index: auto;" >
              <p class="centrado">
                  <br />
                  <br />
            Ingrese el DPI del Usuario a Actualizar:
                  <br />
                  <asp:TextBox ID="txtdpi00" runat="server" Width="200px"></asp:TextBox><br />
<br /><asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Consultar" />
            <br />
            <asp:Label ID="dpi000" runat="server"></asp:Label>
            <br />
            Primer Nombre:<br />
            <asp:TextBox ID="txtnombre1" runat="server" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="nombre1" runat="server"></asp:Label>
            <br />
            Segundo Nombre:<br />
            <asp:TextBox ID="txtnombre2" runat="server" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <br />
            Tercer Nombre:<br />
            <asp:TextBox ID="txtnombre3" runat="server" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <br />
            Primer Apellido:<br /><asp:TextBox ID="txtapellido1" runat="server" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="apellido1" runat="server"></asp:Label>
            <br />
            Segundo Apellido:<br /><asp:TextBox ID="txtapellido2" runat="server" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            
            Apellido Casada:<br />
            <asp:TextBox ID="txtapellido3" runat="server" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <br />
            Nombre del Negocio:<br /><asp:TextBox ID="txtnegocio" runat="server" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="negocio0" runat="server"></asp:Label>
            <br />
            Tipo de Producto que Envia:<br />
            <asp:TextBox ID="txtproducto" runat="server" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="producto0" runat="server"></asp:Label>
            <br />
            DPI: <br /><asp:TextBox ID="txtdpi" runat="server" Enabled="False" TextMode="Number" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="dpi0" runat="server"></asp:Label>
            <br />
            Direccion:<br />
            <asp:TextBox ID="txtdireccion" runat="server" TextMode="MultiLine" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="direccion0" runat="server"></asp:Label>
            <br />
            Correo:<br /><asp:TextBox ID="txtcorreo" runat="server" TextMode="Email" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="correo0" runat="server"></asp:Label>
            <br />
            Nit:<br />
            <asp:TextBox ID="txtnit" runat="server" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="nit0" runat="server"></asp:Label>
            <br />
            Teléfono:<br />
            <asp:TextBox ID="txttelefono" runat="server" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="telefono0" runat="server"></asp:Label>
            <br />
            Fecha de Nacimiento:<br /><asp:TextBox ID="txtnacimiento" runat="server" TextMode="Date" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="nacimiento0" runat="server"></asp:Label>
            <br />
            Nombre del Banco:<br />
            <asp:TextBox ID="txtbanconombre" runat="server" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="banconombre0" runat="server"></asp:Label>
            <br />
            Tipo de Cuenta:<br />
            <asp:TextBox ID="txttipocuenta" runat="server" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="tipocuenta0" runat="server"></asp:Label>
            <br />
            Cuenta Bancaria:<br /><asp:TextBox ID="txtbanco" runat="server" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="banco0" runat="server"></asp:Label>
            <br />
            Rol:<br />
            <asp:DropDownList ID="ddlRol" runat="server" Enabled="False" Width="200px">
                <asp:ListItem Value="0">--Seleccionar</asp:ListItem>
                <asp:ListItem Value="1">Cliente</asp:ListItem>
                <asp:ListItem Value="2">Mensajero</asp:ListItem>
                <asp:ListItem Value="3">Administrador</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Rol0" runat="server"></asp:Label>
            <br />
            Activo:<br />
            <asp:DropDownList ID="ddlActivo" runat="server" Enabled="False" Width="200px">
                <asp:ListItem Value="2">--Seleccionar</asp:ListItem>
                <asp:ListItem Value="1">Si</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Activo0" runat="server"></asp:Label>
            <br />
            Contraseña:<br /><asp:TextBox ID="txtcontraseña" runat="server" TextMode="Password" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="contraseña0" runat="server"></asp:Label>
            <br />
            Confirmar Contraseña:<br /><asp:TextBox ID="txtcontraseña2" runat="server" TextMode="Password" Enabled="False" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="contraseña20" runat="server"></asp:Label>
            <br /></div>
            <br />
            <asp:Button ID="Button4" runat="server" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" OnClick="Button4_Click" />
&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Limpiar" BackColor="#FF9900" ForeColor="White" OnClick="Button3_Click" />
&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Editar Cuenta" Enabled="False" />
        <br />
            <br /></div>
    </asp:Content>
