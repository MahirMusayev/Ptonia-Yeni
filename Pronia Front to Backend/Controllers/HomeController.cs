using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_Front_to_Backend.DataAccesLayer;
using Pronia_Front_to_Backend.ViewModels;

namespace Pronia_Front_to_Backend.Controllers
{
    public class HomeController : Controller
    {
		private readonly ProniaContext _context;
		public HomeController(ProniaContext context)
		{
			_context = context;
		}

		public async Task<IActionResult>  Index()
        {
			HomeVM vm = new HomeVM
			{
				Categories = await _context.Categories.ToListAsync(),
				Sliders = await _context.Sliders.ToListAsync(),

			};
			return View(vm);
        }
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
