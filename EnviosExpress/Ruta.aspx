<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Ruta.aspx.cs" Inherits="EnviosExpress.Ruta" %>
<%@ Register Src="~/DynamicData/FieldTemplates/CuwScannerCode.ascx" TagPrefix="uc1" TagName="ScannerControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        #ModalScannerCode.modal {
            z-index: 1055;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <!-- Escáner reutilizable -->
    <uc1:ScannerControl ID="ScannerControl1" runat="server" />

 


    <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Ruta" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
        <br /><br />
        <div class="container text-center row" style="background-color:#f5f5f5; ">
            <br /><br />
            <div class="container text-center" id="reader" style="width:300px; height:250px">
                <p>
                    Numero de Guia:
                    <asp:TextBox ID="txtcodigoo" runat="server" Width="187px"></asp:TextBox>
                </p>
                <br />
                <br />
                            <!-- Botón para abrir modal en modo "enrutar" -->
<asp:Button ID="btnAbrirScannerRuta" runat="server"
Text="🚚 Enrutar paquetes"
CssClass="btn btn-warning"
OnClientClick="AbrirModalScanner('enrutar'); return false;" />
                <!--Fin del botón-->


            </div>
            <asp:Label ID="Label11" runat="server"></asp:Label>
            <br /><br /><br />

              

        </div>
        <br />
        <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" />
        <br /><br />
    </div>


    <!--Abre el modal de CuwScannerCode.ascx en modo "Enrutar" para escanear los códigos y ponerlos en ruta-->
    <!--script type="text/javascript">
        /*function AbrirModalScannerRuta() {
            const selectModo = document.getElementById("modoOperacion");
            if (selectModo) {
                selectModo.value = "enrutar";
            }
            AbrirModalScanner("enrutar");
        }*/
    </script-->
</asp:Content>
