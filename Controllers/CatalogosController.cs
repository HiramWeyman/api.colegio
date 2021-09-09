using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using api.colegio.Models;
using System.Net.Http;
using System.Net;
using System.Globalization;

namespace api.colegio.Controllers
{
    public class CatalogosController : ApiController
    {
        // GET: Catalogos
        [Route("api/Escolaridad")]
        [HttpGet]
        public IEnumerable<EscolaridadCLS> GetEscolaridad()
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                List<EscolaridadCLS> Escolaridad = null;
                db.Configuration.LazyLoadingEnabled = false;
                //return db.Concurso_Plazas.Where(x => x.pad_plaza_id == id).OrderBy(x => x.pad_f_antig).ToList();
                string query = "  SELECT *  FROM [coleg318_].[Admin].[escolaridad]";
                Escolaridad = db.Database.SqlQuery<EscolaridadCLS>(query).ToList();
                return Escolaridad;
            }
        }

        [Route("api/Estatus")]
        [HttpGet]
        public IEnumerable<EstatusCLS> GetEstatus()
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                List<EstatusCLS> estatus = null;
                db.Configuration.LazyLoadingEnabled = false;
                //return db.Concurso_Plazas.Where(x => x.pad_plaza_id == id).OrderBy(x => x.pad_f_antig).ToList();
                string query = "  SELECT *  FROM [coleg318_].[Admin].[estatus]";
                estatus = db.Database.SqlQuery<EstatusCLS>(query).ToList();
                return estatus;
            }
        }

        [Route("api/Modalidad")]
        [HttpGet]
        public IEnumerable<ModalidadCLS> GetModalidad()
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                List<ModalidadCLS> Modalidad = null;
                db.Configuration.LazyLoadingEnabled = false;
                //return db.Concurso_Plazas.Where(x => x.pad_plaza_id == id).OrderBy(x => x.pad_f_antig).ToList();
                string query = "  SELECT *  FROM [coleg318_].[Admin].[modalidad]";
                Modalidad = db.Database.SqlQuery<ModalidadCLS>(query).ToList();
                return Modalidad;
            }
        }


        [Route("api/Estado")]
        [HttpGet]
        public IEnumerable<EstadoCLS> GetEstado()
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                List<EstadoCLS> estado = null;
                db.Configuration.LazyLoadingEnabled = false;
                //return db.Concurso_Plazas.Where(x => x.pad_plaza_id == id).OrderBy(x => x.pad_f_antig).ToList();
                string query = "  SELECT * FROM [coleg318_].[Admin].[estado]";
                estado = db.Database.SqlQuery<EstadoCLS>(query).ToList();
                return estado;
            }
        }

        [Route("api/Municipio/{id}")]
        [HttpGet]
        public IEnumerable<MunicipioCLS> GetMunicipio(string id)
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                Console.WriteLine(id);
                List<MunicipioCLS> Municipio = null;
                db.Configuration.LazyLoadingEnabled = false;
                //return db.Concurso_Plazas.Where(x => x.pad_plaza_id == id).OrderBy(x => x.pad_f_antig).ToList();
                string query = "  SELECT *  FROM [coleg318_].[Admin].[municipio] where cve_edo_m="+id;
                Municipio = db.Database.SqlQuery<MunicipioCLS>(query).ToList();
                return Municipio;
            }
        }

        [Route("api/Genero")]
        [HttpGet]
        public IEnumerable<GeneroCLS> GetGenero()
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                List<GeneroCLS> Genero = null;
                db.Configuration.LazyLoadingEnabled = false;
                //return db.Concurso_Plazas.Where(x => x.pad_plaza_id == id).OrderBy(x => x.pad_f_antig).ToList();
                string query = "  SELECT *  FROM [coleg318_].[Admin].[sexo]";
                Genero = db.Database.SqlQuery<GeneroCLS>(query).ToList();
                return Genero;
            }
        }

        [Route("api/Edocivil")]
        [HttpGet]
        public IEnumerable<EdocivilCLS> GetEdocivil()
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                List<EdocivilCLS> Edocivil = null;
                db.Configuration.LazyLoadingEnabled = false;
                //return db.Concurso_Plazas.Where(x => x.pad_plaza_id == id).OrderBy(x => x.pad_f_antig).ToList();
                string query = "  SELECT *  FROM[coleg318_].[Admin].[estadocivil]";
                Edocivil = db.Database.SqlQuery<EdocivilCLS>(query).ToList();
                return Edocivil;
            }
        }

        [Route("api/Altatratamiento")]
        [HttpGet]
        public IEnumerable<TratamientoCLS> GetAltatratamiento()
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                List<TratamientoCLS> alta = null;
                db.Configuration.LazyLoadingEnabled = false;
                //return db.Concurso_Plazas.Where(x => x.pad_plaza_id == id).OrderBy(x => x.pad_f_antig).ToList();
                string query = "  SELECT *  FROM[coleg318_].[Admin].[alta_tratamiento]";
                alta = db.Database.SqlQuery<TratamientoCLS>(query).ToList();
                return alta;
            }
        }

        [Route("api/Metodoeva")]
        [HttpGet]
        public IEnumerable<MetodoevaCLS> GetMetodoeva()
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                List<MetodoevaCLS> eva = null;
                db.Configuration.LazyLoadingEnabled = false;
                //return db.Concurso_Plazas.Where(x => x.pad_plaza_id == id).OrderBy(x => x.pad_f_antig).ToList();
                string query = "  SELECT *  FROM[coleg318_].[Admin].[cat_metodo_evaluacion]";
                eva = db.Database.SqlQuery<MetodoevaCLS>(query).ToList();
                return eva;
            }
        }

        [Route("api/Modeloterapia")]
        [HttpGet]
        public IEnumerable<ModeloterapiaCLS> GetModeloterapia()
        {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                List<ModeloterapiaCLS> modelo = null;
                db.Configuration.LazyLoadingEnabled = false;
                //return db.Concurso_Plazas.Where(x => x.pad_plaza_id == id).OrderBy(x => x.pad_f_antig).ToList();
                string query = "  SELECT *  FROM [coleg318_].[Admin].[cat_modelo_terapeutico]";
                modelo = db.Database.SqlQuery<ModeloterapiaCLS>(query).ToList();
                return modelo;
            }
        }
    }
}