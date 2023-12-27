using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLSoftwareApi.Models.DTO;
using OLSoftwareApi.Models.Repository;

namespace OLSoftwareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleController : ControllerBase
    {
        private readonly IDetalleRepository _detalleRepository;
        private readonly IMapper _mapper;

        public DetalleController(IDetalleRepository detalleRepository, IMapper mapper)
        {
            _detalleRepository = detalleRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var detalle = _detalleRepository.GetDetalle(id);

                if (detalle == null)
                {
                    return NotFound();
                }

                

                return Ok(detalle);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
