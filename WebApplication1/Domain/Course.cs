using WebApplication1.Domain.BaseModels;

namespace WebApplication1.Domain
{
    public class Course : NamedBaseEnity
    {
        public IList<Group> Groups { get; set; } = new List<Group>();
    }
}
