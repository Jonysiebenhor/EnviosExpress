using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

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

        public class ResultadoCodigo
        {
            public int Codigo { get; set; }
            public bool Exito { get; set; }
            public string Mensaje { get; set; }
        }

        [WebMethod(EnableSession = true)]
        public static object RegistrarEstadoPaquetes(
    List<CodigoEstadoQR> codigos,
    string motivo = null,
    bool visitaDestinatario = false,
    string quienRecibe = "",
    bool esRutaDirecta = false)
        {
            try
            {
                int idUsuarioMns = 0;

                if (HttpContext.Current.Session["id"] != null)
                {
                    int.TryParse(HttpContext.Current.Session["id"].ToString(), out idUsuarioMns);
                }

                var primeraEntrada = codigos.FirstOrDefault();
                if (primeraEntrada == null)
                {
                    return new
                    {
                        success = false,
                        errores = new List<ResultadoCodigo>
                {
                    new ResultadoCodigo { Codigo = -1, Exito = false, Mensaje = "No hay códigos para procesar" }
                }
                    };
                }

                string primerEstado = primeraEntrada.Estado;
                List<ResultadoCodigo> resultado;

                if (primerEstado == "entregado")
                {
                    var codigosSimples = codigos.Select(c => new CodigoQR
                    {
                        Codigo = c.Codigo,
                        Fecha = c.Fecha
                    }).ToList();

                    resultado = RegistrarEntregas(codigosSimples, idUsuarioMns);

                    if (!string.IsNullOrWhiteSpace(quienRecibe))
                    {
                        ActualizarPaqueteRecibido(codigosSimples, quienRecibe);
                    }
                }
                else if (primerEstado == "intento de entrega")
                {
                    var codigosSimples = codigos.Select(c => new CodigoQR
                    {
                        Codigo = c.Codigo,
                        Fecha = c.Fecha
                    }).ToList();

                    resultado = RegistrarIntentosEntrega(codigosSimples, idUsuarioMns, motivo, visitaDestinatario);
                }
                else if (primerEstado != null && primerEstado.StartsWith("Devolución "))
                {
                    var codigosSimples = codigos.Select(c => new CodigoQR
                    {
                        Codigo = c.Codigo,
                        Fecha = c.Fecha
                    }).ToList();

                    resultado = RegistrarDevoluciones(codigosSimples, primerEstado, idUsuarioMns, quienRecibe);
                }
                else
                {
                    resultado = RegistrarRecoleccionRuta(codigos, idUsuarioMns, esRutaDirecta);
                }

                return new
                {
                    success = resultado.All(r => r.Exito),
                    errores = resultado
                };
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.StatusCode = 500;
                return new
                {
                    success = false,
                    errores = new List<ResultadoCodigo> {
                new ResultadoCodigo {
                    Codigo = -1,
                    Exito = false,
                    Mensaje = "Error inesperado: " + ex.Message
                }
            }
                };
            }
        }

        // ✅ CORREGIDO: idusuario ahora se envía como NULL
        private static List<ResultadoCodigo> RegistrarRecoleccionRuta(List<CodigoEstadoQR> codigos, int idUsuarioMns, bool esRutaDirecta = false)
        {
            var resultados = new List<ResultadoCodigo>();

            // Crear tabla para enviar al SP
            DataTable dt = new DataTable();
            dt.Columns.Add("idpaquete", typeof(int));
            dt.Columns.Add("fechahora", typeof(DateTime));
            dt.Columns.Add("estado", typeof(string));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("idusuario", typeof(long));
            dt.Columns.Add("idusuariomns", typeof(long));
            dt.Columns.Add("intentoentrega", typeof(string));

            // ✅ Agregar cada código con idusuario como NULL
            foreach (var item in codigos)
            {
                dt.Rows.Add(
                    item.Codigo,
                    item.Fecha,
                    item.Estado,
                    "-",
                    DBNull.Value,  // ✅ CAMBIO: idusuario = NULL en lugar de 1L
                    idUsuarioMns,
                    DBNull.Value
                );
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("workstation id=EnviosExpress.mssql.somee.com;packet size=4096;user id=EnviosExpress;pwd=Envios3228@;data source=EnviosExpress.mssql.somee.com;"))
                using (SqlCommand cmd = new SqlCommand("sp_registrar_estado_paquete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@codigos", dt);
                    tvpParam.SqlDbType = SqlDbType.Structured;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return new List<ResultadoCodigo>();
                        }

                        while (reader.Read())
                        {
                            string mensaje = reader["mensaje"].ToString();
                            int codigoPaquete = Convert.ToInt32(reader["idpaquete"]);

                            bool esExito = mensaje.ToLower().Contains("registrado correctamente") ||
                                           mensaje.ToLower().Contains("insertado correctamente") ||
                                           mensaje.ToLower().Contains("exitosamente") ||
                                           mensaje.ToLower().Contains("se registró") ||
                                           mensaje.ToLower().Contains("completado");

                            if (esRutaDirecta && esExito)
                            {
                                continue;
                            }

                            if (!esExito)
                            {
                                resultados.Add(new ResultadoCodigo
                                {
                                    Codigo = codigoPaquete,
                                    Exito = false,
                                    Mensaje = mensaje
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
                    Mensaje = $"Error en base de datos: {ex.Message}"
                });
            }

            return resultados;
        }

        // ✅ CORREGIDO: idusuario ahora se envía como NULL
        private static List<ResultadoCodigo> RegistrarEntregas(List<CodigoQR> codigos, int idUsuarioMns)
        {
            var resultados = new List<ResultadoCodigo>();

            DataTable dt = new DataTable();
            dt.Columns.Add("idpaquete", typeof(int));
            dt.Columns.Add("fechahora", typeof(DateTime));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("idusuario", typeof(long));
            dt.Columns.Add("idusuariomns", typeof(long));
            dt.Columns.Add("intentoentrega", typeof(string));

            foreach (var item in codigos)
            {
                // ✅ CAMBIO: idusuario = NULL en lugar de 1L
                dt.Rows.Add(item.Codigo, item.Fecha, "-", DBNull.Value, idUsuarioMns, DBNull.Value);
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("workstation id=EnviosExpress.mssql.somee.com;packet size=4096;user id=EnviosExpress;pwd=Envios3228@;data source=EnviosExpress.mssql.somee.com;"))
                using (SqlCommand cmd = new SqlCommand("sp_entregar_paquete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@codigos", dt);
                    tvpParam.SqlDbType = SqlDbType.Structured;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return new List<ResultadoCodigo>();
                        }

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



        // ✅ CORREGIDO: idusuario ahora se envía como NULL
        private static List<ResultadoCodigo> RegistrarIntentosEntrega(List<CodigoQR> codigos, int idUsuarioMns, string motivo, bool visitaDestinatario)
        {
            var resultados = new List<ResultadoCodigo>();

            DataTable dt = new DataTable();
            dt.Columns.Add("idpaquete", typeof(int));
            dt.Columns.Add("fechahora", typeof(DateTime));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("idusuario", typeof(long));
            dt.Columns.Add("idusuariomns", typeof(long));
            dt.Columns.Add("estado", typeof(string));
            dt.Columns.Add("visitadestinatario", typeof(bool));

            if (string.IsNullOrEmpty(motivo))
                motivo = "Intento de entrega fallido";

            foreach (var item in codigos)
            {
                // ✅ CAMBIO: idusuario = NULL en lugar de 1L
                dt.Rows.Add(item.Codigo, item.Fecha, "-", DBNull.Value, idUsuarioMns, motivo, visitaDestinatario);
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("workstation id=EnviosExpress.mssql.somee.com; packet size=4096; user id=EnviosExpress; pwd=Envios3228@; data source=EnviosExpress.mssql.somee.com;"))
                using (SqlCommand cmd = new SqlCommand("sp_intento_entrega_paquete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@codigos", dt);
                    tvpParam.SqlDbType = SqlDbType.Structured;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return new List<ResultadoCodigo>();
                        }

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



        // ✅ CORREGIDO: idusuario ahora se envía como NULL
        private static List<ResultadoCodigo> RegistrarDevoluciones(List<CodigoQR> codigos, string estadoCompleto, int idUsuarioMns, string quienRecibe = "")
        {
            var resultados = new List<ResultadoCodigo>();

            DataTable dt = new DataTable();
            dt.Columns.Add("idpaquete", typeof(int));
            dt.Columns.Add("fechahora", typeof(DateTime));
            dt.Columns.Add("motivodevolucion", typeof(string));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("idusuario", typeof(long));
            dt.Columns.Add("idusuariomns", typeof(long));

            string motivo = estadoCompleto.Replace("Devolución ", "");

            foreach (var item in codigos)
            {
                // ✅ CAMBIO: idusuario = NULL en lugar de 1L
                dt.Rows.Add(item.Codigo, item.Fecha, motivo, "-", DBNull.Value, idUsuarioMns);
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("workstation id=EnviosExpress.mssql.somee.com;packet size=4096;user id=EnviosExpress;pwd=Envios3228@;data source=EnviosExpress.mssql.somee.com;"))
                using (SqlCommand cmd = new SqlCommand("sp_registrar_devolucion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@codigos", dt);
                    tvpParam.SqlDbType = SqlDbType.Structured;

                    cmd.Parameters.AddWithValue("@quienRecibe", quienRecibe ?? "");

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return new List<ResultadoCodigo>();
                        }

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

        private static void ActualizarPaqueteRecibido(List<CodigoQR> codigos, string quienRecibe)
        {
            if (string.IsNullOrWhiteSpace(quienRecibe) || codigos == null || codigos.Count == 0)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection("workstation id=EnviosExpress.mssql.somee.com;packet size=4096;user id=EnviosExpress;pwd=Envios3228@;data source=EnviosExpress.mssql.somee.com;"))
                {
                    conn.Open();

                    foreach (var c in codigos)
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE paquete SET recibido = @recibido WHERE idpaquete = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@recibido", quienRecibe);
                            cmd.Parameters.AddWithValue("@id", c.Codigo);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Opcional: log del error
            }
        }

        public class CodigoQR
        {
            public int Codigo { get; set; }
            public DateTime Fecha { get; set; }
        }

        public class CodigoEstadoQR : CodigoQR
        {
            public string Estado { get; set; }
        }
    }
}