using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Text;
using System.Web.Http;

using api.colegio.Models;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
//using OfficeOpenXml;
//using OfficeOpenXml.Style;
using System.Drawing;
using Font = iTextSharp.text.Font;
using System.Net.Http.Headers;

namespace api.colegio.Controllers
{
    public class NotaPDFController : ApiController
    {
        [Route("api/Nota/{id}")]
        [HttpGet]
        public HttpResponseMessage Tratamiento(int id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var psicoterapia = db.pac_psicoterapia.FirstOrDefault(x => x.pac_psico_id == id);

                var hojauso = db.hojausomultiple.FirstOrDefault(x => x.paciente_id == psicoterapia.pac_psico_pac_id);
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
                iTextSharp.text.Font font3 = new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD);
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
                    float[] valores = new float[2] { 12, 30 };
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


                    Paragraph fecha = new Paragraph("FECHA Y HORA: " + psicoterapia.pac_psico_fecha + "                                                                                                                                                     " + psicoterapia.pac_psico_desc, font3);
                    fecha.Alignment = Element.ALIGN_LEFT;

                    Paragraph desc = new Paragraph("DIAGNOSTICO O DESCRIPCION DEL PROBLEMA.", font3);
                    desc.Alignment = Element.ALIGN_LEFT;

                    Paragraph resdesc = new Paragraph(psicoterapia.pac_psico_texto, font);
                    resdesc.Alignment = Element.ALIGN_LEFT;

                    Paragraph obj = new Paragraph("OBJETIVO DE INTERVENCIÓN.", font3);
                    obj.Alignment = Element.ALIGN_LEFT;

                    Paragraph objres = new Paragraph(psicoterapia.pac_psico_intervencion, font);
                    objres.Alignment = Element.ALIGN_LEFT;

                    Paragraph tecnicas = new Paragraph("TÉCNICAS O PROCEDIMIENTO DE INTERVENCIÓN.", font3);
                    tecnicas.Alignment = Element.ALIGN_LEFT;

                    Paragraph tecnicares = new Paragraph(psicoterapia.pac_psico_tecnicas, font);
                    tecnicares.Alignment = Element.ALIGN_LEFT;

                    Paragraph res = new Paragraph("RESULTADOS.", font3);
                    res.Alignment = Element.ALIGN_LEFT;

                    Paragraph resp = new Paragraph(psicoterapia.pac_psico_resultados, font);
                    resp.Alignment = Element.ALIGN_LEFT;

                    Paragraph reco = new Paragraph("RECOMENDACIONES.", font3);
                    reco.Alignment = Element.ALIGN_LEFT;

                    Paragraph recores = new Paragraph(psicoterapia.pac_psico_recomenda, font);
                    recores.Alignment = Element.ALIGN_LEFT;

                    Paragraph observ = new Paragraph("OBSERVACIONES.", font3);
                    observ.Alignment = Element.ALIGN_LEFT;

                    Paragraph observres = new Paragraph(psicoterapia.pac_psico_observaciones, font);
                    observres.Alignment = Element.ALIGN_LEFT;

              


                    //Paragraph fecha = new Paragraph("FECHA Y HORA: " + psicoterapia.pac_psico_fecha + "                                                                " + psicoterapia.pac_psico_desc, font3);
                    //fecha.Alignment = Element.ALIGN_LEFT;


                    //Paragraph fecha = new Paragraph("FECHA Y HORA: " + psicoterapia.pac_psico_fecha + "                                                                " + psicoterapia.pac_psico_desc, font3);

                    //Paragraph fecha = new Paragraph("FECHA Y HORA: " + psicoterapia.pac_psico_fecha + "                                                                " + psicoterapia.pac_psico_desc, font3);

                    //Paragraph fecha = new Paragraph("FECHA Y HORA: " + psicoterapia.pac_psico_fecha + "                                                                " + psicoterapia.pac_psico_desc, font3);
                    //fecha.Alignment = Element.ALIGN_LEFT;
                    //fecha.Alignment = Element.ALIGN_LEFT;
                    //fecha.Alignment = Element.ALIGN_LEFT;

                    //PdfPTable tabla3 = new PdfPTable(2);
                    //tabla3.WidthPercentage = 100f;
                    //////Asignando los anchos de las columnas
                    //float[] valores3 = new float[2] { 30, 70 };
                    //tabla3.SetWidths(valores3);



