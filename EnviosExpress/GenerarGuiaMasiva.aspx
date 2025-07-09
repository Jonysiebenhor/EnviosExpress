<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="GenerarGuiaMasiva.aspx.cs" Inherits="EnviosExpress.GenerarGuiaMasiva" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div  class="container text-center"  style="background-color:#2d2d30;  width:100%;">
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Crear Guias Masivas" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br /><br />
         <div class="container text-center" style="   width:95%;  background-image: url('Resources/.jpg');   background-color:ghostwhite;background-repeat :no-repeat;  position:page; z-index: auto;" >
              <p class="centrado">
                  <br />
                  <br />
             



         <div class="container-fluid mt-4">
                 <div class="card">
                  <div class="card-header">
                    Cargar Archivo
                  </div>
                  <div class="card-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="form-row">
                                <div class="form-group col-sm-10">
                                  <label for="FileUpload1">Archivo</label>
                                    <asp:FileUpload ID="FileUpload1" CssClass="form-control-file" runat="server" />
                                </div>
                                <div class="form-group col-sm-2">
                                  <asp:Button ID="Button5" runat="server" Text="Cargar" CssClass="btn btn-block btn-success mt-4" OnClick="Button5_Click" />
                                  
                                </div>
                            </div>
                        </div>

                    </div>
                      <hr />
                   <div class="row">
                       <div class="col-sm-12">
                           <div class="card">
                          <div class="card-header p-1">
                              <asp:Label ID="Label2" runat="server"></asp:Label>
                              <asp:Label ID="Labeldescargar" runat="server" Text="Registros Cargados" Visible="False"></asp:Label>
                               <img runat ="server" id ="imgCtrl" visible="False" />&nbsp;
                              &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="descargar" runat="server" OnClick="descargar_Click" Text="Descargar Guias" BackColor="#FF3300" ForeColor="White" Visible="False" />
                          </div>
                          <div class="card-body">
                          <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered mitabla table-hover"></asp:GridView>
                          </div>
                               <div class="card-body">&nbsp;</div>
                        </div>
                     </div>
                       
                   </div>
                  </div>
                </div>
             <asp:GridView ID="GridView3" runat="server"></asp:GridView>
        </div>

        
        <%--<div>
            
            <br />
            <br />
           
        </div>
        <br />
        <div>
            <asp:Label ID="lblrespuesta" runat="server"></asp:Label>
        </div>--%>
        






             <br />
        </div>
         <p class="centrado">   
             <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="&lt; Regresar" OnClick="Button3_Click" BackColor="#FF3300" ForeColor="White" />
      
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      
        
        &nbsp;<p /></div>
    </asp:Content>
