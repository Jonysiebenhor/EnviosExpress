using System;
using System.Data;
using System.Drawing;


namespace EnviosExpress
{
    public partial class Devolucion : System.Web.UI.Page
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
            string intento = DropDownList1.Text;
            string idpaquete = guia;
            String recibido = txtrecibido.Text;

            if (guia == "")
            {
                Label11.Text = "Ingrese Numero de Guia";
                Label11.ForeColor = Color.Red;
            }

            else if (intento == "--Seleccionar")
            {
                Label11.Text = "Seleccione Motivo de Devolución";
                Label11.ForeColor = Color.Red;
            }
            else
            {
                conectado.conectar();
                String dpi = Session["id"].ToString();
                DataTable prueba = new DataTable();
                prueba = conectado.paquete(guia);
                DataTable entregado = new DataTable();
                entregado = conectado.estadopaquete1(guia);
                if (entregado.Rows.Count > 0)
                {
                    Response.Write("<script>alert('ERROR Guia ya esta Entregada')</script>");
                }
                else if (prueba.Rows.Count > 0)
                {
                    if (intento == "Entregado")
                    {

                        if (recibido == "")
                        {
                            Label11.Text = "Quien Recibe?";
                            Label11.ForeColor = Color.Red;
                        }
                        else
                        {
                            conectado.devolucion(guia, dpi, intento);
                            conectado.entrega1(guia, recibido);
                            Response.Write("<script>alert('Devolución Entregada')</script>");
                            txtcodigoo.Text = "";
                            txtrecibido.Text = "";
                            Label11.Text = "";
                        }
                    }
                    else
                    {
                        conectado.devolucion(guia, dpi, intento);
                        Response.Write("<script>alert('Devolución Reportada')</script>");
                        txtcodigoo.Text = "";
                        txtrecibido.Text = "";
                        Label11.Text = "";
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


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.Text == "Entregado")
            {
                txtrecibido.Visible = true;
                Label12.Visible = true;
            }
            else
            {
                txtrecibido.Visible = false;
                Label12.Visible = false;
            }
        }
    }
}