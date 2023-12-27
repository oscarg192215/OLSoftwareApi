using AutoMapper;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Profiles
{
    public class PruebaAspiranteProfile : Profile
    {
        public PruebaAspiranteProfile()
        {
            CreateMap<PruebaAspirante, PruebaAspiranteDTO>();
            CreateMap<PruebaAspiranteDTO, PruebaAspirante>();
        }
    }
}
