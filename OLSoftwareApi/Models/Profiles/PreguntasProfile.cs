using AutoMapper;
using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Profiles
{
    public class PreguntasProfile: Profile
    {
        public PreguntasProfile() 
        {
            CreateMap<Preguntas, PreguntasDTO>();
            CreateMap<PreguntasDTO, Preguntas>();
        }
    }
}
