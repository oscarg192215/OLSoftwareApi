using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OLSoftwareApi.Models;
using OLSoftwareApi.Models.DTO;
using OLSoftwareApi.Models.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OLSoftwareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LenguajesProgramacionController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ILenguajesProgramacionRepository _lenguajeProgamacionRepository;

        public LenguajesProgramacionController(IMapper mapper, ILenguajesProgramacionRepository lenguajeProgamacionRepository)
        {
            _mapper = mapper;
            _lenguajeProgamacionRepository = lenguajeProgamacionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listLenguajeProgramacion = await _lenguajeProgamacionRepository.GetlistLenguajesProgramacion();

                var listLenguajeProgramacionDto = _mapper.Map<IEnumerable<LenguajesProgramacionDTO>>(listLenguajeProgramacion);

                return Ok(listLenguajeProgramacionDto);
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
                var lenguajeProgamacion = await _lenguajeProgamacionRepository.GetLenguajesProgramacion(id);

                if (lenguajeProgamacion == null)
                {
                    return NotFound();
                }

                var lenguajeProgamacionDto = _mapper.Map<LenguajesProgramacion>(lenguajeProgamacion);

                return Ok(lenguajeProgamacionDto);

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
                var lenguajeProgamacion = await _lenguajeProgamacionRepository.GetLenguajesProgramacion(id);

                if (lenguajeProgamacion == null)
                {
                    return NotFound();
                }

                await _lenguajeProgamacionRepository.DeleteLenguajesProgramacion(lenguajeProgamacion);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(LenguajesProgramacionDTO lenguajeProgamacionDto)
        {
            try
            {
                var lenguajeProgamacion = _mapper.Map<LenguajesProgramacion>(lenguajeProgamacionDto);

                lenguajeProgamacion = await _lenguajeProgamacionRepository.AddLenguajesProgramacion(lenguajeProgamacion);

                var lenguajeProgamacionItemDto = _mapper.Map<LenguajesProgramacionDTO>(lenguajeProgamacion);

                return CreatedAtAction("Get", new { id = lenguajeProgamacionItemDto.id_lenguaje }, lenguajeProgamacionItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, LenguajesProgramacionDTO lenguajeProgamacionDto)
        {
            try
            {
                var lenguajeProgamacion = _mapper.Map<LenguajesProgramacion>(lenguajeProgamacionDto);
                lenguajeProgamacion.id_lenguaje = id;

                var lenguajeProgamacionItem = await _lenguajeProgamacionRepository.GetLenguajesProgramacion(id);

                if (lenguajeProgamacionItem == null)
                {
                    return NotFound();
                }

                await _lenguajeProgamacionRepository.UpdateLenguajesProgramacion(lenguajeProgamacion);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
