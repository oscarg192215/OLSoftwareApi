using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public interface IPreguntasRepository
    {
        Task<List<Preguntas>> GetlistPreguntas();
        Task<Preguntas> GetPreguntas(int id);
        Task DeletePreguntas(Preguntas preguntas);
        Task<Preguntas> AddPreguntas(Preguntas preguntas);
        Task UpdatePreguntas(PreguntasDTO preguntas);
    }
}
