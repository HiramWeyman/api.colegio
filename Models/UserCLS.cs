using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.colegio.Models
{
    public class UserCLS
    {
        public long usuario_id { get; set; }
        public string usuario_nombre { get; set; }
        public int usuario_tipo { get; set; }
    }
}