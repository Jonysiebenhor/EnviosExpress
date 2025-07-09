<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra2.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="EnviosExpress.MenuPrincipal" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">






<div id="myCarousel" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
  </ol>

  <!-- Wrapper for slides -->

  <div class="carousel-inner" role="listbox">
    <div class="item active">
        <p class="centrado">
      <img src="Imagenes/paquete3.jpg" alt="New York" style="height:100%;width:80%;">
      </p>
            <div class="carousel-caption">
        <h3>RAPIDEZ</h3>
        <p>Entregas a la ciudad el mismo dia y departamentos al dia siguiente.</p>
      </div>
    </div>

    <div class="item">
<p class="centrado">
      <img src="Imagenes/paquete2.jpg" alt="New York" style="height:100%;width:80%;">
      </p>      
        <div class="carousel-caption">
        <h3>CONFIANZA</h3>
        <p>Garantizamos la integridad de sus paquetes.</p>
      </div>
    </div>

    <div class="item">
<p class="centrado">
      <img src="Imagenes/paquete1.jpg" alt="New York" style="height:100%;width:80%;">
      </p>      <div class="carousel-caption">
        <h3>Servicios</h3>
        <p>Pago contra entrega y Estandar</p>
      </div>
    </div>
  </div>

  <!-- Left and right controls -->
  <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>


<div class="row text-center">
  <div class="col-sm-4">
    <div class="thumbnail">
      <img src="Imagenes/antigua.jpg" alt="Paris"Style=" height:200px;width:200px;">
      <p><strong>ESTANDAR</strong></p>
      <p>Se hace solo la entrega del paquete. Esta es una opción confiable y económica para el envio de cartas, documentos, paquetería, o lo que necesite enviar.</p>
    </div>
  </div>
  <div class="col-sm-4">
    <div class="thumbnail">
      <img src="Imagenes/cod.jpg" alt="New York"Style=" height:200px;width:200px;">
      <p><strong>PAGO CONTRA ENTREGA</strong></p>
      <p>Se hace la entrega del envio y se COBRA el valor del paquete que se está entregando al destinatario. Posteriormente le depositamos una liquidación de los cobros efectuados.</p>
    </div>
  </div>
  <div class="col-sm-4">
    <div class="thumbnail">
        <img src="Imagenes/guat.jpg" alt="San Francisco"Style=" height:200px;width:200px;">
      <p><strong>COLLECT</strong></p>
      <p>Se entrega el paquete y el destinatario solo paga el valor del envio.</p>
    </div>
  </div>
</div>
</div>




<script>
    $(document).ready(function () {
        // Initialize Tooltip
        $('[data-toggle="tooltip"]').tooltip();
    })
</script> 

</asp:Content>
