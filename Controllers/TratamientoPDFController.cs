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
using System.Drawing;
using Font = iTextSharp.text.Font;
using System.Net.Http.Headers;


namespace api.colegio.Controllers
{
    public class TratamientoPDFController : ApiController
    {
        [Route("api/Tratamiento/{id}")]
        [HttpGet]
        public HttpResponseMessage Tratamiento(int id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var hojauso = db.hojausomultiple.FirstOrDefault(x => x.paciente_id == id);
                //Variables grlesmpaciente
                string nombre = "";
                string genero = "";
                string edad = "";
                string telefono = "";
                string ocupacion = "";
                string edocivil = "";

                string psicologo = "";
                string cedula = "";
                string modalidad = "";

                if (hojauso != null)
                {
                    nombre = hojauso.paciente_nombre;
                    genero = hojauso.sexo_descrip;
                    edad = hojauso.paciente_edad.ToString();
                    telefono = hojauso.paciente_telefono;
                    ocupacion = hojauso.paciente_ocupacion;
                    edocivil = hojauso.edocivil_descrip;
                    psicologo = hojauso.usuario_nombre;
                    cedula = hojauso.usuario_cedula;
                    modalidad = hojauso.modalidad_descrip;
                }

                List<vmetodos_evaluacion> evaluaciones = null;
                evaluaciones = db.vmetodos_evaluacion.Where(x => x.metodo_pac_id == id).OrderBy(x => x.evaluacion).ToList();

                List<pac_psicoterapia> sessiones = null;
                sessiones = db.pac_psicoterapia.Where(x => x.pac_psico_pac_id == id).OrderBy(x => x.pac_psico_desc).ToList();

                List<evaluacion_resultado> resultados = null;
                resultados = db.evaluacion_resultado.Where(x => x.evaluacion_pac_id == id).OrderBy(x => x.evaluacion_resultado1).ToList();

                string altadesc = "";
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

                    PdfPCell c7 = new PdfPCell(new Phrase("TELEFONO:", font));
                    c7.BackgroundColor = new BaseColor(240, 240, 240);
                    c7.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla.AddCell(c7);

                    PdfPCell c8 = new PdfPCell(new Phrase(telefono, font));
                    c8.BackgroundColor = new BaseColor(240, 240, 240);
                    c8.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla.AddCell(c8);
                    //tabla.Alignment = Element.ALIGN_LEFT;

                    PdfPCell c9 = new PdfPCell(new Phrase("OCUPACIÓN:", font));
                    c9.BackgroundColor = new BaseColor(240, 240, 240);
                    c9.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla.AddCell(c9);

                    PdfPCell c10 = new PdfPCell(new Phrase(ocupacion, font));
                    c10.BackgroundColor = new BaseColor(240, 240, 240);
                    c10.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla.AddCell(c10);

                    PdfPCell c11 = new PdfPCell(new Phrase("ESTADO CIVIL:", font));
                    c11.BackgroundColor = new BaseColor(240, 240, 240);
                    c11.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla.AddCell(c11);

                    PdfPCell c12 = new PdfPCell(new Phrase(edocivil, font));
                    c12.BackgroundColor = new BaseColor(240, 240, 240);
                    c12.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla.AddCell(c12);

                    PdfPTable tabla2 = new PdfPTable(2);
                    tabla2.WidthPercentage = 100f;
                    ////Asignando los anchos de las columnas
                    float[] valores2 = new float[2] { 50, 50 };
                    tabla2.SetWidths(valores2);
                    PdfPCell t1 = new PdfPCell(new Phrase("METODOS DE EVALUACIÓN", font3));
                    t1.BackgroundColor = new BaseColor(240, 240, 240);
                    t1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(t1);

                    PdfPCell t2 = new PdfPCell(new Phrase("RESULTADOS", font3));
                    t2.BackgroundColor = new BaseColor(240, 240, 240);
                    t2.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(t2);

                    if (evaluaciones.Count() > 0) {

                        foreach (var ele in evaluaciones)
                        {
                            PdfPCell t4 = new PdfPCell(new Phrase(ele.evaluacion, font));
                            t4.BackgroundColor = new BaseColor(240, 240, 240);
                            t4.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            tabla2.AddCell(t4);

                            PdfPCell t5 = new PdfPCell(new Phrase(ele.resultado, font));
                            t5.BackgroundColor = new BaseColor(240, 240, 240);
                            t5.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            tabla2.AddCell(t5);
                        }
                    }

                    PdfPTable tabla3 = new PdfPTable(2);
                    tabla3.WidthPercentage = 100f;
                    ////Asignando los anchos de las columnas
                    float[] valores3 = new float[2] { 30, 70 };
                    tabla3.SetWidths(valores3);

                    var diagnostico = db.infodiagnostico.Where(x => x.pac_diag_pac_id == id).Count();
                    if (diagnostico > 0)
                    {
                        var diagnosticoData = db.infodiagnostico.FirstOrDefault(x => x.pac_diag_pac_id == id);
                        if (diagnosticoData != null)
                        {
                            string primarioConv = UppercaseFirst(diagnosticoData.diag_descrip);
                            string altaDescConv = UppercaseFirst(diagnosticoData.alta_descrip);
                            string ModTeraConv = UppercaseFirst(diagnosticoData.modtera_descrip);
                            altadesc = diagnosticoData.alta_descrip;

                            PdfPCell r1 = new PdfPCell(new Phrase("DIAGNÓSTICO PSICOLOGICO", font3));
                            r1.BackgroundColor = new BaseColor(240, 240, 240);
                            r1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            tabla3.AddCell(r1);

                            PdfPCell r2 = new PdfPCell(new Phrase(diagnosticoData.pac_diag_diagnostico, font));
                            r2.BackgroundColor = new BaseColor(240, 240, 240);
                            r2.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            tabla3.AddCell(r2);

                            PdfPCell r3= new PdfPCell(new Phrase("OBJETIVO INTEGRAL DEL TRATAMIENTO", font3));
                            r3.BackgroundColor = new BaseColor(240, 240, 240);
                            r3.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            tabla3.AddCell(r3);

                            PdfPCell r4 = new PdfPCell(new Phrase(diagnosticoData.pac_diag_obj_integral, font));
                            r4.BackgroundColor = new BaseColor(240, 240, 240);
                            r4.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            tabla3.AddCell(r4);

                            PdfPCell r5 = new PdfPCell(new Phrase("OBJETIVO(S) ESPECIFICO(S)", font3));
                            r5.BackgroundColor = new BaseColor(240, 240, 240);
                            r5.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            tabla3.AddCell(r5);

                            PdfPCell r6 = new PdfPCell(new Phrase(diagnosticoData.pac_diag_obj_especifico, font));
                            r6.BackgroundColor = new BaseColor(240, 240, 240);
                            r6.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            tabla3.AddCell(r6);

                            PdfPCell r7 = new PdfPCell(new Phrase("MODALIDAD DEL TRATAMIENTO", font3));
                            r7.BackgroundColor = new BaseColor(240, 240, 240);
                            r7.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            tabla3.AddCell(r7);

                            PdfPCell r8 = new PdfPCell(new Phrase(modalidad, font));
                            r8.BackgroundColor = new BaseColor(240, 240, 240);
                            r8.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            tabla3.AddCell(r8);

                            PdfPCell r9 = new PdfPCell(new Phrase("MODELO TERAPEUTICO", font3));
                            r9.BackgroundColor = new BaseColor(240, 240, 240);
                            r9.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            tabla3.AddCell(r9);

                            PdfPCell r10 = new PdfPCell(new Phrase(ModTeraConv, font));
                            r10.BackgroundColor = new BaseColor(240, 240, 240);
                            r10.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            tabla3.AddCell(r10);

                        }


                    }
                    string UppercaseFirst(string s)
                    {
                        if (string.IsNullOrEmpty(s))
                        {
                            return string.Empty;
                        }
                        char[] a = s.ToCharArray();
                        a[0] = char.ToUpper(a[0]);
                        return new string(a);
                    }

                    PdfPTable tabla4 = new PdfPTable(1);
                    tabla4.WidthPercentage = 75f;
                    ////Asignando los anchos de las columnas
                    float[] valores4 = new float[1] { 100 };
                    tabla4.SetWidths(valores4);
                    PdfPCell res = new PdfPCell(new Phrase("RESULTADOS", font3));
                    res.BackgroundColor = new BaseColor(240, 240, 240);
                    tabla4.AddCell(res);
                    if (resultados.Count() > 0)
                    {

                        foreach (var ele in resultados)
                        {
                            PdfPCell res1 = new PdfPCell(new Phrase(ele.evaluacion_resultado1, font));
                            res1.BackgroundColor = new BaseColor(240, 240, 240);
                            res1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            tabla4.AddCell(res1);

                      
                        }
                    }

                    Paragraph resumen = new Paragraph("RESUMEN DE INTERVENCION", font3);
                    resumen.Alignment = Element.ALIGN_LEFT;

                    Paragraph consultas = new Paragraph("                              NÚMERO DE CONSULTAS: " + sessiones.Count(), font3);
                    Paragraph motivoalta = new Paragraph("                              MOTIVO DE ALTA: " + altadesc, font3);
                    resumen.Alignment = Element.ALIGN_LEFT;

                    
                    Paragraph p = new Paragraph();
                    p.Add(new Chunk(image1, 0, -20));
                    p.Add(new Phrase("  PLAN DE TRATAMIENTO ", font2));
                    p.Add(new Phrase("DE PSICOLOGIA  CLINICA             ", font2));
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
                    doc.Add(tabla2);
                    doc.Add(espacio);
                    doc.Add(tabla3);
                    doc.Add(espacio);
                    doc.Add(resumen); 
                    doc.Add(espacio);
                    doc.Add(consultas);
                    doc.Add(motivoalta);
                    doc.Add(espacio);
                    doc.Add(tabla4);
                    doc.Add(espacio);
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
