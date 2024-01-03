using LiveDinner.Areas.Admin.Models;
using LiveDinner.Models;
using LiveDinner.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LiveDinner.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var mnList = _context.Users.OrderBy(m => m.UserID).ToList();
            return View(mnList);
        }
        public IActionResult Delete(int id)
        {
            var deleMenu = _context.Users.Find(id);
            if (deleMenu == null)
            {
                return NotFound();
            }
            _context.Users.Remove(deleMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Users.Find(id);
            mn.Password = Functions.MD5Password(mn.Password);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User mn)
        {
            if (ModelState.IsValid)
            {
                mn.Password = Functions.MD5Password(mn.Password);
                _context.Users.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
    }
}

