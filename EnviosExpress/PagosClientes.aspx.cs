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
                // Recuperamos la fila donde se pulsó el botón
                var btn = (System.Web.UI.WebControls.Button)e.CommandSource;
                var row = (GridViewRow)btn.NamingContainer;

                // Suponiendo que la columna Cliente es la segunda (índice 1):
                string cliente = row.Cells[1].Text;

                // Tomamos el ID de pago
                string idPago = e.CommandArgument.ToString();

                //  ---> Aquí asignamos el encabezado dinámico:
                lblTituloDetalleT.Text =
                  $"Informe de liquidación para {cliente} con el ID de pago {idPago}";

                // El resto igual:
                conectado.conectar();
                var dtDetalle = conectado.ObtenerDetalleLiquidacionCliente(idPago);
                conectado.desconectar();
               
                GridViewDetalleT.DataSource = dtDetalle;
                GridViewDetalleT.DataBind();
                pnlDetalleT.Visible = true;
            }
        }


    }

}