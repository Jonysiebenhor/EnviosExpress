using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Data;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace EnviosExpress
{
    public partial class ScannerHandler : System.Web.UI.Page
    {
        [WebMethod]
        public static string RegistrarCodigo(string codigo)
        {
            var codigos = HttpContext.Current.Session["CodigosEscaneados"] as List<string>;
            if (codigos == null)
            {
                codigos = new List<string>();
                HttpContext.Current.Session["CodigosEscaneados"] = codigos;
            }

            if (codigos.Contains(codigo))
                return $"⚠️ El código {codigo} ya fue escaneado.";

            codigos.Add(codigo);
            return $"✅ Código {codigo} registrado correctamente.";
        }

        [WebMethod]
        public static List<string> ObtenerCodigos()
        {
            var codigos = HttpContext.Current.Session["CodigosEscaneados"] as List<string>;
            return codigos ?? new List<string>();
        }

        [WebMethod]
        public static void VaciarCodigos()
        {
            HttpContext.Current.Session["CodigosEscaneados"] = null;
        }


        //Código para convertir la cola en un data table e insertar los datos en la base de datos
        //Este código ejecuta un procedimiento almacenado con validaciones.
        public class ResultadoCodigo
        {
            public int Codigo { get; set; }
            public bool Exito { get; set; }
            public string Mensaje { get; set; }
        }

      /*  [WebMethod]
        public static List<ResultadoCodigo> EnviarTodosLosCodigos(List<CodigoQR> codigos)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idpaquete", typeof(int));
            dt.Columns.Add("fechahora", typeof(DateTime));
            dt.Columns.Add("estado", typeof(string));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("idusuario", typeof(long));
            dt.Columns.Add("idusuariomns", typeof(long));
            dt.Columns.Add("intentoentrega", typeof(string));

            foreach (var item in codigos)
            {
                dt.Rows.Add(
                    item.Codigo,
                    item.Fecha,
                    "pendiente de entregar",
                    "-",
                    1L,
                    1L,
                    "Intento exitoso"
                );
            }

            var resultados = new List<ResultadoCodigo>();

            try
            {
                using (SqlConnection conn = new SqlConnection("workstation id = EnviosExpress.mssql.somee.com; packet size = 4096; user id = EnviosExpress; pwd=Envios3228@;data source = EnviosExpress.mssql.somee.com;"))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_recolectarpaquete", conn))

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter tvpParam = cmd.Parameters.AddWithValue("@codigos", dt);
                        tvpParam.SqlDbType = SqlDbType.Structured;

                        conn.Open();

                        // Leer los resultados del SP
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var id = Convert.ToInt32(reader["idpaquete"]);
                                var msg = reader["mensaje"].ToString();

                                resultados.Add(new ResultadoCodigo
                                {
                                    Codigo = id,
                                    Exito = msg.Contains("exitosamente"), // <- marcamos como éxito si lo dice
                                    Mensaje = msg
                                });
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultados.Add(new ResultadoCodigo
                {
                    Codigo = -1, // ← Indica error general
                    Exito = false,
                    Mensaje = ex.Message
                });
            }

            return resultados;
        }

        [WebMethod]
        public static List<ResultadoCodigo> EnviarPaquetesRuta(List<CodigoQR> codigos)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idpaquete", typeof(int));
            dt.Columns.Add("fechahora", typeof(DateTime));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("idusuario", typeof(long));
            dt.Columns.Add("idusuariomns", typeof(long));
            dt.Columns.Add("intentoentrega", typeof(string));

            foreach (var item in codigos)
            {
                dt.Rows.Add(item.Codigo, item.Fecha, "-", 1L, 1L, "Intento exitoso");
            }

            var resultados = new List<ResultadoCodigo>();

            try
            {
                using (SqlConnection conn = new SqlConnection("workstation id = EnviosExpress.mssql.somee.com; packet size = 4096; user id = EnviosExpress; pwd=Envios3228@;data source = EnviosExpress.mssql.somee.com;"))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_enrutarpaquete", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter tvpParam = cmd.Parameters.AddWithValue("@codigos", dt);
                        tvpParam.SqlDbType = SqlDbType.Structured;

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                resultados.Add(new ResultadoCodigo
                                {
                                    Codigo = Convert.ToInt32(reader["idpaquete"]),
                                    Exito = false,
                                    Mensaje = reader["mensaje"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultados.Add(new ResultadoCodigo
                {
                    Codigo = -1,
                    Exito = false,
                    Mensaje = ex.Message
                });
            }

            return resultados;
        }
        */
        

        //WebMethod para que al escanear los códigos, se registren con estado "Ruta de entrega" en vez de "Recolectado.

        [WebMethod]
        public static List<ResultadoCodigo> RegistrarEstadoPaquetes(List<CodigoQR> codigos, string estado)
        {
            var resultados = new List<ResultadoCodigo>();

            DataTable dt = new DataTable();
            dt.Columns.Add("idpaquete", typeof(int));
            dt.Columns.Add("fechahora", typeof(DateTime));
            dt.Columns.Add("estado", typeof(string));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("idusuario", typeof(long));
            dt.Columns.Add("idusuariomns", typeof(long));
            dt.Columns.Add("intentoentrega", typeof(string));

            foreach (var item in codigos)
            {
                dt.Rows.Add(item.Codigo, item.Fecha, estado, "-", 1L, 1L, "Intento exitoso");
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("workstation id = EnviosExpress.mssql.somee.com; packet size = 4096; user id = EnviosExpress; pwd=Envios3228@;data source = EnviosExpress.mssql.somee.com;"))
                using (SqlCommand cmd = new SqlCommand("sp_registrar_estado_paquete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@codigos", dt);
                    tvpParam.SqlDbType = SqlDbType.Structured;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultados.Add(new ResultadoCodigo
                            {
                                Codigo = Convert.ToInt32(reader["idpaquete"]),
                                Exito = false,
                                Mensaje = reader["mensaje"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultados.Add(new ResultadoCodigo
                {
                    Codigo = -1,
                    Exito = false,
                    Mensaje = ex.Message
                });
            }

            return resultados;
        }
        

        public class CodigoQR
        {
            public int Codigo { get; set; }
            public DateTime Fecha { get; set; }
        }



    }
}
