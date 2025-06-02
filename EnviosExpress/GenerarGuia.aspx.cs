
using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace EnviosExpress
{
    public partial class GenerarGuia : System.Web.UI.Page

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
                /*String dpi = Request.QueryString["id"].ToString();
                ViewState["dpii"] = dpi;
                conectado.conectar();
                DataRow rows = conectado.consultaUsuarioDPI(dpi).Rows[0];
                String nombre = Convert.ToString(Convert.ToString(rows["primerNombre"]));
                String apellido = Convert.ToString(Convert.ToString(rows["primerApellido"]));
                String negocio = Convert.ToString(Convert.ToString(rows["nombrenegocio"]));
                String sesion = Convert.ToString(Convert.ToString(rows["sesion"]));
                id.Text = nombre;
                id2.Text = apellido;
                id3.Text = negocio;


                DataTable sesionn = new DataTable();
                sesionn = conectado.consultasesion1(dpi, sesion);

                if (sesionn.Rows.Count > 0)
                {
                    DataRow rowss = conectado.consultaUsuarioloign2(dpi).Rows[0];
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                conectado.desconectar();*/
            }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //String dpi = Request.QueryString["id"].ToString();
            Response.Redirect("Menu.aspx");
        }

       protected void Button4_Click(object sender, EventArgs e)
        {
            Remitente0.Text = "";
            Destinatario0.Text = "";
            Tipo0.Text = "";
            Direccion0.Text = "";
            Telefono0.Text = "";
            Monto00.Text = "";
            Peso0.Text = "";
            Departamento0.Text = "";
            Municipio0.Text = "";
            Zona0.Text = "";
            Peso0.Text = "";

            string remitente = txtremitente.Text;
            string destinatario = txtdestinatario.Text;
            string tipo = DropDownList4.Text;
            string direccion = txtdireccion.Text;
            string telefono = txttelefono.Text;
            string peso = DropDownList5.Text;
            string monto = txtmontos.Text;
            string departamento = ddldepartamento.SelectedItem.Value;
            string municipio = ddlmunicipio.SelectedItem.Value;
            string zona = ddlzona.SelectedItem.Value;
            String dpi = Session["id"].ToString();
            string valorenvio = montoenvio.Text;

           

            if (remitente == "")
            {
                Remitente0.Text = "Agregue Nombre Del Remitente";
                Remitente0.ForeColor = Color.Red;
            }
            else if (destinatario == "")
            {
                Destinatario0.Text = "Agregue Nombre Del Destinatario";
                Destinatario0.ForeColor = Color.Red;
            }
            else if (departamento == "0")
            {
                Departamento0.Text = "Seleccione Un departamento";
                Departamento0.ForeColor = Color.Red;
                Municipio0.Text = "Seleccione Un Municipio";
                Municipio0.ForeColor = Color.Red;
                Zona0.Text = "Seleccione Una Zona, Aldea o Lugar";
                Zona0.ForeColor = Color.Red;
            }
            else if (municipio == "0")
            {
                Municipio0.Text = "Seleccione Un Municipio";
                Municipio0.ForeColor = Color.Red;
                Zona0.Text = "Seleccione Una Zona, Aldea o Lugar";
                Zona0.ForeColor = Color.Red;
            }
            else if (zona == "0")
            {
                Zona0.Text = "Seleccione Una Zona, Aldea o Lugar";
                Zona0.ForeColor = Color.Red;
            }
            else if (direccion == "")
            {
                Direccion0.Text = "Agregue Una Direccion";
                Direccion0.ForeColor = Color.Red;
            }
            else if (peso == "--Peso")
            {
                Peso0.Text = "Agregue Peso";
                Peso0.ForeColor = Color.Red;
            }
            else if (telefono == "")
            {
                Telefono0.Text = "Agregue minimo un numero de telefono";
                Telefono0.ForeColor = Color.Red;
            }
           
            else if (tipo == "--Tipo de Servicio")
            {
                Tipo0.Text = "Agregue Un Tipo de Servicio";
                Tipo0.ForeColor = Color.Red;
            }
            else if (tipo == "Pago Contra Entrega" & monto == "")
            {
                Monto00.Text = "Agrege una cantidad entre Q1 y Q5,000";
                Monto00.ForeColor = Color.Red;
            }
            else
            {
                if (tipo == "Estandar")
                {
                    monto = "";
                    string cantidadadepositar = "-" + valorenvio;
                    conectado.conectar();
                    
                    conectado.crearguiapaquete(remitente, destinatario, direccion, telefono, monto, peso, valorenvio, cantidadadepositar, departamento, municipio, zona,dpi, tipo);

                    DataRow rows = conectado.Guia().Rows[0];
                    String guia = Convert.ToString(Convert.ToString(rows["idpaquete"]));
                    String dpii = Convert.ToString(Convert.ToString(dpi));
                    //Response.Redirect("DescargarGuia.aspx?id=" + guia+"&dpi="+dpii);
                    Response.Redirect("DescargarGuia.aspx?guia=" + guia);
                }
                else if (tipo == "Pagar Solo Envio")
                {
                    string cantidadadepositar = "-" ;

                    monto = montoenvio.Text;
                    valorenvio = montoenvio.Text;
                    conectado.conectar();
                    conectado.crearguiapaquete(remitente, destinatario, direccion, telefono, monto, peso, valorenvio, cantidadadepositar, departamento, municipio, zona,dpi, tipo);

                    DataRow rows = conectado.Guia().Rows[0];
                    String guia = Convert.ToString(Convert.ToString(rows["idpaquete"]));
                    String dpii = Convert.ToString(Convert.ToString(dpi));
                    Response.Redirect("DescargarGuia.aspx?guia=" + guia);
                }

                else
                {
                    int montoo = int.Parse(txtmontos.Text);
                    if (tipo == "Pago Contra Entrega" & montoo < 25)
                    {
                        Monto00.Text = "Agrege una cantidad mayor a Q25";
                        Monto00.ForeColor = Color.Red;
                    }
                    else if (tipo == "Pago Contra Entrega" & montoo > 5000)
                    {
                        Monto00.Text = "Agrege una cantidad menor a Q5,000";
                        Monto00.ForeColor = Color.Red;
                    }
                    else
                    {
                        int valorenvioo = int.Parse(valorenvio);
                        int montooo = int.Parse(monto);
                        int cantidadadepositarr = montooo - valorenvioo;
                        string cantidadadepositar = Convert.ToString(cantidadadepositarr);

                        conectado.conectar();
                        conectado.crearguiapaquete(remitente, destinatario, direccion, telefono, monto, peso, valorenvio, cantidadadepositar, departamento, municipio, zona,dpi, tipo);

                        DataRow rows = conectado.Guia().Rows[0];
                        String guia = Convert.ToString(Convert.ToString(rows["idpaquete"]));
                        String dpii = Convert.ToString(Convert.ToString(dpi));
                        Response.Redirect("DescargarGuia.aspx?guia=" + guia);
                    }
                }
            }
            conectado.desconectar();
        }
        protected void ddldepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlmunicipio.Items.Clear();
            ddlzona.Items.Clear();
            ddlzona0.Items.Clear();
            DropDownList5.Text = "--Peso";
            DropDownList4.Text = "--Tipo de Servicio";
            montoenvio.Text = "";

            ddlmunicipio.Items.Insert(0, new ListItem("--Municipio", "0"));
            ddlzona.Items.Insert(0, new ListItem("--Zona, Aldea, Lugar", "0"));
            Peso0.Text = "";
        }
        protected void ddlmunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlzona.Items.Clear();
            ddlzona0.Items.Clear();
            DropDownList5.Text = "--Peso";
            DropDownList4.Text = "--Tipo de Servicio";
            montoenvio.Text = "";
            ddlzona.Items.Insert(0, new ListItem("--Zona, Aldea, Lugar", "0"));
            Peso0.Text = "";
        }
        protected void ddlzona_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlzona0.Items.Clear();
            Peso0.Text = "";
        }
        protected void ddlzona0_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList4.Text == "Pago Contra Entrega")
            {
                Montoacobrar.Visible = true;
                txtmontos.Visible = true;
            }
            else
            {
                Montoacobrar.Visible = false;
                txtmontos.Visible = false;
            }
            Tipo0.Text = "";
        }

        /*protected void cerrarsecion_Click(object sender, EventArgs e)
        {
            String dpi = Request.QueryString["id"].ToString();
            DataTable sesion = new DataTable();
            sesion = conectado.cerrarsesion(dpi);
            conectado.desconectar();
            Response.Redirect("Login.aspx");
        }*/

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList5.Text == "--Peso")
            {
                Peso0.Text = "Agregue el Peso del Paquete";
                Peso0.ForeColor = Color.Red;
            }
            else if (DropDownList5.Text == "1-8 Libras")
            {
                if (ddlzona0.Text == "" || ddldepartamento.Text == "" || ddlmunicipio.Text == "")
                {
                    Peso0.Text = "Agregue Zona,Aldea,Lugar";
                    Peso0.ForeColor = Color.Red;
                    DropDownList5.Text = "--Peso";

                }
                else if(ddlzona0.SelectedItem.Text == "25" || ddlzona0.SelectedItem.Text == "30" || ddlzona0.SelectedItem.Text == "35")
                {
                    Montoacobrar.Visible = false;
                    txtmontos.Visible = false;
                    montoenvio.Text = ddlzona0.SelectedItem.Text;
                    Peso0.Text = "";
                    tarifaenvio.Visible=true;
                }
                else
                {
                    Peso0.Text = "Agregue Zona,Aldea,Lugar";
                    Peso0.ForeColor = Color.Red;
                    DropDownList5.Text = "--Peso";
                }
            }
            else if (DropDownList5.Text == "9-20 Libras")
            {
                if (ddlzona0.Text == "" || ddldepartamento.Text == "" || ddlmunicipio.Text == "")
                {
                    Peso0.Text = "Agregue Zona,Aldea,Lugar";
                    Peso0.ForeColor = Color.Red;
                    DropDownList5.Text = "--Peso";

                }
                else if (ddlzona0.SelectedItem.Text == "25" || ddlzona0.SelectedItem.Text == "30" || ddlzona0.SelectedItem.Text == "35")
                {
                    String tarifa = ddlzona0.SelectedItem.Text;
                    int tarifaa = Int32.Parse(tarifa) + 10;
                    String tarifaaa = Convert.ToString(tarifaa);
                    montoenvio.Text = tarifaaa;
                    Peso0.Text = "";
                    tarifaenvio.Visible = true;
                }
                else
                {
                    Peso0.Text = "Agregue Zona,Aldea,Lugar";
                    Peso0.ForeColor = Color.Red;
                    DropDownList5.Text = "--Peso";
                }
            }
            else if (DropDownList5.Text == "21-50 Libras")
            {
                if (ddlzona0.Text == "" || ddldepartamento.Text == "" || ddlmunicipio.Text == "")
                {
                    Peso0.Text = "Agregue Zona,Aldea,Lugar";
                    Peso0.ForeColor = Color.Red;
                    DropDownList5.Text = "--Peso";

                }
                else if (ddlzona0.SelectedItem.Text == "25" || ddlzona0.SelectedItem.Text == "30" || ddlzona0.SelectedItem.Text == "35")
                {
                    String tarifa = ddlzona0.SelectedItem.Text;
                    int tarifaa = Int32.Parse(tarifa) + 30;
                    String tarifaaa = Convert.ToString(tarifaa);
                    montoenvio.Text = tarifaaa;
                    Peso0.Text = "";
                    tarifaenvio.Visible = true;
                }
                else
                {
                    Peso0.Text = "Agregue Zona,Aldea,Lugar";
                    Peso0.ForeColor = Color.Red;
                    DropDownList5.Text = "--Peso";
                }
            }
            /*else if (DropDownList5.Text == "101-200 Libras")
            {
                if (ddlzona0.Text == "" || ddldepartamento.Text == "" || ddlmunicipio.Text == "")
                {
                    Peso0.Text = "Agregue Zona,Aldea,Lugar";
                    Peso0.ForeColor = Color.Red;
                    DropDownList5.Text = "--Peso";

                }
                else if (ddlzona0.SelectedItem.Text == "25" || ddlzona0.SelectedItem.Text == "30" || ddlzona0.SelectedItem.Text == "35")
                {
                    String tarifa = ddlzona0.SelectedItem.Text;
                    int tarifaa = Int32.Parse(tarifa) + 20;
                    String tarifaaa = Convert.ToString(tarifaa);
                    montoenvio.Text = tarifaaa;
                    Peso0.Text = "";
                    tarifaenvio.Visible = true;
                }
                else 
                {
                    Peso0.Text = "Agregue Zona,Aldea,Lugar";
                    Peso0.ForeColor = Color.Red;
                    DropDownList5.Text = "--Peso";
                }
            }*/
        }
        protected void ddlzona0_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
        }
    }
}