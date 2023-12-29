using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LiveDinner.Utilities;
using Microsoft.Extensions.Hosting;
using LiveDinner.Models;

namespace LiveDinner.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var mnList = _context.view_Pro_Cates.OrderBy(m => m.CreatedDate).ToList();
            return View(mnList);
        }

        public IActionResult Create()
        {
            var List = (from m in _context.categories
                          select new SelectListItem()
                          {
                              Text = m.CategoryName,
                              Value = m.CategoryID.ToString(),
                          }).ToList();
            List.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.List = List;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
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
            var ct = _context.Products.Find(id);
            if (ct == null)
            {
                return NotFound();
            }
            var List = (from m in _context.categories
                        select new SelectListItem()
                        {
                            Text = m.CategoryName,
                            Value = m.CategoryID.ToString(),
                        }).ToList();
            List.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.List = List;
            return View(ct);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product prod)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(prod);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prod);
        }
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = _context.Products.Find(id);

            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        public IActionResult Delete(int id)
        {
            var delete = _context.Products.Find(id);
            if (delete == null)
            {
                return NotFound();
            }
            _context.Products.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

