using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public class PruebaAspiranteRepository : IPruebaAspiranteRepository
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;

        public PruebaAspiranteRepository(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PruebaAspiranteDTO> AddPruebaAspirante(PruebaAspirante pruebaaspirante)
        {
            _context.Add(pruebaaspirante);
            await _context.SaveChangesAsync();

            var mapPruebaAspirante = _mapper.Map<PruebaAspiranteDTO>(pruebaaspirante);
            return mapPruebaAspirante;
        }

        public async Task DeletePruebaAspirante(PruebaAspirante pruebaaspirante)
        {
            _context.Remove(pruebaaspirante);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PruebaAspirante>> GetlistPruebaAspirante()
        {
            return await _context.PruebaAspirante.ToListAsync();
        }

        public async Task<PruebaAspirante> GetPruebaAspirante(int id)
        {
            return await _context.PruebaAspirante.FindAsync(id);
        }

        public async Task UpdatePruebaAspirante(PruebaAspirante pruebaaspirante)
        {
            var pruebaaspiranteItem = await _context.PruebaAspirante.FirstOrDefaultAsync(x => x.id_prueba_aspirante.Equals(pruebaaspirante.id_prueba_aspirante));
            if (pruebaaspiranteItem != null)
            {
                pruebaaspiranteItem.id_prueba_aspirante = pruebaaspirante.id_prueba_aspirante;
                pruebaaspiranteItem.id_prueba = pruebaaspirante.id_prueba;
                pruebaaspiranteItem.id_aspirante = pruebaaspirante.id_aspirante;
                pruebaaspiranteItem.fecha_inicio = pruebaaspirante.fecha_inicio;
                pruebaaspiranteItem.fecha_finalizacion = pruebaaspirante.fecha_finalizacion;

                await _context.SaveChangesAsync();
            }
        }
    }
}
