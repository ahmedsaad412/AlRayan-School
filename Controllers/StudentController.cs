using AlRayan.Data;
using AlRayan.Models.MainEntity;
using AlRayan.Repository.Abstract;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AlRayan.Controllers
{
    [Authorize(Roles ="Student")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ICourseService _course;
        private readonly IStudentService _student;

        private string UserId { get { return User.FindFirstValue(ClaimTypes.NameIdentifier); } }

        public StudentController(ApplicationDbContext db, ICourseService course, IStudentService student)
        {
            _db = db;
            _course = course;
            _student = student;
        }
        public IActionResult Index()
        { 
            
            var student= _db.Users.Where(x=>x.Id==UserId).FirstOrDefault();
            List<CourseName> CoursesName= new List<CourseName>();
            if (student is not null)
            {
                 CoursesName = _db.Student_Courses
                    .Include(s=>s.Student)
                    .Include(c=>c.Course)
                    .Where(c=>c.Student.UserId==UserId)
                    .Select(s => new CourseName { Name=s.Course.Name} )
                    .ToList();
                //var courses = _db.Students
                 //   .Include(sc => sc.Courses)
                 //   .ThenInclude(c => c.Course)
                 //   .Where(i => i.UserId == student.Id)
                 //   .ToList();
               

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
