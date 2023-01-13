using WebApplication1.Domain;

namespace WebApplication1.Interfaces
{
    public interface IInstructorService
    {
        Task<List<Instructor>> GetInstructors();
        Instructor? GetById(int? id);
        Task Create(Instructor instructor);
        void Update(Instructor instructor);
        void Delete(int id);
        bool InstructorExists(int id);
    }
}
