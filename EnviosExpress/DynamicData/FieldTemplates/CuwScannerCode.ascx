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
                <input type="hidden" id="modoOperacion" value="recolectar" />
                <h6 class="modal-title" id="lblTitulo" ><strong>Escanear paquetes</strong></h6>
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
    
    
</template>
                </table>
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

                <!-- SOLO visible en modo intento de entrega -->
<div id="bloqueMotivoIntento" class="form-group" style="display:none;">
  <label for="motivoIntentoEntrega">Motivo del intento fallido:</label>
  <select id="motivoIntentoEntrega" class="form-control">
    <option value="--Seleccionar">--Seleccionar</option>
    <option>No Quizo Recibir</option>
    <option>No Contesta LLamadas</option>
    <option>No Llego a Punto de Encuentro</option>
    <option>No esta de Acuerdo Con el Precio</option>
    <option>No Recibe Fines de Semana</option>
    <option>Ya No Lo Desea</option>
    <option>Nadie En Casa</option>
    <option>Direccion Incorrecta</option>
    <option>Lugar Muy Retirado</option>
    <option>Desperfectos Mecanicos</option>
    <option>Bloqueos, Derrumbes, Manifestaciones</option>
  </select>
</div>

                
                <!--Checkbox para pedir si desea enviarlos a ruta de una vez-->
                <div class="form-check" id="grupoRutaDirecta">
  <input type="checkbox" class="form-check-input" id="chkRutaDirecta">
  <label class="form-check-label" for="chkRutaDirecta" style="margin-left:17px;">
    ¿Enviar paquete a ruta directamente?
  </label>
