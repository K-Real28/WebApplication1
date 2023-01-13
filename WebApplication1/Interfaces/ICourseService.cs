using System.Threading.Tasks;
using WebApplication1.Domain;

namespace WebApplication1.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetCourses();
        Course? GetById(int? id);
        Task Create(Course course);
        void Update(Course course);
        void Delete(int id);
        bool CourseExists(int id);
    }
}
