using api.colegio.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
namespace api.colegio.Controllers
{
    public class PsicoterapiaController : ApiController
    {

   


        [Route("api/Sessiones/{id}")]
        [HttpGet]
        public List<pac_psicoterapia> GetSessiones(int id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                List<pac_psicoterapia> pac = null;

                db.Configuration.LazyLoadingEnabled = false;
                pac = db.pac_psicoterapia.OrderBy(x=>x.pac_psico_desc).Where(x=>x.pac_psico_pac_id==id).ToList();
                return pac;
            }
        }

        [Route("api/Nombre/{id}")]
        [HttpGet]
        public string GetNombre(int id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                try {

                    if (id > 0)
                    {
                        db.Configuration.LazyLoadingEnabled = false;
                        // var user = db.Database.SqlQuery<string>("SELECT paciente_nombre FROM [coleg318_].[Admin].[pacientes] where  paciente_id=@id  ", new SqlParameter("id", id)).ToString();
                        string vend = (from vnd in db.pacientes
                                       where vnd.paciente_id == id
                                       select vnd.paciente_nombre).FirstOrDefault().ToString();
                        if (vend == "")
                        {

                            return "";
                        }
                        else
                        {
                            return vend;
                        }
                    }
                    else {
                        return "";
                    }
                 

                    
                }

                catch (Exception ex)
                {
                    string error = "";
                    Console.WriteLine(ex.InnerException.Message);
                    error = ex.InnerException.Message.ToString();
                    return error;
                }


            }
        }

        [Route("api/Countsessiones/{id}")]
        [HttpGet]
        public int GetCountSession(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

               db.Configuration.LazyLoadingEnabled = false;
               int pac = db.pac_psicoterapia.Count(x => x.pac_psico_pac_id == id);
               return pac;

            }
        }


        [Route("api/Session/{id}")]
        [HttpGet]
        public HttpResponseMessage GetSession(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var pac = db.pac_psicoterapia.FirstOrDefault(x => x.pac_psico_id == id);
                //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                if (pac != null)
                {



                    var dateTime = DateTime.Now;
                    dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    //pac.paciente_fec_nac.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);


                    return Request.CreateResponse(HttpStatusCode.OK, pac);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }

        [Route("api/Sessionesinsert")]
        [HttpPost]
        public HttpResponseMessage Post(PsicoterapiaCLS psicoterapiaCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_psicoterapia Psicoterapia = new pac_psicoterapia();


                    Psicoterapia.pac_psico_pac_id = psicoterapiaCLS.pac_psico_pac_id;
                    Psicoterapia.pac_psico_desc = psicoterapiaCLS.pac_psico_desc;
                    Psicoterapia.pac_psico_texto = psicoterapiaCLS.pac_psico_texto;
                    //Psicoterapia.pac_psico_fecha = psicoterapiaCLS.pac_psico_fecha;
                    Psicoterapia.pac_psico_fecha = DateTime.Now;
                    Psicoterapia.pac_psico_intervencion = psicoterapiaCLS.pac_psico_intervencion;
                    Psicoterapia.pac_psico_tecnicas = psicoterapiaCLS.pac_psico_tecnicas;
                    Psicoterapia.pac_psico_resultados = psicoterapiaCLS.pac_psico_resultados;
                    Psicoterapia.pac_psico_recomenda = psicoterapiaCLS.pac_psico_recomenda;
                    Psicoterapia.pac_psico_observaciones = psicoterapiaCLS.pac_psico_observaciones;


                    db.pac_psicoterapia.Add(Psicoterapia);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, psicoterapiaCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Sessionesupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, PsicoterapiaCLS psicoterapiaCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_psicoterapia Psicoterapia = new pac_psicoterapia();
                    Psicoterapia = db.pac_psicoterapia.Where(p => p.pac_psico_id.Equals(id)).First();
                    if (Psicoterapia == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Session  no encontrada");
                    }
                    else
                    {
                        Psicoterapia.pac_psico_pac_id = psicoterapiaCLS.pac_psico_pac_id;
                        Psicoterapia.pac_psico_desc = psicoterapiaCLS.pac_psico_desc;
                        Psicoterapia.pac_psico_texto = psicoterapiaCLS.pac_psico_texto;
                        Psicoterapia.pac_psico_fecha = psicoterapiaCLS.pac_psico_fecha;
                        Psicoterapia.pac_psico_intervencion = psicoterapiaCLS.pac_psico_intervencion;
                        Psicoterapia.pac_psico_tecnicas = psicoterapiaCLS.pac_psico_tecnicas;
                        Psicoterapia.pac_psico_resultados = psicoterapiaCLS.pac_psico_resultados;
                        Psicoterapia.pac_psico_recomenda = psicoterapiaCLS.pac_psico_recomenda;
                        Psicoterapia.pac_psico_observaciones = psicoterapiaCLS.pac_psico_observaciones;



                        // db.pacientes.Add(Pacientes);
                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, psicoterapiaCLS);
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

        //[Route("api/SessionDelete/{id}")]
        //[HttpDelete]
        //public HttpResponseMessage Delete(int id)
        //{

        //    try
        //    {
        //        //id = userCLS.id;
        //        using (coleg318_Entities1 db = new coleg318_Entities1())
        //        {
        //            pac_psicoterapia Psicoterapia = new pac_psicoterapia();
        //            Psicoterapia = db.pac_psicoterapia.Where(p => p.pac_psico_id.Equals(id)).First();
        //            if (Psicoterapia == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Session  no encontrada");
        //            }
        //            else
        //            {
        //                //Psicoterapia.pac_psico_pac_id = psicoterapiaCLS.pac_psico_pac_id;
        //                //Psicoterapia.pac_psico_desc = psicoterapiaCLS.pac_psico_desc;
        //                //Psicoterapia.pac_psico_texto = psicoterapiaCLS.pac_psico_texto;


        //                // db.pacientes.Add(Pacientes);
        //                db.pac_psicoterapia.Remove(Psicoterapia);
        //                var Mensaje = Request.CreateResponse(HttpStatusCode.Created,"Eliminado");
        //                return Mensaje;

        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        TextWriter errorWriter = Console.Error;
        //        errorWriter.WriteLine(ex.Message);
        //        //errorWriter.WriteLine(usageText);
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorWriter.ToString());
        //    }

        //}

        [Route("api/SessionDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_psicoterapia.FirstOrDefault(e => e.pac_psico_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_psicoterapia.Remove(entity);
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