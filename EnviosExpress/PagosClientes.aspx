<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="PagosClientes.aspx.cs" Inherits="EnviosExpress.PagosClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
             <br />
            <br />
           <div class="container text-center""row" style="background-color:#f5f5f5; width:500px;">
               <br />
               <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Transferencias" Visible="True"></asp:Label>
<br />
     
 <p>
            <br />
        Desde: <asp:TextBox ID="txtfecha1" runat="server" Width="100px" TextMode="Date"></asp:TextBox>&nbsp;
      a: <asp:TextBox ID="txtfecha2" runat="server" Width="100px" TextMode="Date"></asp:TextBox>
            &nbsp;
     

        <asp:Button ID="btnrecolectar" runat="server" OnClick="btnrecolectar_Click" Text="Consultar" BackColor="#339933" ForeColor="White" />
            </p>
     
               <asp:Label ID="Label11" runat="server"></asp:Label>
&nbsp;
               &nbsp;&nbsp;
               <br />
                <br />
         <div class="container text-center" style="   width:400px;  background-image: url('Resources/.jpg'); background-attachment:fixed;  background-color:white;background-repeat :no-repeat;  position:page; z-index: auto;" >
            
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                   
               
               <p />
               <asp:GridView ID="GridView5" runat="server" ForeColor="Black" CellSpacing="10" HorizontalAlign="Center" GridLines="Horizontal" CellPadding="10" Width="380px" >
                   <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <EditRowStyle HorizontalAlign="Center" />
                <HeaderStyle BackColor="#FF6600" Font-Bold="True" Font-Italic="False" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Width="600px" Wrap="True" />
                   <RowStyle HorizontalAlign="Center" />
                <SelectedRowStyle BorderStyle="Solid" HorizontalAlign="Center" />
                   <SortedAscendingHeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <SortedDescendingHeaderStyle HorizontalAlign="Center" />
            </asp:GridView>
             </div>
            <br />
        
               <br /><br />
     </div>
        <br />
     

     

        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" />
        
        &nbsp;&nbsp;&nbsp;&nbsp;
     

        <br/><br/></div>
    </asp:Content>
