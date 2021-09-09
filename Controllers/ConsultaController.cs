using api.colegio.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.colegio.Controllers
{
    public class ConsultaController : ApiController
    {
        [Route("api/Consulta/{id}")]
        [HttpGet]
        public HttpResponseMessage GetConsulta(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var cons = db.pac_consulta.FirstOrDefault(x => x.pac_cons_pac_id == id);
                //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                if (cons != null)
                {
                    //var dateTime = DateTime.Now;
                    //dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    //pac.paciente_fec_nac.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    return Request.CreateResponse(HttpStatusCode.OK, cons);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }


        [Route("api/Consultainsert")]
        [HttpPost]
        public HttpResponseMessage Post(ConsultaCLS consCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_consulta Consulta = new pac_consulta();


                    Consulta.pac_cons_pac_id = consCLS.pac_cons_pac_id;
                    Consulta.pac_cons_problema = consCLS.pac_cons_problema;
                    Consulta.pac_cons_historia = consCLS.pac_cons_historia;
                    Consulta.pac_cons_referencia = consCLS.pac_cons_referencia;
                    Consulta.pac_cons_experiencia = consCLS.pac_cons_experiencia;

                    db.pac_consulta.Add(Consulta);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, consCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Consultaupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, ConsultaCLS consCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_consulta Consulta = new pac_consulta();
                    Consulta = db.pac_consulta.Where(p => p.pac_cons_id.Equals(id)).First();
                    if (Consulta == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Paciente  no encontrado");
                    }
                    else
                    {
                        Consulta.pac_cons_pac_id = consCLS.pac_cons_pac_id;
                        Consulta.pac_cons_problema = consCLS.pac_cons_problema;
                        Consulta.pac_cons_historia = consCLS.pac_cons_historia;
                        Consulta.pac_cons_referencia = consCLS.pac_cons_referencia;
                        Consulta.pac_cons_experiencia = consCLS.pac_cons_experiencia;

                        // db.pacientes.Add(Pacientes);
                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, consCLS);
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


        [Route("api/ConsultaDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_consulta.FirstOrDefault(e => e.pac_cons_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_consulta.Remove(entity);
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