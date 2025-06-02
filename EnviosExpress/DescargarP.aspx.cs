using iTextSharp.text;
using iTextSharp.text.pdf;
using MessagingToolkit.QRCode.Codec;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using Font = iTextSharp.text.Font;
using Rectangle = iTextSharp.text.Rectangle;

namespace EnviosExpress
{
    public partial class DescargarP : System.Web.UI.Page
    {
        Conectar conectado = new Conectar();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargar();
        }
        public DataTable cargar()
        {
            conectado.conectar();
            DataTable dt = new DataTable();
            dt = conectado.descargarguia2();

            guia12.Visible = true;
            direccion12.Visible = true;
            telefono12.Visible = true;
            peso12.Visible = true;
            monto12.Visible = true;
            destinatario12.Visible = true;
            tipo12.Visible = true;
            imgCtrl.Visible = true;

            guia11.Text = Request.QueryString["id"].ToString();
            string idpaquete = guia11.Text;
            conectado.conectar();
            
            DataRow rows = conectado.Guia2(idpaquete).Rows[0];
            String guia = Convert.ToString(Convert.ToString(rows["idpaquete"]));
           // conectado.pendiente(guia);
            String destinatario1 = Convert.ToString(Convert.ToString(rows["destinatario"]));
            String direccion1 = Convert.ToString(Convert.ToString(rows["direccion"]));
            String departamento1 = Convert.ToString(Convert.ToString(rows["dep"]));
            String municipio1 = Convert.ToString(Convert.ToString(rows["mun"]));
            String zona1 = Convert.ToString(Convert.ToString(rows["zon"]));
            String telefono1 = Convert.ToString(Convert.ToString(rows["telefono"]));
            String peso1 = Convert.ToString(Convert.ToString(rows["peso"]));
            String tipo1 = Convert.ToString(Convert.ToString(rows["tipo"]));
            String monto1 = Convert.ToString(Convert.ToString(rows["monto"]));
            String nombrenegocio = Convert.ToString(Convert.ToString(rows["remitente"]));
            String telefono = Convert.ToString(Convert.ToString(rows["telcliente"]));
            String fecha = Convert.ToString(Convert.ToString(rows["fecha"]));
            String fecha1 = Convert.ToString(Convert.ToString(rows["fecha1"]));
            String fecha2 = Convert.ToString(Convert.ToString(rows["fecha2"]));
            guia11.Text = guia;
            guia13.Text = guia;
            destinatario11.Text = destinatario1;
            direccion11.Text = direccion1;
            departamento11.Text = departamento1;
            municipio11.Text = municipio1;
            zona11.Text = zona1;
            telefono11.Text = telefono1;
            peso11.Text = peso1;
            tipo11.Text = tipo1;
            monto11.Text = monto1;
            telefono14.Text = telefono;
            remitente11.Text = nombrenegocio;
            fecha0.Text = fecha;
            fecha11.Text = fecha1;
            fecha22.Text = fecha2;

            QRCodeEncoder encoder = new QRCodeEncoder(); ;
            Bitmap img = encoder.Encode(guia);
            System.Drawing.Image QR = (System.Drawing.Image)img;

            using (MemoryStream ms = new MemoryStream())
            {
                QR.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                imgCtrl.Src = "data:image/gif;base64," + Convert.ToBase64String(imageBytes);
                imgCtrl.Height = 130;
                imgCtrl.Width = 130;

                conectado.desconectar();
            }


            conectado.desconectar();

            return dt;
        }

