using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public interface INivelesConocimientoRepository
    {
        Task<List<NivelesConocimiento>> GetlistNivelesConocimiento();
        Task<NivelesConocimiento> GetNivelesConocimiento(int id);
        Task DeleteNivelesConocimiento(NivelesConocimiento nivelesconocimiento);
        Task<NivelesConocimiento> AddNivelesConocimiento(NivelesConocimiento nivelesconocimiento);
        Task UpdateNivelesConocimiento(NivelesConocimiento nivelesconocimiento);
    }
}
