using Italian_Restaurant_1.Models;
using Italian_Restaurant_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Italian_Restaurant_1.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
        ItalyContext db = new ItalyContext();
        public IActionResult Index()
		{
			var ListRecipe = db.Recipes.ToList();
			var ListCategory = db.Categories.ToList();
			var viewModel = new RecipeCategoryViewModel
			{
				Recipes = ListRecipe,
				Categories = ListCategory
			};
			return View(viewModel);
		
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
