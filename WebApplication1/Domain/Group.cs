using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Domain
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
