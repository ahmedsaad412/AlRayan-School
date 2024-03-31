namespace AlRayan.Models.MainEntity
{
    public class Teatcher
    {
        public int Id { get; set; }
        public bool? IsMarried { get; set; }
        public bool IsDeleted { get; set; } 

        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int CenterId { get; set; }
        public Center Center { get; set; }
        //1-m user
        public  string UserId { get; set; }
        public  ApplicationUser User { get; set; }
    }
}
