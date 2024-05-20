using Microsoft.AspNetCore.Mvc;

namespace Pronia_Front_to_Backend.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
