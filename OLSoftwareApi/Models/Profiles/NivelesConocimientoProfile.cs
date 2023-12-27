using AutoMapper;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Profiles
{
    public class NivelesConocimientoProfile : Profile
    {
        public NivelesConocimientoProfile()
        {
            CreateMap<NivelesConocimiento, NivelesConocimientoDTO>();
            CreateMap<NivelesConocimientoDTO, NivelesConocimiento>();
        }
    }
}
