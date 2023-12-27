using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OLSoftwareApi.Models.DTO;
using System.Collections.Generic;

namespace OLSoftwareApi.Models.Repository
{
    [AllowAnonymous]
    public class AspirantesRepository : IAspirantesRepository
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;

        public AspirantesRepository(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAspirantes(Aspirantes aspirantes)
        {
            try
            {
                _context.Add(aspirantes);
                await _context.SaveChangesAsync();

                PruebaAspirante pruebaAspirante = new()
                {
                    id_prueba_aspirante = 0,
                    id_aspirante = aspirantes.id_aspirante,
                    id_prueba = aspirantes.id_prueba,
                    fecha_inicio = aspirantes.fecha_inicio,
                    fecha_finalizacion = aspirantes.fecha_finalizacion
                };

                _context.PruebaAspirante.Add(pruebaAspirante);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAspirantes(int id_prueba_aspirante, int id_aspirante)
        {
            var pruebaAspirante = await _context.PruebaAspirante.FindAsync(id_prueba_aspirante);

            if (pruebaAspirante != null)
            {
                _context.Remove(pruebaAspirante);
                await _context.SaveChangesAsync();
            }

            var aspirante = await _context.Aspirantes.FindAsync(id_aspirante);
            if (aspirante != null)
            {
                _context.Remove(aspirante);
                await _context.SaveChangesAsync();
            }            
        }

        public async Task<AspiranteDetalleDTO> GetAspirantes(int id)
        {
            var queryDto = await (from a in _context.Aspirantes
                                  join p in _context.PruebaAspirante on a.id_aspirante equals p.id_aspirante
                                  join pr in _context.Pruebas on p.id_prueba equals pr.id_prueba
                                  where p.id_prueba_aspirante == id
                                  orderby a.id_aspirante
                                  select new
                                  {
                                      a.id_aspirante,
                                      a.nombre_aspirante,
                                      a.apellido_aspirante,
                                      a.documento_aspirante,
                                      a.celular_aspirante,
                                      a.ciudad_aspirante,
                                      a.direccion_aspirante,
                                      a.email_aspirante,
                                      a.fecha_nacimiento_aspirante,
                                      a.id_login,
                                      a.pais_aspirante,
                                      pr.id_prueba,
                                      pr.nombre_prueba,
                                      pr.cantidad_preguntas,
                                      p.fecha_inicio,
                                      p.fecha_finalizacion,
                                      p.id_prueba_aspirante
                                  }).FirstOrDefaultAsync();

            AspiranteDetalleDTO detalle = new();

            if (queryDto != null)
            {
                detalle.id_aspirante = queryDto.id_aspirante;
                detalle.nombre_aspirante = queryDto.nombre_aspirante;
                detalle.apellido_aspirante = queryDto.apellido_aspirante;
                detalle.documento_aspirante = queryDto.documento_aspirante;
                detalle.celular_aspirante = queryDto.celular_aspirante;
                detalle.ciudad_aspirante = queryDto.ciudad_aspirante;
                detalle.direccion_aspirante = queryDto.direccion_aspirante;
                detalle.email_aspirante = queryDto.email_aspirante;
                detalle.fecha_nacimiento_aspirante = queryDto.fecha_nacimiento_aspirante;
                detalle.id_login = queryDto.id_login;
                detalle.pais_aspirante = queryDto.pais_aspirante;
                detalle.id_prueba = queryDto.id_prueba;
                detalle.nombre_prueba = queryDto.nombre_prueba;
                detalle.cantidad_preguntas = queryDto.cantidad_preguntas;
                detalle.fecha_inicio = queryDto.fecha_inicio;
                detalle.fecha_finalizacion = queryDto.fecha_finalizacion;
                detalle.id_prueba_aspirante = queryDto.id_prueba_aspirante;
            }
            return detalle;
        }

        public async Task<List<AspiranteDetalleDTO>> GetlistAspirantes()
        {
            List<AspiranteDetalleDTO> listaDetalle = new();
            var queryDto = await (from a in _context.Aspirantes
                                  join p in _context.PruebaAspirante on a.id_aspirante equals p.id_aspirante
                                  join pr in _context.Pruebas on p.id_prueba equals pr.id_prueba
                                  orderby a.id_aspirante
                                  select new
                                  {
                                      a.id_aspirante,
                                      a.nombre_aspirante,
                                      a.apellido_aspirante,
                                      a.documento_aspirante,
                                      a.celular_aspirante,
                                      a.ciudad_aspirante,
                                      a.direccion_aspirante,
                                      a.email_aspirante,
                                      a.fecha_nacimiento_aspirante,
                                      a.id_login,
                                      a.pais_aspirante,
                                      pr.id_prueba,
                                      pr.nombre_prueba,
                                      pr.cantidad_preguntas,
                                      p.fecha_inicio,
                                      p.fecha_finalizacion,
                                      p.id_prueba_aspirante
                                  }).ToListAsync();



            foreach (var item in queryDto)
            {
                AspiranteDetalleDTO detalle = new();
                detalle.id_aspirante = item.id_aspirante;
                detalle.nombre_aspirante = item.nombre_aspirante;
                detalle.apellido_aspirante = item.apellido_aspirante;
                detalle.documento_aspirante = item.documento_aspirante;
                detalle.celular_aspirante = item.celular_aspirante;
                detalle.ciudad_aspirante = item.ciudad_aspirante;
                detalle.direccion_aspirante = item.direccion_aspirante;
                detalle.email_aspirante = item.email_aspirante;
                detalle.fecha_nacimiento_aspirante = item.fecha_nacimiento_aspirante;
                detalle.id_login = item.id_login;
                detalle.pais_aspirante = item.pais_aspirante;
                detalle.id_prueba = item.id_prueba;
                detalle.nombre_prueba = item.nombre_prueba;
                detalle.cantidad_preguntas = item.cantidad_preguntas;
                detalle.fecha_inicio = item.fecha_inicio;
                detalle.fecha_finalizacion = item.fecha_finalizacion;
                detalle.id_prueba_aspirante = item.id_prueba_aspirante;
                listaDetalle.Add(detalle);
            }


            //var list = await _context.Aspirantes.ToListAsync();
            return listaDetalle.ToList();
        }

        public async Task UpdateAspirantes(Aspirantes aspirantes)
        {  
            try
            {
                var aspirantePruebas = await _context.PruebaAspirante.FindAsync(aspirantes.id_prueba_aspirante);
                if (aspirantePruebas != null)
                {
                    aspirantePruebas.id_prueba_aspirante = aspirantes.id_prueba_aspirante;
                    aspirantePruebas.id_prueba = aspirantes.id_prueba;
                    aspirantePruebas.id_aspirante = aspirantes.id_aspirante;
                    aspirantePruebas.fecha_finalizacion = aspirantes.fecha_finalizacion;
                    aspirantePruebas.fecha_inicio = aspirantes.fecha_inicio;
                    await _context.SaveChangesAsync();
                }
                var aspirantesItem = await _context.Aspirantes.FindAsync(aspirantes.id_aspirante);
                if (aspirantesItem != null) 
                { 
                    aspirantesItem.id_aspirante = aspirantes.id_aspirante;
                    aspirantesItem.id_login = aspirantes.id_login;
                    aspirantesItem.nombre_aspirante = aspirantes.nombre_aspirante;
                    aspirantesItem.apellido_aspirante = aspirantes.apellido_aspirante;
                    aspirantesItem.documento_aspirante = aspirantes.documento_aspirante;
                    aspirantesItem.fecha_nacimiento_aspirante = aspirantes.fecha_nacimiento_aspirante;
                    aspirantesItem.celular_aspirante = aspirantes.celular_aspirante;
                    aspirantesItem.email_aspirante = aspirantes.email_aspirante;
                    aspirantesItem.direccion_aspirante = aspirantes.direccion_aspirante;
                    aspirantesItem.pais_aspirante = aspirantes.pais_aspirante;
                    aspirantesItem.ciudad_aspirante = aspirantes.ciudad_aspirante;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
