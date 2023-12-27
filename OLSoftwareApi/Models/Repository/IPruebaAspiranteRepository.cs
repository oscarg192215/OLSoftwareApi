using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public interface IPruebaAspiranteRepository
    {
        Task<List<PruebaAspirante>> GetlistPruebaAspirante();
        Task<PruebaAspirante> GetPruebaAspirante(int id);
        Task DeletePruebaAspirante(PruebaAspirante pruebaaspirante);
        Task<PruebaAspiranteDTO> AddPruebaAspirante(PruebaAspirante pruebaaspirante);
        Task UpdatePruebaAspirante(PruebaAspirante pruebaaspirante);
    }
}
