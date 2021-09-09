using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.colegio.Models
{
    public class MetodosevaController : ApiController
    {
        [Route("api/DescEva")]
        [HttpPost]
        public HttpResponseMessage Post([FromUri] string descripcion)
        {
            Console.WriteLine(descripcion);

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    cat_metodo_evaluacion metodo = new cat_metodo_evaluacion();
                    metodo.cat_metodo_descrip = descripcion;
                    db.cat_metodo_evaluacion.Add(metodo);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, metodo);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/InsertEva")]
        [HttpPost]
        public HttpResponseMessage Insert(EvaluacionCLS evaluacion)
        {
  
            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    metodo_evaluacion metodo = new metodo_evaluacion();
                    metodo.metodo_pac_id = evaluacion.metodo_pac_id;
                    metodo.metodo_evaluacion1 = evaluacion.metodo_evaluacion;
                    db.metodo_evaluacion.Add(metodo);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, metodo);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/InsertResultado")]
        [HttpPost]
        public HttpResponseMessage InsertResultado(ResultadoCLS resultado)
        {

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    evaluacion_resultado res = new evaluacion_resultado();
                    res.evaluacion_metodo = resultado.evaluacion_metodo;
                    res.evaluacion_pac_id = resultado.evaluacion_pac_id;
                    res.evaluacion_resultado1 = resultado.evaluacion_resultado1;
                    db.evaluacion_resultado.Add(res);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, res);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Evaluacion/{id}")]
        [HttpGet]
        public HttpResponseMessage GetDatosEvaluacion(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                List<evaluacion> Evaluacion = null;

                Evaluacion = db.evaluacion.OrderBy(x => x.cat_metodo_descrip).Where(x => x.metodo_pac_id == id).ToList();
                if (Evaluacion != null)
                {
                    //var dateTime = DateTime.Now;
                    //dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    //pac.paciente_fec_nac.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    return Request.CreateResponse(HttpStatusCode.OK, Evaluacion);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                }


            }
        }

        [Route("api/ResultadoEva")]
        [HttpGet]
        public HttpResponseMessage GetResultado([FromUri] int paciente_id, [FromUri] int metodo_id)
        {
          

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    db.Configuration.LazyLoadingEnabled = false;
                    var ressultado = db.evaluacion_resultado.FirstOrDefault(x => x.evaluacion_pac_id == paciente_id && x.evaluacion_metodo== metodo_id);
                    //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                    if (ressultado != null)
                    {
                        //var dateTime = DateTime.Now;
                        //dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                        //pac.paciente_fec_nac.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                        return Request.CreateResponse(HttpStatusCode.OK, ressultado);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado.");
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [Route("api/UpdateResultado/{id}")]
        [HttpPost]
        public HttpResponseMessage UpdateResultado(int id, ResultadoCLS resultado)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    evaluacion_resultado res = new evaluacion_resultado();
                    res = db.evaluacion_resultado.Where(p => p.evaluacion_id.Equals(id)).First();
                    if (res == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Paciente  no encontrado");
                    }
                    else
                    {
                        //res.evaluacion_metodo = resultado.evaluacion_metodo;
                        //res.evaluacion_pac_id = resultado.evaluacion_pac_id;
                        res.evaluacion_resultado1 = resultado.evaluacion_resultado1;                   
                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, resultado);
                        return Mensaje;

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [Route("api/DeleteResultado/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteResultado(int id)
        {

            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.evaluacion_resultado.FirstOrDefault(e => e.evaluacion_id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.evaluacion_resultado.Remove(entity);
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

        [Route("api/DeleteRes")]
        [HttpPost]
        public int DeleteRes([FromUri] int paciente_id, [FromUri] int metodo_id)
        {

            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.evaluacion_resultado.FirstOrDefault(e => e.evaluacion_pac_id == paciente_id && e.evaluacion_metodo== metodo_id);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        dbContext.evaluacion_resultado.Remove(entity);
                        dbContext.SaveChanges();
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return 0;
            }

        }

        [Route("api/DeleteEvaluacion")]
        [HttpPost]
        public int DeleteEvaluacion([FromUri] int paciente_id, [FromUri] int metodo_id)
        {

            try
            {
                using (coleg318_Entities1 dbContext = new coleg318_Entities1())
                {
                    var entity = dbContext.metodo_evaluacion.FirstOrDefault(e => e.metodo_pac_id == paciente_id && e.metodo_id == metodo_id);
                    if (entity == null)
                    {
                        //return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        //    "Employee with Id = " + paciente_id.ToString() + " not found to delete");
                        return 0;
                    }
                    else
                    {
                        dbContext.metodo_evaluacion.Remove(entity);
                        dbContext.SaveChanges();
                        return 1;
                      /*  return Request.CreateResponse(HttpStatusCode.OK)*/;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return 0;
            }

        }

        [Route("api/CountResultado")]
        [HttpGet]
        public int CountResultado([FromUri] int paciente_id, [FromUri] int metodo_id)
        {


            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    db.Configuration.LazyLoadingEnabled = false;
                    var ressultado = db.evaluacion_resultado.Where(x => x.evaluacion_pac_id == paciente_id && x.evaluacion_metodo == metodo_id).Count();

                    return ressultado;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return 0;
            }
        }
    }
}
