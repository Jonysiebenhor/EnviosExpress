<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ConsultarGuia.aspx.cs" Inherits="EnviosExpress.ConsultarGuia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div class="container text-center" style="background-color:#2d2d30; height:100%; width:100%;">
             <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Consultar Guia" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
           <div class="container text-center""row" style="background-color:#f5f5f5; width:500px;">


<br /><br />
     
 <p>
            Numero de Guía:<br />
        <asp:TextBox ID="txtcodigoo" runat="server" Width="187px" TextMode="Number"></asp:TextBox>
            &nbsp;
     

        <asp:Button ID="btnrecolectar" runat="server" OnClick="btnrecolectar_Click" Text="Consultar" BackColor="#339933" ForeColor="White" />
            </p>
     

        &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="187px" Visible="False">
                   <asp:ListItem>--Solicitudes</asp:ListItem>
                   <asp:ListItem>Sacar a Ruta</asp:ListItem>
                   <asp:ListItem>Trasladar a Agencia</asp:ListItem>
                   <asp:ListItem>Devolución</asp:ListItem>
                   <asp:ListItem>Liquidar el Paquete</asp:ListItem>
               </asp:DropDownList>
&nbsp;&nbsp;<asp:Button ID="tnruta" runat="server" OnClick="btnruta_Click" Text="Solicitar" BackColor="#339933" ForeColor="White" Visible="False" />
               <br />
        
               <asp:Label ID="Label11" runat="server"></asp:Label>
