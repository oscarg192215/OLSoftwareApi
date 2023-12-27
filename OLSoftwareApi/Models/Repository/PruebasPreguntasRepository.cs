using Microsoft.EntityFrameworkCore;

namespace OLSoftwareApi.Models.Repository
{
    public class PruebasPreguntasRepository : IPruebasPreguntasRepository
    {
        private readonly AplicationDbContext _context;
        public PruebasPreguntasRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PruebasPreguntas> AddPruebasPreguntas(PruebasPreguntas pruebaspreguntas)
        {
            _context.Add(pruebaspreguntas);
            await _context.SaveChangesAsync();
            return pruebaspreguntas;
        }

        public async Task DeletePruebasPreguntas(PruebasPreguntas pruebaspreguntas)
        {
            _context.Remove(pruebaspreguntas);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PruebasPreguntas>> GetlistPruebasPreguntas()
        {
            return await _context.PruebasPreguntas.ToListAsync();
        }

        public async Task<PruebasPreguntas> GetPruebasPreguntas(int id)
        {
            return await _context.PruebasPreguntas.FindAsync(id);
        }

        public async Task UpdatePruebasPreguntas(PruebasPreguntas pruebaspreguntas)
        {
            var pruebaspreguntasItem = await _context.PruebasPreguntas.FirstOrDefaultAsync(x => x.id_prueba_pregunta.Equals(pruebaspreguntas.id_prueba_pregunta));
            if (pruebaspreguntasItem != null)
            {
                pruebaspreguntasItem.id_prueba_pregunta = pruebaspreguntas.id_prueba_pregunta;
                pruebaspreguntasItem.id_prueba = pruebaspreguntas.id_prueba;
                pruebaspreguntasItem.id_pregunta = pruebaspreguntas.id_pregunta;

                await _context.SaveChangesAsync();
            }
        }

    }
}
