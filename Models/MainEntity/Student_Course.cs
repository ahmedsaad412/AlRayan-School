namespace AlRayan.Models.MainEntity
{
    public class Student_Course
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;

        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
