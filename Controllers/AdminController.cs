using AlRayan.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlRayan.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICenterService _center;
        private readonly ITeatcherService _teatcher;
        private readonly ICourseService _course;
        private readonly IStudentService _student;
        public AdminController( ICenterService center, ICourseService course, ITeatcherService teatcher, IStudentService student)
        {
            _center = center;
            _course = course;
            _teatcher = teatcher;
            _student = student;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AssignTeatcher()
        {
            AssignTeatcherFormViewModel viewModel = new()
            {
                Centers = _center.GetSelectList(),

                Courses = _course.GetSelectList(),

                Teatchers = _teatcher.GetSelectListDistinct(),
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignTeatcher(AssignTeatcherFormViewModel model)
        {
          
            if (!ModelState.IsValid)
            {
                model.Centers = _center.GetSelectList();

                model.Courses = _course.GetSelectList();

                model.Teatchers =_teatcher.GetSelectListDistinct();

                return View(model);
            }
            await _teatcher.Create(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AssignCourse()
        {
            AssignCourseFormViewModel viewModel = new()
            {
                Centers = _center.GetSelectList(),

            };
            return View(viewModel);
            
        }
        [HttpGet]
        public IActionResult TestAssignCourse()
        {
            AssignCourseFormViewModel viewModel = new()
            {
                Centers = _center.GetSelectList(),

            };
            return View(viewModel);
            
        }
        [HttpPost ]
        public async Task<IActionResult> AddCourse(AssignCourseFormViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Enter required fields");
            await _course.Create(model);
            return Ok($"Form Data received!");

           
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddCourse(AssignCourseForm model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        model.Centers = _center.GetSelectList();

        //        //model.Students = _student.GetSelectList();

        //        //model.Teatchers = _teatcher.GetSelectList();

        //        return View(model);
        //    }
        //    await _course.Create(model);
        //    return RedirectToAction(nameof(Index));
        //}
    }
    }
