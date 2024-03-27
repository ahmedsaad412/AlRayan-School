
namespace AlRayan.IService
{
    public interface IStudentService : IBase
    {
        List<CourseName> GetMyCourses(string userId);
        Task AssignCourse(ChooseCourseViewModel model);
    }
}
