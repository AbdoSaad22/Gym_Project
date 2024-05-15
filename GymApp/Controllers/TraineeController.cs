using Microsoft.AspNetCore.Mvc;
using GymApp.Data;
using GymApp.Models;
namespace GymApp.Controllers
{
    public class TraineeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
