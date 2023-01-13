using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class SpecialService : ISpecialService
    {
        private AppDbContext _context;

        public SpecialService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Special>> GetSpecials()
        {
            return (await _context.Specials.ToListAsync());
        }

        public Special? GetById(int? id)
        {
            var special = _context.Specials
                .FirstOrDefault(_ => _.Id == id);
            return special;
        }

        public async Task Create(Special special)
        {
            _context.Add(special);
            await _context.SaveChangesAsync();
        }

        public void Update(Special special)
        {
            var item = GetById(special.Id);

            if (item == null)
            {
                return;
            }

            item.Title = special.Title;

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

        public bool SpecialExists(int id)
        {
            return _context.Specials.Any(e => e.Id == id);
        }
    }
}
