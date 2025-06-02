<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Recoleccion.aspx.cs" Inherits="EnviosExpress.Recoleccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">


        <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
             <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Recolección" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
           <div class="container text-center""row" style="background-color:#f5f5f5; ">


<br /><br />
     
        <div class="container text-center" id="reader" style ="width:300px; height:250px">
           
 <p>
            Numero de Guia:
        <asp:TextBox ID="txtcodigoo" runat="server" Width="187px"></asp:TextBox>
            </p>
            <asp:CheckBox ID="CheckBox3" Text="Marcar paquete en Ruta" runat="server" />
            <br />
        </div>
               <asp:Label ID="Label11" runat="server"></asp:Label>
               <br /><br />
     </div>
        <br />
     

     
            <asp:Button ID="Button2" runat="server" OnClick="btnrecolectar_Click" Text="Recolectar" BackColor="#339933" ForeColor="White" />
        
        
        &nbsp;&nbsp;&nbsp;&nbsp;
     

        <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" />
        
        <br/><br/>
            </div>
 
   <!--script>
        $(document).ready(function () {
            $('#reader').html5_qrcode(function (data) {
                $('#<!--%=txtcodigoo.ClientID%>').val(data);
            },
                function (error) {
                    $('#read_error').html(error);
                }, function (videoError) {
                    alert("No hay Cámara")
                }
            );
        });
    </script--> 
    </asp:Content>
