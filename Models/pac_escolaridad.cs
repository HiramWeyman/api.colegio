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
    
    public partial class pac_escolaridad
    {
        public long pac_escolaridad_id { get; set; }
        public long pac_escolaridad_pac_id { get; set; }
        public string pac_escolaridad_primaria { get; set; }
        public string pac_escolaridad_secundaria { get; set; }
        public string pac_escolaridad_preparatoria { get; set; }
        public string pac_escolaridad_otras { get; set; }
        public string pac_escolaridad_relacion { get; set; }
        public string pac_escolaridad_rendimiento { get; set; }
        public string pac_escolaridad_cambios { get; set; }
        public string pac_escolaridad_evaluacion { get; set; }
        public string pac_escolaridad_universidad { get; set; }
    
        public virtual pacientes pacientes { get; set; }
    }
}