                    //PdfPTable tabla4 = new PdfPTable(1);
                    //tabla4.WidthPercentage = 100f;
                    //////Asignando los anchos de las columnas
                    //float[] valores4 = new float[1] { 100 };
                    //tabla4.SetWidths(valores4);
                    //PdfPCell fec = new PdfPCell(new Phrase("FECHA Y HORA: "+psicoterapia.pac_psico_fecha+"                                                                "+psicoterapia.pac_psico_desc, font3));
                    //fec.BackgroundColor = new BaseColor(240, 240, 240);
                    //tabla4.AddCell(fec);

                    //PdfPCell desc = new PdfPCell(new Phrase("DIAGNOSTICO O DESCRIPCION DEL PROBLEMA.", font3));
                    //desc.BackgroundColor = new BaseColor(240, 240, 240);
                    //tabla4.AddCell(desc);

                    //PdfPCell resdesc = new PdfPCell(new Phrase(psicoterapia.pac_psico_texto, font));
                    //resdesc.BackgroundColor = new BaseColor(240, 240, 240);
                    //tabla4.AddCell(resdesc);

                    //PdfPCell obj = new PdfPCell(new Phrase("OBJETIVO DE INTERVENCIÓN.", font3));
                    //obj.BackgroundColor = new BaseColor(240, 240, 240);
                    //tabla4.AddCell(obj);

                    //PdfPCell objres = new PdfPCell(new Phrase(psicoterapia.pac_psico_intervencion, font));
                    //objres.BackgroundColor = new BaseColor(240, 240, 240);
                    //tabla4.AddCell(objres);

                    //PdfPCell tecnicas = new PdfPCell(new Phrase("TÉCNICAS O PROCEDIMIENTO DE INTERVENCIÓN.", font3));
                    //tecnicas.BackgroundColor = new BaseColor(240, 240, 240);
                    //tabla4.AddCell(tecnicas);

                    //PdfPCell tecnicasres = new PdfPCell(new Phrase(psicoterapia.pac_psico_tecnicas, font));
                    //tecnicasres.BackgroundColor = new BaseColor(240, 240, 240);
                    //tabla4.AddCell(tecnicasres);


                    //PdfPCell res = new PdfPCell(new Phrase("RESULTADOS.", font3));
                    //res.BackgroundColor = new BaseColor(240, 240, 240);
                    //tabla4.AddCell(res);

                    //PdfPCell resp = new PdfPCell(new Phrase(psicoterapia.pac_psico_resultados, font));
                    //resp.BackgroundColor = new BaseColor(240, 240, 240);
                    //tabla4.AddCell(resp);

                    //PdfPCell reco = new PdfPCell(new Phrase("RECOMENDACIONES.", font3));
                    //reco.BackgroundColor = new BaseColor(240, 240, 240);
                    //tabla4.AddCell(reco);

                    //PdfPCell recores = new PdfPCell(new Phrase(psicoterapia.pac_psico_recomenda, font));
                    //recores.BackgroundColor = new BaseColor(240, 240, 240);
                    //tabla4.AddCell(recores);

                    //PdfPCell observ = new PdfPCell(new Phrase("OBSERVACIONES.", font3));
                    //observ.BackgroundColor = new BaseColor(240, 240, 240);
                    //tabla4.AddCell(observ);

                    //PdfPCell observres = new PdfPCell(new Phrase(psicoterapia.pac_psico_observaciones, font));
                    //observres.BackgroundColor = new BaseColor(240, 240, 240);
                    //tabla4.AddCell(observres);





                    Paragraph p = new Paragraph();
                    p.Add(new Chunk(image1, 0, -20));
                    p.Add(new Phrase("  NOTA ", font2));
                    p.Add(new Phrase("DE ATENCIÓN PSICOLOGICA             ", font2));
                    p.Alignment = Element.ALIGN_CENTER;

                    Paragraph nompsi = new Paragraph(psicologo + " " + cedula, font);
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
                    doc.Add(fecha);
                    doc.Add(espacio);
                    doc.Add(desc);
                    doc.Add(resdesc);
                    doc.Add(espacio);
                    doc.Add(obj);
                    doc.Add(objres);
                    doc.Add(espacio);
                    doc.Add(tecnicas);
                    doc.Add(tecnicares);
                    doc.Add(espacio);
                    doc.Add(res);
                    doc.Add(resp);
                    doc.Add(espacio);
                    doc.Add(reco);
                    doc.Add(recores);
                    doc.Add(espacio);
                    doc.Add(observ);
                    doc.Add(observres);
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
                    string filename = nombre.Replace(" ", "_");
                    string filenamedoc = filename + ".pdf";
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
                    {
                        FileName = filenamedoc
                    };

                    return response;
                }

            }

        }
    }
}
