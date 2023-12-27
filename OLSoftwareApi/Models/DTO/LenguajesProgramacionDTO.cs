using System.ComponentModel.DataAnnotations;

namespace OLSoftwareApi.Models.DTO
{
    public class LenguajesProgramacionDTO
    {
        [Key]
        public int id_lenguaje { get; set; }
        public string? nombre_lenguaje { get; set; }
        public string? descripcion_lenguaje { get; set; }
    }
}
