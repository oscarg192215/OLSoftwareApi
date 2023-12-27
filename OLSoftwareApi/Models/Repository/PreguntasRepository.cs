using Microsoft.EntityFrameworkCore;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public class PreguntasRepository : IPreguntasRepository
    {
        private readonly AplicationDbContext _context;

        public PreguntasRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Preguntas> AddPreguntas(Preguntas preguntas)
        {
            _context.Add(preguntas);
            await _context.SaveChangesAsync();
            return preguntas;
        }

        public async Task DeletePreguntas(Preguntas preguntas)
        {
            _context.Remove(preguntas);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Preguntas>> GetlistPreguntas()
        {
            return await _context.Preguntas.Include(x => x.NivelesConocimiento).Include(l => l.LenguajesProgramacion).ToListAsync(); ;
        }

        public async Task<Preguntas> GetPreguntas(int id)
        {
            return await _context.Preguntas.Include(x => x.NivelesConocimiento).Include(l => l.LenguajesProgramacion).Where(x => x.id_pregunta.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task UpdatePreguntas(PreguntasDTO preguntas)
        {
            var preguntasItem = await _context.Preguntas.FirstOrDefaultAsync(x=>x.id_pregunta == preguntas.id_pregunta);

            if (preguntasItem != null)
            {
                preguntasItem.contenido_pregunta = preguntas.contenido_pregunta;
                preguntasItem.id_nivel = preguntas.id_nivel;
                preguntasItem.id_lenguaje = preguntas.id_lenguaje;
                 await _context.SaveChangesAsync();
            }
        }
    }
}
