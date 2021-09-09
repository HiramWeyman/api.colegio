using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class ConstelacionCLS
    {
      public long pac_conste_id { get; set; }
      public long pac_conste_paciene_id { get; set; }
      public string pac_conste_texto { get; set; }
      public string pac_conste_antecedentes { get; set; }
      public string pac_conste_desc_padre_madre { get; set; }
      public string pac_conste_hermanos { get; set; }
      public string pac_conste_rivalidades { get; set; }
      public string pac_conste_papel_fam { get; set; }
      public string pac_conste_uniones { get; set; }
      public string pac_conste_normas { get; set; }
      public string pac_conste_cambios { get; set; }
    }
}