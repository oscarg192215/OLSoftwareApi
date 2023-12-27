using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OLSoftwareApi.Models
{
    public class PruebasPreguntas
    {
        [Key]
        public int id_prueba_pregunta { get; set; }
        public int id_prueba { get; set; }
        public int id_pregunta { get; set; }
        [ForeignKey("id_prueba")]
        public virtual Pruebas Pruebas { get; set; }
        [ForeignKey("id_pregunta")]
        public virtual Preguntas Preguntas { get; set; }
    }
}
