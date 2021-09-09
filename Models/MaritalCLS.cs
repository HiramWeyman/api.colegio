using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class MaritalCLS
    {
        public long pac_maritales_id { get; set; }
        public long pac_maritales_pac_id { get; set; }
        public string pac_maritales_noviazgo { get; set; }
        public string pac_maritales_expnoviazgo { get; set; }
        public string pac_maritales_desc_conyuge { get; set; }
        public string pac_maritales_eventos { get; set; }
        public string pac_maritales_numhijos { get; set; }
        public string pac_maritales_interaccion { get; set; }
        public string pac_maritales_familia { get; set; }
    }
}