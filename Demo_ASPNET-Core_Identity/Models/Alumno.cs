using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASPNET_Core_Identity.Models
{
    [Table("Alumno")]
    public class Alumno
    {
        public int AlumnoId { get; set; }
        public string Nombre{ get; set; }
        public string Codigo { get; set; }
        public string Tipo { get; set; }
    }
}
