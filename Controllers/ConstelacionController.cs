using api.colegio.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.colegio.Controllers
{
    public class ConstelacionController : ApiController
    {
        [Route("api/Constelacion/{id}")]
        [HttpGet]
        public HttpResponseMessage GetConstelacion(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                var constelacion = db.pac_constelacion_fam.FirstOrDefault(x => x.pac_conste_paciene_id == id);
                //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                if (constelacion != null)
                {
                    //var dateTime = DateTime.Now;
                    //dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    //pac.paciente_fec_nac.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    return Request.CreateResponse(HttpStatusCode.OK, constelacion);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }


        [Route("api/Constelacioninsert")]
        [HttpPost]
        public HttpResponseMessage Post(ConstelacionCLS contelacionCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    pac_constelacion_fam Constelacion = new pac_constelacion_fam();


                    Constelacion.pac_conste_paciene_id = contelacionCLS.pac_conste_paciene_id;
                    Constelacion.pac_conste_texto = contelacionCLS.pac_conste_texto;
                    Constelacion.pac_conste_antecedentes = contelacionCLS.pac_conste_antecedentes;
                    Constelacion.pac_conste_desc_padre_madre = contelacionCLS.pac_conste_desc_padre_madre;
                    Constelacion.pac_conste_hermanos = contelacionCLS.pac_conste_hermanos;
                    Constelacion.pac_conste_rivalidades = contelacionCLS.pac_conste_rivalidades;
                    Constelacion.pac_conste_papel_fam = contelacionCLS.pac_conste_papel_fam;
                    Constelacion.pac_conste_uniones = contelacionCLS.pac_conste_uniones;
                    Constelacion.pac_conste_normas = contelacionCLS.pac_conste_normas;
                    Constelacion.pac_conste_cambios = contelacionCLS.pac_conste_cambios;

                    db.pac_constelacion_fam.Add(Constelacion);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, contelacionCLS);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Constelacionupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, ConstelacionCLS contelacionCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    pac_constelacion_fam Constelacion = new pac_constelacion_fam();
                    Constelacion = db.pac_constelacion_fam.Where(p => p.pac_conste_id.Equals(id)).First();
                    if (Constelacion == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Constelacion  no encontrada");
                    }
                    else
                    {
                        Constelacion.pac_conste_paciene_id = contelacionCLS.pac_conste_paciene_id;
                        Constelacion.pac_conste_texto = contelacionCLS.pac_conste_texto;
                        Constelacion.pac_conste_antecedentes = contelacionCLS.pac_conste_antecedentes;
                        Constelacion.pac_conste_desc_padre_madre = contelacionCLS.pac_conste_desc_padre_madre;
                        Constelacion.pac_conste_hermanos = contelacionCLS.pac_conste_hermanos;
                        Constelacion.pac_conste_rivalidades = contelacionCLS.pac_conste_rivalidades;
                        Constelacion.pac_conste_papel_fam = contelacionCLS.pac_conste_papel_fam;
                        Constelacion.pac_conste_uniones = contelacionCLS.pac_conste_uniones;
                        Constelacion.pac_conste_normas = contelacionCLS.pac_conste_normas;
                        Constelacion.pac_conste_cambios = contelacionCLS.pac_conste_cambios;


                        // db.pacientes.Add(Pacientes);
                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, contelacionCLS);
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

        [Route("api/ConstelacionDelete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.pac_constelacion_fam.FirstOrDefault(e => e.pac_conste_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.pac_constelacion_fam.Remove(entity);
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