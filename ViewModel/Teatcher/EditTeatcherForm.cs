namespace AlRayan.ViewModel.Teatcher
{
    public class EditTeatcherForm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        
        public int CenterId { get; set; }
        public IEnumerable<SelectListItem> Centers { get; set; } = Enumerable.Empty<SelectListItem>();
        public int CourseId { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
