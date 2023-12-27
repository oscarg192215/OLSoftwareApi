using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OLSoftwareApi.Models
{
    public class RespuestaPruebaAspirante
    {
        [Key]
        public int id_respuesta_prueba_aspirante { get; set; }
        public int id_prueba { get; set; }
        public int id_aspirante { get; set; }
        public string respuesta_aspirante { get; set; }
        public int id_estado_prueba_aspirante { get; set; }
        [ForeignKey("id_estado_prueba_aspirante")]
        public virtual EstadosPruebaAspirante? EstadosPruebaAspirante { get; set; }
    }
}
