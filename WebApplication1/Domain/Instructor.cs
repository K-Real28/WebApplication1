using WebApplication1.Domain.BaseModels;

namespace WebApplication1.Domain
{
    public class Instructor : BaseEntity
    {
        public string FullName { get; set; }
        public string Phone { get; set; }

        public Group Group { get; set; }

    }
}
