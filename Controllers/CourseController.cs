using Microsoft.AspNetCore.Mvc;

namespace AlRayan.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
