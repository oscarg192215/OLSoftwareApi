using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLSoftwareApi.Models.DTO;
using OLSoftwareApi.Models;
using OLSoftwareApi.Models.Repository;

namespace OLSoftwareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposPruebasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITiposPruebasRepository _tiposPruebasRepository;

        public TiposPruebasController(IMapper mapper, ITiposPruebasRepository tiposPruebasRepository)
        {
            _mapper = mapper;
            _tiposPruebasRepository = tiposPruebasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listTiposPruebas = await _tiposPruebasRepository.GetlistTiposPruebas();

                var listTiposPruebasDto = _mapper.Map<IEnumerable<TiposPruebas>>(listTiposPruebas);

                return Ok(listTiposPruebasDto);
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
                var tiposPruebas = await _tiposPruebasRepository.GetTiposPruebas(id);

                if (tiposPruebas == null)
                {
                    return NotFound();
                }

                var tiposPruebasDto = _mapper.Map<TiposPruebas>(tiposPruebas);

                return Ok(tiposPruebasDto);

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
                var tiposPruebas = await _tiposPruebasRepository.GetTiposPruebas(id);

                if (tiposPruebas == null)
                {
                    return NotFound();
                }

                await _tiposPruebasRepository.DeleteTiposPruebas(tiposPruebas);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(TiposPruebasDTO tiposPruebasDto)
        {
            try
            {
                var tiposPruebas = _mapper.Map<TiposPruebas>(tiposPruebasDto);

                tiposPruebas = await _tiposPruebasRepository.AddTiposPruebas(tiposPruebas);

                var tiposPruebasItemDto = _mapper.Map<TiposPruebasDTO>(tiposPruebas);

                return CreatedAtAction("Get", new { id = tiposPruebasDto.id_tipo_prueba }, tiposPruebasDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TiposPruebasDTO tiposPruebasDto)
        {
            try
            {
                var tiposPruebas = _mapper.Map<TiposPruebas>(tiposPruebasDto);
                tiposPruebas.id_tipo_prueba = id;

                var tiposPruebasItem = await _tiposPruebasRepository.GetTiposPruebas(id);

                if (tiposPruebasItem == null)
                {
                    return NotFound();
                }

                await _tiposPruebasRepository.UpdateTiposPruebas(tiposPruebas);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
