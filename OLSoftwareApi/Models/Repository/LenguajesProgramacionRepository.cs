using Microsoft.EntityFrameworkCore;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public class LenguajesProgramacionRepository: ILenguajesProgramacionRepository
    {
        private readonly AplicationDbContext _context;

        public LenguajesProgramacionRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LenguajesProgramacion> AddLenguajesProgramacion(LenguajesProgramacion lenguajesprogramacion)
        {
            _context.Add(lenguajesprogramacion);
            await _context.SaveChangesAsync();
            return lenguajesprogramacion;
        }

        public async Task DeleteLenguajesProgramacion(LenguajesProgramacion lenguajesprogramacion)
        {
            _context.LenguajesProgramacion.Remove(lenguajesprogramacion);
            await _context.SaveChangesAsync();
        }

        public async Task<LenguajesProgramacion> GetLenguajesProgramacion(int id)
        {
            return await _context.LenguajesProgramacion.FindAsync(id);
        }

        public async Task<List<LenguajesProgramacion>> GetlistLenguajesProgramacion()
        {
            return await _context.LenguajesProgramacion.ToListAsync();
        }

        public async Task UpdateLenguajesProgramacion(LenguajesProgramacion lenguajesprogramacion)
        {
            var lenguajesProgramacionItem = await _context.LenguajesProgramacion.FirstOrDefaultAsync(x => x.id_lenguaje == lenguajesprogramacion.id_lenguaje);

            if (lenguajesProgramacionItem != null)
            {
                lenguajesProgramacionItem.id_lenguaje = lenguajesprogramacion.id_lenguaje;
                lenguajesProgramacionItem.nombre_lenguaje = lenguajesprogramacion.nombre_lenguaje;
                lenguajesProgramacionItem.descripcion_lenguaje = lenguajesprogramacion.descripcion_lenguaje;

                await _context.SaveChangesAsync();
            }
        }
    }
}
