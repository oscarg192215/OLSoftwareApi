using AutoMapper;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Profiles
{
    public class LenguajesProgramacionProfile : Profile
    {
        public LenguajesProgramacionProfile()
        {
            CreateMap<LenguajesProgramacion, LenguajesProgramacionDTO>();
            CreateMap<LenguajesProgramacionDTO, LenguajesProgramacion>();
        }
    }
}
