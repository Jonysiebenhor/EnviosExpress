<%@ Control Language="C#" CodeBehind="CuwScannerCode.ascx.cs" Inherits="EnviosExpress.DynamicData.FieldTemplates.CuwScannerCode" %>

<asp:Literal runat="server" ID="Literal1" Text="<%# FieldValueString %>" />

<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

<script src="https://unpkg.com/html5-qrcode"></script>
<link rel="stylesheet" href="https://cdn.datatables.net/2.1.8/css/dataTables.dataTables.css" />

<!-- Bootstrap 4 (CSS y JS necesarios para modales) -->
<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />


<!-- jQuery -->
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

<!--Bootstrap JS-->
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js"></script>



<!-- Modal Scanner Code-->
<div class="modal" id="ModalScannerCode" tabindex="-1" role="dialog" aria-labelledby="ModalScannerCodeLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-centered " role="document">
        <div class="modal-content">
            <div class="modal-header P-2">
                <h6 class="modal-title" id="lblTitulo" runat="server"><strong>Recolectar paquetes</strong></h6>
                <label class="switch ml-2">
                    <asp:CheckBox ID="chkOnOff" runat="server" Enabled="false" Visible="false" Checked="false" />
                    <span class="slider round"></span>
                </label>

                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body p-4">
                <!--***************************************************-->
                <div class="row">
                    <div class="col-12" style="text-align: center;">
                        <div id="reader" style="display: inline-block; position: relative; padding: 0px; width: 350px"></div>
                    </div>
                </div>
                <div class="form-group form-row">
                    <div class="col">
                        <asp:TextBox ID="txtResultado" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                    </div>
                </div>

                <div class="form-row">
                    <div class="col-10">
                        <select name="Camaras" id="Camaras" class="form-control form-control-sm">
                        </select>
                    </div>
                    <div class="col-2">
                        <button id="Interruptor" type="button" class="btn btn-sm btn-info form-control  form-control-sm"><i class="" aria-hidden="true"></i></button>
                    </div>
                </div>




                <div class="form-group form-row">
                    <div class="col text-center">
                    </div>
                </div>

                <asp:Button ID="btnDevolver" runat="server" Text="" UseSubmitBehavior="False" CssClass="Ocultar" />

                <asp:Label ID="lblMessage" runat="server" class="alert alert-danger d-block" />

                
                                <!--Para mostrar los códigos escaneados:-->
               <div class="text-right mb-2">
  <h2><span class="badge badge-primary">Códigos escaneados: <span id="contadorCodigos">0</span></span></h2>
</div>

                <!--Tabla-->
                <table class="table" id="tablaQr">
                   <thead>
    <tr>
        <th scope="col">#</th>
        <th scope="col">Código</th>
        <th scope="col">Fecha y Hora</th>
    </tr>
</thead>

                   <tbody id="items">
</tbody>

<!-- Mueve el template aquí afuera -->
<template id="template-items">
    <tr>
        <th scope="row">0</th>
        <td><input name="entrada[0]"></td>
    </tr>
</template>


<tfoot>
    <tr id="footer"></tr>
</tfoot>
<template id="template-footer-content">
    <th scope="row">Total</th>
    <td>
        <button class="btn btn-danger btn-sm" id="vaciar-items" type="button">Vaciar</button>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </td>
</template>
                </table>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:GridView ID="gd1" runat="server">
                                       <Columns>
         <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
    <asp:TemplateField HeaderText="DPI">
        <ItemTemplate>
            <asp:Label ID="dpi" Text='<% # Eval("dpi") %>'  runat="server"  Enabled="false" Width="80px"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

</Columns>
                </asp:GridView>
                
                <!--***************************************************-->
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" onclick="limpiarTablaYMemoria()">Vaciar tabla</button>
                <button type="button" id="btnEnviarDatos" runat="server" class="btn btn-success" onclick="hola()">Enviar datos</button>
                 <button type="button" class="btn btn-secondary" onclick="$('#ModalScannerCode').modal('hide')">Cerrar</button>

            </div>
        </div>
    </div>
</div>


