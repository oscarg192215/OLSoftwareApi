using OLSoftwareApi.Models.DTO;

namespace OLSoftwareApi.Models.Repository
{
    public interface IDetalleRepository
    {
        public DetalleDTO GetDetalle(int id);
    }
}   
