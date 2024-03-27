using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AlRayan.Controllers
{
    public class TeatcherController : Controller
    {
        private readonly ITeatcherService _teatcher;
        private readonly ICenterService _Center;
        private readonly ICourseService _Course;
        private readonly IUserData _userData;
        private string UserId { get { return User.FindFirstValue(ClaimTypes.NameIdentifier); } }
        public TeatcherController(ITeatcherService teatcher, ICenterService center, ICourseService course, IUserData userData)
        {
            _teatcher = teatcher;
            _Center = center;
            _Course = course;
            _userData = userData;
        }
        public IActionResult Index()
        {
            var teatcher = _userData.GetSignInUser(UserId);
            return View(teatcher);
        }
        public IActionResult AdminIndex()
        {
            var teatchers = _teatcher.GetAllTeatchers();
            return View(teatchers);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var teatcher = _teatcher.GetById(id);
            if (teatcher is null)
            {
                return NotFound();
            }
            return View(teatcher);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var teatcher = _teatcher.GetById(id);
            if (teatcher is null)
            {
                return NotFound();
            }
            EditTeatcherFormViewModel viewModel = new ()
            {
               Id=id,
               CenterId=teatcher.CenterId,
               CourseId=teatcher.CourseId,
               Courses=_Course.GetSelectList(),
               Centers=_Center.GetSelectList(),
               Name=teatcher.User.FirstName +" "+teatcher.User.LastName,
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditTeatcherFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Centers = _Center.GetSelectList();
                return View(model);
            }
            var teatcher = await _teatcher.Update(model);
            if (teatcher is null)
                return BadRequest();
            return RedirectToAction("AdminIndex");
        }

        public ActionResult SoftDelete(int id)
        {
            var teatcher = _teatcher.GetById(id);
            if (teatcher is null)
            {
                return NotFound();
            }
             teatcher.IsDeleted = true;
            _teatcher.Save();
            return RedirectToAction("AdminIndex");
        }
    }
}
