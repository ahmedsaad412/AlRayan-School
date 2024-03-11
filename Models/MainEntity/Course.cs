namespace AlRayan.Models.MainEntity
{
    public class Course
    {
        public int Id { get; set; }
        public  string  Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Course()
        {
            Teatchers = new HashSet<Teatcher>();
            Students = new HashSet<Student_Course>();
        }

        public int CenterId { get; set; }
        public Center Center { get; set; }

        public ICollection<Teatcher> Teatchers { get; set; }
        public ICollection<Student_Course> Students { get; set; }
    }
}
