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
    public class NivelesConocimientoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INivelesConocimientoRepository _nivelesConocimientoRepository;

        public NivelesConocimientoController(IMapper mapper, INivelesConocimientoRepository nivelesConocimientoRepository)
        {
            _mapper = mapper;
            _nivelesConocimientoRepository = nivelesConocimientoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listNivelesConocimiento = await _nivelesConocimientoRepository.GetlistNivelesConocimiento();

                var listNivelesConocimientoDto = _mapper.Map<IEnumerable<NivelesConocimientoDTO>>(listNivelesConocimiento);

                return Ok(listNivelesConocimientoDto);
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
                var nivelesConocimiento = await _nivelesConocimientoRepository.GetNivelesConocimiento(id);

                if (nivelesConocimiento == null)
                {
                    return NotFound();
                }

                var nivelesConocimientoDto = _mapper.Map<NivelesConocimiento>(nivelesConocimiento);

                return Ok(nivelesConocimientoDto);

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
                var nivelesConocimiento = await _nivelesConocimientoRepository.GetNivelesConocimiento(id);

                if (nivelesConocimiento == null)
                {
                    return NotFound();
                }

                await _nivelesConocimientoRepository.DeleteNivelesConocimiento(nivelesConocimiento);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(NivelesConocimientoDTO nivelesConocimientoDto)
        {
            try
            {
                var nivelesConocimiento = _mapper.Map<NivelesConocimiento>(nivelesConocimientoDto);

                nivelesConocimiento = await _nivelesConocimientoRepository.AddNivelesConocimiento(nivelesConocimiento);

                var nivelesConocimientoItemDto = _mapper.Map<NivelesConocimientoDTO>(nivelesConocimiento);

                return CreatedAtAction("Get", new { id = nivelesConocimientoItemDto.id_nivel }, nivelesConocimientoDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, NivelesConocimientoDTO nivelesConocimientoDto)
        {
            try
            {
                var nivelesConocimiento = _mapper.Map<NivelesConocimiento>(nivelesConocimientoDto);
                nivelesConocimiento.id_nivel = id;

                var nivelesConocimientoItem = await _nivelesConocimientoRepository.GetNivelesConocimiento(id);

                if (nivelesConocimientoItem == null)
                {
                    return NotFound();
                }

                await _nivelesConocimientoRepository.UpdateNivelesConocimiento(nivelesConocimiento);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
