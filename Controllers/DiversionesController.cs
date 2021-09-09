using api.colegio.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.colegio.Controllers
{
    public class DiversionesController : ApiController
    {
        [Route("api/Diversion/{id}")]
        [HttpGet]
        public HttpResponseMessage GetDiversion(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var diversion = db.pac_diversion_intereses.FirstOrDefault(x => x.pac_diversion_pac_id == id);
                //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                if (diversion != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, diversion);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }


        [Route("api/Diversioninsert")]
        [HttpPost]
        public HttpResponseMessage Post(DiversionCLS diversionCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_diversion_intereses Diversion = new pac_diversion_intereses();
                    Diversion.pac_diversion_pac_id = diversionCLS.pac_diversion_pac_id;
                    Diversion.pac_diversion_lectura = diversionCLS.pac_diversion_lectura;
                    Diversion.pac_diversion_practicas = diversionCLS.pac_diversion_practicas;
                    Diversion.pac_diversion_pertenencia = diversionCLS.pac_diversion_pertenencia;
                 

                    db.pac_diversion_intereses.Add(Diversion);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, diversionCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Diversionupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, DiversionCLS diversionCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_diversion_intereses Diversion = new pac_diversion_intereses();
                    Diversion = db.pac_diversion_intereses.Where(p => p.pac_diversion_id.Equals(id)).First();
                    if (Diversion == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "registro  no encontrado");
                    }
                    else
                    {
                        Diversion.pac_diversion_pac_id = diversionCLS.pac_diversion_pac_id;
                        Diversion.pac_diversion_lectura = diversionCLS.pac_diversion_lectura;
                        Diversion.pac_diversion_practicas = diversionCLS.pac_diversion_practicas;
                        Diversion.pac_diversion_pertenencia = diversionCLS.pac_diversion_pertenencia;

                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, diversionCLS);
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

        [Route("api/DiversionDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_diversion_intereses.FirstOrDefault(e => e.pac_diversion_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_diversion_intereses.Remove(entity);
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