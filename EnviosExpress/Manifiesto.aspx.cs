using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using MessagingToolkit.QRCode.Codec;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.X500;
using System;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Windows.Controls;
using System.Windows.Media;
//using System.Web.Hosting;
using System.Windows.Media.Media3D;
using Font = iTextSharp.text.Font;
using Path = iTextSharp.text.pdf.parser.Path;
using Rectangle = iTextSharp.text.Rectangle;

namespace EnviosExpress
{
    public partial class Manifiesto : System.Web.UI.Page
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

                //String dpi = Session["id"].ToString();
                String idmanifiestoo = Request.QueryString["idmanifiesto"].ToString();
                int idmanifiesto = Int32.Parse(idmanifiestoo);
                //ViewState["dpii"] = dpi;

                if (idmanifiesto > 1)
                {
                    imprimir.Visible = true;

                }
                else
                {
                    imprimir.Visible = false;
                }
                conectado.desconectar();
            }
        }

        public void cargar1(String dpi)
        {
            dpi = Session["id"].ToString();


        }
        public void cargar2(String idmanifiesto)
        {
            idmanifiesto = Request.QueryString["idmanifiesto"].ToString();


        }
        private void cargar1(string @string, object dpi)
        {
            dpi = Session["id"].ToString();
        }
        public static int contador = 0;

        public static string ContadorX;


        protected void Cierre_Click(object sender, EventArgs e)
        {
            conectado.conectar();
            imprimir.Visible = false;
            GridView5.Visible = false;
            String dpi = Session["id"].ToString();
            DataTable sesionn = new DataTable();
            sesionn = conectado.manifiesto(dpi);

            if (sesionn.Rows.Count > 0)
            {
                conectado.manifiesto1(dpi);
                DataRow rows = conectado.manifiesto0().Rows[0];
                String idmanifiesto = Convert.ToString(Convert.ToString(rows["idmanifiesto"]));

                conectado.manifiesto3(idmanifiesto, dpi);
                imprimir.Visible = true;

                Cierre.Visible = false;
                Response.Redirect("Manifiesto.aspx?idmanifiesto=" + idmanifiesto);
                //Response.Redirect("Manifiesto.aspx?id=" + dpi);
                GridView5.DataSource = conectado.manifiesto7(idmanifiesto);
                GridView5.DataBind();
            }
            else
            {
                Response.Write("<script>alert('No hay Manifiestos por Cerrar')</script>");
            }
            conectado.desconectar();
        }
        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");

        }
        // public static String CONTADORT = ContadorX;

        // public static int contador1 = ContadorX;

        protected void imprimir_Click(object sender, EventArgs e)
        {

            //contador++;
            String dpi1 = Session["id"].ToString();
            String idmanifiesto = Request.QueryString["idmanifiesto"].ToString();

            conectado.conectar();
            DataRow rows = conectado.manifiesto2(idmanifiesto).Rows[0];
            String fechahora = Convert.ToString(Convert.ToString(rows["fechahora"]));

            DataRow rowss = conectado.consultaUsuarioDPI(dpi1).Rows[0];
            String Nombre = Convert.ToString(Convert.ToString(rowss["primerNombre"]));
            String Apellido = Convert.ToString(Convert.ToString(rowss["primerApellido"]));
            String negocio = Convert.ToString(Convert.ToString(rowss["nombrenegocio"]));
            String dpi = Nombre + " " + Apellido;




            DataTable dt = new DataTable();
            Document document = new Document();
            document.SetPageSize(new Rectangle(792f, 612f));
            document.SetMargins(45f, 50f, 110f, 50f);

            PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);



            dt = conectado.manifiesto7(idmanifiesto);
            document.Open();

            string pathImage = idmanifiesto;
            // string contador2 = Convert.ToString(CONTADORT);
            //String ContadorY = Convert.ToString(contador);


            writer.PageEvent = new PdfWriterEvents(pathImage, fechahora, dpi, negocio); //ContadorY);
            //contador = 0;


            Font titulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            Font subtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            Font subtitulo2 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            Font subtitulo3 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);
            Font subtitulo4 = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            Font texto = FontFactory.GetFont(FontFactory.HELVETICA, 8);

            PdfPTable table = new PdfPTable(7);

            //actual width of table in points

            table.TotalWidth = 700f;

            //fix the absolute width of the table

            table.LockedWidth = true;



            //relative col widths in proportions - 1/3 and 2/3

            float[] widths = new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 1f };

            table.SetWidths(widths);

            table.HorizontalAlignment = 0;

            //leave a gap before and after the table

            //table.SpacingBefore = 40f;

            //table.SpacingAfter = 40f;




            PdfPCell cell = new PdfPCell();

            cell.Colspan = 7;

            cell.Border = 0;

            cell.HorizontalAlignment = 1;
            table.AddCell(cell);



            String connect = "workstation id=EnviosExpress.mssql.somee.com;packet size=4096;user id=EnviosExpress;pwd=Envios3228@;data source=EnviosExpress.mssql.somee.com;persist security info=False;initial catalog=EnviosExpress;TrustServerCertificate=True";
            //string connect = "Data Source=DESKTOP-KNTJ3BG\\SQLEXPRESS;DATABASE=EnviosExpress;Integrated security=true";

            using (SqlConnection conn = new SqlConnection(connect))

            {

                string query = "select a.idpaquete as Guía,a.Destinatario, SUBSTRING(a.direccion, 1, 80) as Dirección , a.Telefono as Teléfono, a.Monto, b.nombre as Departamento,c.nombre as Municipio from paquete a left join departamento b on a.iddepartamento = b.iddepartamento left join municipio c on a.idmunicipio = c.idmunicipio where a.idmanifiesto = " + idmanifiesto + "";
                SqlCommand cmd = new SqlCommand(query, conn);

                try

                {

                    conn.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())

                    {
                        //DataTable dt = new DataTable();
                        //PdfPTable table = new PdfPTable(dt.Columns.Count);

                        foreach (DataColumn c in dt.Columns)
                        {
                            table.AddCell(new Phrase(c.ColumnName, subtitulo));
                        }

                        while (rdr.Read())

                        {

                            table.AddCell(rdr[0].ToString());
                            table.AddCell(rdr[1].ToString());
                            table.AddCell(rdr[2].ToString());
                            table.AddCell(rdr[3].ToString());
                            table.AddCell("Q" + rdr[4].ToString());
                            table.AddCell(rdr[5].ToString());
                            table.AddCell(rdr[6].ToString());
                        }

                    }

                }

                catch (Exception ex)

                {

                    Response.Write(ex.Message);
                }

                document.Add(table);
                document.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + idmanifiesto + ".pdf");
                HttpContext.Current.Response.Write(idmanifiesto);
                Response.Flush();
                Response.End();

            }
            conectado.desconectar();
            //contador = 0;
        }

        class PdfWriterEvents : IPdfPageEvent
        {
            //PdfContentByte cb;
            BaseFont bf = null;
            string PathImage = null;
            string fechahora = null;
            string contador3 = null;
            string dpi0 = null;
            string negocio0 = null;
            PdfTemplate template;
            // BaseFont bg = null;
            DateTime PrintTime = DateTime.Now;


            public PdfWriterEvents(String logoPaht, String fechahora1, String dpi, String negocio)
            {

                //contador++;
                PathImage = logoPaht;
                fechahora = fechahora1;
                dpi0 = dpi;
                negocio0 = negocio;
                // contador0 = ContadorY;

            }
            public void OnChapter(PdfWriter writer, Document document, float paragraphPosition, Paragraph title)
            {
            }

            public void OnChapterEnd(PdfWriter writer, Document document, float paragraphPosition)
            {
            }

            public void OnCloseDocument(PdfWriter writer, Document document)
            {

            }

            public void OnEndPage(PdfWriter writer, Document document)
            {

                PdfContentByte cb = writer.DirectContent;
                String image = PathImage;
                String fechahora2 = fechahora;
                String contador4 = contador3;
                String dpi1 = dpi0;
                String negocio1 = negocio0;

                String marca = "Manifiesto " + image;
                float positionX = writer.PageSize.Right / 2;
                float positionXX = writer.PageSize.Right / 5;
                float positiony = writer.PageSize.Top - 60;
                float positionyy = writer.PageSize.Top - 90;
                float fontSize = 20f;
                float fontSize2 = 15f;
                float rotation = 0f;





                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, BaseFont.EMBEDDED);
                cb.BeginText();
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(bf, fontSize);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, marca, positionX, positiony, rotation);
                cb.EndText();

                BaseFont bb = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.EMBEDDED);
                cb.BeginText();
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(bb, fontSize2);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, fechahora2, positionX, positionyy, rotation);
                cb.EndText();

                BaseFont bh = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.EMBEDDED);
                cb.BeginText();
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(bh, fontSize2);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dpi1, positionXX, positionyy, rotation);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, negocio1, positionXX, positiony, rotation);
                cb.EndText();



                iTextSharp.text.Image logo1 = iTextSharp.text.Image.GetInstance("http://www.enviosexpress.somee.com/Imagenes/enviosexpress22.jpg");
                logo1.ScaleAbsoluteWidth(170);
                logo1.ScaleAbsoluteHeight(70);
                logo1.SetAbsolutePosition(550, 520);
                PdfGState state = new PdfGState();
                state.FillOpacity = 1;
                cb.SetGState(state);
                cb.AddImage(logo1);

                /*try
                {
                    PrintTime = DateTime.Now;
                    bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    cb = writer.DirectContent;
                    template = cb.CreateTemplate(document.PageSize.Width, 50);
                }
                catch (DocumentException de)
                {
                }
                catch (System.IO.IOException ioe)
                {
                }*/

                //base.OnEndPage(writer, document);
                Rectangle pageSize = document.PageSize;
                cb.BeginText();
                cb.SetFontAndSize(bf, 15);
                cb.SetRGBColorFill(50, 50, 200);
                cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetTop(40));
                //cb.ShowText(ContadorYY);
                cb.EndText();
                contador++;

                //base.OnEndPage(writer, document);
                int pageN = writer.PageNumber;
                String text = "Page " + pageN;
                float len = bf.GetWidthPoint(pageN, 8);
                //string len1 = Convert.ToString(contador);
                //ContadorX = len1;

                //Rectangle pageSize = document.PageSize;
                cb.SetRGBColorFill(100, 100, 100);
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetBottom(30));
                cb.ShowText(text);
                //cb.ShowText("LEN "+len1);
                //cb.ShowText("contador " + ContadorYY);
                cb.EndText();


                // String text1 = contador.ToString();
                //cb.ShowText("LEN " + text1);

                //cb.AddTemplate(template, pageSize.GetLeft(40) + len, pageSize.GetBottom(30));
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT,
                    "Impreso el " + PrintTime.ToString(),
                  pageSize.GetRight(40),
                   pageSize.GetBottom(30), 0);
                cb.EndText();
            }



            public void OnGenericTag(PdfWriter writer, Document document, Rectangle rect, string text)
            {
            }

            public void OnOpenDocument(PdfWriter writer, Document document)
            {

            }

            public void OnParagraph(PdfWriter writer, Document document, float paragraphPosition)
            {
            }

            public void OnParagraphEnd(PdfWriter writer, Document document, float paragraphPosition)
            {

            }

            public void OnSection(PdfWriter writer, Document document, float paragraphPosition, int depth, Paragraph title)
            {
            }

            public void OnSectionEnd(PdfWriter writer, Document document, float paragraphPosition)
            {
            }

            public void OnStartPage(PdfWriter writer, Document document)
            {
            }

        }


        protected void Button2_Click(object sender, EventArgs e)
        {

            imprimir.Visible = false;
            String dpi = Session["id"].ToString();
            String fechain = TextBox1.Text;
            String fechafin = TextBox2.Text;
            DataTable sesionn = new DataTable();
            sesionn = conectado.manifiesto8(fechain, fechafin);

            if (sesionn.Rows.Count > 0)
            {
                DataRow rows = conectado.manifiesto9(fechain, fechafin, dpi).Rows[0];
                //String idmanifiesto = Convert.ToString(Convert.ToString(rows["idmanifiesto"]));

                GridView5.Visible = true;
                GridView5.DataSource = conectado.manifiesto9(fechain, fechafin, dpi);
                GridView5.DataBind();

            }
            else
            {
                Response.Write("<script>alert('No se encontraron manifiestos')</script>");
                GridView5.Visible = false;
            }
            conectado.desconectar();
        }

        //contador = 0;
    }
}
//contador = 0;