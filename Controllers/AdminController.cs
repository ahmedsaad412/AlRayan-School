using AlRayan.Data;
using AlRayan.Models.MainEntity;
using AlRayan.Repository.Abstract;
using AlRayan.ViewModel.Course;
using AlRayan.ViewModel.Teatcher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AlRayan.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly RoleManager<IdentityRole> _roleManger;
        private readonly ApplicationDbContext _db;
        private readonly ICenterService _center;
        private readonly ITeatcherService _teatcher;
        private readonly ICourseService _course;
        private readonly IStudentService _student;
        public AdminController(ApplicationDbContext db, RoleManager<IdentityRole> roleManger, UserManager<ApplicationUser> userManger, ICenterService center, ICourseService course, ITeatcherService teatcher, IStudentService student)
        {
            _db = db;
            _roleManger = roleManger;
            _userManger = userManger;
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
            AssignTeatcherForm viewModel = new()
            {
                Centers = _center.GetSelectList(),

                Courses = _course.GetSelectList(),

                Teatchers = _teatcher.GetSelectList(),

            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignTeatcher(AssignTeatcherForm model)
        {
            if (!ModelState.IsValid)
            {
                model.Centers = _center.GetSelectList();

                model.Courses = _course.GetSelectList();

                model.Teatchers = _teatcher.GetSelectList();

                return View(model);
            }
            await _teatcher.Create(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AssignCourse()
        {
            AssignCourseForm viewModel = new()
            {
                Centers = _center.GetSelectList(),

            };
            return View(viewModel);
            
        }
        [HttpPost ]
        public async Task<IActionResult> AddCourse(AssignCourseForm model)
        {
            if (!ModelState.IsValid) return BadRequest("Enter required fields");
            await _course.Create(model);
            return Ok($"Form Data received!");

            //{
            //    if (!ModelState.IsValid)
            //    {
            //        model.Centers = _center.GetSelectList();
            //        return View(model);
            //    }
            //      _course.Create(model);
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
