using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Domain.BaseModels;

namespace WebApplication1.Domain
{
    public class Student : BaseEntity
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }

        public Group Group { get; set; }
    }
}
