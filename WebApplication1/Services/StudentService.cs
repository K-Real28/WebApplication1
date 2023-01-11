using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class StudentService : IStudentService
    {
        private AppDbContext _context;

        public StudentService(AppDbContext context) 
        { 
            _context = context;
        }

        public async Task<List<Student>> GetStudents()
        { 
            return(await _context.Students.ToListAsync());
        }

        public Student? GetById(int? id)
        {
            var student = _context.Students
                .FirstOrDefault(_ => _.Id == id);
            return student;
        }

        public async Task Create(Student student)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
        }

        public void Update(Student student)
        {
            var item = GetById(student.Id);

            if (item == null)
            {
                return;
            }

            item.FullName = student.FullName;
            item.Phone = student.Phone;
            //item.Photo = student.Photo;
            //item.Group = student.Group;

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

        public bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
