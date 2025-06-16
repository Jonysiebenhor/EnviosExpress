<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Entrega.aspx.cs" Inherits="EnviosExpress.Entrega" %>
<%@ Register Src="~/DynamicData/FieldTemplates/CuwScannerCode.ascx" TagPrefix="uc2" TagName="CuwScannerCode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1" />
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

 <link rel="stylesheet" href="fontawesome/css/font-awesome.min.css" />
 <script src="bootstrap/js/popper.min.js"></script>

 <script src="js/jquery-3.3.1.min.js"></script>
 <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
 <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>

 <link href="css/Central.css" rel="stylesheet" />
 <style>
     .bgTituloDocumento {
         -webkit-box-shadow: inset 0px 0px 22px 1px rgba(0,0,0,0.45);
         -moz-box-shadow: inset 0px 0px 22px 1px rgba(0,0,0,0.45);
         box-shadow: inset 0px 0px 22px 1px rgba(0,0,0,0.45);
     }
 </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
             <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Entrega" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
           <div class="container text-center""row" style="background-color:#f5f5f5; ">


<br /><br />



    <div class="input-group-append">
         <button type="button" id="lkbScanner" class="btn btn-sm btn-info" onclick="AbrirModalScanner('entregar'); return false;">
    <i class="fa fa-barcode" aria-hidden="true"></i> Escanear paquetes para entrega
</button>


    </div>
    <uc2:CuwScannerCode runat="server" ID="CuwScannerCode" />
    <asp:Button ID="Button2" runat="server" Text="Button" CssClass="Ocultar" />




 <p>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            Numero de Guia:
        <asp:TextBox ID="txtcodigoo" runat="server" Width="187px"></asp:TextBox>
            </p>
           
 <p>
            Recibido Por:
            </p>
            <p>
        <asp:TextBox ID="txtrecibido" runat="server" Width="187px"></asp:TextBox>
            </p>
            <br />
        </div>
               <asp:Label ID="Label11" runat="server"></asp:Label>
               <br /><br />
     </div>
        <br />
     

     

        <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" />
        
        &nbsp;&nbsp;&nbsp;&nbsp;
     

        <asp:Button ID="btnrecolectar" runat="server" OnClick="btnrecolectar_Click" Text="Entregar" BackColor="#339933" ForeColor="White" />
        
        <br/><br/></div>
    
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
