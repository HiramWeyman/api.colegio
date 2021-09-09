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
    public class UsuariosController : ApiController
    {
        private static Random random = new Random();
        // GET: Usuarios
        [HttpGet]
        public IEnumerable<UsuariosCLS> Get()
        {
            List<UsuariosCLS> listaEmpleado = null;
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {
                db.Configuration.LazyLoadingEnabled = false;
                listaEmpleado = (from usr in db.usuarios
                                 orderby usr.usuario_id

                                 select new UsuariosCLS
                                 {
                                     id = (int)usr.usuario_id,
                                     usuario_nombre = usr.usuario_nombre ,
                                     usuario_direccion = usr.usuario_direccion,
                                     usuario_cel = usr.usuario_cel,
                                     usuario_telcsa=usr.usuario_telcsa,
                                     usuario_correo=usr.usuario_correo,
                                     usuario_fecha_ing = (DateTime?)usr.usuario_fecha_ing,
                                     usuario_cedula=usr.usuario_cedula
                                 }).ToList();
               // EnviarCorreo();
                return listaEmpleado;

            }
        }

        [HttpPost]
        public HttpResponseMessage Post(UsuariosCLS userCLS)
        {

            try
            {
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                  
        
                    usuarios Usuario = new usuarios();
                    var dateTime = DateTime.Now;
                    dateTime.ToString("dd/MM/yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
                    string pass = RandomString(6);
                    SHA256Managed sha = new SHA256Managed();
                    byte[] byteContra = Encoding.Default.GetBytes(pass);
                    byte[] byteContraCifrado = sha.ComputeHash(byteContra);
                    string contraCifrada = BitConverter.ToString(byteContraCifrado).Replace("-", "");

                    Usuario.usuario_nombre = userCLS.usuario_nombre;
                    Usuario.usuario_direccion = userCLS.usuario_direccion;
                    Usuario.usuario_telcsa = userCLS.usuario_telcsa;
                    Usuario.usuario_cel = userCLS.usuario_cel;
                    Usuario.usuario_correo = userCLS.usuario_correo;
                    Usuario.usuario_fecha_ing = dateTime;
                    Usuario.usuario_tipo = userCLS.usuario_tipo;
                    Usuario.usuario_password = contraCifrada;
                    Usuario.usuario_cedula = userCLS.usuario_cedula;
                    db.usuarios.Add(Usuario);
                    db.SaveChanges();
                    var Mensaje = Request.CreateResponse(HttpStatusCode.Created, userCLS);
                    EnviarCorreo(Usuario.usuario_id, pass, Usuario.usuario_correo);
                    return Mensaje;



                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [Route("api/password")]
        [HttpPost]
        public HttpResponseMessage Edit(PasswordCLS passwordCLS)
        {

            try
            {
                //id = userCLS.id;
                using (coleg318_Entities1 db = new coleg318_Entities1())
                {
                    usuarios password = new usuarios();
                    int id = passwordCLS.usuario_id;
                    password = db.usuarios.Where(p => p.usuario_id.Equals(id)).First();
                    if (password == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Paciente  no encontrado");
                    }
                    else
                    {
                        SHA256Managed sha = new SHA256Managed();
                        byte[] byteContra = Encoding.Default.GetBytes(passwordCLS.usuario_password);
                        byte[] byteContraCifrado = sha.ComputeHash(byteContra);
                        string contraCifrada = BitConverter.ToString(byteContraCifrado).Replace("-", "");
                        password.usuario_password = contraCifrada;

                        // db.pacientes.Add(Pacientes);
                        db.SaveChanges();
                        var Mensaje = Request.CreateResponse(HttpStatusCode.Created, passwordCLS.usuario_id);
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

        private void EnviarCorreo(long user,string pass,string correo)
        {
            Console.WriteLine(user);
            Console.WriteLine(pass);
            
            MailMessage email = new MailMessage();
            SmtpClient smtp = new SmtpClient();
      
            //email.To.Add(new MailAddress("correo@destino.com"));
            //email.From = new MailAddress("correo@origen.com");
            email.To.Add(new MailAddress(correo));
            email.From = new MailAddress("ColegioTerapeutasDGO@colegioterapeutasdgo.org");
            email.Subject = "Notificación ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
            email.SubjectEncoding = System.Text.Encoding.UTF8;
            email.Body = "<label><b>Su usuario es: "+user+ "</b></label><br><label><b>Su password es: " + pass+ "</b></label>";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            //FileStream fs = new FileStream("E:\\TestFolder\\test.pdf", FileMode.Open, FileAccess.Read);
            //Attachment a = new Attachment(fs, "test.pdf", MediaTypeNames.Application.Octet);
            //email.Attachments.Add(a);
            smtp.Host = "mail.colegioterapeutasdgo.org";
            // smtp.Host = "192.XXX.X.XXX";  // IP empresa/institucional
            //smtp.Host = "smtp.hotmail.com";
            //smtp.Host = "smtp.gmail.com";
            // smtp.Port = 25;
            smtp.Port = 587;
            smtp.Timeout = 1000;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new NetworkCredential("correo@origen.com", "password");
            smtp.Credentials = new NetworkCredential("ColegioTerapeutasDGO@colegioterapeutasdgo.org", "Hiram1586");

            string lista = "ejemplo1@correo.com; ejemplo2@correo2.com;";
            string output = "";
            try
            {
                smtp.Send(email);
                email.Dispose();
                output = "Correo electrónico fue enviado satisfactoriamente.";
            }
            catch (SmtpException exm)
            {
                throw exm;
            }
            catch (Exception ex)
            {
                output = "Error enviando correo electrónico: " + ex.Message;
            }
            //var mails = lista.Split(';');
            //foreach (string dir in mails)
            //    email.To.Add(dir);

            //try
            //{
            //    smtp.Send(email);
            //    email.Dispose();
            //    output = "Correo electrónico fue enviado satisfactoriamente.";
            //}
            //catch (SmtpException exm)
            //{
            //    throw exm;
            //}
            //catch (Exception ex)
            //{
            //    output = "Error enviando correo electrónico: " + ex.Message;
            //}

            // MessageBox.Show(output);
        }

   
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Route("api/Countmail/{correo}")]
        [HttpGet]
        public int  Countcorreo(string correo) {
            using (coleg318_Entities1 db = new coleg318_Entities1())
            {

                db.Configuration.LazyLoadingEnabled = false;
                int pac = db.usuarios.Count(x => x.usuario_correo == correo);
                return pac;

            }
        }
    }
}