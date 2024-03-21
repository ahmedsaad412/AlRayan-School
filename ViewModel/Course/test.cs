namespace AlRayan.ViewModel.Course
{
    public class Test
    {
        public string name { get; set; }
        public string description { get; set; }
        public int hours { get; set; }

        public int centerId { get; set; }
        public IEnumerable<SelectListItem> centers { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
