//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace api.colegio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class infodiagnostico
    {
        public string diag_descrip { get; set; }
        public long pac_diag_id { get; set; }
        public long pac_diag_pac_id { get; set; }
        public string pac_diag_perfilcog { get; set; }
        public string pac_diag_pruebaspsi { get; set; }
        public string pac_diag_diagnostico { get; set; }
        public string pac_diag_especifico { get; set; }
        public string pac_diag_pronostico { get; set; }
        public Nullable<int> pac_diag_primario { get; set; }
        public string pac_diag_obj_integral { get; set; }
        public string pac_diag_obj_especifico { get; set; }
        public Nullable<System.DateTime> pac_diag_fec_seguimiento { get; set; }
        public string alta_descrip { get; set; }
        public string modtera_descrip { get; set; }
    }
}