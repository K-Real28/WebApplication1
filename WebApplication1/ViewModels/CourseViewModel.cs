using WebApplication1.ViewModels.BaseViewModels;

namespace WebApplication1.ViewModels
{
    public class CourseViewModel : NameBaseEntityViewModel
    {
        public IList<GroupViewModel> Groups { get; set; }
    }
}
