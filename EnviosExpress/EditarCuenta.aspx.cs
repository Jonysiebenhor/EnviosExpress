using System;
using System.Data;
using System.Drawing;

namespace EnviosExpress
{
    public partial class EditarCuenta : System.Web.UI.Page
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

        protected void Button1_Click1(object sender, EventArgs e)
        {
            dpi000.Text = "";
            String dpi = txtdpi00.Text;
            conectado.conectar();

            DataTable prueba = new DataTable();
            prueba = conectado.consultaUsuarioDPI(dpi);


            if (prueba.Rows.Count > 0)
            {
                DataRow rows = conectado.consultaUsuarioDPI(dpi).Rows[0];
                String primerNombre = Convert.ToString(Convert.ToString(rows["primerNombre"]));
                String segundoNombre = Convert.ToString(Convert.ToString(rows["segundoNombre"]));
                String tercerNombre = Convert.ToString(Convert.ToString(rows["tercerNombre"]));
                String primerApellido = Convert.ToString(Convert.ToString(rows["primerApellido"]));
                String segundoApellido = Convert.ToString(Convert.ToString(rows["segundoApellido"]));
                String ApellidoCasada = Convert.ToString(Convert.ToString(rows["ApellidoCasada"]));
                String nombrenegocio = Convert.ToString(Convert.ToString(rows["nombrenegocio"]));
                String producto = Convert.ToString(Convert.ToString(rows["producto"]));
                String dpiii = Convert.ToString(Convert.ToString(rows["dpi"]));
                String direccion = Convert.ToString(Convert.ToString(rows["direccion"]));
                String correo = Convert.ToString(Convert.ToString(rows["correo"]));
                String nit = Convert.ToString(Convert.ToString(rows["nit"]));
                String telefono = Convert.ToString(Convert.ToString(rows["telefono"]));
                String nacimiento = Convert.ToString(Convert.ToString(rows["nacimiento"]));
                String nombrebanco = Convert.ToString(Convert.ToString(rows["nombrebanco"]));
                String tipocuenta = Convert.ToString(Convert.ToString(rows["tipocuenta"]));
                String cuentabancaria = Convert.ToString(Convert.ToString(rows["cuentabancaria"]));
                String rol = Convert.ToString(Convert.ToString(rows["rol"]));
                String activo = Convert.ToString(Convert.ToString(rows["activo"]));
                String contraseña = Convert.ToString(Convert.ToString(rows["contraseña"]));

                txtnombre1.Enabled = true;
                txtdpi00.Enabled = false;
                txtnombre2.Enabled = true;
                txtnombre3.Enabled = true;
                txtapellido1.Enabled = true;
                txtapellido2.Enabled = true;
                txtapellido3.Enabled = true;
                txtnegocio.Enabled = true;
                txtproducto.Enabled = true;
                txtdpi.Enabled = true;
                txtdireccion.Enabled = true;
                txtcorreo.Enabled = true;
                txtnit.Enabled = true;
                txttelefono.Enabled = true;
                txtnacimiento.Enabled = true;
                txtbanconombre.Enabled = true;
                txttipocuenta.Enabled = true;
                txtbanco.Enabled = true;
                ddlRol.Enabled = true;
                ddlActivo.Enabled = true;
                txtcontraseña.Enabled = true;
                txtcontraseña2.Enabled = true;
                Button2.Enabled = true;


                txtnombre1.Text = primerNombre;
                txtnombre2.Text = segundoNombre;
                txtnombre3.Text = tercerNombre;
                txtapellido1.Text = primerApellido;
                txtapellido2.Text = segundoApellido;
                txtapellido3.Text = ApellidoCasada;
                txtnegocio.Text = nombrenegocio;
                txtproducto.Text = producto;
                txtdpi.Text = dpiii;
                txtdireccion.Text = direccion;
                txtcorreo.Text = correo;
                txtnit.Text = nit;
                txttelefono.Text = telefono;
                txtnacimiento.Text = nacimiento;
                txtbanconombre.Text = nombrebanco;
                txttipocuenta.Text = tipocuenta;
                txtbanco.Text = cuentabancaria;
                if (rol == "1")
                {
                    ddlRol.SelectedValue = "1";
                }
                if (rol == "2")
                {
                    ddlRol.SelectedValue = "2";
                }
                if (rol == "3")
                {
                    ddlRol.SelectedValue = "3";
                }
                if (activo == "True")
                {
                    ddlActivo.SelectedValue = "1";
                }
                if (activo == "False")
                {
                    ddlActivo.SelectedValue = "2";
                }
                txtcontraseña.Text = contraseña;
                txtcontraseña2.Text = contraseña;

            }
            else if (dpi == "")
            {
                dpi000.Text = "Agregue DPI";
                dpi000.ForeColor = Color.Red;
            }
            else if (prueba.Rows.Count == 0)
            {
                dpi000.Text = "DPI no Existe";
                dpi000.ForeColor = Color.Red;

            }

            conectado.desconectar();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            /* DataRow rows = conectado.consultaUsuarioloign2(dpi).Rows[0];
             String activo = Convert.ToString(Convert.ToString(rows["activo"]));*/
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


            String dpi = txtdpi00.Text;
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
            string dpii = txtdpi.Text;
            string direccion = txtdireccion.Text;
            string correo = txtcorreo.Text;
            string nit = txtnit.Text;
            string telefono = txttelefono.Text;
            string nacimiento = txtnacimiento.Text;
            string banconombre = txtbanconombre.Text;
            string tipocuenta = txttipocuenta.Text;
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
            else if (dpii == "")
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
            else if (banconombre == "")
            {
                banconombre0.Text = "Agregue Nombre del Banco";
                banconombre0.ForeColor = Color.Red;
                contraseña20.Text = "Faltan Datos";
                contraseña20.ForeColor = Color.Red;
            }
            else if (tipocuenta == "")
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

                // DataTable prueba2 = new DataTable();
                // prueba2 = conectado.consultaUsuarioDPI(dpi);

                // if (prueba2.Rows.Count == 0)
                {
                    conectado.conectar();
                    conectado.editarusuario(nombre, nombre2, nombre3, apellido, apellido2, apellido3, negocio, producto, dpii, direccion, correo, nit, telefono, nacimiento, banconombre, tipocuenta, cuentabancaria, rol, activo, contraseña, dpi);

                    Response.Write("<script>alert('El Usuario Se Ha Actualizado')</script>");
                    txtnombre1.Text = "";
                    txtdpi00.Text = "";
                    txtnombre2.Text = "";
                    txtnombre3.Text = "";
                    txtapellido1.Text = "";
                    txtapellido2.Text = "";
                    txtapellido3.Text = "";
                    txtnegocio.Text = "";
                    txtproducto.Text = "";
                    txtdpi.Text = "";
                    txtdireccion.Text = "";
                    txtcorreo.Text = "";
                    txtnit.Text = "";
                    txttelefono.Text = "";
                    txtnacimiento.Text = "";
                    txtbanconombre.Text = "";
                    txttipocuenta.Text = "";
                    txtbanco.Text = "";
                    ddlRol.SelectedValue = "0";
                    ddlActivo.SelectedValue = "2";
                    txtcontraseña.Text = "";
                    txtcontraseña2.Text = "";
                    Button2.Text = "";

                    txtnombre1.Enabled = false;
                    txtdpi00.Enabled = true;
                    txtnombre2.Enabled = false;
                    txtnombre3.Enabled = false;
                    txtapellido1.Enabled = false;
                    txtapellido2.Enabled = false;
                    txtapellido3.Enabled = false;
                    txtnegocio.Enabled = false;
                    txtproducto.Enabled = false;
                    txtdpi.Enabled = false;
                    txtdireccion.Enabled = false;
                    txtcorreo.Enabled = false;
                    txtnit.Enabled = false;
                    txttelefono.Enabled = false;
                    txtnacimiento.Enabled = false;
                    txtbanconombre.Enabled = false;
                    txttipocuenta.Enabled = false;
                    txtbanco.Enabled = false;
                    ddlRol.Enabled = false;
                    ddlActivo.Enabled = false;
                    txtcontraseña.Enabled = false;
                    txtcontraseña2.Enabled = false;
                    Button2.Enabled = false;
                }
                /*else
                {


                    Response.Write("<script>alert('DPI ya esta registrado')</script>");
                    contraseña20.Text = "Ya existe una cuenta con este numero de DPI: " + dpi;
                    contraseña20.ForeColor = Color.Red;
                }*/
            }



