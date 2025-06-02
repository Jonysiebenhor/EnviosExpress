<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="EnviosExpress.prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<script src="js/jquery-1.9.1.min.js"></script>
<script src="js/html5-qrcode.min.js"></script>

<body>
    <form id="form1" runat="server">
        <div id="reader"  style="width:300px; height:300px; background-color:black;">
            <asp:TextBox ID="txtcodigoo" runat="server"></asp:TextBox>
        </div>
    </form>

      <script>
       $(document).ready(function () {
           $('#reader').html5_qrcode(function (data) {
               $('#<%=txtcodigoo.ClientID%>').val(data);
           },
               function (error) {
                   $('#read_error').html(error);
               }, function (videoError) {
                   alert("No hay Cámara")
               }
           );
       });
      </script> 


</body>
</html>
