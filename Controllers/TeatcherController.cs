using AlRayan.Data;
using AlRayan.Models.MainEntity;
using AlRayan.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AlRayan.Controllers
{
    public class TeatcherController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ITeatcherService _teatcher;
        private readonly ICenterService _Center;
        private readonly ICourseService _Course;

        private string UserId { get { return User.FindFirstValue(ClaimTypes.NameIdentifier); } }

        public TeatcherController(ApplicationDbContext db, ITeatcherService teatcher, ICenterService center, ICourseService course)
        {
            _db = db;
            _teatcher = teatcher;
            _Center = center;
            _Course = course;
        }
        public IActionResult Index()
        {
            var teatcher = _db.Users.Where(x => x.Id == UserId).FirstOrDefault();
            return View(teatcher);
        }
        public IActionResult AdminIndex()
        {
            var teatchers = _db.Teatchers.Include(a => a.User)
                .Include(a=>a.Center)
                .Include(c=>c.Course)
                .ToList();
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
            EditTeatcherForm viewModel = new ()
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
        public async Task<IActionResult> Edit(EditTeatcherForm model)
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
            _db.SaveChanges();

            return RedirectToAction("AdminIndex");
        }
    }
}
