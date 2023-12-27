using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OLSoftwareApi.Models.DTO
{
    public class PruebasDTO
    {
        [Key]
        public int id_prueba { get; set; }
        public string? nombre_prueba { get; set; }
        public int id_tipo_prueba { get; set; }
        public int id_lenguaje { get; set; }
        public int id_nivel { get; set; }
        public int cantidad_preguntas { get; set; }
        public int  id_estado_prueba_aspirante { get; set; }
        public int[]? id_pregunta { get; set; }
    }
}
