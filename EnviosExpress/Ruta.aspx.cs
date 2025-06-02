using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnviosExpress
{
    public partial class Ruta : System.Web.UI.Page
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
            String dpi = Session["id"].ToString();
            Response.Redirect("MenuMensajero.aspx");
        }

        protected void btnrecolectar_Click(object sender, EventArgs e)
        {

            string guia = txtcodigoo.Text;
            string idpaquete = guia;
            if (guia == "")
            {
                Label11.Text = "Ingrese Numero de Guia";
                Label11.ForeColor = Color.Red;
            }
            else
            {
                conectado.conectar();
                DataTable prueba = new DataTable();
                prueba = conectado.estadopaquete(guia);
                DataTable entregado = new DataTable();
                entregado = conectado.estadopaquete1(guia);


                if (entregado.Rows.Count > 0)
                {
                    Response.Write("<script>alert('ERROR Guia ya esta Entregada')</script>");
                }
                else if (prueba.Rows.Count > 0)
                {
                    String dpi = Session["id"].ToString();
                    prueba = conectado.ruta(guia, dpi);
                    Response.Write("<script>alert('Guía en Ruta')</script>");
                    txtcodigoo.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('ERROR Guia No Existe')</script>");
                }
                conectado.desconectar();
            }
            conectado.desconectar();
        }
    }
}