</div>


                <!--***************************************************-->
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" onclick="limpiarTablaYMemoria()">Vaciar tabla</button>
                <button type="button" class="btn btn-success" onclick="EnviarSegunModo()">Enviar datos</button>
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
    async function AbrirModalScanner(modo = "recolectar") {
        // Establecer modo
        document.getElementById("modoOperacion").value = modo;


        const bloqueMotivo = document.getElementById("bloqueMotivoIntento");
        if (bloqueMotivo) {
            bloqueMotivo.style.display = (modo === "intento" || modo === "devolucion") ? "block" : "none";

        }



        // Establecer título dinámico
        let titulo = "Escanear paquetes";

        if (modo === "recolectar") titulo = "Recolectar paquetes";
        else if (modo === "enrutar") titulo = "Enrutar paquetes";
        else if (modo === "entregar") titulo = "Entrega de paquetes";

        const tituloLabel = document.getElementById("lblTitulo");

        if (tituloLabel) {
            tituloLabel.innerHTML = `<strong>${titulo}</strong>`;
        } else {
            console.warn("⚠️ lblTitulo no encontrado en el DOM.");
        }

        // 👉 Mostrar/ocultar checkbox según el modo
        const grupoRuta = document.getElementById("grupoRutaDirecta");
        if (grupoRuta) {
            grupoRuta.style.display = (modo === "recolectar") ? "block" : "none";
        }

        try {
            // Resetear variables internas
            colaCodigosEscaneados.length = 0;
            codigosEscaneados.clear();
            document.getElementById("items").innerHTML = "";
            id = 0;

            // Limpiar TextBox (ID dinámico generado por ASP.NET)
            const txtResultado = document.querySelector('[id$="_txtResultado"]');
            if (txtResultado) txtResultado.value = "";

            // Limpiar mensaje
            if (typeof lblmensaje !== "undefined") {
                lblmensaje.innerHTML = "";
                lblmensaje.setAttribute('style', 'display:none !important');
            }

            // Resetear manualmente estado del modal
            const modal = document.getElementById("ModalScannerCode");
            if (modal) {
                modal.classList.remove("show");
                modal.style.display = "none";
                modal.setAttribute("aria-hidden", "true");
            }

            // Mostrar modal
            $('#ModalScannerCode').modal({
                backdrop: 'static',
                keyboard: false
            });

            // Cargar cámaras
            ListarCamaras("Camaras");

            const CamaraId = await GetIdCamaraApropiada();
            if (CamaraId.length > 0) {
                $("#Camaras option[value='" + CamaraId + "']").attr("selected", true);
                AbrirCamara(CamaraId);
            }

        } catch (err) {
            console.error("❌ Error al abrir el modal del scanner:", err);
            Swal.fire("Error", "No se pudo abrir el escáner correctamente.", "error");
        }

        console.log("🧭 Modo actual:", modo);
        console.log("📦 Estado se definirá en EnviarSegunModo()");


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
    const codigoInt = parseInt(decodedText, 10);

    // Validar si es un número entero válido
    if (isNaN(codigoInt)) {
        Swal.fire({
            icon: "error",
            title: "Código inválido",
            html: `🚫 El código escaneado <strong>${decodedText}</strong> no es un número válido.`,
            confirmButtonText: "Entendido"
        });
        return;
    }

    // Validar si ya fue escaneado antes (evitar duplicados)
    if (codigosEscaneados.has(codigoInt)) {
        Swal.fire({
            icon: "warning",
            title: "Código duplicado",
            html: `⚠️ El código <strong>${codigoInt}</strong> ya fue escaneado.`,
            confirmButtonText: "OK"
        });
        return;
    }

    // Agregar a estructuras
    codigosEscaneados.add(codigoInt);
    colaCodigosEscaneados.push({
        Codigo: codigoInt,
        Fecha: new Date().toISOString()
    });

    // Mostrar en la tabla
    PintarTabla(codigoInt);

    // Reproducir sonido
    sonido();

    // Lógica para enviar o no al backend
    if (!$('#CuwScannerCode_chkOnOff').prop('checked')) {
        EnviarCodigoAlServidor(codigoInt);
    } else {
        let lectura = `${codigoInt}`;
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
        if (items.rows.length === 0) {
    footer.innerHTML = `<th scope="row"></th>`;
    return;
}


        const nCantidad = items.rows.length;
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
        });
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

    //Función para enviar los códigos a la base de datos

    function EnviarSegunModo() {
        const modo = document.getElementById("modoOperacion").value;
        const enviarARuta = document.getElementById("chkRutaDirecta")?.checked || false;
        const motivo = document.getElementById("motivoIntentoEntrega")?.value || "";

        let estado = "recolectado";

        // Determinar el estado según el modo
        switch (modo) {
            case "recolectar":
                estado = enviarARuta ? "recolectado + ruta de entrega" : "recolectado";
                break;
            case "enrutar":
                estado = "Ruta de entrega";
                break;
            case "entregar":
                estado = "entregado";
                break;
            case "intento":
                estado = "intento de entrega";
                break;
            case "devolucion":
                const motivoCombo = document.getElementById("motivoIntentoEntrega")?.value || "";
                if (!motivoCombo || motivoCombo === "--Seleccionar") {
                    Swal.fire("⚠️", "Debes seleccionar un motivo de devolución.", "warning");
                    return;
                }
                estado = "Devolución " + motivoCombo;
                break;

        }

        if (colaCodigosEscaneados.length === 0) {
            Swal.fire({
                icon: "error",
                title: "Error",
                text: "No hay códigos para procesar."
            });
            return;
        }

        // Validar motivo en caso de intento de entrega
        if (modo === "intento") {
            if (!motivo || motivo === "--Seleccionar") {
                Swal.fire("⚠️", "Debes seleccionar un motivo de intento fallido.", "warning");
                return;
            }
        }

        if (modo === "intento") {
            
            if (!motivo || motivo === "--Seleccionar") {
                Swal.fire("⚠️", "Debes seleccionar un motivo para el intento fallido.", "warning");
                return;
            }
            estado = motivo; // se usa como estado
        }


        // Armar el payload (se agrega 'motivo' solo si aplica)
        let payload = {
            codigos: colaCodigosEscaneados,
            estado: estado
        };

        if (modo === "intento") {
            payload.motivo = motivo;
        }

        // Enviar datos
        fetch("DynamicData/FieldTemplates/ScannerHandler.aspx/RegistrarEstadoPaquetes", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(payload)
        })
            .then(res => res.json())
            .then(data => {
                const errores = data.d;
                if (errores.length === 0) {
                    Swal.fire("✔️ Éxito", "Todos los paquetes se registraron correctamente.", "success");
                } else {
                    const mensajes = errores.map(e => `Código ${e.Codigo}: ${e.Mensaje}`).join('<br>');
                    Swal.fire("⚠️ Algunos errores en los paquetes", mensajes, "warning");
                }
                limpiarTablaQr();
                document.getElementById("contadorCodigos").innerText = "0";
            })
            .catch(err => {
                console.error("Error:", err);
                Swal.fire("❌ Error", "No se pudo enviar la información al servidor.", "error");
            });
    }




</script>