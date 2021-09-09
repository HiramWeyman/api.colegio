using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class ConsultaCLS
    {
        public int pac_cons_id { get; set; }
        public int pac_cons_pac_id { get; set; }
        public string pac_cons_problema { get; set; }
        public string pac_cons_historia { get; set; }
        public string pac_cons_referencia { get; set; }
        public string pac_cons_experiencia { get; set; }
    }
}