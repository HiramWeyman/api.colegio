using api.colegio.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.colegio.Controllers
{
    public class SituacionactController : ApiController
    {
        [Route("api/Situacion/{id}")]
        [HttpGet]
        public HttpResponseMessage GetSituacion(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var situacion = db.pac_situacion_act.FirstOrDefault(x => x.pac_situacion_pac_id == id);
                //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                if (situacion != null)
                {
                    //var dateTime = DateTime.Now;
                    //dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    //pac.paciente_fec_nac.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    return Request.CreateResponse(HttpStatusCode.OK, situacion);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }


        [Route("api/Situacioninsert")]
        [HttpPost]
        public HttpResponseMessage Post(SituacionCLS situacionCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_situacion_act Situacion = new pac_situacion_act();


                    Situacion.pac_situacion_pac_id = situacionCLS.pac_situacion_pac_id;
                    Situacion.pac_situacion_dia = situacionCLS.pac_situacion_dia;
                    Situacion.pac_situacion_esp = situacionCLS.pac_situacion_esp;
                  
                 

                    db.pac_situacion_act.Add(Situacion);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, situacionCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Situacionupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, SituacionCLS situacionCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_situacion_act Situacion = new pac_situacion_act();
                    Situacion = db.pac_situacion_act.Where(p => p.pac_situacion_id.Equals(id)).First();
                    if (Situacion == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Paciente  no encontrado");
                    }
                    else
                    {
                        Situacion.pac_situacion_pac_id = situacionCLS.pac_situacion_pac_id;
                        Situacion.pac_situacion_dia = situacionCLS.pac_situacion_dia;
                        Situacion.pac_situacion_esp = situacionCLS.pac_situacion_esp;
                    

                        // db.pacientes.Add(Pacientes);
                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, situacionCLS);
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

        [Route("api/SituacionDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_situacion_act.FirstOrDefault(e => e.pac_situacion_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_situacion_act.Remove(entity);
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