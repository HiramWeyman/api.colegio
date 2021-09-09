using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class PacDescCLS
    {
        public int pac_desc_id { get; set; }
        public int pac_paciente_id { get; set; }
        public string pac_desc_aspectos { get; set; }
        public string  pac_desc_vestimenta { get; set; }
        public string  pac_desc_porte { get; set; }
        public string pac_desc_movimientos { get; set; }
        public string pac_desc_afecto { get; set; }
    }
}