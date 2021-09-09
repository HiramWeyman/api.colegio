using api.colegio.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.colegio.Controllers
{
    public class HistoriaController : ApiController
    {
        [Route("api/Historia/{id}")]
        [HttpGet]
        public HttpResponseMessage GetHistoria(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var historia = db.pac_historia_per.FirstOrDefault(x => x.pac_hist_pac_id == id);
                //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                if (historia != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, historia);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }


        [Route("api/Historiainsert")]
        [HttpPost]
        public HttpResponseMessage Post(HistoriaCLS historiaCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_historia_per Historia = new pac_historia_per();
                    Historia.pac_hist_pac_id = historiaCLS.pac_hist_pac_id;
                    Historia.pac_hist_embarazo = historiaCLS.pac_hist_embarazo;
                    Historia.pac_hist_inicio = historiaCLS.pac_hist_inicio;
                    Historia.pac_hist_infancia = historiaCLS.pac_hist_infancia;
                    Historia.pac_hist_nines_re = historiaCLS.pac_hist_nines_re;
                    Historia.pac_hist_adolecencia = historiaCLS.pac_hist_adolecencia;
                    Historia.pac_hist_edad_ad = historiaCLS.pac_hist_edad_ad;
                    Historia.pac_hist_edad_av = historiaCLS.pac_hist_edad_av;
                    Historia.pac_hist_alimentacion = historiaCLS.pac_hist_alimentacion;
                    Historia.pac_hist_sueno = historiaCLS.pac_hist_sueno;
                    Historia.pac_hist_enfermedades = historiaCLS.pac_hist_enfermedades;
                    Historia.pac_hist_lesiones = historiaCLS.pac_hist_lesiones;
                    Historia.pac_hist_salud_act = historiaCLS.pac_hist_salud_act;
                    db.pac_historia_per.Add(Historia);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, historiaCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Historiaupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, HistoriaCLS historiaCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_historia_per Historia = new pac_historia_per();
                    Historia = db.pac_historia_per.Where(p => p.pac_hist_id.Equals(id)).First();
                    if (Historia == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "registro  no encontrado");
                    }
                    else
                    {
                        Historia.pac_hist_pac_id = historiaCLS.pac_hist_pac_id;
                        Historia.pac_hist_embarazo = historiaCLS.pac_hist_embarazo;
                        Historia.pac_hist_inicio = historiaCLS.pac_hist_inicio;
                        Historia.pac_hist_infancia = historiaCLS.pac_hist_infancia;
                        Historia.pac_hist_nines_re = historiaCLS.pac_hist_nines_re;
                        Historia.pac_hist_adolecencia = historiaCLS.pac_hist_adolecencia;
                        Historia.pac_hist_edad_ad = historiaCLS.pac_hist_edad_ad;
                        Historia.pac_hist_edad_av = historiaCLS.pac_hist_edad_av;
                        Historia.pac_hist_alimentacion = historiaCLS.pac_hist_alimentacion;
                        Historia.pac_hist_sueno = historiaCLS.pac_hist_sueno;
                        Historia.pac_hist_enfermedades = historiaCLS.pac_hist_enfermedades;
                        Historia.pac_hist_lesiones = historiaCLS.pac_hist_lesiones;
                        Historia.pac_hist_salud_act = historiaCLS.pac_hist_salud_act;
                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, historiaCLS);
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

        [Route("api/HistoriaDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_historia_per.FirstOrDefault(e => e.pac_hist_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_historia_per.Remove(entity);
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