            conectado.desconectar();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            txtnombre1.Text = "";
            txtdpi00.Text = "";
            txtnombre2.Text = "";
            txtnombre3.Text = "";
            txtapellido1.Text = "";
            txtapellido2.Text = "";
            txtapellido3.Text = "";
            txtnegocio.Text = "";
            txtproducto.Text = "";
            txtdpi.Text = "";
            txtdireccion.Text = "";
            txtcorreo.Text = "";
            txtnit.Text = "";
            txttelefono.Text = "";
            txtnacimiento.Text = "";
            txtbanconombre.Text = "";
            txttipocuenta.Text = "";
            txtbanco.Text = "";
            ddlRol.SelectedValue = "0";
            ddlActivo.SelectedValue = "2";
            txtcontraseña.Text = "";
            txtcontraseña2.Text = "";
            Button2.Text = "";

            txtnombre1.Enabled = false;
            txtdpi00.Enabled = true;
            txtnombre2.Enabled = false;
            txtnombre3.Enabled = false;
            txtapellido1.Enabled = false;
            txtapellido2.Enabled = false;
            txtapellido3.Enabled = false;
            txtnegocio.Enabled = false;
            txtproducto.Enabled = false;
            txtdpi.Enabled = false;
            txtdireccion.Enabled = false;
            txtcorreo.Enabled = false;
            txtnit.Enabled = false;
            txttelefono.Enabled = false;
            txtnacimiento.Enabled = false;
            txtbanconombre.Enabled = false;
            txttipocuenta.Enabled = false;
            txtbanco.Enabled = false;
            ddlRol.Enabled = false;
            ddlActivo.Enabled = false;
            txtcontraseña.Enabled = false;
            txtcontraseña2.Enabled = false;
            Button2.Enabled = false;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            Response.Redirect("MenuAdministrador.aspx");
        }

    }
}