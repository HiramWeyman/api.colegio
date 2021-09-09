using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using api.colegio.Models;

namespace api.colegio.Controllers
{
    public class LoginController : ApiController
    {
      
        [HttpPost]
        public HttpResponseMessage Post(LoginCLS log)
        {
            //string user_login = "";
            Console.WriteLine(log);
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                try {
                    string contraCifrada = "";
                    if (log.usuario_password != null)
                    {
                        SHA256Managed sha = new SHA256Managed();
                        byte[] byteContra = Encoding.Default.GetBytes(log.usuario_password);
                        byte[] byteContraCifrado = sha.ComputeHash(byteContra);
                        contraCifrada = BitConverter.ToString(byteContraCifrado).Replace("-", "");
                        var user = db.Database.SqlQuery<UserCLS>("SELECT usuario_id,usuario_nombre,usuario_tipo FROM [coleg318_].[Admin].[usuarios] where  usuario_id=@id and usuario_password=@pass ", new SqlParameter("id", log.usuario_id), new SqlParameter("pass", contraCifrada));
                        db.Configuration.LazyLoadingEnabled = false;
                        if (user != null)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, user);
                            //user_login = db.Database.SqlQuery<string>("Select user_login from Usuarios where user_login=@usuario and password=@password adnd role_id=1", new SqlParameter("@usuario", usr), new SqlParameter("@password", password)).FirstOrDefault();
                            //Session["Usuario"] = user_login;

                        }
                        else
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Usuario  no encontrado");
                        }
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Falta  Ingresar password  ");
                    }

                } 
                catch (Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
                }
               

            }
        }
    }
}