using Italian_Restaurant_1.Models;
using Italian_Restaurant_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using Italian_Restaurant_1.Models.Authentication;
using X.PagedList;

namespace Italian_Restaurant_1.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		ItalyContext db = new ItalyContext();
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		
		//[Authentication]
		public IActionResult Index(int? page)
		{
			int pageSize = 5;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var ListRecipe = db.Recipes.AsNoTracking().OrderBy(x => x.RecipeName);
			PagedList <Recipe> lst = new PagedList<Recipe>(ListRecipe, pageNumber, pageSize); 
			//var ListCategory = db.Categories.ToList();
			//var viewModel = new RecipeCategoryViewModel
			//{
			//	Recipes = ListRecipe,
			//	Categories = ListCategory
			//};
			return View(lst);		
		}

		public IActionResult RecipeDetail(int maSp)
		{
			var Recipe = db.Recipes.SingleOrDefault(x => x.RecipeId == maSp); 
			var img = db.Recipes.Where(x => x.RecipeId == maSp).ToList(); 
			ViewBag.img = img;
			return View(Recipe);
		}

		public IActionResult CategoryRecipe(int maLoai)
		{
			List<Recipe> ListRecipe = db.Recipes.Where(x => x.Category == maLoai).OrderBy(x => x.RecipeName).ToList();
			return View(ListRecipe);
			
		}

       

        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
