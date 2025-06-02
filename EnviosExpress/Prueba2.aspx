<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra2.Master" AutoEventWireup="true" CodeBehind="Prueba2.aspx.cs" Inherits="EnviosExpress.Prueba2" %>

<asp:Content ID="Content4" ContentPlaceHolderID="title" runat="server">
    Envios Express
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="body" runat="server">


    <div>
    <asp:GridView ID="gd1" runat="server"> </asp:GridView>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
</asp:Content>
