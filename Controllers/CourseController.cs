using AlRayan.Data;
using AlRayan.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlRayan.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ICourseService _course;
        private readonly ICenterService _center;

        public CourseController(ApplicationDbContext db, ICourseService course, ICenterService center)
        {
            _db = db;
            _course = course;
            _center = center;
        }
        public IActionResult Index()

        {

            var courses = _db.Courses.Include(c => c.Center)
                .ThenInclude(t => t.User)
                .AsNoTracking()
                .ToList();
            return View(courses);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var course = _course.GetById(id);
            if (course is null)
            {
                return NotFound();
            }
            return View(course);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _course.GetById(id);
            if (course is null)
            {
                return NotFound();
            }
            EditCourseForm viewModel = new()

            {
                Id = id,
                Name = course.Name,
                Hours = course.Hours,
                Description = course.Description,
                CenterId = course.CenterId,
                Centers = _center.GetSelectList(),
                studentNumber = course.Students.Count(),
                teatcherNumber = course.Teatchers.Count(),

            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCourseForm model)
        {
            if (!ModelState.IsValid)
            {
                model.Centers = _center.GetSelectList();
                return View(model);
            }
            var course = await _course.Update(model);
            if (course is null)
                return BadRequest();
            return RedirectToAction(nameof(Index));

        }

        public ActionResult SoftDelete(int id)
        {
            var course = _course.GetById(id);
            if (course is null)
            {
                return NotFound();
            }
            
                course.IsDeleted = true;
                _db.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