        protected void btnGenerarPDF_click(object sender, EventArgs e)
        {
            guia12.Visible = true;
            direccion12.Visible = true;
            telefono12.Visible = true;
            peso12.Visible = true;
            monto12.Visible = true;
            destinatario12.Visible = true;
            tipo12.Visible = true;
            imgCtrl.Visible = true;

            guia11.Text = Request.QueryString["id"].ToString();
            string idpaquete = guia11.Text;
            conectado.conectar();
            DataRow rows = conectado.Guia2(idpaquete).Rows[0];
            String guia = Convert.ToString(Convert.ToString(rows["idpaquete"]));
            String destinatario1 = Convert.ToString(Convert.ToString(rows["destinatario"]));
            String direccion1 = Convert.ToString(Convert.ToString(rows["direccion"]));
            String departamento1 = Convert.ToString(Convert.ToString(rows["dep"]));
            String municipio1 = Convert.ToString(Convert.ToString(rows["mun"]));
            String zona1 = Convert.ToString(Convert.ToString(rows["zon"]));
            String telefono1 = Convert.ToString(Convert.ToString(rows["telefono"]));
            String peso1 = Convert.ToString(Convert.ToString(rows["peso"]));
            String tipo1 = Convert.ToString(Convert.ToString(rows["tipo"]));
            String monto1 = Convert.ToString(Convert.ToString(rows["monto"]));
            String nombrenegocio = Convert.ToString(Convert.ToString(rows["remitente"]));
            String telefono = Convert.ToString(Convert.ToString(rows["telcliente"]));
            String fecha = Convert.ToString(Convert.ToString(rows["fecha"]));
            String fecha1 = Convert.ToString(Convert.ToString(rows["fecha1"]));
            String fecha2 = Convert.ToString(Convert.ToString(rows["fecha2"]));
            guia11.Text = guia;
            destinatario11.Text = destinatario1;
            direccion11.Text = direccion1;
            departamento11.Text = departamento1;
            municipio11.Text = municipio1;
            zona11.Text = zona1;
            telefono11.Text = telefono1;
            peso11.Text = peso1;
            tipo11.Text = tipo1;
            monto11.Text = monto1;

            DataTable dt = new DataTable();
            Document document = new Document();
            document.SetPageSize(new Rectangle(272.126f, 272.126f));
            document.SetMargins(15f, 15f, 15f, 8f);
            PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
            dt = cargar();
            if (dt.Rows.Count > 0)
            {
                document.Open();
                Font titulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                Font subtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                Font subtitulo2 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
                Font subtitulo3 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);
                Font texto = FontFactory.GetFont(FontFactory.HELVETICA, 8);

                PdfPTable table = new PdfPTable(dt.Columns.Count);
                document.Add(new Paragraph(6, "   " + guia, titulo));

                QRCodeEncoder encoder = new QRCodeEncoder(); ;
                Bitmap img = encoder.Encode(guia);
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

                document.Add(new Phrase(6, "Número de Guía: " + guia, subtitulo2));
                document.Add(new Phrase(12, "       Remitente:", subtitulo3));
                document.Add(new Phrase(12, nombrenegocio, texto));
                document.Add(new Chunk("\n"));
                document.Add(new Phrase(12, "Destinatario:", subtitulo));
                document.Add(new Phrase(12, "                           Teléfono:", subtitulo3));
                document.Add(new Phrase(12, telefono, texto));
                document.Add(new Paragraph(12, destinatario1));
                document.Add(new Phrase(12, "Teléfono:", subtitulo));
                document.Add(new Phrase(12, "                                 Peso:", subtitulo3));
                document.Add(new Phrase(12, peso1, texto));
                document.Add(new Paragraph(12, telefono1));
                document.Add(new Phrase(12, "Direccion: ", subtitulo));
                document.Add(new Phrase(12, "                             Tipo:", subtitulo3));
                document.Add(new Phrase(12, tipo1, texto));
                document.Add(new Paragraph(12, direccion1));
                document.Add(new Paragraph(12, departamento1 + "," + municipio1 + "," + zona1));
                document.Add(new Phrase(12, "Monto:Q" + monto1, subtitulo));
                document.Add(new Phrase(12, "                              " + fecha2 + "/" + fecha1 + "/" + fecha));
            }

            document.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + guia + ".pdf");
            HttpContext.Current.Response.Write(rows);
            Response.Flush();
            Response.End();
            conectado.desconectar();

        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GenerarGuiaP.aspx");
        }

        protected void btnrecolectar10_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPrincipal.aspx");
        }
    }
}