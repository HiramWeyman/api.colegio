using api.colegio.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.colegio.Controllers
{
    public class AjustessocialesController : ApiController
    {
        [Route("api/Ajustes/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAjustes(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var ajustes = db.pac_ajustes_sociales.FirstOrDefault(x => x.pac_ajustes_pac_id == id);
                //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                if (ajustes != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, ajustes);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }


        [Route("api/Ajustesinsert")]
        [HttpPost]
        public HttpResponseMessage Post(AjustesCLS ajustesCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_ajustes_sociales Ajustes = new pac_ajustes_sociales();
                    Ajustes.pac_ajustes_pac_id = ajustesCLS.pac_ajustes_pac_id;
                    Ajustes.pac_ajustes_relacionesint = ajustesCLS.pac_ajustes_relacionesint;
                    Ajustes.pac_ajustes_amistades = ajustesCLS.pac_ajustes_amistades;
                    Ajustes.pac_ajustes_sentir = ajustesCLS.pac_ajustes_sentir;
                    Ajustes.pac_ajustes_novias = ajustesCLS.pac_ajustes_novias;


                    db.pac_ajustes_sociales.Add(Ajustes);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, ajustesCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Ajustesupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, AjustesCLS ajustesCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_ajustes_sociales Ajustes = new pac_ajustes_sociales();
                    Ajustes = db.pac_ajustes_sociales.Where(p => p.pac_ajustes_id.Equals(id)).First();
                    if (Ajustes == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "registro  no encontrado");
                    }
                    else
                    {
                        Ajustes.pac_ajustes_pac_id = ajustesCLS.pac_ajustes_pac_id;
                        Ajustes.pac_ajustes_relacionesint = ajustesCLS.pac_ajustes_relacionesint;
                        Ajustes.pac_ajustes_amistades = ajustesCLS.pac_ajustes_amistades;
                        Ajustes.pac_ajustes_sentir = ajustesCLS.pac_ajustes_sentir;
                        Ajustes.pac_ajustes_novias = ajustesCLS.pac_ajustes_novias;

                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, ajustesCLS);
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

        [Route("api/AjustesDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_ajustes_sociales.FirstOrDefault(e => e.pac_ajustes_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_ajustes_sociales.Remove(entity);
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