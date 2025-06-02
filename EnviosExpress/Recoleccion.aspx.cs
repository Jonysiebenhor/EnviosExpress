using System;
using System.Data;
using System.Drawing;


namespace EnviosExpress
{
    public partial class Recoleccion : System.Web.UI.Page
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
                if (prueba.Rows.Count > 0)
                {

                    DataRow rows = conectado.estadopaquete(guia).Rows[0];
                    String recolectadoo = Convert.ToString(Convert.ToString(rows["estado"]));
                    String dpi = Session["id"].ToString();
                    DataTable entregado = new DataTable();
                    entregado = conectado.estadopaquete1(guia);

                    if (recolectadoo == "Recolectado")
                    {
                        Response.Write("<script>alert('ERROR Guia ya esta Recolectada')</script>");
                    }
                    else if (entregado.Rows.Count > 0)
                    {
                        Response.Write("<script>alert('ERROR Guia ya esta Entregada')</script>");
                    }

                    else
                    {
                        prueba = conectado.recolectado(guia, dpi);
                        Response.Write("<script>alert('Guia Recolectada')</script>");
                        txtcodigoo.Text = "";

                        if (CheckBox3.Checked == true)
                        {
                            prueba = conectado.ruta(guia, dpi);
                            CheckBox3.Checked = false;
                        }
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

    }
}