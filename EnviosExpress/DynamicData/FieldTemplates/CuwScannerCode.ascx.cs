using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace EnviosExpress.DynamicData.FieldTemplates
{
    public partial class CuwScannerCode : System.Web.DynamicData.FieldTemplateUserControl, IPostBackEventHandler
    {
        public override Control DataControl => Literal1;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Session["CodigosEscaneados"] == null)
                Session["CodigosEscaneados"] = new List<string>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gd1.DataBind();
            }
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            if (!string.IsNullOrWhiteSpace(eventArgument))
            {
                List<string> codigos = Session["CodigosEscaneados"] as List<string>;
                if (!codigos.Contains(eventArgument))
                {
                    codigos.Add(eventArgument);
                    // Aquí podrías actualizar una tabla, GridView, base de datos, etc.
                    lblMessage.Text = $"✅ Código <strong>{eventArgument}</strong> registrado.";
                    lblMessage.CssClass = "alert alert-success d-block";
                }
                else
                {
                    lblMessage.Text = $"⚠️ El código <strong>{eventArgument}</strong> ya fue escaneado.";
                    lblMessage.CssClass = "alert alert-warning d-block";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Aquí podrías manejar lo que sucede cuando se envían todos los códigos escaneados
            var codigos = Session["CodigosEscaneados"] as List<string>;
            if (codigos != null)
            {
                // Procesar lista, guardar en BD, etc.
            }
        }

        [System.Web.Services.WebMethod]
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

        [System.Web.Services.WebMethod]
        public static List<string> ObtenerCodigos()
        {
            var codigos = HttpContext.Current.Session["CodigosEscaneados"] as List<string>;
            return codigos ?? new List<string>();
        }

        private DataTable ConvertirListaACodigoDataTable(List<string> codigos)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CodigoQR", typeof(string)); // Pueden cambiar el nombre de columna si tu tabla en BD tiene otro

            foreach (var codigo in codigos)
            {
                dt.Rows.Add(codigo);
            }

            return dt;
        }




    }
}
