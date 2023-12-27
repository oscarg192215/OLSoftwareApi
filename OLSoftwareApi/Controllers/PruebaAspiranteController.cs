using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLSoftwareApi.Models.Repository;
using OLSoftwareApi.Models;

namespace OLSoftwareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaAspiranteController : ControllerBase
    {
        private readonly IPruebaAspiranteRepository _pruebaAspiranteRepository;
        private readonly IMapper _mapper;

        public PruebaAspiranteController(IPruebaAspiranteRepository pruebaAspiranteRepository, IMapper mapper)
        {
            _pruebaAspiranteRepository = pruebaAspiranteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listpruebaAspirante = await _pruebaAspiranteRepository.GetlistPruebaAspirante();

                var listpruebaAspiranteDto = _mapper.Map<IEnumerable<PruebaAspirante>>(listpruebaAspirante);

                return Ok(listpruebaAspiranteDto);
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
                var pruebaAspirante = await _pruebaAspiranteRepository.GetPruebaAspirante(id);

                if (pruebaAspirante == null)
                {
                    return NotFound();
                }

                var pruebaAspiranteDto = _mapper.Map<PruebaAspirante>(pruebaAspirante);

                return Ok(pruebaAspiranteDto);

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
                var pruebaAspirante = await _pruebaAspiranteRepository.GetPruebaAspirante(id);

                if (pruebaAspirante == null)
                {
                    return NotFound();
                }

                await _pruebaAspiranteRepository.DeletePruebaAspirante(pruebaAspirante);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PruebaAspirante pruebaAspiranteDto)
        {
            try
            {
                var pruebaAspirante = await _pruebaAspiranteRepository.AddPruebaAspirante(pruebaAspiranteDto);

                var pruebaAspiranteItemDto = _mapper.Map<PruebaAspirante>(pruebaAspirante);

                return CreatedAtAction("Get", new { id = pruebaAspiranteItemDto.id_prueba_aspirante }, pruebaAspiranteItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PruebaAspirante pruebaAspiranteDto)
        {
            try
            {
                var pruebaAspirante = _mapper.Map<PruebaAspirante>(pruebaAspiranteDto);
                pruebaAspirante.id_prueba_aspirante = id;

                var pruebaAspiranteItem = await _pruebaAspiranteRepository.GetPruebaAspirante(id);

                if (pruebaAspiranteItem == null)
                {
                    return NotFound();
                }

                await _pruebaAspiranteRepository.UpdatePruebaAspirante(pruebaAspirante);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
