using AutoMapper;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Profiles
{
    public class RespuestaPruebaAspiranteProfile : Profile
    {
        public RespuestaPruebaAspiranteProfile()
        {
            CreateMap<RespuestaPruebaAspirante, RespuestaPruebaAspiranteDTO>();
            CreateMap<RespuestaPruebaAspiranteDTO, RespuestaPruebaAspirante>();
        }
    }
}
