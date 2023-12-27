using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OLSoftwareApi.Models
{
    public class Aspirantes
    {
        [Key]
        public int id_aspirante { get; set; }
        public string id_login { get; set; }
        public string nombre_aspirante { get; set; }
        public string apellido_aspirante { get; set; }
        public string documento_aspirante { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public string fecha_nacimiento_aspirante { get; set; }
        public string celular_aspirante { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email_aspirante { get; set; }
        public string direccion_aspirante { get; set; }
        public string pais_aspirante { get; set; }
        public string ciudad_aspirante { get; set; }
        [NotMapped]
        [BindProperty, DataType(DataType.Date)]
        public string fecha_inicio { get; set; }
        [NotMapped]
        [BindProperty, DataType(DataType.Date)]
        public string fecha_finalizacion { get; set; }
        [NotMapped]
        public int id_prueba { get; set; }
        [NotMapped]
        public int id_prueba_aspirante { get; set; }
    }
}
