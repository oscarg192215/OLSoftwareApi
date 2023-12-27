using Microsoft.EntityFrameworkCore;

namespace OLSoftwareApi.Models.Repository
{
    public class EstadosPruebaAspiranteRepository : IEstadosPruebaAspiranteRepository
    {       
        private readonly AplicationDbContext _context;
        public EstadosPruebaAspiranteRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EstadosPruebaAspirante> AddEstadosPruebaAspirante(EstadosPruebaAspirante estadospruebaaspirante)
        {
            _context.Add(estadospruebaaspirante);
            await _context.SaveChangesAsync();
            return estadospruebaaspirante;
        }

        public async Task DeleteEstadosPruebaAspirante(EstadosPruebaAspirante estadospruebaaspirante)
        {
            _context.Remove(estadospruebaaspirante);
            await _context.SaveChangesAsync();
        }

        public async Task<EstadosPruebaAspirante> GetEstadosPruebaAspirante(int id)
        {
            return await _context.EstadosPruebaAspirante.FindAsync(id);
        }

        public async Task<List<EstadosPruebaAspirante>> GetlistEstadosPruebaAspirante()
        {
            return await _context.EstadosPruebaAspirante.ToListAsync();
        }

        public async Task UpdateEstadosPruebaAspirante(EstadosPruebaAspirante estadospruebaaspirante)
        {
            var estadosPruebaAspiranteItem = await _context.EstadosPruebaAspirante.FirstOrDefaultAsync(x => x.id_estado_prueba_aspirante == estadospruebaaspirante.id_estado_prueba_aspirante);

            if (estadosPruebaAspiranteItem != null)
            {
                estadosPruebaAspiranteItem.id_estado_prueba_aspirante = estadospruebaaspirante.id_estado_prueba_aspirante;
                estadosPruebaAspiranteItem.nombre_estado = estadospruebaaspirante.nombre_estado;
                estadosPruebaAspiranteItem.descripcion_estado = estadospruebaaspirante.descripcion_estado;

                await _context.SaveChangesAsync();
            }
        }
    }
}
