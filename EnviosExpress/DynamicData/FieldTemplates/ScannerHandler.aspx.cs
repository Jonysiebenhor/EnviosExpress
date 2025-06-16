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




        //WebMethod para que al escanear los códigos, se registren con un estado dependiendo el módulo en el que está.


        [WebMethod]
        public static List<ResultadoCodigo> RegistrarEstadoPaquetes(List<CodigoQR> codigos, string estado)
        {
            if (estado == "entregado")
            {
                return RegistrarEntregas(codigos);
            }
            else if (estado == "intento de entrega")
            {
                return RegistrarIntentosEntrega(codigos);
            }
            else
            {
                return RegistrarRecoleccionRuta(codigos, estado);
            }
        }


        private static List<ResultadoCodigo> RegistrarRecoleccionRuta(List<CodigoQR> codigos, string estado)
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

        private static List<ResultadoCodigo> RegistrarEntregas(List<CodigoQR> codigos)
        {
            var resultados = new List<ResultadoCodigo>();

            // Asegurarse de que las columnas coincidan EXACTAMENTE con TipoEntregaPaquete
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

            try
            {
                // Cadena de conexión correcta (misma que usás en otros métodos)
                string cadenaConexion = "workstation id=EnviosExpress.mssql.somee.com;packet size=4096;user id=EnviosExpress;pwd=Envios3228@;data source=EnviosExpress.mssql.somee.com;";

                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                using (SqlCommand cmd = new SqlCommand("sp_entregar_paquete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetro tipo tabla
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


        private static List<ResultadoCodigo> RegistrarIntentosEntrega(List<CodigoQR> codigos)
        {
            var resultados = new List<ResultadoCodigo>();

            DataTable dt = new DataTable();
            dt.Columns.Add("idpaquete", typeof(int));
            dt.Columns.Add("fechahora", typeof(DateTime));
            dt.Columns.Add("estado", typeof(string)); // El motivo va aquí
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("idusuario", typeof(long));
            dt.Columns.Add("idusuariomns", typeof(long));
            dt.Columns.Add("intentoentrega", typeof(string)); // <- Será null

            string motivo = HttpContext.Current.Request.Params["motivo"];
            if (string.IsNullOrEmpty(motivo)) motivo = "Intento de entrega fallido";

            foreach (var item in codigos)
            {
                dt.Rows.Add(item.Codigo, item.Fecha, motivo, "-", 1L, 1L, DBNull.Value); // <== importante
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("workstation id=EnviosExpress.mssql.somee.com;packet size=4096;user id=EnviosExpress;pwd=Envios3228@;data source=EnviosExpress.mssql.somee.com;"))
                using (SqlCommand cmd = new SqlCommand("sp_intento_entrega_paquete", conn))
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
