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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class coleg318_Entities1 : DbContext
    {
        public coleg318_Entities1()
            : base("name=coleg318_Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<escolaridad> escolaridad { get; set; }
        public DbSet<estado> estado { get; set; }
        public DbSet<estadocivil> estadocivil { get; set; }
        public DbSet<estatus> estatus { get; set; }
        public DbSet<modalidad> modalidad { get; set; }
        public DbSet<pacientes> pacientes { get; set; }
        public DbSet<sexo> sexo { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<pac_consulta> pac_consulta { get; set; }
        public DbSet<pac_descrip> pac_descrip { get; set; }
        public DbSet<pac_situacion_act> pac_situacion_act { get; set; }
        public DbSet<pac_constelacion_fam> pac_constelacion_fam { get; set; }
        public DbSet<pac_ajustes_sociales> pac_ajustes_sociales { get; set; }
        public DbSet<pac_datos_maritales> pac_datos_maritales { get; set; }
        public DbSet<pac_desarrollo_sexual> pac_desarrollo_sexual { get; set; }
        public DbSet<pac_desc_simismo> pac_desc_simismo { get; set; }
        public DbSet<pac_diversion_intereses> pac_diversion_intereses { get; set; }
        public DbSet<pac_escolaridad> pac_escolaridad { get; set; }
        public DbSet<pac_estado_mental> pac_estado_mental { get; set; }
        public DbSet<pac_historia_per> pac_historia_per { get; set; }
        public DbSet<pac_psicoterapia> pac_psicoterapia { get; set; }
        public DbSet<pac_record_trabajo> pac_record_trabajo { get; set; }
        public DbSet<pac_recuerdos_tempranos> pac_recuerdos_tempranos { get; set; }
        public DbSet<diag_primario> diag_primario { get; set; }
        public DbSet<pac_diagnostico> pac_diagnostico { get; set; }
        public DbSet<infodiagnostico> infodiagnostico { get; set; }
        public DbSet<hojausomultiple> hojausomultiple { get; set; }
        public DbSet<alta_tratamiento> alta_tratamiento { get; set; }
        public DbSet<cat_metodo_evaluacion> cat_metodo_evaluacion { get; set; }
        public DbSet<evaluacion_resultado> evaluacion_resultado { get; set; }
        public DbSet<metodo_evaluacion> metodo_evaluacion { get; set; }
        public DbSet<evaluacion> evaluacion { get; set; }
        public DbSet<cat_modelo_terapeutico> cat_modelo_terapeutico { get; set; }
        public DbSet<vmetodos_evaluacion> vmetodos_evaluacion { get; set; }
        public DbSet<pacientediagnosticado> pacientediagnosticado { get; set; }
        public DbSet<infogeneral> infogeneral { get; set; }
    }
}
