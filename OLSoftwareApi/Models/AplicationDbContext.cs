
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }
        public DbSet<LenguajesProgramacion> LenguajesProgramacion { get; set; }
        public DbSet<EstadosPruebaAspirante> EstadosPruebaAspirante { get; set; }
        public DbSet<TiposPruebas> TiposPruebas { get; set; }
        public DbSet<NivelesConocimiento> NivelesConocimiento { get; set; }
        public DbSet<Preguntas> Preguntas { get; set; }
        public DbSet<Pruebas> Pruebas { get; set; }
        public DbSet<PruebasPreguntas> PruebasPreguntas { get; set; }
        public DbSet<Aspirantes> Aspirantes { get; set; }
        public DbSet<PruebaAspirante> PruebaAspirante { get; set; }
        public DbSet<RespuestaPruebaAspirante> RespuestaPruebaAspirante { get; set; }
    }
}
