using System;
using System.Data;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Web.UI.WebControls;
using System.Threading;

namespace EnviosExpress
{
    public partial class ConsultarGuiaAdmin : System.Web.UI.Page
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
                Cargar();
            }
        }
        public void Cargar1()
        {
            string guia = txtcodigoo.Text;
            guia12.Visible = true;
            direccion12.Visible = true;
            telefono12.Visible = true;
            peso12.Visible = true;
            monto12.Visible = true;
            destinatario12.Visible = true;
            tipo12.Visible = true;
            telefono13.Visible = true;
            telefono15.Visible = true;
            destinatario13.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label5.Visible = true;
            recibe.Visible = true;
            txtrecibe.Visible = true;
            Textnombre.Visible = true;
            Texttel.Visible = true;
            Textdir.Visible = true;
            Textnombre.Enabled = false;
            Texttel.Enabled = false;
            Textdir.Enabled = false;



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
            String departamento = Convert.ToString(Convert.ToString(rows["departamento"]));
            String municipio = Convert.ToString(Convert.ToString(rows["municipio"]));
            String zona = Convert.ToString(Convert.ToString(rows["zona"]));
            String valorenvio = Convert.ToString(Convert.ToString(rows["valorenvio"]));
            String destinatario2 = Convert.ToString(Convert.ToString(rows["destinatario2"]));
            String direccion2 = Convert.ToString(Convert.ToString(rows["direccion2"]));
            String telefono2 = Convert.ToString(Convert.ToString(rows["telefono2"]));

            /*ddldepartamento.Items.(departamento);
            /*ddldepartamento.SelectedValue = municipio;
            ddldepartamento.SelectedValue = zona;
            ddldepartamento.SelectedValue = valorenvio;

            ddldepartamento.Text = departamento;*/
            /*ddlmunicipio.Items.Equals(municipio);
            ddlzona.Items.Equals(zona);
            ddlzona0.Items.Equals(valorenvio); ;*/
            Textnombre.Text = destinatario2;
            Texttel.Text = telefono2;
            Textdir.Text = direccion2;
            destinatario11.Text = destinatario1;
            direccion11.Text = direccion1;
            departamento11.Text = departamento1;
            municipio11.Text = municipio1;
            zona11.Text = zona1;
            telefono11.Text = telefono1;
            guia11.Text = guia;
            peso11.Text = peso1;
            tipo11.Text = tipo1;
            monto11.Text = monto1;
            telefono14.Text = telefono;
            remitente11.Text = nombrenegocio;
            telefono16.Text = dirusuario;
            txtrecibe.Text = recibido;
            GridView5.DataSource = conectado.Guia8(guia);
            GridView5.DataBind();//mostrar datos de la tabla
            conectado.desconectar();
            DropDownList1.Visible = true;
            conectado.desconectar();
        }
        public void Cargar()
        {
            conectado.conectar();
            string guia = txtcodigoo.Text;//obtener numero de guia
            GridView5.DataSource = conectado.Guia8(guia);
            GridView5.DataBind();//mostrar datos de la tabla
            conectado.desconectar();
        }
        protected void btnrecolectar_Click(object sender, EventArgs e)
        {
            conectado.conectar();
            String dpi = Session["id"].ToString();
            string guia = txtcodigoo.Text;//obtener numero de guia
            string idpaquete = txtcodigoo.Text;//obtener numero de guia
                                               // DataRow rowss = conectado.Guia2(idpaquete).Rows[0];
                                               //String idusuario = Convert.ToString(Convert.ToString(rowss["idusuario"]));
            if (guia == "")//validar si guia no es un dato
            {
                Label11.Text = "Ingrese Numero de Guia";//error por no tener dato
                Label11.ForeColor = Color.Red;
            }//color del texto error
            /*else if (dpi != idusuario)
            {
                Label11.Text = "Acceso denegado para ver esta guía";//error por no tener dato
                Label11.ForeColor = Color.Red;

                GridView5.Visible = false;
                guia11.Visible = false;
                monto11.Visible = false;
                destinatario11.Visible = false;
                telefono11.Visible = false;
                direccion11.Visible = false;
                destinatario17.Visible = false;
                telefono17.Visible = false;
                direccion17.Visible = false;
                Texttel.Visible = false;
                Textdir.Visible = false;
                tipo11.Visible = false;
                peso11.Visible = false;
                departamento11.Visible = false;
                municipio11.Visible = false;
                zona11.Visible = false;
                remitente11.Visible = false;
                telefono14.Visible = false;
                telefono16.Visible = false;
                DropDownList1.Visible = false;
                guia12.Visible = false;
                direccion12.Visible = false;
                telefono12.Visible = false;
                peso12.Visible = false;
                monto12.Visible = false;
                destinatario12.Visible = false;
                tipo12.Visible = false;
                telefono13.Visible = false;
                telefono15.Visible = false;
                destinatario13.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                Label5.Visible = false;
                recibe.Visible = false;
                txtrecibe.Visible = false;
                Textnombre.Visible = false;
                Texttel.Visible = false;
                Textdir.Visible = false;
                Textnombre.Enabled = false;
                Texttel.Enabled = false;
                Textdir.Enabled = false;
            }*/
            else
            {
                GridView5.Visible = true;
                guia11.Visible = true;
                monto11.Visible = true;
                destinatario11.Visible = true;
                telefono11.Visible = true;
                direccion11.Visible = true;
                destinatario17.Visible = true;
                telefono17.Visible = true;
                direccion17.Visible = true;
                Texttel.Visible = true;
                Textdir.Visible = true;
                tipo11.Visible = true;
                peso11.Visible = true;
                departamento11.Visible = true;
                municipio11.Visible = true;
                zona11.Visible = true;
                remitente11.Visible = true;
                telefono14.Visible = true;
                telefono16.Visible = true;
                DropDownList1.Visible = true;
                guia12.Visible = true;
                direccion12.Visible = true;
                telefono12.Visible = true;
                peso12.Visible = true;
                monto12.Visible = true;
                destinatario12.Visible = true;
                tipo12.Visible = true;
                telefono13.Visible = true;
                telefono15.Visible = true;
                destinatario13.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                Label5.Visible = true;
                recibe.Visible = true;
                txtrecibe.Visible = true;
                Textnombre.Visible = true;
                Texttel.Visible = true;
                Textdir.Visible = true;
                Textnombre.Enabled = true;
                Texttel.Enabled = true;
                Textdir.Enabled = true;
                Label11.Text = "";
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
                    telefono13.Visible = true;
                    telefono15.Visible = true;
                    destinatario13.Visible = true;
                    Label2.Visible = true;
                    Label3.Visible = true;
                    Label5.Visible = true;
                    recibe.Visible = true;
                    txtrecibe.Visible = true;
                    Textnombre.Visible = true;
                    Texttel.Visible = true;
                    Textdir.Visible = true;
                    Textnombre.Enabled = false;
                    Texttel.Enabled = false;
                    Textdir.Enabled = false;



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
                    String departamento = Convert.ToString(Convert.ToString(rows["departamento"]));
                    String municipio = Convert.ToString(Convert.ToString(rows["municipio"]));
                    String zona = Convert.ToString(Convert.ToString(rows["zona"]));
                    String valorenvio = Convert.ToString(Convert.ToString(rows["valorenvio"]));
                    String destinatario2 = Convert.ToString(Convert.ToString(rows["destinatario2"]));
                    String direccion2 = Convert.ToString(Convert.ToString(rows["direccion2"]));
                    String telefono2 = Convert.ToString(Convert.ToString(rows["telefono2"]));

                    /*ddldepartamento.Items.(departamento);
                    /*ddldepartamento.SelectedValue = municipio;
                    ddldepartamento.SelectedValue = zona;
                    ddldepartamento.SelectedValue = valorenvio;

                    ddldepartamento.Text = departamento;*/
                    /*ddlmunicipio.Items.Equals(municipio);
                    ddlzona.Items.Equals(zona);
                    ddlzona0.Items.Equals(valorenvio); ;*/
                    Textnombre.Text = destinatario2;
                    Texttel.Text = telefono2;
                    Textdir.Text = direccion2;
                    destinatario11.Text = destinatario1;
                    direccion11.Text = direccion1;
                    departamento11.Text = departamento1;
                    municipio11.Text = municipio1;
                    zona11.Text = zona1;
                    telefono11.Text = telefono1;
                    guia11.Text = guia;
                    peso11.Text = peso1;
                    tipo11.Text = tipo1;
                    monto11.Text = monto1;
                    telefono14.Text = telefono;
                    remitente11.Text = nombrenegocio;
                    telefono16.Text = dirusuario;
                    txtrecibe.Text = recibido;
                    GridView5.DataSource = conectado.Guia8(guia);
                    GridView5.DataBind();//mostrar datos de la tabla
                    conectado.desconectar();
                    DropDownList1.Visible = true;
                }


                else
                {
                    GridView5.Visible = false;
                    guia11.Visible = false;
                    monto11.Visible = false;
                    destinatario11.Visible = false;
                    telefono11.Visible = false;
                    direccion11.Visible = false;
                    destinatario17.Visible = false;
                    telefono17.Visible = false;
                    direccion17.Visible = false;
                    Texttel.Visible = false;
                    Textdir.Visible = false;
                    tipo11.Visible = false;
                    peso11.Visible = false;
                    departamento11.Visible = false;
                    municipio11.Visible = false;
                    zona11.Visible = false;
                    remitente11.Visible = false;
                    telefono14.Visible = false;
                    telefono16.Visible = false;
                    DropDownList1.Visible = false;
                    guia12.Visible = false;
                    direccion12.Visible = false;
                    telefono12.Visible = false;
                    peso12.Visible = false;
                    monto12.Visible = false;
                    destinatario12.Visible = false;
                    tipo12.Visible = false;
                    telefono13.Visible = false;
                    telefono15.Visible = false;
                    destinatario13.Visible = false;
                    Label2.Visible = false;
                    Label3.Visible = false;
                    Label5.Visible = false;
                    recibe.Visible = false;
                    txtrecibe.Visible = false;
                    Textnombre.Visible = false;
                    Texttel.Visible = false;
                    Textdir.Visible = false;
                    Textnombre.Enabled = false;
                    Texttel.Enabled = false;
                    Textdir.Enabled = false;
                    Response.Write("<script>alert('ERROR Guia No Existe')</script>");//Mensaje de error
                }

            }
            conectado.desconectar();
        }
        protected void regresar_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            Response.Redirect("MenuAdministrador.aspx");
        }




        protected void btnruta_Click(object sender, EventArgs e)
        {

            //Cargar1();
            conectado.conectar();
            String dpi1 = Session["id"].ToString();
            string guiaa = txtcodigoo.Text;//obtener numero de guia
            DataTable entregado = new DataTable();
            entregado = conectado.estadopaquete1(guiaa);
            DataTable liquidado = new DataTable();
            liquidado = conectado.estadopaquete0(guiaa);
            DataTable estado = new DataTable();
            estado = conectado.estadopaquete3(guiaa);

            //DataRow rows = conectado.Guia2(guia).Rows[0];

            //String destinatario1 = Convert.ToString(Convert.ToString(rows["destinatario"]));

            DataRow rowsss = conectado.estadopaquete2(dpi1, guiaa).Rows[0];
            int contador = Convert.ToInt32(Convert.ToInt32(rowsss["Guia"]));

            //if (contador >= 3)
            //{
            //Response.Write("<script>alert('ERROR Solo Puedes Hacer 3 Solicitudes por Guia')</script>");
            //}
            //  else
            //  {
            if (estado.Rows.Count == 0)
            {
                Response.Write("<script>alert('ERROR Guia no ha sido Recolectada')</script>");
            }
            else if (liquidado.Rows.Count > 0)
            {
                Response.Write("<script>alert('ERROR Guia ya esta Liquidada')</script>");
            }
            else if (DropDownList1.Text == "Liquidar el Paquete")
            {
                if (entregado.Rows.Count > 0)
                {
                    ddldepartamento.Visible = false;
                    ddlmunicipio.Visible = false;
                    ddlzona.Visible = false;
                    String dpi = Session["id"].ToString();
                    String guia = txtcodigoo.Text;
                    String intento = "Administrador Solicito Liquidar el Paquete";
                    conectado.intento(intento, guia, dpi);
                    Response.Write("<script>alert(' Se ha Solicitado Liquidar el Paquete')</script>");
                    DropDownList1.Text = "--Solicitudes";
                    btnrecolectar.Enabled = true;
                    btnrecolectar.Visible = true;
                    tnruta.Visible = false;
                    txtcodigoo.Enabled = true;
                }
                else
                {
                    Response.Write("<script>alert('ERROR Primero tiene que ser Entregada la Guia')</script>");
                }

            }

            else if (entregado.Rows.Count > 0)
            {
                Response.Write("<script>alert('ERROR Guia ya esta Entregada')</script>");
            }
            else
            {
                if (DropDownList1.Text == "--Solicitudes")
                {
                    ddldepartamento.Visible = false;
                    ddlmunicipio.Visible = false;
                    ddlzona.Visible = false;

                }
                else if (DropDownList1.Text == "Sacar a Ruta")
                {

                    ddldepartamento.Visible = false;
                    ddlmunicipio.Visible = false;
                    ddlzona.Visible = false;
                    String dpi = Session["id"].ToString();
                    String guia = txtcodigoo.Text;
                    Response.Write("<script>alert(' Se ha solicitado sacar a Ruta')</script>");//Mensaje de error

                    String intento = "Administrador Solicito Sacar a Ruta";
                    conectado.intento(intento, guia, dpi);
                    DropDownList1.Text = "--Solicitudes";
                    btnrecolectar.Enabled = true;
                    btnrecolectar.Visible = true;
                    tnruta.Visible = false;
                    txtcodigoo.Enabled = true;
                }
                else if (DropDownList1.Text == "Hacer Cambios")
                {

                    ddldepartamento.Visible = true;
                    ddlmunicipio.Visible = true;
                    ddlzona.Visible = true;
                    String dpi = Session["id"].ToString();
                    String guia = txtcodigoo.Text;
                    String destinatario = Textnombre.Text;
                    String telefono = Texttel.Text;
                    String direccion = Textdir.Text;
                    String peso = peso11.Text;
                    /*String departamento = ddldepartamento.Text;
                    String municipio = ddlmunicipio.Text;
                    String zona = ddlzona.Text;
                    String valorenvio= ddlzona0.Text;*/

                    conectado.conectar();
                    DataRow rows = conectado.paquete(guia).Rows[0];
                    String montoo = Convert.ToString(Convert.ToString(rows["monto"]));
                    String tipo = Convert.ToString(Convert.ToString(rows["tipo"]));
                    String valorvisita = Convert.ToString(Convert.ToString(rows["valorvisita"]));

                    String valorenvioo = Convert.ToString(Convert.ToString(rows["valorenvio"]));
                    string departamento = ddldepartamento.SelectedItem.Value;
                    string municipio = ddlmunicipio.SelectedItem.Value;
                    string zona = ddlzona.SelectedItem.Value;
                    //string valorenvio = ddlzona0.SelectedItem.Value;
                    if (tipo == "Estandar")
                    {
                        if (ddldepartamento.SelectedValue == "0" || ddlmunicipio.SelectedValue == "0" || ddlzona.SelectedValue == "0" || Textnombre.Text == "" || Texttel.Text == "" || Textdir.Text == "")
                        {
                            Response.Write("<script>alert('Agregar Nombre, Teléfono, Dirección, Departamento, Municipio, Zona')</script>");

                        }
                        else
                        {
                            String valorenvio1 = ddlzona0.SelectedItem.Text;
                            string monto = "";
                            if (peso == "1-8 Libras")
                            {
                                int valorenvio2 = Int32.Parse(valorenvio1);
                                String valorenvio = Convert.ToString(valorenvio2);
                                int valorenvio3 = Int32.Parse(valorenvio1) + Int32.Parse(valorvisita);

                                string cantidadadepositar = "-" + valorenvio3;
                                conectado.conectar();
                                conectado.editarguiapaquete(guia, destinatario, direccion, telefono, monto, valorenvio, cantidadadepositar, departamento, municipio, zona);
                                String intento = "Administrador Realizo Cambio de Datos";
                                conectado.intento(intento, guia, dpi);
                                Response.Write("<script>alert('Se han guardado los Cambios')</script>");
                                DropDownList1.Text = "--Solicitudes";
                                Textnombre.Enabled = false;
                                Texttel.Enabled = false;
                                Textdir.Enabled = false;
                                tnruta.Visible = false;
                                ddldepartamento.Visible = false;
                                ddlmunicipio.Visible = false;
                                ddlzona.Visible = false;
                                ddlzona0.Visible = false;
                                txtcodigoo.Enabled = true;
                            }
                            else if (peso == "9-20 Libras")
                            {

                                int valorenvio2 = Int32.Parse(valorenvio1) + 5;
                                String valorenvio = Convert.ToString(valorenvio2);
                                int valorenvio3 = Int32.Parse(valorenvio1) + 10 + Int32.Parse(valorvisita);


                                string cantidadadepositar = "-" + valorenvio;
                                conectado.conectar();
                                conectado.editarguiapaquete(guia, destinatario, direccion, telefono, monto, valorenvio, cantidadadepositar, departamento, municipio, zona);
                                String intento = "Administrador Realizo Cambio de Datos";
                                conectado.intento(intento, guia, dpi);
                                Response.Write("<script>alert('111 Se han guardado los Cambios')</script>");
                            }
                            else if (peso == "21-50 Libras")
                            {
                                int valorenvio2 = Int32.Parse(valorenvio1) + 30;
                                String valorenvio = Convert.ToString(valorenvio2);
                                int valorenvio3 = Int32.Parse(valorenvio1) + 30 + Int32.Parse(valorvisita);

                                string cantidadadepositar = "-" + valorenvio;
                                conectado.conectar();
                                conectado.editarguiapaquete(guia, destinatario, direccion, telefono, monto, valorenvio, cantidadadepositar, departamento, municipio, zona);
                                String intento = "Administrador Realizo Cambio de Datos";
                                conectado.intento(intento, guia, dpi);
                                Response.Write("<script>alert('Se han guardado los Cambios')</script>");
                                DropDownList1.Text = "--Solicitudes";
                                btnrecolectar.Enabled = true;
                                btnrecolectar.Visible = true;
                                Textnombre.Enabled = false;
                                Texttel.Enabled = false;
                                Textdir.Enabled = false;
                                tnruta.Visible = false;
                                ddldepartamento.Visible = false;
                                ddlmunicipio.Visible = false;
                                ddlzona.Visible = false;
                                ddlzona0.Visible = false;
                                txtcodigoo.Enabled = true;
                            }
                            else if (peso == "101-200 Libras")
                            {
                                int valorenvio2 = Int32.Parse(valorenvio1) + 20;
                                String valorenvio = Convert.ToString(valorenvio2);
                                int valorenvio3 = Int32.Parse(valorenvio1) + 20 + Int32.Parse(valorvisita);

                                string cantidadadepositar = "-" + valorenvio;
                                conectado.conectar();
                                conectado.editarguiapaquete(guia, destinatario, direccion, telefono, monto, valorenvio, cantidadadepositar, departamento, municipio, zona);
                                String intento = "Administrador Realizo Cambio de Datos";
                                conectado.intento(intento, guia, dpi);
                                Response.Write("<script>alert('Se han guardado los Cambios')</script>");
                                DropDownList1.Text = "--Solicitudes";
                                btnrecolectar.Enabled = true;
                                btnrecolectar.Visible = true;
                                Textnombre.Enabled = false;
                                Texttel.Enabled = false;
                                Textdir.Enabled = false;
                                tnruta.Visible = false;
                                ddldepartamento.Visible = false;
                                ddlmunicipio.Visible = false;
                                ddlzona.Visible = false;
                                ddlzona0.Visible = false;
                                txtcodigoo.Enabled = true;
                            }

                        }
                    }
                    else if (tipo == "Pagar Solo Envio")
                    {
                        if (ddldepartamento.SelectedValue == "0" || ddlmunicipio.SelectedValue == "0" || ddlzona.SelectedValue == "0" || Textnombre.Text == "" || Texttel.Text == "" || Textdir.Text == "")
                        {
                            Response.Write("<script>alert(Agregar Nombre, Teléfono, Dirección, Departamento, Municipio, Zona')</script>");

                        }
                        else
                        {
                            String valorenvio1 = ddlzona0.SelectedItem.Text;
                            if (peso == "1-8 Libras")
                            {
                                int valorenvio2 = Int32.Parse(valorenvio1);
                                String valorenvio = Convert.ToString(valorenvio2);
                                String monto = Convert.ToString(valorenvio2);
                                string cantidadadepositar = "-" + valorvisita;
                                conectado.editarguiapaquete(guia, destinatario, direccion, telefono, monto, valorenvio, cantidadadepositar, departamento, municipio, zona);
                                String intento = "Administrador Realizo Cambio de Datos";
                                conectado.intento(intento, guia, dpi);
                                Response.Write("<script>alert('Se han guardado los Cambios')</script>");
                                DropDownList1.Text = "--Solicitudes";
                                btnrecolectar.Enabled = true;
                                btnrecolectar.Visible = true;
                                Textnombre.Enabled = false;
                                Texttel.Enabled = false;
                                Textdir.Enabled = false;
                                tnruta.Visible = false;
                                ddldepartamento.Visible = false;
                                ddlmunicipio.Visible = false;
                                ddlzona.Visible = false;
                                ddlzona0.Visible = false;
                                txtcodigoo.Enabled = true;
                            }
                            else if (peso == "9-20 Libras")
                            {
                                int valorenvio2 = Int32.Parse(valorenvio1) + 10;
                                String valorenvio = Convert.ToString(valorenvio2);
                                String monto = Convert.ToString(valorenvio2);
                                string cantidadadepositar = "-" + valorvisita;
                                conectado.editarguiapaquete(guia, destinatario, direccion, telefono, monto, valorenvio, cantidadadepositar, departamento, municipio, zona);
                                String intento = "Administrador Realizo Cambio de Datos";
                                conectado.intento(intento, guia, dpi);
                                Response.Write("<script>alert('Se han guardado los Cambios')</script>");
                                DropDownList1.Text = "--Solicitudes";
                                btnrecolectar.Enabled = true;
                                btnrecolectar.Visible = true;
                                Textnombre.Enabled = false;
                                Texttel.Enabled = false;
                                Textdir.Enabled = false;
                                tnruta.Visible = false;
                                ddldepartamento.Visible = false;
                                ddlmunicipio.Visible = false;
                                ddlzona.Visible = false;
                                ddlzona0.Visible = false;
                                txtcodigoo.Enabled = true;
                            }
                            else if (peso == "21-50 Libras")
                            {
                                int valorenvio2 = Int32.Parse(valorenvio1) + 30;
                                String valorenvio = Convert.ToString(valorenvio2);
                                String monto = Convert.ToString(valorenvio2);
                                string cantidadadepositar = "-" + valorvisita;
                                conectado.editarguiapaquete(guia, destinatario, direccion, telefono, monto, valorenvio, cantidadadepositar, departamento, municipio, zona);
                                String intento = "Administrador Realizo Cambio de Datos";
                                conectado.intento(intento, guia, dpi);
                                Response.Write("<script>alert('Se han guardado los Cambios')</script>");
                                DropDownList1.Text = "--Solicitudes";
                                btnrecolectar.Enabled = true;
                                btnrecolectar.Visible = true;
                                Textnombre.Enabled = false;
                                Texttel.Enabled = false;
                                Textdir.Enabled = false;
                                tnruta.Visible = false;
                                ddldepartamento.Visible = false;
                                ddlmunicipio.Visible = false;
                                ddlzona.Visible = false;
                                ddlzona0.Visible = false;
                                txtcodigoo.Enabled = true;
                            }
                            else if (peso == "101-200 Libras")
                            {
                                int valorenvio2 = Int32.Parse(valorenvio1) + 20;
                                String valorenvio = Convert.ToString(valorenvio2);
                                String monto = Convert.ToString(valorenvio2);
                                string cantidadadepositar = "-" + valorvisita;
                                conectado.editarguiapaquete(guia, destinatario, direccion, telefono, monto, valorenvio, cantidadadepositar, departamento, municipio, zona);
                                String intento = "Administrador Realizo Cambio de Datos";
                                conectado.intento(intento, guia, dpi);
                                Response.Write("<script>alert('Se han guardado los Cambios')</script>");
                                DropDownList1.Text = "--Solicitudes";
                                btnrecolectar.Enabled = true;
                                btnrecolectar.Visible = true;
                                Textnombre.Enabled = false;
                                Texttel.Enabled = false;
                                Textdir.Enabled = false;
                                tnruta.Visible = false;
                                ddldepartamento.Visible = false;
                                ddlmunicipio.Visible = false;
                                ddlzona.Visible = false;
                                ddlzona0.Visible = false;
                                txtcodigoo.Enabled = true;
                            }
                        }

                    }
                    else if (tipo == "Pago Contra Entrega")
                    {
                        if (ddldepartamento.SelectedValue == "0" || ddlmunicipio.SelectedValue == "0" || ddlzona.SelectedValue == "0" || Textnombre.Text == "" || Texttel.Text == "" || Textdir.Text == "")
                        {
                            Response.Write("<script>alert(Agregar Nombre, Teléfono, Dirección, Departamento, Municipio, Zona')</script>");

                        }
                        else
                        {
                            String valorenviooo = ddlzona0.SelectedItem.Text.ToString();
                            String valorenvio1 = valorenviooo;
                            String monto = montoo;
                            if (peso == "1-8 Libras")
                            {
                                int valorenvio2 = Int32.Parse(valorenvio1);
                                String valorenvio = Convert.ToString(valorenvio2);
                                int valorenvioooo = int.Parse(valorenvio);
                                int montooo = int.Parse(monto);
                                int cantidadadepositarr = montooo - valorenvioooo - int.Parse(valorvisita);
                                string cantidadadepositar = Convert.ToString(cantidadadepositarr);
                                conectado.editarguiapaquete(guia, destinatario, direccion, telefono, monto, valorenvio, cantidadadepositar, departamento, municipio, zona);
                                String intento = "Administrador Realizo Cambio de Datos";
                                conectado.intento(intento, guia, dpi);
                                Response.Write("<script>alert(' 222Se han guardado los Cambios')</script>");
                                DropDownList1.Text = "--Solicitudes";
                                btnrecolectar.Enabled = true;
                                btnrecolectar.Visible = true;
                                Textnombre.Enabled = false;
                                Texttel.Enabled = false;
                                Textdir.Enabled = false;
                                tnruta.Visible = false;
                                ddldepartamento.Visible = false;
                                ddlmunicipio.Visible = false;
                                ddlzona.Visible = false;
                                ddlzona0.Visible = false;
                                txtcodigoo.Enabled = true;
                            }
                            else if (peso == "9-20 Libras")
                            {
                                int valorenvio2 = Int32.Parse(valorenvio1) + 10;
                                String valorenvio = Convert.ToString(valorenvio2);
                                int valorenvioooo = int.Parse(valorenvio);
                                int montooo = int.Parse(monto);
                                int cantidadadepositarr = montooo - valorenvioooo - int.Parse(valorvisita);
                                string cantidadadepositar = Convert.ToString(cantidadadepositarr);
                                conectado.editarguiapaquete(guia, destinatario, direccion, telefono, monto, valorenvio, cantidadadepositar, departamento, municipio, zona);
                                String intento = "Administrador Realizo Cambio de Datos";
                                conectado.intento(intento, guia, dpi);
                                Response.Write("<script>alert('Se han guardado los Cambios')</script>");
                                DropDownList1.Text = "--Solicitudes";
                                btnrecolectar.Enabled = true;
                                btnrecolectar.Visible = true;
                                Textnombre.Enabled = false;
                                Texttel.Enabled = false;
                                Textdir.Enabled = false;
                                tnruta.Visible = false;
                                ddldepartamento.Visible = false;
                                ddlmunicipio.Visible = false;
                                ddlzona.Visible = false;
                                ddlzona0.Visible = false;
                                txtcodigoo.Enabled = true;
                            }
                            else if (peso == "21-50 Libras")
                            {
                                int valorenvio2 = Int32.Parse(valorenvio1) + 30;
                                String valorenvio = Convert.ToString(valorenvio2);
                                int valorenvioooo = int.Parse(valorenvio);
                                int montooo = int.Parse(monto);
                                int cantidadadepositarr = montooo - valorenvioooo - int.Parse(valorvisita);
                                string cantidadadepositar = Convert.ToString(cantidadadepositarr);
                                conectado.editarguiapaquete(guia, destinatario, direccion, telefono, monto, valorenvio, cantidadadepositar, departamento, municipio, zona);
                                String intento = "Administrador Realizo Cambio de Datos";
                                conectado.intento(intento, guia, dpi);
                                Response.Write("<script>alert('Se han guardado los Cambios')</script>");
                                DropDownList1.Text = "--Solicitudes";
                                btnrecolectar.Enabled = true;
                                btnrecolectar.Visible = true;
                                Textnombre.Enabled = false;
                                Texttel.Enabled = false;
                                Textdir.Enabled = false;
                                tnruta.Visible = false;
                                ddldepartamento.Visible = false;
                                ddlmunicipio.Visible = false;
                                ddlzona.Visible = false;
                                ddlzona0.Visible = false;
                                txtcodigoo.Enabled = true;
                            }
                            else if (peso == "101-200 Libras")
                            {
                                int valorenvio2 = Int32.Parse(valorenvio1) + 20;
                                String valorenvio = Convert.ToString(valorenvio2);
                                int valorenvioooo = int.Parse(valorenvio);
                                int montooo = int.Parse(monto);
                                int cantidadadepositarr = montooo - valorenvioooo - int.Parse(valorvisita);
                                string cantidadadepositar = Convert.ToString(cantidadadepositarr);
                                conectado.editarguiapaquete(guia, destinatario, direccion, telefono, monto, valorenvio, cantidadadepositar, departamento, municipio, zona);
                                String intento = "Administrador Realizo Cambio de Datos";
                                conectado.intento(intento, guia, dpi);
                                Response.Write("<script>alert('Se han guardado los Cambios')</script>");
                                DropDownList1.Text = "--Solicitudes";
                                btnrecolectar.Enabled = true;
                                btnrecolectar.Visible = true;
                                Textnombre.Enabled = false;
                                Texttel.Enabled = false;
                                Textdir.Enabled = false;
                                tnruta.Visible = false;
                                ddldepartamento.Visible = false;
                                ddlmunicipio.Visible = false;
                                ddlzona.Visible = false;
                                ddlzona0.Visible = false;
                                txtcodigoo.Enabled = true;
                            }
                        }
                    }
                }
                else if (DropDownList1.Text == "Cambiar Monto")
                {
                    conectado.conectar();
                    String guia = txtcodigoo.Text;
                    DataRow rows = conectado.paquete(guia).Rows[0];
                    int cantidadadepositar1 = Convert.ToInt32(Convert.ToInt32(rows["cantidadadepositar"]));
                    int valorenvio = Convert.ToInt32(Convert.ToInt32(rows["valorenvio"]));
                    int montoant = Convert.ToInt32(Convert.ToInt32(rows["monto"]));
                    int monto1 = Convert.ToInt32(txtmonto11.Text);
                    int cantidadadepositar2 = monto1 - (montoant - cantidadadepositar1);
                    String monto = txtmonto11.Text;
                    String cantidadadepositar = Convert.ToString(cantidadadepositar2);
                    conectado.Nuevomontopaquete(guia, monto, cantidadadepositar);
                    // ddldepartamento.Visible = false;
                    // ddlmunicipio.Visible = false;
                    // ddlzona.Visible = false;
                    // monto11.Visible = false;
                    //txtmonto11.Enabled = true;
                    //txtmonto11.Visible = true;
                    //txtmonto11.Text = montoo;
                    String dpi = Session["id"].ToString();


                    String intento = "Administrador ha Cambiado el Monto";
                    conectado.intento(intento, guia, dpi);
                    Response.Write("<script>alert(' Se ha Cambiado el Monto')</script>");
                    DropDownList1.Text = "--Solicitudes";
                    btnrecolectar.Enabled = true;
                    btnrecolectar.Visible = true;
                    tnruta.Visible = false;
                    txtcodigoo.Enabled = true;
                    txtmonto11.Visible = false;
                    monto11.Visible = true;
                }
                else if (DropDownList1.Text == "Trasladar a Agencia")
                {

                    ddldepartamento.Visible = false;
                    ddlmunicipio.Visible = false;
                    ddlzona.Visible = false;
                    String dpi = Session["id"].ToString();
                    String guia = txtcodigoo.Text;
                    String intento = "Administrador Solicito Trasladar a Agencia";
                    conectado.intento(intento, guia, dpi);
                    Response.Write("<script>alert(' Se han Solicitado Trasladar a Agencia')</script>");
                    DropDownList1.Text = "--Solicitudes";
                    btnrecolectar.Enabled = true;
                    btnrecolectar.Visible = true;
                    tnruta.Visible = false;
                    txtcodigoo.Enabled = true;

                }
                else if (DropDownList1.Text == "Devolución")
                {
                    ddldepartamento.Visible = false;
                    ddlmunicipio.Visible = false;
                    ddlzona.Visible = false;
                    String dpi = Session["id"].ToString();
                    String guia = txtcodigoo.Text;
                    String intento = "Administrador Solicito Devolución";
                    conectado.intento(intento, guia, dpi);
                    Response.Write("<script>alert(' Se ha Solicitado como Devolución')</script>");
                    DropDownList1.Text = "--Solicitudes";
                    btnrecolectar.Enabled = true;
                    btnrecolectar.Visible = true;
                    tnruta.Visible = false;
                    txtcodigoo.Enabled = true;
                }

                else if (DropDownList1.Text == "Otros")
                {
                    String dpi = Session["id"].ToString();
                    String guia = txtcodigoo.Text;
                    String descripcion = Textdir.Text;
                    String intento = "Administrador hizo una Solicitud";
                    conectado.otros(descripcion, guia);
                    conectado.intento(intento, guia, dpi);
                    Response.Write("<script>alert(' Se ha Realizado la Solicitud')</script>");
                    DropDownList1.Text = "--Solicitudes";
                    btnrecolectar.Enabled = true;
                    btnrecolectar.Visible = true;
                    tnruta.Visible = false;
                    Textdir.Visible = false;
                    txtcodigoo.Enabled = true;
                }
            }
            // Cargar1();
            //}
            //protected void btnrecolectar_Click(object sender, EventArgs e)
            // btnrecolectar_Click(object sender, EventArgs e);
            conectado.desconectar();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conectado.conectar();
            destinatario11.Visible = true;
            telefono11.Visible = true;
            direccion11.Visible = true;
            ddldepartamento.Visible = false;
            ddlmunicipio.Visible = false;
            ddlzona.Visible = false;
            ddlzona0.Visible = false;
            Textnombre.Enabled = false;
            Texttel.Enabled = false;
            Textdir.Enabled = false;
            txtcodigoo.Enabled = false;
            destinatario17.Visible = true;
            telefono17.Visible = true;
            direccion17.Visible = true;
            btnrecolectar.Visible = false;
            txtmonto11.Visible = false;
            monto11.Visible = true;
            if (DropDownList1.Text == "--Solicitudes")
            {
                btnrecolectar.Enabled = true;
                btnrecolectar.Visible = true;
                tnruta.Visible = false;
                txtcodigoo.Enabled = true;
            }
            else if (DropDownList1.Text == "Hacer Cambios")
            {

                tnruta.Visible = true;


                String guia = txtcodigoo.Text;
                conectado.conectar();

                DataTable prueba = new DataTable();
                prueba = conectado.paquete(guia);


                if (prueba.Rows.Count > 0)
                {
                    DataRow rows = conectado.paquete(guia).Rows[0];
                    String destinatario = Convert.ToString(Convert.ToString(rows["Destinatario"]));
                    String telefono = Convert.ToString(Convert.ToString(rows["telefono"]));
                    String direccion = Convert.ToString(Convert.ToString(rows["Direccion"]));
                    String destinatario2 = Convert.ToString(Convert.ToString(rows["Destinatario2"]));
                    String telefono2 = Convert.ToString(Convert.ToString(rows["telefono2"]));
                    String direccion2 = Convert.ToString(Convert.ToString(rows["Direccion2"]));
                    String cantidadadepositar = Convert.ToString(Convert.ToString(rows["cantidadadepositar"]));
                    String tipo = Convert.ToString(Convert.ToString(rows["tipo"]));

                    if (destinatario2 == "")
                    {


                        String departamento = Convert.ToString(Convert.ToString(rows["iddepartamento"]));
                        String municipio = Convert.ToString(Convert.ToString(rows["idmunicipio"]));
                        String zona = Convert.ToString(Convert.ToString(rows["idzona"]));
                        String valorenvio = Convert.ToString(Convert.ToString(rows["valorenvio"]));

                        ddldepartamento.Visible = true;
                        ddlmunicipio.Visible = true;
                        ddlzona.Visible = true;
                        ddlzona0.Visible = true;

                        Textnombre.Visible = true;
                        Texttel.Visible = true;
                        Textdir.Visible = true;
                        Textnombre.Enabled = true;
                        Texttel.Enabled = true;
                        Textdir.Enabled = true;
                        Textnombre.Text = destinatario;
                        Texttel.Text = telefono;
                        Textdir.Text = direccion;

                    }
                    else
                    {



                        String departamento = Convert.ToString(Convert.ToString(rows["iddepartamento"]));
                        String municipio = Convert.ToString(Convert.ToString(rows["idmunicipio"]));
                        String zona = Convert.ToString(Convert.ToString(rows["idzona"]));
                        String valorenvio = Convert.ToString(Convert.ToString(rows["valorenvio"]));

                        ddldepartamento.Visible = true;
                        ddlmunicipio.Visible = true;
                        ddlzona.Visible = true;
                        ddlzona0.Visible = true;

                        Textnombre.Enabled = true;
                        Texttel.Enabled = true;
                        Textdir.Enabled = true;
                        Textnombre.Text = destinatario2;
                        Texttel.Text = telefono2;
                        Textdir.Text = direccion2;

                    }
                }

            }

            else if (DropDownList1.Text == "Otros")
            {
                tnruta.Visible = true;


                String guia = txtcodigoo.Text;
                conectado.conectar();

                DataTable prueba = new DataTable();
                prueba = conectado.paquete(guia);


                if (prueba.Rows.Count > 0)
                {
                    DataRow rows = conectado.paquete(guia).Rows[0];
                    String descripcion = Convert.ToString(Convert.ToString(rows["descripcion"]));

                    if (descripcion == "")
                    {
                        Textdir.Enabled = true;

                    }
                    else
                    {



                        Textdir.Enabled = true;
                        Textdir.Text = descripcion;

                    }
                }

            }
            else if (DropDownList1.Text == "Cambiar Monto")
            {
                txtcodigoo.Enabled = false;
                tnruta.Visible = true;
                txtmonto11.Visible = true;
                monto11.Visible = false;

                conectado.conectar();
                String guia = txtcodigoo.Text;
                DataRow rows = conectado.paquete(guia).Rows[0];
                String montoo = Convert.ToString(Convert.ToString(rows["monto"]));
                //ddldepartamento.Visible = false;
                //ddlmunicipio.Visible = false;
                //ddlzona.Visible = false;
                monto11.Visible = false;
                txtmonto11.Enabled = true;
                txtmonto11.Visible = true;
                txtmonto11.Text = montoo;
                //String dpi = Session["id"].ToString();

            }
            else
            {
                txtcodigoo.Enabled = false;
                tnruta.Visible = true;
            }
            conectado.desconectar();
        }

        protected void ddldepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlmunicipio.Items.Clear();
            ddlzona.Items.Clear();
            ddlzona0.Items.Clear();
            ddlmunicipio.Items.Insert(0, new ListItem("--Municipio", "0"));
            ddlzona.Items.Insert(0, new ListItem("--Zona, Aldea, Lugar", "0"));

        }
        protected void ddlmunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlzona.Items.Clear();
            ddlzona0.Items.Clear();
            ddlzona.Items.Insert(0, new ListItem("--Zona, Aldea, Lugar", "0"));

        }
        protected void ddlzona_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlzona0.Items.Clear();

        }

        protected void ddlzona0_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}