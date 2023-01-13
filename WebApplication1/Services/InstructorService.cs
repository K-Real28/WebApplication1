using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class InstructorService : IInstructorService
    {
        private AppDbContext _context;

        public InstructorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Instructor>> GetInstructors()
        {
            return (await _context.Instructors.ToListAsync());
        }

        public Instructor? GetById(int? id)
        {
            var instructor = _context.Instructors
                .FirstOrDefault(_ => _.Id == id);
            return instructor;
        }

        public async Task Create(Instructor instructor)
        {
            _context.Add(instructor);
            await _context.SaveChangesAsync();
        }

        public void Update(Instructor instructor)
        {
            var item = GetById(instructor.Id);

            if (item == null)
            {
                return;
            }

            item.FullName = instructor.FullName;
            item.Phone = instructor.Phone;

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

        public bool InstructorExists(int id)
        {
            return _context.Instructors.Any(e => e.Id == id);
        }
    }
}
