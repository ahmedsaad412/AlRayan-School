using Microsoft.AspNetCore.Mvc;

namespace AlRayan.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
