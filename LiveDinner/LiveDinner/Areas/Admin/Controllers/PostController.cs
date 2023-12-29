using LiveDinner.Models;
using LiveDinner.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LiveDinner.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly DataContext _context;
        public PostController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var mnList = _context.Posts.OrderBy(m => m.PostID).ToList();
            return View(mnList);
        }
        public IActionResult Details(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = _context.Posts.Find(id);

            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        public IActionResult Edit(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Posts.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post mn)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Posts.Find(id);

            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }


        [HttpPost]


        public IActionResult Delete(long id)
        {
            var deleMenu = _context.Posts.Find(id);
            if (deleMenu == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(deleMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

