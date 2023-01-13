using WebApplication1.Domain;

namespace WebApplication1.Interfaces
{
    public interface ISpecialService
    {
        Task<List<Special>> GetSpecials();
        Special? GetById(int? id);
        Task Create(Special special);
        void Update(Special special);
        void Delete(int id);
        bool SpecialExists(int id);
    }
}
