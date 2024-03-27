using Microsoft.AspNetCore.Mvc;
namespace AlRayan.Controllers
{

    public class CourseController : Controller
    {
        private readonly ICourseService _course;
        private readonly ICenterService _center;
        public CourseController(ICourseService course, ICenterService center)
        {
            _course = course;
            _center = center;
        }
        public IActionResult Index()

        {
            return View();
        }
        public IActionResult GetCourses()
        {
            var courses = _course.GetAllCourses();
            
            return Json(new {data = courses });
        }
        [HttpGet]
        public IActionResult Details(int id)
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
            EditCourseFormViewModel viewModel = new()
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
        public async Task<IActionResult> Edit(EditCourseFormViewModel model)
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
            var relatedTeatcher = _course.GetAllTeatchersInCourse(id);
            var x = _course.RemoveTeatchersInCourse(relatedTeatcher);
            if (x > 0) 
            {
                return RedirectToAction("Index"); 
            }  
            return BadRequest();
        }
    }
}
