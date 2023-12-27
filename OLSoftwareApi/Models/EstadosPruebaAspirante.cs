using System.ComponentModel.DataAnnotations;

namespace OLSoftwareApi.Models
{
    public class EstadosPruebaAspirante
    {
        [Key]
        public int id_estado_prueba_aspirante { get; set; }
        public string? nombre_estado { get; set; }
        public string? descripcion_estado { get; set; }
    }
}
