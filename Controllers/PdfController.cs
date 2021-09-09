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
    public class PdfController : ApiController
    {

        [Route("api/ReportePDF/{id}")]
        [HttpGet]
        public HttpResponseMessage ReporteSol(int id)
        {

            //List<ConcursoPlazasCLS> listaEmpleado = null;

            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                db.Configuration.LazyLoadingEnabled = false;
            
                var infogeneral = db.infogeneral.FirstOrDefault(x => x.paciente_id == id);
                //Variables grlesmpaciente
                string nombre = "";
                string direccion = "";
                string ocupacion = "";
                string fnac = "";
                string fing = "";
                string genero = "";
                string edad = "";
                string edocivil = "";
                string telefono = "";
                string telefono_eme = "";
                string escolaridad = "";
                string edo = "";
                string mun = "";
                string edo_res = "";
                string mun_res = "";
                string mod = "";
                string estatus = "";

                //desc paciente
                string aspecto = "";
                string vestimenta = "";
                string porte = "";
                string movimientos = "";
                string afecto = "";

                //Motivo Cons
                string problema = "";
                string historia = "";
                string referencia = "";
                string experiencia = "";

                //Situacion actual
                string dia = "";
                string ocaciones = "";

                //Constelacion fam
                string observaciones = "";
                string antecedentes = "";
                string descripcion = "";
                string hermanos = "";
                string rivalidades = "";
                string papel = "";
                string uniones = "";
                string normas = "";
                string cambios = "";

                //recuerdos tempranos
                string recuerdo = "";

                //historia personal
                string embarazo = "";
                string inicio = "";
                string infancia = "";
                string ninez = "";
                string adolecencia = "";
                string adulta = "";
                string avanzada = "";
                string alimentacion = "";
                string sueno = "";
                string enfermedades = "";
                string lesiones = "";
                string opinion = "";

                //Escolaridad
                string primaria = "";
                string secundaria = "";
                string preparatoria = "";
                string universidad = "";
                string otra = "";
                string relacion = "";
                string rendimiento = "";
                string cambio = "";
                string evaluacion = "";

                //Diversiones e intereses
                string lectura = "";
                string practicas = "";
                string pertenencia = "";

                //Ajustes sociales
                string relacionesint = "";
                string amistades = "";
                string sentir = "";
                string novios = "";

                //Desarrollo sexual
                string nociones = "";
                string contacto = "";
                string interes = "";
                string mast = "";
                string homo = "";
                string relpre = "";

                //Datos Maritales
                string noviazgo = "";
                string expectativas = "";
                string descon = "";
                string eventos = "";
                string hijos = "";
                string interaccion = "";
                string familia = "";

                //Desc si mismo
                string afuera = "";
                string demas = "";
                string preocupaciones = "";
                string metas = "";
                string sido = "";
                string crisis = "";
                string triunfo = "";
                string problemas = "";

                //Estado mental
                string estadocon = "";
                string orientacion = "";
                string afectividad = "";
                string asociaciones = "";
                string contenido = "";
                string percepcion = "";
                string funcionamiento = "";
                string juicio = "";
                string insight = "";
                string madurez = "";

                //Diagnostico
                string cognitivo = "";
                string psicometrico = "";
                string diagnostico_ = "";
                string primario = "";
                string primarioConv = "";
                string especifico = "";
                string pronostico = "";

                if (infogeneral != null)
                {
                    nombre = infogeneral.paciente_nombre;
                    direccion = infogeneral.paciente_direccion;
                    ocupacion = infogeneral.paciente_ocupacion;
                    fnac = infogeneral.paciente_fec_nac.ToString();
                    fing = infogeneral.paciente_fec_ing.ToString();
                    genero = infogeneral.sexo_descrip;
                    edad = infogeneral.paciente_edad.ToString();
                    edocivil = infogeneral.edocivil_descrip;
                    telefono = infogeneral.paciente_telefono;
                    telefono_eme = infogeneral.paciente_telefono_eme;
                    escolaridad = infogeneral.escolar_descrip;
                    edo = infogeneral.desc_edo;
                    mun = infogeneral.desc_mun;
                    edo_res = infogeneral.estado_res;
                    mun_res = infogeneral.municipio_res;
                    mod = infogeneral.modalidad_descrip;
                    estatus = infogeneral.estatus_descrip;
                }
                //Consultas
                var descPaciente = db.pac_descrip.Where(x => x.pac_paciente_id == id).Count();
                if (descPaciente > 0)
                {
                    var descPacienteData = db.pac_descrip.FirstOrDefault(x => x.pac_paciente_id == id);
                    aspecto = descPacienteData.pac_desc_aspectos;
                    vestimenta = descPacienteData.pac_desc_vestimenta;
                    porte = descPacienteData.pac_desc_porte;
                    movimientos = descPacienteData.pac_desc_movimientos;
                    afecto = descPacienteData.pac_desc_afecto;
                }
                var motivocons = db.pac_consulta.Where(x => x.pac_cons_pac_id == id).Count();
                if (motivocons > 0)
                {
                    var motivoconsData = db.pac_consulta.FirstOrDefault(x => x.pac_cons_pac_id == id);
                    if (motivoconsData != null)
                    {
                        problema = motivoconsData.pac_cons_problema;
                        historia = motivoconsData.pac_cons_historia;
                        referencia = motivoconsData.pac_cons_referencia;
                        experiencia = motivoconsData.pac_cons_experiencia;
                    }

                }

                var situacion = db.pac_situacion_act.Where(x => x.pac_situacion_pac_id == id).Count();
                if (situacion > 0)
                {
                    var situacionData = db.pac_situacion_act.FirstOrDefault(x => x.pac_situacion_pac_id == id);
                    if (situacionData != null)
                    {
                        dia = situacionData.pac_situacion_dia;
                        ocaciones = situacionData.pac_situacion_esp;
                    }


                }
                var constelacion = db.pac_constelacion_fam.Where(x => x.pac_conste_paciene_id == id).Count();
                if (constelacion > 0)
                {
                    var constelacionData = db.pac_constelacion_fam.FirstOrDefault(x => x.pac_conste_paciene_id == id);
                    if (constelacionData != null)
                    {
                        observaciones = constelacionData.pac_conste_texto;
                        antecedentes = constelacionData.pac_conste_antecedentes;
                        descripcion = constelacionData.pac_conste_desc_padre_madre;
                        hermanos = constelacionData.pac_conste_hermanos;
                        rivalidades = constelacionData.pac_conste_rivalidades;
                        papel = constelacionData.pac_conste_papel_fam;
                        uniones = constelacionData.pac_conste_uniones;
                        normas = constelacionData.pac_conste_normas;
                        cambios = constelacionData.pac_conste_cambios;
                    }

                }
                var recuerdos = db.pac_recuerdos_tempranos.Where(x => x.pac_recuerdos_pac_id == id).Count();
                if (recuerdos > 0)
                {
                    var recuerdoseData = db.pac_recuerdos_tempranos.FirstOrDefault(x => x.pac_recuerdos_pac_id == id);
                    if (recuerdoseData != null)
                    {
                        recuerdo = recuerdoseData.pac_recuerdos_temp;

                    }

                }
                var historiaPer = db.pac_historia_per.Where(x => x.pac_hist_pac_id == id).Count();
                if (historiaPer > 0)
                {
                    var historiaPereData = db.pac_historia_per.FirstOrDefault(x => x.pac_hist_pac_id == id);
                    if (historiaPereData != null)
                    {
                        embarazo = historiaPereData.pac_hist_embarazo;
                        inicio = historiaPereData.pac_hist_inicio;
                        infancia = historiaPereData.pac_hist_infancia;
                        ninez = historiaPereData.pac_hist_nines_re;
                        adolecencia = historiaPereData.pac_hist_adolecencia;
                        adulta = historiaPereData.pac_hist_edad_ad;
                        avanzada = historiaPereData.pac_hist_edad_av;
                        alimentacion = historiaPereData.pac_hist_alimentacion;
                        sueno = historiaPereData.pac_hist_sueno;
                        enfermedades = historiaPereData.pac_hist_enfermedades;
                        lesiones = historiaPereData.pac_hist_lesiones;
                        opinion = historiaPereData.pac_hist_salud_act;
                    }

                }
                var escolar = db.pac_escolaridad.Where(x => x.pac_escolaridad_pac_id == id).Count();
                if (escolar > 0)
                {
                    var escolarData = db.pac_escolaridad.FirstOrDefault(x => x.pac_escolaridad_pac_id == id);
                    if (escolarData != null)
                    {
                        primaria = escolarData.pac_escolaridad_primaria;
                        secundaria = escolarData.pac_escolaridad_secundaria;
                        preparatoria = escolarData.pac_escolaridad_preparatoria;
                        universidad = escolarData.pac_escolaridad_universidad;
                        otra = escolarData.pac_escolaridad_otras;
                        relacion = escolarData.pac_escolaridad_relacion;
                        rendimiento = escolarData.pac_escolaridad_rendimiento;
                        cambio = escolarData.pac_escolaridad_cambios;
                        evaluacion = escolarData.pac_escolaridad_evaluacion;
                    }

                }
                var diversion = db.pac_diversion_intereses.Where(x => x.pac_diversion_pac_id == id).Count();
                if (diversion > 0)
                {
                    var diversionData = db.pac_diversion_intereses.FirstOrDefault(x => x.pac_diversion_pac_id == id);
                    if (diversionData != null)
                    {
                        lectura = diversionData.pac_diversion_lectura;
                        practicas = diversionData.pac_diversion_practicas;
                        pertenencia = diversionData.pac_diversion_pertenencia;
                    }


                }
                var ajustes = db.pac_ajustes_sociales.Where(x => x.pac_ajustes_pac_id == id).Count();
                if (ajustes > 0)
                {
                    var ajustesData = db.pac_ajustes_sociales.FirstOrDefault(x => x.pac_ajustes_pac_id == id);
                    if (ajustesData != null)
                    {
                        relacionesint = ajustesData.pac_ajustes_relacionesint;
                        amistades = ajustesData.pac_ajustes_amistades;
                        sentir = ajustesData.pac_ajustes_sentir;
                        novios = ajustesData.pac_ajustes_novias;
                    }

                }
                var desarrollo = db.pac_desarrollo_sexual.Where(x => x.pac_desarrollo_pac_id == id).Count();
                if (desarrollo > 0)
                {
                    var desarrolloData = db.pac_desarrollo_sexual.FirstOrDefault(x => x.pac_desarrollo_pac_id == id);
                    if (desarrolloData != null)
                    {
                        nociones = desarrolloData.pac_desarrollo_nociones;
                        contacto = desarrolloData.pac_desarrollo_contacto;
                        interes = desarrolloData.pac_desarrollo_fantasias;
                        mast = desarrolloData.pac_desarrollo_fantasias;
                        homo = desarrolloData.pac_desarrollo_homosex;
                        relpre = desarrolloData.pac_desarrollo_relaciones;
                    }


                }
                var datosmar = db.pac_datos_maritales.Where(x => x.pac_maritales_pac_id == id).Count();
                if (datosmar > 0)
                {
                    var datosmarnData = db.pac_datos_maritales.FirstOrDefault(x => x.pac_maritales_pac_id == id);
                    if (datosmarnData != null)
                    {
                        noviazgo = datosmarnData.pac_maritales_noviazgo;
                        expectativas = datosmarnData.pac_maritales_expnoviazgo;
                        descon = datosmarnData.pac_maritales_desc_conyuge;
                        eventos = datosmarnData.pac_maritales_eventos;
                        hijos = datosmarnData.pac_maritales_numhijos;
                        interaccion = datosmarnData.pac_maritales_interaccion;
                        familia = datosmarnData.pac_maritales_familia;
                    }


                }
                var descsimismo = db.pac_desc_simismo.Where(x => x.pac_simismo_pac_id == id).Count();
                if (descsimismo > 0)
                {
                    var descsimismoData = db.pac_desc_simismo.FirstOrDefault(x => x.pac_simismo_pac_id == id);
                    if (descsimismoData != null)
                    {
                        afuera = descsimismoData.pac_simismo_comoseve;
                        demas = descsimismoData.pac_simismo_comocree;
                        preocupaciones = descsimismoData.pac_simismo_preocupaciones;
                        metas = descsimismoData.pac_simismo_metas;
                        sido = descsimismoData.pac_simismo_gustaria;
                        crisis = descsimismoData.pac_simismo_crisis;
                        triunfo = descsimismoData.pac_simismo_triunfo_frac;
                        problemas = descsimismoData.pac_simismo_siente_problem;
                    }


                }
                var estadomen = db.pac_estado_mental.Where(x => x.pac_estado_pac_id == id).Count();
                if (estadomen > 0)
                {
                    var estadomenData = db.pac_estado_mental.FirstOrDefault(x => x.pac_estado_pac_id == id);
                    if (estadomenData != null)
                    {
                        estadocon = estadomenData.pac_estado_conciencia;
                        orientacion = estadomenData.pac_estado_orientacion;
                        afectividad = estadomenData.pac_estadoafectividad;
                        asociaciones = estadomenData.pac_estado_asociaciones;
                        contenido = estadomenData.pac_estado_pensamiento;
                        percepcion = estadomenData.pac_estado_percepcion;
                        funcionamiento = estadomenData.pac_estado_funcionamiento;
                        juicio = estadomenData.pac_estado_juicio;
                        insight = estadomenData.pac_estado_insight;
                        madurez = estadomenData.pac_estado_madurez;
                    }


                }
                var diagnostico = db.infodiagnostico.Where(x => x.pac_diag_pac_id == id).Count();
                if (diagnostico > 0)
                {
                    var diagnosticoData = db.infodiagnostico.FirstOrDefault(x => x.pac_diag_pac_id == id);
                    if (diagnosticoData != null)
                    {
                        cognitivo = diagnosticoData.pac_diag_perfilcog;
                        psicometrico = diagnosticoData.pac_diag_pruebaspsi;
                        diagnostico_ = diagnosticoData.pac_diag_diagnostico;
                        primario = diagnosticoData.diag_descrip.ToLower();
                        primarioConv = UppercaseFirst(primario);
                        especifico = diagnosticoData.pac_diag_especifico;
                        pronostico = diagnosticoData.pac_diag_pronostico;
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

                List<pac_psicoterapia> sessiones = null;
                sessiones = db.pac_psicoterapia.Where(x => x.pac_psico_pac_id == id).OrderBy(x => x.pac_psico_desc).ToList();

                if (infogeneral != null) {
                     nombre = infogeneral.paciente_nombre;
                     direccion = infogeneral.paciente_direccion;
                     ocupacion = infogeneral.paciente_ocupacion;
                     fnac = infogeneral.paciente_fec_nac.ToString();
                     fing = infogeneral.paciente_fec_ing.ToString();
                     genero = infogeneral.sexo_descrip;
                     edad = infogeneral.paciente_edad.ToString();
                     edocivil = infogeneral.edocivil_descrip;
                     telefono = infogeneral.paciente_telefono;
                     escolaridad = infogeneral.escolar_descrip;
                     edo = infogeneral.desc_edo;
                     mun = infogeneral.desc_mun;
                     mod = infogeneral.modalidad_descrip;
                     estatus = infogeneral.estatus_descrip;
                }



                //String ruta_img = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "imagenes\\logoSteujed.png");
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

                    //iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(ruta_img);
                    ////image1.ScalePercent(50f);
                    //image1.ScaleAbsoluteWidth(70);
                    //image1.ScaleAbsoluteHeight(60);
                    //image1.Alignment = Element.ALIGN_CENTER;
                    //doc.Add(image1);
                    Paragraph espacio = new Paragraph(" ");
                    doc.Add(espacio);

                    Paragraph title1 = new Paragraph(" EXPEDIENTE CLÍNICO", font2);
                    title1.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title1);
                    doc.Add(espacio);

                    Paragraph title3 = new Paragraph("DATOS DEL PACIENTE:", font1);
                    title3.Alignment = Element.ALIGN_LEFT;
                    doc.Add(title3);
                    doc.Add(espacio);



                    ////Creando la tabla
                    PdfPTable tabla2 = new PdfPTable(2);
                    tabla2.WidthPercentage = 80f;
                    ////Asignando los anchos de las columnas
                    float[] valores = new float[2] { 30, 40 };
                    tabla2.SetWidths(valores);

                    ////Creando celdas agregando contenido
                    PdfPCell c1 = new PdfPCell(new Phrase("NOMBRE:", font));
                    c1.BackgroundColor = new BaseColor(240, 240, 240);
                    c1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c1);

                    PdfPCell c2 = new PdfPCell(new Phrase(nombre, font));
                    c2.BackgroundColor = new BaseColor(240, 240, 240);
                    c2.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c2);

                    PdfPCell c3 = new PdfPCell(new Phrase("DIRECCIÓN:", font));
                    c3.BackgroundColor = new BaseColor(240, 240, 240);
                    c3.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c3);

                    PdfPCell c4 = new PdfPCell(new Phrase(direccion, font));
                    c4.BackgroundColor = new BaseColor(240, 240, 240);
                    c4.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c4);

                    PdfPCell c5 = new PdfPCell(new Phrase("OCUPACIÓN:", font));
                    c5.BackgroundColor = new BaseColor(240, 240, 240);
                    c5.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c5);

                    PdfPCell c6 = new PdfPCell(new Phrase(ocupacion, font));
                    c6.BackgroundColor = new BaseColor(240, 240, 240);
                    c6.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c6);

                    PdfPCell c7 = new PdfPCell(new Phrase("F_NACIMIENTO:", font));
                    c7.BackgroundColor = new BaseColor(240, 240, 240);
                    c7.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c7);

                    PdfPCell c8 = new PdfPCell(new Phrase(fnac, font));
                    c8.BackgroundColor = new BaseColor(240, 240, 240);
                    c8.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c8);

                    PdfPCell c9 = new PdfPCell(new Phrase("F_INGRESO:", font));
                    c9.BackgroundColor = new BaseColor(240, 240, 240);
                    c9.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c9);

                    PdfPCell c10 = new PdfPCell(new Phrase(fing, font));
                    c10.BackgroundColor = new BaseColor(240, 240, 240);
                    c10.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c10);

                    PdfPCell c11 = new PdfPCell(new Phrase("GÉNERO:", font));
                    c11.BackgroundColor = new BaseColor(240, 240, 240);
                    c11.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c11);

                    PdfPCell c12 = new PdfPCell(new Phrase(genero, font));
                    c12.BackgroundColor = new BaseColor(240, 240, 240);
                    c12.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c12);

                    PdfPCell c13 = new PdfPCell(new Phrase("EDAD:", font));
                    c13.BackgroundColor = new BaseColor(240, 240, 240);
                    c13.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c13);

                    PdfPCell c14 = new PdfPCell(new Phrase(edad, font));
                    c14.BackgroundColor = new BaseColor(240, 240, 240);
                    c14.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c14);

                    PdfPCell c15 = new PdfPCell(new Phrase("ESTADO CIVIL:", font));
                    c15.BackgroundColor = new BaseColor(240, 240, 240);
                    c15.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c15);

                    PdfPCell c16 = new PdfPCell(new Phrase(edocivil, font));
                    c16.BackgroundColor = new BaseColor(240, 240, 240);
                    c16.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c16);

                    PdfPCell c17 = new PdfPCell(new Phrase("TELEFONO:", font));
                    c17.BackgroundColor = new BaseColor(240, 240, 240);
                    c17.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c17);

                    PdfPCell c18 = new PdfPCell(new Phrase(telefono, font));
                    c18.BackgroundColor = new BaseColor(240, 240, 240);
                    c18.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c18);

                    PdfPCell c19 = new PdfPCell(new Phrase("TELEFONO EMERGENICA:", font));
                    c19.BackgroundColor = new BaseColor(240, 240, 240);
                    c19.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c19);

                    PdfPCell c20 = new PdfPCell(new Phrase(telefono_eme, font));
                    c20.BackgroundColor = new BaseColor(240, 240, 240);
                    c20.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c20);

                    PdfPCell c21 = new PdfPCell(new Phrase("ESCOLARIDAD:", font));
                    c21.BackgroundColor = new BaseColor(240, 240, 240);
                    c21.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c21);

                    PdfPCell c22 = new PdfPCell(new Phrase(escolaridad, font));
                    c22.BackgroundColor = new BaseColor(240, 240, 240);
                    c22.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c22);

                    PdfPCell c23 = new PdfPCell(new Phrase("ESTADO:", font));
                    c23.BackgroundColor = new BaseColor(240, 240, 240);
                    c23.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c23);

                    PdfPCell c24 = new PdfPCell(new Phrase(edo, font));
                    c24.BackgroundColor = new BaseColor(240, 240, 240);
                    c24.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c24);

                    PdfPCell c25 = new PdfPCell(new Phrase("MUNICIPIO:", font));
                    c25.BackgroundColor = new BaseColor(240, 240, 240);
                    c25.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c25);

                    PdfPCell c26 = new PdfPCell(new Phrase(mun, font));
                    c26.BackgroundColor = new BaseColor(240, 240, 240);
                    c26.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c26);

                    PdfPCell c27 = new PdfPCell(new Phrase("ESTADO DE RESIDENCIA:", font));
                    c27.BackgroundColor = new BaseColor(240, 240, 240);
                    c27.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c27);

                    PdfPCell C28 = new PdfPCell(new Phrase(edo_res, font));
                    C28.BackgroundColor = new BaseColor(240, 240, 240);
                    C28.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(C28);

                    PdfPCell c29 = new PdfPCell(new Phrase("MUNICIPIO DE RESIDENCIA:", font));
                    c29.BackgroundColor = new BaseColor(240, 240, 240);
                    c29.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c29);

                    PdfPCell c30 = new PdfPCell(new Phrase(mun_res, font));
                    c30.BackgroundColor = new BaseColor(240, 240, 240);
                    c30.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c30);

                    PdfPCell c31 = new PdfPCell(new Phrase("MODALIDAD:", font));
                    c31.BackgroundColor = new BaseColor(240, 240, 240);
                    c31.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c31);

                    PdfPCell c32 = new PdfPCell(new Phrase(mod, font));
                    c32.BackgroundColor = new BaseColor(240, 240, 240);
                    c32.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c32);

                    PdfPCell c33 = new PdfPCell(new Phrase("ESTATUS:", font));
                    c33.BackgroundColor = new BaseColor(240, 240, 240);
                    c33.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c33);

                    PdfPCell c34 = new PdfPCell(new Phrase(estatus, font));
                    c34.BackgroundColor = new BaseColor(240, 240, 240);
                    c34.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    tabla2.AddCell(c34);
                    //Agregando tabla al documento
                    doc.Add(tabla2);
                    doc.Add(espacio);
                    doc.Add(espacio);

                    if (descPaciente > 0)
                    {
                        Paragraph descpac = new Paragraph("DESCRIPCIÓN DEL PACIENTE", font1);
                        descpac.Alignment = Element.ALIGN_CENTER;
                        doc.Add(descpac);
                        doc.Add(espacio);

                        Paragraph desc1 = new Paragraph("1.Aspectos Generales.", font1);
                        desc1.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdesc1 = new Paragraph(aspecto, font);
                        resdesc1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(desc1);
                        doc.Add(resdesc1);
                        doc.Add(espacio);

                        Paragraph desc2 = new Paragraph("2.Vestimenta y aliño.", font1);
                        desc2.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdesc2 = new Paragraph(vestimenta, font);
                        resdesc1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(desc2);
                        doc.Add(resdesc2);
                        doc.Add(espacio);

                        Paragraph desc3 = new Paragraph("3.Porte y actitud.", font1);
                        desc3.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdesc3 = new Paragraph(porte, font);
                        resdesc1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(desc3);
                        doc.Add(resdesc3);
                        doc.Add(espacio);

                        Paragraph desc4 = new Paragraph("4.Movimientos, voz y lenguaje.", font1);
                        desc4.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdesc4 = new Paragraph(movimientos, font);
                        resdesc4.Alignment = Element.ALIGN_LEFT;
                        doc.Add(desc4);
                        doc.Add(resdesc4);
                        doc.Add(espacio);

                        Paragraph desc5 = new Paragraph("5.Afecto.", font1);
                        desc5.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdesc5 = new Paragraph(afecto, font);
                        resdesc5.Alignment = Element.ALIGN_LEFT;
                        doc.Add(desc5);
                        doc.Add(resdesc5);
                        doc.Add(espacio);
                        doc.Add(espacio);

                    }

                    if (motivocons>0) {
                        Paragraph motivotitulo = new Paragraph("MOTIVO DE LA CONSULTA", font1);
                        motivotitulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(motivotitulo);
                        doc.Add(espacio);

                        Paragraph motivo1 = new Paragraph("1.Problema actual.", font1);
                        motivo1.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmotivo1 = new Paragraph(problema, font);
                        resmotivo1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(motivo1);
                        doc.Add(resmotivo1);
                        doc.Add(espacio);

                        Paragraph motivo2 = new Paragraph("2.Historia del problema.", font1);
                        motivo2.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmotivo2 = new Paragraph(historia, font);
                        resmotivo2.Alignment = Element.ALIGN_LEFT;
                        doc.Add(motivo2);
                        doc.Add(resmotivo2);
                        doc.Add(espacio);

                        Paragraph motivo3 = new Paragraph("3.Referencia.", font1);
                        motivo3.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmotivo3 = new Paragraph(referencia, font);
                        resmotivo3.Alignment = Element.ALIGN_LEFT;
                        doc.Add(motivo3);
                        doc.Add(resmotivo3);
                        doc.Add(espacio);

                        Paragraph motivo4 = new Paragraph("4.Experiencia y Tx.", font1);
                        motivo4.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmotivo4 = new Paragraph(experiencia, font);
                        resmotivo4.Alignment = Element.ALIGN_LEFT;
                        doc.Add(motivo4);
                        doc.Add(resmotivo4);
                        doc.Add(espacio);
                        doc.Add(espacio);
                    }
                    if (situacion>0) {
                        Paragraph situaciontitulo = new Paragraph("SITUACIÓN ACTUAL", font1);
                        situaciontitulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(situaciontitulo);
                        doc.Add(espacio);

                        Paragraph sitiacion1 = new Paragraph("1.Día común y corriente.", font1);
                        sitiacion1.Alignment = Element.ALIGN_LEFT;
                        Paragraph ressituacion1 = new Paragraph(problema, font);
                        ressituacion1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(sitiacion1);
                        doc.Add(ressituacion1);
                        doc.Add(espacio);

                        Paragraph sitiacion2 = new Paragraph("2.Ocaciones especiales.", font1);
                        sitiacion2.Alignment = Element.ALIGN_LEFT;
                        Paragraph ressituacion2 = new Paragraph(historia, font);
                        ressituacion2.Alignment = Element.ALIGN_LEFT;
                        doc.Add(sitiacion2);
                        doc.Add(ressituacion2);
                        doc.Add(espacio);
                        doc.Add(espacio);
                    }
                    if (constelacion>0) {
                        Paragraph constelaciontitulo = new Paragraph("CONSTELACIÓN FAMILIAR", font1);
                        constelaciontitulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(constelaciontitulo);
                        doc.Add(espacio);

                        Paragraph constelacion1 = new Paragraph("Observación.", font1);
                        constelacion1.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmconstelacion1 = new Paragraph(observaciones, font);
                        resmconstelacion1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(constelacion1);
                        doc.Add(resmconstelacion1);
                        doc.Add(espacio);

                        Paragraph constelacion2 = new Paragraph("1.Antecedentes patológicos.", font1);
                        constelacion2.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmconstelacion2 = new Paragraph(antecedentes, font);
                        resmconstelacion2.Alignment = Element.ALIGN_LEFT;
                        doc.Add(constelacion2);
                        doc.Add(resmconstelacion2);
                        doc.Add(espacio);

                        Paragraph constelacion3 = new Paragraph("2.Descripción del padre y la madre.", font1);
                        constelacion3.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmconstelacion3 = new Paragraph(descripcion, font);
                        resmconstelacion3.Alignment = Element.ALIGN_LEFT;
                        doc.Add(constelacion3);
                        doc.Add(resmconstelacion3);
                        doc.Add(espacio);

                        Paragraph constelacion4 = new Paragraph("3.Hermanos.", font1);
                        constelacion4.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmconstelacion4 = new Paragraph(hermanos, font);
                        resmconstelacion4.Alignment = Element.ALIGN_LEFT;
                        doc.Add(constelacion4);
                        doc.Add(resmconstelacion4);
                        doc.Add(espacio);

                        Paragraph constelacion5 = new Paragraph("4.Rivalidades.", font1);
                        constelacion5.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmconstelacion5 = new Paragraph(rivalidades, font);
                        resmconstelacion5.Alignment = Element.ALIGN_LEFT;
                        doc.Add(constelacion5);
                        doc.Add(resmconstelacion5);
                        doc.Add(espacio);

                        Paragraph constelacion6 = new Paragraph("5.Papel dentro de la familia.", font1);
                        constelacion6.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmconstelacion6 = new Paragraph(papel, font);
                        resmconstelacion6.Alignment = Element.ALIGN_LEFT;
                        doc.Add(constelacion6);
                        doc.Add(resmconstelacion6);
                        doc.Add(espacio);

                        Paragraph constelacion7 = new Paragraph("6.Uniones y fricciones.", font1);
                        constelacion7.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmconstelacion7 = new Paragraph(uniones, font);
                        resmconstelacion7.Alignment = Element.ALIGN_LEFT;
                        doc.Add(constelacion7);
                        doc.Add(resmconstelacion7);
                        doc.Add(espacio);

                        Paragraph constelacion8 = new Paragraph("7.Normas sociales.", font1);
                        constelacion8.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmconstelacion8 = new Paragraph(normas, font);
                        resmconstelacion8.Alignment = Element.ALIGN_LEFT;
                        doc.Add(constelacion8);
                        doc.Add(resmconstelacion8);
                        doc.Add(espacio);

                        Paragraph constelacion9 = new Paragraph("8.Cambios en la constelación familiar.", font1);
                        constelacion9.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmconstelacion9 = new Paragraph(cambios, font);
                        resmconstelacion9.Alignment = Element.ALIGN_LEFT;
                        doc.Add(constelacion9);
                        doc.Add(resmconstelacion9);
                        doc.Add(espacio);
                        doc.Add(espacio);
                    }
                    if (recuerdos>0) {
                        Paragraph recuerdostitulo = new Paragraph("RECUERDOS TEMPRANOS", font1);
                        recuerdostitulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(recuerdostitulo);
                        doc.Add(espacio);

                        Paragraph recuerdos1 = new Paragraph("1.Recuerdos tempranos.", font1);
                        recuerdos1.Alignment = Element.ALIGN_LEFT;
                        Paragraph resrecuerdos1 = new Paragraph(recuerdo, font);
                        resrecuerdos1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(recuerdos1);
                        doc.Add(resrecuerdos1);
                        doc.Add(espacio);
                        doc.Add(espacio);

                    }
                    if (historiaPer>0) {
                        Paragraph historiatitulo = new Paragraph("HISTORIA PERSONAL", font1);
                        historiatitulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(historiatitulo);
                        doc.Add(espacio);

                        Paragraph historia1 = new Paragraph("1.Embarazo y nacimiento.", font1);
                        historia1.Alignment = Element.ALIGN_LEFT;
                        Paragraph reshistoria1 = new Paragraph(embarazo, font);
                        reshistoria1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(historia1);
                        doc.Add(reshistoria1);
                        doc.Add(espacio);

                        Paragraph historia2 = new Paragraph("2.Inició marcha, habla y control de esfinteres.", font1);
                        historia2.Alignment = Element.ALIGN_LEFT;
                        Paragraph reshistoria2 = new Paragraph(inicio, font);
                        reshistoria2.Alignment = Element.ALIGN_LEFT;
                        doc.Add(historia2);
                        doc.Add(reshistoria2);
                        doc.Add(espacio);

                        Paragraph historia3 = new Paragraph("3.Infancia; hábitos, alimentación, etc.", font1);
                        historia3.Alignment = Element.ALIGN_LEFT;
                        Paragraph reshistoria3 = new Paragraph(infancia, font);
                        reshistoria3.Alignment = Element.ALIGN_LEFT;
                        doc.Add(historia3);
                        doc.Add(reshistoria3);
                        doc.Add(espacio);

                        Paragraph historia4 = new Paragraph("4.Niñez; relaciones sociales, temores, etc.", font1);
                        historia4.Alignment = Element.ALIGN_LEFT;
                        Paragraph reshistoria4 = new Paragraph(ninez, font);
                        reshistoria4.Alignment = Element.ALIGN_LEFT;
                        doc.Add(historia4);
                        doc.Add(reshistoria4);
                        doc.Add(espacio);

                        Paragraph historia5 = new Paragraph("5.Adolecencia; problemas, relaciones interpersonales.", font1);
                        historia5.Alignment = Element.ALIGN_LEFT;
                        Paragraph reshistoria5 = new Paragraph(adolecencia, font);
                        reshistoria5.Alignment = Element.ALIGN_LEFT;
                        doc.Add(historia5);
                        doc.Add(reshistoria5);
                        doc.Add(espacio);

                        Paragraph historia6 = new Paragraph("6.Edad adulta; logros, satisfacciones, etc.", font1);
                        historia6.Alignment = Element.ALIGN_LEFT;
                        Paragraph reshistoria6 = new Paragraph(adulta, font);
                        reshistoria6.Alignment = Element.ALIGN_LEFT;
                        doc.Add(historia6);
                        doc.Add(reshistoria6);
                        doc.Add(espacio);

                        Paragraph historia7 = new Paragraph("7.Edad avanzada; abandono de los hijos, temor a la muerte.", font1);
                        historia7.Alignment = Element.ALIGN_LEFT;
                        Paragraph reshistoria7 = new Paragraph(avanzada, font);
                        reshistoria7.Alignment = Element.ALIGN_LEFT;
                        doc.Add(historia7);
                        doc.Add(reshistoria7);
                        doc.Add(espacio);

                        Paragraph historia8 = new Paragraph("8.Alimentación.", font1);
                        historia8.Alignment = Element.ALIGN_LEFT;
                        Paragraph reshistoria8 = new Paragraph(alimentacion, font);
                        reshistoria8.Alignment = Element.ALIGN_LEFT;
                        doc.Add(historia8);
                        doc.Add(reshistoria8);
                        doc.Add(espacio);

                        Paragraph historia9 = new Paragraph("9.Sueño.", font1);
                        historia9.Alignment = Element.ALIGN_LEFT;
                        Paragraph reshistoria9 = new Paragraph(sueno, font);
                        reshistoria9.Alignment = Element.ALIGN_LEFT;
                        doc.Add(historia9);
                        doc.Add(reshistoria9);
                        doc.Add(espacio);

                        Paragraph historia10 = new Paragraph("10.Enfermedades.", font1);
                        historia10.Alignment = Element.ALIGN_LEFT;
                        Paragraph reshistoria10 = new Paragraph(enfermedades, font);
                        reshistoria10.Alignment = Element.ALIGN_LEFT;
                        doc.Add(historia10);
                        doc.Add(reshistoria10);
                        doc.Add(espacio);

                        Paragraph historia11 = new Paragraph("11.Lesiones,operaciones.", font1);
                        historia11.Alignment = Element.ALIGN_LEFT;
                        Paragraph reshistoria11 = new Paragraph(lesiones, font);
                        reshistoria1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(historia11);
                        doc.Add(reshistoria11);
                        doc.Add(espacio);

                        Paragraph historia12 = new Paragraph("12.Opinión de salud actual.", font1);
                        historia12.Alignment = Element.ALIGN_LEFT;
                        Paragraph reshistoria12 = new Paragraph(opinion, font);
                        reshistoria12.Alignment = Element.ALIGN_LEFT;
                        doc.Add(historia12);
                        doc.Add(reshistoria12);
                        doc.Add(espacio);
                        doc.Add(espacio);
                    }
                    if (escolar>0) {
                        Paragraph escolartitulo = new Paragraph("ESCOLARIDAD", font1);
                        escolartitulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(escolartitulo);
                        doc.Add(espacio);

                        Paragraph escolarx = new Paragraph("Escuelas a las que asistió.", font1);
                        Paragraph escolar1 = new Paragraph("Primaria:", font1);
                        escolarx.Alignment = Element.ALIGN_LEFT;
                        escolar1.Alignment = Element.ALIGN_LEFT;
                        Paragraph resescolar1 = new Paragraph(primaria, font);
                        resescolar1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(escolarx);
                        doc.Add(escolar1);
                        doc.Add(resescolar1);
                        doc.Add(espacio);

                        Paragraph escolar2 = new Paragraph("Secundaria:", font1);
                        escolar2.Alignment = Element.ALIGN_LEFT;
                        Paragraph resescolar2 = new Paragraph(secundaria, font);
                        resescolar2.Alignment = Element.ALIGN_LEFT;
                        doc.Add(escolar2);
                        doc.Add(resescolar2);
                        doc.Add(espacio);


                        Paragraph escolar3 = new Paragraph("Preparatoria:", font1);
                        escolar3.Alignment = Element.ALIGN_LEFT;
                        Paragraph resescolar3 = new Paragraph(preparatoria, font);
                        resescolar3.Alignment = Element.ALIGN_LEFT;
                        doc.Add(escolar3);
                        doc.Add(resescolar3);
                        doc.Add(espacio);


                        Paragraph escolar4 = new Paragraph("Universidad:", font1);
                        escolar4.Alignment = Element.ALIGN_LEFT;
                        Paragraph resescolar4 = new Paragraph(universidad, font);
                        resescolar1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(escolar4);
                        doc.Add(resescolar4);
                        doc.Add(espacio);


                        Paragraph escolar5 = new Paragraph("Otras:", font1);
                        escolar5.Alignment = Element.ALIGN_LEFT;
                        Paragraph resescolar5 = new Paragraph(otra, font);
                        resescolar5.Alignment = Element.ALIGN_LEFT;
                        doc.Add(escolar5);
                        doc.Add(resescolar5);
                        doc.Add(espacio);


                        Paragraph escolar6 = new Paragraph("1.Relación con los maestros y compañeros.", font1);
                        escolar6.Alignment = Element.ALIGN_LEFT;
                        Paragraph resescolar6 = new Paragraph(relacion, font);
                        resescolar6.Alignment = Element.ALIGN_LEFT;
                        doc.Add(escolar6);
                        doc.Add(resescolar6);
                        doc.Add(espacio);


                        Paragraph escolar7 = new Paragraph("2.Rendimiento escolar.", font1);
                        escolar7.Alignment = Element.ALIGN_LEFT;
                        Paragraph resescolar7 = new Paragraph(rendimiento, font);
                        resescolar7.Alignment = Element.ALIGN_LEFT;
                        doc.Add(escolar7);
                        doc.Add(resescolar7);
                        doc.Add(espacio);

                        Paragraph escolar8 = new Paragraph("3.Cambios de escuela.", font1);
                        escolar8.Alignment = Element.ALIGN_LEFT;
                        Paragraph resescolar8 = new Paragraph(cambio, font);
                        resescolar8.Alignment = Element.ALIGN_LEFT;
                        doc.Add(escolar8);
                        doc.Add(resescolar8);
                        doc.Add(espacio);

                        Paragraph escolar9 = new Paragraph("4.Evaluacion personal de vida escolar.", font1);
                        escolar9.Alignment = Element.ALIGN_LEFT;
                        Paragraph resescolar9 = new Paragraph(evaluacion, font);
                        resescolar9.Alignment = Element.ALIGN_LEFT;
                        doc.Add(escolar9);
                        doc.Add(resescolar9);
                        doc.Add(espacio);
                        doc.Add(espacio);
                    }
                    if (diversion>0) {
                        Paragraph diversiontitulo = new Paragraph("DIVERSIÓN E INTERESES", font1);
                        diversiontitulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(diversiontitulo);
                        doc.Add(espacio);

                        Paragraph diversion1 = new Paragraph("1.Lectura, música, deportes, etc.", font1);
                        diversion1.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdiversion1 = new Paragraph(lectura, font);
                        resdiversion1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(diversion1);
                        doc.Add(resdiversion1);
                        doc.Add(espacio);

                        Paragraph diversion2 = new Paragraph("2.Prácticas religiosas.", font1);
                        diversion2.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdiversion2 = new Paragraph(practicas, font);
                        resdiversion2.Alignment = Element.ALIGN_LEFT;
                        doc.Add(diversion2);
                        doc.Add(resdiversion2);
                        doc.Add(espacio);

                        Paragraph diversion3 = new Paragraph("3.Pertenencia a grupo.", font1);
                        diversion3.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdiversion3 = new Paragraph(pertenencia, font);
                        resdiversion3.Alignment = Element.ALIGN_LEFT;
                        doc.Add(diversion3);
                        doc.Add(resdiversion3);
                        doc.Add(espacio);
                        doc.Add(espacio);
                    }
                    if (ajustes>0) {
                        Paragraph ajustestitulo = new Paragraph("AJUSTES SOCIALES", font1);
                        ajustestitulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(ajustestitulo);
                        doc.Add(espacio);

                        Paragraph ajustes1 = new Paragraph("1.Relaciones interpersonales.", font1);
                        ajustes1.Alignment = Element.ALIGN_LEFT;
                        Paragraph resajustes1 = new Paragraph(relacionesint, font);
                        resajustes1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(ajustes1);
                        doc.Add(resajustes1);
                        doc.Add(espacio);

                        Paragraph ajustes2 = new Paragraph("2.Amistades (Hombres-Mujeres).", font1);
                        ajustes2.Alignment = Element.ALIGN_LEFT;
                        Paragraph resajustes2 = new Paragraph(amistades, font);
                        resajustes2.Alignment = Element.ALIGN_LEFT;
                        doc.Add(ajustes2);
                        doc.Add(resajustes2);
                        doc.Add(espacio);

                        Paragraph ajustes3 = new Paragraph("3.Su sentir respecto a sus amistades.", font1);
                        ajustes3.Alignment = Element.ALIGN_LEFT;
                        Paragraph resajustes3 = new Paragraph(sentir, font);
                        resajustes3.Alignment = Element.ALIGN_LEFT;
                        doc.Add(ajustes3);
                        doc.Add(resajustes3);
                        doc.Add(espacio);

                        Paragraph ajustes4 = new Paragraph("4.Novios(as)(Cuantos y como fue la relación).", font1);
                        ajustes4.Alignment = Element.ALIGN_LEFT;
                        Paragraph resajustes4 = new Paragraph(novios, font);
                        resajustes4.Alignment = Element.ALIGN_LEFT;
                        doc.Add(ajustes4);
                        doc.Add(resajustes4);
                        doc.Add(espacio);
                        doc.Add(espacio);
                    }
                    if (desarrollo>0) {

                        Paragraph desarrollotitulo = new Paragraph("DESARROLLO SEXUAL", font1);
                        desarrollotitulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(desarrollotitulo);
                        doc.Add(espacio);

                        Paragraph desarrollo1 = new Paragraph("1.Primeras nociones acerca del sexo.", font1);
                        desarrollo1.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdesarrollo1 = new Paragraph(nociones, font);
                        resdesarrollo1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(desarrollo1);
                        doc.Add(resdesarrollo1);
                        doc.Add(espacio);

                        Paragraph desarrollo2 = new Paragraph("2.Primer contacto sexual.", font1);
                        desarrollo2.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdesarrollo2 = new Paragraph(contacto, font);
                        resdesarrollo2.Alignment = Element.ALIGN_LEFT;
                        doc.Add(desarrollo2);
                        doc.Add(resdesarrollo2);
                        doc.Add(espacio);

                        Paragraph desarrollo3 = new Paragraph("3.Evolución e interes sexual.", font1);
                        desarrollo3.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdesarrollo3 = new Paragraph(interes, font);
                        resdesarrollo3.Alignment = Element.ALIGN_LEFT;
                        doc.Add(desarrollo3);
                        doc.Add(resdesarrollo3);
                        doc.Add(espacio);

                        Paragraph desarrollo4 = new Paragraph("4.Masturbación, sueños y fantasías sexuales.", font1);
                        desarrollo4.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdesarrollo4 = new Paragraph(mast, font);
                        resdesarrollo4.Alignment = Element.ALIGN_LEFT;
                        doc.Add(desarrollo4);
                        doc.Add(resdesarrollo4);
                        doc.Add(espacio);

                        Paragraph desarrollo5 = new Paragraph("5.Homosexualidad.", font1);
                        desarrollo5.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdesarrollo5 = new Paragraph(homo, font);
                        resdesarrollo5.Alignment = Element.ALIGN_LEFT;
                        doc.Add(desarrollo5);
                        doc.Add(resdesarrollo5);
                        doc.Add(espacio);

                        Paragraph desarrollo6 = new Paragraph("6.Relaciones premaritales, maritales y extramarital.", font1);
                        desarrollo6.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdesarrollo6 = new Paragraph(relpre, font);
                        resdesarrollo6.Alignment = Element.ALIGN_LEFT;
                        doc.Add(desarrollo6);
                        doc.Add(resdesarrollo6);
                        doc.Add(espacio);
                        doc.Add(espacio);
                    }
                    if (datosmar>0) {
                        Paragraph maritalestitulo = new Paragraph("DATOS MARITALES", font1);
                        maritalestitulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(maritalestitulo);
                        doc.Add(espacio);

                        Paragraph maritales1 = new Paragraph("1.Noviazgo.", font1);
                        maritales1.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmaritales1 = new Paragraph(nociones, font);
                        resmaritales1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(maritales1);
                        doc.Add(resmaritales1);
                        doc.Add(espacio);


                        Paragraph maritales2 = new Paragraph("2.Expectativas de noviazgo.", font1);
                        maritales2.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmaritales2 = new Paragraph(nociones, font);
                        resmaritales2.Alignment = Element.ALIGN_LEFT;
                        doc.Add(maritales2);
                        doc.Add(resmaritales2);
                        doc.Add(espacio);


                        Paragraph maritales3 = new Paragraph("3.Descripción del cónyuge.", font1);
                        maritales3.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmaritales3 = new Paragraph(nociones, font);
                        resmaritales3.Alignment = Element.ALIGN_LEFT;
                        doc.Add(maritales3);
                        doc.Add(resmaritales3);
                        doc.Add(espacio);


                        Paragraph maritales4 = new Paragraph("4.Eventos importantes.", font1);
                        maritales4.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmaritales4 = new Paragraph(nociones, font);
                        resmaritales4.Alignment = Element.ALIGN_LEFT;
                        doc.Add(maritales4);
                        doc.Add(resmaritales4);
                        doc.Add(espacio);


                        Paragraph maritales5 = new Paragraph("5.Número de hijos, preferencias.", font1);
                        maritales5.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmaritales5 = new Paragraph(nociones, font);
                        resmaritales5.Alignment = Element.ALIGN_LEFT;
                        doc.Add(maritales5);
                        doc.Add(resmaritales5);
                        doc.Add(espacio);


                        Paragraph maritales6 = new Paragraph("6.Interacción de la familia actual.", font1);
                        maritales6.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmaritales6 = new Paragraph(nociones, font);
                        resmaritales6.Alignment = Element.ALIGN_LEFT;
                        doc.Add(maritales6);
                        doc.Add(resmaritales6);
                        doc.Add(espacio);


                        Paragraph maritales7 = new Paragraph("7.Cómo se siente respecto a su familia.", font1);
                        maritales7.Alignment = Element.ALIGN_LEFT;
                        Paragraph resmaritales7 = new Paragraph(nociones, font);
                        resmaritales7.Alignment = Element.ALIGN_LEFT;
                        doc.Add(maritales7);
                        doc.Add(resmaritales7);
                        doc.Add(espacio);
                        doc.Add(espacio);
                    }
                    if (descsimismo>0) {
                        Paragraph simismotitulo = new Paragraph("DESCRIPCIÓN DE SÍ MISMO", font1);
                        simismotitulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(simismotitulo);
                        doc.Add(espacio);

                        Paragraph simismo1 = new Paragraph("1.Como se ve desde afuera.", font1);
                        simismo1.Alignment = Element.ALIGN_LEFT;
                        Paragraph ressimismo1 = new Paragraph(afuera, font);
                        ressimismo1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(simismo1);
                        doc.Add(ressimismo1);
                        doc.Add(espacio);

                        Paragraph simismo2 = new Paragraph("2.Como cree que lo ven los demás.", font1);
                        simismo2.Alignment = Element.ALIGN_LEFT;
                        Paragraph ressimismo2 = new Paragraph(demas, font);
                        ressimismo2.Alignment = Element.ALIGN_LEFT;
                        doc.Add(simismo2);
                        doc.Add(ressimismo2);
                        doc.Add(espacio);

                        Paragraph simismo3 = new Paragraph("3.Preocupaciones, dudas, etc.", font1);
                        simismo3.Alignment = Element.ALIGN_LEFT;
                        Paragraph ressimismo3 = new Paragraph(preocupaciones, font);
                        ressimismo3.Alignment = Element.ALIGN_LEFT;
                        doc.Add(simismo3);
                        doc.Add(ressimismo3);
                        doc.Add(espacio);

                        Paragraph simismo4 = new Paragraph("4.Metas.", font1);
                        simismo4.Alignment = Element.ALIGN_LEFT;
                        Paragraph ressimismo4 = new Paragraph(metas, font);
                        ressimismo4.Alignment = Element.ALIGN_LEFT;
                        doc.Add(simismo4);
                        doc.Add(ressimismo4);
                        doc.Add(espacio);

                        Paragraph simismo5 = new Paragraph("5.Como le gustaria haber sido.", font1);
                        simismo5.Alignment = Element.ALIGN_LEFT;
                        Paragraph ressimismo5 = new Paragraph(sido, font);
                        ressimismo5.Alignment = Element.ALIGN_LEFT;
                        doc.Add(simismo5);
                        doc.Add(ressimismo5);
                        doc.Add(espacio);

                        Paragraph simismo6 = new Paragraph("6.Las crisis más importantes.", font1);
                        simismo6.Alignment = Element.ALIGN_LEFT;
                        Paragraph ressimismo6 = new Paragraph(crisis, font);
                        ressimismo6.Alignment = Element.ALIGN_LEFT;
                        doc.Add(simismo6);
                        doc.Add(ressimismo6);
                        doc.Add(espacio);

                        Paragraph simismo7 = new Paragraph("7.Descripción de un triunfo y un fracaso.", font1);
                        simismo7.Alignment = Element.ALIGN_LEFT;
                        Paragraph ressimismo7 = new Paragraph(triunfo, font);
                        ressimismo7.Alignment = Element.ALIGN_LEFT;
                        doc.Add(simismo7);
                        doc.Add(ressimismo7);
                        doc.Add(espacio);

                        Paragraph simismo8 = new Paragraph("8.Cómo se siente ante sus problemas.", font1);
                        simismo8.Alignment = Element.ALIGN_LEFT;
                        Paragraph ressimismo8 = new Paragraph(problemas, font);
                        ressimismo8.Alignment = Element.ALIGN_LEFT;
                        doc.Add(simismo8);
                        doc.Add(ressimismo8);
                        doc.Add(espacio);
                        doc.Add(espacio);
                    }
                    if (estadomen>0) {
                        Paragraph estadotitulo = new Paragraph("ESTADO MENTAL", font1);
                        estadotitulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(estadotitulo);
                        doc.Add(espacio);

                        Paragraph estado1 = new Paragraph("1.Estado de conciencia.", font1);
                        estado1.Alignment = Element.ALIGN_LEFT;
                        Paragraph resestado1 = new Paragraph(estadocon, font);
                        resestado1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(estado1);
                        doc.Add(resestado1);
                        doc.Add(espacio);

                        Paragraph estado2 = new Paragraph("2.Orientación, tiempo, espacio.", font1);
                        estado2.Alignment = Element.ALIGN_LEFT;
                        Paragraph resestado2 = new Paragraph(orientacion, font);
                        resestado2.Alignment = Element.ALIGN_LEFT;
                        doc.Add(estado2);
                        doc.Add(resestado2);
                        doc.Add(espacio);

                        Paragraph estado3 = new Paragraph("3.Afectividad y estado de ánimo.", font1);
                        estado3.Alignment = Element.ALIGN_LEFT;
                        Paragraph resestado3 = new Paragraph(afectividad, font);
                        resestado3.Alignment = Element.ALIGN_LEFT;
                        doc.Add(estado3);
                        doc.Add(resestado3);
                        doc.Add(espacio);

                        Paragraph estado4 = new Paragraph("4.Asociaciones y pensamiento.", font1);
                        estado4.Alignment = Element.ALIGN_LEFT;
                        Paragraph resestado4 = new Paragraph(asociaciones, font);
                        resestado4.Alignment = Element.ALIGN_LEFT;
                        doc.Add(estado4);
                        doc.Add(resestado4);
                        doc.Add(espacio);

                        Paragraph estado5 = new Paragraph("5.Contenido del pensamiento.", font1);
                        estado5.Alignment = Element.ALIGN_LEFT;
                        Paragraph resestado5 = new Paragraph(contenido, font);
                        resestado5.Alignment = Element.ALIGN_LEFT;
                        doc.Add(estado5);
                        doc.Add(resestado5);
                        doc.Add(espacio);

                        Paragraph estado6 = new Paragraph("6.Percepción.", font1);
                        estado6.Alignment = Element.ALIGN_LEFT;
                        Paragraph resestado6 = new Paragraph(percepcion, font);
                        resestado1.Alignment = Element.ALIGN_LEFT;
                        doc.Add(estado6);
                        doc.Add(resestado6);
                        doc.Add(espacio);

                        Paragraph estado7 = new Paragraph("7.Funcionamiento Sintético-Integrativo.", font1);
                        estado7.Alignment = Element.ALIGN_LEFT;
                        Paragraph resestado7 = new Paragraph(funcionamiento, font);
                        resestado7.Alignment = Element.ALIGN_LEFT;
                        doc.Add(estado7);
                        doc.Add(resestado7);
                        doc.Add(espacio);

                        Paragraph estado8 = new Paragraph("8.Juicio.", font1);
                        estado8.Alignment = Element.ALIGN_LEFT;
                        Paragraph resestado8 = new Paragraph(juicio, font);
                        resestado8.Alignment = Element.ALIGN_LEFT;
                        doc.Add(estado8);
                        doc.Add(resestado8);
                        doc.Add(espacio);

                        Paragraph estado9 = new Paragraph("9.Insight.", font1);
                        estado9.Alignment = Element.ALIGN_LEFT;
                        Paragraph resestado9 = new Paragraph(insight, font);
                        resestado9.Alignment = Element.ALIGN_LEFT;
                        doc.Add(estado9);
                        doc.Add(resestado9);
                        doc.Add(espacio);

                        Paragraph estado10 = new Paragraph("10.Madurez.", font1);
                        estado10.Alignment = Element.ALIGN_LEFT;
                        Paragraph resestado10 = new Paragraph(madurez, font);
                        resestado10.Alignment = Element.ALIGN_LEFT;
                        doc.Add(estado10);
                        doc.Add(resestado10);
                        doc.Add(espacio);
                        doc.Add(espacio);
                    }
                    if (diagnostico>0) {
                        Paragraph diagnosticotitulo = new Paragraph("DIAGNÓSTICO", font1);
                        diagnosticotitulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(diagnosticotitulo);
                        doc.Add(espacio);

                        Paragraph diagnostico1 = new Paragraph("Perfil cognitivo.", font1);
                        diagnostico1.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdiagnostico11 = new Paragraph(cognitivo, font);
                        resdiagnostico11.Alignment = Element.ALIGN_LEFT;
                        doc.Add(diagnostico1);
                        doc.Add(resdiagnostico11);
                        doc.Add(espacio);

                        Paragraph diagnostico2 = new Paragraph("Pruebas psicométricas.", font1);
                        diagnostico2.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdiagnostico12 = new Paragraph(psicometrico, font);
                        resdiagnostico12.Alignment = Element.ALIGN_LEFT;
                        doc.Add(diagnostico2);
                        doc.Add(resdiagnostico12);
                        doc.Add(espacio);

                        Paragraph diagnostico3 = new Paragraph("Diagnóstico.", font1);
                        diagnostico3.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdiagnostico3 = new Paragraph(diagnostico_, font);
                        resdiagnostico3.Alignment = Element.ALIGN_LEFT;
                        doc.Add(diagnostico3);
                        doc.Add(resdiagnostico3);
                        doc.Add(espacio);

                        Paragraph diagnostico4 = new Paragraph("Diagnóstico primario.", font1);
                        diagnostico4.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdiagnostico4 = new Paragraph(primarioConv, font);
                        resdiagnostico4.Alignment = Element.ALIGN_LEFT;
                        doc.Add(diagnostico4);
                        doc.Add(resdiagnostico4);
                        doc.Add(espacio);

                        Paragraph diagnostico5 = new Paragraph("Diagnóstico específico.", font1);
                        diagnostico5.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdiagnostico5 = new Paragraph(especifico, font);
                        resdiagnostico5.Alignment = Element.ALIGN_LEFT;
                        doc.Add(diagnostico5);
                        doc.Add(resdiagnostico5);
                        doc.Add(espacio);

                        Paragraph diagnostico6 = new Paragraph("Pronóstico.", font1);
                        diagnostico6.Alignment = Element.ALIGN_LEFT;
                        Paragraph resdiagnostico6 = new Paragraph(pronostico, font);
                        resdiagnostico6.Alignment = Element.ALIGN_LEFT;
                        doc.Add(diagnostico6);
                        doc.Add(resdiagnostico6);
                        doc.Add(espacio);
                        doc.Add(espacio);
                    }
                    if (sessiones.Count()>0) {
                        Paragraph psicoterapiatitulo = new Paragraph("PSICOTERAPIA", font1);
                        psicoterapiatitulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(psicoterapiatitulo);
                        doc.Add(espacio);

                        foreach (var ele in sessiones)
                        {
                            Paragraph sess = new Paragraph(ele.pac_psico_desc, font1);
                            sess.Alignment = Element.ALIGN_LEFT;
                            Paragraph psico1 = new Paragraph("Diagnóstico o Descrición del problema.", font1);
                            psico1.Alignment = Element.ALIGN_LEFT;
                            Paragraph respsico1 = new Paragraph(ele.pac_psico_texto, font);
                            respsico1.Alignment = Element.ALIGN_LEFT;
                            Paragraph obj = new Paragraph("Objetivo de intervención.", font1);
                            obj.Alignment = Element.ALIGN_LEFT;
                            Paragraph objres = new Paragraph(ele.pac_psico_intervencion, font);
                            objres.Alignment = Element.ALIGN_LEFT;
                            Paragraph tecnicas = new Paragraph("Técnicas o procedimiento de intervención.", font1);
                            tecnicas.Alignment = Element.ALIGN_LEFT;
                            Paragraph tecnicasres = new Paragraph(ele.pac_psico_tecnicas, font);
                            tecnicasres.Alignment = Element.ALIGN_LEFT;
                            Paragraph resultado = new Paragraph("Resultados.", font1);
                            resultado.Alignment = Element.ALIGN_LEFT;
                            Paragraph resultadores = new Paragraph(ele.pac_psico_resultados, font);
                            resultadores.Alignment = Element.ALIGN_LEFT;
                            Paragraph reco = new Paragraph("Recomendaciones.", font1);
                            reco.Alignment = Element.ALIGN_LEFT;
                            Paragraph recores = new Paragraph(ele.pac_psico_recomenda, font);
                            recores.Alignment = Element.ALIGN_LEFT;
                            Paragraph osb = new Paragraph("Observaciones.", font1);
                            osb.Alignment = Element.ALIGN_LEFT;
                            Paragraph osbres = new Paragraph(ele.pac_psico_observaciones, font);
                            osbres.Alignment = Element.ALIGN_LEFT;
                            doc.Add(sess);
                            doc.Add(espacio);
                            doc.Add(psico1);
                            doc.Add(respsico1);
                            doc.Add(espacio);
                            doc.Add(obj);
                            doc.Add(objres);
                            doc.Add(espacio);
                            doc.Add(tecnicas);
                            doc.Add(tecnicasres);
                            doc.Add(espacio);
                            doc.Add(resultado);
                            doc.Add(resultadores);
                            doc.Add(espacio);
                            doc.Add(reco);
                            doc.Add(recores);
                            doc.Add(espacio);
                            doc.Add(osb);
                            doc.Add(osbres);
                            doc.Add(espacio);
                        }
                    }




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
                    response.Content.Headers.ContentDisposition  = new ContentDispositionHeaderValue("inline")
                    {
                        FileName = filenamedoc
                    };
                    //if (ContentDispositionHeaderValue.TryParse("inline; filename="+ filenamedoc, out contentDisposition))
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
