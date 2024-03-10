using AlRayan.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlRayan.Controllers
{
    public class TeatcherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TeatcherController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var students = _db.Teatchers.Include(a => a.User)
                .Include(a=>a.Center)
                .Include(c=>c.Course)
                .ToList();
            return View(students);
        }
    }
}
