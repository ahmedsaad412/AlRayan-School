namespace AlRayan.Models.MainEntity
{
    public class Center
    {
        public int Id { get; set; }
        public string CenterName { get; set; }
        public bool IsDeleted { get; set; }=false;

        public Center()
        {
            Teatchers = new HashSet<Teatcher>();
            Courses = new HashSet<Course>();
        }
        ICollection<Teatcher> Teatchers { get; set; }
        ICollection<Course> Courses { get; set; }

        //1-m user

        public required string UserId { get; set; }
        public   ApplicationUser User { get; set; }
    }
}
