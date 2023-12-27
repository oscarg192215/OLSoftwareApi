using System.ComponentModel.DataAnnotations;

namespace OLSoftwareApi.Models.DTO
{
    public class TiposPruebasDTO
    {
        [Key]
        public int id_tipo_prueba { get; set; }
        public string? nombre_tipo_prueba { get; set; }
        public string? descripcion_tipo_prueba { get; set; }
    }
}
