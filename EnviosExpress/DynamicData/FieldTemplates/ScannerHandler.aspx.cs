using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Data;

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
        public static string EnviarTodosLosCodigos(List<string> codigos)
        {
            // Simular la conversión a DataTable
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Codigo");

            foreach (string codigo in codigos)
            {
                tabla.Rows.Add(codigo);
            }

            // Aquí podrías guardar en base de datos, procesar, etc.
            return $"✅ Se recibieron {tabla.Rows.Count} códigos correctamente.";
        }



    }
}
