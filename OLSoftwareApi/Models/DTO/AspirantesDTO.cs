using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OLSoftwareApi.Models.DTO
{
    public class AspirantesDTO
    {
        [Key]
        public int id_aspirante { get; set; }
        public string id_login { get; set; }
        public string nombre_aspirante { get; set; }
        public string apellido_aspirante { get; set; }
        public string documento_aspirante { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public string fecha_nacimiento_aspirante { get; set; }
        public int celular_aspirante { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email_aspirante { get; set; }
        public string direccion_aspirante { get; set; }
        public string pais_aspirante { get; set; }
        public string ciudad_aspirante { get; set; }

    }
}
