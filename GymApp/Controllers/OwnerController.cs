using GymApp.Data;
using GymApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;

namespace GymApp.Controllers
{
    public class OwnerController : Controller
    {
        public AppDbContext _db;
        public OwnerController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(User u)
        {
            Owner o = _db.Owners.FirstOrDefault(t => t.email == u.email);
            return View(o);
        }

        public IActionResult show()
        {
            
            return View();
        }
    }
}
