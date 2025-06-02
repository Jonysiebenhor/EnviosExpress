

using System;
using System.Data;
using System.Drawing;


namespace EnviosExpress
{
    public partial class CrearCuentaAdmin : System.Web.UI.Page
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

        protected void crear_Click(object sender, EventArgs e)
        {
            nombre1.Text = "";
            apellido1.Text = "";
            dpi0.Text = "";
            direccion0.Text = "";
            correo0.Text = "";
            nit0.Text = "";
            telefono0.Text = "";
            nacimiento0.Text = "";
            banco0.Text = "";
            contraseña0.Text = "";
            contraseña20.Text = "";
            tipocuenta0.Text = "";
            banconombre0.Text = "";
            negocio0.Text = "";
            producto0.Text = "";
            Rol0.Text = "";

            string nombre = txtnombre1.Text;
            string nombre2 = txtnombre2.Text;
            if (nombre2 == "")
            {
                nombre2 = "null";
            }
            string nombre3 = txtnombre3.Text;
            if (nombre3 == "")
            {
                nombre3 = "null";
            }
            string apellido = txtapellido1.Text;
            string apellido2 = txtapellido2.Text;
            if (apellido2 == "")
            {
                apellido2 = "null";
            }
            string apellido3 = txtapellido3.Text;
            if (apellido3 == "")
            {
                apellido3 = "null";
            }
            string negocio = txtnegocio.Text;
            string producto = txtproducto.Text;
            string dpi = txtdpi.Text;
            string direccion = txtdireccion.Text;
            string correo = txtcorreo.Text;
            string nit = txtnit.Text;
            string telefono = txttelefono.Text;
            string nacimiento = txtnacimiento.Text;
            string banconombre = DropDownList1.Text;
            string tipocuenta = DropDownList2.Text;
            string cuentabancaria = txtbanco.Text;
            string rol = ddlRol.Text;
            string rol1 = ddlRol.SelectedItem.Value;
            string activo = ddlActivo.SelectedItem.Value;
            string contraseña = txtcontraseña.Text;
            string contraseña2 = txtcontraseña2.Text;

            if (nombre == "")
            {
                nombre1.Text = "Agregue Primer Nombre";
                nombre1.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (apellido == "")
            {
                apellido1.Text = "Agregue Primer Apellido";
                apellido1.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (negocio == "")
            {
                negocio0.Text = "Agregue Nombre del negocio";
                negocio0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (producto == "")
            {
                producto0.Text = "Agregue Producto que Distribuye";
                producto0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (dpi == "")
            {
                dpi0.Text = "Agregue DPI";
                dpi0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (direccion == "")
            {
                direccion0.Text = "Agregue Direccion";
                direccion0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (correo == "")
            {
                correo0.Text = "Agregue Correo";
                correo0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (nit == "")
            {
                nit0.Text = "Agregue Nit";
                nit0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (telefono == "")
            {
                telefono0.Text = "Agregue Numero de Teléfono";
                telefono0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (nacimiento == "")
            {
                nacimiento0.Text = "Agregue Fecha Nacimiento";
                nacimiento0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (banconombre == "--Banco")
            {
                banconombre0.Text = "Agregue Nombre del Banco";
                banconombre0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (tipocuenta == "--Tipo Cuenta")
            {
                tipocuenta0.Text = "Agregue Tipo de Cuenta Bancaria";
                tipocuenta0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (cuentabancaria == "")
            {
                banco0.Text = "Agregue Cuenta Bancaria";
                banco0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (rol1 == "0")
            {
                Rol0.Text = "Agregue Rol del Usuario";
                Rol0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (activo == "2")
            {
                Activo0.Text = "Asigne Actividad del Usuario";
                Activo0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (contraseña == "")
            {
                contraseña0.Text = "Agregue Una Contraseña";
                contraseña0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (contraseña2 == "")
            {
                contraseña20.Text = "Confirme la Contraseña";
                contraseña20.ForeColor = Color.Red;
            }
            else if (contraseña != contraseña2)
            {
                contraseña20.Text = "La Contraseña no Coindice";
                contraseña20.ForeColor = Color.Red;
            }
            else
            {
                conectado.conectar();

                DataTable prueba = new DataTable();
                prueba = conectado.consultaUsuarioDPI(dpi);

                if (prueba.Rows.Count == 0)
                {
                    conectado.conectar();
                    conectado.crearusuario(nombre, nombre2, nombre3, apellido, apellido2, apellido3, negocio, producto, dpi, direccion, correo, nit, telefono, nacimiento, banconombre, tipocuenta, cuentabancaria, rol, activo, contraseña);

                    // Response.Write("<script>alert('Usuario Registrado Exitosamente')</script>");

                    txtnombre1.Text = "";
                    txtnombre2.Text = "";
                    txtnombre3.Text = "";
                    txtapellido1.Text = "";
                    txtapellido2.Text = "";
                    txtapellido3.Text = "";
                    txtdpi.Text = "";
                    txtdireccion.Text = "";
                    txtcorreo.Text = "";
                    txtnit.Text = "";
                    txttelefono.Text = "";
                    txtnacimiento.Text = "";
                    txtbanco.Text = "";
                    txtcontraseña.Text = "";
                    txtcontraseña2.Text = "";
                    DropDownList1.SelectedValue = "--Banco";
                    DropDownList2.SelectedValue = "--Tipo Cuenta";
                    txtnegocio.Text = "";
                    txtproducto.Text = "";
                    ddlRol.SelectedValue = "0";
                    ddlActivo.SelectedValue = "2";
                    Response.Write("<script>alert('Exito al crear la cuenta')</script>");
                }
                else
                {


                    Response.Write("<script>alert('DPI ya esta registrado')</script>");
                    contraseña20.Text = "Ya existe una cuenta con este numero de DPI: " + dpi;
                    contraseña20.ForeColor = Color.Red;
                }
            }
            conectado.desconectar();
        }


        protected void regresar_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            Response.Redirect("MenuAdministrador.aspx");
        }

    }
}