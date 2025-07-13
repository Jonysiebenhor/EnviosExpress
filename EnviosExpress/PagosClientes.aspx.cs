using MessagingToolkit.QRCode.Codec;
using NPOI.SS.Formula.Functions;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Policy;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace EnviosExpress
{
    public partial class PagosClientes : System.Web.UI.Page
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
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            Response.Redirect("Menu.aspx");
            conectado.desconectar();
        }
        protected void btnrecolectar_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            String fecha1 = txtfecha1.Text;
            String fecha2 = txtfecha2.Text;
            conectado.conectar();
            GridView5.DataSource = conectado.pagosclientes7(dpi, fecha1, fecha2);//obtener datos de la guia
            GridView5.DataBind();
            conectado.desconectar();
        }
        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerConsulta")
            {
                pnlTransferencias.Visible = false;
                pnlDetalleT.Visible = true;
                // 1) Recuperamos la fila donde se pulsó el botón y el cliente
                var btn = (System.Web.UI.WebControls.Button)e.CommandSource;
                var row = (GridViewRow)btn.NamingContainer;
                string cliente = row.Cells[1].Text;

                // 2) Tomamos el ID de pago y actualizamos el título
                string idPago = e.CommandArgument.ToString();
                lblTituloDetalleT.Text =
                    $"Informe de liquidación para {cliente} con el ID de pago {idPago}";
                pnlDetalleT.Visible = true;

                // 3) Traemos los datos en un DataTable
                conectado.conectar();
                var dtDetalle = conectado.ObtenerDetalleLiquidacionCliente(idPago);
                conectado.desconectar();

                // 4) Calculamos los totales si hay filas
                decimal totalCobrado = 0m, totalEnvio = 0m, totalVisita = 0m, totalPagoCli = 0m;
                if (dtDetalle.Rows.Count > 0)
                {
                    totalCobrado = Convert.ToDecimal(
                        dtDetalle.Compute("SUM(MontoCobrado)", ""));
                    totalEnvio = Convert.ToDecimal(
                        dtDetalle.Compute("SUM(ValorEnvio)", ""));
                    totalVisita = Convert.ToDecimal(
                        dtDetalle.Compute("SUM(ValorVisita)", ""));
                    totalPagoCli = Convert.ToDecimal(
                        dtDetalle.Compute("SUM(PagoCliente)", ""));

                    // 5) Insertamos la fila de totales al final
                    var sumRow = dtDetalle.NewRow();
                    sumRow["NoGuia"] = DBNull.Value;
                    sumRow["IdPago"] = DBNull.Value;
                    sumRow["Departamento"] = DBNull.Value;
                    sumRow["Municipio"] = DBNull.Value;
                    sumRow["Zona"] = DBNull.Value;
                    sumRow["MontoCobrado"] = totalCobrado;
                    sumRow["ValorEnvio"] = totalEnvio;
                    sumRow["ValorVisita"] = totalVisita;
                    sumRow["PagoCliente"] = totalPagoCli;
                    sumRow["FechaHoraEntrega"] = DBNull.Value;
                    sumRow["Estado"] = DBNull.Value;
                    sumRow["descripcion"] = DBNull.Value;
                    dtDetalle.Rows.Add(sumRow);
                }

                // 6) Enlazamos al GridView
                GridViewDetalleT.DataSource = dtDetalle;
                GridViewDetalleT.DataBind();

                // 7) Damos formato a la última fila como “Totales:”
                if (dtDetalle.Rows.Count > 0)
                {
                    int lastIdx = GridViewDetalleT.Rows.Count - 1;
                    var totalRow = GridViewDetalleT.Rows[lastIdx];

                    // Columna 0 (NoGuia) → “Totales:”
                    totalRow.Cells[0].Text = "Totales:";
                    totalRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;

                    // Asegúrate de que estos índices coincidan con el orden de tus columnas:
                    totalRow.Cells[5].Text = $"Q{totalCobrado:N2}";  // MontoCobrado
                    totalRow.Cells[6].Text = $"Q{totalEnvio:N2}";    // ValorEnvio
                    totalRow.Cells[7].Text = $"Q{totalVisita:N2}";   // ValorVisita
                    totalRow.Cells[8].Text = $"Q{totalPagoCli:N2}";  // PagoCliente

                    totalRow.Font.Bold = true;
                }
            }
        }

        /// <summary>
        /// Al clicar “← Regresar” en detalle de transferencias,
        /// volvemos al listado principal.
        /// </summary>
        protected void btnRegresarT_Click(object sender, EventArgs e)
        {
            pnlDetalleT.Visible = false;
            pnlTransferencias.Visible = true;
        }




    }

}