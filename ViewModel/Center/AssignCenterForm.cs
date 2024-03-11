using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlRayan.ViewModel.Center
{
    public class AssignCenterForm
    {
        public string CenterName { get; set; }
        public string UserId { get; set; }
        public IEnumerable<SelectListItem> Centers { get; set; } = Enumerable.Empty<SelectListItem>();
        public List<int> SelectedTeatchers { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> Teatchers { get; set; } = Enumerable.Empty<SelectListItem>();
        public List<int> SelectedCourses { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> Courses { get; set; } = Enumerable.Empty<SelectListItem>();
       
    }
}
