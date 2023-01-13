using WebApplication1.ViewModels.BaseViewModels;

namespace WebApplication1.ViewModels
{
    public class SpecialViewModel : BaseEntityViewModel
    {
        public string Title { get; set; }
        public IList<GroupViewModel> Groups { get; set; }
    }
}
