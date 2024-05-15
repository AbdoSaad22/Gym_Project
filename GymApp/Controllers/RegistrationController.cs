using GymApp.Data;
using GymApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.IO;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.Web;

namespace GymApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IHostingEnvironment _host;
        public AppDbContext _db;

        public RegistrationController(AppDbContext db, IHostingEnvironment host)
        {
            _db = db;
            _host = host;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult add()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult add(IFormCollection res, IFormFile file)
        {
            string filename = string.Empty;
            User u = new User();
            u.SSN = res["SSN"];
            u.email = res["email"];
            u.password = res["password"];
            u.type = res["type"];
            _db.Users.Add(u);
            if (res["type"] == "Owner")
            {
                Owner o = new Owner();
                o.name = res["name"];
                o.SSN = res["SSN"];
                o.email = res["email"];
                o.password = res["password"];
                o.age = Convert.ToInt32(res["age"]);
                o.phoneNum = res["phoneNum"];
                o.clientfile = file;

                if (o.clientfile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    filename = o.clientfile.FileName;
                    string fullpath = Path.Combine(myUpload, filename);
                    o.clientfile.CopyTo(new FileStream(fullpath, FileMode.Create));
                    o.imagePath = filename;
                    MemoryStream stream = new MemoryStream();
                    o.clientfile.CopyTo(stream);
                    o.dbImage = stream.ToArray();
                }
                _db.Owners.Add(o);
            }
            else if (res["type"] == "Trainee")
            {
                Trainee t = new Trainee();
                t.name = res["name"];
                t.SSN = res["SSN"];
                t.email = res["email"];
                t.password = res["password"];
                t.age = Convert.ToInt32(res["age"]);
                t.phoneNum = res["phoneNum"];


                if (t.clientfile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    filename = t.clientfile.FileName;
                    string fullpath = Path.Combine(myUpload, filename);
                    t.clientfile.CopyTo(new FileStream(fullpath, FileMode.Create));
                    t.imagePath = filename;

                }

                _db.Trainees.Add(t);
            }
            else
            {
                Coach c = new Coach();
                c.name = res["name"];
                c.SSN = res["SSN"];
                c.email = res["email"];
                c.password = res["password"];
                c.age = Convert.ToInt32(res["age"]);
                c.phoneNum = res["phoneNum"];


                if (c.clientfile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    filename = c.clientfile.FileName;
                    string fullpath = Path.Combine(myUpload, filename);
                    c.clientfile.CopyTo(new FileStream(fullpath, FileMode.Create));
                    c.imagePath = filename;

                }

                _db.Coachs.Add(c);

            }
            _db.SaveChanges();
            return RedirectToAction("add");

        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(User res)
        {

            var u = _db.Users.FirstOrDefault(t => t.email == res.email);
            if (u == null || u.password != res.password)
            {
                TempData["ErrorMessage"] = "incorrect email or password";
                return RedirectToAction("login");
            }
        
            HttpContext.Session.SetString("SSN", u.SSN);
            TempData["SuccessMessage"] = "you've successfully logged in";
            if (u.type == "Owner")
            {
                return RedirectToAction("Index","Owner",u);
            }
            else if (u.type == "Trainee")
                return RedirectToAction("Index", "Trainee", u);
            return RedirectToAction("Index", "Coach", u);
          
        }
    }
}