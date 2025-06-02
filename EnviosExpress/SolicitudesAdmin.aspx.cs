using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls;

namespace EnviosExpress
{
    public partial class SolicitudesAdmin : System.Web.UI.Page
    {
        Conectar conectado = new Conectar();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] is null)
                {
                    Response.Redirect("/Login.aspx");
                }
            }
        }



        protected void btn3_Click(object sender, EventArgs e)
        {
        }

        protected void regresar_Click(object sender, EventArgs e)
        { Response.Redirect("MenuAdministrador.aspx");
        }
    }
}