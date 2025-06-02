using iTextSharp.text;
using iTextSharp.text.pdf;
using EnviosExpress;
using System;
using System.Data;

using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

using System.Collections.Generic;
using System.Linq;
using System.Web.UI;


using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using static QRCoder.PayloadGenerator;
using static System.Net.WebRequestMethods;

using MessagingToolkit.QRCode.Codec;

using Font = iTextSharp.text.Font;
//using Path = iTextSharp.text.pdf.parser.Path;
using Rectangle = iTextSharp.text.Rectangle;
//using System.Windows.Documents;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Security.Policy;
using System.Threading;
using Azure;
using System.Web.UI.WebControls;

namespace EnviosExpress
{
    public partial class GenerarGuiaMasiva : System.Web.UI.Page

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

        public static int contador = 0;

        public static string ContadorX;
        protected void descargar_Click(object sender, EventArgs e)
        {
            Label2.Text = "hola";
            //contador++;
            String dpi1 = Session["id"].ToString();

            conectado.conectar();
            DataRow rows = conectado.ultimMasv(dpi1).Rows[0];
            String fechahora = Convert.ToString(Convert.ToString(rows["fechahora"]));
            //String fechahora = Convert.ToString(fechahora1);
            //Label2.Text = "hola";
            //DataRow rowss = conectado.consultaUsuarioDPI(dpi1).Rows[0];
            //String Nombre = Convert.ToString(Convert.ToString(rowss["primerNombre"]));
            ///String Apellido = Convert.ToString(Convert.ToString(rowss["primerApellido"]));
            //String negocio = Convert.ToString(Convert.ToString(rowss["nombrenegocio"]));
            //String dpi = Nombre + " " + Apellido;




            DataTable dt = new DataTable();
            Document document = new Document();
            document.SetPageSize(new Rectangle(272.126f, 272.126f));
            document.SetMargins(15f, 15f, 15f, 8f);

            PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);



            //dt = conectado.ultimosMasv(fechahora);
            document.Open();

            string pathImage = fechahora;
            // string contador2 = Convert.ToString(CONTADORT);
            //String ContadorY = Convert.ToString(contador);


            //writer.PageEvent = new PdfWriterEvents(pathImage, fechahora, dpi, negocio); //ContadorY);
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




            string connect = "workstation id=EnviosExpress.mssql.somee.com;packet size=4096;user id=EnviosExpress;pwd=Envios3228@;data source=EnviosExpress.mssql.somee.com;persist security info=False;initial catalog=EnviosExpress;TrustServerCertificate=True";
            //string connect = "Data Source=DESKTOP-KNTJ3BG\\SQLEXPRESS;DATABASE=EnviosExpress;Integrated security=true";

            using (SqlConnection conn = new SqlConnection(connect))

