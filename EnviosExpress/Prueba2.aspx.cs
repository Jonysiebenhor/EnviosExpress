using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnviosExpress
{
    public partial class Prueba2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["CuwScannerCode%24resultado"].ToString();

            TextBox1.Text = rawId;
        }
    }
}