namespace AlRayan.Models.MainEntity
{
    public class Teatcher
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int CenterId { get; set; }
        public Center Center { get; set; }
        //1-m user
        public required string UserId { get; set; }
        public required ApplicationUser User { get; set; }
    }
}
