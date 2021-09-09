using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class SimismoCLS
    {
        public long pac_simismo_id { get; set; }
        public long pac_simismo_pac_id { get; set; }
        public string pac_simismo_comoseve { get; set; }
        public string pac_simismo_comocree { get; set; }
        public string pac_simismo_preocupaciones { get; set; }
        public string pac_simismo_metas { get; set; }
        public string pac_simismo_gustaria { get; set; }
        public string pac_simismo_crisis { get; set; }
        public string pac_simismo_triunfo_frac { get; set; }
        public string pac_simismo_siente_problem { get; set; }
    }
}