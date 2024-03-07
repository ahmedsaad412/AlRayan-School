namespace AlRayan.Models.MainEntity
{
    public class Student
    {
        public int Id { get; set; }
        
        public Student()
        {
            Courses = new HashSet<Student_Course>();
        }

        ICollection<Student_Course> Courses { get; set; }

        //1-m user.
        public required string UserId { get; set; }
        public  required ApplicationUser User { get; set; }
    }

}
