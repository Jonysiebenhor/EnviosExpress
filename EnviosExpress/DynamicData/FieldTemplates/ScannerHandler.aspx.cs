using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Data;
using Newtonsoft.Json;

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


        //Código para convertir la cola en un data table
        [WebMethod]
        public static string EnviarTodosLosCodigos(List<CodigoQR> codigos)
        {
            // Aquí convierte el JSON obtenido en el JS en un Data Table.
            DataTable dt = new DataTable();
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));

            foreach (var item in codigos)
            {
                dt.Rows.Add(item.Codigo, item.Fecha);
            }

            // Aquí se puede guardar el DataTable en la base de datos o hacer lo necesario
            // De momento, solo devolvemos el número de registros como prueba
            return $"Se recibieron {dt.Rows.Count} registros.";
        }

        public class CodigoQR
        {
            public string Codigo { get; set; }
            public DateTime Fecha { get; set; }
        }



    }
}
