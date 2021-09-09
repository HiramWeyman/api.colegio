using api.colegio.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.colegio.Controllers
{
    public class RecuerdosController : ApiController
    {
        [Route("api/Recuerdos/{id}")]
        [HttpGet]
        public HttpResponseMessage GetRecuerdos(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var situacion = db.pac_recuerdos_tempranos.FirstOrDefault(x => x.pac_recuerdos_pac_id == id);
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


        [Route("api/Recuerdosinsert")]
        [HttpPost]
        public HttpResponseMessage Post(RecuerdosCLS recuerdosCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_recuerdos_tempranos Recuerdos = new pac_recuerdos_tempranos();
                    Recuerdos.pac_recuerdos_pac_id = recuerdosCLS.pac_recuerdos_pac_id;
                    Recuerdos.pac_recuerdos_temp = recuerdosCLS.pac_recuerdos_temp;
                    db.pac_recuerdos_tempranos.Add(Recuerdos);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, recuerdosCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Recuerdosupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, RecuerdosCLS recuerdosCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_recuerdos_tempranos Recuerdos = new pac_recuerdos_tempranos();
                    Recuerdos = db.pac_recuerdos_tempranos.Where(p => p.pac_recuerdos_id.Equals(id)).First();
                    if (Recuerdos == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Paciente  no encontrado");
                    }
                    else
                    {
                        Recuerdos.pac_recuerdos_temp = recuerdosCLS.pac_recuerdos_temp;
                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, recuerdosCLS);
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

        [Route("api/RecuerdosDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_recuerdos_tempranos.FirstOrDefault(e => e.pac_recuerdos_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_recuerdos_tempranos.Remove(entity);
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