using System;
using System.Data;
using System.Drawing;

namespace EnviosExpress
{
    public partial class RastrearGuia : System.Web.UI.Page
    {
        Conectar conectado = new Conectar();
        protected void Page_Load(object sender, EventArgs e)
        { } //Pagina principal 
        protected void btnrecolectar_Click(object sender, EventArgs e)
        {
            string guia = txtcodigoo.Text;//obtener numero de guia
            if (guia == "")//validar si guia no es un dato
            {
                Label11.Text = "Ingrese Numero de Guia";//error por no tener dato
                Label11.ForeColor = Color.Red;
            }//color del texto error
            else
            {
                conectado.conectar();//llamar el metodo para conectarse a la base de datos
                DataTable prueba = new DataTable();//crear una tabla
                prueba = conectado.paquete(guia);//llenar la nueva tabla con datos de guia
                if (prueba.Rows.Count > 0)//validar si la tabla tiene datos
                {
                    //GridView1.DataSource = conectado.Guia6(guia);//obtener datos de la guia
                    //GridView1.DataBind();//mostrar datos de la tabla         

                    GridView5.DataSource = conectado.Guia7(guia);
                    GridView5.DataBind();//mostrar datos de la tabla
                    conectado.desconectar();
                }//desconectar la base de datos
                else
                {
                    Response.Write("<script>alert('ERROR Guia No Existe')</script>");//Mensaje de error
                }
            }
            conectado.desconectar();

        }
        protected void regresar_Click(object sender, EventArgs e)
        { Response.Redirect("MenuPrincipal.aspx"); }
    }
} //Redirigir al menu principal