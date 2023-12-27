using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OLSoftwareApi.Models.DTO
{
    public class PruebaAspiranteDTO
    {
        [Key]
        public int id_prueba_aspirante { get; set; }
        public int id_prueba { get; set; }
        public int id_aspirante { get; set; }
        public int cantidad_preguntas_aspirante { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime fecha_inicio { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime fecha_finalizacion { get; set; }
    }
}
