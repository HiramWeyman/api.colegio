using api.colegio.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.colegio.Controllers
{
    public class SimismoController : ApiController
    {
        [Route("api/Simismo/{id}")]
        [HttpGet]
        public HttpResponseMessage GetMental(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var simismo = db.pac_desc_simismo.FirstOrDefault(x => x.pac_simismo_pac_id == id);
                //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                if (simismo != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, simismo);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }


        [Route("api/Simismoinsert")]
        [HttpPost]
        public HttpResponseMessage Post(SimismoCLS simismoCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_desc_simismo Simismo = new pac_desc_simismo();
                    Simismo.pac_simismo_pac_id = simismoCLS.pac_simismo_pac_id;
                    Simismo.pac_simismo_comoseve = simismoCLS.pac_simismo_comoseve;
                    Simismo.pac_simismo_comocree = simismoCLS.pac_simismo_comocree;
                    Simismo.pac_simismo_preocupaciones = simismoCLS.pac_simismo_preocupaciones;
                    Simismo.pac_simismo_metas = simismoCLS.pac_simismo_metas;
                    Simismo.pac_simismo_gustaria = simismoCLS.pac_simismo_gustaria;
                    Simismo.pac_simismo_crisis = simismoCLS.pac_simismo_crisis;
                    Simismo.pac_simismo_triunfo_frac = simismoCLS.pac_simismo_triunfo_frac;
                    Simismo.pac_simismo_siente_problem = simismoCLS.pac_simismo_siente_problem;
       
                    db.pac_desc_simismo.Add(Simismo);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, simismoCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Simismoupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, SimismoCLS simismoCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_desc_simismo Simismo = new pac_desc_simismo();
                    Simismo = db.pac_desc_simismo.Where(p => p.pac_simismo_id.Equals(id)).First();
                    if (Simismo == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "registro  no encontrado");
                    }
                    else
                    {
                        Simismo.pac_simismo_pac_id = simismoCLS.pac_simismo_pac_id;
                        Simismo.pac_simismo_comoseve = simismoCLS.pac_simismo_comoseve;
                        Simismo.pac_simismo_comocree = simismoCLS.pac_simismo_comocree;
                        Simismo.pac_simismo_preocupaciones = simismoCLS.pac_simismo_preocupaciones;
                        Simismo.pac_simismo_metas = simismoCLS.pac_simismo_metas;
                        Simismo.pac_simismo_gustaria = simismoCLS.pac_simismo_gustaria;
                        Simismo.pac_simismo_crisis = simismoCLS.pac_simismo_crisis;
                        Simismo.pac_simismo_triunfo_frac = simismoCLS.pac_simismo_triunfo_frac;
                        Simismo.pac_simismo_siente_problem = simismoCLS.pac_simismo_siente_problem;

                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, simismoCLS);
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

        [Route("api/SimismoDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_desc_simismo.FirstOrDefault(e => e.pac_simismo_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_desc_simismo.Remove(entity);
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