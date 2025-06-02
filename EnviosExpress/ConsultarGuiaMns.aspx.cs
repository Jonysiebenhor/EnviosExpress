using System;
using System.Data;
using System.Drawing;

namespace EnviosExpress
{
    public partial class ConsultarGuiaMns : System.Web.UI.Page
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

                conectado.conectar();
                DataTable dt = new DataTable();
                dt = conectado.Guia2(guia);
                if (dt.Rows.Count > 0)
                {
                    guia12.Visible = true;
                    direccion12.Visible = true;
                    telefono12.Visible = true;
                    peso12.Visible = true;
                    monto12.Visible = true;
                    destinatario12.Visible = true;
                    tipo12.Visible = true;
                    Label3.Visible = true;
                    Label5.Visible = true;
                    recibe.Visible = true;
                    txtrecibe.Visible = true;


                    conectado.conectar();
                    DataRow rows = conectado.Guia2(guia).Rows[0];
                    String destinatario1 = Convert.ToString(Convert.ToString(rows["destinatario"]));
                    String direccion1 = Convert.ToString(Convert.ToString(rows["direccion"]));
                    String departamento1 = Convert.ToString(Convert.ToString(rows["dep"]));
                    String municipio1 = Convert.ToString(Convert.ToString(rows["mun"]));
                    String zona1 = Convert.ToString(Convert.ToString(rows["zon"]));
                    String telefono1 = Convert.ToString(Convert.ToString(rows["telefono"]));
                    String peso1 = Convert.ToString(Convert.ToString(rows["peso"]));
                    String tipo1 = Convert.ToString(Convert.ToString(rows["tipo"]));
                    String monto1 = Convert.ToString(Convert.ToString(rows["monto"]));
                    String nombrenegocio = Convert.ToString(Convert.ToString(rows["remitente"]));
                    String telefono = Convert.ToString(Convert.ToString(rows["telcliente"]));
                    String fecha = Convert.ToString(Convert.ToString(rows["fecha"]));
                    String fecha1 = Convert.ToString(Convert.ToString(rows["fecha1"]));
                    String fecha2 = Convert.ToString(Convert.ToString(rows["fecha2"]));
                    String dirusuario = Convert.ToString(Convert.ToString(rows["dirusuario"]));
                    String recibido = Convert.ToString(Convert.ToString(rows["recibido"]));
                    guia11.Text = guia;
                    destinatario11.Text = destinatario1;
                    direccion11.Text = direccion1;
                    departamento11.Text = departamento1;
                    municipio11.Text = municipio1;
                    zona11.Text = zona1;
                    telefono11.Text = telefono1;
                    peso11.Text = peso1;
                    tipo11.Text = tipo1;
                    monto11.Text = monto1;
                    txtrecibe.Text = recibido;
                    GridView5.DataSource = conectado.Guia8(guia);
                    GridView5.DataBind();//mostrar datos de la tabla
                    conectado.desconectar();
                }

                else
                {
                    Response.Write("<script>alert('ERROR Guia No Existe')</script>");//Mensaje de error
                }
            }
        }
        protected void regresar_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            Response.Redirect("MenuMensajero.aspx");
        }

    }
}