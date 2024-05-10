using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
{
    public class GymController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