            {

                string query = "Select a.recibido,a.cantidadadepositar, e.direccion as dirusuario, a.idusuario, YEAR(a.fecha) as fecha,MONTH(a.fecha) as fecha1,DAY(a.fecha) as fecha2,a.remitente,e.telefono as telcliente, a.idpaquete,a.destinatario,REPLACE(REPLACE(REPLACE(SUBSTRING(a.direccion,1,160),CHAR(9),''),CHAR(10),','),CHAR(13),'') as direccion,b.iddepartamento as departamento,c.idmunicipio as municipio,d.idzona as zona,d.monto as valorenvio, a.telefono2,a.direccion2,a.destinatario2,a.telefono,a.peso,a.monto,a.tipo,b.nombre as dep,c.nombre as mun ,d.nombre as zon from paquete a left join usuario e on a.idusuario = e.idusuario left join departamento b on a.iddepartamento = b.iddepartamento left join municipio c on a.idmunicipio = c.idmunicipio left join zona d on a.idzona = d.idzona   where a.fechahora='" + fechahora + "'";
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
                        ///   for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            document.NewPage();
                            //document.Add(new Section);
                            document.Add(new Paragraph(6, "   " + (rdr[9].ToString()), titulo));

                            QRCodeEncoder encoder = new QRCodeEncoder(); ;
                            Bitmap img = encoder.Encode((rdr[9].ToString()));
                            System.Drawing.Image QR = (System.Drawing.Image)img;

                            using (MemoryStream ms = new MemoryStream())
                            {
                                QR.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                byte[] imageBytes = ms.ToArray();
                                imgCtrl.Src = "data:image/gif;base64," + Convert.ToBase64String(imageBytes);
                                imgCtrl.Height = 250;
                                imgCtrl.Width = 250;

                                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(imageBytes);

                                iTextSharp.text.Image logo1 = iTextSharp.text.Image.GetInstance("http://www.enviosexpress.somee.com/Imagenes/enviosexpress.png");
                                logo1.ScaleAbsoluteWidth(100);
                                logo1.ScaleAbsoluteHeight(100);
                                logo1.SetAbsolutePosition(160, 160);
                                document.Add(logo);
                                document.Add(logo1);

                                conectado.desconectar();
                            }

                            document.Add(new Phrase(6, "Número de Guía: " + (rdr[9].ToString()), subtitulo2));
                            document.Add(new Phrase(12, "       Remitente:", subtitulo3));
                            document.Add(new Phrase(12, (rdr[7].ToString()), texto));
                            document.Add(new Chunk("\n"));
                            document.Add(new Phrase(12, "Destinatario:", subtitulo));
                            document.Add(new Phrase(12, "                           Teléfono:", subtitulo3));
                            document.Add(new Phrase(12, (rdr[8].ToString()), texto));
                            document.Add(new Paragraph(12, (rdr[10].ToString())));
                            document.Add(new Phrase(12, "Teléfono:", subtitulo));
                            document.Add(new Phrase(12, "                                 Peso:", subtitulo3));
                            document.Add(new Phrase(12, (rdr[20].ToString()), texto));
                            document.Add(new Paragraph(12, (rdr[19].ToString())));
                            document.Add(new Phrase(12, "Direccion: ", subtitulo));
                            document.Add(new Phrase(12, "                             Tipo:", subtitulo3));
                            document.Add(new Phrase(12, (rdr[22].ToString()), texto));
                            document.Add(new Paragraph(12, (rdr[11].ToString())));
                            document.Add(new Paragraph(12, (rdr[23].ToString()) + "," + (rdr[24].ToString()) + "," + (rdr[25].ToString())));
                            document.Add(new Phrase(12, "Monto:Q" + (rdr[21].ToString()), subtitulo));
                            document.Add(new Phrase(12, "                              " + (rdr[6].ToString()) + "/" + (rdr[5].ToString()) + "/" + (rdr[4].ToString())));

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
                Response.AddHeader("content-disposition", "attachment;filename=" + fechahora + ".pdf");
                HttpContext.Current.Response.Write(fechahora);
                Response.Flush();
                Response.End();
                conectado.desconectar();

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



                iTextSharp.text.Image logo1 = iTextSharp.text.Image.GetInstance("http://www.enviosexpress.somee.com/Imagenes/enviosexpress.png");
                logo1.ScaleAbsoluteWidth(100);
                logo1.ScaleAbsoluteHeight(100);
                logo1.SetAbsolutePosition(600, 500);
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
        protected void Button3_Click(object sender, EventArgs e)
        {

            Response.Redirect("Menu.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            String dpi = Session["id"].ToString();
            string ruta_carpeta = HttpContext.Current.Server.MapPath("~/Temporal");

            if (!Directory.Exists(ruta_carpeta))
            {
                Directory.CreateDirectory(ruta_carpeta);
            }

            if (FileUpload1.HasFile)
            {

                //GUARDAMOS EL ARCHIVO EN LOCAL

                var ruta_guardado = Path.Combine(ruta_carpeta, FileUpload1.FileName);
            
                FileUpload1.SaveAs(ruta_guardado);


                IWorkbook MiExcel = null;
                FileStream fs = new FileStream(ruta_guardado, FileMode.Open, FileAccess.Read);

                if (Path.GetExtension(ruta_guardado) == ".xlsm")
                    MiExcel = new XSSFWorkbook(fs);
                else
                    MiExcel = new HSSFWorkbook(fs);
                //    DataTable dt = MiExcel;

                ISheet hoja = MiExcel.GetSheetAt(0);

                DataTable table = new DataTable();
                table.Columns.Add("idusuario", typeof(int));
                table.Columns.Add("Remitente", typeof(string));
                table.Columns.Add("Destinatario", typeof(string));
                table.Columns.Add("Departamento", typeof(string));
                table.Columns.Add("Municipio", typeof(string));
                table.Columns.Add("Zona", typeof(string));
                table.Columns.Add("Direccion", typeof(string));
                table.Columns.Add("Telefono", typeof(string));
                table.Columns.Add("Peso", typeof(string));
                table.Columns.Add("Monto", typeof(int));
                //table.Columns.Add("Fecha", typeof(DateTime));


                if (hoja != null)
                {

                    int cantidadfilas = hoja.LastRowNum;

                    for (int i = 1; i <= cantidadfilas; i++)
                    {
                        IRow fila = hoja.GetRow(i);


                        if (fila != null)
                            table.Rows.Add(
                                (dpi),
                                fila.GetCell(0, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(0, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                                fila.GetCell(1, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(1, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                                fila.GetCell(2, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(2, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                                fila.GetCell(3, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(3, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                                fila.GetCell(4, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(4, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                                fila.GetCell(5, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(5, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                                  // fila.GetCell(6, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(6, MissingCellPolicy.RETURN_NULL_AND_BLANK).DateCellValue.ToString("dd/MM/yyyy", new CultureInfo("es-ES")) : "",
                                  fila.GetCell(6, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(6, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                                 fila.GetCell(7, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(7, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                                 fila.GetCell(8, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(8, MissingCellPolicy.RETURN_NULL_AND_BLANK).NumericCellValue.ToString() : ""
                                );
                    }

                }



                int resultado = cargarEnSQL(table);

                if (resultado == 1)
                {
                    GridView1.DataSource = table;
                    GridView1.DataBind();
                    descargar.Visible = true;
                    Labeldescargar.Visible = true;
                }
                else
                {
                    Response.Write("<script>alert('ERROR DE CARGA: Corriga datos o contactese con soporte!')</script>");
                }
                conectado.desconectar();
            }

            else
            {Response.Write("<script>alert('ERROR No se ha cargado ningun archivo')</script>");
        }
}
        public int cargarEnSQL(DataTable tabla)
        {
            int resultado = 0;
            //int idpaquete;
            try
            {
                //NOS CONECTAMOS CON LA BASE DE DATOS
                using (SqlConnection conn = new SqlConnection("workstation id=EnviosExpress.mssql.somee.com;packet size=4096;user id=EnviosExpress;pwd=Envios3228@;data source=EnviosExpress.mssql.somee.com;persist security info=False;initial catalog=EnviosExpress;TrustServerCertificate=True"))
                //using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-KNTJ3BG\\SQLEXPRESS;DATABASE=EnviosExpress;Integrated security=true"))
                {
                    SqlCommand cmd = new SqlCommand("usp_cargarInformacion", conn);
                    cmd.Parameters.Add("EstructuraCarga", SqlDbType.Structured).Value = tabla;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    // cmd.Parameters.Add("idpaquete", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    // idpaquete = Convert.ToInt32(cmd.Parameters["idpaquete"].Value);
                    resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    conectado.conectar();

                    //String idpaquete1= Convert.ToString(idpaquete);
                    //GridView3.DataSource = conectado.ultim(idpaquete1);//obtener datos de la guia
                    //GridView3.DataBind();
                }
            }

            catch (Exception ex)
            {

                string mensaje = ex.Message.ToString();
                resultado = 0;
            }

            return resultado;
        }




        public class informacion
        {
            public string Remitente { get; set; }
            public string Destinatario { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public string Peso { get; set; }
            public string Monto { get; set; }
            public string valorenvio { get; set; }
            public string Tipo { get; set; }
            public string Fecha { get; set; }
            public string Departamento { get; set; }
            public string Municipio { get; set; }
            public string Zona { get; set; }
            public string idusuario { get; set; }

        }
    }
}