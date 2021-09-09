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


namespace api.colegio.Controllers
{
    public class LogController : ApiController
    {
        private static Random random = new Random();
        // GET: Usuarios

       
        [HttpPost]
        public IEnumerable<UserCLS> Post(LoginCLS log)
        {
            List<UserCLS> listaEmpleado = null;
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                db.Configuration.LazyLoadingEnabled = false;
                string contraCifrada = "";
                SHA256Managed sha = new SHA256Managed();
                byte[] byteContra = Encoding.Default.GetBytes(log.usuario_password);
                byte[] byteContraCifrado = sha.ComputeHash(byteContra);
                contraCifrada = BitConverter.ToString(byteContraCifrado).Replace("-", "");
               // string query = "  SELECT pad_id,pad_plaza_id,pad_mat,pad_nombre,pad_adscripcion,pad_categoria,pad_sueldo,pad_funcion,pad_situacion,pad_permanencia,pad_f_ingreso,pad_permisos,pad_f_antig,pad_n_insaluble,pad_adscrip_base,pad_catego_base,pad_funcion_base,pad_situacion_base,pad_num_contacto,pad_observaciones,pad_cancelado,SUBSTRING(pad_f_antig,7, 4) as anio,catp_id,catp_descrip,catp_status,catp_u_captura,catp_f_captura,catp_categoria,catp_funcion,catp_adscripcion FROM steujedo_sindicato.steujedo_sindicato.Concurso_Plazas,steujedo_sindicato.steujedo_sindicato.Cat_Plazas where pad_plaza_id=catp_id  order by SUBSTRING(pad_f_antig,7, 4), pad_sueldo ";
                //string query = "  SELECT pad_id,SUBSTRING(pad_f_antig,7, 4) as anio FROM steujedo_sindicato.steujedo_sindicato.Concurso_Plazas,steujedo_sindicato.steujedo_sindicato.Cat_Plazas where pad_plaza_id=catp_id  order by SUBSTRING(pad_f_antig,7, 4), pad_sueldo ";
                listaEmpleado = db.Database.SqlQuery<UserCLS>("SELECT usuario_id,usuario_nombre,usuario_direccion,usuario_cel,usuario_telcsa,usuario_correo,usuario_tipo FROM [coleg318_].[Admin].[usuarios] where  usuario_id=@id and usuario_password=@pass ",new SqlParameter("id",log.usuario_id),new SqlParameter("pass",contraCifrada)).ToList();
                return listaEmpleado;

            }
        }



 
    }
}