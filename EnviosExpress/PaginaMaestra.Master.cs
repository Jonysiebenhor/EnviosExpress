using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnviosExpress
{
    public partial class PaginaMaestra : System.Web.UI.MasterPage
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
                String dpi = Session["id"].ToString();

                conectado.conectar();
                DataRow rows = conectado.consultaUsuarioDPI(dpi).Rows[0];
                String nombre = Convert.ToString(Convert.ToString(rows["primerNombre"]));
                String apellido = Convert.ToString(Convert.ToString(rows["primerApellido"]));
                String negocio = Convert.ToString(Convert.ToString(rows["nombrenegocio"]));
                id.Text = nombre;
                id2.Text = apellido;
                id3.Text = negocio;
                conectado.desconectar();
            }
        }
        protected void cerrarsecion_Click(object sender, EventArgs e)
        {
            Session.Remove("id");
            Session.RemoveAll();
            Response.Redirect("/Login.aspx");
        }
    }
}