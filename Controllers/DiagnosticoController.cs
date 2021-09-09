using api.colegio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.colegio.Controllers
{
    public class DiagnosticoController : ApiController
    {
        [Route("api/Diagnosticoprimario")]
        [HttpGet]
        public IEnumerable<DiagprimCLS> GetDiagnosticoprimario()
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                List<DiagprimCLS> diagprim = null;
                db.Configuration.LazyLoadingEnabled = false;
                //return db.Concurso_Plazas.Where(x => x.pad_plaza_id == id).OrderBy(x => x.pad_f_antig).ToList();
                string query = "  SELECT *  FROM [coleg318_].[Admin].[diag_primario]";
                diagprim = db.Database.SqlQuery<DiagprimCLS>(query).ToList();
                return diagprim;
            }
        }

        [Route("api/Diagnostico/{id}")]
        [HttpGet]
        public HttpResponseMessage GetDiagnostico(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var diagnostico = db.pac_diagnostico.FirstOrDefault(x => x.pac_diag_pac_id == id);
                //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                if (diagnostico != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, diagnostico);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }


        [Route("api/Diagnosticoinsert")]
        [HttpPost]
        public HttpResponseMessage Post(DiagnosticoCLS diagnosticoCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_diagnostico Diagnostico = new pac_diagnostico();
                    DateTime date = DateTime.Parse(diagnosticoCLS.pac_diag_fec_seguimiento);

                    Console.WriteLine(diagnosticoCLS.pac_diag_fec_seguimiento);
                    Console.WriteLine(date);
                    Diagnostico.pac_diag_pac_id = diagnosticoCLS.pac_diag_pac_id;
                    Diagnostico.pac_diag_perfilcog = diagnosticoCLS.pac_diag_perfilcog;
                    Diagnostico.pac_diag_pruebaspsi = diagnosticoCLS.pac_diag_pruebaspsi;
                    Diagnostico.pac_diag_diagnostico = diagnosticoCLS.pac_diag_diagnostico;
                    Diagnostico.pac_diag_primario = diagnosticoCLS.pac_diag_primario;
                    Diagnostico.pac_diag_obj_integral = diagnosticoCLS.pac_diag_obj_integral;
                    Diagnostico.pac_diag_obj_especifico = diagnosticoCLS.pac_diag_obj_especifico;
                    Diagnostico.pac_diag_especifico = diagnosticoCLS.pac_diag_especifico;
                    Diagnostico.pac_diag_pronostico = diagnosticoCLS.pac_diag_pronostico;
                    Diagnostico.pac_diag_modelo_tera = diagnosticoCLS.pac_diag_modelo_tera;
                    Diagnostico.pac_diag_motivo_alta = diagnosticoCLS.pac_diag_motivo_alta;
                    Diagnostico.pac_diag_fec_seguimiento = date;


                    db.pac_diagnostico.Add(Diagnostico);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, diagnosticoCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Diagnosticoupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, DiagnosticoCLS diagnosticoCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_diagnostico Diagnostico = new pac_diagnostico();
                    Diagnostico = db.pac_diagnostico.Where(p => p.pac_diag_id.Equals(id)).First();
                    if (Diagnostico == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Diagnostico  no encontrado");
                    }
                    else
                    {
                        Console.WriteLine(diagnosticoCLS.pac_diag_fec_seguimiento);
                        DateTime date = DateTime.Parse(diagnosticoCLS.pac_diag_fec_seguimiento);
                        Console.WriteLine(date);
                        Diagnostico.pac_diag_pac_id = diagnosticoCLS.pac_diag_pac_id;
                        Diagnostico.pac_diag_perfilcog = diagnosticoCLS.pac_diag_perfilcog;
                        Diagnostico.pac_diag_pruebaspsi = diagnosticoCLS.pac_diag_pruebaspsi;
                        Diagnostico.pac_diag_diagnostico = diagnosticoCLS.pac_diag_diagnostico;
                        Diagnostico.pac_diag_primario = diagnosticoCLS.pac_diag_primario;
                        Diagnostico.pac_diag_obj_integral = diagnosticoCLS.pac_diag_obj_integral;
                        Diagnostico.pac_diag_obj_especifico = diagnosticoCLS.pac_diag_obj_especifico;
                        Diagnostico.pac_diag_especifico = diagnosticoCLS.pac_diag_especifico;
                        Diagnostico.pac_diag_pronostico = diagnosticoCLS.pac_diag_pronostico;
                        Diagnostico.pac_diag_modelo_tera = diagnosticoCLS.pac_diag_modelo_tera;
                        Diagnostico.pac_diag_motivo_alta = diagnosticoCLS.pac_diag_motivo_alta;
                        Diagnostico.pac_diag_fec_seguimiento = date;


                        // db.pacientes.Add(Pacientes);
                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, diagnosticoCLS);
                        return Mensaje;

                    }

                }

            }
            catch (Exception ex)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(ex.Message);
                //errorWriter.WriteLine(usageText);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorWriter.ToString());
            }

        }

        [Route("api/DiagnosticoDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_diagnostico.FirstOrDefault(e => e.pac_diag_id.Equals(id));
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                           "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_diagnostico.Remove(entity);
                        dbContext.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}