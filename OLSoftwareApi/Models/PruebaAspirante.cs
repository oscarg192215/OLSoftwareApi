using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OLSoftwareApi.Models
{
    public class PruebaAspirante
    {
        [Key]
        public int id_prueba_aspirante { get; set; }
        public int id_prueba { get; set; }
        public int id_aspirante { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public string fecha_inicio { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public string fecha_finalizacion { get; set; }

    }
}
