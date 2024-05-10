using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
{
    public class CoachController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
