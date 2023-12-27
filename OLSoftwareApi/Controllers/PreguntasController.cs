using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLSoftwareApi.Models;
using OLSoftwareApi.Models.DTO;
using OLSoftwareApi.Models.Repository;

namespace OLSoftwareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPreguntasRepository _preguntasRepository;

        public PreguntasController(IMapper mapper, IPreguntasRepository preguntasRepository)
        {
            _mapper = mapper;
            _preguntasRepository = preguntasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listPreguntas = await _preguntasRepository.GetlistPreguntas();

                var listPreguntasDto = _mapper.Map<IEnumerable<Preguntas>>(listPreguntas);

                return Ok(listPreguntasDto);
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
                var preguntas = await _preguntasRepository.GetPreguntas(id);

                if (preguntas == null)
                {
                    return NotFound();
                }

                var preguntasDto = _mapper.Map<Preguntas>(preguntas);

                return Ok(preguntasDto);

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
                var preguntas = await _preguntasRepository.GetPreguntas(id);

                if (preguntas == null)
                {
                    return NotFound();
                }

                await _preguntasRepository.DeletePreguntas(preguntas);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PreguntasDTO preguntasDto)
        {
            try
            {
                var preguntas = _mapper.Map<Preguntas>(preguntasDto);

                preguntas = await _preguntasRepository.AddPreguntas(preguntas);

                var preguntasItemDto = _mapper.Map<PreguntasDTO>(preguntas);

                return CreatedAtAction("Get", new { id = preguntasItemDto.id_pregunta }, preguntasDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PreguntasDTO preguntasDto)
        {
            try
            {
               var preguntasItem = await _preguntasRepository.GetPreguntas(id);

                if (preguntasItem == null)
                {
                    return NotFound();
                }

                preguntasDto.id_pregunta = id;
                await _preguntasRepository.UpdatePreguntas(preguntasDto);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
