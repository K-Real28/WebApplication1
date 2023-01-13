using WebApplication1.ViewModels.BaseViewModels;

namespace WebApplication1.ViewModels
{
    public class StudentViewModel : BaseEntityViewModel
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }

        public GroupViewModel Group { get; set; }
    }
}
