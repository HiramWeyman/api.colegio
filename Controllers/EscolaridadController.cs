using api.colegio.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.colegio.Controllers
{
    public class EscolaridadController : ApiController
    {
        [Route("api/Escolar/{id}")]
        [HttpGet]
        public HttpResponseMessage GetEscolar(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var escolar = db.pac_escolaridad.FirstOrDefault(x => x.pac_escolaridad_pac_id == id);
                //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                if (escolar != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, escolar);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }


        [Route("api/Escolarinsert")]
        [HttpPost]
        public HttpResponseMessage Post(EscolarCLS escolarCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_escolaridad Escolar = new pac_escolaridad();
                    Escolar.pac_escolaridad_pac_id = escolarCLS.pac_escolaridad_pac_id;
                    Escolar.pac_escolaridad_primaria = escolarCLS.pac_escolaridad_primaria;
                    Escolar.pac_escolaridad_secundaria = escolarCLS.pac_escolaridad_secundaria;
                    Escolar.pac_escolaridad_preparatoria = escolarCLS.pac_escolaridad_preparatoria;
                    Escolar.pac_escolaridad_universidad = escolarCLS.pac_escolaridad_universidad;
                    Escolar.pac_escolaridad_otras = escolarCLS.pac_escolaridad_otras;
                    Escolar.pac_escolaridad_relacion = escolarCLS.pac_escolaridad_relacion;
                    Escolar.pac_escolaridad_rendimiento = escolarCLS.pac_escolaridad_rendimiento;
                    Escolar.pac_escolaridad_cambios = escolarCLS.pac_escolaridad_cambios;
                    Escolar.pac_escolaridad_evaluacion = escolarCLS.pac_escolaridad_evaluacion;
               
                    db.pac_escolaridad.Add(Escolar);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, escolarCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Escolarupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, EscolarCLS escolarCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_escolaridad Escolar = new pac_escolaridad();
                    Escolar = db.pac_escolaridad.Where(p => p.pac_escolaridad_id.Equals(id)).First();
                    if (Escolar == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "registro  no encontrado");
                    }
                    else
                    {
                        Escolar.pac_escolaridad_pac_id = escolarCLS.pac_escolaridad_pac_id;
                        Escolar.pac_escolaridad_primaria = escolarCLS.pac_escolaridad_primaria;
                        Escolar.pac_escolaridad_secundaria = escolarCLS.pac_escolaridad_secundaria;
                        Escolar.pac_escolaridad_preparatoria = escolarCLS.pac_escolaridad_preparatoria;
                        Escolar.pac_escolaridad_universidad = escolarCLS.pac_escolaridad_universidad;
                        Escolar.pac_escolaridad_otras = escolarCLS.pac_escolaridad_otras;
                        Escolar.pac_escolaridad_relacion = escolarCLS.pac_escolaridad_relacion;
                        Escolar.pac_escolaridad_rendimiento = escolarCLS.pac_escolaridad_rendimiento;
                        Escolar.pac_escolaridad_cambios = escolarCLS.pac_escolaridad_cambios;
                        Escolar.pac_escolaridad_evaluacion = escolarCLS.pac_escolaridad_evaluacion;
                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, escolarCLS);
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

        [Route("api/EscolarDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_escolaridad.FirstOrDefault(e => e.pac_escolaridad_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_escolaridad.Remove(entity);
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}