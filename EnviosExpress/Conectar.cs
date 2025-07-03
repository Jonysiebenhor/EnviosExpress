using iTextSharp.text.pdf.codec.wmf;
using NPOI.POIFS.Crypt.Dsig;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Bcpg;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Windows.Controls.Primitives;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static NPOI.SS.Formula.PTG.ArrayPtg;
using static QRCoder.PayloadGenerator.SwissQrCode;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace EnviosExpress
{
    public class Conectar
    {
        SqlConnection conexion = new SqlConnection();

        //Esta cadena de conexión la cambié por la de mi máquina local, esta se debe cambiar después por la cadena de conexión del servidor.
        //String conexionString = "Data Source=PC-ERICK\\SQLEXPRESS;Initial Catalog=db_prueba;User ID=(Usuario de la BD);Password=(Contraseña de la BD);TrustServerCertificate=True;";
       

        //¡OJO! LEER EL COMENTARIO DE ARRIBA!!



        //String conexionString = "Data Source=DESKTOP-QTSGBLO;DATABASE=EnviosExpress;Integrated security=true";pasada
        //String conexionString = "Data Source=DESKTOP-KNTJ3BG\\SQLEXPRESS;DATABASE=EnviosExpress;Integrated security=true";
        String conexionString = "workstation id = EnviosExpress.mssql.somee.com; packet size = 4096; user id = EnviosExpress; pwd=Envios3228@;data source = EnviosExpress.mssql.somee.com;";
        public void conectar()
        {
            try
            {
                conexion.ConnectionString = conexionString;
                conexion.Open();
            }
            catch
            {
                //MessageBox.Show("Error en Conexion");
            }
        }
        internal void Open()
        {
            throw new NotImplementedException();
        }

        public void desconectar()
        {
            try
            {
                conexion.ConnectionString = conexionString;
                conexion.Close();
            }
            catch
            {
                //MessageBox.Show("Error en Conexion");
            }
        }

        public DataTable ObtenerReportePagosPorCliente(string dpi, DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EnviosExpressConnectionString"].ToString()))

            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(@"
            SELECT * FROM pagos 
            WHERE idusuario = (SELECT idusuario FROM usuario WHERE dpi = @dpi) 
            AND CONVERT(date, fechahora) BETWEEN @desde AND @hasta", con))
                {
                    cmd.Parameters.AddWithValue("@dpi", dpi);
                    cmd.Parameters.AddWithValue("@desde", desde.Date);
                    cmd.Parameters.AddWithValue("@hasta", hasta.Date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }


        public DataTable consultaUsuarioloign2(String dpi)
        {
            String query = "Select activo,rol  from usuario where dpi ='" + dpi + "' ";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable solirecoleccion
           (String nombre, String tel1, string tel2, string direccion)
        {
            string query = "INSERT INTO recoleccion" +
                        "(" +
                        "nombre," +
                        "tel1," +
                        "tel2," +
                        "fecha," +
                        "direccion)" +
                        "VALUES" +
                        "('" + nombre + "'," +
                        "'" + tel1 + "'," +
                        "'" + tel2 + "'," +
                        "GETDATE()," +
                        "'" + direccion + "')";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        /*public string varr(var1)
            {
            string var1="0"; 
        }*/
        public DataTable editarusuario
           (String nombre, String nombre2, String nombre3, String apellido, String apellido2, String apellido3, String negocio, String producto, String dpii, String direccion, String correo, String nit, String telefono, String nacimiento, String banconombre, String tipocuenta, String cuentabancaria, String rol, String activo, String contraseña, String dpi)
        {
            String query = "update usuario set " +
                        "primerNombre='" + nombre + "'," +
                        "segundoNombre='" + nombre2 + "'," +
                        "tercerNombre='" + nombre3 + "'," +
                        "primerApellido='" + apellido + "'," +
                        "segundoApellido='" + apellido2 + "'," +
                        "apellidoCasada='" + apellido3 + "'," +
                        "nombrenegocio = '" + negocio + "'," +
                        "producto = '" + producto + "'," +
                        "dpi = '" + dpii + "'," +
                        "direccion  = '" + direccion + "'," +
                        "correo  = '" + correo + "'," +
                        "nit = '" + nit + "'," +
                        "telefono='" + telefono + "'," +
                        "nacimiento ='" + nacimiento + "'," +
                        "activo ='" + activo + "'," +
                        "nombrebanco  ='" + banconombre + "'," +
                        "tipocuenta ='" + tipocuenta + "'," +
                        "cuentabancaria = '" + cuentabancaria + "'," +
                        "rol = '" + rol + "'," +
                        "contraseña ='" + contraseña + "'" +
                "where dpi =" + dpi + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable consultaUsuarioloign(String dpi, String contraseña)
        {
            String query = "Select *  from usuario where dpi ='" + dpi + "' and contraseña='" + contraseña + "'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable consultaUsuarioDPI(String dpi)
        {
            String query = "Select *  from usuario where dpi ='" + dpi + "'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable consultasesion1(String dpi, String sesion)
        {
            String query = "Select *  from usuario where dpi ='" + dpi + "' and '" + sesion + "' ='1'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable consultasesion2(String dpi, String sesion)
        {
            String query = "Select *  from usuario where dpi ='" + dpi + "' and '" + sesion + "' ='2'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable consultasesion3(String dpi, String sesion)
        {
            String query = "Select *  from usuario where dpi ='" + dpi + "' and '" + sesion + "' ='3'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable consultaUsuario(String idusuario, String contraseña)
        {
            string query = "SELECT * FROM usuario " +
            "WHERE idusuario = " + idusuario +
            " and contraseña = '" + contraseña + "'";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }

        public DataTable crearguiadepartamento
           (String departamento, String municipio, String zona)
        {
            string query = "INSERT INTO departamento" +
                        "(" +
                        "nombre," +
                        "municipio," +
                        "zona)" +
                        "VALUES" +
                        "('" + departamento + "'," +
                        "'" + municipio + "'," +
                        "'" + zona + "')";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable crearguiatarifa
           (String monto, String peso)
        {
            string query = "INSERT INTO tarifa" +
                        "(" +
                        "monto," +
                        "peso)" +
                        "VALUES" +
                        "('" + monto + "'," +
                        "'" + peso + "')";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable crearguiapaquete
           (String remitente, String destinatario, String direccion, String telefono, String monto, String peso, String valorenvio, String cantidadadepositar, String departamento, String municipio, String zona, string dpi, String tipo)
        {
            string query = "INSERT INTO paquete" +
                        "(" +
                        "remitente," +
                        "destinatario," +
                        "direccion," +
                        "telefono," +
                        "fecha," +
                        "fechahora," +
                        "monto," +
                        "peso," +
                        "valorenvio," +
                        "cantidadadepositar," +
                        "valorvisita," +
                        "iddepartamento," +
                        "idmunicipio," +
                        "idzona," +
                        "idusuario," +
                        "idtarifa," +
                        "idmensajero," +
                        "cierre," +
                        "pendiente," +
                        "tipo)" +
                        "VALUES" +
                        "('" + remitente + "'," +
                        "'" + destinatario + "'," +
                        "'" + direccion + "'," +
                        "'" + telefono + "'," +
                        "GETDATE()," +
                        "GETDATE()," +
                        "'" + monto + "'," +
                        "'" + peso + "'," +
                        "'" + valorenvio + "'," +
                        "'" + cantidadadepositar + "'," +
                        "'0'," +
                        "'" + departamento + "'," +
                         "'" + municipio + "'," +
                          "'" + zona + "'," +
                          "'" + dpi + "'," +
                          "  null  ," +
                        "  null  ," +
                        "  0  ," +
                        "1," +
                        "'" + tipo + "')";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable crearguiapaquete1
           (String remitente, String destinatario, String direccion, String telefono, String monto, String peso, String valorenvio, String cantidadadepositar, String departamento, String municipio, String zona, String tipo)
        {
            string query = "INSERT INTO paquete" +
                        "(" +
                        "remitente," +
                        "destinatario," +
                        "direccion," +
                        "telefono," +
                        "fecha," +
                        "fechahora," +
                        "monto," +
                        "peso," +
                        "valorenvio," +
                        "cantidadadepositar," +
                        "valorvisita," +
                        "iddepartamento," +
                        "idmunicipio," +
                        "idzona," +
                        "idusuario," +
                        "idtarifa," +
                        "idmensajero," +
                        "pendiente," +
                        "tipo)" +
                        "VALUES" +
                        "('" + remitente + "'," +
                        "'" + destinatario + "'," +
                        "'" + direccion + "'," +
                        "'" + telefono + "'," +
                        "GETDATE()," +
                        "GETDATE()," +
                        "'" + monto + "'," +
                        "'" + peso + "'," +
                        "'" + valorenvio + "'," +
                        "'" + cantidadadepositar + "'," +
                        "0," +
                        "'" + departamento + "'," +
                         "'" + municipio + "'," +
                          "'" + zona + "'," +
                          "  null  ," +
                          "  null  ," +
                        "  null  ," +
                        "1," +
                        "'" + tipo + "')";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable consultarultimopaquete()
        {
            string query = "Select idpaquete, remitente, destinatario, direccion, telefono, monto, iddepartamento, idmunicipio, idzona, peso from paquete where idpaquete =SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable Guia()
        {
            String query = "Select*  from paquete where idpaquete =SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable Guia2(String idpaquete)
        {
            String query = "Select a.recibido,a.cantidadadepositar, e.direccion as dirusuario, a.idusuario, YEAR(a.fecha) as fecha,MONTH(a.fecha) as fecha1,DAY(a.fecha) as fecha2,a.remitente,e.telefono as telcliente, a.idpaquete,a.destinatario,REPLACE(REPLACE(REPLACE(SUBSTRING(a.direccion,1,160),CHAR(9),''),CHAR(10),','),CHAR(13),'') as direccion,b.iddepartamento as departamento,c.idmunicipio as municipio,d.idzona as zona,d.monto as valorenvio, a.telefono2,a.direccion2,a.destinatario2,a.telefono,a.peso,a.monto,a.tipo,b.nombre as dep,c.nombre as mun ,d.nombre as zon from paquete a left join usuario e on a.idusuario = e.idusuario left join departamento b on a.iddepartamento = b.iddepartamento left join municipio c on a.idmunicipio = c.idmunicipio left join zona d on a.idzona = d.idzona   where idpaquete='" + idpaquete + "'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable Guia3(String guia)
        {
            String query = "Select a.idpaquete as Guia, a.destinatario as Destinatario,a.telefono as Teléfono,a.direccion as Dirección from paquete a where idpaquete= '" + guia + "'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable Guia4(String guia)
        {
            String query = "Select b.nombre as Departamento  ,c.nombre as Municipio ,d.nombre as Zona from paquete a left join departamento b on a.iddepartamento = b.iddepartamento left join municipio c on a.idmunicipio = c.idmunicipio left join zona d on a.idzona = d.idzona where idpaquete= '" + guia + "'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable Guia5(String guia)
        {
            String query = "Select a.tipo as Tipo, a.peso as Peso,a.monto as Monto from paquete a left join departamento b on a.iddepartamento = b.iddepartamento left join municipio c on a.idmunicipio = c.idmunicipio left join zona d on a.idzona = d.idzona where idpaquete= '" + guia + "'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable Guia6(String guia)
        {
            String query = "Select a.primerNombre as Nombre, a.primerApellido as Apellido,a.telefono as Teléfono, a.direccion as Dirección from usuario a left join paquete b on a.idusuario = b.idusuario where b.idpaquete= '" + guia + "'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable Guia7(String guia)
        {
            String query = "Select pendiente as Pendiente, recolectado as Recolectado, intentoentrega as IntendoEntrega, entregado as Entregado, devolucion as Devolucion from paquete where idpaquete = '" + guia + "'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable Guia8(String guia)
        {
            String query = "Select estado as Estado_del_Paquete, fechahora as Fecha_y_Hora from estadopaquete where idpaquete = '" + guia + "'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable ingresardepartamento
           (String monto, String peso)
        {
            string query = "INSERT INTO departamento" +
                        "(" +
                        "departamento," +
                        "peso)" +
                        "VALUES" +
                        "('" + monto + "'," +
                        "'" + peso + "')";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable crearusuario
           (String nombre, String nombre2, String nombre3, String apellido, String apellido2, String apellido3, String negocio, String producto, String dpi, String direccion, String correo, String nit, String telefono, String nacimiento, String banconombre, String tipocuenta, String cuentabancaria, String rol, String activo, String contraseña)
        {
            string query = "insert into usuario" +
                        "(" +
                        "primerNombre," +
                        "segundoNombre," +
                        "tercerNombre," +
                        "primerApellido," +
                        "segundoApellido," +
                        "ApellidoCasada," +
                        "nombrenegocio," +
                        "producto," +
                        "dpi," +
                        "direccion," +
                        "correo," +
                        "nit," +
                        "telefono," +
                        "nacimiento," +
                        "ingreso," +
                        "nombrebanco," +
                        "tipocuenta," +
                        "cuentabancaria," +
                        "rol," +
                        "activo," +
                        "contraseña," +
                        "sesion)" +
                        "VALUES" +
                        "('" + nombre + "'," +
                        "'" + nombre2 + "'," +
                        "'" + nombre3 + "'," +
                        "'" + apellido + "'," +
                        "'" + apellido2 + "'," +
                        "'" + apellido3 + "'," +
                         "'" + negocio + "'," +
                          "'" + producto + "'," +
                        "'" + dpi + "'," +
                        "'" + direccion + "'," +
                        "'" + correo + "'," +
                        "'" + nit + "'," +
                        "'" + telefono + "'," +
                        "'" + nacimiento + "'," +
                        "GETDATE()," +
                         "'" + banconombre + "'," +
                          "'" + tipocuenta + "'," +
                        "'" + cuentabancaria + "'," +
                        "'" + rol + "'," +
                        "'" + activo + "'," +
                        "'" + contraseña + "'," +
                        "' 0 ')";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable descargarguia()
        {
            string query = "SELECT      a.iddepartamento, a.nombre, b.idmunicipio, b.nombre, c.idzona, c.nombre from departamento a left join municipio b on a.iddepartamento=b.iddepartamento left join zona c on b.idmunicipio=c.idmunicipio";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable descargarguia2()
        {
            String query = "Select a.idpaquete,a.destinatario,a.direccion,a.telefono,a.peso,a.monto,a.tipo,b.nombre,c.nombre,d.nombre from paquete a left join departamento b on a.iddepartamento = b.iddepartamento left join municipio c on a.idmunicipio = c.idmunicipio left join zona d on a.idzona = d.idzona";
                
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }

        public DataTable generarguia()
        {
            string query = "SELECT      a.iddepartamento, a.nombre, b.idmunicipio, b.nombre, c.idzona, c.nombre from departamento a left join municipio b on a.iddepartamento=b.iddepartamento left join zona c on b.idmunicipio=c.idmunicipio";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable paquete(String guia)
        {
            string query = "SELECT * from paquete where idpaquete =" + guia + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }

        public DataTable estadopaquete(String guia)
        {
            string query = "SELECT a.idpaquete, b.idpaquete, b.estado from paquete a left join estadopaquete b on a.idpaquete=b.idpaquete  where a.idpaquete =" + guia + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable cierrepaquete(String dpi)
        {
            string query = "SELECT sum(b.monto) as montototal  from estadopaquete a left join paquete b on a.idpaquete=b.idpaquete  where a.idusuariomns =" + dpi + " and b.idpagomns is null and a.estado='Entregado'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable solicitudesMns(String dpi)
        {
            string query = "SELECT sum(b.monto) as montototal  from estadopaquete a left join paquete b on a.idpaquete=b.idpaquete  where a.idusuario =" + dpi + " and b.cierre =0 and a.estado='Entregado'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable solicitudesMns1(String dpi)
        {
            string query ="select distinct(a.idpaquete) as guia from estadopaquete a left join estadopaquete b on a.idpaquete = b.idpaquete left join paquete c on a.idpaquete = c.idpaquete where b.idusuariomns >0 and c.entregado = 'false' and a.estado = 'Remitente Solicito Sacar a Ruta'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }

        public DataTable soliMns1(String dpi, String fecha1,String fecha2)
        {
            string query = "select a.idpaquete as Guia,a.fechahora,a.estado from estadopaquete a right join (select distinct(idpaquete) from estadopaquete where idusuariomns=" + dpi + ") b  on  a.idpaquete=b.idpaquete where a.idusuariomns is null and a.descripcion is null and a.fechahora between '" + fecha1 + " 00:00:00.000" + "' and '" + fecha2 + " 23:59:59.000" + "' order by idestadopaquete desc";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable soliAdmin1(String fecha1, String fecha2)
        {
            string query = "select a.idpaquete as Guia,a.fechahora,a.estado,b.nombre as Mensajero from estadopaquete a left join (select distinct(a.idpaquete),concat(primerNombre,' ',primerApellido) as Nombre from estadopaquete a right join usuario b on a.idusuariomns=b.dpi) b  on  a.idpaquete=b.idpaquete where a.idusuariomns is null and descripcion is null and a.fechahora between '" + fecha1 + " 00:00:00.000" + "' and '" + fecha2 + " 23:59:59.000" + "' order by idestadopaquete desc";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable manifiesto9(String fechain, String fechafin, String dpi)
        {
            string query = "select idmanifiesto as No_Manifiesto, fechahora as Hora_y_Fecha from manifiesto where idusuario= " + dpi + " and fechahora between '" + fechain + " 00:00:00.000" + "' and '" + fechafin + " 23:59:59.000" + "' ";  


            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable manifiesto8(String fechain, String fechafin)
        {
            string query = "select*from manifiesto where fechahora between '" + fechain +" 00:00:00.000"+ "' and '" + fechafin + " 23:59:59.000" + "' ";


            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable manifiesto7(String idmanifiesto)
        {
            string query = "select a.idpaquete as Guía,a.Destinatario, SUBSTRING(a.direccion, 1, 80) as Dirección , a.Telefono as Teléfono, a.Monto, b.nombre as Departamento,c.nombre as Municipio from paquete a left join departamento b on a.iddepartamento = b.iddepartamento left join municipio c on a.idmunicipio = c.idmunicipio where a.idmanifiesto = " + idmanifiesto + "";


            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }

        public DataTable manifiesto6(String idmanifiesto)
        {
            string query = "Select min(fechahora) as fechahora  from paquete where idmanifiesto=" + idmanifiesto + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable manifiesto5(String idmanifiesto)
        {
            string query = "Select max(fechahora) as fechahora  from paquete where idmanifiesto=" + idmanifiesto + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable manifiesto4(String idmanifiesto)
        {
            string query = "Select*  from paquete where idmanifiesto =" + idmanifiesto + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable manifiesto3(String idmanifiesto, String dpi )
        {
            string query = "update paquete set " +
                        "idmanifiesto= '" + idmanifiesto + "'" +
                         "where idusuario =" + dpi + " and idmanifiesto is null";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
       
        public DataTable manifiesto2(String idmanifiesto)
        {
            String query = "Select*  from manifiesto where idmanifiesto ="+idmanifiesto+"";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }

        public DataTable manifiesto1(String dpi)
        {
            string query = "INSERT INTO manifiesto" +
                        "(" +
                        "idusuario," +
                        "fechahora)" +
                        "VALUES" +
                        "('" + dpi + "'," +
                        "GETDATE() )";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable manifiesto0()
        {
            String query = "Select* from manifiesto where idmanifiesto=SCOPE_IDENTITY()";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable manifiesto(String dpi)
        {
            string query = "select * from paquete where idusuario=" + dpi + "and idmanifiesto is null";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable cierrepaquete0(String dpi,String monto)
        {
            string query = "INSERT INTO pagos" +
                         "(" +
                        "estado," +
                        "fechahora," +
                        "monto," +
                        "idusuariomns)" +
                        "VALUES" +
                        "('Proceso'," +
                        "GETDATE()," +
                        "'" + monto + "' ," +
                        "'" + dpi + "')";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable cierrepaquete1()
        {
            String query = "Select*  from pagos where idpago =SCOPE_IDENTITY()";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable ultimo(String fechahora)
        {
            String query = "Select*  from pagos where fechahora =" + fechahora + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable cierrepaquete2(String idpago, String dpi)
        {
            string query = "update paquete set idpagomns = " + idpago + "" +
"from estadopaquete a left join paquete b on a.idpaquete = b.idpaquete  where a.idusuariomns = " + dpi + " and b.idpagomns is null and a.estado = 'Entregado'";


            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable estadopaquete0(String guia)
        {
            string query = "SELECT a.idpaquete, b.idpaquete, b.estado from paquete a left join estadopaquete b on a.idpaquete = b.idpaquete  where b.idpaquete = " + guia + "and (  b.estado='Liquidado')";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable estadopaquete1(String guia)
        {
            string query = "SELECT a.idpaquete, b.idpaquete, b.estado from paquete a left join estadopaquete b on a.idpaquete = b.idpaquete  where b.idpaquete = " + guia + "and (  b.estado='Entregado' or  b.estado='Devolucion Entregado')";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable estadopaquete2(String dpi1, String guiaa)
        {
            string query = "select count(a.idpaquete) as Guia from estadopaquete a right join (select distinct(idpaquete) from estadopaquete where idusuario=" + dpi1 + " and idpaquete=" + guiaa + ") b  on  a.idpaquete=b.idpaquete where a.idusuariomns is null and descripcion is null";
;

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable estadopaquete3(String guia)
        {
            string query = "SELECT a.idpaquete, b.idpaquete, b.estado from paquete a left join estadopaquete b on a.idpaquete = b.idpaquete  where b.idpaquete = " + guia + "and (  b.estado is not null)";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable pagosclientes1(String fecha1, String fecha2)
        {
            String query = "select b.dpi, CONCAT(b.primerNombre, ' ', b.primerApellido) as Cliente,b.nombrenegocio as Negocio, sum(cantidadadepositar) as Monto from paquete c  left join usuario b on c.idusuario=b.dpi left join estadopaquete d on d.idpaquete=c.idpaquete  where c.idpago is null and d.estado = 'entregado' and d.fechahora between '" + fecha1 + " 00:00:00.000" + "' and '" + fecha2 + " 23:59:59.000" + "' group by b.primerNombre,b.primerApellido,b.nombrenegocio,b.dpi;";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable pagosclientes2(String dpi, String dpi2, String monto,String refe)
        {
            string query = "INSERT INTO pagos" +
                         "(" +
                        "estado," +
                        "fechahora," +
                        "monto," +
                        "descripcion," +
                        "idusuariomns," +
                        "idusuario)" +
                        "VALUES" +
                        "('Liquidado'," +
                        "GETDATE()," +
                        "'" + monto + "' ," +
                        "'" + refe + "' ," +
                        "'" + dpi2 + "' ," +
                         "'" + dpi + "')";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable pagosclientes3(String idpago, String dpi1)
        {
            string query = "update paquete set idpago= " + idpago + "" +
            "from  paquete where idusuario = " + dpi1 + " and idpago is null and entregado = 1";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable pagosclientes4(String idpago)
        {
            string query = "INSERT INTO estadopaquete ( idpaquete, idusuario) SELECT idpaquete, idusuario from paquete where idpago=" + idpago  +"";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable pagosclientes5(String dpi1,String dpi2)
        {
            string query = "update estadopaquete set fechahora = GETDATE(),idusuariomns=" + dpi2 + ", estado = 'Liquidado' where fechahora is null and idusuario = " + dpi1 + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable pagosclientes6(String fecha3, String fecha4)
        {
            string query = "Select a.idpago, CONCAT(b.primerNombre, ' ', b.primerApellido) as Cliente, a.fechahora as Fecha,  CONCAT('Q', a.monto) as Monto, a.Estado as Estado,a.descripcion as #Referencia from pagos a left join usuario b on a.idusuario=b.dpi where b.rol= 1 and a.estado='Liquidado' and a.fechahora between '" + fecha3 + " 00:00:00.000" + "' and '" + fecha4 + " 23:59:59.000" + "' order by a.fechahora DESC";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable pagosclientes7(String dpi, String fecha1, String fecha2)
        {
            string query = "Select a.idpago, CONCAT(b.primerNombre, ' ', b.primerApellido) as Cliente, a.fechahora as Fecha,  CONCAT('Q', a.monto) as Monto, a.Estado as Estado,a.descripcion as #Referencia from pagos a left join usuario b on a.idusuario=b.dpi where b.rol= 1 and a.estado='Liquidado' and a.idusuario=" + dpi  + " and a.fechahora between '" + fecha1 + " 00:00:00.000" + "' and '" + fecha2 + " 23:59:59.000" + "' order by a.fechahora DESC";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable ultim(String idpaquete1)
        {
            string query = "select*from paquete where idpaquete=" + idpaquete1 + "";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;  
        }

        public DataTable ultimMasv(String dpi1)
        {
            string query = "select concat(DATEPART(YEAR, fechahora),'-',DATEPART(MONTH, fechahora),'-',DATEPART(DAY, fechahora),' ',DATEPART(HOUR, fechahora),':',DATEPART(MINUTE, fechahora),':',DATEPART(SECOND, fechahora),':',DATEPART(MILLISECOND, fechahora))as fechahora from paquete where idusuario=" + dpi1 + " order by idpaquete desc";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable ultimosMasv(String fechahora)
        {
            //DateTime fechahora1 = Convert.ToDateTime(fechahora);
            string query = "select*from paquete where fechahora = '" + fechahora + "'";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable pagos1(String fecha5, String fecha6)
        {
            String query = "Select a.idpago,CONCAT(b.primerNombre, ' ', b.primerApellido) as Mensajero, a.fechahora as Fecha,  CONCAT('Q',a.monto) as Monto, a.Estado as Estado,a.descripcion from pagos a left join usuario b on a.idusuariomns=b.dpi where b.rol=2 and a.fechahora between '" + fecha5 + " 00:00:00.000" + "' and '" + fecha6 + " 23:59:59.000" + "' order by a.fechahora DESC";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable pagos2(String Estado, String guia,String refe)
        {
            String query = "update pagos set " +
                        "estado= '" + Estado + "'," +
                        "descripcion= '" + refe + "'" +
                         "where idpago =" + guia + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        /// <summary>
        /// Devuelve el informe de entregas pendientes de pago en un rango de fechas.
        /// </summary>
        public DataTable ObtenerReportePagos(DateTime fechaDesde, DateTime fechaHasta)
        {
            var dt = new DataTable();
            const string sql = @"
SELECT
    p.idusuario                                  AS dpi,
    e.idpaquete                                  AS NoGuia,
    b.nombre                                     AS Departamento,
    c.nombre                                     AS Municipio,
    d.nombre                                     AS Zona,
    p.monto                                      AS MontoCobrado,
    p.valorenvio                                 AS ValorEnvio,
    p.valorvisita                                AS ValorVisita,
    p.cantidadadepositar                         AS PagoCliente,
    e.fechahora                                  AS FechaHoraEntrega,
    CONCAT(m.primerNombre,' ',m.primerApellido)  AS Mensajero
FROM dbo.estadopaquete e
INNER JOIN dbo.paquete      p ON e.idpaquete      = p.idpaquete
LEFT  JOIN dbo.departamento b ON p.iddepartamento = b.iddepartamento
LEFT  JOIN dbo.municipio    c ON p.idmunicipio    = c.idmunicipio
LEFT  JOIN dbo.zona         d ON p.idzona         = d.idzona
LEFT  JOIN dbo.usuario      m ON e.idusuariomns   = m.dpi
WHERE e.estado    = 'Entregado'
  AND CAST(e.fechahora AS date) BETWEEN @desde AND @hasta
  AND NOT EXISTS (
      SELECT 1 FROM dbo.pagos x WHERE x.idpago = e.idpaquete
  )
ORDER BY e.fechahora DESC;
";

            using (var cmd = new SqlCommand(sql, conexion))
            {

                cmd.Parameters.AddWithValue("@desde", fechaDesde.Date);
                cmd.Parameters.AddWithValue("@hasta", fechaHasta.Date);
                using (var da = new SqlDataAdapter(cmd))

                    da.Fill(dt);
            }

            if (!dt.Columns.Contains("dpi"))
                throw new InvalidOperationException("Falta la columna 'dpi' en el DataTable.");
            return dt;
        }




        public DataTable pendiente(String guia)
        {
            string query = "INSERT INTO estadopaquete" +
                        "(" +
                        "idpaquete," +
                        "fechahora," +
                        "estado)" +
                        "VALUES" +
                        "('" + guia + "'," +
                        "GETDATE()," +
                        "'Pendiente de Recolectar' )";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable recolectado(String guia, String dpi)
        {
            string query = "INSERT INTO estadopaquete" +
                        "(" +
                        "idpaquete," +
                        "fechahora," +
                        "idusuariomns," +
                        "estado)" +
                        "VALUES" +
                        "('" + guia + "'," +
                        "GETDATE()," +
                        "'" + dpi + "' ,"+
                        "'Recolectado' )";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable ruta(String guia, String dpi)
        {
            string query = "INSERT INTO estadopaquete" +
                        "(" +
                        "idpaquete," +
                        "fechahora," +
                        "idusuariomns," +
                        "estado)" +
                        "VALUES" +
                        "('" + guia + "'," +
                        "GETDATE()," +
                         "'" + dpi + "' ," +
                        "'Ruta de Entrega' )";

                        

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable entrega(String guia, String dpi)
        {
            string query = "INSERT INTO estadopaquete" +
                        "(" +
                        "idpaquete," +
                        "fechahora," +
                        "idusuariomns," +
                        "estado)" +
                        "VALUES" +
                        "('" + guia + "'," +
                        "GETDATE()," +
                         "'" + dpi + "' ," +
                        "'Entregado' )";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable otros(String guia, String descripcion)
        {
            string query = "update paquete set " +
                        "descripcion= '" + descripcion + "'" +
                         "where idpaquete =" + guia + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable entrega1(String guia,String recibido)
        {
            string query =  "update paquete set " +
                        "recibido= '" + recibido + "'," +
                        "entregado= ' true '" +
                         "where idpaquete =" + guia + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable editarguiapaquete (String guia, String destinatario, String direccion, String telefono, String monto, String valorenvio, String cantidadadepositar, String departamento, String municipio, String zona)
        {
            string query = "update paquete set " +
                            "destinatario2= '" + destinatario + "'" +
                            ",direccion2= '" + direccion + "'" +
                            ",telefono2= '" + telefono + "'" +
                            ",monto= '" + monto + "'" +
                            ",valorenvio= '" + valorenvio + "'" +
                            ",cantidadadepositar= '" + cantidadadepositar + "'" +
                            ",iddepartamento= '" + departamento + "'" +
                            ",idmunicipio= '" + municipio + "'" +
                            ",idzona= '" + zona + "'" +
                            "where idpaquete =" + guia + "";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable Nuevomontopaquete(String guia, String monto, String cantidadadepositar)
        {
            string query = "update paquete set " +
                            "monto= '" + monto + "'" +
                            ",cantidadadepositar= '" + cantidadadepositar + "'" +
                            "where idpaquete =" + guia + "";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }

        public DataTable intento(String intento, String guia, String dpi)
        {
            string query ="INSERT INTO estadopaquete" +
                        "(" +
                        "idpaquete," +
                        "fechahora," +
                        "idusuario," +
                        "estado)" +
                        "VALUES" +
                        "('" + guia + "'," +
                        "GETDATE()," +
                        "'" + dpi + "' ," +
                        "'" + intento + "' )";


            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable intentomns(String intento, String guia, String dpi)
        {
            string query = "INSERT INTO estadopaquete" +
                        "(" +
                        "idpaquete," +
                        "fechahora," +
                        "idusuariomns," +
                        "estado)" +
                        "VALUES" +
                        "('" + guia + "'," +
                        "GETDATE()," +
                        "'" + dpi + "' ," +
                        "'" + intento + "' )";


            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable intento1( String guia, String valorvisita)
        {
            string query = "update paquete set " +
                        "valorvisita= " + valorvisita + "" +
                         "where idpaquete =" + guia + "";


            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable intento2(String guia, String cantidadadepositar)
        {
            string query = "update paquete set " +
                        "cantidadadepositar= " + cantidadadepositar + "" +
                         "where idpaquete =" + guia + "";


            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable abrirsesion1( String dpi)
        {
            string query = "update usuario set " +
                        "sesion =' 1 '" +
                         "where dpi =" + dpi + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable abrirsesion2(String dpi)
        {
            string query = "update usuario set " +
                        "sesion =' 2 '" +
                         "where dpi =" + dpi + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable abrirsesion3(String dpi)
        {
            string query = "update usuario set " +
                        "sesion =' 3 '" +
                         "where dpi =" + dpi + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable cerrarsesion(String dpi)
        {
            string query = "update usuario set " +
                        "sesion =' 0 '" +
                         "where dpi =" + dpi + "";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }
        public DataTable devolucion(String guia,String dpi, String intento)
        {
            string query = "INSERT INTO estadopaquete" +
                        "(" +
                        "idpaquete," +
                        "fechahora," +
                        "idusuariomns," +
                        "estado)" +
                        "VALUES" +
                        "('" + guia + "'," +
                        "GETDATE()," +
                        "'" + dpi + "' ," +
                        "'Devolucion '+'" + intento + "' )";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;

        }


        public DataTable consultaguia(String dpi, String contraseña)
        {
            String query = "Select *  from usuario where dpi ='" + dpi + "' and contraseña='" + contraseña + "'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }
        public DataTable consultaguia2(String guia)
        {
            String query = "Select *  from paquete where id ='" + guia +  "'";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }

        public DataTable recolectadoconescanner(String guia, String dpi)
        {
            String query = "INSERT INTO estadopaquete" +
                        "(" +
                        "idpaquete," +
                        "fechahora," +
                        "idusuariomns," +
                        "estado)" +
                        "VALUES" +
                        "('" + guia + "'," +
                        "GETDATE()," +
                        "'" + dpi + "' ," +
                        "'Recolectado' )";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataAdapter returnVal = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnVal.Fill(dt);
            return dt;
        }

    }
}