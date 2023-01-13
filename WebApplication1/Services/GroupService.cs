using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class GroupService : IGroupService
    {
        private AppDbContext _context;

        public GroupService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Group>> GetGroups()
        {
            return (await _context.Groups.ToListAsync());
        }

        public Group? GetById(int? id)
        {
            var group = _context.Groups
                .FirstOrDefault(_ => _.Id == id);
            return group;
        }

        public async Task Create(Group group)
        {
            _context.Add(group);
            await _context.SaveChangesAsync();
        }

        public void Update(Group group)
        {
            var item = GetById(group.Id);

            if (item == null)
            {
                return;
            }

            // item.Course = group.Course;
            // item.Curator = group.Curator;
            // item.Special = group.Special;
            item.Year = group.Year;
            item.Name = group.Name;

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

        public bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}
