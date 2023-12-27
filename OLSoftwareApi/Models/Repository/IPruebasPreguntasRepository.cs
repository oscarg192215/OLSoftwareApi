namespace OLSoftwareApi.Models.Repository
{
    public interface IPruebasPreguntasRepository
    {
        Task<List<PruebasPreguntas>> GetlistPruebasPreguntas();
        Task<PruebasPreguntas> GetPruebasPreguntas(int id);
        Task DeletePruebasPreguntas(PruebasPreguntas pruebaspreguntas);
        Task<PruebasPreguntas> AddPruebasPreguntas(PruebasPreguntas pruebaspreguntas);
        Task UpdatePruebasPreguntas(PruebasPreguntas pruebaspreguntas);
    }
}
