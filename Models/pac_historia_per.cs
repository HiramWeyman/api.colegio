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
    
    public partial class pac_historia_per
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
    
        public virtual pacientes pacientes { get; set; }
    }
}