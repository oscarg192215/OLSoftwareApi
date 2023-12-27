using AutoMapper;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Profiles
{
    public class PruebasProfile : Profile
    {
        public PruebasProfile()
        {
            CreateMap<Pruebas, PruebasDTO>();
            CreateMap<PruebasDTO, Pruebas>();
        }
    }
}
