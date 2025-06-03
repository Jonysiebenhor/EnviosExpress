using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnviosExpress
{
    //Backend que guarda el resultado del escaneo
    public partial class Prueba2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string rawId = Request.QueryString["CuwScannerCode$resultado"];

            if (!string.IsNullOrEmpty(rawId))
            {
                TextBox1.Text = rawId;
            }
            else
            {
                TextBox1.Text = "No se recibió código escaneado.";
            }


            TextBox1.Text = rawId;
        }
    }
}