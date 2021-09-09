using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class DiversionCLS
    {
       public long pac_diversion_id { get; set; }
       public long pac_diversion_pac_id { get; set; }
       public string pac_diversion_lectura{ get; set; }
       public string pac_diversion_practicas{ get; set; }
       public string pac_diversion_pertenencia{ get; set; }
    }
}