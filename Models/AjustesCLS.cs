using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class AjustesCLS
    {
       public long pac_ajustes_id { get; set; }
        public long pac_ajustes_pac_id { get; set; }
        public string pac_ajustes_relacionesint { get; set; }
        public string pac_ajustes_amistades { get; set; }
        public string pac_ajustes_sentir { get; set; }
        public string pac_ajustes_novias { get; set; }
    }
}