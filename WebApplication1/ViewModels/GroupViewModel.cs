using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Domain;
using WebApplication1.ViewModels.BaseViewModels;

namespace WebApplication1.ViewModels
{
    public class GroupViewModel : NameBaseEntityViewModel
    {
        public int Year { get; set; }

        public int? CourseId { get; set; }
        public CourseViewModel Course { get; set; }

        public int? SpecialId { get; set; }
        public SpecialViewModel Special { get; set; }

        public int? CuratorId { get; set; }
        public InstructorViewModel Curator { get; set; }

        public IList<StudentViewModel> Students { get; set; }
    }
}
