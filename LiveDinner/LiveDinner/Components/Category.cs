using LiveDinner.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveDinner.Components
{
	[ViewComponent(Name = "Category")]
	public class Category : ViewComponent
	{
		private DataContext _context;
		public Category(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listofcategory = (from m in _context.Products
								  join r in _context.categories on m.CategoryID equals r.CategoryID
								  where (m.IsActive == true)
								  select m).Take(9).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", listofcategory));
		}
	}
}
