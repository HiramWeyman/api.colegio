using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using api.colegio.Models;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using Newtonsoft.Json;

namespace api.colegio.Controllers
{
    public class PacientesController : ApiController
    {
        private readonly int _RegistrosPorPagina = 10;

        private List<pacientes> _Pacientes;
        private PaginadorGenerico<pacientes> _PaginadorPacientes;

        [Route("api/Pacientes/{id}")]
        [HttpGet]
        public PaginadorGenerico<pacientes> Get(int id, int pagina = 1)
        {

            int _TotalRegistros = 0;
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                db.Configuration.LazyLoadingEnabled = false;
                // Número total de registros de la tabla Customers
                _TotalRegistros = db.pacientes.Count();

                // Obtenemos la 'página de registros' de la tabla Customers
                _Pacientes = db.pacientes.Where(x=>x.paciente_usuario==id && x.paciente_estatus==1).OrderBy(x => x.paciente_nombre)
                                                 .Skip((pagina - 1) * _RegistrosPorPagina)
                                                 .Take(_RegistrosPorPagina)
                                                 .ToList();

                // Número total de páginas de la tabla Customers
                var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);
                // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
                _PaginadorPacientes = new PaginadorGenerico<pacientes>()
                {
                    RegistrosPorPagina = _RegistrosPorPagina,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = pagina,
                    Resultado = _Pacientes
                };
                // Enviamos a la Vista la 'Clase de paginación'

