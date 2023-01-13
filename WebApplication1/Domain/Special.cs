using WebApplication1.Domain.BaseModels;

namespace WebApplication1.Domain
{
    public class Special : BaseEntity
    {
        public string Title { get; set; }
        public IList<Group> Groups { get; set; } = new List<Group>();
    }
}
