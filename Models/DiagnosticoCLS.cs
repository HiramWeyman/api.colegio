using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class DiagnosticoCLS
    {
      public long pac_diag_id { get; set; }
      public long pac_diag_pac_id { get; set; }
      public string pac_diag_perfilcog { get; set; }
      public string pac_diag_pruebaspsi { get; set; }
      public string pac_diag_diagnostico { get; set; }
      public int pac_diag_primario { get; set; }
      public string pac_diag_especifico { get; set; }
      public string pac_diag_obj_integral { get; set; }
      public string pac_diag_obj_especifico { get; set; }
      public string pac_diag_pronostico { get; set; }
      public int pac_diag_modelo_tera { get; set; }
      public int pac_diag_motivo_alta { get; set; }
      public string pac_diag_fec_seguimiento { get; set; }
    }
}