using System;
using System.Data;
using System.Drawing;

namespace EnviosExpress
{
    public partial class SoliRecoleccionCliente : System.Web.UI.Page
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

        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void btnrecolectar_Click(object sender, EventArgs e)
        {
            string nombre = txtnombre.Text;
            string tel1 = txttelefono1.Text;
            string tel2 = txttelefono2.Text;
            string direccion = txtdireccion.Text;
            if (nombre == "")
            {
                nombre0.Text = "Agregue Nombre y Apellido";
                nombre0.ForeColor = Color.Red;
            }
            else if (tel1 == "")
            {
                tel10.Text = "Agregue Teléfono";
                tel10.ForeColor = Color.Red;
            }
            else if (tel2 == "")
            {
                tel20.Text = "Agregue Teléfono";
                tel20.ForeColor = Color.Red;
            }
            else if (direccion == "")
            {
                direccion0.Text = "Agregue Dirección";
                direccion0.ForeColor = Color.Red;
            }
            else
            {
                conectado.conectar();
                conectado.solirecoleccion(nombre, tel1, tel2, direccion);

                Response.Write("<script>alert('Recolección Solicitada')</script>");
                txtnombre.Text = "";
                txttelefono1.Text = "";
                txttelefono2.Text = "";
                txtdireccion.Text = "";

            }
            conectado.desconectar();
        }
    }
}