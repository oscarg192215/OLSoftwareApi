using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public interface IRespuestaPruebaAspiranteRepository
    {
        Task<List<RespuestaPruebaAspirante>> GetlistRespuestaPruebaAspirante();
        Task<RespuestaPruebaAspirante> GetRespuebaAspirante(int id);
        Task DeleteRespuestaPruebaAspirante(RespuestaPruebaAspirante respuestapruebaaspirante);
        Task<RespuestaPruebaAspirante> AddRespuestaPruebaAspirante(RespuestaPruebaAspirante respuestapruebaaspirante);
        Task UpdateRespuestaPruebaAspirante(RespuestaPruebaAspirante respuestapruebaaspirante);
    }
}
