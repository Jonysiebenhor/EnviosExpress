using System;
using System.Data;
using System.Drawing;

namespace EnviosExpress
{
    public partial class Login : System.Web.UI.Page
    {
        Conectar conectado = new Conectar();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //astrid banesa
        protected void Button2_Click(object sender, EventArgs e)
        {
            String dpi = txtdpi.Text;
            string contraseña = txtcontraseña.Text;

            if (dpi == "" || contraseña == "")

            {
                estado.Text = "Faltan Datos";
                estado.ForeColor = Color.Red;
            }
            else
            {
                conectado.conectar();

                DataTable prueba = new DataTable();
                prueba = conectado.consultaUsuarioloign(dpi, contraseña);

                if (prueba.Rows.Count > 0)
                {
                    DataRow rows = conectado.consultaUsuarioloign2(dpi).Rows[0];
                    String activo = Convert.ToString(Convert.ToString(rows["activo"]));
                    String prueba2 = Convert.ToString(Convert.ToString(rows["rol"]));

                    if (activo == "False")
                    {
                        estado.Text = "Usuario Inactivo " + dpi;
                        estado.ForeColor = Color.Red;
                    }
                    else// (activo == "2")
                    {
                        //varr = 1;
                        if (prueba2 == "1")
                        {
                            Session["id"] = txtdpi.Text;
                            Response.Redirect("Menu.aspx");
                        }
                        else if (prueba2 == "2")
                        {
                            Session["id"] = txtdpi.Text;
                            Response.Redirect("MenuMensajero.aspx");
                        }
                        else
                        {
                            Session["id"] = txtdpi.Text;
                            Response.Redirect("MenuAdministrador.aspx");
                        }
                    }
                    // Response.Write("<script>alert('Guardado')</script>");

                    //Thread::Sleep(2000);
                    //  Response.Redirect("Menu.aspx");
                    //estado.Text = prueba2;
                    //   estado.Text = "";

                }
                else

                    estado.Text = "Usuario o Contraseña incorrectas " + dpi;
                estado.ForeColor = Color.Red;
            }
            conectado.desconectar();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearCuenta.aspx");
        }


    }
}