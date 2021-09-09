using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class MentalCLS
    {
        public long pac_estado_id { get; set; }
        public long pac_estado_pac_id { get; set; }
        public string  pac_estado_conciencia { get; set; }
        public string pac_estado_orientacion { get; set; }
        public string pac_estadoafectividad { get; set; }
        public string pac_estado_asociaciones { get; set; }
        public string pac_estado_pensamiento { get; set; }
        public string pac_estado_percepcion { get; set; }
        public string pac_estado_funcionamiento { get; set; }
        public string pac_estado_juicio { get; set; }
        public string pac_estado_insight { get; set; }
        public string pac_estado_madurez { get; set; }
    }
}