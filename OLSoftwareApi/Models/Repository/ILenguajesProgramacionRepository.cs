using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public interface ILenguajesProgramacionRepository
    {
        Task<List<LenguajesProgramacion>> GetlistLenguajesProgramacion();
        Task<LenguajesProgramacion> GetLenguajesProgramacion(int id);
        Task DeleteLenguajesProgramacion(LenguajesProgramacion lenguajesprogramacion);
        Task<LenguajesProgramacion> AddLenguajesProgramacion(LenguajesProgramacion lenguajesprogramacion);
        Task UpdateLenguajesProgramacion(LenguajesProgramacion lenguajesprogramacion);
    }
}
