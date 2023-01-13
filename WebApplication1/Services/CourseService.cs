using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class CourseService : ICourseService
    {
        private AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetCourses()
        {
            return (await _context.Courses.ToListAsync());
        }

        public Course? GetById(int? id)
        {
            var course = _context.Courses
                .FirstOrDefault(_ => _.Id == id);
            return course;
        }

        public async Task Create(Course course)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
        }

        public void Update(Course course)
        {
            var item = GetById(course.Id);

            if (item == null)
            {
                return;
            }

            item.Name = course.Name;         

            _context.Update(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);

            if (item == null)
                return;

            _context.Remove(item);
            _context.SaveChanges();
        }

        public bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
