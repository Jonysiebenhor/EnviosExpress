<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lector.aspx.cs" Inherits="EnviosExpress.Lector" %>


<%@ Register Src="~/DynamicData/FieldTemplates/CuwScannerCode.ascx" TagPrefix="uc2" TagName="CuwScannerCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" /> 
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Lector Código Barras</title>

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

</head>
<body>
    <form id="form1"  method="get" action="Prueba2.aspx" runat="server">

         <div class="container Formulario">
     <div class="form-row">
         <div class="col-sm-12 col-md-6 col-lg-4 order-sm-1 order-md-2 my-1">
        <div class="card h-100 bg-transparent">
    <asp:Label ID="LabeMensaje" ForeColor="White" CssClass="card-title card-header text-center p-2" runat="server" Text="N0000000000"></asp:Label>


    <div class="card-body">
        <div class="input-group-append">
                        <button type="button" id="lkbScanner" class="btn btn-sm btn-info rounded-right" onclick="AbrirModalScanner(); return false;"><i class="fa fa-barcode" aria-hidden="true"></i></button>
                    </div>
                </div>
            </div>
             </div>
         </div>
             </div>
        <uc2:CuwScannerCode runat="server" ID="CuwScannerCode" />
        
        <asp:Button ID="Button1" runat="server" Text="Button" CssClass="Ocultar" />

    </form>


</body>

<script>

</script>

</html>

