using api.colegio.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.colegio.Controllers
{
    public class MaritalesController : ApiController
    {
        [Route("api/Marital/{id}")]
        [HttpGet]
        public HttpResponseMessage GetMarital(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var mental = db.pac_datos_maritales.FirstOrDefault(x => x.pac_maritales_pac_id == id);
                //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                if (mental != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, mental);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }


        [Route("api/Maritalinsert")]
        [HttpPost]
        public HttpResponseMessage Post(MaritalCLS maritalCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_datos_maritales Maritales = new pac_datos_maritales();
                    Maritales.pac_maritales_pac_id = maritalCLS.pac_maritales_pac_id;
                    Maritales.pac_maritales_noviazgo = maritalCLS.pac_maritales_noviazgo;
                    Maritales.pac_maritales_expnoviazgo = maritalCLS.pac_maritales_expnoviazgo;
                    Maritales.pac_maritales_desc_conyuge = maritalCLS.pac_maritales_desc_conyuge;
                    Maritales.pac_maritales_eventos = maritalCLS.pac_maritales_eventos;
                    Maritales.pac_maritales_numhijos = maritalCLS.pac_maritales_numhijos;
                    Maritales.pac_maritales_interaccion = maritalCLS.pac_maritales_interaccion;
                    Maritales.pac_maritales_familia = maritalCLS.pac_maritales_familia;

                    db.pac_datos_maritales.Add(Maritales);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, maritalCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Maritalupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, MaritalCLS maritalCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_datos_maritales Maritales = new pac_datos_maritales();
                    Maritales = db.pac_datos_maritales.Where(p => p.pac_maritales_id.Equals(id)).First();
                    if (Maritales == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "registro  no encontrado");
                    }
                    else
                    {
                        Maritales.pac_maritales_pac_id = maritalCLS.pac_maritales_pac_id;
                        Maritales.pac_maritales_noviazgo = maritalCLS.pac_maritales_noviazgo;
                        Maritales.pac_maritales_expnoviazgo = maritalCLS.pac_maritales_expnoviazgo;
                        Maritales.pac_maritales_desc_conyuge = maritalCLS.pac_maritales_desc_conyuge;
                        Maritales.pac_maritales_eventos = maritalCLS.pac_maritales_eventos;
                        Maritales.pac_maritales_numhijos = maritalCLS.pac_maritales_numhijos;
                        Maritales.pac_maritales_interaccion = maritalCLS.pac_maritales_interaccion;
                        Maritales.pac_maritales_familia = maritalCLS.pac_maritales_familia;

                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, maritalCLS);
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

        [Route("api/MaritalDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_datos_maritales.FirstOrDefault(e => e.pac_maritales_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_datos_maritales.Remove(entity);
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