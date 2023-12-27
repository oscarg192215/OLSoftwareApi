using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public class PruebasRepository : IPruebasRepository
    {
        private readonly AplicationDbContext _context;

        public PruebasRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pruebas> AddPruebas(PruebasDTO pruebas)
        {
            try
            {
                int cantidad_preguntas = 0;

                if (pruebas.id_pregunta != null )
                {
                    cantidad_preguntas = pruebas.id_pregunta.Length;
                }
                else
                    cantidad_preguntas = 0;

                    var pruebasItem = new Pruebas
                    {
                        id_prueba = pruebas.id_prueba,
                        id_tipo_prueba = pruebas.id_tipo_prueba,
                        nombre_prueba = pruebas.nombre_prueba,
                        id_lenguaje = pruebas.id_lenguaje,
                        id_nivel = pruebas.id_nivel,
                        cantidad_preguntas = cantidad_preguntas,
                        id_estado_prueba_aspirante = pruebas.id_estado_prueba_aspirante
                    };
                _context.Add(pruebasItem);
                await _context.SaveChangesAsync();

                if (pruebas.id_pregunta != null)
                {
                    foreach (int item in pruebas.id_pregunta)
                    {
                        var pruebaspreguntasItem = new PruebasPreguntas
                        {
                            id_pregunta = item,
                            id_prueba = pruebasItem.id_prueba
                        };
                        _context.PruebasPreguntas.Add(pruebaspreguntasItem);
                        await _context.SaveChangesAsync();
                    }
                }
                

                return pruebasItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletePruebas(int id_prueba)
        {
            var listPruebasPreguntas = await _context.PruebasPreguntas.Where(x => x.id_prueba.Equals(id_prueba)).ToListAsync();
            if (listPruebasPreguntas != null)
            {
                foreach (var item in listPruebasPreguntas)
                {
                    _context.PruebasPreguntas.Remove(item);
                    await _context.SaveChangesAsync();
                }
            }
            var pruebas = await _context.Pruebas.FindAsync(id_prueba);
            _context.Remove(pruebas);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Pruebas>> GetlistPruebas()
        {
            return await _context.Pruebas.Include(tp => tp.TiposPruebas).Include(l => l.LenguajesProgramacion).Include(n => n.NivelesConocimiento).Include(e=>e.EstadosPruebaAspirante).ToListAsync();
        }

        public async Task<PruebaDetalleDTO> GetPruebas(int id)
        {
            PruebaDetalleDTO detalle = new PruebaDetalleDTO();

            Pruebas prueba = new Pruebas();
            prueba = await _context.Pruebas.Include(tp => tp.TiposPruebas).Include(l => l.LenguajesProgramacion).Include(n => n.NivelesConocimiento).Include(e => e.EstadosPruebaAspirante).Where(x => x.id_prueba.Equals(id)).FirstOrDefaultAsync();

            if (prueba != null)
            {
                detalle.id_prueba = prueba.id_prueba;
                detalle.nombre_prueba = prueba.nombre_prueba;
                detalle.id_tipo_prueba = prueba.id_tipo_prueba;
                detalle.nombre_tipo_prueba = prueba.TiposPruebas.nombre_tipo_prueba;
                detalle.id_lenguaje = prueba.id_lenguaje;
                detalle.nombre_lenguaje = prueba.LenguajesProgramacion.nombre_lenguaje;
                detalle.id_nivel = prueba.id_nivel;
                detalle.nombre_nivel = prueba.NivelesConocimiento.nombre_nivel;
                detalle.cantidad_preguntas = prueba.cantidad_preguntas;
                detalle.id_estado_prueba_aspirante = prueba.id_estado_prueba_aspirante;
                detalle.nombre_estado = prueba.EstadosPruebaAspirante.nombre_estado;
                var preguntas = await _context.PruebasPreguntas.Include(p => p.Preguntas).Where(x => x.id_prueba.Equals(prueba.id_prueba)).Select(p => p.Preguntas).ToListAsync();

                detalle.Preguntas = preguntas;
            }

            return detalle;
        }

        public async Task UpdatePruebas(PruebasDTO pruebas)
        {
            try
            {
                int cantidad_preguntas = 0;
                var pruebasItem = await _context.Pruebas.FirstOrDefaultAsync(x => x.id_prueba == pruebas.id_prueba);

                var listPruebasPreguntas = await _context.PruebasPreguntas.Where(x => x.id_prueba.Equals(pruebas.id_prueba)).ToListAsync();
                if (listPruebasPreguntas != null)
                {
                    foreach (var item in listPruebasPreguntas)
                    {
                        _context.PruebasPreguntas.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }

                if (pruebas.id_pregunta != null)
                {
                    foreach (int item in pruebas.id_pregunta)
                    {
                        if (item > 0)
                        {
                            var pruebaspreguntasItem = new PruebasPreguntas
                            {
                                id_pregunta = item,
                                id_prueba = pruebasItem.id_prueba
                            };
                            _context.PruebasPreguntas.Add(pruebaspreguntasItem);
                            await _context.SaveChangesAsync();
                            cantidad_preguntas++;
                        }
                    }
                }                

                if (pruebasItem != null)
                {
                    pruebasItem.id_prueba = pruebas.id_prueba;
                    pruebasItem.nombre_prueba = pruebas.nombre_prueba;
                    pruebasItem.id_tipo_prueba = pruebas.id_tipo_prueba;
                    pruebasItem.cantidad_preguntas = cantidad_preguntas;
                    pruebasItem.id_lenguaje = pruebas.id_lenguaje;
                    pruebasItem.id_nivel = pruebas.id_nivel;
                    pruebasItem.id_estado_prueba_aspirante = pruebas.id_estado_prueba_aspirante;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
