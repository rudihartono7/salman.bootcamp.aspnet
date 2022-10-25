using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RAS.Bootcamp.Catalog.Mvc.Net.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}