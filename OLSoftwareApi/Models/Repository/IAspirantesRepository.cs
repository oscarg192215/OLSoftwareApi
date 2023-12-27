using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public interface IAspirantesRepository
    {
        Task<List<AspiranteDetalleDTO>> GetlistAspirantes();
        Task<AspiranteDetalleDTO> GetAspirantes(int id);
        Task DeleteAspirantes(int id_prueba_aspirante, int id_aspirante);
        Task AddAspirantes(Aspirantes aspirantes);
        Task UpdateAspirantes(Aspirantes aspirantes);
    }
}
