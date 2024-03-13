namespace AlRayan.ViewModel.Student
{
    public class ChooseCourseViewModel
    {
       
        public string? UserId { get; set; }
        public int CourseId { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
