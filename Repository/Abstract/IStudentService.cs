namespace AlRayan.Repository.Abstract
{
    public interface IStudentService:IBase
    {
        Task AssignCourse(ChooseCourseViewModel model);

    }
}
