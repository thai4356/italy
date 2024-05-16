using Italian_Restaurant_1.Models;
using Italian_Restaurant_1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Italian_Restaurant_1.ViewComponents
{
	public class CategoryViewComponent : ViewComponent
	{
		private readonly RecipeCategoryInterface _CategoryRecipe;
		public CategoryViewComponent(RecipeCategoryInterface CategoryRecipe)
		{
			_CategoryRecipe = CategoryRecipe;
		}
	
		public IViewComponentResult Invoke()
		{
			var category = _CategoryRecipe.GetAllCategory().OrderBy(x=>x.CatId);
			return View(category);
		}
	}
}
