namespace OLSoftwareApi.Models.DTO
{
    public class PruebaDetalleDTO
    {        
        public int id_prueba { get; set; }
        public string? nombre_prueba { get; set; }
        public int id_tipo_prueba { get; set; }
        public string nombre_tipo_prueba { get; set; }
        public int id_lenguaje { get; set; }
        public string nombre_lenguaje { get; set; }
        public int id_nivel { get; set; }
        public string nombre_nivel { get; set; }
        public int cantidad_preguntas { get; set; }
        public int id_estado_prueba_aspirante { get; set; }
        public string nombre_estado { get; set; }
        public List<Preguntas> Preguntas { get; set; }
    }
}
