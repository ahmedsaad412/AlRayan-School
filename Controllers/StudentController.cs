using AlRayan.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AlRayan.Controllers
{
    [Authorize(Roles ="Student")]
    public class StudentController : Controller
    {
        private readonly ICourseService _course;
        private readonly IStudentService _student;
        private readonly IUserData _userData;
        private string UserId { get { return User.FindFirstValue(ClaimTypes.NameIdentifier); } }
        public StudentController(ICourseService course, IStudentService student, IUserData userData)
        {
            _course = course;
            _student = student;
            _userData = userData;
        }
        public IActionResult Index()
        {
            var student = _userData.GetSignInUser(UserId);
            List<CourseName> CoursesName= new List<CourseName>();
            if (student is not null)
            {
                CoursesName = _student.GetMyCourses(UserId);
            }
            StudentIndexViewModel viewModel = new() { 
             Photo=student.Photo,
             Name=student.FirstName+" "+student.LastName,
             CoursesName= CoursesName
            };
            return View(viewModel);        
        }
        [HttpGet]
        public IActionResult ChooseCourse()
        {
            ChooseCourseViewModel viewModel = new()
            {
                Courses = _course.GetSelectList()
            };
               return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChooseCourse(ChooseCourseViewModel model)
        {
            model.UserId = UserId;
            if (!ModelState.IsValid)
            {
                model.Courses = _course.GetSelectList();
                return View(model);
            }
            await _student.AssignCourse(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
