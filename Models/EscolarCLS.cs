using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class EscolarCLS
    {
       public long pac_escolaridad_id { get; set; }
        public long pac_escolaridad_pac_id { get; set; }
        public string pac_escolaridad_primaria { get; set; }
        public string pac_escolaridad_secundaria { get; set; }
        public string pac_escolaridad_preparatoria { get; set; }
        public string pac_escolaridad_universidad { get; set; }
        public string pac_escolaridad_otras { get; set; }
        public string pac_escolaridad_relacion { get; set; }
        public string pac_escolaridad_rendimiento { get; set; }
        public string pac_escolaridad_cambios { get; set; }
        public string pac_escolaridad_evaluacion { get; set; }
    }
}