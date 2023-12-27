using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public class RespuestaPruebaAspiranteRepository : IRespuestaPruebaAspiranteRepository
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;
        public RespuestaPruebaAspiranteRepository(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RespuestaPruebaAspirante> AddRespuestaPruebaAspirante(RespuestaPruebaAspirante respuestapruebaaspirante)
        {
            _context.Add(respuestapruebaaspirante);
            await _context.SaveChangesAsync();

            return respuestapruebaaspirante;
        }

        public async Task DeleteRespuestaPruebaAspirante(RespuestaPruebaAspirante respuestapruebaaspirante)
        {
            _context.Remove(respuestapruebaaspirante);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RespuestaPruebaAspirante>> GetlistRespuestaPruebaAspirante()
        {
            return await _context.RespuestaPruebaAspirante.Include(e => e.EstadosPruebaAspirante).ToListAsync();
        }

        public async Task<RespuestaPruebaAspirante> GetRespuebaAspirante(int id)
        {
            return await _context.RespuestaPruebaAspirante.Include(e => e.EstadosPruebaAspirante).FirstOrDefaultAsync(x => x.id_respuesta_prueba_aspirante == id);            
        }

        public async Task UpdateRespuestaPruebaAspirante(RespuestaPruebaAspirante respuestapruebaaspirante)
        {
            var respuestapruebaaspiranteItem = await _context.RespuestaPruebaAspirante.FirstOrDefaultAsync(x => x.id_respuesta_prueba_aspirante == respuestapruebaaspirante.id_respuesta_prueba_aspirante);
            if (respuestapruebaaspiranteItem != null)
            {
                respuestapruebaaspiranteItem.id_respuesta_prueba_aspirante = respuestapruebaaspirante.id_respuesta_prueba_aspirante;
                respuestapruebaaspiranteItem.id_prueba = respuestapruebaaspirante.id_prueba;
                respuestapruebaaspiranteItem.respuesta_aspirante = respuestapruebaaspirante.respuesta_aspirante;
                respuestapruebaaspiranteItem.id_aspirante = respuestapruebaaspirante.id_aspirante;
                respuestapruebaaspiranteItem.id_estado_prueba_aspirante = respuestapruebaaspirante.id_estado_prueba_aspirante;

                await _context.SaveChangesAsync();
            }
        }
    }
}
