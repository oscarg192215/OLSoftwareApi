using AutoMapper;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Profiles
{
    public class TiposPruebasProfile : Profile
    {
        public TiposPruebasProfile()
        {
            CreateMap<TiposPruebas, TiposPruebasDTO>();
            CreateMap<TiposPruebasDTO, TiposPruebas>();
        }
    }
}
