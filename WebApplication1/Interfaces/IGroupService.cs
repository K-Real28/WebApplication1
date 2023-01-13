using WebApplication1.Domain;

namespace WebApplication1.Interfaces
{
    public interface IGroupService
    {
        Task<List<Group>> GetGroups();
        Group? GetById(int? id);
        Task Create(Group group);
        void Update(Group group);
        void Delete(int id);
        bool GroupExists(int id);
    }
}
