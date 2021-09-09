using api.colegio.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.colegio.Controllers
{
    public class DesarrolloController : ApiController
    {
        [Route("api/Desarrollo/{id}")]
        [HttpGet]
        public HttpResponseMessage GetDiversion(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var desarrollo = db.pac_desarrollo_sexual.FirstOrDefault(x => x.pac_desarrollo_pac_id == id);
                //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                if (desarrollo != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, desarrollo);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }


        [Route("api/Desarrolloinsert")]
        [HttpPost]
        public HttpResponseMessage Post(DesarrolloCLS desarrolloCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_desarrollo_sexual Desarrollo = new pac_desarrollo_sexual();
                    Desarrollo.pac_desarrollo_pac_id = desarrolloCLS.pac_desarrollo_pac_id;
                    Desarrollo.pac_desarrollo_nociones = desarrolloCLS.pac_desarrollo_nociones;
                    Desarrollo.pac_desarrollo_contacto = desarrolloCLS.pac_desarrollo_contacto;
                    Desarrollo.pac_desarrollo_interes = desarrolloCLS.pac_desarrollo_interes;
                    Desarrollo.pac_desarrollo_fantasias = desarrolloCLS.pac_desarrollo_fantasias;
                    Desarrollo.pac_desarrollo_homosex = desarrolloCLS.pac_desarrollo_homosex;
                    Desarrollo.pac_desarrollo_relaciones = desarrolloCLS.pac_desarrollo_relaciones;
      
                    db.pac_desarrollo_sexual.Add(Desarrollo);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, desarrolloCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Desarrolloupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, DesarrolloCLS desarrolloCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_desarrollo_sexual Desarrollo = new pac_desarrollo_sexual();
                    Desarrollo = db.pac_desarrollo_sexual.Where(p => p.pac_desarrollo_id.Equals(id)).First();
                    if (Desarrollo == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "registro  no encontrado");
                    }
                    else
                    {
                        Desarrollo.pac_desarrollo_pac_id = desarrolloCLS.pac_desarrollo_pac_id;
                        Desarrollo.pac_desarrollo_nociones = desarrolloCLS.pac_desarrollo_nociones;
                        Desarrollo.pac_desarrollo_contacto = desarrolloCLS.pac_desarrollo_contacto;
                        Desarrollo.pac_desarrollo_interes = desarrolloCLS.pac_desarrollo_interes;
                        Desarrollo.pac_desarrollo_fantasias = desarrolloCLS.pac_desarrollo_fantasias;
                        Desarrollo.pac_desarrollo_homosex = desarrolloCLS.pac_desarrollo_homosex;
                        Desarrollo.pac_desarrollo_relaciones = desarrolloCLS.pac_desarrollo_relaciones;

                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, desarrolloCLS);
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

        [Route("api/DessarrolloDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_desarrollo_sexual.FirstOrDefault(e => e.pac_desarrollo_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_desarrollo_sexual.Remove(entity);
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