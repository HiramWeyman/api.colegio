using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace api.colegio.Models
{
    public class PacienteCLS
    {
        [Key]
        public int  paciente_id { get; set; }
        public int paciente_usuario { get; set; }
        public string paciente_nombre { get; set; }
        public int paciente_sexo { get; set; }
        public int paciente_edad { get; set; }
        public string paciente_edo_nac { get; set; }
        public string paciente_mun_nac { get; set; }
        public string paciente_edo_res { get; set; }
        public string paciente_mun_res { get; set; }
        public DateTime? paciente_fec_nac { get; set; }
        public int paciente_edo_civil { get; set; }
        public int paciente_estatus { get; set; }
        public string paciente_direccion { get; set; }
        public string paciente_ocupacion { get; set; }
        public int paciente_escolaridad { get; set; }
        public DateTime? paciente_fec_ing { get; set; }
        public string paciente_telefono { get; set; }
        public string paciente_telefono_eme { get; set; }
        public int paciente_modalidad { get; set; }
    }
}