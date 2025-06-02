using MathNet.Numerics.Distributions;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI.WebControls;

namespace EnviosExpress
{
    public partial class PagosAdmin : System.Web.UI.Page
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
                bingrind();
            }
        }
        private void bingrind()
        {
            /* SqlConnection con = new SqlConnection();
             con.ConnectionString = ConfigurationManager.ConnectionStrings["connBD"].ToString();
             con.Open();
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "Select a.idpago,CONCAT(b.primerNombre, ' ', b.primerApellido) as Mensajero, a.fechahora as Fecha,  CONCAT('Q',a.monto) as Monto, a.Estado as Estado from pagos a left join usuario b on a.idusuariomns=b.dpi where b.rol=2 order by a.fechahora DESC";
             cmd.Connection = con;
             SqlDataReader rd= cmd.ExecuteReader();*/
            conectado.conectar();
            String fecha5 = txtfecha5.Text;
            String fecha6 = txtfecha6.Text;
            GridView1.DataSource = conectado.pagos1(fecha5, fecha6);
            GridView1.DataBind();
            String fecha3 = txtfecha3.Text;
            String fecha4 = txtfecha4.Text;
            GridView3.DataSource = conectado.pagosclientes6(fecha3, fecha4);//obtener datos de la guia
            GridView3.DataBind();
            String fecha1 = txtfecha1.Text;
            String fecha2 = txtfecha2.Text;
            GridView2.DataSource = conectado.pagosclientes1(fecha1, fecha2);//obtener datos de la guia
            GridView2.DataBind();
            conectado.desconectar();
        }
        protected void btnrecolectar_Click(object sender, EventArgs e)
        {
            conectado.conectar();
            String fecha5 = txtfecha5.Text;
            String fecha6 = txtfecha6.Text;
            GridView1.DataSource = conectado.pagos1(fecha5, fecha6);//obtener datos de la guia
            GridView1.DataBind();
            conectado.desconectar();
        }
        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdministrador.aspx");
        }


        protected void btn3_Click(object sender, EventArgs e)
        {
            conectado.conectar();
            String fecha1 = txtfecha1.Text;
            String fecha2 = txtfecha2.Text;
            GridView2.DataSource = conectado.pagosclientes1(fecha1, fecha2);//obtener datos de la guia
            GridView2.DataBind();
            conectado.desconectar();
        }
        protected void btn2_Click(object sender, EventArgs e)
        {
            conectado.conectar();
            String fecha3 = txtfecha3.Text;
            String fecha4 = txtfecha4.Text;
            GridView3.DataSource = conectado.pagosclientes6(fecha3, fecha4);//obtener datos de la guia
            GridView3.DataBind();
            conectado.desconectar();
        }

        protected void RowUpdatingEvent(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            GridViewRow fila = GridView1.Rows[e.RowIndex];
            String Estado = (fila.FindControl("ddl2") as DropDownList).Text.ToUpper();
            String guia = (fila.FindControl("TextBox3") as TextBox).Text.ToUpper();
            String refe = (fila.FindControl("TextBox88") as TextBox).Text.ToUpper();
            String fecha5 = txtfecha5.Text;
            String fecha6 = txtfecha6.Text;
            conectado.conectar();
            conectado.pagos2(Estado, guia, refe);
            GridView1.EditIndex = -1;
            GridView1.DataSource = conectado.pagos1(fecha5, fecha6);//obtener datos de la guia
            GridView1.DataBind();
            conectado.desconectar();

        }

        protected void RowEditingEvent(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            conectado.conectar();
            String fecha5 = txtfecha5.Text;
            String fecha6 = txtfecha6.Text;
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = conectado.pagos1(fecha5, fecha6);//obtener datos de la guia
            GridView1.DataBind();
            conectado.desconectar();

        }



        protected void RowCancelingEvent(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            conectado.conectar();
            String fecha5 = txtfecha5.Text;
            String fecha6 = txtfecha6.Text;
            GridView1.EditIndex = -1;
            GridView1.DataSource = conectado.pagos1(fecha5, fecha6);//obtener datos de la guia
            GridView1.DataBind();
            conectado.desconectar();
        }


        protected void RowCancelingEvent1(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            conectado.conectar();
            String fecha1 = txtfecha1.Text;
            String fecha2 = txtfecha2.Text;
            GridView2.EditIndex = -1;
            GridView2.DataSource = conectado.pagosclientes1(fecha1, fecha2);//obtener datos de la guia
            GridView2.DataBind();
            conectado.desconectar();
        }

        protected void RowEditingEvent1(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            conectado.conectar();
            String fecha1 = txtfecha1.Text;
            String fecha2 = txtfecha2.Text;
            GridView2.EditIndex = e.NewEditIndex;
            GridView2.DataSource = conectado.pagosclientes1(fecha1, fecha2);//obtener datos de la guia
            GridView2.DataBind();
            conectado.desconectar();

        }


        protected void RowUpdatingEvent1(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            String dpi2 = Session["id"].ToString();
            GridViewRow fila = GridView2.Rows[e.RowIndex];
            String dpi = (fila.FindControl("TextBox7") as TextBox).Text.ToUpper();
            String monto = (fila.FindControl("TextBox10") as TextBox).Text.ToUpper();
            String refe = (fila.FindControl("TextBox11") as TextBox).Text.ToUpper();

            conectado.conectar();
            conectado.pagosclientes2(dpi, dpi2, monto, refe);

            DataRow cierre2 = conectado.cierrepaquete1().Rows[0];
            String idpago = Convert.ToString(Convert.ToString(cierre2["idpago"]));
            String dpi1 = Convert.ToString(Convert.ToString(cierre2["idusuario"]));
            conectado.pagosclientes3(idpago, dpi1);
            conectado.pagosclientes4(idpago);
            conectado.pagosclientes5(dpi1, dpi2);

            ////DataTable ct = conectado.pagosclientes4(idpago);
            //for (int i = 0; i <= ct; i++)
            /*DataRow cierre3 = conectado.pagosclientes4(idpago).Rows[0];
           /* String guia = Convert.ToString(Convert.ToString(cierre3["idpaquete"]));
            String dpi2 = Convert.ToString(Convert.ToString(cierre3["idusuario"]));
            conectado.pagosclientes5(guia, dpi2);*/
            String fecha1 = txtfecha1.Text;
            String fecha2 = txtfecha2.Text;
            String fecha3 = txtfecha3.Text;
            String fecha4 = txtfecha4.Text;
            GridView2.EditIndex = -1;
            GridView2.DataSource = conectado.pagosclientes1(fecha1, fecha2);//obtener datos de la guia
            GridView2.DataBind();
            GridView3.EditIndex = -1;
            GridView3.DataSource = conectado.pagosclientes6(fecha3, fecha4);//obtener datos de la guia
            GridView3.DataBind();
            conectado.desconectar();
        }

    }
} //Redirigir al menu principal