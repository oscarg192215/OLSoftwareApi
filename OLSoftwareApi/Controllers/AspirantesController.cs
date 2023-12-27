using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLSoftwareApi.Models.Repository;
using OLSoftwareApi.Models;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspirantesController : ControllerBase
    {
        private readonly IAspirantesRepository _aspirantesRepository;
        private readonly IMapper _mapper;

        public AspirantesController(IAspirantesRepository aspirantesRepository, IMapper mapper)
        {
            _aspirantesRepository = aspirantesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaspirantes = await _aspirantesRepository.GetlistAspirantes();

                var listaspirantesDto = _mapper.Map<IEnumerable<AspiranteDetalleDTO>>(listaspirantes);

                return Ok(listaspirantesDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var aspirantes = await _aspirantesRepository.GetAspirantes(id);

                if (aspirantes == null)
                {
                    return NotFound();
                }

                var aspirantesDto = _mapper.Map<AspiranteDetalleDTO>(aspirantes);

                return Ok(aspirantesDto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var aspirantes = await _aspirantesRepository.GetAspirantes(id);

                if (aspirantes == null)
                {
                    return NotFound();
                }               

                await _aspirantesRepository.DeleteAspirantes(aspirantes.id_prueba_aspirante, aspirantes.id_aspirante);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aspirantes aspirantesDto)
        {
            try
            {
                await _aspirantesRepository.AddAspirantes(aspirantesDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AspiranteDetalleDTO aspirantesDto)
        {
            try
            {
                var aspirantes = await _aspirantesRepository.GetAspirantes(id);

                if (aspirantes == null)
                {
                    return NotFound();
                }

                Aspirantes aspirantesMap = new();
                aspirantesMap.id_aspirante = aspirantesDto.id_aspirante;
                aspirantesMap.id_login = aspirantesDto.id_login;
                aspirantesMap.nombre_aspirante = aspirantesDto.nombre_aspirante;
                aspirantesMap.apellido_aspirante = aspirantesDto.apellido_aspirante;
                aspirantesMap.documento_aspirante = aspirantesDto.documento_aspirante;
                aspirantesMap.fecha_nacimiento_aspirante = aspirantesDto.fecha_nacimiento_aspirante;
                aspirantesMap.celular_aspirante = aspirantesDto.celular_aspirante;
                aspirantesMap.email_aspirante = aspirantesDto.email_aspirante;
                aspirantesMap.direccion_aspirante = aspirantesDto.direccion_aspirante;
                aspirantesMap.pais_aspirante = aspirantesDto.pais_aspirante;
                aspirantesMap.ciudad_aspirante = aspirantesDto.ciudad_aspirante;
                aspirantesMap.fecha_inicio = aspirantesDto.fecha_inicio;
                aspirantesMap.fecha_finalizacion = aspirantesDto.fecha_finalizacion;
                aspirantesMap.id_prueba = aspirantesDto.id_prueba;
                aspirantesMap.id_prueba_aspirante = aspirantesDto.id_prueba_aspirante;
                await _aspirantesRepository.UpdateAspirantes(aspirantesMap);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
