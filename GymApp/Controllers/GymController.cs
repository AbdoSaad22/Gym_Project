using Microsoft.AspNetCore.Mvc;
using GymApp.Data;
using GymApp.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
namespace GymApp.Controllers
{
    public class GymController : Controller
    {
        public AppDbContext _db;
        public GymController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult show(int id)
        {
            Gym g = _db.Gym.Find(id);
            if (g.Trainee_Gyms==null) TempData["trainees"] = 0;
            else TempData["trainees"] = g.Trainee_Gyms.Count();
            if (g.Coach_Gyms==null) TempData["coaches"] = 0;
            else TempData["coaches"] = g.Coach_Gyms.Count();
            return View(g);
        }
    }
}
