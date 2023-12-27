using System.ComponentModel.DataAnnotations;

namespace OLSoftwareApi.Models
{
    public class NivelesConocimiento
    {
        [Key]
        public int id_nivel { get; set; }
        public string? nombre_nivel { get; set; }
        public string? descripcion_nivel { get; set; }
    }
}
