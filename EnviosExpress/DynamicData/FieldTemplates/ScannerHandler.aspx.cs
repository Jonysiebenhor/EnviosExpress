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


        [WebMethod(EnableSession = true)]
        public static List<ResultadoCodigo> RegistrarEstadoPaquetes(List<CodigoQR> codigos, string estado, string motivo, bool visitaDestinatario = false)
        {
            int idUsuarioMns = 0;
            if (HttpContext.Current.Session["id"] != null)
            {
                int.TryParse(HttpContext.Current.Session["id"].ToString(), out idUsuarioMns);
            }

            if (estado == "entregado")
            {
                return RegistrarEntregas(codigos, idUsuarioMns);
            }
            else if (estado == "intento de entrega")
            {
                return RegistrarIntentosEntrega(codigos, idUsuarioMns, motivo, visitaDestinatario); // <- 🔧 AQUÍ
            }
            else if (estado.StartsWith("Devolución "))
            {
                return RegistrarDevoluciones(codigos, estado, idUsuarioMns);
            }
            else
            {
                return RegistrarRecoleccionRuta(codigos, estado, idUsuarioMns);
            }
        }





        private static List<ResultadoCodigo> RegistrarRecoleccionRuta(List<CodigoQR> codigos, string estado, int idUsuarioMns)
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
                dt.Rows.Add(item.Codigo, item.Fecha, estado, "-", 1L, idUsuarioMns, DBNull.Value);
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
                dt.Rows.Add(item.Codigo, item.Fecha, "-", 1L, idUsuarioMns, "Intento exitoso");
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


        //Intento de entrega: 

        private static List<ResultadoCodigo> RegistrarIntentosEntrega(List<CodigoQR> codigos, int idUsuarioMns, string motivo, bool visitaDestinatario)

        {
            var resultados = new List<ResultadoCodigo>();

            DataTable dt = new DataTable();
            dt.Columns.Add("idpaquete", typeof(int));
            dt.Columns.Add("fechahora", typeof(DateTime));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("idusuario", typeof(long));
            dt.Columns.Add("idusuariomns", typeof(long));
            dt.Columns.Add("intentoentrega", typeof(string));

            if (string.IsNullOrEmpty(motivo)) motivo = "Intento de entrega fallido";

            foreach (var item in codigos)
            {
                string motivoFinal = visitaDestinatario ? "VISITA" : motivo;

                // Si se visitó al destinatario, actualizamos valores directamente
                if (visitaDestinatario)
                {
                    using (SqlConnection conn = new SqlConnection("workstation id=EnviosExpress.mssql.somee.com; packet size=4096; user id=EnviosExpress; pwd=Envios3228@; data source=EnviosExpress.mssql.somee.com;"))
                    {
                        conn.Open();
                        string updateSql = @"
UPDATE paquete
SET 
    valorvisita = ISNULL(valorvisita, 0) + ISNULL(valorenvio, 0)
WHERE idpaquete = @id;

UPDATE paquete
SET 
    cantidadadepositar = 
        CASE 
            WHEN monto IS NOT NULL AND valorenvio IS NOT NULL AND valorvisita IS NOT NULL
            THEN monto - valorenvio - valorvisita
            ELSE NULL
        END
WHERE idpaquete = @id;";

                        using (SqlCommand cmd = new SqlCommand(updateSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", item.Codigo);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // Añadir fila al TVP
                dt.Rows.Add(item.Codigo, item.Fecha, "-", 1L, idUsuarioMns, motivoFinal);
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






        //Devoluciones: 


        private static List<ResultadoCodigo> RegistrarDevoluciones(List<CodigoQR> codigos, string estadoCompleto, int idUsuarioMns)
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
                dt.Rows.Add(item.Codigo, item.Fecha, motivo, "-", 1L, idUsuarioMns); //idUsuarioMns Es el usuario que se logeó
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("workstation id=EnviosExpress.mssql.somee.com;packet size=4096;user id=EnviosExpress;pwd=Envios3228@;data source=EnviosExpress.mssql.somee.com;"))
                using (SqlCommand cmd = new SqlCommand("sp_registrar_devolucion", conn))
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
