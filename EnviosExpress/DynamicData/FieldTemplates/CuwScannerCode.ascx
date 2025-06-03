<%@ Control Language="C#" CodeBehind="CuwScannerCode.ascx.cs" Inherits="EnviosExpress.DynamicData.FieldTemplates.CuwScannerCode" %>

<asp:Literal runat="server" ID="Literal1" Text="<%# FieldValueString %>" />


<script src="https://unpkg.com/html5-qrcode"></script>
<link rel="stylesheet" href="https://cdn.datatables.net/2.1.8/css/dataTables.dataTables.css" />


<!-- Modal Scanner Code-->
<div class="modal fade" runat="server" id="ModalScannerCode" tabindex="-1" role="dialog" aria-labelledby="ModalScannerCodeLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-centered " role="document">
        <div class="modal-content">
            <div class="modal-header P-2">
                <h6 class="modal-title" id="lblTitulo" runat="server"><strong>Devolver</strong> </h6>
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
                        <asp:TextBox ID="resultado" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
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

                <table class="table" id="tablaor">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Código</th>
                        </tr>
                    </thead>
                    <tbody id="items">
                        <template id="template-items">
                            <tr>
                                <th scope="row">0</th>
                                <td ><input name="entrada[0]">
                                </td>
                            </tr>
                        </template>
                    </tbody>
                    <tfoot>
                        <tr id="footer">
                            <template id="template-footer">
                                <th scope="row">Total</th>
                                <td>
                                    <button class="btn btn-danger btn-sm" id="vaciar-items" type="button">
                                         vaciar
                                    </button>
                                    <button class="btn btn-danger btn-sm" id="llenar-items" type="button">
                                    llenar
                                </button>
                                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                                </td>
                            </template>
                        </tr>
                    </tfoot>
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
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
            </div>
        </div>
    </div>
</div>


<!-- Aquí empieza la función del JS -->
<script type="text/javascript">

    
    var html5QrCode;
    const codigosEscaneados = new Set(); // <- Lista para registrar códigos escaneados 1 sola vez
    let lblmensaje = document.getElementById('<%=lblMessage.ClientID %>');

    // Variables para manejar la tabla de resultados
    let id = 0
    const templateCarrito = document.getElementById('template-items').content
    const fragment = document.createDocumentFragment()
    const items = document.getElementById('items')
    const footer = document.getElementById('footer')
    const templateFooter = document.getElementById('template-footer').content

    // Reproduce sonido al escanear exitosamente
    function sonido() {
        const audio = new Audio("../Multimedia/Audio/beep.mp3");
        audio.play();
    }

    // Función para abrir el modal del scanner
    async function AbrirModalScanner() {
        document.getElementById("<%=resultado.ClientID%>").value = ""; // Limpiar campo resultado
        lblmensaje.innerHTML = "";
        lblmensaje.setAttribute('style', 'display:none !important');

        // Mostrar modal
        $('#CuwScannerCode_ModalScannerCode').modal({ backdrop: 'static', keyboard: false });
        $('#CuwScannerCode_ModalScannerCode').modal('show');

        ListarCamaras("Camaras");

        // Obtener cámara
        const CamaraId = await GetIdCamaraApropiada();
        if (CamaraId.length > 0) {
            $("#Camaras option[value='" + CamaraId + "']").attr("selected", true);
            AbrirCamara(CamaraId); // Iniciar cámara
        }
    }

    // Al cerrar el modal: detener cámara, limpiar códigos y campo de texto
    $('#CuwScannerCode_ModalScannerCode').on('hidden.bs.modal', function (e) {
        StopCamara(); // Detener cámara
        codigosEscaneados.clear(); // Limpiar códigos escaneados
        document.getElementById("<%=resultado.ClientID%>").value = ""; // Limpiar campo de resultado
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

        try {
            html5QrCode.start(
                CamaraId,
                { fps: 10, qrbox: 250 }, // Configuración de escaneo
                (decodedText, decodedResult) => {
                    // Verificar si el código ya fue escaneado
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
                    sonido(); // Reproducir sonido

                    
                    if ($('#CuwScannerCode_chkOnOff').prop('checked')) {
                        let lectura = `${decodedText}`;
                        document.getElementById("<%=resultado.ClientID%>").value = lectura;

                     
                        if (lectura.length === 11 && !lectura.includes(".")) {
                            html5QrCode.stop();
                            document.getElementById("CuwScannerCode_btnDevolver").click();
                        }
                        return;
                    } else {
                        PintarTabla(decodedText, decodedResult); // Agregar a tabla
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
    function PintarTabla(decodedText, decodedResult) {
        document.getElementById("<%=resultado.ClientID%>").value = `${decodedText}`;

        id++;
        templateCarrito.querySelector('th').textContent = id;
        templateCarrito.querySelectorAll('td')[0].textContent = `${decodedText}`;
        const clone = templateCarrito.cloneNode(true);
        fragment.appendChild(clone);
        items.appendChild(fragment);
        pintarFooter();
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

</script>

