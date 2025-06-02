using System;
using System.Data;
using System.Drawing;


namespace EnviosExpress
{
    public partial class Entrega : System.Web.UI.Page
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

        protected void txtrecolectar_Click(object sender, EventArgs e)
        {
        }
        protected void btnrecolectar_Click(object sender, EventArgs e)
        {
            string guia = txtcodigoo.Text;
            string idpaquete = guia;
            String recibido = txtrecibido.Text;
            if (guia == "")
            {
                Label11.Text = "Ingrese Numero de Guia";
                Label11.ForeColor = Color.Red;
            }
            else if (recibido == "")
            {
                Label11.Text = "Quien Recibe?";
                Label11.ForeColor = Color.Red;
            }
            else
            {
                conectado.conectar();
                DataTable prueba = new DataTable();
                prueba = conectado.paquete(guia);
                if (prueba.Rows.Count > 0)
                {
                    DataTable entregado = new DataTable();
                    entregado = conectado.estadopaquete1(guia);
                    if (entregado.Rows.Count > 0)
                    {
                        Response.Write("<script>alert('ERROR Guia ya esta Entregada')</script>");
                    }
                    else
                    {

                        String dpi = Session["id"].ToString();
                        conectado.entrega(guia, dpi);
                        conectado.entrega1(guia, recibido);
                        Response.Write("<script>alert('Guía Entregada')</script>");
                        txtcodigoo.Text = "";
                        txtrecibido.Text = "";
                    }

                }

                else
                {
                    Response.Write("<script>alert('ERROR Guia No Existe')</script>");
                }
                conectado.desconectar();
            }
            conectado.desconectar();
        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            Response.Redirect("MenuMensajero.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Lector.aspx");
            
        }
    }
}