using AlRayan.ViewModel.Course;
using AlRayan.ViewModel.Teatcher;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlRayan.Repository.Abstract
{
    public interface ICourseService :IBase
    {
        Task Create(AssignCourseForm model);

    }
}
