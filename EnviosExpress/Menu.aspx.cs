using NPOI.SS.Formula.Functions;
using System;
using System.Data;

namespace EnviosExpress
{
    public partial class Menu : System.Web.UI.Page
    {
        Conectar conectado = new Conectar();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Session["id"] is null)
                {
                    Response.Redirect("/Login.aspx");
                }
            }
        }

        /*protected void cerrarsecion_Click(object sender, EventArgs e)
        {
            String dpi = Request.QueryString["id"].ToString();
            DataTable sesion = new DataTable();
            sesion = conectado.cerrarsesion(dpi);
            conectado.desconectar();

            Response.Redirect("Login.aspx");
        }*/

    
       /* protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            String dpi = Request.QueryString["id"].ToString();
            Response.Redirect("GenerarGuia.aspx?id=" + dpi);
        }*/
        protected void Consultarguia_Click(object sender, EventArgs e)
        {
           // String dpi = Session["id"].ToString();
           // Response.Redirect("ConsultarGuia.aspx?id=" + dpi);
            Response.Redirect("ConsultarGuia.aspx");
        }

        protected void Crearguia_Click(object sender, EventArgs e)
        {
            //String dpi = Session["id"].ToString();
            Response.Redirect("GenerarGuia.aspx");
        }

        protected void Recoleccion_Click(object sender, EventArgs e)
        {
            //String dpi = Session["id"].ToString();
            Response.Redirect("SoliRecoleccionCliente.aspx");
        }

        protected void Manifiestos_Click(object sender, EventArgs e)
        {
            //String dpi = Session["id"].ToString();
            Response.Redirect("Manifiesto.aspx?idmanifiesto=0");
        }

        protected void Crearguiamasiva_Click(object sender, EventArgs e)
        {
            //String dpi = Session["id"].ToString();
            Response.Redirect("GenerarGuiaMasiva.aspx");
        }
        protected void Transferencias_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            Response.Redirect("PagosClientes.aspx");
        }
    }
}