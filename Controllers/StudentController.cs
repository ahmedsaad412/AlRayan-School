using Microsoft.AspNetCore.Mvc;

namespace AlRayan.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
