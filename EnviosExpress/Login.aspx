<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra2.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EnviosExpress.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
        <div class="container text-center" style="background-color:#2d2d30; height: 577px; width:100%;">
              <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Ingresar" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
         <div class="container text-center"x style="   width:230px; height: 50%; background-image: url('Resources/.jpg');   background-color:ghostwhite;background-repeat :no-repeat;  position:page; z-index: auto;" >
              <p class="centrado">
                  <br />
                  <br />
             <h>Bienvenido</h>
             <br />
            <asp:Label ID="estado0"  runat="server">D P I</asp:Label>
                  <br />
             
            <asp:TextBox ID="txtdpi" runat="server" placeholder="" Width="115px" ></asp:TextBox> 
        <br />
            <asp:Label ID="estado1"  runat="server">Contraseña</asp:Label>
            <br />
        <asp:TextBox ID="txtcontraseña" runat="server" TextMode="Password" placeholder="" Width="115px"></asp:TextBox>
           <br />
            <br />
            <asp:Label ID="estado"  runat="server"></asp:Label>
          <br />
            <br />
           
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click"  Text="Ingresar" Width="80px" BackColor="orange" BorderColor="Black" />
                   </p>
              <p class="centrado">
                  <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Crear Cuenta" Width="100px" />
                   </p> </div></div>
     </asp:Content>
