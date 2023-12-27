using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OLSoftwareApi.Models.DTO;
using OLSoftwareApi.Models.Repository;
using OLSoftwareApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OLSoftwareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosPruebaAspiranteController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IEstadosPruebaAspiranteRepository _estadosPruebaAspiranteRepository;

        public EstadosPruebaAspiranteController(IMapper mapper, IEstadosPruebaAspiranteRepository estadosPruebaAspiranteRepository)
        {
            _mapper = mapper;
            _estadosPruebaAspiranteRepository  = estadosPruebaAspiranteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listEstadosPruebaAspirante = await _estadosPruebaAspiranteRepository.GetlistEstadosPruebaAspirante();

                var listEstadosPruebaAspiranteDto = _mapper.Map<IEnumerable<EstadosPruebaAspiranteDTO>>(listEstadosPruebaAspirante);

                return Ok(listEstadosPruebaAspiranteDto);
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
                var estadosPruebaAspirante = await _estadosPruebaAspiranteRepository.GetEstadosPruebaAspirante(id);

                if (estadosPruebaAspirante == null)
                {
                    return NotFound();
                }

                var estadosPruebaAspiranteDto = _mapper.Map<EstadosPruebaAspirante>(estadosPruebaAspirante);

                return Ok(estadosPruebaAspiranteDto);

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
                var estadosPruebaAspirante = await _estadosPruebaAspiranteRepository.GetEstadosPruebaAspirante(id);

                if (estadosPruebaAspirante == null)
                {
                    return NotFound();
                }

                await _estadosPruebaAspiranteRepository.DeleteEstadosPruebaAspirante(estadosPruebaAspirante);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EstadosPruebaAspiranteDTO estadosPruebaAspiranteDto)
        {
            try
            {
                var estadosPruebaAspirante = _mapper.Map<EstadosPruebaAspirante>(estadosPruebaAspiranteDto);

                estadosPruebaAspirante = await _estadosPruebaAspiranteRepository.AddEstadosPruebaAspirante(estadosPruebaAspirante);

                var estadosPruebaAspiranteItemDto = _mapper.Map<EstadosPruebaAspiranteDTO>(estadosPruebaAspirante);

                return CreatedAtAction("Get", new { id = estadosPruebaAspiranteItemDto.id_estado_prueba_aspirante }, estadosPruebaAspiranteDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EstadosPruebaAspiranteDTO estadosPruebaAspiranteDto)
        {
            try
            {
                var estadosPruebaAspirante = _mapper.Map<EstadosPruebaAspirante>(estadosPruebaAspiranteDto);
                estadosPruebaAspirante.id_estado_prueba_aspirante = id;

                var estadosPruebaAspiranteItem = await _estadosPruebaAspiranteRepository.GetEstadosPruebaAspirante(id);

                if (estadosPruebaAspiranteItem == null)
                {
                    return NotFound();
                }

                await _estadosPruebaAspiranteRepository.UpdateEstadosPruebaAspirante(estadosPruebaAspirante);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