<!-- Aquí empieza la función del JS -->
<script type="text/javascript">

    
    var html5QrCode;
    let lblmensaje = document.getElementById('<%=lblMessage.ClientID %>');

    // Variables para manejar la tabla de resultados
    let id = 0
    const templateCarrito = document.getElementById('template-items').content
    const fragment = document.createDocumentFragment()
    const items = document.getElementById('items')
    const footer = document.getElementById('footer')
    const templateFooter = document.getElementById('template-footer-content').content;
    const codigosEscaneados = new Set(); // ya existe
    const colaCodigosEscaneados = [];    // <-- nueva cola


    // Reproduce sonido al escanear exitosamente
    function sonido() {
        const audio = new Audio("../Multimedia/Audio/beep.mp3");
        audio.play();
    }

    // Función para abrir el modal del scanner
    async function AbrirModalScanner() {
        try {
            // Resetear variables
            colaCodigosEscaneados.length = 0;
            codigosEscaneados.clear();
            document.getElementById("items").innerHTML = "";
            id = 0;
            document.getElementById("<%=txtResultado.ClientID%>").value = "";
            lblmensaje.innerHTML = "";
            lblmensaje.setAttribute('style', 'display:none !important');

            // Resetear manualmente estado del modal (por si quedó "incompleto")
            const modal = document.getElementById("ModalScannerCode");
            modal.classList.remove("show");
            modal.style.display = "none";
            modal.setAttribute("aria-hidden", "true");

            // MOSTRAR modal correctamente
            $('#ModalScannerCode').modal({
                backdrop: 'static',
                keyboard: false
            });

            // Cargar cámaras
            ListarCamaras("Camaras");

            const CamaraId = await GetIdCamaraApropiada();
            if (CamaraId.length > 0) {
                $("#Camaras option[value='" + CamaraId + "']").attr("selected", true);
                AbrirCamara(CamaraId); // Iniciar cámara
            }
        } catch (err) {
            console.error("❌ Error al abrir el modal del scanner:", err);
            Swal.fire("Error", "No se pudo abrir el escáner correctamente.", "error");
        }
    }

    // Al cerrar el modal: detener cámara, limpiar códigos y campo de texto
    $('#ModalScannerCode').on('hidden.bs.modal', function (e) {
        StopCamara(); // Detener cámara
        codigosEscaneados.clear(); // Limpiar códigos escaneados
        document.getElementById("<%=txtResultado.ClientID%>").value = ""; // Limpiar campo de resultado
    });

    // Lista todas las cámaras disponibles
    function ListarCamaras(domElement) {
        html5QrCode = new Html5Qrcode("reader");
        Html5Qrcode.getCameras().then(devices => {
            var select = document.getElementsByName(domElement)[0];
            $("#Camaras").empty();

            for (device of devices) {
                if (device.label) {
                    var option = document.createElement("option");
                    option.text = device.label;
                    option.value = device.id;
                    select.add(option);
                }
            }
        }).catch(err => {
            lblmensaje.setAttribute('style', 'display:block !important');
            lblmensaje.innerHTML = err;
        });
    }

    //Detecta la cámara apropiada
    function GetIdCamaraApropiada() {
        return new Promise(resolve => {
            html5QrCode = new Html5Qrcode("reader");
            Html5Qrcode.getCameras().then(devices => {
                let CamaraEncontrada;

                if (devices.length === 1) {
                    CamaraEncontrada = devices[0].id;
                } else {
                    for (device of devices) {
                        if (device.label && device.label.includes("back")) {
                            CamaraEncontrada = device.id;
                            break;
                        }
                    }
                    if (CamaraEncontrada === undefined) {
                        CamaraEncontrada = devices[0].id;
                    }
                }
                resolve(CamaraEncontrada);
            }).catch(err => {});
        });
    }

    // Controla el botón para iniciar o detener la cámara
    function EstadoBoton(estado) {
        var btn = document.getElementById("Interruptor");
        var i = btn.querySelector("i");
        var combo = document.getElementById("Camaras");

        if (estado === 0) {
            btn.setAttribute("onclick", "AbrirCamara()");
            i.setAttribute("class", "fa fa-play-circle");
            combo.disabled = false;
        } else {
            btn.setAttribute("onclick", "StopCamara()");
            i.setAttribute("class", "fa fa-stop-circle");
            combo.disabled = true;
        }
    }

    // Inicia la cámara y comienza a escanear
    function AbrirCamara(CamaraId) {
        if (CamaraId === undefined) {
            var e = document.getElementById("Camaras");
            CamaraId = e.options[e.selectedIndex].value;
        }

        html5QrCode = new Html5Qrcode("reader");
        EstadoBoton(1); // Cambiar a estado "detener"

        //Esta parte sirve para que pueda escanear tanto códigos QR como códigos de barra.
        //Esta constante muestra todos los tipos de códigos que acepta.
        const config = {
            fps: 10,
            qrbox: 250,
            formatsToSupport: [
                Html5QrcodeSupportedFormats.QR_CODE, //Formato de códigos QR
                Html5QrcodeSupportedFormats.CODE_128,  //Tipo de códigos de barra
                Html5QrcodeSupportedFormats.CODE_39,  //Tipo de códigos de barra
                Html5QrcodeSupportedFormats.EAN_13,  //Tipo de códigos de barra.
                Html5QrcodeSupportedFormats.AZTEC,      //Tipo de códigos de barra
                Html5QrcodeSupportedFormats.CODABAR,    //TIpo de códigos de barra
                Html5QrcodeSupportedFormats.DATA_MATRIX,    //Tipo de códigos de barra
                Html5QrcodeSupportedFormats.MAXICODE,   //Tipo de códigos de barra
                Html5QrcodeSupportedFormats.ITF,        //Tipo de códigos de barra
            ]
        };


        try {
            html5QrCode.start(
                CamaraId,
                config,
                (decodedText, decodedResult) => {
                    if (codigosEscaneados.has(decodedText)) {
                        lblmensaje.setAttribute('style', 'display:block !important');
                        lblmensaje.innerHTML = `⚠️ El código <strong>${decodedText}</strong> ya ha sido escaneado.`;
                        setTimeout(() => {
                            lblmensaje.setAttribute('style', 'display:none !important');
                            lblmensaje.innerHTML = "";
                        }, 3000);
                        return;
                    }

                    codigosEscaneados.add(decodedText); // Guardar como escaneado
                   colaCodigosEscaneados.push({
    Codigo: decodedText,
    Fecha: new Date().toISOString()
});
 // Agregar a la cola

                    sonido(); // Reproducir sonido

                    // Mostrar siempre el código en la tabla y en el contador
                    PintarTabla(decodedText, decodedResult);

                    // Lógica para enviar o no al backend
                    if (!$('#CuwScannerCode_chkOnOff').prop('checked')) {
                        EnviarCodigoAlServidor(decodedText);
                    } else {
                        let lectura = `${decodedText}`;
                        document.getElementById("<%=txtResultado.ClientID%>").value = lectura;

                        if (lectura.length === 11 && !lectura.includes(".")) {
                            html5QrCode.stop();
                            document.getElementById("CuwScannerCode_btnDevolver").click();
                        }
                    }

                  
                },
                errorMessage => {
                    // Ignorar errores de escaneo en tiempo real
                }
            ).catch(err => {
                lblmensaje.setAttribute('style', 'display:block !important');
                lblmensaje.innerHTML = err;
            });

        } catch (error) {
            lblmensaje.setAttribute('style', 'display:block !important');
            lblmensaje.innerHTML = error;
        }
    }

    // Detiene el escaneo y la cámara
    function StopCamara() {
        try {
            html5QrCode.stop();
            EstadoBoton(0); // Cambiar de estado la cámara
        } catch (error) {}
    }

    // Muestra el código escaneado en la tabla de abajo
    function PintarTabla(decodedText) {
        const tbody = document.getElementById("items");
        const row = document.createElement("tr");

        const cellIndex = document.createElement("th");
        cellIndex.scope = "row";
        cellIndex.textContent = tbody.rows.length + 1;

        const cellCode = document.createElement("td");
        cellCode.textContent = decodedText;

        const cellTimestamp = document.createElement("td");
        cellTimestamp.textContent = new Date().toLocaleString();

        row.appendChild(cellIndex);
        row.appendChild(cellCode);
        row.appendChild(cellTimestamp);
        tbody.appendChild(row);

        // ✅ Actualiza el TextBox
        document.getElementById('<%=txtResultado.ClientID %>').value = decodedText;

        // ✅ Actualiza el contador visual
        document.getElementById("contadorCodigos").innerText = tbody.rows.length;

        // ✅ Recalcula footer
        pintarFooter();

        console.log("✅ Fila añadida:", decodedText);
        console.log("Total filas:", document.querySelectorAll("#items tr").length);

    }



    // Actualiza el pie de tabla con total y botón de vaciar
    const pintarFooter = () => {
        footer.innerHTML = '';
        if (id === 0) {
            footer.innerHTML = `<th scope="row"></th>`;
            return;
        }

        const nCantidad = id;
        templateFooter.querySelector('th').textContent = `Total: ` + nCantidad.toString();

        const clone = templateFooter.cloneNode(true);
        fragment.appendChild(clone);
        footer.appendChild(fragment);

        // Botón para vaciar la tabla
        const boton = document.querySelector('#vaciar-items')
        boton.addEventListener('click', () => {
            id = 0
            items.innerHTML = ''
            codigosEscaneados.clear(); // También limpiar lista al vaciar
            pintarFooter()
        })
    }

    function actualizarTabla() {
        fetch('ScannerHandler.aspx/ObtenerCodigos', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
            body: JSON.stringify({})
        })
            .then(response => response.json())
            .then(data => {
                const tablaBody = document.getElementById('items');
                tablaBody.innerHTML = '';

                data.d.forEach((codigo, index) => {
                    const row = document.createElement('tr');
                    row.innerHTML = `<th scope="row">${index + 1}</th><td>${codigo}</td>`;
                    tablaBody.appendChild(row);
                });
            });
    }

    function limpiarTablaQr() {
        // Limpiar los códigos escaneados
        codigosEscaneados.clear();

        // Limpiar la cola
        colaCodigosEscaneados.length = 0;

        // Limpiar contenido de la tabla (tbody)
        items.innerHTML = '';

        // Reiniciar contador si lo usas para indexar filas
        id = 0;

        // También puedes limpiar el campo de resultado
        document.getElementById("<%=txtResultado.ClientID%>").value = "";

        // Ocultar mensajes de advertencia si estaban activos
        lblmensaje.setAttribute('style', 'display:none !important');
        lblmensaje.innerHTML = "";
    }

    // Esta función se llama cuando haces clic en "Vaciar tabla"
    function limpiarTablaYMemoria() {
        // Limpiar la tabla de la interfaz
        const tbody = document.getElementById('items');
        tbody.innerHTML = ''; // Limpia las filas de la tabla

        // Limpiar códigos escaneados
        codigosEscaneados.clear();

        // Limpiar la cola
        colaCodigosEscaneados.length = 0;

        // Reiniciar contador
        id = 0;

        // Limpiar campo de resultado
        document.getElementById('<%=txtResultado.ClientID%>').value = "";

        // Ocultar mensaje
        lblmensaje.setAttribute('style', 'display:none !important');
        lblmensaje.innerHTML = "";

        // Limpiar pie de tabla
        footer.innerHTML = '';

        // Reiniciar contador visual
        document.getElementById("contadorCodigos").innerText = "0";

        // Opcional: mensaje visual
        Swal.fire("Tabla limpiada", "Ahora puedes volver a escanear.", "success");
    }


    function hola() {

        if (colaCodigosEscaneados.length === 0) {

            Swal.fire({
                icon: "error",
                title: "Ha ocurrido un error",
                text: "No ha ingresado ningún valor",
                footer: 'Ingrese por lo menos 1 registro para poder enviarlo'
            });

            return;
        }

        console.log("📦 Códigos a enviar:", colaCodigosEscaneados); // 👈 Esto muestra la cola

        fetch("DynamicData/FieldTemplates/ScannerHandler.aspx/EnviarTodosLosCodigos", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ codigos: colaCodigosEscaneados })
        })
            .then(response => response.json())
            .then(data => {
                console.log("✅ Respuesta del servidor:", data);
                Swal.fire({
                    title: "Registro exitoso!",
                    text: "Se ha registrado correctamente",
                    icon: "success"
                }); // Mostrar mensaje recibido desde el backend
                limpiarTablaQr(); // Limpiar interfaz después de enviar         
                document.getElementById("contadorCodigos").innerText = "0"; //Limpia el contador de códigos escaneados.
            })
            .catch(error => {
                console.error("❌ Error al enviar datos:", error);
                Swal.fire({
                    icon: "error",
                    title: "Ha ocurrido un error",
                    text: "No se pudieron enviar los datos",
                    footer: 'Inténtelo nuevamente.'

                });
            });

    }

   

</script>