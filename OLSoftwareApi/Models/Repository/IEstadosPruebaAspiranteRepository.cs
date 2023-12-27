using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public interface IEstadosPruebaAspiranteRepository
    {
        Task<List<EstadosPruebaAspirante>> GetlistEstadosPruebaAspirante();
        Task<EstadosPruebaAspirante> GetEstadosPruebaAspirante(int id);
        Task DeleteEstadosPruebaAspirante(EstadosPruebaAspirante estadospruebaaspirante);
        Task<EstadosPruebaAspirante> AddEstadosPruebaAspirante(EstadosPruebaAspirante estadospruebaaspirante);
        Task UpdateEstadosPruebaAspirante(EstadosPruebaAspirante estadospruebaaspirante);
    }
}
