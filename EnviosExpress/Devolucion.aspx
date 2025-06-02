<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Devolucion.aspx.cs" Inherits="EnviosExpress.Devolucion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
             <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Devolución" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
           <div class="container text-center""row" style="background-color:#f5f5f5; ">


<br /><br />
     
        <div class="container text-center" id="reader" style ="width:300px; height:250px">
            <p>
            Numero de Guia:
        <asp:TextBox ID="txtcodigoo" runat="server" Width="187px"></asp:TextBox>
            </p>
           
            <p>
                <asp:Label ID="Label12" runat="server" Text="Recibido por:" Visible="False"></asp:Label>
            </p>
            <p>
        <asp:TextBox ID="txtrecibido" runat="server" Width="187px" Visible="False"></asp:TextBox>
            </p>
            <br />
        </div>
               <br />
               Dellar Motivo de Devolución:
               <br />
               <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                   <asp:ListItem Value="--Seleccionar">--Seleccionar</asp:ListItem>
                   <asp:ListItem>Entregado</asp:ListItem>
                   <asp:ListItem Value="No Quizo Recibir">No Quizo Recibir</asp:ListItem>
                   <asp:ListItem>Remitente lo Solicito</asp:ListItem>
                   <asp:ListItem Value="No Contesta LLamadas">No Contesta LLamadas</asp:ListItem>
                   <asp:ListItem>No Llego a Punto de Encuentro</asp:ListItem>
                   <asp:ListItem>No esta de Acuerdo Con el Precio</asp:ListItem>
                   <asp:ListItem>No Recibe Fines de Semana</asp:ListItem>
                   <asp:ListItem>Ya No Lo Desea</asp:ListItem>
                   <asp:ListItem>Nadie En Casa</asp:ListItem>
                   <asp:ListItem>Dirección Incorrecta</asp:ListItem>
                   <asp:ListItem>Lugar Muy Retirado</asp:ListItem>
                   <asp:ListItem>Desperfectos Mecanicos</asp:ListItem>
                   <asp:ListItem>Bloqueos, Derrumbes, Manifestaciones</asp:ListItem>
               </asp:DropDownList>
               <br />
               <asp:Label ID="Label11" runat="server"></asp:Label>
               <br /><br />
     </div>
        <br />
     

     

        <asp:Button ID="btnrecolectar" runat="server" OnClick="btnrecolectar_Click" Text="Devolución" BackColor="#339933" ForeColor="White" />
        
        &nbsp;&nbsp;&nbsp;&nbsp;
     

     

        <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" />
        
        &nbsp;&nbsp;&nbsp;&nbsp;
     

        <br/><br/>
        </div>
    </asp:Content>


