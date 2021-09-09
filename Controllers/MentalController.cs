using api.colegio.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.colegio.Controllers
{
    public class MentalController : ApiController
    {
        [Route("api/Mental/{id}")]
        [HttpGet]
        public HttpResponseMessage GetMental(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var maritales = db.pac_estado_mental.FirstOrDefault(x => x.pac_estado_pac_id == id);
                //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                if (maritales != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, maritales);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }


        [Route("api/Mentalinsert")]
        [HttpPost]
        public HttpResponseMessage Post(MentalCLS mentalCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_estado_mental Mental = new pac_estado_mental();
                    Mental.pac_estado_pac_id = mentalCLS.pac_estado_pac_id;
                    Mental.pac_estado_conciencia = mentalCLS.pac_estado_conciencia;
                    Mental.pac_estado_orientacion = mentalCLS.pac_estado_orientacion;
                    Mental.pac_estadoafectividad = mentalCLS.pac_estadoafectividad;
                    Mental.pac_estado_asociaciones = mentalCLS.pac_estado_asociaciones;
                    Mental.pac_estado_pensamiento = mentalCLS.pac_estado_pensamiento;
                    Mental.pac_estado_percepcion = mentalCLS.pac_estado_percepcion;
                    Mental.pac_estado_funcionamiento = mentalCLS.pac_estado_funcionamiento;
                    Mental.pac_estado_juicio = mentalCLS.pac_estado_juicio;
                    Mental.pac_estado_insight = mentalCLS.pac_estado_insight;
                    Mental.pac_estado_madurez = mentalCLS.pac_estado_madurez;
       
                    db.pac_estado_mental.Add(Mental);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, mentalCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Mentalupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, MentalCLS mentalCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_estado_mental Mental = new pac_estado_mental();
                    Mental = db.pac_estado_mental.Where(p => p.pac_estado_id.Equals(id)).First();
                    if (Mental == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "registro  no encontrado");
                    }
                    else
                    {
                        Mental.pac_estado_pac_id = mentalCLS.pac_estado_pac_id;
                        Mental.pac_estado_conciencia = mentalCLS.pac_estado_conciencia;
                        Mental.pac_estado_orientacion = mentalCLS.pac_estado_orientacion;
                        Mental.pac_estadoafectividad = mentalCLS.pac_estadoafectividad;
                        Mental.pac_estado_asociaciones = mentalCLS.pac_estado_asociaciones;
                        Mental.pac_estado_pensamiento = mentalCLS.pac_estado_pensamiento;
                        Mental.pac_estado_percepcion = mentalCLS.pac_estado_percepcion;
                        Mental.pac_estado_funcionamiento = mentalCLS.pac_estado_funcionamiento;
                        Mental.pac_estado_juicio = mentalCLS.pac_estado_juicio;
                        Mental.pac_estado_insight = mentalCLS.pac_estado_insight;
                        Mental.pac_estado_madurez = mentalCLS.pac_estado_madurez;

                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, mentalCLS);
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

        [Route("api/MentalDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_estado_mental.FirstOrDefault(e => e.pac_estado_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_estado_mental.Remove(entity);
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