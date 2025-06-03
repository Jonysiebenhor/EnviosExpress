using System;
using System.Collections.Generic;
using System.Web;
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


    }
}
