namespace AlRayan.ViewModel.Course
{
    public class EditCourseForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public int studentNumber { get; set; }
        public int teatcherNumber { get; set; }
        public int CenterId { get; set; }
        public IEnumerable<SelectListItem> Centers { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
