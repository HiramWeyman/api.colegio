using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class PsicoterapiaCLS
    {
        public int pac_psico_id { get; set; }
	    public int pac_psico_pac_id { get; set; }
        public string pac_psico_desc { get; set; }
        public string pac_psico_texto { get; set; }
        public DateTime pac_psico_fecha { get; set; }
        public string pac_psico_intervencion { get; set; }
        public string pac_psico_tecnicas { get; set; }
        public string pac_psico_resultados { get; set; }
        public string pac_psico_recomenda { get; set; }
        public string pac_psico_observaciones { get; set; }
    }
}