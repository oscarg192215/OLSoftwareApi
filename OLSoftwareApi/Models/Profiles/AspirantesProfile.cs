using AutoMapper;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Profiles
{
    public class AspirantesProfile : Profile
    {
        public AspirantesProfile()
        {
            CreateMap<Aspirantes, AspirantesDTO>();
            CreateMap<AspirantesDTO, Aspirantes>();
        }
    }
}
