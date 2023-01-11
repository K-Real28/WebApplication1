using WebApplication1.Domain;

namespace WebApplication1.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Student? GetById(int? id);
        Task Create(Student student);
        void Update(Student student);
        void Delete(int id);
        bool StudentExists(int id);
    }
}
