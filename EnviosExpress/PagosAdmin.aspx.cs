using MathNet.Numerics.Distributions;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI.WebControls;

namespace EnviosExpress
{





    public partial class PagosAdmin : System.Web.UI.Page
    {
        Conectar conectado = new Conectar();
        protected void Page_Load(object sender, EventArgs e)


        {

            if (!IsPostBack)
            {
                if (Session["id"] is null)
                {
                    Response.Redirect("/Login.aspx");

                    
                }
               

                bingrind();

                pnlPendientes.Visible = true;   // ← ya lo tenías
                pnlLiquidados.Visible = true;    // ← cambialo a true
                pnlMensajeros.Visible = true;    // ← cambialo a true
                pnlReporte.Visible = false;
                pnlDetalleLiquidados.Visible = false;
                pnlDetalleMensajeros.Visible = false;
            }
        }

        /// <summary>
        /// Al hacer clic en Ver Reporte, carga GridViewReporte.
        /// </summary>
        protected void btnVerReporte_Click(object sender, EventArgs e)
        {
            DateTime desde = DateTime.Parse(txtfecha1.Text);
            DateTime hasta = DateTime.Parse(txtfecha2.Text);

            conectado.conectar();
            DataTable dt = conectado.ObtenerReportePagos(desde, hasta);
            conectado.desconectar();

            // Muestro el panel y título
            pnlReporte.Visible = true;
            lblReporteTitulo.Text =
                $"Informe de pagos pendientes (DPI: {Session["id"]}) del {desde:dd/MM/yyyy} al {hasta:dd/MM/yyyy}";

            GridViewReporte.DataSource = dt;
            GridViewReporte.DataBind();
        }



        /// <summary>
        /// Captura el clic en “Ver Reporte” dentro de GridView2 (pendientes)
        /// </summary>
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerReporte")
            {
                // ocultamos el listado y mostramos el panel de reporte
                 pnlPendientes.Visible = false;
                 pnlReporte.Visible = true;
                pnlLiquidados.Visible = false;
                pnlMensajeros.Visible = false;

                // 1) DPI y fechas
                string dpi = e.CommandArgument.ToString();
                DateTime desde = DateTime.Parse(txtfecha1.Text);
                DateTime hasta = DateTime.Parse(txtfecha2.Text);

                // 2) Encabezado dinámico
                var btn = (Button)e.CommandSource;
                var row = (GridViewRow)btn.NamingContainer;
                string negocio = ((Label)row.FindControl("Label9")).Text;
                lblReporteTitulo.Text =
                    $"Informe de pagos para {negocio} con número de DPI {dpi} del {desde:dd/MM/yyyy}";
                pnlReporte.Visible = true;

                // 3) Traigo los datos
                conectado.conectar();
                var dt = conectado.ObtenerReportePagosPorCliente(dpi, desde, hasta);
                conectado.desconectar();

                if (dt.Rows.Count > 0)
                {
                    // 4) Calculo los subtotales ANTES de añadir la fila
                    decimal totalMonto = Convert.ToDecimal(dt.Compute("SUM(MontoCobrado)", ""));
                    decimal totalEnvio = Convert.ToDecimal(dt.Compute("SUM(ValorEnvio)", ""));
                    decimal totalVisita = Convert.ToDecimal(dt.Compute("SUM(ValorVisita)", ""));
                    decimal totalPagoCliente = Convert.ToDecimal(dt.Compute("SUM(PagoCliente)", ""));

                    // 5) Creo la fila de totales
                    var sumRow = dt.NewRow();
                    sumRow["NoGuia"] = 0;               // campo clave debe ser numérico
                    sumRow["Departamento"] = DBNull.Value;    // dejamos vacías las otras columnas
                    sumRow["Municipio"] = DBNull.Value;
                    sumRow["Zona"] = DBNull.Value;
                    sumRow["MontoCobrado"] = totalMonto;
                    sumRow["ValorEnvio"] = totalEnvio;
                    sumRow["ValorVisita"] = totalVisita;
                    sumRow["PagoCliente"] = totalPagoCliente;
                    sumRow["FechaHoraEntrega"] = DBNull.Value;
                    sumRow["Mensajero"] = DBNull.Value;
                    dt.Rows.Add(sumRow);

                    // 6) Bindeo
                    GridViewReporte.DataSource = dt;
                    GridViewReporte.DataBind();

                    // 7) Pinto manualmente la última fila con las etiquetas
                    int last = GridViewReporte.Rows.Count - 1;
                    var totalRow = GridViewReporte.Rows[last];

                    // Columna 0 -> "Totales:"
                    totalRow.Cells[0].Text = "Totales:";
                    totalRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;

                    // Ajusta estos índices si cambias el orden de columnas:
                    totalRow.Cells[4].Text = $"Q{totalMonto:N2}";       // MontoCobrado
                    totalRow.Cells[5].Text = $"Q{totalEnvio:N2}";       // ValorEnvio
                    totalRow.Cells[6].Text = $"Q{totalVisita:N2}";      // ValorVisita
                    totalRow.Cells[7].Text = $"Q{totalPagoCliente:N2}"; // PagoCliente

                    totalRow.Font.Bold = true;
                }
                else
                {
                    // Si no hay datos, igual bind (vacío) para que el EmptyDataText aparezca
                    GridViewReporte.DataSource = dt;
                    GridViewReporte.DataBind();
                }
            }
        }








