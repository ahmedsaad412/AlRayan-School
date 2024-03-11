using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlRayan.ViewModel.Teatcher
{
    public class AssignTeatcherForm
    {
        public bool IsMarried { get; set; }
       

        /// <summary>
        /// relations
        /// </summary>
        public string UserId { get; set; }
        public IEnumerable<SelectListItem> Teatchers{ get; set; }=Enumerable.Empty<SelectListItem>();
        public int CenterId { get; set; }
        public IEnumerable<SelectListItem> Centers { get; set; } = Enumerable.Empty<SelectListItem>();
        public int CourseId { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
