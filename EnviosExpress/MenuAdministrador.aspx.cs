using System;
using System.Data;

namespace EnviosExpress
{
    public partial class MenuAdministrador : System.Web.UI.Page
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

        protected void crearcuenta_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            Response.Redirect("CrearCuentaAdmin.aspx");
        }

        protected void editarcuenta_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            Response.Redirect("EditarCuenta.aspx");
        }

        protected void Ingresoguia_Click(object sender, EventArgs e)
        {
            Response.Redirect("GenerarGuiaMns.aspx");
        }
        protected void Consultarguia1_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            Response.Redirect("ConsultarGuiaAdmin.aspx");
        }

        protected void PagosAdmin_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            Response.Redirect("PagosAdmin.aspx");
        }
        protected void Solicitudes_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            Response.Redirect("SolicitudesAdmin.aspx");
        }

    }
}