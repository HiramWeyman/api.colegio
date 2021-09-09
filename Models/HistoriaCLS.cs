using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class HistoriaCLS
    {
        public long pac_hist_id { get; set; }
        public long pac_hist_pac_id { get; set; }
        public string pac_hist_embarazo { get; set; }
        public string pac_hist_inicio { get; set; }
        public string pac_hist_infancia { get; set; }
        public string pac_hist_nines_re { get; set; }
        public string pac_hist_adolecencia { get; set; }
        public string pac_hist_edad_ad { get; set; }
        public string pac_hist_edad_av { get; set; }
        public string pac_hist_alimentacion { get; set; }
        public string pac_hist_sueno { get; set; }
        public string pac_hist_enfermedades { get; set; }
        public string pac_hist_lesiones { get; set; }
        public string pac_hist_salud_act { get; set; }
    }
}