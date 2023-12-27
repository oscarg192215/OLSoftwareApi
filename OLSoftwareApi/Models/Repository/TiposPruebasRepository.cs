using Microsoft.EntityFrameworkCore;

namespace OLSoftwareApi.Models.Repository
{
    public class TiposPruebasRepository : ITiposPruebasRepository
    {
        private readonly AplicationDbContext _context;

        public TiposPruebasRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TiposPruebas> AddTiposPruebas(TiposPruebas tipospruebas)
        {
            _context.Add(tipospruebas);
            await _context.SaveChangesAsync();
            return tipospruebas;
        }

        public async Task DeleteTiposPruebas(TiposPruebas tipospruebas)
        {
            _context.Remove(tipospruebas);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TiposPruebas>> GetlistTiposPruebas()
        {
            return await _context.TiposPruebas.ToListAsync();
        }

        public async Task<TiposPruebas> GetTiposPruebas(int id)
        {
            return await _context.TiposPruebas.FindAsync(id);
        }

        public async Task UpdateTiposPruebas(TiposPruebas tipospruebas)
        {
            var tiposPruebasItem = await _context.TiposPruebas.FirstOrDefaultAsync(x => x.id_tipo_prueba == tipospruebas.id_tipo_prueba);
            if (tiposPruebasItem != null)
            {
                tiposPruebasItem.id_tipo_prueba = tipospruebas.id_tipo_prueba;
                tiposPruebasItem.nombre_tipo_prueba = tipospruebas.nombre_tipo_prueba;
                tiposPruebasItem.descripcion_tipo_prueba = tipospruebas.descripcion_tipo_prueba;

                await _context.SaveChangesAsync();

            }
        }
    }
}
