using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public interface IPruebasRepository
    {
        Task<List<Pruebas>> GetlistPruebas();
        Task<PruebaDetalleDTO> GetPruebas(int id);
        Task DeletePruebas(int id_prueba);
        Task<Pruebas> AddPruebas(PruebasDTO pruebas);
        Task UpdatePruebas(PruebasDTO pruebas);
    }
}
