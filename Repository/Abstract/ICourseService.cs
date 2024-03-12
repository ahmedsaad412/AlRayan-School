using AlRayan.Models.MainEntity;
using AlRayan.ViewModel.Course;
using AlRayan.ViewModel.Teatcher;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlRayan.Repository.Abstract
{
    public interface ICourseService :IBase
    {
        Task Create(AssignCourseForm model);
        Course? GetById(int id);
        Task<Course?> Update(EditCourseForm model);

    }
}
