using AlRayan.Models.MainEntity;
using AlRayan.ViewModel.Course;
using AlRayan.ViewModel.Teatcher;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlRayan.IService
{
    public interface ICourseService : IBase
    {
        Course? GetById(int id);
        IEnumerable<Course> GetAllCourses();
        IEnumerable<Teatcher> GetAllTeatchersInCourse(int id);
        Task Create(AssignCourseFormViewModel model);
        int RemoveTeatchersInCourse(IEnumerable<Teatcher> relatedTeatchers);
        Task<Course?> Update(EditCourseFormViewModel model);

    }
}
