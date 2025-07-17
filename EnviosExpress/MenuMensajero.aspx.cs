using System;
using System.Data;

namespace EnviosExpress
{
    public partial class MenuMensajero : System.Web.UI.Page
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


        protected void Consultarguia_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultarGuiaMns.aspx");
        }

        protected void Ingresoguia_Click(object sender, EventArgs e)
        {
            Response.Redirect("GenerarGuiaMns.aspx");
        }

        protected void recoleccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Recoleccion.aspx");
        }

        protected void ruta_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ruta.aspx");
        }

        protected void entrega_Click(object sender, EventArgs e)
        {
            Response.Redirect("Entrega.aspx");
        }

        protected void intento_Click(object sender, EventArgs e)
        {
            Response.Redirect("IntentoEntrega.aspx");
        }

        protected void devolucion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Devolucion.aspx");
        }


        protected void cierre_Click(object sender, EventArgs e)
        {
            Response.Redirect("CierreDiario.aspx");
        }

        protected void Solicitudes_Click(object sender, EventArgs e)
        {
           Response.Redirect("SolicitudesMns.aspx");
        }
    }
}