&nbsp;
               &nbsp;&nbsp;
               <br />
         <div class="container text-left" style="   width:400px;  background-image: url('Resources/.jpg'); background-attachment:fixed;  background-color:white;background-repeat :no-repeat;  position:page; z-index: auto;" >
            
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
             <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Italic="False" Font-Overline="False" ForeColor="Black" Visible="False">Datos del Destinatario</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <br />
        
             <asp:Label ID="guia12" runat="server" Visible="False" Font-Bold="True" Font-Size="Medium" Font-Italic="False" Font-Overline="False" ForeColor="Black">Número de Guía: </asp:Label>
             <asp:Label ID="guia11" runat="server" Font-Bold="True" Font-Size="Large" Font-Italic="False" Font-Overline="False" ForeColor="Black"></asp:Label>
        
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="monto12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black" Font-Size="Medium">Monto:Q</asp:Label>
        <asp:Label ID="monto11" runat="server" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black" Font-Size="Large"></asp:Label>
        
             <br />
        
        <asp:Label ID="destinatario12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black">Nombre: </asp:Label>
             <asp:Label ID="destinatario11" runat="server" Width="100px"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:Label ID="destinatario17" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black">Nombre 2: </asp:Label>
             <asp:TextBox ID="Textnombre" runat="server" Visible="False" Width="100px"></asp:TextBox>
                     
        <br />
        <asp:Label ID="telefono12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black">Telefono: </asp:Label>
             &nbsp;<asp:Label ID="telefono11" runat="server" Width="100px"></asp:Label>
        &nbsp;&nbsp;
        <asp:Label ID="telefono17" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black">Telefono 2: </asp:Label>
             <asp:TextBox ID="Texttel" runat="server" Visible="False" Width="100px"></asp:TextBox>
             <br />
        <asp:Label ID="direccion12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black">Direccion: </asp:Label>
             &nbsp;<asp:Label ID="direccion11" runat="server" Width="100px"></asp:Label>
             &nbsp;<asp:Label ID="direccion17" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" ForeColor="Black">Direccion 2: </asp:Label>
             <asp:TextBox ID="Textdir" runat="server" Visible="False" TextMode="MultiLine" Width="100px"></asp:TextBox>
             <br />
             
            <asp:DropDownList ID="ddldepartamento" runat="server" OnSelectedIndexChanged="ddldepartamento_SelectedIndexChanged" AutoPostBack="True" Width="100px" AppendDataBoundItems="True" DataSourceID="SqlDataSource4" DataTextField="nombre" DataValueField="iddepartamento" Height="24px" Visible="False">
                <asp:ListItem Selected="True" Value="0">--Departamento</asp:ListItem>
                </asp:DropDownList>
                             <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:EnviosExpressConnectionString %>" SelectCommand="select* from departamento;"></asp:SqlDataSource>

                &nbsp;<asp:DropDownList ID="ddlmunicipio" runat="server" OnSelectedIndexChanged="ddlmunicipio_SelectedIndexChanged" AutoPostBack="True" Width="100px" AppendDataBoundItems="True" DataSourceID="SqlDataSource5" DataTextField="nombre" DataValueField="idmunicipio" Height="24px" Visible="False">
                    <asp:ListItem Selected="True" Value="0">--Municipio</asp:ListItem>
                    </asp:DropDownList>
             <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:EnviosExpressConnectionString %>" SelectCommand="SELECT [idmunicipio], [nombre] FROM [municipio] WHERE ([iddepartamento] = @iddepartamento)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddldepartamento" Name="iddepartamento" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    

                <asp:DropDownList ID="ddlzona" runat="server" OnSelectedIndexChanged="ddlzona_SelectedIndexChanged" Width="100px" AppendDataBoundItems="True" DataSourceID="SqlDataSource6" DataTextField="nombre" DataValueField="idzona" AutoPostBack="True" Height="24px" Visible="False">
                    <asp:ListItem Selected="True" Value="0">--Zona, Aldea, Lugar</asp:ListItem>
                        </asp:DropDownList>
             <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:EnviosExpressConnectionString %>" SelectCommand="SELECT [idzona], [nombre] FROM [zona] WHERE ([idmunicipio] = @idmunicipio)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlmunicipio" Name="idmunicipio" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
             <br />
        <asp:Label ID="departamento11" runat="server" Font-Bold="True" BackColor="Black" Font-Size="Medium" ForeColor="White"></asp:Label>
            &nbsp;&nbsp; <asp:Label ID="municipio11" runat="server" Font-Bold="True" BackColor="Black" Font-Size="Medium" ForeColor="White"></asp:Label>
            &nbsp;&nbsp; <asp:Label ID="zona11" runat="server" Font-Bold="True" BackColor="Black" Font-Size="Medium" ForeColor="White"></asp:Label>
        <br />
        <asp:Label ID="tipo12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Small" ForeColor="Black">Tipo:</asp:Label>
        <asp:Label ID="tipo11" runat="server" Font-Size="Small"></asp:Label>
            
                    <asp:DropDownList ID="ddlzona0" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="monto" DataValueField="idzona" OnSelectedIndexChanged="ddlzona0_SelectedIndexChanged1" BackColor="GhostWhite" Font-Overline="False" Font-Size="Smaller" Font-Strikeout="False" Font-Underline="False" ForeColor="GhostWhite" Visible="False">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EnviosExpressConnectionString %>" SelectCommand="SELECT * FROM [zona] WHERE ([idzona] = @idzona)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlzona" Name="idzona" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
            
             <br />
        <asp:Label ID="peso12" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Small" ForeColor="Black">Peso:</asp:Label>
        <asp:Label ID="peso11" runat="server" Font-Size="Small"></asp:Label>
             <br />
        <asp:Label ID="recibe" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Small" ForeColor="Black">Recibido por:</asp:Label>
        <asp:Label ID="txtrecibe" runat="server" Font-Size="Small"></asp:Label>
             <br />
             <br />
               </div>
               <br />
         <div class="container text-left" style="   width:400px;  background-image: url('Resources/.jpg'); background-attachment:fixed;  background-color:white;background-repeat :no-repeat;  position:page; z-index: auto;" >
            
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
             <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Italic="False" Font-Overline="False" ForeColor="Black" Visible="False">Datos del Remitente</asp:Label>
                &nbsp;<br />
        
        <asp:Label ID="destinatario13" runat="server" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Small" ForeColor="Black" Visible="False">Nombre:</asp:Label>
        <asp:Label ID="remitente11" runat="server" Font-Size="Small"></asp:Label>
        
             <br />
        <asp:Label ID="telefono13" runat="server" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Small" ForeColor="Black" Visible="False">Teléfono: </asp:Label>
        <asp:Label ID="telefono14" runat="server" Font-Size="Small"></asp:Label>
             <br />
        <asp:Label ID="telefono15" runat="server" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Small" ForeColor="Black" Visible="False">Dirección:</asp:Label>
        <asp:Label ID="telefono16" runat="server" Font-Size="Small"></asp:Label>
               <br />
               <br />
               </div>
                <br />
         <div class="container text-center" style="   width:400px;  background-image: url('Resources/.jpg'); background-attachment:fixed;  background-color:white;background-repeat :no-repeat;  position:page; z-index: auto;" >
            
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Estado del Paquete" Visible="False"></asp:Label>
               
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
     

     

        <asp:Button ID="btnrecolectar0" runat="server" OnClick="regresar_Click" Text="&lt; Regresar" BackColor="#FF3300" ForeColor="White" />
        
        &nbsp;&nbsp;&nbsp;&nbsp;
     

        <br/><br/></div>
    </asp:Content>
