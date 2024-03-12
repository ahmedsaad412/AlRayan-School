using AlRayan.Data;
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
        private string UserId { get { return User.FindFirstValue(ClaimTypes.NameIdentifier); } }

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var student= _db.Users.Where(x=>x.Id==UserId).FirstOrDefault();
            return View(student);
        }
    }
}
