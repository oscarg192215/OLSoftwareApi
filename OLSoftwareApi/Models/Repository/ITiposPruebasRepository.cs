using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public interface ITiposPruebasRepository
    {
        Task<List<TiposPruebas>> GetlistTiposPruebas();
        Task<TiposPruebas> GetTiposPruebas(int id);
        Task DeleteTiposPruebas(TiposPruebas tipospruebas);
        Task<TiposPruebas> AddTiposPruebas(TiposPruebas tipospruebas);
        Task UpdateTiposPruebas(TiposPruebas tipospruebas);
    }
}
