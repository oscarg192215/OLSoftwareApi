using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLSoftwareApi.Models.DTO;
using OLSoftwareApi.Models;
using AutoMapper;
using OLSoftwareApi.Models.Repository;

namespace OLSoftwareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebasPreguntasController : ControllerBase
    {
        private readonly IPruebasPreguntasRepository _pruebasPreguntasRepository;
        private readonly IMapper _mapper;

        public PruebasPreguntasController(IPruebasPreguntasRepository pruebasPreguntasRepository, IMapper mapper)
        {
            _pruebasPreguntasRepository = pruebasPreguntasRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listpruebasPreguntas = await _pruebasPreguntasRepository.GetlistPruebasPreguntas();

                var listpruebasPreguntasDto = _mapper.Map<IEnumerable<PruebasPreguntas>>(listpruebasPreguntas);

                return Ok(listpruebasPreguntasDto);
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
                var pruebasPreguntas = await _pruebasPreguntasRepository.GetPruebasPreguntas(id);

                if (pruebasPreguntas == null)
                {
                    return NotFound();
                }

                var pruebasPreguntasDto = _mapper.Map<PruebasPreguntas>(pruebasPreguntas);

                return Ok(pruebasPreguntasDto);

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
                var pruebasPreguntas = await _pruebasPreguntasRepository.GetPruebasPreguntas(id);

                if (pruebasPreguntas == null)
                {
                    return NotFound();
                }

                await _pruebasPreguntasRepository.DeletePruebasPreguntas(pruebasPreguntas);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PruebasPreguntas pruebasPreguntasDto)
        {
            try
            {
                var pruebasPreguntas = _mapper.Map<PruebasPreguntas>(pruebasPreguntasDto);

                pruebasPreguntas = await _pruebasPreguntasRepository.AddPruebasPreguntas(pruebasPreguntas);

                var pruebasPreguntasItemDto = _mapper.Map<PruebasPreguntas>(pruebasPreguntas);

                return CreatedAtAction("Get", new { id = pruebasPreguntasItemDto.id_prueba_pregunta }, pruebasPreguntasItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PruebasPreguntas pruebasPreguntasDto)
        {
            try
            {
                var pruebasPreguntas = _mapper.Map<PruebasPreguntas>(pruebasPreguntasDto);
                pruebasPreguntas.id_prueba_pregunta = id;

                var pruebasPreguntasItem = await _pruebasPreguntasRepository.GetPruebasPreguntas(id);

                if (pruebasPreguntasItem == null)
                {
                    return NotFound();
                }

                await _pruebasPreguntasRepository.UpdatePruebasPreguntas(pruebasPreguntas);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
