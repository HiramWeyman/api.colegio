using api.colegio.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace api.colegio.Controllers
{
    public class PacientedescController : ApiController
    {
        // GET: Pacientedesc
        [Route("api/pacdescripcion/{id}")]
        [HttpGet]
        public HttpResponseMessage GetPacienteDesc(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var pac = db.pac_descrip.FirstOrDefault(x => x.pac_paciente_id == id);
                //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                if (pac != null)
                {
                    //var dateTime = DateTime.Now;
                    //dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    //pac.paciente_fec_nac.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    return Request.CreateResponse(HttpStatusCode.OK, pac);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }

        [Route("api/Descinsert")]
        [HttpPost]
        public HttpResponseMessage Post(PacDescCLS pacCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_descrip Pacientes = new pac_descrip();


                    Pacientes.pac_paciente_id = pacCLS.pac_paciente_id;
                    Pacientes.pac_desc_aspectos = pacCLS.pac_desc_aspectos;
                    Pacientes.pac_desc_porte = pacCLS.pac_desc_porte;
                    Pacientes.pac_desc_vestimenta = pacCLS.pac_desc_vestimenta;
                    Pacientes.pac_desc_movimientos = pacCLS.pac_desc_movimientos;
                    Pacientes.pac_desc_afecto = pacCLS.pac_desc_afecto;
        

                    db.pac_descrip.Add(Pacientes);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, pacCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Descupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, PacDescCLS pacCLS)
        {
        
            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_descrip Pacientes = new pac_descrip();
                    Pacientes = db.pac_descrip.Where(p => p.pac_desc_id.Equals(id)).First();
                    if (Pacientes == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Paciente  no encontrado");
                    }
                    else
                    {
                        Pacientes.pac_paciente_id = pacCLS.pac_paciente_id;
                        Pacientes.pac_desc_aspectos = pacCLS.pac_desc_aspectos;
                        Pacientes.pac_desc_porte = pacCLS.pac_desc_porte;
                        Pacientes.pac_desc_vestimenta = pacCLS.pac_desc_vestimenta;
                        Pacientes.pac_desc_movimientos = pacCLS.pac_desc_movimientos;
                        Pacientes.pac_desc_afecto = pacCLS.pac_desc_afecto;

                        // db.pacientes.Add(Pacientes);
                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, pacCLS);
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


        [Route("api/DescDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_descrip.FirstOrDefault(e => e.pac_desc_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_descrip.Remove(entity);
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