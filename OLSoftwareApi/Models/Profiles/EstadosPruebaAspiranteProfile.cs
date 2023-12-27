using AutoMapper;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Profiles
{
    public class EstadosPruebaAspiranteProfile: Profile
    {
        public EstadosPruebaAspiranteProfile()
        {
            CreateMap<EstadosPruebaAspirante, EstadosPruebaAspiranteDTO>();
            CreateMap<EstadosPruebaAspiranteDTO, EstadosPruebaAspirante>();
        }
    }
}
