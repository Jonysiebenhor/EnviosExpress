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


        //Código para convertir la cola en un data table e insertar los datos en la base de datos
        //Este código ejecuta un procedimiento almacenado con validaciones.
        public class ResultadoCodigo
        {
            public int Codigo { get; set; }
            public bool Exito { get; set; }
            public string Mensaje { get; set; }
        }




        //WebMethod para que al escanear los códigos, se registren con un estado dependiendo el módulo en el que está.


        // ✅ MÉTODO PRINCIPAL CORREGIDO
        [WebMethod(EnableSession = true)]
        public static object RegistrarEstadoPaquetes(
    List<CodigoEstadoQR> codigos,
    string motivo = null,
    bool visitaDestinatario = false,
    string quienRecibe = "")

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
                    return new List<ResultadoCodigo>
            {
                new ResultadoCodigo { Codigo = -1, Exito = false, Mensaje = "No hay códigos para procesar" }
            };
                }

                string primerEstado = primeraEntrada.Estado;

                // Manejar según el tipo de estado
                if (primerEstado == "entregado")
                {
                    var codigosSimples = codigos.Select(c => new CodigoQR
                    {
                        Codigo = c.Codigo,
                        Fecha = c.Fecha
                    }).ToList();

                    var resultado = RegistrarEntregas(codigosSimples, idUsuarioMns);

                    if (!string.IsNullOrWhiteSpace(quienRecibe))
                    {
                        ActualizarPaqueteRecibido(codigosSimples, quienRecibe);
                    }

                    return resultado;
                }

                else if (primerEstado == "intento de entrega")
                {
                    var codigosSimples = codigos.Select(c => new CodigoQR
                    {
                        Codigo = c.Codigo,
                        Fecha = c.Fecha
                    }).ToList();

                    // ✅ CORRECCIÓN PROBLEMA 2: Pasar visitaDestinatario al método
                    return RegistrarIntentosEntrega(codigosSimples, idUsuarioMns, motivo, visitaDestinatario);
                }
                // ✅ PROBLEMA YA CORREGIDO: El estado ya viene con "Devolución " desde el frontend
                else if (primerEstado != null && primerEstado.StartsWith("Devolución "))
                {
                    var codigosSimples = codigos.Select(c => new CodigoQR
                    {
                        Codigo = c.Codigo,
                        Fecha = c.Fecha
                    }).ToList();

                    if (primerEstado?.Trim().ToLower() == "devolución entregado")
                    {
                        // ✅ Registrar entrega normal
                        var resultado = RegistrarEntregas(codigosSimples, idUsuarioMns);

                        // ✅ Actualizar tabla paquete con quienRecibe si viene
                        if (!string.IsNullOrWhiteSpace(quienRecibe))
                        {
                            ActualizarPaqueteRecibido(codigosSimples, quienRecibe);
                        }

                        return resultado;
                    }
                    else
                    {
                        // ✅ Resto de devoluciones con motivos
                        return RegistrarDevoluciones(codigosSimples, primerEstado, idUsuarioMns, quienRecibe);
                    }
                }


                else
                {
                    // Para recolección, enrutado y casos con múltiples estados
                    return RegistrarRecoleccionRuta(codigos, idUsuarioMns);
                }
                return new List<ResultadoCodigo>
{
    new ResultadoCodigo { Codigo = -1, Exito = false, Mensaje = "Error inesperado: camino sin retorno." }
};

            }

            catch (Exception ex)
            {
                HttpContext.Current.Response.StatusCode = 500;
                return new { error = true, mensaje = ex.Message, detalle = ex.StackTrace };
            }
        }





        // ✅ MÉTODO PRINCIPAL CORREGIDO para manejar múltiples estados
        private static List<ResultadoCodigo> RegistrarRecoleccionRuta(List<CodigoEstadoQR> codigos, int idUsuarioMns)
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

            // ✅ Agregar cada código con su estado específico
            foreach (var item in codigos)
            {
                dt.Rows.Add(
                    item.Codigo,
                    item.Fecha,
                    item.Estado,
                    "-",
                    1L,
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
                        // ✅ CORRECCIÓN PROBLEMA 1: Si no hay filas, significa éxito
                        if (!reader.HasRows)
                        {
                            return new List<ResultadoCodigo>(); // Lista vacía = éxito
                        }

                        while (reader.Read())
                        {
                            resultados.Add(new ResultadoCodigo
                            {
                                Codigo = Convert.ToInt32(reader["idpaquete"]),
                                Exito = false,  // Si retorna filas, son errores
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
                    Mensaje = $"Error en base de datos: {ex.Message}"
                });
            }

            return resultados;
        }







        //Para registrar entregas:

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
                // ✅ PROBLEMA 3: No agregar "Intento exitoso", dejar como NULL
                dt.Rows.Add(item.Codigo, item.Fecha, "-", 1L, idUsuarioMns, DBNull.Value);
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
                        // ✅ CORRECCIÓN PROBLEMA 1: Si no hay filas, significa éxito
                        if (!reader.HasRows)
                        {
                            return new List<ResultadoCodigo>(); // Lista vacía = éxito
                        }

                        while (reader.Read())
                        {
                            resultados.Add(new ResultadoCodigo
                            {
                                Codigo = Convert.ToInt32(reader["idpaquete"]),
                                Exito = false,  // Si retorna filas, son errores
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


        //Intento de entrega - VERSIÓN CORREGIDA: Evita que se sume 2 veces el campo de "valorvisita"
        private static List<ResultadoCodigo> RegistrarIntentosEntrega(List<CodigoQR> codigos, int idUsuarioMns, string motivo, bool visitaDestinatario)
        {
            var resultados = new List<ResultadoCodigo>();

            // ✅ CORRECCIÓN: Usar el nuevo tipo de tabla que incluye visitadestinatario
            DataTable dt = new DataTable();
            dt.Columns.Add("idpaquete", typeof(int));
            dt.Columns.Add("fechahora", typeof(DateTime));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("idusuario", typeof(long));
            dt.Columns.Add("idusuariomns", typeof(long));
            dt.Columns.Add("estado", typeof(string));
            dt.Columns.Add("visitadestinatario", typeof(bool));  // ✅ NUEVO CAMPO

            if (string.IsNullOrEmpty(motivo))
                motivo = "Intento de entrega fallido";

            foreach (var item in codigos)
            {
                dt.Rows.Add(item.Codigo, item.Fecha, "-", 1L, idUsuarioMns, motivo, visitaDestinatario);
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
                        // ✅ CORRECCIÓN PROBLEMA 1: Si no hay filas, significa éxito
                        if (!reader.HasRows)
                        {
                            // No hay errores = éxito total
                            return new List<ResultadoCodigo>(); // Lista vacía = éxito
                        }

                        while (reader.Read())
                        {
                            resultados.Add(new ResultadoCodigo
                            {
                                Codigo = Convert.ToInt32(reader["idpaquete"]),
                                Exito = false,  // Si retorna filas, son errores
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








        //Devoluciones: 

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


            // ✅ El estado ya viene con "Devolución " desde el frontend
            string motivo = estadoCompleto.Replace("Devolución ", "");

            foreach (var item in codigos)
            {
                dt.Rows.Add(item.Codigo, item.Fecha, motivo, "-", 1L, idUsuarioMns);
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("workstation id=EnviosExpress.mssql.somee.com;packet size=4096;user id=EnviosExpress;pwd=Envios3228@;data source=EnviosExpress.mssql.somee.com;"))
                using (SqlCommand cmd = new SqlCommand("sp_registrar_devolucion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@codigos", dt);
                    tvpParam.SqlDbType = SqlDbType.Structured;

                    // ✅ Ahora enviar el parámetro
                    cmd.Parameters.AddWithValue("@quienRecibe", quienRecibe ?? "");

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return new List<ResultadoCodigo>(); // Éxito
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
