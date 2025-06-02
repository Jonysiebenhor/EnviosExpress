using System;
using System.Data;
using System.Drawing;


namespace EnviosExpress
{
    public partial class IntentoEntrega : System.Web.UI.Page
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
            if (guia == "")
            {
                Label11.Text = "Ingrese Numero de Guia";
                Label11.ForeColor = Color.Red;
            }
            else if (intento == "--Seleccionar")
            {
                Label11.Text = "Seleccione intento entrega fallido";
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
                    DataRow rows = conectado.paquete(guia).Rows[0];
                    String valorenviooo = Convert.ToString(Convert.ToString(rows["valorenvio"]));
                    String valorvisita1 = Convert.ToString(Convert.ToString(rows["valorvisita"]));
                    String cantidadadepositarr1 = Convert.ToString(Convert.ToString(rows["cantidadadepositar"]));
                    conectado.intentomns(intento, guia, dpi);


                    if (CheckBox3.Checked == true)
                    {
                        int valorenvioo = int.Parse(valorenviooo);
                        int valorvisita2 = int.Parse(valorvisita1);
                        int valorenvio4 = valorenvioo + valorvisita2;
                        string valorvisita = Convert.ToString(valorenvio4);
                        conectado.intento1(guia, valorvisita);



                        int cantidadadepositarr2 = int.Parse(cantidadadepositarr1);
                        int cantidadadepositarr = cantidadadepositarr2 - valorenvioo;
                        string cantidadadepositar = Convert.ToString(cantidadadepositarr);

                        prueba = conectado.intento2(guia, cantidadadepositar);
                        CheckBox3.Checked = false;

                    }
                    Response.Write("<script>alert('Intento Reportado')</script>");
                    txtcodigoo.Text = "";
                    DropDownList1.SelectedValue = "--Seleccionar";
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