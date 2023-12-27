using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLSoftwareApi.Models.DTO;
using OLSoftwareApi.Models.Repository;
using OLSoftwareApi.Models;
using System;

namespace OLSoftwareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPruebasRepository _pruebasRepository;

        public PruebasController(IMapper mapper, IPruebasRepository pruebasRepository)
        {
            _mapper = mapper;
            _pruebasRepository = pruebasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listpruebas = await _pruebasRepository.GetlistPruebas();

                return Ok(listpruebas);
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
                var pruebas = await _pruebasRepository.GetPruebas(id);

                if (pruebas == null)
                {
                    return NotFound();
                }

                return Ok(pruebas);

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
                var pruebas = await _pruebasRepository.GetPruebas(id);

                if (pruebas == null)
                {
                    return NotFound();
                }
                await _pruebasRepository.DeletePruebas(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PruebasDTO pruebasDto)
        {
            try
            {
                var pruebas = await _pruebasRepository.AddPruebas(pruebasDto);

                var pruebasItemDto = _mapper.Map<Pruebas>(pruebas);
                pruebasDto.id_prueba = pruebasItemDto.id_prueba;

                return CreatedAtAction("Get", new { id = pruebasItemDto.id_prueba }, pruebasDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PruebasDTO pruebasDto)
        {
            try
            {
                var pruebasItem = await _pruebasRepository.GetPruebas(id);

                if (pruebasItem == null)
                {
                    return NotFound();
                }

                pruebasDto.id_prueba = id;
                await _pruebasRepository.UpdatePruebas(pruebasDto);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
