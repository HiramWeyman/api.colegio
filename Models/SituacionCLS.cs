using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class SituacionCLS
    {
        public int pac_situacion_id { get; set; }
        public int pac_situacion_pac_id{ get; set; }
        public string pac_situacion_dia { get; set; }
        public string pac_situacion_esp{ get; set; }
    }
}