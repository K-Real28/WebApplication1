using WebApplication1.ViewModels.BaseViewModels;

namespace WebApplication1.ViewModels
{
    public class InstructorViewModel : BaseEntityViewModel
    {
        public string FullName { get; set; }
        public string Phone { get; set; }

        public GroupViewModel Group { get; set; }
    }
}
