using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace api.colegio.Models
{
    public class UsuariosCLS
    {
        [Key]
        public int id { get; set; }


        [Display(Name = "Nombre Completo")]
        public string usuario_nombre { get; set; }

        [Display(Name = "Dirección")]
        public string usuario_direccion { get; set; }

        [Display(Name = "Celular")]
        public string usuario_cel { get; set; }
       

        [Display(Name = "Tel Casa")]
        public string usuario_telcsa { get; set; }

        [Display(Name = "Correo")]
        public string usuario_correo { get; set; }


        [Display(Name = "F_ingreso")]
        public DateTime? usuario_fecha_ing { get; set; }

        public int usuario_tipo { get; set; }

        [Display(Name = "Cedula")]
        public string usuario_cedula { get; set; }
    }





   
}