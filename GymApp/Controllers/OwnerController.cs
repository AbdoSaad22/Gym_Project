using GymApp.Data;
using GymApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using System.Collections.Generic;
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
        public IActionResult Index()
        {
            string temp = HttpContext.Session.GetString("SSN");
            
            Owner o = _db.Owners.Find(temp);
            return View(o);
        }

        public IActionResult show()
        {
            string temp = HttpContext.Session.GetString("SSN");
            List < Gym >gyms= _db.Gym.Where(t => t.OwnerId == temp).ToList();
            return View(gyms);
        }
        [HttpGet]
		public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult add(Gym g)
        {
            g.OwnerId = HttpContext.Session.GetString("SSN");
            _db.Gym.Add(g);
            _db.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}
