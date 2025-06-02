using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnviosExpress
{
    public partial class CierreDiario : System.Web.UI.Page
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



        protected void Cierre_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            conectado.conectar();
            DataRow cierree = conectado.cierrepaquete(dpi).Rows[0];
            String monto = Convert.ToString(Convert.ToString(cierree["montototal"]));
            //int montoo= int.Parse(monto);
            if (monto == "")
            {
                Response.Write("<script>alert('No hay pedidos por Cerrar')</script>");

            }
            else
            {
                DataTable cierre = conectado.cierrepaquete0(dpi, monto);
                DataRow cierre2 = conectado.cierrepaquete1().Rows[0];
                String idpago = Convert.ToString(Convert.ToString(cierre2["idpago"]));
                DataTable cierre3 = conectado.cierrepaquete2(idpago, dpi);
                Label3.Text = "Q ";
                conectado.desconectar();
                Response.Write("<script>alert('Se han cerrado todos los pedidos')</script>");
            }
            conectado.desconectar();
        }

        protected void regresar_Click(object sender, EventArgs e)
        {

            Response.Redirect("MenuMensajero.aspx");
        }
    }
}