        private void bingrind()
        {
            /* SqlConnection con = new SqlConnection();
             con.ConnectionString = ConfigurationManager.ConnectionStrings["connBD"].ToString();
             con.Open();
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "Select a.idpago,CONCAT(b.primerNombre, ' ', b.primerApellido) as Mensajero, a.fechahora as Fecha,  CONCAT('Q',a.monto) as Monto, a.Estado as Estado from pagos a left join usuario b on a.idusuariomns=b.dpi where b.rol=2 order by a.fechahora DESC";
             cmd.Connection = con;
             SqlDataReader rd= cmd.ExecuteReader();*/
            conectado.conectar();
            String fecha5 = txtfecha5.Text;
            String fecha6 = txtfecha6.Text;
            GridView1.DataSource = conectado.pagos1(fecha5, fecha6);
            GridView1.DataBind();
            String fecha3 = txtfecha3.Text;
            String fecha4 = txtfecha4.Text;
            GridView3.DataSource = conectado.pagosclientes6(fecha3, fecha4);//obtener datos de la guia
            GridView3.DataBind();
            String fecha1 = txtfecha1.Text;
            String fecha2 = txtfecha2.Text;
            GridView2.DataSource = conectado.pagosclientes1(fecha1, fecha2);//obtener datos de la guia
            GridView2.DataBind();
            conectado.desconectar();
        }
        protected void btnrecolectar_Click(object sender, EventArgs e)
        {
            conectado.conectar();
            String fecha5 = txtfecha5.Text;
            String fecha6 = txtfecha6.Text;
            GridView1.DataSource = conectado.pagos1(fecha5, fecha6);//obtener datos de la guia
            GridView1.DataBind();
            conectado.desconectar();
        }
        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdministrador.aspx");
        }


        protected void btn3_Click(object sender, EventArgs e)
        {
            conectado.conectar();
            String fecha1 = txtfecha1.Text;
            String fecha2 = txtfecha2.Text;
            GridView2.DataSource = conectado.pagosclientes1(fecha1, fecha2);//obtener datos de la guia
            GridView2.DataBind();
            conectado.desconectar();
        }
        protected void btn2_Click(object sender, EventArgs e)
        {
            pnlDetalleLiquidados.Visible = false;
            conectado.conectar();
            String fecha3 = txtfecha3.Text;
            String fecha4 = txtfecha4.Text;
            GridView3.DataSource = conectado.pagosclientes6(fecha3, fecha4);//obtener datos de la guia
            GridView3.DataBind();
            conectado.desconectar();
        }


        protected void RowUpdatingEvent(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            GridViewRow fila = GridView1.Rows[e.RowIndex];
            String Estado = (fila.FindControl("ddl2") as DropDownList).Text.ToUpper();
            String guia = (fila.FindControl("TextBox3") as TextBox).Text.ToUpper();
            String refe = (fila.FindControl("TextBox88") as TextBox).Text.ToUpper();
            String fecha5 = txtfecha5.Text;
            String fecha6 = txtfecha6.Text;
            conectado.conectar();
            conectado.pagos2(Estado, guia, refe);
            GridView1.EditIndex = -1;
            GridView1.DataSource = conectado.pagos1(fecha5, fecha6);//obtener datos de la guia
            GridView1.DataBind();
            conectado.desconectar();

        }

        protected void RowEditingEvent(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            conectado.conectar();
            String fecha5 = txtfecha5.Text;
            String fecha6 = txtfecha6.Text;
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = conectado.pagos1(fecha5, fecha6);//obtener datos de la guia
            GridView1.DataBind();
            conectado.desconectar();

        }



        protected void RowCancelingEvent(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            conectado.conectar();
            String fecha5 = txtfecha5.Text;
            String fecha6 = txtfecha6.Text;
            GridView1.EditIndex = -1;
            GridView1.DataSource = conectado.pagos1(fecha5, fecha6);//obtener datos de la guia
            GridView1.DataBind();
            conectado.desconectar();
        }


        protected void RowCancelingEvent1(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            conectado.conectar();
            String fecha1 = txtfecha1.Text;
            String fecha2 = txtfecha2.Text;
            GridView2.EditIndex = -1;
            GridView2.DataSource = conectado.pagosclientes1(fecha1, fecha2);//obtener datos de la guia
            GridView2.DataBind();
            conectado.desconectar();
        }

        /// <summary>
        /// Vuelve al listado inicial de pagos pendientes
        /// </summary>
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            pnlReporte.Visible = false;
            pnlPendientes.Visible = true;

            pnlLiquidados.Visible = true;
            pnlMensajeros.Visible = true;

        }


        protected void RowEditingEvent1(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            conectado.conectar();
            String fecha1 = txtfecha1.Text;
            String fecha2 = txtfecha2.Text;
            GridView2.EditIndex = e.NewEditIndex;
            GridView2.DataSource = conectado.pagosclientes1(fecha1, fecha2);//obtener datos de la guia
            GridView2.DataBind();
            conectado.desconectar();

        }


        protected void RowUpdatingEvent1(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            String dpi2 = Session["id"].ToString();
            GridViewRow fila = GridView2.Rows[e.RowIndex];
            String dpi = (fila.FindControl("TextBox7") as TextBox).Text.ToUpper();
            String monto = (fila.FindControl("TextBox10") as TextBox).Text.ToUpper();
            String refe = (fila.FindControl("TextBox11") as TextBox).Text.ToUpper();

            conectado.conectar();
            conectado.pagosclientes2(dpi, dpi2, monto, refe);

            DataRow cierre2 = conectado.cierrepaquete1().Rows[0];
            String idpago = Convert.ToString(Convert.ToString(cierre2["idpago"]));
            String dpi1 = Convert.ToString(Convert.ToString(cierre2["idusuario"]));
            conectado.pagosclientes3(idpago, dpi1);
            conectado.pagosclientes4(idpago);
            conectado.pagosclientes5(dpi1, dpi2);

            ////DataTable ct = conectado.pagosclientes4(idpago);
            //for (int i = 0; i <= ct; i++)
            /*DataRow cierre3 = conectado.pagosclientes4(idpago).Rows[0];
           /* String guia = Convert.ToString(Convert.ToString(cierre3["idpaquete"]));
            String dpi2 = Convert.ToString(Convert.ToString(cierre3["idusuario"]));
            conectado.pagosclientes5(guia, dpi2);*/
            String fecha1 = txtfecha1.Text;
            String fecha2 = txtfecha2.Text;
            String fecha3 = txtfecha3.Text;
            String fecha4 = txtfecha4.Text;
            GridView2.EditIndex = -1;
            GridView2.DataSource = conectado.pagosclientes1(fecha1, fecha2);//obtener datos de la guia
            GridView2.DataBind();
            GridView3.EditIndex = -1;
            GridView3.DataSource = conectado.pagosclientes6(fecha3, fecha4);//obtener datos de la guia
            GridView3.DataBind();
            conectado.desconectar();
        }
        /// <summary>
        /// Captura el clic en “Generar Reporte” dentro de GridView3
        /// </summary>
        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "GenerarReporte")
            {
                pnlPendientes.Visible = false;
                pnlReporte.Visible = false;
                pnlLiquidados.Visible = false;
                pnlMensajeros.Visible = false;
                string idPago = e.CommandArgument.ToString();

                // 1) Traer datos
                conectado.conectar();
                var detalle = conectado.ObtenerDetalleLiquidacionCliente(idPago);
                conectado.desconectar();

                // 2) Sacar el nombre del cliente (si viene)
                string cliente = "(desconocido)";
                if (detalle.Rows.Count > 0 && detalle.Columns.Contains("Cliente"))
                    cliente = detalle.Rows[0]["Cliente"].ToString();

                // 3) Mostrar el panel y fijar el título
                pnlDetalleLiquidados.Visible = true;
                lblTituloDetalle.Text =
                  $"Informe de liquidación para {cliente} con el ID de pago {idPago}";

                // 4) Calcular totales SI HAY filas
                decimal sumCobrado = 0m;
                decimal sumEnvio = 0m;
                decimal sumVisita = 0m;
                decimal sumPagoCliente = 0m;
                if (detalle.Rows.Count > 0)
                {
                    sumCobrado = Convert.ToDecimal(detalle.Compute("SUM(MontoCobrado)", ""));
                    sumEnvio = Convert.ToDecimal(detalle.Compute("SUM(ValorEnvio)", ""));
                    sumVisita = Convert.ToDecimal(detalle.Compute("SUM(ValorVisita)", ""));
                    sumPagoCliente = Convert.ToDecimal(detalle.Compute("SUM(PagoCliente)", ""));
                }

                // 5) Crear y añadir la fila de totales
                if (detalle.Rows.Count > 0)
                {
                    var totRow = detalle.NewRow();
                    totRow["NoGuia"] = 0;               // PK entera
                    totRow["IdPago"] = DBNull.Value;
                    totRow["Departamento"] = DBNull.Value;
                    totRow["Municipio"] = DBNull.Value;
                    totRow["Zona"] = DBNull.Value;
                    totRow["MontoCobrado"] = sumCobrado;
                    totRow["ValorEnvio"] = sumEnvio;
                    totRow["ValorVisita"] = sumVisita;
                    totRow["PagoCliente"] = sumPagoCliente;
                    totRow["FechaHoraEntrega"] = DBNull.Value;
                    totRow["Estado"] = DBNull.Value;
                    totRow["descripcion"] = DBNull.Value;
                    detalle.Rows.Add(totRow);
                }

                // 6) Enlazar al GridView
                GridViewDetalleLiquidados.DataSource = detalle;
                GridViewDetalleLiquidados.DataBind();

                // 7) Dar formato a la última fila como "Totales:"
                if (detalle.Rows.Count > 0)
                {
                    int lastIndex = GridViewDetalleLiquidados.Rows.Count - 1;
                    var filaTot = GridViewDetalleLiquidados.Rows[lastIndex];

                    // Ajusta estos índices según el orden real de tus columnas:
                    filaTot.Cells[0].Text = "Totales:";
                    filaTot.Cells[0].HorizontalAlign = HorizontalAlign.Right;

                    // Suponiendo:
                    //   5 → "MontoCobrado", 
                    //   6 → "ValorEnvio", 
                    //   7 → "ValorVisita", 
                    //   8 → "PagoCliente"
                    filaTot.Cells[5].Text = $"Q{sumCobrado:N2}";
                    filaTot.Cells[6].Text = $"Q{sumEnvio:N2}";
                    filaTot.Cells[7].Text = $"Q{sumVisita:N2}";
                    filaTot.Cells[8].Text = $"Q{sumPagoCliente:N2}";

                    filaTot.Font.Bold = true;
                }
            }
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerReporteMensajero")
            {
                pnlPendientes.Visible = false;
                pnlReporte.Visible = false;
                pnlLiquidados.Visible = false;
                pnlMensajeros.Visible = false;

                string idPago = e.CommandArgument.ToString();

                // 1) Traer datos
                conectado.conectar();
                DataTable dtDetalle = conectado.ObtenerDetalleMensajero(idPago);
                conectado.desconectar();

                // 2) Obtener el nombre del mensajero (si existe)
                string mensajero = "(desconocido)";
                if (dtDetalle.Rows.Count > 0 && dtDetalle.Columns.Contains("Mensajero"))
                    mensajero = dtDetalle.Rows[0]["Mensajero"].ToString();

                // 3) Ajustar el título del panel
                lblTituloDetalleMensajeros.Text =
                    $"Reporte del mensajero {mensajero} con un ID de pago {idPago}";

                // 4) --- NUEVO: calcular y añadir la fila de totales ---
                if (dtDetalle.Rows.Count > 0)
                {
                    // Calculamos cada columna numérica
                    decimal sumCobrado = Convert.ToDecimal(dtDetalle.Compute("SUM(MontoCobrado)", ""));
                    decimal sumEnvio = Convert.ToDecimal(dtDetalle.Compute("SUM(ValorEnvio)", ""));
                    decimal sumVisita = Convert.ToDecimal(dtDetalle.Compute("SUM(ValorVisita)", ""));
                    decimal sumPagoCliente = Convert.ToDecimal(dtDetalle.Compute("SUM(PagoCliente)", ""));

                    // Creamos la fila de totales
                    var totRow = dtDetalle.NewRow();
                    totRow["NoGuia"] = DBNull.Value;  // la pondremos como texto al bind
                    totRow["IdPago"] = DBNull.Value;
                    totRow["Departamento"] = DBNull.Value;
                    totRow["Municipio"] = DBNull.Value;
                    totRow["Zona"] = DBNull.Value;
                    totRow["MontoCobrado"] = sumCobrado;
                    totRow["ValorEnvio"] = sumEnvio;
                    totRow["ValorVisita"] = sumVisita;
                    totRow["PagoCliente"] = sumPagoCliente;
                    totRow["FechaHoraEntrega"] = DBNull.Value;
                    totRow["Estado"] = DBNull.Value;
                    totRow["Mensajero"] = DBNull.Value;
                    totRow["Referencia"] = DBNull.Value;
                    dtDetalle.Rows.Add(totRow);
                }

                // 5) Bindeo al GridView y muestro panel
                GridViewDetalleMensajeros.DataSource = dtDetalle;
                GridViewDetalleMensajeros.DataBind();
                pnlDetalleMensajeros.Visible = true;

                // 6) Doy formato a la última fila para que muestre “Totales:” en la primera celda
                if (dtDetalle.Rows.Count > 0)
                {
                    int last = GridViewDetalleMensajeros.Rows.Count - 1;
                    GridViewRow filaTot = GridViewDetalleMensajeros.Rows[last];

                    // Pongo el texto en la columna “No. Guía”
                    filaTot.Cells[0].Text = "Totales:";
                    filaTot.Cells[0].HorizontalAlign = HorizontalAlign.Right;

                    // El resto de las columnas numéricas ya trajeron sus valores
                    // Sólo las pongo en negrita:
                    filaTot.Font.Bold = true;
                    pnlDetalleMensajeros.Visible = true;
                }
            }
        }
        
        protected void btnRegresarDetalle_Click(object sender, EventArgs e)
        {
            // 1) Ocultar paneles de detalle/reporte
            pnlDetalleLiquidados.Visible = false;
            pnlDetalleMensajeros.Visible = false;
            pnlReporte.Visible = false;

            // 2) Volver a mostrar los 3 listados principales
            pnlPendientes.Visible = true;
            pnlLiquidados.Visible = true;
            pnlMensajeros.Visible = true;
        }

        /// <summary>
        /// Al hacer clic en “← Regresar” del detalle de mensajeros,
        /// ocultamos el panel de detalle y volvemos a mostrar las 3 secciones.
        /// </summary>
        protected void btnRegresarMensajerosDetalle_Click(object sender, EventArgs e)
        {
            pnlDetalleMensajeros.Visible = false;
            pnlPendientes.Visible = true;
            pnlLiquidados.Visible = true;
            pnlMensajeros.Visible = true;
            pnlReporte.Visible = false;
        }


    }
} //Redirigir al menu principal