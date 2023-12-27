using Microsoft.EntityFrameworkCore;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public class NivelesConocimientoRepository : INivelesConocimientoRepository
    {
        private readonly AplicationDbContext _context;

        public NivelesConocimientoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NivelesConocimiento> AddNivelesConocimiento(NivelesConocimiento nivelesconocimiento)
        {
           _context.Add(nivelesconocimiento);
            await _context.SaveChangesAsync();
            return nivelesconocimiento;
        }

        public async Task DeleteNivelesConocimiento(NivelesConocimiento nivelesconocimiento)
        {
            _context.Remove(nivelesconocimiento);
            await _context.SaveChangesAsync();
        }

        public async Task<List<NivelesConocimiento>> GetlistNivelesConocimiento()
        {
            return await _context.NivelesConocimiento.ToListAsync();
        }

        public async Task<NivelesConocimiento> GetNivelesConocimiento(int id)
        {
            return await _context.NivelesConocimiento.FindAsync(id);
        }

        public async Task UpdateNivelesConocimiento(NivelesConocimiento nivelesconocimiento)
        {
            var nivelesConocimientoItem = await _context.NivelesConocimiento.FirstOrDefaultAsync(x => x.id_nivel == nivelesconocimiento.id_nivel);
            if (nivelesConocimientoItem != null)
            {
                nivelesConocimientoItem.id_nivel = nivelesconocimiento.id_nivel;
                nivelesConocimientoItem.nombre_nivel = nivelesconocimiento.nombre_nivel;
                nivelesConocimientoItem.descripcion_nivel = nivelesconocimiento.descripcion_nivel;

                await _context.SaveChangesAsync();
            }
        }
    }
}
