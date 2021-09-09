using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using api.colegio.Models;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
//using OfficeOpenXml;
//using OfficeOpenXml.Style;
using System.Drawing;
using Font = iTextSharp.text.Font;
using System.Net.Http.Headers;
using System.Web.Http.Results;
using System.Configuration;
using System.Collections;
using System.Globalization;
namespace api.colegio.Controllers
{
    public class ClinicoPDFController : ApiController
    {
        [Route("api/Hojausos/{id}")]
        [HttpGet]
        public HttpResponseMessage ReporteClinico(int id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var hojauso = db.hojausomultiple.FirstOrDefault(x => x.paciente_id == id);
                //Variables grlesmpaciente
                string nombre = "";
                string genero = "";
                string edad = "";
                string psicologo = "";
                string cedula = "";

                if (hojauso != null)
                {
                    nombre = hojauso.paciente_nombre;
                    genero = hojauso.sexo_descrip;
                    edad = hojauso.paciente_edad.ToString();
                    psicologo = hojauso.usuario_nombre;
                    cedula = hojauso.usuario_cedula;
                }
                String ruta_img = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "images\\psicologo.png");
                iTextSharp.text.Font font1 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
                iTextSharp.text.Font font2 = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD);
                iTextSharp.text.Font font = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL);
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 40, 40, 42, 35);
                byte[] buffer;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);
                using (MemoryStream stream = new MemoryStream())
                {
                    PdfWriter.GetInstance(doc, stream);
                    doc.Open();
                    iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(ruta_img);
                    image1.ScalePercent(30f);
                    image1.ScaleAbsoluteWidth(40);
                    image1.ScaleAbsoluteHeight(50);
                    //image1.Alignment = Element.ALIGN_LEFT;
                    //doc.Add(image1);
                    Paragraph espacio = new Paragraph(" ");
                    //doc.Add(espacio);

                    PdfPTable tabla = new PdfPTable(2);
                    tabla.WidthPercentage = 40f;
                    ////Asignando los anchos de las columnas
                    float[] valores = new float[2] { 10, 30 };
                    tabla.SetWidths(valores);
                    PdfPCell c1 = new PdfPCell(new Phrase("NOMBRE:", font));
                    c1.BackgroundColor = new BaseColor(240, 240, 240);
                    c1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla.AddCell(c1);

                    PdfPCell c2 = new PdfPCell(new Phrase(nombre, font));
                    c2.BackgroundColor = new BaseColor(240, 240, 240);
                    c2.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla.AddCell(c2);

                    PdfPCell c3 = new PdfPCell(new Phrase("GENERO:", font));
                    c3.BackgroundColor = new BaseColor(240, 240, 240);
                    c3.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla.AddCell(c3);

                    PdfPCell c4 = new PdfPCell(new Phrase(genero, font));
                    c4.BackgroundColor = new BaseColor(240, 240, 240);
                    c4.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla.AddCell(c4);

                    PdfPCell c5 = new PdfPCell(new Phrase("EDAD:", font));
                    c5.BackgroundColor = new BaseColor(240, 240, 240);
                    c5.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla.AddCell(c5);

                    PdfPCell c6 = new PdfPCell(new Phrase(edad, font));
                    c6.BackgroundColor = new BaseColor(240, 240, 240);
                    c6.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla.AddCell(c6);
                    //tabla.Alignment = Element.ALIGN_LEFT;


                    PdfPTable tabla2 = new PdfPTable(1);
                    tabla2.WidthPercentage = 100f;
                    ////Asignando los anchos de las columnas
                    float[] valores2 = new float[1] { 100 };
                    tabla2.SetWidths(valores2);
                    PdfPCell t1 = new PdfPCell(new Phrase(" "));
                    t1.FixedHeight = 500f;
                    tabla2.AddCell(t1);

           

                    Paragraph p = new Paragraph();
                    p.Add(new Chunk(image1, 0, -20));
                    p.Add(new Phrase("  HOJA DE USOS MULTIPLES ", font2));
                    p.Add(new Phrase("DE PSICOLOGIA               ", font2));
                    p.Alignment = Element.ALIGN_CENTER;

                    Paragraph nompsi = new Paragraph(psicologo+" "+cedula,font);
                    nompsi.Alignment = Element.ALIGN_CENTER;

                    Paragraph linea = new Paragraph("_________________________________________", font);
                    linea.Alignment = Element.ALIGN_CENTER;

                    Paragraph firma = new Paragraph("NOMBRE, CÉDULA Y FIRMA DEL PSICÓLOGO", font);
                    firma.Alignment = Element.ALIGN_CENTER;



                    doc.Add(p);
                    doc.Add(espacio);
                    doc.Add(espacio);
                    doc.Add(tabla);
                    doc.Add(espacio);
                    doc.Add(espacio);
                    doc.Add(tabla2);
                    doc.Add(espacio);
                    doc.Add(espacio);
                    doc.Add(nompsi);
                    doc.Add(linea);
                    doc.Add(firma);




                    doc.Close();
                    buffer = stream.ToArray();
                    var contentLength = buffer.Length;

                    var statuscode = HttpStatusCode.OK;
                    response = Request.CreateResponse(statuscode);
                    response.Content = new StreamContent(new MemoryStream(buffer));
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                    response.Content.Headers.ContentLength = contentLength;
                    //ContentDispositionHeaderValue contentDisposition = null;
                    string filename = nombre.Replace(" ", "_");
                    string filenamedoc = filename + ".pdf";
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
                    {
                        FileName = filenamedoc
                    };
                    //if (ContentDispositionHeaderValue.TryParse("inline; filename=" + filenamedoc, out contentDisposition))
                    //{
                    //    response.Content.Headers.ContentDisposition = contentDisposition;
                    //}
                    //else
                    //{
                    //    //var statuscode = HttpStatusCode.NotFound;
                    //    // var message = String.Format("Unable to find file. file \"{0}\" may not exist.");
                    //    // var responseData = responseDataFactory.CreateWithOnlyMetadata(statuscode, message);
                    //    response = Request.CreateResponse((HttpStatusCode.NotFound));
                    //}

                    return response;
                }

            }

        }
    }
}
    
