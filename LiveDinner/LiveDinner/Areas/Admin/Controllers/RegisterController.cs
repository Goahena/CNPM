using LiveDinner.Models;
using LiveDinner.Utilities;
using Microsoft.AspNetCore.Mvc;
using LiveDinner.Areas.Admin.Models;

namespace Startup.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly DataContext _context;

        public RegisterController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            var check = _context.Users.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                Functions._MessageEmail = "Duplicate Email!";
                return RedirectToAction("Index", "Register");
            }
            Functions._MessageEmail = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}
