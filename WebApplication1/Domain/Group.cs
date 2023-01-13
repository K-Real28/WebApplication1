using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Domain.BaseModels;

namespace WebApplication1.Domain
{
    public class Group : NamedBaseEnity
    {
        public int Year { get; set; }

        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public int? SpecialId { get; set; }
        [ForeignKey("SpecialId")]
        public Special Special { get; set; }

        [ForeignKey("Curator")]
        public int? CuratorId { get; set; }
        public Instructor Curator { get; set; }

        public IList<Student> Students { get; set; } = new List<Student>();
    }
}
