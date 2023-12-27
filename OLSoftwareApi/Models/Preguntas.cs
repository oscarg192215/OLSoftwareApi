using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OLSoftwareApi.Models
{
    public class Preguntas
    {
        [Key] 
        public int id_pregunta { get; set; }
        public string contenido_pregunta { get; set; }
        public int id_nivel { get; set; }        
        public int id_lenguaje { get; set; }

        [ForeignKey("id_nivel")]
        public virtual NivelesConocimiento? NivelesConocimiento { get; set; }
        [ForeignKey("id_lenguaje")]
        public virtual LenguajesProgramacion? LenguajesProgramacion { get; set; }
    }
}
