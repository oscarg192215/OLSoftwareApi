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
    public class RespuestaPruebaAspiranteController : ControllerBase
    {
        private readonly IRespuestaPruebaAspiranteRepository _respuestaPruebaAspiranteRepository;
        private readonly IMapper _mapper;

        public RespuestaPruebaAspiranteController(IRespuestaPruebaAspiranteRepository respuestaPruebaAspiranteRepository, IMapper mapper)
        {
            _respuestaPruebaAspiranteRepository = respuestaPruebaAspiranteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listrespuestaPruebaAspirante = await _respuestaPruebaAspiranteRepository.GetlistRespuestaPruebaAspirante();

                return Ok(listrespuestaPruebaAspirante);
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
                var respuestaPruebaAspirante = await _respuestaPruebaAspiranteRepository.GetRespuebaAspirante(id);

                if (respuestaPruebaAspirante == null)
                {
                    return NotFound();
                }

                return Ok(respuestaPruebaAspirante);

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
                var respuestaPruebaAspirante = await _respuestaPruebaAspiranteRepository.GetRespuebaAspirante(id);

                if (respuestaPruebaAspirante == null)
                {
                    return NotFound();
                }
                var respuestaPruebaAspiranteItem = _mapper.Map<RespuestaPruebaAspirante>(respuestaPruebaAspirante);
                await _respuestaPruebaAspiranteRepository.DeleteRespuestaPruebaAspirante(respuestaPruebaAspiranteItem);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(RespuestaPruebaAspiranteDTO respuestaPruebaAspiranteDto)
        {
            try
            {
                var respuestaPruebaAspirante = _mapper.Map<RespuestaPruebaAspirante>(respuestaPruebaAspiranteDto);

                respuestaPruebaAspirante = await _respuestaPruebaAspiranteRepository.AddRespuestaPruebaAspirante(respuestaPruebaAspirante);

                var lenguajeProgamacionItemDto = _mapper.Map<LenguajesProgramacionDTO>(respuestaPruebaAspirante);

                return CreatedAtAction("Get", new { id = lenguajeProgamacionItemDto.id_lenguaje }, lenguajeProgamacionItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, RespuestaPruebaAspiranteDTO respuestaPruebaAspiranteDto)
        {
            try
            {
                var respuestaPruebaAspirante = _mapper.Map<RespuestaPruebaAspirante>(respuestaPruebaAspiranteDto);
                respuestaPruebaAspirante.id_respuesta_prueba_aspirante = id;

                var respuestaPruebaAspiranteItem = await _respuestaPruebaAspiranteRepository.GetRespuebaAspirante(id);

                if (respuestaPruebaAspiranteItem == null)
                {
                    return NotFound();
                }

                await _respuestaPruebaAspiranteRepository.UpdateRespuestaPruebaAspirante(respuestaPruebaAspirante);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
