using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class ResultadoCLS
    {
       public long evaluacion_id { get; set; }
       public long evaluacion_pac_id { get; set; }
       public long evaluacion_metodo { get; set; }
       public string evaluacion_resultado1 { get; set; }
    }
}