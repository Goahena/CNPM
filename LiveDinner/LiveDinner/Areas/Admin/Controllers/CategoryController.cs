using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LiveDinner.Utilities;
using Microsoft.Extensions.Hosting;
using LiveDinner.Models;

namespace LiveDinner.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var mnList = _context.categories.OrderBy(m => m.MenuOrder).ToList();
            return View(mnList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category cate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cate);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ct = _context.categories.Find(id);
            if (ct == null)
            {
                return NotFound();
            }
            return View(ct);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category cate)
        {
            if (ModelState.IsValid)
            {
                _context.categories.Update(cate);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cate);
        }
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cate = _context.categories.Find(id);

            if (cate == null)
            {
                return NotFound();
            }
            return View(cate);
        }

        public IActionResult Delete(int id)
        {
            var delete = _context.categories.Find(id);
            if (delete == null)
            {
                return NotFound();
            }
            _context.categories.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