                // Setting Header  
                //HttpContext.Current.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(_PaginadorPacientes));
                // Returing List of Customers Collections  
                //return items;
                return _PaginadorPacientes;
            

            }
        }


        [Route("api/PacientesInactivos/{id}")]
        [HttpGet]
        public PaginadorGenerico<pacientes> GetInactivos(int id, int pagina = 1)
        {

            int _TotalRegistros = 0;
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                db.Configuration.LazyLoadingEnabled = false;
                // Número total de registros de la tabla Customers
                _TotalRegistros = db.pacientes.Count();

                // Obtenemos la 'página de registros' de la tabla Customers
                _Pacientes = db.pacientes.Where(x => x.paciente_usuario == id && x.paciente_estatus == 2).OrderBy(x => x.paciente_nombre)
                                                 .Skip((pagina - 1) * _RegistrosPorPagina)
                                                 .Take(_RegistrosPorPagina)
                                                 .ToList();

                // Número total de páginas de la tabla Customers
                var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);
                // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
                _PaginadorPacientes = new PaginadorGenerico<pacientes>()
                {
                    RegistrosPorPagina = _RegistrosPorPagina,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = pagina,
                    Resultado = _Pacientes
                };
                // Enviamos a la Vista la 'Clase de paginación'

                // Setting Header  
                //HttpContext.Current.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(_PaginadorPacientes));
                // Returing List of Customers Collections  
                //return items;
                return _PaginadorPacientes;


            }
        }


        [Route("api/Paciente/{id}")]
        [HttpGet]
        public HttpResponseMessage GetPaciente(long id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
          
                db.Configuration.LazyLoadingEnabled = false;
                var pac = db.pacientes.FirstOrDefault(x => x.paciente_id == id);
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


        [Route("api/NombrePaciente/{Nom}")]
        [HttpGet]
        public PaginadorGenerico<pacientes> GetNombrePaciente(string nom, int pagina = 1)
        {

            int _TotalRegistros = 0;
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                db.Configuration.LazyLoadingEnabled = false;
                // Número total de registros de la tabla Customers
                _TotalRegistros = db.pacientes.Count();

                // Obtenemos la 'página de registros' de la tabla Customers
                _Pacientes = db.pacientes.Where(x => x.paciente_nombre.Contains(nom) && x.paciente_estatus == 1).OrderBy(x => x.paciente_nombre)
                                                 .Skip((pagina - 1) * _RegistrosPorPagina)
                                                 .Take(_RegistrosPorPagina)
                                                 .ToList();

                // Número total de páginas de la tabla Customers
                var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);
                // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
                _PaginadorPacientes = new PaginadorGenerico<pacientes>()
                {
                    RegistrosPorPagina = _RegistrosPorPagina,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = pagina,
                    Resultado = _Pacientes
                };
                // Enviamos a la Vista la 'Clase de paginación'

                // Setting Header  
                //HttpContext.Current.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(_PaginadorPacientes));
                // Returing List of Customers Collections  
                //return items;
                return _PaginadorPacientes;


            }
        }


        [Route("api/NombrePacienteInactivo/{Nom}")]
        [HttpGet]
        public PaginadorGenerico<pacientes> GetNombrePacienteInactivo(string nom, int pagina = 1)
        {

            int _TotalRegistros = 0;
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                db.Configuration.LazyLoadingEnabled = false;
                // Número total de registros de la tabla Customers
                _TotalRegistros = db.pacientes.Count();

                // Obtenemos la 'página de registros' de la tabla Customers
                _Pacientes = db.pacientes.Where(x => x.paciente_nombre.Contains(nom) && x.paciente_estatus == 2).OrderBy(x => x.paciente_nombre)
                                                 .Skip((pagina - 1) * _RegistrosPorPagina)
                                                 .Take(_RegistrosPorPagina)
                                                 .ToList();

                // Número total de páginas de la tabla Customers
                var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);
                // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
                _PaginadorPacientes = new PaginadorGenerico<pacientes>()
                {
                    RegistrosPorPagina = _RegistrosPorPagina,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = pagina,
                    Resultado = _Pacientes
                };
                // Enviamos a la Vista la 'Clase de paginación'

                // Setting Header  
                //HttpContext.Current.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(_PaginadorPacientes));
                // Returing List of Customers Collections  
                //return items;
                return _PaginadorPacientes;


            }
        }

        [Route("api/pacienteDet/{id}")]
        [HttpGet]
        public HttpResponseMessage GetDetalle(long id)
        {
            try {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                    db.Configuration.LazyLoadingEnabled = false;

                    var infogeneral = db.infogeneral.FirstOrDefault(x => x.paciente_id == id);
                    //var pac = db.Database.SqlQuery<PacienteCLS>("  SELECT * FROM [coleg318_].[Admin].[pacientes] where paciente_id=@id", new SqlParameter("id", id)).FirstOrDefault();

                    if (infogeneral != null)
                    {
                      

                        return Request.CreateResponse(HttpStatusCode.OK, infogeneral);
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


        [Route("api/Pacinsert")]
        [HttpPost]
        public HttpResponseMessage Post(PacienteCLS pacCLS)
        {
            //string user_login = "";

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    // string iDate = "05/05/2005";
                    //DateTime oDate = Convert.ToDateTime(pacCLS.paciente_fec_ing);
                    //DateTime oDate2 = Convert.ToDateTime(pacCLS.paciente_fec_nac);

                    //DateTime oDate = Convert.ToDateTime(DateTime.ParseExact(pacCLS.paciente_fec_ing.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    //DateTime oDate2 = Convert.ToDateTime(DateTime.ParseExact(pacCLS.paciente_fec_nac.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    DateTime oDate = Convert.ToDateTime(pacCLS.paciente_fec_ing);
                    DateTime oDate2 = Convert.ToDateTime(pacCLS.paciente_fec_nac);
                    pacientes Pacientes = new pacientes();
                    //var dateTime = DateTime.Now;
                    //dateTime.ToString("dd/MM/yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);

                    Pacientes.paciente_usuario = pacCLS.paciente_usuario;
                    Pacientes.paciente_nombre = pacCLS.paciente_nombre;
                    Pacientes.paciente_direccion = pacCLS.paciente_direccion;
                    Pacientes.paciente_ocupacion = pacCLS.paciente_ocupacion;
                    Pacientes.paciente_telefono = pacCLS.paciente_telefono;
                    Pacientes.paciente_telefono_eme = pacCLS.paciente_telefono_eme;
                    Pacientes.paciente_sexo = pacCLS.paciente_sexo;
                    Pacientes.paciente_edad = pacCLS.paciente_edad;
                    Pacientes.paciente_edo_civil = pacCLS.paciente_edo_civil;
                    Pacientes.paciente_escolaridad = pacCLS.paciente_escolaridad;
                    Pacientes.paciente_edo_nac = pacCLS.paciente_edo_nac;
                    Pacientes.paciente_mun_nac = pacCLS.paciente_mun_nac;
                    Pacientes.paciente_edo_res = pacCLS.paciente_edo_res;
                    Pacientes.paciente_mun_res = pacCLS.paciente_mun_res;
                    Pacientes.paciente_estatus = pacCLS.paciente_estatus;
                    Pacientes.paciente_modalidad = pacCLS.paciente_modalidad;
                    Pacientes.paciente_fec_ing = oDate;
                    Pacientes.paciente_fec_nac = oDate2;

                    db.pacientes.Add(Pacientes);
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

        [Route("api/Pacupdate/{id}")]
        [HttpPost]
        public HttpResponseMessage Edit(int id, PacienteCLS pacCLS)
        {
            
            try
            {
                
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    int idx = pacCLS.paciente_id;
                    pacientes Pacientes = new pacientes();
                    Pacientes = db.pacientes.Where(p => p.paciente_id.Equals(id)).First();
                    if (Pacientes == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Paciente  no encontrado");
                    }
                    else
                    {

                        DateTime oDate = Convert.ToDateTime(pacCLS.paciente_fec_ing);
                        DateTime oDate2 = Convert.ToDateTime(pacCLS.paciente_fec_nac);


                        Pacientes.paciente_usuario = pacCLS.paciente_usuario;
                        Pacientes.paciente_nombre = pacCLS.paciente_nombre;
                        Pacientes.paciente_direccion = pacCLS.paciente_direccion;
                        Pacientes.paciente_ocupacion = pacCLS.paciente_ocupacion;
                        Pacientes.paciente_telefono = pacCLS.paciente_telefono;
                        Pacientes.paciente_telefono_eme = pacCLS.paciente_telefono_eme;
                        Pacientes.paciente_sexo = pacCLS.paciente_sexo;
                        Pacientes.paciente_edad = pacCLS.paciente_edad;
                        Pacientes.paciente_edo_civil = pacCLS.paciente_edo_civil;
                        Pacientes.paciente_escolaridad = pacCLS.paciente_escolaridad;
                        Pacientes.paciente_edo_nac = pacCLS.paciente_edo_nac;
                        Pacientes.paciente_mun_nac = pacCLS.paciente_mun_nac;
                        Pacientes.paciente_edo_res = pacCLS.paciente_edo_res;
                        Pacientes.paciente_mun_res = pacCLS.paciente_mun_res;
                        Pacientes.paciente_estatus = pacCLS.paciente_estatus;
                        Pacientes.paciente_modalidad = pacCLS.paciente_modalidad;
                        Pacientes.paciente_fec_ing = oDate;
                        Pacientes.paciente_fec_nac = oDate2;

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


        [Route("api/ActivarPaciente/{id}")]
        [HttpPost]
        public HttpResponseMessage ActivarPaciente(int id, PacienteCLS pacCLS)
        {

            try
            {

                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    int idx = pacCLS.paciente_id;
                    pacientes Pacientes = new pacientes();
                    Pacientes = db.pacientes.Where(p => p.paciente_id.Equals(id)).First();
                    if (Pacientes == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Paciente  no encontrado");
                    }
                    else
                    {
                    
                        Pacientes.paciente_estatus = 1;

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

        [Route("api/DesactivarPaciente/{id}")]
        [HttpPost]
        public HttpResponseMessage DesactivarPaciente(int id, PacienteCLS pacCLS)
        {

            try
            {

                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    int idx = pacCLS.paciente_id;
                    pacientes Pacientes = new pacientes();
                    Pacientes = db.pacientes.Where(p => p.paciente_id.Equals(id)).First();
                    if (Pacientes == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Paciente  no encontrado");
                    }
                    else
                    {

                        Pacientes.paciente_estatus = 2;

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

        [Route("api/pacdiag")]
        [HttpGet]
        public HttpResponseMessage PacienteDiag([FromUri] int id, [FromUri] int user)
        {

            try
            {

                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                   List<pacientediagnosticado> Pacientes = null;
                    Pacientes = db.pacientediagnosticado.Where(p => p.diag_id.Equals(id) && p.paciente_usuario.Equals(user)).ToList();
                    if (Pacientes == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Paciente  no encontrado");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, Pacientes); ;

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


        [Route("api/pacdiagCount")]
        [HttpGet]
        public int PacienteDiagCount([FromUri] int id, [FromUri] int user)
        {

            try
            {

                using (coleg318_Entities1 db = new coleg318_Entities1())
                {

                   
                    int Pacientes = db.pacientediagnosticado.Where(p => p.diag_id.Equals(id) && p.paciente_usuario.Equals(user)).Count();
                    return Pacientes;

                }

            }
            catch (Exception ex)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(ex.Message);
                //errorWriter.WriteLine(usageText);
                return 0;
            }

        }
    }
}